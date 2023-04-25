using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using RedactorDiagramClassov.Models;

namespace RedactorDiagramClassov.Views.Control
{
    public class ClassInsideaxaml : TemplatedControl
    {
        public static readonly StyledProperty<Point> CustomXProperty =
             AvaloniaProperty.Register<ClassInsideaxaml, Point>("CustomX");
        public Point CustomX
        {
            get => GetValue(CustomXProperty);
            set => SetValue(CustomXProperty, value);
        }
        public static readonly StyledProperty<Point> CustomYProperty =
            AvaloniaProperty.Register<ClassInsideaxaml, Point>("CustomY");
        public Point CustomY
        {
            get => GetValue(CustomYProperty);
            set => SetValue(CustomYProperty, value);
        }
        public static readonly StyledProperty<List<Point>> CustomListTipPointsProperty =
            AvaloniaProperty.Register<ClassInsideaxaml, List<Point>>("CustomListTipPoints");
        public List<Point> CustomListTipPoints
        {
            get => GetValue(CustomListTipPointsProperty);
            set => SetValue(CustomListTipPointsProperty, value);
        }
        public static readonly StyledProperty<SolidColorBrush> FillLineProperty =
            AvaloniaProperty.Register<ClassInsideaxaml, SolidColorBrush>("FillLine");
        public SolidColorBrush FillLine
        {
            get => GetValue(FillLineProperty);
            set => SetValue(FillLineProperty, value);
        }
    }
}
