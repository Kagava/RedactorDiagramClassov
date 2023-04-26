using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.VisualTree;

namespace RedactorDiagramClassov.Views.Control
{
    public class InnerClass : TemplatedControl
    {
        static InnerClass()
        {
            DoubleTappedEvent.AddClassHandler<InnerClass>(
                (sender, args) => sender.OnDoubleTapped(args));
        }
        protected virtual void OnDoubleTapped(RoutedEventArgs routedEventArgs)
        {
            var descendants = this.GetVisualDescendants();
            var border = descendants.OfType<Border>()
                .FirstOrDefault(control =>
                                string.IsNullOrEmpty(control.Name) == false &&
                                control.Name.Equals("downGridBorder"));
            var grid = descendants.OfType<Grid>()
                                .FirstOrDefault(control =>
                                string.IsNullOrEmpty(control.Name) == false &&
                                control.Name.Equals("downGrid"));
            
            if (border != null && grid != null)
            {
                if (border.IsVisible == true)
                {
                    border.IsVisible = false;
                }
                else
                {
                    border.IsVisible = true;
                    grid.LostFocus += OnLostFocus;
                    grid.Focus();
                }
                
               
            }
        }
        protected virtual void OnLostFocus(object? sender, RoutedEventArgs routedEventArgs)
        {
            if (sender is StackPanel grid)
            {
                var border = grid.GetVisualAncestors()
                    .OfType<Border>()
                    .FirstOrDefault(control =>
                                string.IsNullOrEmpty(control.Name) == false &&
                                control.Name.Equals("downGridBorder"));
               
                if (border != null)
                {
                    border.IsVisible = false;
                }
                grid.LostFocus -= OnLostFocus;
            }
        }

        internal Action<RoutedEventArgs> OnDoubleTapped(object args)
        {
            throw new NotImplementedException();
        }

        public static readonly StyledProperty<string> CustomNameProperty =
             AvaloniaProperty.Register<InnerClass, string>("CustomName");
        public string CustomName
        {
            get => GetValue(CustomNameProperty);
            set => SetValue(CustomNameProperty, value);
        }
        public static readonly StyledProperty<string> CustomAtributeProperty =
             AvaloniaProperty.Register<InnerClass, string>("CustomAtribute");
        public string CustomAtribute
        {
            get => GetValue(CustomAtributeProperty);
            set => SetValue(CustomAtributeProperty, value);
        }
        public static readonly StyledProperty<string> CustomOperatuonProperty =
             AvaloniaProperty.Register<InnerClass, string>("CustomOperatuon");
        public string CustomOperatuon
        {
            get => GetValue(CustomOperatuonProperty);
            set => SetValue(CustomOperatuonProperty, value);
        }
    }
}
