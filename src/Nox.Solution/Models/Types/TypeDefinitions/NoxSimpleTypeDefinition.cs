using Json.Schema.Generation;

namespace Nox.Solution
{

    [Title("Defines the request parameters for a domain query.")]
    [Description("The ordered parameters that is the input for the requested query. Can contain simple or complex types")]
    [AdditionalProperties(false)]
    public class NoxSimpleTypeDefinition : DefinitionBase
    {
        [Required]
        [Pattern(@"^[^\s]*$")]
        public string Name { get; internal set; } = string.Empty;
        
        public string? Description { get; internal set; }

        [Required]
        public NoxType? Type { get; internal set; }

        #region TypeOptions

        public TextTypeOptions? TextTypeOptions { get; set; }
        public NumberTypeOptions? NumberTypeOptions { get; set; }
        public MoneyTypeOptions? MoneyTypeOptions { get; set; }
        public EntityTypeOptions? EntityTypeOptions { get; set; }

        #endregion

        public bool IsRequired { get; internal set; } = false;

        public TypeUserInterface? UserInterface { get; internal set; }

        public bool IsReadonly { get; internal set; } = false;

    }
}