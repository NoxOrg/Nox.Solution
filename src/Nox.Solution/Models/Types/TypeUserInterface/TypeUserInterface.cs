using Json.Schema.Generation;

namespace Nox
{

    [AdditionalProperties(false)]
    public class TypeUserInterface : DefinitionBase
    {
        public string? Label { get; internal set; }
        public string? TranslationId { get; internal set; }
        public Widget? Widget { get; internal set; }
        public string? Icon { get; internal set; }
        public IconPosition? IconPosition { get; internal set; } = global::Nox.IconPosition.Begin;
        public string? InputMask { get; internal set; }
        public string? OutputMask { get; internal set; }
        public string? Regex { get; internal set; }
        public string? PageGroup { get; internal set; }
        public string? FieldGroup { get; internal set; }
        public int InputOrder { get; internal set; }
        public string HelpHint { get; internal set; } = ""; //Default to attribute description
        public string ErrorMessage { get; internal set; } = "";
    }
}