using Json.Schema.Generation;

namespace Nox
{

    [AdditionalProperties(false)]
    public class TranslatedTextTypeOptions : DefinitionBase
    {
        public int MinLength { get; set; } = 0;

        public int MaxLength { get; set; } = 511;

        public TextTypeCasing CharacterCasing { get; set; } = TextTypeCasing.Normal;
    }
}