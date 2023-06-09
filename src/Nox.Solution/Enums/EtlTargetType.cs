using System;
using System.Linq;

namespace Nox;

public enum EtlTargetType
{
    Database,
    Entity,
    File,
    WebApi,
    MessageQueue
}

public static class EtlTargetTypeHelpers
{
    public static string NameList()
    {
        var list = Enum.GetValues(typeof(EtlTargetType))
            .Cast<EtlTargetType>()
            .ToList();
        return string.Join(", ", list);
    }
}