using Json.Schema.Generation;

namespace Nox
{

    [AdditionalProperties(false)]
    public class MoneyTypeOptions : DefinitionBase
    {
        public int DecimalDigits { get; set; } = 4;

        public int IntegerDigits { get; set; } = 9;

        public decimal MinValue { get; set; } = -999999999.9999M;

        public decimal MaxValue { get; set; } = 999999999.9999M;

        public CurrencyCode DefaultCurrency { get; set; } = CurrencyCode.USD;
    }
}