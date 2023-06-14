using Json.Schema.Generation;

namespace Nox.Solution
{

    [AdditionalProperties(false)]
    public class IntegrationSourceDatabaseWatermark
    {
        public string[]? DateColumns { get; internal set; }
        public string? SequentialKeyColumn { get; internal set; }
    }
}