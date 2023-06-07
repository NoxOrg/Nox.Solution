using System;
using System.Linq;

namespace Nox
{
    public enum EtlMappingConverter
    {
        UpperCase,
        LowerCase
    }
    
    public static class EtlMappingConverterHelpers
    {
        public static string NameList()
        {
            var list = Enum.GetValues(typeof(EtlMappingConverter))
                .Cast<EtlMappingConverter>()
                .ToList();
            return string.Join(", ", list);
        }
    }
}