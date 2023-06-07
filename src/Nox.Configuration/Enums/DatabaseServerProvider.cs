using System;
using System.Linq;

namespace Nox
{
    public enum DatabaseServerProvider
    {
        sqlServer,
        postgres,
        mySql,
        sqlLite,
    }
    
    public static class DatabaseServerProviderHelpers
    {
        public static string NameList()
        {
            var list = Enum.GetValues(typeof(DatabaseServerProvider))
                .Cast<DatabaseServerProvider>()
                .ToList();
            return string.Join(", ", list);
        }
    }
}
