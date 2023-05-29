using Json.Schema.Generation;

namespace Nox
{

    [AdditionalProperties(false)]
    public class NumberTypeOptions : DefinitionBase
    {
        public int DecimalDigits { get; set; } = 0;

        public int IntegerDigits { get; set; } = 9;

        public decimal MinValue { get; set; } = -999999999;

        public decimal MaxValue { get; set; } = 999999999;
    }
}