using Json.Schema.Generation;

namespace Nox
{

    [AdditionalProperties(false)]
    public class DatabaseWatermark
    {
        public string[]? DateColumns { get; set; }
        public string? SequentialKeyColumn { get; set; }
    }
}