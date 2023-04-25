using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace RedactorDiagramClassov.Views.Control
{
    public class TemplatedControl1 : TemplatedControl
    {
        public static readonly StyledProperty<Point> CustomXProperty =
             AvaloniaProperty.Register<TemplatedControl1, Point>("CustomX");
        public Point CustomX
        {
            get => GetValue(CustomXProperty);
            set => SetValue(CustomXProperty, value);
        }
        public static readonly StyledProperty<Point> CustomYProperty =
            AvaloniaProperty.Register<TemplatedControl1, Point>("CustomY");
        public Point CustomY
        {
            get => GetValue(CustomYProperty);
            set => SetValue(CustomYProperty, value);
        }
    }
}
