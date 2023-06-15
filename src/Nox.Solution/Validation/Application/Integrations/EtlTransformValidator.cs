using FluentValidation;

namespace Nox.Solution.Validation
{
    public class EtlTransformValidator: AbstractValidator<IntegrationTransform>
    {
        public EtlTransformValidator(string etlName)
        {
            RuleForEach(p => p.Mappings)
                .SetValidator(v => new EtlMappingValidator(etlName));

            RuleForEach(p => p.Lookups)
                .SetValidator(v => new EtlLookupValidator(etlName));
        }
    }
}