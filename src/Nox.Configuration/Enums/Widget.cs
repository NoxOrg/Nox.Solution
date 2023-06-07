using System;
using System.Linq;

namespace Nox
{
    public enum Widget
    {
        textInput,
        textArea,
        numberInput,
        numberSlider,
        fileUpload,
        datePicker,
        dateRangePicker,
        timePicker,
        timeRangePicker,
        radio,
        select,
        checkbox,
        @switch,
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