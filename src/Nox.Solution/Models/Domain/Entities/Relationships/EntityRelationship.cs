﻿using Json.Schema.Generation;

namespace Nox
{
    [Title("Defines a one way relationship to another entity.")]
    [Description("Defines a one way relationship to another entity. It is required to define the reverse relationship on the target entity.")]
    [AdditionalProperties(false)]
    public class EntityRelationship : DefinitionBase
    {
        [Required]
        [Title("The name of the relationship. Contains no spaces.")]
        [Description("The name of the relationship, usually in the format EntityRelationshipTargetEntity. Eg \"CountryHasCapitalCity\".")]
        [Pattern(@"^[^\s]*$")]
        public string Name { get; internal set; } = string.Empty;

        [Required]
        [Title("A phrase describing the relationship with the target entity.")]
        [Description("A phrase that describes the relationship of the form <entity> <phrase> <targetEntity>. Eg. \"has capital\" like in <Country> <has capital> <City>")]
        public string? Description { get; internal set; }

        [Required]
        [Title("The type/cardinality of the relationship.")]
        [Description("The cardinality (type) of relationship with the target entity.")]
        public EntityRelationshipType? Relationship { get; internal set; }

        [Required]
        [Title("The target entity that relates to this entity.")]
        [Description("The name of the target entity that this entity relates to.")]
        public string? Entity { get; internal set; }

    }
}