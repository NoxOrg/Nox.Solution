using Json.Schema.Generation;

namespace Nox
{

    [AdditionalProperties(false)]
    public class TypeUserInterface : DefinitionBase
    {
        public string? Label { get; set; }
        public string? TranslationId { get; set; }
        public Widget? Widget { get; set; }
        public string? Icon { get; set; }
        public IconPosition? IconPosition { get; set; } = global::Nox.IconPosition.Begin;
        public string? InputMask { get; set; }
        public string? OutputMask { get; set; }
        public string? Regex { get; set; }
        public string? PageGroup { get; set; }
        public string? FieldGroup { get; set; }
        public int InputOrder { get; set; }
        public string HelpHint { get; set; } = ""; //Default to attribute description
        public string ErrorMessage { get; set; } = "";
    }
}