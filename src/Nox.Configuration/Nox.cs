
namespace Nox
{

    public class Nox
    {
        public static NoxSolutionBuilder CreateBuilder()
        {
            var builder = new NoxSolutionBuilder();

            return builder;
        }
    }

    public class NoxSolutionBuilder
    {
        public NoxConfigurationBuilder Configuration { get; } = new NoxConfigurationBuilder();


    }

    public class NoxConfiguration
    {

    }


    public class NoxConfigurationBuilder
    {

        private string _yamlFilePath = string.Empty;

        public NoxConfigurationBuilder AddYamlFile(string yamlFilePath)
        {
            _yamlFilePath = yamlFilePath;
            return this;
        }

        public NoxConfiguration Build()
        {
            return new NoxConfiguration();
        }
    }
}