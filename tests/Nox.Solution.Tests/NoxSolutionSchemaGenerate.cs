using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Json.Schema;
using Json.Schema.Generation;
using Json.Schema.Generation.Generators;
using Json.Schema.Generation.Intents;
using Nox.Types;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using static Nox.Solution.Tests.NoxSolutionSchemaGenerate;

using System.Diagnostics;
using Json.More;
using System;
using Json.Schema.Serialization;
using Xunit.Abstractions;
using FluentValidation;
using Nox.Solution.Validation;

namespace Nox.Solution.Tests;

public class NoxSolutionSchemaGenerate
{
    [Fact]
    public void Can_create_a_json_schema_for_yaml()
    {
        /*
         * TODO: $ref support for arrays/lists
         *
         * TODO: make enum type strings too
         *
         */

        var path = FindOrCreateFolderInProjectRoot("schemas");

        var schemaConfig = new SchemaGeneratorConfiguration()
        {
            PropertyNamingMethod = PropertyNamingMethods.CamelCase,
            Nullability = Nullability.AllowForNullableValueTypes,
            Refiners = { new EnumToCamelCaseRefiner(excludeTypes: new Type[] { typeof(CurrencyCode) }) },
            Generators = { new ReadOnlyStringDictionarySchemaGenerator() },
            Optimize = false,
        };

        var jsonConfig = new JsonSerializerOptions()
        {
            WriteIndented = true,
        };

        //Solution
        var solutionSchema = new JsonSchemaBuilder()
            .Schema(MetaSchemas.Draft7Id)
            .FromType<NoxSolution>(schemaConfig)
            .Build();

        File.WriteAllText(Path.Combine(path, "solution.json"),
            JsonSerializer.Serialize(solutionSchema, jsonConfig)
        );

        //Variables
        var variablesSchema = new JsonSchemaBuilder()
            .Schema(MetaSchemas.Draft7Id)
            .FromType<Dictionary<string, string>?>(schemaConfig)
            .Build();

        File.WriteAllText(Path.Combine(path, "variables.json"),
            JsonSerializer.Serialize(variablesSchema, jsonConfig)
        );

        //Environments
        var environmentSchema = new JsonSchemaBuilder()
            .Schema(MetaSchemas.Draft7Id)
            .FromType<Environment>(schemaConfig)
            .Build();

        File.WriteAllText(Path.Combine(path, "environment.json"),
            JsonSerializer.Serialize(environmentSchema, jsonConfig)
        );

        //Version Control
        var versionControlSchema = new JsonSchemaBuilder()
            .Schema(MetaSchemas.Draft7Id)
            .FromType<VersionControl>(schemaConfig)
            .Build();

        File.WriteAllText(Path.Combine(path, "versionControl.json"),
            JsonSerializer.Serialize(versionControlSchema, jsonConfig)
        );

        //Team
        var teamSchema = new JsonSchemaBuilder()
            .Schema(MetaSchemas.Draft7Id)
            .FromType<TeamMember>(schemaConfig)
            .Build();

        File.WriteAllText(Path.Combine(path, "team.json"),
            JsonSerializer.Serialize(teamSchema, jsonConfig)
        );

        //Domain
        var domainSchema = new JsonSchemaBuilder()
            .Schema(MetaSchemas.Draft7Id)
            .FromType<Domain>(schemaConfig)
            .Build();

        File.WriteAllText(Path.Combine(path, "domain.json"),
            JsonSerializer.Serialize(domainSchema, jsonConfig)
        );

        //Domain/Entity
        var entitySchema = new JsonSchemaBuilder()
            .Schema(MetaSchemas.Draft7Id)
            .FromType<Entity>(schemaConfig)
            .Build();

        File.WriteAllText(Path.Combine(path, "entity.json"),
            JsonSerializer.Serialize(entitySchema, jsonConfig)
        );

        //Application
        var applicationSchema = new JsonSchemaBuilder()
            .Schema(MetaSchemas.Draft7Id)
            .FromType<Application>(schemaConfig)
            .Build();

        File.WriteAllText(Path.Combine(path, "application.json"),
            JsonSerializer.Serialize(applicationSchema, jsonConfig)
        );

        //Application/DataTransferObjects
        var dtosSchema = new JsonSchemaBuilder()
            .Schema(MetaSchemas.Draft7Id)
            .FromType<List<DataTransferObject>>(schemaConfig)
            .Build();

        File.WriteAllText(Path.Combine(path, "dataTransferObjects.json"),
            JsonSerializer.Serialize(dtosSchema, jsonConfig)
        );

        //Application/dto
        var dtoSchema = new JsonSchemaBuilder()
            .Schema(MetaSchemas.Draft7Id)
            .FromType<DataTransferObject>(schemaConfig)
            .Build();

        File.WriteAllText(Path.Combine(path, "dto.json"),
            JsonSerializer.Serialize(dtoSchema, jsonConfig)
        );

        //Application/Integration
        var integrationSchema = new JsonSchemaBuilder()
            .Schema(MetaSchemas.Draft7Id)
            .FromType<Integration>(schemaConfig)
            .Build();

        File.WriteAllText(Path.Combine(path, "integration.json"),
            JsonSerializer.Serialize(integrationSchema, jsonConfig)
        );

        //Infrastructure
        var infrastructureSchema = new JsonSchemaBuilder()
            .Schema(MetaSchemas.Draft7Id)
            .FromType<Infrastructure>(schemaConfig)
            .Build();

        File.WriteAllText(Path.Combine(path, "infrastructure.json"),
            JsonSerializer.Serialize(infrastructureSchema, jsonConfig)
        );

        //Infrastructure/Persistence
        var persistenceSchema = new JsonSchemaBuilder()
            .Schema(MetaSchemas.Draft7Id)
            .FromType<Persistence>(schemaConfig)
            .Build();

        File.WriteAllText(Path.Combine(path, "persistence.json"),
            JsonSerializer.Serialize(persistenceSchema, jsonConfig)
        );

        //Infrastructure/Persistence/DatabaseServer
        var dbServerSchema = new JsonSchemaBuilder()
            .Schema(MetaSchemas.Draft7Id)
            .FromType<DatabaseServer>(schemaConfig)
            .Build();

        File.WriteAllText(Path.Combine(path, "databaseServer.json"),
            JsonSerializer.Serialize(dbServerSchema, jsonConfig)
        );

        //Infrastructure/Persistence/CacheServer
        var cacheServerSchema = new JsonSchemaBuilder()
            .Schema(MetaSchemas.Draft7Id)
            .FromType<CacheServer>(schemaConfig)
            .Build();

        File.WriteAllText(Path.Combine(path, "cacheServer.json"),
            JsonSerializer.Serialize(cacheServerSchema, jsonConfig)
        );

        //Infrastructure/Persistence/SearchServer
        var searchServerSchema = new JsonSchemaBuilder()
            .Schema(MetaSchemas.Draft7Id)
            .FromType<SearchServer>(schemaConfig)
            .Build();

        File.WriteAllText(Path.Combine(path, "searchServer.json"),
            JsonSerializer.Serialize(searchServerSchema, jsonConfig)
        );

        //Infrastructure/Persistence/EventSourceServer
        var eventSourceSchema = new JsonSchemaBuilder()
            .Schema(MetaSchemas.Draft7Id)
            .FromType<Infrastructure>(schemaConfig)
            .Build();

        File.WriteAllText(Path.Combine(path, "eventSourceServer.json"),
            JsonSerializer.Serialize(eventSourceSchema, jsonConfig)
        );

        //Infrastructure/Messaging
        var messagingSchema = new JsonSchemaBuilder()
            .Schema(MetaSchemas.Draft7Id)
            .FromType<Messaging>(schemaConfig)
            .Build();

        File.WriteAllText(Path.Combine(path, "messaging.json"),
            JsonSerializer.Serialize(messagingSchema, jsonConfig)
        );

        //Infrastructure/Endpoints
        var endpointsSchema = new JsonSchemaBuilder()
            .Schema(MetaSchemas.Draft7Id)
            .FromType<Endpoints>(schemaConfig)
            .Build();

        File.WriteAllText(Path.Combine(path, "endpoints.json"),
            JsonSerializer.Serialize(endpointsSchema, jsonConfig)
        );

        //Infrastructure/Endpoints/ApiServer
        var apiServerSchema = new JsonSchemaBuilder()
            .Schema(MetaSchemas.Draft7Id)
            .FromType<ApiServer>(schemaConfig)
            .Build();

        File.WriteAllText(Path.Combine(path, "apiServer.json"),
            JsonSerializer.Serialize(apiServerSchema, jsonConfig)
        );

        //Infrastructure/Endpoints/BffServer
        var bffServerSchema = new JsonSchemaBuilder()
            .Schema(MetaSchemas.Draft7Id)
            .FromType<BffServer>(schemaConfig)
            .Build();

        File.WriteAllText(Path.Combine(path, "bffServer.json"),
            JsonSerializer.Serialize(bffServerSchema, jsonConfig)
        );

        //Infrastructure/Dependencies
        var dependenciesSchema = new JsonSchemaBuilder()
            .Schema(MetaSchemas.Draft7Id)
            .FromType<Dependencies>(schemaConfig)
            .Build();

        File.WriteAllText(Path.Combine(path, "dependencies.json"),
            JsonSerializer.Serialize(dependenciesSchema, jsonConfig)
        );

        //Infrastructure/Dependencies/Notifications
        var notificationsSchema = new JsonSchemaBuilder()
            .Schema(MetaSchemas.Draft7Id)
            .FromType<Notifications>(schemaConfig)
            .Build();

        File.WriteAllText(Path.Combine(path, "notifications.json"),
            JsonSerializer.Serialize(notificationsSchema, jsonConfig)
        );

        //Infrastructure/Dependencies/Monitoring
        var monitoringSchema = new JsonSchemaBuilder()
            .Schema(MetaSchemas.Draft7Id)
            .FromType<Monitoring>(schemaConfig)
            .Build();

        File.WriteAllText(Path.Combine(path, "monitoring.json"),
            JsonSerializer.Serialize(monitoringSchema, jsonConfig)
        );

        //Infrastructure/Dependencies/Translations
        var translationsSchema = new JsonSchemaBuilder()
            .Schema(MetaSchemas.Draft7Id)
            .FromType<Translations>(schemaConfig)
            .Build();

        File.WriteAllText(Path.Combine(path, "translations.json"),
            JsonSerializer.Serialize(translationsSchema, jsonConfig)
        );

        //Infrastructure/Dependencies/Security
        var securitySchema = new JsonSchemaBuilder()
            .Schema(MetaSchemas.Draft7Id)
            .FromType<Security>(schemaConfig)
            .Build();

        File.WriteAllText(Path.Combine(path, "security.json"),
            JsonSerializer.Serialize(securitySchema, jsonConfig)
        );

        //Infrastructure/Dependencies/DataConnection
        var dataConnectionSchema = new JsonSchemaBuilder()
            .Schema(MetaSchemas.Draft7Id)
            .FromType<DataConnection>(schemaConfig)
            .Build();

        File.WriteAllText(Path.Combine(path, "dataConnection.json"),
            JsonSerializer.Serialize(dataConnectionSchema, jsonConfig)
        );
    }

    private static string FindOrCreateFolderInProjectRoot(string folderName)
    {
        var path = new DirectoryInfo(Directory.GetCurrentDirectory());
        var targetFolder = string.Empty;

        while (path != null)
        {
            if (path.GetDirectories(".git").Any())
            {
                targetFolder = Path.Combine(path.FullName, folderName);
                if (!Path.Exists(targetFolder))
                {
                    Directory.CreateDirectory(targetFolder);
                }
                break;
            }

            path = path.Parent;
        }

        return targetFolder;
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

    [Fact]
    public void test_validation()
    {
        var yaml = File.ReadAllText("./files/sample.solution.nox.yaml");

        var model = NoxValidationJsonConverter.Deserialize<NoxSolution>(yaml);
    }
}