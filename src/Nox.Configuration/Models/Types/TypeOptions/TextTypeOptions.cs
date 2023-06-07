using Json.Schema.Generation;

namespace Nox
{

    [AdditionalProperties(false)]
    public class TextTypeOptions: DefinitionBase
    {
        public bool IsUnicode { get; set; } = true;

        public int MinLength { get; set; } = 0;

        public int MaxLength { get; set; } = 511;

        public TextTypeCasing CharacterCasing { get; set; } = TextTypeCasing.normal;

        public bool IsMultiline { get; set; } = false;
    }
}