using Json.Schema.Generation;

namespace Nox.Solution
{
    public class EtlMatch
    {
        [Required]
        [Title("Name of the lookup table.")]
        [Description("Specify the table name used for the lookup at the data source.")]
        public string Table { get; internal set; } = string.Empty;

        [Required]
        [Title("Name of the lookup column.")]
        [Description("Specify the column used for the lookup at the data source.")]
        public string LookupColumn { get; internal set; } = string.Empty;

        [Required]
        [Title("Name of the column used for the return value.")]
        [Description("Specify the return column of which the value is used for the lookup result.")]
        public string ReturnColumn { get; internal set; } = string.Empty;
    }
}