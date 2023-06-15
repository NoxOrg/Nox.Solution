using FluentValidation;

namespace Nox.Solution.Validation
{
    public class IntegrationTransformValidator: AbstractValidator<IntegrationTransform>
    {
        public IntegrationTransformValidator(string etlName)
        {
            RuleForEach(p => p.Mappings)
                .SetValidator(v => new IntegrationMappingValidator(etlName));

            RuleForEach(p => p.Lookups)
                .SetValidator(v => new IntegrationLookupValidator(etlName));
        }
    }
}