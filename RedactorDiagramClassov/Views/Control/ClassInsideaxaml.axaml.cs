using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace RedactorDiagramClassov.Views.Control
{
    public class ClassInsideaxaml : TemplatedControl
    {
        public static readonly StyledProperty<double> CustomXProperty =
            AvaloniaProperty.Register<ClassInsideaxaml, double>("CustomX");

        public double CustomX 
        {
            get => GetValue(CustomXProperty);
            set => SetValue(CustomXProperty, value);
        }
        public static readonly StyledProperty<double> CustomYProperty =
            AvaloniaProperty.Register<ClassInsideaxaml, double>("CustomY");

        public double CustomY
        {
            get => GetValue(CustomYProperty);
            set => SetValue(CustomYProperty, value);
        }
    }
}
