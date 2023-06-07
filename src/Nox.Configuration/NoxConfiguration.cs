using FluentValidation;
using Nox.Configuration.Validation;
using Nox.Utilities.Yaml;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Nox
{
    public class NoxConfiguration
    {
        private readonly string _rootYamlFile;
        private Solution? _solution;

        public Solution? Solution => _solution;

        public NoxConfiguration(string rootYamlFile)
        {
            _rootYamlFile = rootYamlFile;
            var resolver = new YamlResolver(_rootYamlFile);
            var yaml = resolver.ResolveReferences();
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
            _solution = deserializer.Deserialize<Solution>(yaml);
        }

        internal void Validate()
        {
            var validator = new SolutionValidator();
            validator.ValidateAndThrow<Solution>(_solution!);
        }
    }
}