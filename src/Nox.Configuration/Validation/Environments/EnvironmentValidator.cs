using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace Nox.Configuration.Validation
{
    public class EnvironmentValidator: AbstractValidator<Environment>
    {
        private readonly IEnumerable<Environment>? _environments;
        
        public EnvironmentValidator(IEnumerable<Environment>? environments)
        {
            if (environments == null) return;
            _environments = environments;
            
            RuleFor(env => env.Name)
                .NotEmpty()
                .WithMessage(env => string.Format(ValidationResources.EnvironmentNameEmpty, env.Ref));

            RuleFor(env => env.Name).Must(HaveUniqueName)
                .WithMessage(env => string.Format(ValidationResources.EnvironmentNameDuplicate, env.Name, env.Ref));

        }

        private bool HaveUniqueName(Environment toEvaluate, string name)
        {
            return _environments!.All(env => env.Equals(toEvaluate) || env.Name != name);
        }
    }
}