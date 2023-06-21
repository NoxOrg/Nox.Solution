using System.Collections.Generic;
using System.IO;
using System;
using FluentValidation;
using Nox.Types;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using System.Text.Json;
using Json.Schema.Generation.Generators;
using Json.Schema;
using Json.Schema.Generation.Intents;
using Json.Schema.Generation;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml;

namespace Nox.Solution.Validation
{
    internal class SolutionValidator : AbstractValidator<Solution>
    {
        public SolutionValidator()
        {
            RuleFor(solution => solution.Name)
                .NotEmpty()
                .WithMessage(solution => string.Format(ValidationResources.SolutionNameEmpty));

            RuleForEach(sln => sln.Environments)
                .SetValidator(sln => new EnvironmentValidator(sln.Environments));

            RuleFor(sln => sln.VersionControl!)
                .SetValidator(new VersionControlValidator());

            RuleForEach(sln => sln.Team)
                .SetValidator(sln => new TeamValidator(sln.Team));

            RuleFor(sln => sln.Domain!)
                .SetValidator(new DomainValidator());

            RuleFor(sln => sln.Application!)
                .SetValidator(sln => new ApplicationValidator(sln.Infrastructure?.Dependencies?.DataConnections));

            RuleFor(sln => sln.Infrastructure!)
                .SetValidator(new InfrastructureValidator());
        }
    }
}