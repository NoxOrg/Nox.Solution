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
