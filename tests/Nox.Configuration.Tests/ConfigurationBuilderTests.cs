using Nox.Exceptions;

namespace Nox.Configuration.Tests;

public class ConfigurationBuilderTests
{
    [Fact]
    public void Can_create_configuration_from_set_yaml_file()
    {
        var noxConfig = new NoxConfigurationBuilder()
            .WithYamlFile("./files/minimal.solution.nox.yaml")
            .Build();
        Assert.False(noxConfig == null);
    }

    [Fact]
    public void Error_if_set_yaml_file_does_not_exist()
    {
        var noxConfigBuilder = new NoxConfigurationBuilder()
            .WithYamlFile("./files/missing.solution.nox.yaml");
        Assert.Throws<NoxConfigurationException>(() => noxConfigBuilder.Build());
    }

    [Fact]
    public void Can_create_configuration_from_nox_design_folder()
    {
        var noxConfig = new NoxConfigurationBuilder()
            .Build();
        Assert.False(noxConfig == null);
    }

    [Fact]
    public void Error_if_configuration_not_found_in_nox_folder()
    {
        TestHelpers.RenameFilesInFolder("../../../../../.nox/design", "*.nox.yaml", "zaml");
        var noxConfigBuilder = new NoxConfigurationBuilder();
        Assert.Throws<NoxConfigurationException>(() => noxConfigBuilder.Build());
        TestHelpers.RenameFilesInFolder("../../../../../.nox/design", "*.nox.zaml", "yaml");
    }
    
    
}