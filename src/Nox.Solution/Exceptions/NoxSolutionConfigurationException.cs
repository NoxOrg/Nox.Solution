using System;

namespace Nox.Exceptions
{
    [Serializable]
    public class NoxSolutionConfigurationException: Exception
    {
        public NoxSolutionConfigurationException(string message): base(message)
        {
            
        }
        
        public NoxSolutionConfigurationException(string message, Exception innerException): base(message, innerException)
        {
        
        }
    }
}