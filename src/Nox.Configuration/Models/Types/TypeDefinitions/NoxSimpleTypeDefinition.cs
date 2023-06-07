using Json.Schema.Generation;

namespace Nox
{

    [Title("Defines the request parameters for a domain query.")]
    [Description("The ordered parameters that is the input for the requested query. Can contain simple or complex types")]
    [AdditionalProperties(false)]
    public class NoxSimpleTypeDefinition : DefinitionBase
    {
        [Required]
        [Pattern(@"^[^\s]*$")]
        public string Name { get; set; } = string.Empty;
        
        public string? Description { get; set; }

        [Required]
        public NoxType? Type { get; set; }

        #region TypeOptions

        public TextTypeOptions? TextTypeOptions { get; set; }
        public NumberTypeOptions? NumberTypeOptions { get; set; }
        public MoneyTypeOptions? MoneyTypeOptions { get; set; }
        public EntityTypeOptions? EntityTypeOptions { get; set; }

        #endregion

        public bool IsRequired { get; set; } = false;

        public TypeUserInterface? UserInterface { get; set; }

        public bool IsReadonly { get; set; } = false;

    }
}