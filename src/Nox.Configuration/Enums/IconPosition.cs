using System;
using System.Linq;

namespace Nox
{
    public enum IconPosition
    {
        begin,
        end
    }
    
    public static class IconPositionHelpers
    {
        public static string NameList()
        {
            var list = Enum.GetValues(typeof(IconPosition))
                .Cast<IconPosition>()
                .ToList();
            return string.Join(", ", list);
        }
    }
}