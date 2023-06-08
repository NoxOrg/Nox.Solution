using System;
using System.Linq;

namespace Nox
{
    public enum MessagingServerProvider
    {
        RabbitMq,
        AzureServiceBus,
        AmazonSqs,
        InMemory
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

        public static string GetProviderScheme(MessagingServerProvider provider)
        {
            switch (provider)
            {
                case MessagingServerProvider.RabbitMq:
                    return "rabbitmq";
                case MessagingServerProvider.AzureServiceBus:
                    return "sb";
                default:
                    return "";
            }
        }
    }
}
