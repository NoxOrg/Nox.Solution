using FluentValidation;

namespace Nox.Validation.Application.Integration
{
    public class EtlTransformValidator: AbstractValidator<EtlTransform>
    {
        public EtlTransformValidator(string etlName)
        {
            RuleForEach(p => p.Map)
                .SetValidator(v => new EtlMappingValidator(etlName));

            RuleForEach(p => p.Lookup)
                .SetValidator(v => new EtlLookupValidator(etlName));
        }
    }
}