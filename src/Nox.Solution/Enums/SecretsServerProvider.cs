using System;
using System.Linq;

namespace Nox
{

    public enum SecretsServerProvider
    {
        AwsKeyManagementService,
        AzureKeyVault,
        HashicorpVault

    }
    
    public static class SecretsServerProviderHelpers
    {
        public static string NameList()
        {
            var list = Enum.GetValues(typeof(SecretsServerProvider))
                .Cast<SecretsServerProvider>()
                .ToList();
            return string.Join(", ", list);
        }
    }
}