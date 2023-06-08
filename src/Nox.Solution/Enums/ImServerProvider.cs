using System;
using System.Linq;

namespace Nox
{
    public enum ImServerProvider
    {
        WhatsApp,
        Telegram
    }
    
    public static class ImServerProviderHelpers
    {
        public static string NameList()
        {
            var list = Enum.GetValues(typeof(ImServerProvider))
                .Cast<ImServerProvider>()
                .ToList();
            return string.Join(", ", list);
        }
    }
}