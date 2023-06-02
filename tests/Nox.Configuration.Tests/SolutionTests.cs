namespace Nox.Configuration.Tests;

public class SolutionTests
{
    [Fact]
    public void Variables_section_is_deserialized()
    {
        var noxConfig = new NoxConfigurationBuilder()
            .WithYamlFile("./files/variables.solution.nox.yaml")
            .Build();
        Assert.NotNull(noxConfig);
        Assert.NotNull(noxConfig.Solution);
        Assert.NotNull(noxConfig.Solution.Variables);
        Assert.Equal(2, noxConfig.Solution.Variables.Count);
        Assert.Equal("value1", noxConfig.Solution.Variables["VARIABLE1"]);
        Assert.Equal("value2", noxConfig.Solution.Variables["VARIABLE2"]);
    }
    
    [Fact]
    public void Environments_section_is_deserialized()
    {
        var noxConfig = new NoxConfigurationBuilder()
            .WithYamlFile("./files/environments.solution.nox.yaml")
            .Build();
        Assert.NotNull(noxConfig);
        Assert.NotNull(noxConfig.Solution);
        Assert.NotNull(noxConfig.Solution.Environments);
        Assert.Equal(4, noxConfig.Solution.Environments.Count);
        Assert.Equal("dev", noxConfig.Solution.Environments[0].Name);
        Assert.Equal("Used for development and testing", noxConfig.Solution.Environments[0].Description);
        Assert.Equal("test", noxConfig.Solution.Environments[1].Name);
        Assert.Equal("Test environment", noxConfig.Solution.Environments[1].Description);
        Assert.Equal("uat", noxConfig.Solution.Environments[2].Name);
        Assert.Equal("For them end users to check it works", noxConfig.Solution.Environments[2].Description);
        Assert.Equal("prod", noxConfig.Solution.Environments[3].Name);
        Assert.Equal("Production environment used for, well - the real thing!", noxConfig.Solution.Environments[3].Description);
    }
    
    [Fact]
    public void VersionControl_section_is_deserialized()
    {
        var noxConfig = new NoxConfigurationBuilder()
            .WithYamlFile("./files/versionControl.solution.nox.yaml")
            .Build();
        Assert.NotNull(noxConfig);
        Assert.NotNull(noxConfig.Solution);
        Assert.NotNull(noxConfig.Solution.VersionControl);
        Assert.Equal(VersionControlProvider.AzureDevops, noxConfig.Solution.VersionControl.Provider);
        Assert.Equal(new Uri("https://dev.azure.com/iwgplc"), noxConfig.Solution.VersionControl.Host);
        Assert.NotNull(noxConfig.Solution.VersionControl.Folders);
        Assert.Equal("/src", noxConfig.Solution.VersionControl.Folders.SourceCode);
        Assert.Equal("/docker", noxConfig.Solution.VersionControl.Folders.Containers);
    }
    
    [Fact]
    public void Team_section_is_deserialized()
    {
        var noxConfig = new NoxConfigurationBuilder()
            .WithYamlFile("./files/team.solution.nox.yaml")
            .Build();
        Assert.NotNull(noxConfig);
        Assert.NotNull(noxConfig.Solution);
        Assert.NotNull(noxConfig.Solution.Team);
        Assert.Equal(2, noxConfig.Solution.Team.Count);
        Assert.Equal("Andre Sharpe", noxConfig.Solution.Team[0].Name);
        Assert.Equal("andre.sharpe@iwgplc.com", noxConfig.Solution.Team[0].UserName);
        Assert.NotNull(noxConfig.Solution.Team[0].Roles);
        Assert.Equal(5, noxConfig.Solution.Team[0].Roles!.Count);
        Assert.True(noxConfig.Solution.Team[0].Roles!.Contains(TeamRole.Architect));
        Assert.True(noxConfig.Solution.Team[0].Roles!.Contains(TeamRole.Manager));
    }
    
    [Fact]
    public void Domain_section_is_deserialized()
    {
        var noxConfig = new NoxConfigurationBuilder()
            .WithYamlFile("./files/domain.solution.nox.yaml")
            .Build();
        Assert.NotNull(noxConfig);
        Assert.NotNull(noxConfig.Solution);
        Assert.NotNull(noxConfig.Solution.Domain);
        Assert.NotNull(noxConfig.Solution.Domain.Entities);
        Assert.Equal(2, noxConfig.Solution.Domain.Entities.Count);
        
        var country = noxConfig.Solution.Domain.Entities[0];
        Assert.Equal("Country", country.Name);
        Assert.Equal("The list of countries", country.Description);
        
        Assert.NotNull(country.UserInterface);
        Assert.Equal("world", country.UserInterface.Icon);
        
        Assert.NotNull(country.Persistence);
        Assert.True(country.Persistence.IsVersioned);
        
        Assert.NotNull(country.Relationships);
        Assert.Equal(1, country.Relationships.Count);
        Assert.Equal("CountryAcceptsCurrency", country.Relationships[0].Name);
        Assert.Equal("accepts as legal tender", country.Relationships[0].Description);
        Assert.Equal(EntityRelationshipType.OneOrMany, country.Relationships[0].Relationship);
        Assert.Equal("Currency", country.Relationships[0].Entity);
        
        Assert.NotNull(country.OwnedRelationships);
        Assert.Equal(1, country.OwnedRelationships.Count);
        Assert.Equal("CountryLocalNames", country.OwnedRelationships[0].Name);
        Assert.Equal("is also know as", country.OwnedRelationships[0].Description);
        Assert.Equal(EntityRelationshipType.OneOrMany, country.OwnedRelationships[0].Relationship);
        Assert.Equal("CountryLocalNames", country.OwnedRelationships[0].Entity);
        
        Assert.NotNull(country.Queries);
        Assert.Equal(1, country.Queries.Count);
        Assert.Equal("GetCountriesByContinent", country.Queries[0].Name);
        Assert.Equal("Returns a list of countries for a given continent", country.Queries[0].Description);
        Assert.NotNull(country.Queries[0].requestInput);
        Assert.Equal(1, country.Queries[0].requestInput!.Count);
        Assert.Equal("continentName", country.Queries[0].requestInput![0].Name);
        Assert.Equal("Africa, Europe, Asia, Australia, North America, or South America", country.Queries[0].requestInput![0].Description);
        Assert.Equal(NoxType.text, country.Queries[0].requestInput![0].Type);
        Assert.NotNull(country.Queries[0].requestInput![0].TextTypeOptions);
        Assert.False(country.Queries[0].requestInput![0].TextTypeOptions!.IsUnicode);
        
        Assert.NotNull(country.Queries[0].responseOutput);
        
        
        Assert.NotNull(country.Commands);
        
        Assert.NotNull(country.Keys);
        
        Assert.NotNull(country.Attributes);
    }
    
    
}