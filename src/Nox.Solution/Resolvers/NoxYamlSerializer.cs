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
using YamlDotNet.Core;
using System.Text.Json.Serialization;

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

        T yamlObject;
        try
        {
            yamlObject = deserializer.Deserialize<T>(yamlContent);
        }
        catch (YamlException ex)
        {
            var message = $"{ex.InnerException?.Message}. Line {ex.End.Line}, column {ex.End.Column}.";

            throw new NoxSolutionConfigurationException(message, ex);
        }

        var enumConverter = new JsonStringEnumConverter(JsonNamingPolicy.CamelCase);
        var opts = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        opts.Converters.Add(enumConverter);

        var jsonDocument = JsonSerializer.SerializeToDocument(yamlObject, opts);

        var evaluateOptions = new EvaluationOptions
        {
            OutputFormat = OutputFormat.Hierarchical,
            EvaluateAs = SpecVersion.Draft7
        };
        var schema = SchemaGenerator.Generate<T>();

        var result = schema.Evaluate(jsonDocument, evaluateOptions);
        var t = JsonSerializer.Serialize(result);

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
                if (results.EvaluationPath.ToString().EndsWith("/$ref"))
                {
                    continue;
                }
                else if (error.Key == "type")
                {
                    continue;
                }
                else if (error.Key == "enum")
                {
                    continue;
                }
                var path = string.IsNullOrEmpty(results.EvaluationPath.ToString()) ? string.Empty : $"Path: {results.EvaluationPath}. ";

                errors.Add($"{path}{error.Value} ({error.Key.ToUpper()}).");
            }
        }
        foreach (var detail in results.Details)
        {
            HandleErrorsRecursively(detail, errors);
        }
    }
}