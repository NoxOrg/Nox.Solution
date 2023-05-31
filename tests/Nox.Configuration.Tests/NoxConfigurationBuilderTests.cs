namespace Nox.Configuration.Tests;

public class NoxConfigurationBuilderTests
{
    [Fact]
    public void Can_create_configuration_from_set_yaml_file()
    {
        var noxConfig = new NoxConfigurationBuilder()
            .WithYamlFile("./files/workplace.solution.nox.yaml")
            .Build();
        Assert.False(noxConfig == null);
    }

    [Fact]
    public void Can_create_configuration_from_nox_design_folder()
    {
        var noxConfig = new NoxConfigurationBuilder()
            .Build();
        Assert.False(noxConfig == null);
    }
}