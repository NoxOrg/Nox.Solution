using System;
using System.Linq;

namespace Nox
{
    public enum TextTypeCasing
    {
        normal,
        lower,
        upper
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