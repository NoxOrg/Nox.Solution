using Json.Schema.Generation;

namespace Nox
{
    [Title("Defines a one way owned relationship to another entity.")]
    [Description("Defines a one way relationship to an owned entity. This automatically flags this entity as an aggregate root.")]
    [AdditionalProperties(false)]
    public class EntityOwnedRelationship : DefinitionBase
    {
        [Required]
        [Title("The name of the relationship. Contains no spaces.")]
        [Description("The name of the relationship, usually in the format EntityRelationshipTargetEntity. Eg \"CountryHasCapitalCity\".")]
        [Pattern(@"^[^\s]*$")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Title("A phrase describing the relationship with the target entity.")]
        [Description("A \"phrase\" part that describes the relationship of the form <entity> <phrase> <targetEntity>. Eg. \"has capital\" like in <Country> <has capital> <City>")]
        public string? Description { get; set; }

        [Required]
        [Title("The type/cardinality of the relationship.")]
        [Description("The cardinality (type) of relationship with the target entity.")]
        public EntityRelationshipType? Relationship { get; set; }

        [Required]
        [Title("The target entity that relates to this entity.")]
        [Description("The name of the target entity that this entity relates to.")]
        public string? Entity { get; set; }

    }
}