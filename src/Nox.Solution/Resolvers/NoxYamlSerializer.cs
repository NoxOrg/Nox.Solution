using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using System.Text.Json;
using Json.Schema;
using Nox.Solution.Exceptions;
using YamlDotNet.Core;
using System.Text.Json.Serialization;
using System.Linq;
using System;

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

        var errors = new List<string>();

        var yamlObjectInstance = deserializer.Deserialize<object>(yamlContent);

        var schema = SchemaGenerator.Generate<T>();

        var evaluateOptions = new EvaluationOptions
        {
            OutputFormat = OutputFormat.Hierarchical,
            EvaluateAs = SpecVersion.Draft7
        };
        var jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
        };

        var errorsFromObjectValidation = Validate(yamlObjectInstance, jsonSerializerOptions, schema, evaluateOptions);
        errors.AddRange(errorsFromObjectValidation);

        T yamlTypedObjectInstance;
        try
        {
            yamlTypedObjectInstance = deserializer.Deserialize<T>(yamlContent);
        }
        catch (YamlException ex)
        {
            HandleYamlExceptionMessage(ex, errors);
            var message = string.Join("\n", errors);

            throw new NoxSolutionConfigurationException(message, ex);
        }

        var errorsFromTypedObjectValidation = Validate(yamlTypedObjectInstance, jsonSerializerOptions, schema, evaluateOptions);
        errors.AddRange(errorsFromTypedObjectValidation);

        if (errors.Count > 0)
        {
            throw new NoxSolutionConfigurationException(string.Join("\n", errors));
        }

        return yamlTypedObjectInstance;
    }

    private static void HandleYamlExceptionMessage(Exception? exception, List<string> errors)
    {
        if (exception is null)
        {
            return;
        }

        string message;
        if (exception is YamlException yamlException)
        {
            message = $"{yamlException.Message}. Line {yamlException.End.Line}, column {yamlException.End.Column}.";
        }
        else
        {
            message = exception.Message;
        }

        errors.Add(message);
        HandleYamlExceptionMessage(exception.InnerException, errors);
    }

    private static List<string> Validate<T>(
            T yamlObject,
            JsonSerializerOptions jsonSerializerOptions,
            JsonSchema schema,
            EvaluationOptions evaluateOptions)
    {
        var jsonDocument = JsonSerializer.SerializeToDocument(yamlObject, jsonSerializerOptions);
        var errors = new List<string>();
        var result = schema.Evaluate(jsonDocument, evaluateOptions);

        HandleErrorsRecursively(result, errors);

        return errors;
    }

    private static void HandleErrorsRecursively(EvaluationResults results, List<string> errors)
    {
        if (results.Errors != null)
        {
            foreach (var error in results.Errors)
            {
                if (results.EvaluationPath.ToString().EndsWith("/$ref")
                    || error.Key == "type"
                    )
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