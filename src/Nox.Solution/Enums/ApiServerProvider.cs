using System;
using System.Linq;

namespace Nox;

public enum ApiServerProvider
{
    AttributeRouting,
    OData,
    Grpc,
    GraphQl
}

public static class ApiServerProviderHelpers
{
    public static string NameList()
    {
        var list = Enum.GetValues(typeof(ApiServerProvider))
            .Cast<ApiServerProvider>()
            .ToList();
        return string.Join(", ", list);
    }
}