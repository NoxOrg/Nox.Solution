using Json.Schema.Generation;

namespace Nox
{

    [AdditionalProperties(false)]
    public class NumberTypeOptions : DefinitionBase
    {
        public int DecimalDigits { get; internal set; } = 0;

        public int IntegerDigits { get; internal set; } = 9;

        public decimal MinValue { get; internal set; } = -999999999;

        public decimal MaxValue { get; internal set; } = 999999999;
    }
}