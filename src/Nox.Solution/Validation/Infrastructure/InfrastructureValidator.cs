using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace Nox
{
    internal class InfrastructureValidator: AbstractValidator<Infrastructure>
    {
        private IEnumerable<ServerBase>? _servers;

        public InfrastructureValidator()
        {
            RuleFor(p => p.Persistence)
                .NotEmpty()
                .WithMessage(ValidationResources.InfrastructurePersistenceEmpty);
            
            RuleFor(p => p.Persistence!)
                .SetValidator(v => new PersistenceValidator(GetServerList(v)));
            
            RuleFor(p => p.Messaging)
                .NotEmpty()
                .WithMessage(ValidationResources.InfrastructureMessagingEmpty);
            
            RuleFor(p => p.Messaging!)
                .SetValidator(v => new MessagingValidator(GetServerList(v)));
            
            RuleFor(p => p.Endpoints!)
                .SetValidator(v => new EndpointsValidator(GetServerList(v)));
            
            RuleFor(p => p.Dependencies!)
                .SetValidator(v => new DependenciesValidator(GetServerList(v)));
            
        }

        private IEnumerable<ServerBase>? GetServerList(Infrastructure infra)
        {
            if (_servers == null)
            {
                _servers = new List<ServerBase>();
                var servers = new List<ServerBase>();
                if (infra.Persistence != null)
                {
                    if (infra.Persistence.DatabaseServer != null) servers.Add(infra.Persistence.DatabaseServer);
                    if (infra.Persistence.CacheServer != null) servers.Add(infra.Persistence.CacheServer);
                    if (infra.Persistence.SearchServer != null) servers.Add(infra.Persistence.SearchServer);
                    if (infra.Persistence.EventSourceServer != null) servers.Add(infra.Persistence.EventSourceServer);    
                }

                if (infra.Messaging != null)
                {
                    if (infra.Messaging.DomainEventServer != null) servers.Add(infra.Messaging.DomainEventServer);
                    if (infra.Messaging.IntegrationEventServer != null) servers.Add(infra.Messaging.IntegrationEventServer);
                }

                if (infra.Endpoints != null)
                {
                    if (infra.Endpoints.ApiServer != null) servers.Add(infra.Endpoints.ApiServer);
                    if (infra.Endpoints.BffServer != null) servers.Add(infra.Endpoints.BffServer);
                }

                if (infra.Dependencies != null)
                {
                    if (infra.Dependencies.Notifications != null)
                    {
                        if (infra.Dependencies.Notifications.EmailServer != null) servers.Add(infra.Dependencies.Notifications.EmailServer);
                        if (infra.Dependencies.Notifications.SmsServer != null) servers.Add(infra.Dependencies.Notifications.SmsServer);
                        if (infra.Dependencies.Notifications.ImServer != null) servers.Add(infra.Dependencies.Notifications.ImServer);
                    }
                    
                    if (infra.Dependencies.Monitoring != null) servers.Add(infra.Dependencies.Monitoring);
                    
                    if (infra.Dependencies.Translations != null) servers.Add(infra.Dependencies.Translations);
                    
                    if (infra.Dependencies.Security != null)
                    {
                        if (infra.Dependencies.Security.Secrets is { SecretsServer: { } }) servers.Add(infra.Dependencies.Security.Secrets.SecretsServer);
                    }
                    
                    if (infra.Dependencies.DataConnections != null)
                    {
                        foreach (var dataConnection in infra.Dependencies.DataConnections)
                        {
                            servers.Add(dataConnection);
                        }
                    }
                        
                }
                
                _servers = servers;
            }
            
            return _servers;
        }
    }
}