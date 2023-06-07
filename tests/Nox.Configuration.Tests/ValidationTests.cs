using Nox.Configuration.Validation;

namespace Nox.Configuration.Tests;

public class ValidationTests
{
    [Fact]
    public void Environment_names_are_unique()
    {
        var noxConfig = new NoxConfigurationBuilder()
            .WithYamlFile("./files/duplicate-environment-name.solution.nox.yaml")
            .Build();
        Assert.NotNull(noxConfig);
        Assert.NotNull(noxConfig.Solution);
        Assert.NotNull(noxConfig.Solution.Environments);
        var validator = new EnvironmentValidator(noxConfig.Solution.Environments);
        Assert.Equal(3, noxConfig.Solution.Environments.Count);
        var result = validator.Validate(noxConfig.Solution.Environments[0]);
        Assert.True(result.IsValid);
        result = validator.Validate(noxConfig.Solution.Environments[1]);
        Assert.False(result.IsValid);
        Assert.Equal("The environment name 'test' is duplicated. Environment names must be unique in a solution.", result.Errors[0].ErrorMessage);
    }
}