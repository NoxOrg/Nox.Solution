using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using FluentAssertions;
using Json.Schema.Generation;
using Nox.Solution.Exceptions;
using Nox.Solution.Resolvers;

namespace Nox.Solution.Tests;

public class ValidationTests
{
    [Fact]
    public void Environment_names_are_unique()
    {
        var ex = Assert.Throws<FluentValidation.ValidationException>(() =>
            _ = new NoxSolutionBuilder()
                .UseYamlFile("./files/duplicate-environment-name.solution.nox.yaml")
                .Build()
        );

        Assert.Equal("The environment name 'test' is duplicated. Environment names must be unique in a solution.", ex.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Solution_DeserializeWithValidation_ShoouldThrow()
    {
        var yaml = File.ReadAllText("./files/invalid-sample.solution.nox.yaml");

        var exception = Assert.Throws<NoxSolutionConfigurationException>(() => NoxYamlSerializer.Deserialize<NoxSolution>(yaml));

        var errorCount = exception.Message.Split('\n').Length;

        Assert.Contains("[\"relationship\"]", exception.Message);
        Assert.Contains("[\"name\"]", exception.Message);
        Assert.Contains("[\"serverUri\"]", exception.Message);
        Assert.Contains("dataConnection", exception.Message);
        Assert.Equal(11, errorCount);
    }

    [Fact]
    public void Solution_DeserializeWithValidation_Success()
    {
        var yaml = File.ReadAllText("./files/sample.solution.nox.yaml");

        var model = NoxYamlSerializer.Deserialize<NoxSolution>(yaml)!;

        Assert.Equal("SampleService", model.Name);
    }
}