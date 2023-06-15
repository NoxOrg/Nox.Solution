using FluentValidation;

namespace Nox.Solution.Validation
{
    public class IntegrationTransformValidator: AbstractValidator<IntegrationTransform>
    {
        public IntegrationTransformValidator(string integrationName)
        {
            RuleForEach(p => p.Map)
                .SetValidator(v => new IntegrationMappingValidator(integrationName));

            RuleForEach(p => p.Lookup)
                .SetValidator(v => new IntegrationLookupValidator(integrationName));
        }
    }
}