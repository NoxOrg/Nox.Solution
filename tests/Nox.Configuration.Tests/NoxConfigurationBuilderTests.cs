namespace Nox.Configuration.Tests;

public class NoxConfigurationBuilderTests
{
    [Fact]
    public void Can_create_a_minimal_configuration()
    {
        var noxConfig = new NoxConfigurationBuilder()
            .WithYamlFile("../samples/workplace.solution.yaml")
            .Build();
        Assert.False(noxConfig == null);
    }
}