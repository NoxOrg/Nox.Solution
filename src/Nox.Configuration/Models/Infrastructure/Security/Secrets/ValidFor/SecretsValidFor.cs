using Json.Schema.Generation;

namespace Nox;

[AdditionalProperties(false)]
public class SecretsValidFor
{
    public int? Days { get; set; }
    public int? Hours { get; set; }
    public int? Minutes { get; set; }
    public int? Seconds { get; set; }
}