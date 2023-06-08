using Json.Schema.Generation;

namespace Nox
{

    [AdditionalProperties(false)]
    public class DataConnection : ServerBase
    {
        public DataConnectionProvider? Provider { get; internal set; }
    }
}