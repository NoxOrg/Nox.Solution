using Json.More;
using Json.Schema;
using Json.Schema.Generation;
using System.Text.Json;

namespace Nox.Configuration.Tests;

public class NoxConfigurationSchemaTests
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
            Optimize = false,
        };

        var jsonConfig = new JsonSerializerOptions()
        {
            WriteIndented = true,
        };

        var solutionSchema = new JsonSchemaBuilder()
            .Schema(MetaSchemas.Draft7Id)
            .FromType<Solution>(schemaConfig)
            .Build();

        File.WriteAllText(Path.Combine(path, "solution.json"),
            JsonSerializer.Serialize(solutionSchema, jsonConfig)
        );

        var environmentSchema = new JsonSchemaBuilder()
            .Schema(MetaSchemas.Draft7Id)
            .FromType<Environment>(schemaConfig)
            .Build();

        File.WriteAllText(Path.Combine(path, "solution.json"),
            JsonSerializer.Serialize(solutionSchema, jsonConfig)
        );

        var versionControlSchema = new JsonSchemaBuilder()
            .Schema(MetaSchemas.Draft7Id)
            .FromType<VersionControl>(schemaConfig)
            .Build();


        File.WriteAllText(Path.Combine(path, "versionControl.json"),
            JsonSerializer.Serialize(versionControlSchema, jsonConfig)
        );

        var teamSchema = new JsonSchemaBuilder()
            .Schema(MetaSchemas.Draft7Id)
            .FromType<Team>(schemaConfig)
            .Build();

        File.WriteAllText(Path.Combine(path, "team.json"),
            JsonSerializer.Serialize(teamSchema, jsonConfig)
        );

    }

    private static string FindOrCreateFolderInProjectRoot(string folderName)
    {
        var path = new DirectoryInfo( Directory.GetCurrentDirectory() );
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
}