using System;
using System.Linq;

namespace Nox
{
    public enum SmsServerProvider
    {
        Twilio,
        ClickSend
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