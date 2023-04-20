using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.VisualTree;
using RedactorDiagramClassov.Models;
using RedactorDiagramClassov.ViewModels;

namespace RedactorDiagramClassov.Views
{
    public partial class MainWindow : Window
    {
        private Point pointPointerPressed;
        private Point pointerPositionIntoShape;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void PointerPressedOnCanvas(object? sender, PointerPressedEventArgs pointerPressedEventArgs)
        {
            pointPointerPressed = pointerPressedEventArgs
                    .GetPosition(
                    this.GetVisualDescendants()
                    .OfType<Canvas>()
                    .FirstOrDefault());

            if (this.DataContext is MainWindowViewModel mainWindowViewModel)
            {
               
                if (mainWindowViewModel.IsClass == true)
                {
                    mainWindowViewModel.CountOfClass++;
                    string CurrentName = "Class" + mainWindowViewModel.CountOfClass;
                    mainWindowViewModel.AbstractFigs.Add(
                        new MyClass(CurrentName)
                        {
                            StartPoint = pointPointerPressed,
                        });
                    this.PointerMoved += PointerMoveDragRectangle;
                    this.PointerReleased += PointerPressedReleasedDragRectangle;
                }
                else if (mainWindowViewModel.IsInterface == true)
                {
                    mainWindowViewModel.CountOfInterface++;
                    string CurrentName = "Interface" + mainWindowViewModel.CountOfInterface;
                    mainWindowViewModel.AbstractFigs.Add(
                        new MyInterface(CurrentName)
                        {
                            StartPoint = pointPointerPressed,
                        });
                    this.PointerMoved += PointerMoveDragRectangle;
                    this.PointerReleased += PointerPressedReleasedDragRectangle;
                }
                else if (mainWindowViewModel.IsDrag == true)
                {
                    if (pointerPressedEventArgs.Source is Shape shape)
                    {
                        pointerPositionIntoShape = pointerPressedEventArgs.GetPosition(shape);
                        this.PointerMoved += PointerMoveDragShape;
                        this.PointerReleased += PointerPressedReleasedDragShape;
                    }
                }
            }
        }
        private void PointerPressedReleasedDragRectangle(object? sender, PointerReleasedEventArgs pointerReleasedEventArgs)
        {
            if (DataContext is MainWindowViewModel mainWindowViewModel)
            {
                this.PointerMoved -= PointerMoveDragRectangle;
                this.PointerReleased -= PointerPressedReleasedDragRectangle;
            }
        }
        private void PointerMoveDragRectangle(object? sender, PointerEventArgs pointerEventArgs)
        {

            if (this.DataContext is MainWindowViewModel mainWindowViewModel)
            {
                if (mainWindowViewModel.IsClass == true)
                {
                    MyClass editClass = mainWindowViewModel.AbstractFigs[mainWindowViewModel.AbstractFigs.Count - 1] as MyClass;
                    Point currentPointerPosition = pointerEventArgs
                        .GetPosition(
                        this.GetVisualDescendants()
                        .OfType<Canvas>()
                        .FirstOrDefault());

                    editClass.Width = currentPointerPosition.X - pointPointerPressed.X;
                    editClass.Height = currentPointerPosition.Y - pointPointerPressed.Y;
                }
                if (mainWindowViewModel.IsInterface == true)
                {
                    MyInterface editInterface = mainWindowViewModel.AbstractFigs[mainWindowViewModel.AbstractFigs.Count - 1] as MyInterface;
                    Point currentPointerPosition = pointerEventArgs
                        .GetPosition(
                        this.GetVisualDescendants()
                        .OfType<Canvas>()
                        .FirstOrDefault());

                    editInterface.Width = currentPointerPosition.X - pointPointerPressed.X;
                    editInterface.Height = currentPointerPosition.Y - pointPointerPressed.Y;
                }
            }
        }
        private void PointerMoveDragShape(object? sender, PointerEventArgs pointerEventArgs)
        {
            if(pointerEventArgs.Source is Shape shape)
            {
                Point currentPointerPosition = pointerEventArgs
                    .GetPosition(
                    this.GetVisualDescendants()
                    .OfType<Canvas>()
                    .FirstOrDefault());

                if (shape.DataContext is AbstractFig myShape)
                {
                    myShape.StartPoint = new Point(
                        currentPointerPosition.X - pointerPositionIntoShape.X,
                        currentPointerPosition.Y - pointerPositionIntoShape.Y);
                }
            }
        }

        private void PointerPressedReleasedDragShape(object? sender, PointerReleasedEventArgs pointerReleasedEventArgs)
        {
            this.PointerMoved -= PointerMoveDragShape;
            this.PointerReleased -= PointerPressedReleasedDragShape;
        }
    }
}
