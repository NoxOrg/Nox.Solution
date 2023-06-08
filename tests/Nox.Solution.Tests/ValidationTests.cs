using Nox.Configuration.Validation;

namespace Nox.Configuration.Tests;

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
}