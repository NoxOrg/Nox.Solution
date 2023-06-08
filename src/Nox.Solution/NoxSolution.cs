using FluentValidation;

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