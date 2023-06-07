using System;
using System.Linq;

namespace Nox
{
    public enum EmailServerProvider
    {
        SendGrid,
        Mailchimp
    }
    
    public static class EmailServerProviderHelpers
    {
        public static string NameList()
        {
            var list = Enum.GetValues(typeof(EmailServerProvider))
                .Cast<EmailServerProvider>()
                .ToList();
            return string.Join(", ", list);
        }
    }
}