using System.Collections.Generic;
using System.IO;
using System;
using FluentValidation;
using Nox.Types;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using System.Text.Json;
using Json.Schema.Generation.Generators;
using Json.Schema;
using Json.Schema.Generation.Intents;
using Json.Schema.Generation;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml;

namespace Nox.Solution.Validation
{
    internal class SolutionValidator : AbstractValidator<Solution>
    {
        public SolutionValidator()
        {
            RuleFor(solution => solution.Name)
                .NotEmpty()
                .WithMessage(solution => string.Format(ValidationResources.SolutionNameEmpty));

            RuleForEach(sln => sln.Environments)
                .SetValidator(sln => new EnvironmentValidator(sln.Environments));

            RuleFor(sln => sln.VersionControl!)
                .SetValidator(new VersionControlValidator());

            RuleForEach(sln => sln.Team)
                .SetValidator(sln => new TeamValidator(sln.Team));

            RuleFor(sln => sln.Domain!)
                .SetValidator(new DomainValidator());

            RuleFor(sln => sln.Application!)
                .SetValidator(sln => new ApplicationValidator(sln.Infrastructure?.Dependencies?.DataConnections));

            RuleFor(sln => sln.Infrastructure!)
                .SetValidator(new InfrastructureValidator());
        }
    }

    public class NoxValidationJsonConverter
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

            var yamlObject = deserializer.Deserialize<T>(new StringReader(yaml));
            var jsonDocument = JsonSerializer.SerializeToDocument(yamlObject, new JsonSerializerOptions
            {
            });

            var doc = ToJsonString(jsonDocument);

            var evaluateOptions = new EvaluationOptions
            {
                OutputFormat = OutputFormat.List,
                RequireFormatValidation = true
            };
            var result = schema.Validate(jsonDocument, evaluateOptions);

            if (result.IsValid)
            {
                // JSON is valid according to the schema
                var opts = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true,
                };

                var obj = JsonSerializer.Deserialize<T>(jsonDocument, opts);
                return obj;
            }
            else
            {
                var errors = new List<string>();
                HandleErrorsRecursively(result, errors);

                throw new Exception(string.Join("\n", errors));
            }
        }

        private static void HandleErrorsRecursively(EvaluationResults results, List<string> errors)
        {
            if (results.Errors != null)
            {
                foreach (var error in results.Errors)
                {
                    errors.Add($"{results.EvaluationPath}: {error.Key} - {error.Value}");
                }
            }
            foreach (var detail in results.Details)
            {
                HandleErrorsRecursively(detail, errors);
            }
        }

        public static string ToJsonString(JsonDocument jsonDocument)
        {
            using (var stream = new MemoryStream())
            {
                Utf8JsonWriter writer = new Utf8JsonWriter(stream, new JsonWriterOptions { Indented = true });
                jsonDocument.WriteTo(writer);
                writer.Flush();
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }
    }

    internal class ReadOnlyStringDictionarySchemaGenerator : ISchemaGenerator
    {
        public bool Handles(Type type)
        {
            if (!type.IsGenericType) return false;

            var generic = type.GetGenericTypeDefinition();

            if (generic != typeof(IReadOnlyDictionary<,>))
                return false;

            var keyType = type.GenericTypeArguments[0];
            return keyType == typeof(string);
        }

        public void AddConstraints(SchemaGenerationContextBase context)
        {
            context.Intents.Add(new TypeIntent(SchemaValueType.Object));

            var valueType = context.Type.GenericTypeArguments[1];
            var valueContext = SchemaGenerationContextCache.Get(valueType);

            context.Intents.Add(new AdditionalPropertiesIntent(valueContext));
        }
    }

    internal class EnumToCamelCaseRefiner : ISchemaRefiner
    {
        private readonly Type[] _excludeTypes;

        public EnumToCamelCaseRefiner() : this(Array.Empty<Type>())
        {
        }

        public EnumToCamelCaseRefiner(Type[] excludeTypes)
        {
            _excludeTypes = excludeTypes;
        }

        public bool ShouldRun(SchemaGenerationContextBase context)
        {
            // we only want to run this if the generated schema has a `enum` keyword

            if (_excludeTypes.Contains(context.Type))
                return false;

            return context.Intents.OfType<EnumIntent>().Any();
        }

        public void Run(SchemaGenerationContextBase context)
        {
            // find the enum keyword
            var enumIntent = context.Intents.OfType<EnumIntent>().First();
            enumIntent.Names = enumIntent.Names.Select(n => Char.ToLowerInvariant(n[0]) + n.Substring(1)).ToList();
        }
    }
}