using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Nox.Solution.Events;

namespace Nox.Solution.Validation;

public class DomainEventValidator: AbstractValidator<DomainEvent>
{
    private readonly IEnumerable<DomainEvent>? _allEvents;

    public DomainEventValidator(IEnumerable<DomainEvent>? allEvents, string entityName)
    {
        if (_allEvents == null) return;
        _allEvents = allEvents;

        RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage(m => string.Format(ValidationResources.DomainEventNameEmpty, entityName));
            
        RuleFor(c => c.Name).Must(HaveUniqueName)
            .WithMessage(m => string.Format(ValidationResources.DomainEventNameDuplicate, m.Name, entityName));

        RuleFor(c => c.Type)
            .NotEmpty()
            .WithMessage(m => string.Format(ValidationResources.DomainEventTypeEmpty, m.Name, entityName));

        RuleFor(c => c.ObjectTypeOptions!)
            .SetValidator(v => new ObjectTypeOptionsValidator($"domain event '{v.Name}' in entity '{entityName}'", "Domain events"));
    }
        
    private bool HaveUniqueName(DomainEvent toEvaluate, string name)
    {
        return _allEvents!.All(q => q.Equals(toEvaluate) || q.Name != name);
    }
}