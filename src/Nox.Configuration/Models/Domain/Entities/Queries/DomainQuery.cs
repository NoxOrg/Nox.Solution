using Json.Schema.Generation;
using System.Collections.Generic;

namespace Nox
{
    [Title("Defines a query for the domain.")]
    [Description("Defines a query that operates on the domain. Queries should have no side effects and not mutate the domain state.")]
    [AdditionalProperties(false)]
    public class DomainQuery : DefinitionBase
    {
        [Required]
        [Title("The name of the relationship. Contains no spaces.")]
        [Description("The name of the query, usually in the format Get<x>by<y>. Eg \"GetCapitalCitiesByContinent\".")]
        [Pattern(@"^[^\s]*$")]
        public string Name { get; internal set; } = string.Empty;

        [Title("A phrase describing the relationship with the target entity.")]
        [Description("A phrase that describes the relationship of the form <entity> <phrase> <targetEntity>. Eg. \"has capital\" like in <Country> <has capital> <City>.")]
        public string? Description { get; internal set; }

        [AdditionalProperties(false)]
        public List<DomainQueryRequestInput>? RequestInput { get; internal set; }

        [Required]
        [AdditionalProperties(false)]
        public DomainQueryResponseOutput? ResponseOutput { get; internal set; }
    }
}