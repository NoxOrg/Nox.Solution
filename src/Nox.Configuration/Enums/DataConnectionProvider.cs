using System;
using System.Linq;

namespace Nox
{
    public enum DataConnectionProvider
    {
        amazonSqs,
        azureServiceBus,
        csvFile,
        excelFile,
        jsonFile,
        mySql,
        parquetFile,
        postgres,
        rabbitMq,
        sqlServer,
        webApi,
        xmlFile
    }
    
    public static class DataConnectionProviderHelpers
    {
        public static string NameList()
        {
            var list = Enum.GetValues(typeof(DataConnectionProvider))
                .Cast<DataConnectionProvider>()
                .ToList();
            return string.Join(", ", list);
        }
    }
}