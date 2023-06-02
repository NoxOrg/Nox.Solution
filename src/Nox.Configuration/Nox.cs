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
    
}