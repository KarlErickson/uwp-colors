using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace UwpColors
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        List<NamedColor> NamedColors { get; } =
            (from property in typeof(Colors).GetRuntimeProperties()
             let color = (Color)property.GetValue(null)
             select new NamedColor
             {
                 Brush = new SolidColorBrush(color),
                 Name = color.GetName(),
                 ForegroundBrush = new SolidColorBrush(color.GetContrastingForegroundColor())
             })
            .ToList();
    }

    public class NamedColor
    {
        public Brush Brush { get; set; }
        public string Name { get; set; }
        public Brush ForegroundBrush { get; set; }
    }
}
