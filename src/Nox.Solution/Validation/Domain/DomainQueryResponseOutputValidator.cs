using FluentValidation;

namespace Nox.Solution.Validation
{
    public class DomainQueryResponseOutputValidator: AbstractValidator<DomainQueryResponseOutput>
    {
        public DomainQueryResponseOutputValidator(string queryName)
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage(m => string.Format(ValidationResources.DomainQueryResponseNameEmpty, queryName));
            
            RuleFor(p => p.Type)
                .NotEmpty()
                .WithMessage(m => string.Format(ValidationResources.DomainQueryResponseTypeEmpty, queryName));

            RuleFor(p => p.CollectionTypeOptions!)
                .SetValidator(v => new CollectionTypeOptionsValidator($"response output of query '{queryName}'"));
        }    
    }
}