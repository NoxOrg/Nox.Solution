using System.Collections.Generic;
using System.IO;
using System;
using Nox.Types;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using System.Text.Json;
using Json.Schema;
using Json.Schema.Generation;
using Nox.Solution.Schema;

namespace Nox.Solution.Resolvers;

/// <summary>
/// Deserialize yaml configuration with validation.
/// </summary>
internal static class NoxYamlSerializer
{
    public static T? Deserialize<T>(string yaml)
    {
        var schemaConfig = new SchemaGeneratorConfiguration()
        {
            PropertyNamingMethod = PropertyNamingMethods.CamelCase,
            Nullability = Nullability.AllowForNullableValueTypes,
            Refiners = { new EnumToCamelCaseRefiner(excludeTypes: new Type[] { typeof(CurrencyCode) }) },
            Generators = { new ReadOnlyStringDictionarySchemaGenerator() },
            Optimize = false,
        };

        var schema = new JsonSchemaBuilder()
           .Schema(MetaSchemas.Draft7Id)
           .FromType<T>(schemaConfig)
           .Build();

        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .WithNodeTypeResolver(new ReadOnlyCollectionNodeTypeResolver())
            .Build();

        var yamlObject = deserializer.Deserialize(new StringReader(yaml));
        var jsonDocument = JsonSerializer.SerializeToDocument(yamlObject);

        var evaluateOptions = new EvaluationOptions
        {
            OutputFormat = OutputFormat.List,
            RequireFormatValidation = true
        };

        var result = schema.Evaluate(jsonDocument, evaluateOptions);

        var errors = new List<string>();
        HandleErrorsRecursively(result, errors);

        if (errors.Count > 0)
        {
            throw new ApplicationException(string.Join("\n", errors));
        }

        var obj = jsonDocument.Deserialize<T>(new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        return obj;
    }

    private static void HandleErrorsRecursively(EvaluationResults results, List<string> errors)
    {
        if (results.Errors != null)
        {
            foreach (var error in results.Errors)
            {
                if (error.Key == "type")
                {
                    continue;
                }
                errors.Add($"{results.EvaluationPath}: {error.Key} - {error.Value}");
            }
        }
        foreach (var detail in results.Details)
        {
            HandleErrorsRecursively(detail, errors);
        }
    }
}