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
using Nox.Solution.Exceptions;

namespace Nox.Solution.Resolvers;

/// <summary>
/// Deserialize yaml configuration with validation.
/// </summary>
internal static class NoxYamlSerializer
{
    public static T? Deserialize<T>(string yaml)
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .WithNodeTypeResolver(new ReadOnlyCollectionNodeTypeResolver())
            .Build();

        using var sr = new StringReader(yaml);
        var yamlContent = sr.ReadToEnd();

        var yamlObject = deserializer.Deserialize<object>(yamlContent);
        var jsonDocument = JsonSerializer.SerializeToDocument(yamlObject);

        var evaluateOptions = new EvaluationOptions
        {
            OutputFormat = OutputFormat.List,
            RequireFormatValidation = true
        };

        var schema = SchemaGenerator.Generate<Solution>();
        var result = schema.Evaluate(jsonDocument, evaluateOptions);

        var errors = new List<string>();
        HandleErrorsRecursively(result, errors);

        if (errors.Count > 0)
        {
            throw new NoxSolutionConfigurationException(string.Join("\n", errors));
        }

        var obj = deserializer.Deserialize<T>(yamlContent);

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
                errors.Add($"Path: {results.EvaluationPath}. Error:  {error.Key} - {error.Value}");
            }
        }
        foreach (var detail in results.Details)
        {
            HandleErrorsRecursively(detail, errors);
        }
    }
}