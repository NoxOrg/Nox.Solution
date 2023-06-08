using System;
using System.Linq;

namespace Nox
{
    public enum TextTypeCasing
    {
        Normal,
        Lower,
        Upper
    }
    
    public static class TextTypeCasingHelpers
    {
        public static string NameList()
        {
            var list = Enum.GetValues(typeof(TextTypeCasing))
                .Cast<TextTypeCasing>()
                .ToList();
            return string.Join(", ", list);
        }
    }
}