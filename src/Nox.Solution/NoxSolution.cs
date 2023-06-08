using FluentValidation;
using Nox.Configuration.Validation;
using Nox.Utilities.Yaml;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Nox
{
    public class NoxSolution : Solution
    {
        public string? RootYamlFile { get; internal set; }

        internal void Validate()
        {
            var validator = new SolutionValidator();
            validator.ValidateAndThrow<Solution>((Solution)this);
        }
    }
}