using Json.Schema.Generation;

namespace Nox.Solution
{
    [Title("UI display options for this attribute.")]
    [Description("Specify how this attribute is rendered on the Nox user interface. Configuration options include label, icon, input/output masks, help hints among other.")]
    [AdditionalProperties(false)]
    public class TypeUserInterface : DefinitionBase
    {
        [Title("A descriptive label for this attribute on the UI.")]
        [Description("The text label rendered on the user interface alongside the NoxTextInput component.")]
        public string? Label { get; internal set; }

        // Pending implementation details
        public string? TranslationId { get; internal set; }

        // Pending implementation details
        public Widget? Widget { get; internal set; }

        [Title("The icon representing the attribute on the UI.")]
        [Description("A reference URI to the attribute icon file. Could be a CSS or Mudblazor reference, e.g. '@Icons.Material.Filled.Globe'.")]
        public string? Icon { get; internal set; }

        [Title("The position of the attribute icon on the UI.")]
        [Description("The postition of the attribute icon relative to the text input area on the user interface, e.g. begin or end.")]
        public IconPosition? IconPosition { get; internal set; } = global::Nox.IconPosition.Begin;

        [Title("A mask expression used to validate and control text input.")]
        [Description("A string of characters that indicates the format of valid input values. Examples include '*?@?*.?*' for an email address and '(000) 000-0000' for a seven digit phone number with mandatory area code.")]
        public string? InputMask { get; internal set; }

        [Title("A mask expression used to validate and control text output.")]
        [Description("A string of characters that indicates the format of valid output. Used to handle validation triggers for onSubmit and onChange events of the control.")]
        public string? OutputMask { get; internal set; }

        [Title("The regular expression against which input is validated.")]
        [Description("A regex string that indicates the format of valid input. Examples include '/^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$/gm' for email address and '/^(\\([0-9]{3}\\) |[0-9]{3}-)[0-9]{3}-[0-9]{4}$/gm' for a seven digit phone number with mandatory area code.")]
        public string? Regex { get; internal set; }

        [Title("The UI PageGroup ID.")]
        [Description("Used to associate component with a PageGroup ID on the user interface.")]
        public string? PageGroup { get; internal set; }

        [Title("The UI FieldGroup ID.")]
        [Description("Used to associate component with a FieldGroup ID on the user interface.")]
        public string? FieldGroup { get; internal set; }

        [Title("FieldGroup tab order for this UI component.")]
        [Description("Used to define the sequentially focusable Tab Order of the UI component within a FieldGroup.")]
        public int InputOrder { get; internal set; }

        [Title("Helper text for this component.")]
        [Description("The component default helper text used to aid the understanding of the component function to the user.")]
        public string HelpHint { get; internal set; } = ""; //Default to attribute description

        [Title("Validation error message.")]
        [Description("The default error message displayed when text input validation fails.")]
        public string ErrorMessage { get; internal set; } = "";
    }
}