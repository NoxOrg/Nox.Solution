using Json.Schema.Generation;

namespace Nox
{

    [AdditionalProperties(false)]
    public class SecretsValidFor
    {
        public int? Days { get; internal set; }
        public int? Hours { get; internal set; }
        public int? Minutes { get; internal set; }
        public int? Seconds { get; internal set; }
    }
}