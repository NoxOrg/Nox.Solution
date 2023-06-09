using System;
using System.Linq;

namespace Nox;

public enum BffServerProvider
{
    Blazor
}

public static class BffServerProviderHelpers
{
    public static string NameList()
    {
        var list = Enum.GetValues(typeof(BffServerProvider))
            .Cast<BffServerProvider>()
            .ToList();
        return string.Join(", ", list);
    }
}