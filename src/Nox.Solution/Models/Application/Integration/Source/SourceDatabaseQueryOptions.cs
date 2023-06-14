using Json.Schema.Generation;

namespace Nox.Solution;

public class SourceDatabaseQueryOptions
{
    [Required]
    [Title("The query to execute.")]
    [Description("The query that will be executed on the source database.")]
    public string Query { get; set; } = string.Empty;
    
    
    public int MinimumExpectedRecords { get; set; } = 1;
}