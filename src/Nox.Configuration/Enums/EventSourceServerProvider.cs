using System;
using System.Linq;

namespace Nox
{
    public enum EventSourceServerProvider
    {
        eventStoreDb
    }
    
    public static class EventSourceServerProviderHelpers
    {
        public static string NameList()
        {
            var list = Enum.GetValues(typeof(EventSourceServerProvider))
                .Cast<EventSourceServerProvider>()
                .ToList();
            return string.Join(", ", list);
        }
    }
}