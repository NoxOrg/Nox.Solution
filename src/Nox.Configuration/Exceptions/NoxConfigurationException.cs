using System;

namespace Nox.Exceptions
{
    [Serializable]
    public class NoxConfigurationException: Exception
    {
        public NoxConfigurationException(string message): base(message)
        {
            
        }
        
        public NoxConfigurationException(string message, Exception innerException): base(message, innerException)
        {
        
        }
    }
}