using Json.Schema.Generation;

namespace Nox.Solution;

public class SourceFileOptions
{
    [Required] 
    [Title("The file name.")]
    [Description("The name of the file that will be ingested.")]
    public string Filename { get; set; } = string.Empty;
    public int MinimumExpectedRecords { get; set; } = 1;
}