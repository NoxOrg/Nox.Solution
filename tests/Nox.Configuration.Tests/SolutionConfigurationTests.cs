using Microsoft.Extensions.DependencyInjection;

namespace Nox.Configuration.Tests;

public class SolutionConfigurationTests
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
            .WithYamlFile("./files/version-control.solution.nox.yaml")
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
        Assert.Contains(TeamRole.Architect, noxConfig.Solution.Team[0].Roles!);
        Assert.Contains(TeamRole.Manager, noxConfig.Solution.Team[0].Roles!);
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
        Assert.Single(country.Relationships);
        Assert.Equal("CountryAcceptsCurrency", country.Relationships[0].Name);
        Assert.Equal("accepts as legal tender", country.Relationships[0].Description);
        Assert.Equal(EntityRelationshipType.OneOrMany, country.Relationships[0].Relationship);
        Assert.Equal("Currency", country.Relationships[0].Entity);
        
        Assert.NotNull(country.OwnedRelationships);
        Assert.Single(country.OwnedRelationships);
        Assert.Equal("CountryLocalNames", country.OwnedRelationships[0].Name);
        Assert.Equal("is also know as", country.OwnedRelationships[0].Description);
        Assert.Equal(EntityRelationshipType.OneOrMany, country.OwnedRelationships[0].Relationship);
        Assert.Equal("CountryLocalNames", country.OwnedRelationships[0].Entity);
        
        Assert.NotNull(country.Queries);
        Assert.Single(country.Queries);
        Assert.Equal("GetCountriesByContinent", country.Queries[0].Name);
        Assert.Equal("Returns a list of countries for a given continent", country.Queries[0].Description);
        
        Assert.NotNull(country.Queries[0].RequestInput);
        Assert.Single(country.Queries[0].RequestInput!);
        Assert.Equal("continentName", country.Queries[0].RequestInput![0].Name);
        Assert.Equal("Africa, Europe, Asia, Australia, North America, or South America", country.Queries[0].RequestInput![0].Description);
        Assert.Equal(NoxType.text, country.Queries[0].RequestInput![0].Type);
        Assert.NotNull(country.Queries[0].RequestInput![0].TextTypeOptions);
        Assert.False(country.Queries[0].RequestInput![0].TextTypeOptions!.IsUnicode);
        
        Assert.NotNull(country.Queries[0].ResponseOutput);
        Assert.Equal("countriesByContinentDto", country.Queries[0].ResponseOutput!.Name);
        Assert.Equal(NoxType.collection, country.Queries[0].ResponseOutput!.Type);
        Assert.NotNull(country.Queries[0].ResponseOutput!.CollectionTypeOptions);
        Assert.Equal("countryInfo", country.Queries[0].ResponseOutput!.CollectionTypeOptions!.Name);
        Assert.Equal(NoxType.@object, country.Queries[0].ResponseOutput!.CollectionTypeOptions!.Type);
        Assert.NotNull(country.Queries[0].ResponseOutput!.CollectionTypeOptions!.ObjectTypeOptions);
        Assert.NotNull(country.Queries[0].ResponseOutput!.CollectionTypeOptions!.ObjectTypeOptions!.Attributes);
        Assert.Equal(2, country.Queries[0].ResponseOutput!.CollectionTypeOptions!.ObjectTypeOptions!.Attributes!.Count);
        Assert.Equal("CountryId", country.Queries[0].ResponseOutput!.CollectionTypeOptions!.ObjectTypeOptions!.Attributes![0].Name);
        Assert.Equal("The country's Id", country.Queries[0].ResponseOutput!.CollectionTypeOptions!.ObjectTypeOptions!.Attributes![0].Description);
        Assert.Equal(NoxType.countryCode2, country.Queries[0].ResponseOutput!.CollectionTypeOptions!.ObjectTypeOptions!.Attributes![0].Type);
        Assert.Equal("CountryName", country.Queries[0].ResponseOutput!.CollectionTypeOptions!.ObjectTypeOptions!.Attributes![1].Name);
        Assert.Equal("The country name", country.Queries[0].ResponseOutput!.CollectionTypeOptions!.ObjectTypeOptions!.Attributes![1].Description);
        Assert.Equal(NoxType.text, country.Queries[0].ResponseOutput!.CollectionTypeOptions!.ObjectTypeOptions!.Attributes![1].Type);
        
        Assert.NotNull(country.Commands);
        Assert.Single(country.Commands);
        Assert.Equal("UpdatePopulationStatistics", country.Commands[0].Name);
        Assert.Equal("Instructs the service to collect updated population statistics", country.Commands[0].Description);
        Assert.Equal(NoxType.@object, country.Commands[0].Type);
        Assert.NotNull(country.Commands[0].ObjectTypeOptions);
        Assert.NotNull(country.Commands[0].ObjectTypeOptions!.Attributes);
        Assert.Single(country.Commands[0].ObjectTypeOptions!.Attributes!);
        Assert.Equal("CountryCode", country.Commands[0].ObjectTypeOptions!.Attributes![0].Name);
        Assert.Equal(NoxType.countryCode2, country.Commands[0].ObjectTypeOptions!.Attributes![0].Type);
        Assert.NotNull(country.Commands[0].EmitEvents);
        Assert.Single(country.Commands[0].EmitEvents!);
        Assert.Equal("CountryUpdatedEvent", country.Commands[0].EmitEvents![0]);
        
        Assert.NotNull(country.Keys);
        Assert.Single(country.Keys);
        Assert.Equal("Id", country.Keys[0].Name);
        Assert.Equal(NoxType.text, country.Keys[0].Type);
        Assert.NotNull(country.Keys[0].TextTypeOptions);
        Assert.False(country.Keys[0].TextTypeOptions!.IsUnicode);
        Assert.Equal(2, country.Keys[0].TextTypeOptions!.MaxLength);
        Assert.Equal(2, country.Keys[0].TextTypeOptions!.MinLength);
        
        Assert.NotNull(country.Attributes);
        Assert.Equal(15, country.Attributes.Count);
        
    }

    [Fact]
    public void Application_section_is_deserialized()
    {
        var noxConfig = new NoxConfigurationBuilder()
            .WithYamlFile("./files/application.solution.nox.yaml")
            .Build();
        
        Assert.NotNull(noxConfig);
        Assert.NotNull(noxConfig.Solution);
        Assert.NotNull(noxConfig.Solution!.Application);
        
        Assert.NotNull(noxConfig.Solution!.Application.DataTransferObjects);
        Assert.Single(noxConfig.Solution!.Application.DataTransferObjects);
        Assert.Equal("CountryDto", noxConfig.Solution!.Application.DataTransferObjects[0].Name);
        Assert.Equal("Dto for country information", noxConfig.Solution!.Application.DataTransferObjects[0].Description);
        Assert.NotNull(noxConfig.Solution!.Application.DataTransferObjects[0].Attributes);
        Assert.Single(noxConfig.Solution!.Application.DataTransferObjects[0].Attributes!);
        Assert.Equal("Id", noxConfig.Solution!.Application.DataTransferObjects[0].Attributes![0].Name);
        Assert.Equal("The identity of the country, the Iso Alpha 2 code", noxConfig.Solution!.Application.DataTransferObjects[0].Attributes![0].Description);
        Assert.Equal(NoxType.text, noxConfig.Solution!.Application.DataTransferObjects[0].Attributes![0].Type);
        Assert.NotNull(noxConfig.Solution!.Application.DataTransferObjects[0].Attributes![0].TextTypeOptions);
        Assert.Equal(TextTypeCasing.Lower, noxConfig.Solution!.Application.DataTransferObjects[0].Attributes![0].TextTypeOptions!.CharacterCasing);
        Assert.Equal(2, noxConfig.Solution!.Application.DataTransferObjects[0].Attributes![0].TextTypeOptions!.MaxLength);
        Assert.Equal(2, noxConfig.Solution!.Application.DataTransferObjects[0].Attributes![0].TextTypeOptions!.MinLength);
        
        Assert.NotNull(noxConfig.Solution!.Application.Integration);
        Assert.Single(noxConfig.Solution!.Application.Integration);
        Assert.Equal("SampleEtl", noxConfig.Solution!.Application.Integration[0].Name);
        Assert.Equal("a Sample Etl", noxConfig.Solution!.Application.Integration[0].Description);
        Assert.NotNull(noxConfig.Solution!.Application.Integration[0].Source);
        Assert.Equal("SampleEtlDataSource", noxConfig.Solution!.Application.Integration[0].Source!.Name);
        Assert.Equal("Sources Country data from a json file", noxConfig.Solution!.Application.Integration[0].Source!.Description);
        Assert.Equal("CountryJsonData", noxConfig.Solution!.Application.Integration[0].Source!.DataConnection);
        Assert.NotNull(noxConfig.Solution!.Application.Integration[0].Source!.Schedule);
        Assert.Equal("every day at 2am", noxConfig.Solution!.Application.Integration[0].Source!.Schedule!.Start);
        Assert.NotNull(noxConfig.Solution!.Application.Integration[0].Source!.Schedule!.Retry);
        Assert.Equal(5, noxConfig.Solution!.Application.Integration[0].Source!.Schedule!.Retry!.Limit);
        Assert.Equal(5, noxConfig.Solution!.Application.Integration[0].Source!.Schedule!.Retry!.DelaySeconds);
        Assert.Equal(10, noxConfig.Solution!.Application.Integration[0].Source!.Schedule!.Retry!.DoubleDelayLimit);
        Assert.True(noxConfig.Solution!.Application.Integration[0].Source!.Schedule!.RunOnStartup);
        
        Assert.NotNull(noxConfig.Solution!.Application.Integration[0].Source!.Watermark);
        Assert.NotNull(noxConfig.Solution!.Application.Integration[0].Source!.Watermark!.DateColumns);
        Assert.Equal(2, noxConfig.Solution!.Application.Integration[0].Source!.Watermark!.DateColumns!.Length);
        Assert.Equal("CreateDate", noxConfig.Solution!.Application.Integration[0].Source!.Watermark!.DateColumns![0]);
        Assert.Equal("EditDate", noxConfig.Solution!.Application.Integration[0].Source!.Watermark!.DateColumns![1]);
        Assert.Equal("CountryId", noxConfig.Solution!.Application.Integration[0].Source!.Watermark!.SequentialKeyColumn);
        
        Assert.NotNull(noxConfig.Solution!.Application.Integration[0].Transform);
        Assert.NotNull(noxConfig.Solution!.Application.Integration[0].Transform!.Map);
        Assert.Equal(3, noxConfig.Solution!.Application.Integration[0].Transform!.Map!.Count);
        Assert.Equal("IsoAlpha2Code", noxConfig.Solution!.Application.Integration[0].Transform!.Map![0].SourceColumn);
        Assert.Equal("Id", noxConfig.Solution!.Application.Integration[0].Transform!.Map![0].TargetAttribute);
        Assert.Equal(EtlMappingConverter.UpperCase, noxConfig.Solution!.Application.Integration[0].Transform!.Map![0].Converter);
        Assert.Equal("CountryName", noxConfig.Solution!.Application.Integration[0].Transform!.Map![1].SourceColumn);
        Assert.Equal("Name", noxConfig.Solution!.Application.Integration[0].Transform!.Map![1].TargetAttribute);
        Assert.Equal("CountryFullName", noxConfig.Solution!.Application.Integration[0].Transform!.Map![2].SourceColumn);
        Assert.Equal("FormalName", noxConfig.Solution!.Application.Integration[0].Transform!.Map![2].TargetAttribute);
        
        Assert.NotNull(noxConfig.Solution!.Application.Integration[0].Transform!.Lookup);
        Assert.Single(noxConfig.Solution!.Application.Integration[0].Transform!.Lookup!);
        Assert.Equal("RegionId", noxConfig.Solution!.Application.Integration[0].Transform!.Lookup![0].SourceColumn);
        Assert.NotNull(noxConfig.Solution!.Application.Integration[0].Transform!.Lookup![0].Match);
        Assert.Equal("GeoRegions", noxConfig.Solution!.Application.Integration[0].Transform!.Lookup![0].Match!.Table);
        Assert.Equal("Id", noxConfig.Solution!.Application.Integration[0].Transform!.Lookup![0].Match!.LookupColumn);
        Assert.Equal("Name", noxConfig.Solution!.Application.Integration[0].Transform!.Lookup![0].Match!.ReturnColumn);
        Assert.Equal("GeoRegion", noxConfig.Solution!.Application.Integration[0].Transform!.Lookup![0].TargetAttribute);
        
        Assert.NotNull(noxConfig.Solution!.Application.Integration[0].Target);
        Assert.Equal("???", noxConfig.Solution!.Application.Integration[0].Target!.Name);
        Assert.NotNull(noxConfig.Solution!.Application.Integration[0].Target!.DataConnection);
        Assert.Equal("Nox", noxConfig.Solution!.Application.Integration[0].Target!.DataConnection);
    }

    [Fact]
    public void Infrastructure_section_is_deserialized()
    {
        var noxConfig = new NoxConfigurationBuilder()
            .WithYamlFile("./files/infrastructure.solution.nox.yaml")
            .Build();
        Assert.NotNull(noxConfig);
        Assert.NotNull(noxConfig.Solution);
        Assert.NotNull(noxConfig.Solution!.Infrastructure);
        
        Assert.NotNull(noxConfig.Solution!.Infrastructure.Persistence);
        Assert.NotNull(noxConfig.Solution!.Infrastructure.Persistence.DatabaseServer);
        Assert.Equal("SampleCurrencyDb", noxConfig.Solution!.Infrastructure.Persistence.DatabaseServer.Name);
        Assert.Equal("sqlserver.iwgplc.com", noxConfig.Solution!.Infrastructure.Persistence.DatabaseServer.ServerUri);
        Assert.Equal(DatabaseServerProvider.SqlServer, noxConfig.Solution!.Infrastructure.Persistence.DatabaseServer.Provider);
        Assert.Equal(1433, noxConfig.Solution!.Infrastructure.Persistence.DatabaseServer.Port);
        Assert.Equal("sqluser", noxConfig.Solution!.Infrastructure.Persistence.DatabaseServer.User);
        Assert.Equal("sqlpassword", noxConfig.Solution!.Infrastructure.Persistence.DatabaseServer.Password);
        
        Assert.NotNull(noxConfig.Solution!.Infrastructure.Persistence.CacheServer);
        Assert.Equal("SampleCache", noxConfig.Solution!.Infrastructure.Persistence.CacheServer.Name);
        Assert.Equal("redis.iwgplc.com", noxConfig.Solution!.Infrastructure.Persistence.CacheServer.ServerUri);
        Assert.Equal(CacheServerProvider.AzureRedis, noxConfig.Solution!.Infrastructure.Persistence.CacheServer.Provider);
        Assert.Equal("RedisUser", noxConfig.Solution!.Infrastructure.Persistence.CacheServer.User);
        Assert.Equal("RedisPassword", noxConfig.Solution!.Infrastructure.Persistence.CacheServer.Password);
        
        Assert.NotNull(noxConfig.Solution!.Infrastructure.Persistence.SearchServer);
        Assert.Equal("SampleSearch", noxConfig.Solution!.Infrastructure.Persistence.SearchServer.Name);
        Assert.Equal("elastic.igwplc.com", noxConfig.Solution!.Infrastructure.Persistence.SearchServer.ServerUri);
        Assert.Equal(SearchServerProvider.ElasticSearch, noxConfig.Solution!.Infrastructure.Persistence.SearchServer.Provider);
        Assert.Equal("ElasticUser", noxConfig.Solution!.Infrastructure.Persistence.SearchServer.User);
        Assert.Equal("ElasticPassword", noxConfig.Solution!.Infrastructure.Persistence.SearchServer.Password);
        
        Assert.NotNull(noxConfig.Solution!.Infrastructure.Persistence.EventSourceServer);
        Assert.Equal("SampleEvtSrc", noxConfig.Solution!.Infrastructure.Persistence.EventSourceServer.Name);
        Assert.Equal("SampleEvt.iwgplc.com", noxConfig.Solution!.Infrastructure.Persistence.EventSourceServer.ServerUri);
        Assert.Equal(EventSourceServerProvider.EventStoreDb, noxConfig.Solution!.Infrastructure.Persistence.EventSourceServer.Provider);
        Assert.Equal("EvtUser", noxConfig.Solution!.Infrastructure.Persistence.EventSourceServer.User);
        Assert.Equal("EvtPassword", noxConfig.Solution!.Infrastructure.Persistence.EventSourceServer.Password);
        
        Assert.NotNull(noxConfig.Solution!.Infrastructure.Messaging);
        Assert.NotNull(noxConfig.Solution!.Infrastructure.Messaging.DomainEventServer);
        Assert.Equal("MediatR", noxConfig.Solution!.Infrastructure.Messaging.DomainEventServer.Name);
        Assert.Equal(MessagingServerProvider.MediatR, noxConfig.Solution!.Infrastructure.Messaging.DomainEventServer.Provider);
        
        Assert.NotNull(noxConfig.Solution!.Infrastructure.Messaging.IntegrationEventServer);
        Assert.Equal("IntegrationBus", noxConfig.Solution!.Infrastructure.Messaging.IntegrationEventServer.Name);
        Assert.Equal("rabbitmq://localhost", noxConfig.Solution!.Infrastructure.Messaging.IntegrationEventServer.ServerUri);
        Assert.Equal(MessagingServerProvider.RabbitMq, noxConfig.Solution!.Infrastructure.Messaging.IntegrationEventServer.Provider);
        Assert.Equal(5672, noxConfig.Solution!.Infrastructure.Messaging.IntegrationEventServer.Port);
        Assert.Equal("guest", noxConfig.Solution!.Infrastructure.Messaging.IntegrationEventServer.User);
        Assert.Equal("guest", noxConfig.Solution!.Infrastructure.Messaging.IntegrationEventServer.Password);
        
        Assert.NotNull(noxConfig.Solution!.Infrastructure.Endpoints);
        Assert.NotNull(noxConfig.Solution!.Infrastructure.Endpoints.ApiServer);
        Assert.Equal("SampleApiServer", noxConfig.Solution!.Infrastructure.Endpoints.ApiServer.Name);
        Assert.Equal("workplace.iwgplc.com", noxConfig.Solution!.Infrastructure.Endpoints.ApiServer.ServerUri);
        Assert.Equal(8080, noxConfig.Solution!.Infrastructure.Endpoints.ApiServer.Port);
        
        Assert.NotNull(noxConfig.Solution!.Infrastructure.Endpoints.BffServer);
        Assert.Equal("SampleBffServer", noxConfig.Solution!.Infrastructure.Endpoints.BffServer.Name);
        Assert.Equal("SampleBff.iwgplc.com", noxConfig.Solution!.Infrastructure.Endpoints.BffServer.ServerUri);
        Assert.Equal(8080, noxConfig.Solution!.Infrastructure.Endpoints.BffServer.Port);
        
        Assert.NotNull(noxConfig.Solution!.Infrastructure.Dependencies);
        Assert.NotNull(noxConfig.Solution!.Infrastructure.Dependencies.Notifications);
        Assert.NotNull(noxConfig.Solution!.Infrastructure.Dependencies.Notifications.EmailServer);
        Assert.Equal("SampleEmailServer", noxConfig.Solution!.Infrastructure.Dependencies.Notifications.EmailServer!.Name);
        Assert.Equal(EmailServerProvider.SendGrid, noxConfig.Solution!.Infrastructure.Dependencies.Notifications.EmailServer!.Provider);
        Assert.Equal("sendgrid.igwplc.com", noxConfig.Solution!.Infrastructure.Dependencies.Notifications.EmailServer!.ServerUri);
        Assert.Equal("SendGridUser", noxConfig.Solution!.Infrastructure.Dependencies.Notifications.EmailServer!.User);
        Assert.Equal("SendGridPassword", noxConfig.Solution!.Infrastructure.Dependencies.Notifications.EmailServer!.Password);
        
        Assert.NotNull(noxConfig.Solution!.Infrastructure.Dependencies.Notifications.SmsServer);
        Assert.Equal("SampleSmsServer", noxConfig.Solution!.Infrastructure.Dependencies.Notifications.SmsServer!.Name);
        Assert.Equal(SmsServerProvider.Twilio, noxConfig.Solution!.Infrastructure.Dependencies.Notifications.SmsServer!.Provider);
        Assert.Equal("https://twilio.com", noxConfig.Solution!.Infrastructure.Dependencies.Notifications.SmsServer!.ServerUri);
        Assert.Equal(8080, noxConfig.Solution!.Infrastructure.Dependencies.Notifications.SmsServer!.Port);
        Assert.Equal("TwilioUser", noxConfig.Solution!.Infrastructure.Dependencies.Notifications.SmsServer!.User);
        Assert.Equal("TwilioPassword", noxConfig.Solution!.Infrastructure.Dependencies.Notifications.SmsServer!.Password);
        
        Assert.NotNull(noxConfig.Solution!.Infrastructure.Dependencies.Notifications.ImServer);
        Assert.Equal("SampleImServer", noxConfig.Solution!.Infrastructure.Dependencies.Notifications.ImServer!.Name);
        Assert.Equal(ImServerProvider.WhatsApp, noxConfig.Solution!.Infrastructure.Dependencies.Notifications.ImServer!.Provider);
        Assert.Equal("https://whatsapp.com", noxConfig.Solution!.Infrastructure.Dependencies.Notifications.ImServer!.ServerUri);
        Assert.Equal("whatsappUser", noxConfig.Solution!.Infrastructure.Dependencies.Notifications.ImServer!.User);
        Assert.Equal(8080, noxConfig.Solution!.Infrastructure.Dependencies.Notifications.ImServer!.Port);
        Assert.Equal("whatsappPassword", noxConfig.Solution!.Infrastructure.Dependencies.Notifications.ImServer!.Password);
        
        
        Assert.NotNull(noxConfig.Solution!.Infrastructure.Dependencies.Monitoring);
        Assert.Equal("SampleObservabiity", noxConfig.Solution!.Infrastructure.Dependencies.Monitoring!.Name);
        Assert.Equal("localhost", noxConfig.Solution!.Infrastructure.Dependencies.Monitoring!.ServerUri);
        Assert.Equal(8200, noxConfig.Solution!.Infrastructure.Dependencies.Monitoring!.Port);
        
        Assert.NotNull(noxConfig.Solution!.Infrastructure.Dependencies.Translations);
        Assert.Equal("SampleTranslationService", noxConfig.Solution!.Infrastructure.Dependencies.Translations!.Name);
        Assert.Equal("translator.iwgplc.com", noxConfig.Solution!.Infrastructure.Dependencies.Translations!.ServerUri);
        Assert.Equal(443, noxConfig.Solution!.Infrastructure.Dependencies.Translations!.Port);
        
        Assert.NotNull(noxConfig.Solution!.Infrastructure.Dependencies.Security);
        Assert.NotNull(noxConfig.Solution!.Infrastructure.Dependencies.Security.Secrets);
        Assert.NotNull(noxConfig.Solution!.Infrastructure.Dependencies.Security.Secrets!.SecretsServer);
        Assert.Equal("SampleSecretServer", noxConfig.Solution!.Infrastructure.Dependencies.Security.Secrets!.SecretsServer!.Name);
        Assert.Equal(SecretsServerProvider.AzureKeyVault, noxConfig.Solution!.Infrastructure.Dependencies.Security.Secrets!.SecretsServer!.Provider);
        Assert.Equal("kv.iwgplc.com", noxConfig.Solution!.Infrastructure.Dependencies.Security.Secrets!.SecretsServer!.ServerUri);
        Assert.Equal("secrets@iwgplc.com", noxConfig.Solution!.Infrastructure.Dependencies.Security.Secrets!.SecretsServer!.User);
        Assert.Equal("SecretPassword", noxConfig.Solution!.Infrastructure.Dependencies.Security.Secrets!.SecretsServer!.Password);
        
        Assert.NotNull(noxConfig.Solution!.Infrastructure.Dependencies.Security.Secrets!.ValidFor);
        Assert.Equal(10, noxConfig.Solution!.Infrastructure.Dependencies.Security.Secrets!.ValidFor!.Minutes);
        
        
        Assert.NotNull(noxConfig.Solution!.Infrastructure.Dependencies.DataConnections);
        Assert.Single(noxConfig.Solution!.Infrastructure.Dependencies.DataConnections);
        Assert.Equal("CountryJsonData", noxConfig.Solution!.Infrastructure.Dependencies.DataConnections[0].Name);
        Assert.Equal(DataConnectionProvider.JsonFile, noxConfig.Solution!.Infrastructure.Dependencies.DataConnections[0].Provider);
        Assert.Equal("file:///C:/my-data-files", noxConfig.Solution!.Infrastructure.Dependencies.DataConnections[0].ServerUri);
        Assert.Equal("Source=File;Filename=country-data.json;", noxConfig.Solution!.Infrastructure.Dependencies.DataConnections[0].Options);
    }

    [Fact]
    public void Can_create_a_full_configuration()
    {
        var noxConfig = new NoxConfigurationBuilder()
            .WithYamlFile("./files/sample.solution.nox.yaml")
            .Build();
        Assert.NotNull(noxConfig);
        
    }
    
    [Fact]
    public void Can_a_full_configuration_from_di()
    {
        var services = new ServiceCollection();
        new NoxConfigurationBuilder()
            .WithYamlFile("./files/sample.solution.nox.yaml")
            .WithDependencyInjection(services)
            .Build();
        var provider = services.BuildServiceProvider();
        var config = provider.GetRequiredService<NoxConfiguration>();
        Assert.NotNull(config);
    }
}