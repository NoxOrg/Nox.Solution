﻿using System.Collections.Generic;
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
    /// <summary>
    /// Deserialize yaml content to T object.
    /// It deserilizes data to string then serialize to json object to validate all properties against data annotation schema.
    /// It should validate twice: first time it considers yaml content as json object to find missed required fields.
    /// If object validation carries out then consider yaml content as certain T type to find corectness of properties, whether properties
    /// match json content.
    /// </summary>
    /// <typeparam name="T">Any type corresponds to yaml content.</typeparam>
    /// <param name="yaml">Yaml file string content.</param>
    /// <returns>Deserialized T instance.</returns>
    /// <exception cref="NoxSolutionConfigurationException">Exception bring error messages caught during validation.</exception>
    public static T Deserialize<T>(string yaml)
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .WithNodeTypeResolver(new ReadOnlyCollectionNodeTypeResolver())
            .Build();

        using var sr = new StringReader(yaml);
        var yamlContent = sr.ReadToEnd();

        var errors = new List<string>();

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
        // The purpose is to deserialize yaml to object is to validate content against json schema generated from properties annotations.
        // If deserialize content to certain type then value-type properties will be initilized by default and will exist in
        // futher json serialization during the validation.
        // However, to handle a case when value-type properties are required it's neccessary to validate json where these properties are not involved.
        var yamlObjectInstance = deserializer.Deserialize<object>(yamlContent);
        var errorsFromObjectValidation = Validate(yamlObjectInstance, jsonSerializerOptions, schema, evaluateOptions);
        errors.AddRange(errorsFromObjectValidation);

        T yamlTypedObjectInstance;
        try
        {
            // Then when all required fields are validate it's neccessary to check whether all properties match T object properties.
            // In case some field is missed it will throw an exception regarding to deserializtion error.
            yamlTypedObjectInstance = deserializer.Deserialize<T>(yamlContent);
        }
        catch (YamlException ex)
        {
            HandleYamlExceptionMessage(ex, errors);
            var message = string.Join("\n", errors.Distinct());

            throw new NoxSolutionConfigurationException(message, ex);
        }

        var errorsFromTypedObjectValidation = Validate(yamlTypedObjectInstance, jsonSerializerOptions, schema, evaluateOptions);
        errors.AddRange(errorsFromTypedObjectValidation);

        if (errors.Count > 0)
        {
            var message = string.Join("\n", errors.Distinct());
            throw new NoxSolutionConfigurationException(message);
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
                if (results.EvaluationPath
                    .ToString()
                    .EndsWith("/$ref") || error.Key == "type")
                {
                    continue;
                }

                var evaluationPath = results.EvaluationPath.ToString();
                var path = string.IsNullOrEmpty(evaluationPath) ? string.Empty : $"Path: {evaluationPath}. ";

                errors.Add($"{path}{error.Value} ({error.Key.ToUpper()}).");
            }
        }
        foreach (var detail in results.Details)
        {
            HandleErrorsRecursively(detail, errors);
        }
    }
}