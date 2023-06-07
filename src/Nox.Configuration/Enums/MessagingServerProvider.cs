using System;
using System.Linq;

namespace Nox
{
    public enum MessagingServerProvider
    {
        MediatR,
        RabbitMq,
        AzureServiceBus,
        AmazonSqs,
    }
    
    public static class MessagingServerProviderHelpers
    {
        public static string NameList()
        {
            var list = Enum.GetValues(typeof(MessagingServerProvider))
                .Cast<MessagingServerProvider>()
                .ToList();
            return string.Join(", ", list);
        }
    }
}
