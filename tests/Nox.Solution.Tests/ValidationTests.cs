
using FluentAssertions;
using FluentValidation;
using Nox.Solution.Exceptions;


namespace Nox.Solution.Tests;

public class ValidationTests
{
    [Theory]
    [InlineData("unsupported-version-control.solution.nox")]
    [InlineData("not-found.yaml")]
    public void WhenInvalidYamlNotShouldThrowException(string filrName)
    {
        var solutionBuilder = new NoxSolutionBuilder().UseYamlFile($"./files/{filrName}");

        solutionBuilder
            .Invoking(solution => solution.Build())
            .Should().Throw<NoxSolutionConfigurationException>();            
    }
    
    [Theory]
    [InlineData("duplicate-environment-name.solution.nox.yaml", "The environment name 'test' is duplicated. Environment names must be unique in a solution.")]
    [InlineData("invalid-version-control.solution.nox.yaml", "Version Control provider missing. a Version Control Provider must be specified in a solution.")]
    public void WhenInvalidConfigurationShouldThrowValidationException(string ymlFileName, string expectedErrorMessage)
    {              
       Action act = () => new NoxSolutionBuilder()
                .UseYamlFile($"./files/{ymlFileName}")
                .Build()
                .Validate();
       
        act.Should()
            .Throw<ValidationException>()
            .Where(exception => exception.Errors.First().ErrorMessage.Contains(expectedErrorMessage));       
    }

    [Theory]
    [InlineData("application.solution.nox.yaml")]
    [InlineData("domain.solution.nox.yaml")]    
    [InlineData("environments.solution.nox.yaml")]    
    [InlineData("infrastructure.solution.nox.yaml")]        
    [InlineData("minimal.solution.nox.yaml")]
    [InlineData("sample.solution.nox.yaml")]
    [InlineData("team.solution.nox.yaml")]
    [InlineData("variables.solution.nox.yaml")]
    [InlineData("version-control.solution.nox.yaml")]    
    public void WhenValidConfigurationShouldValidate(string ymlFileName)
    {
        var noxSolution = new NoxSolutionBuilder()
                .UseYamlFile($"./files/{ymlFileName}")
                .Build();

        noxSolution
            .Invoking(solution => solution.Validate())
            .Should().NotThrow();
    }
}