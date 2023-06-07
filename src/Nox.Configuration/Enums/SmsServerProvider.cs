using System;
using System.Linq;

namespace Nox
{
    public enum SmsServerProvider
    {
        twilio,
        clickSend
    }
    
    public static class SmsServerProviderHelpers
    {
        public static string NameList()
        {
            var list = Enum.GetValues(typeof(SmsServerProvider))
                .Cast<SmsServerProvider>()
                .ToList();
            return string.Join(", ", list);
        }
    }
}