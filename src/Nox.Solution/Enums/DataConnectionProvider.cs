using System;
using System.Linq;

namespace Nox
{
    public enum DataConnectionProvider
    {
        AmazonSqs,
        AzureServiceBus,
        CsvFile,
        ExcelFile,
        JsonFile,
        MySql,
        ParquetFile,
        Postgres,
        RabbitMq,
        SqlServer,
        WebApi,
        XmlFile,
        InMemory
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