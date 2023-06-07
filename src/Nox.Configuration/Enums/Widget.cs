using System;
using System.Linq;

namespace Nox
{
    public enum Widget
    {
        TextInput,
        TextArea,
        NumberInput,
        NumberSlider,
        FileUpload,
        DatePicker,
        DateRangePicker,
        TimePicker,
        TimeRangePicker,
        Radio,
        Select,
        Checkbox,
        @Switch,
    }
    
    public static class WidgetHelpers
    {
        public static string NameList()
        {
            var list = Enum.GetValues(typeof(Widget))
                .Cast<Widget>()
                .ToList();
            return string.Join(", ", list);
        }
    }
}