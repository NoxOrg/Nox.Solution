using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace Nox
{
    internal class IntegrationValidator: AbstractValidator<Integration>
    {
        private readonly IEnumerable<Integration>? _integrations;
        private readonly IEnumerable<DataConnection>? _dataConnections;

        public IntegrationValidator(IEnumerable<Integration>? integrations, IEnumerable<DataConnection>? dataConnections)
        {
            if (integrations == null) return;
            _dataConnections = dataConnections;
            _integrations = integrations;
            
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage(string.Format(ValidationResources.EtlNameEmpty));

            RuleFor(p => p.Name).Must(HaveUniqueName)
                .WithMessage(m => string.Format(ValidationResources.EtlNameDuplicate, m.Name));

            RuleFor(p => p.Source)
                .NotEmpty()
                .WithMessage(m => string.Format(ValidationResources.EtlSourceMissing, m.Name));

            RuleFor(p => p.Source!)
                .SetValidator(v => new EtlSourceValidator(v.Name, _dataConnections));

            RuleFor(p => p.Transform!)
                .SetValidator(v => new EtlTransformValidator(v.Name));
            
            RuleFor(p => p.Target)
                .NotEmpty()
                .WithMessage(m => string.Format(ValidationResources.EtlTargetMissing, m.Name));
            
            RuleFor(p => p.Target!)
                .SetValidator(v => new EtlTargetValidator(v.Name, _dataConnections));
        }
        
        private bool HaveUniqueName(Integration toEvaluate, string name)
        {
            return _integrations!.All(dto => dto.Equals(toEvaluate) || dto.Name != name);
        }
    }
}