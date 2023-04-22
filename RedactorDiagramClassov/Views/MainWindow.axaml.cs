using System.Diagnostics;
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
        private Point pointerPositionBegineLine;
        private Point pointerPositionEndLine;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void PointerPressedOnCanvas(object? sender, PointerPressedEventArgs pointerPressedEventArgs)
        {
            if (pointerPressedEventArgs.Source is Avalonia.Controls.Control control)
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
                                    //StartPoint = pointPointerPressed,
                                    StartPointGrid = pointPointerPressed

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
                                    //StartPoint = pointPointerPressed,
                                    StartPointGrid = pointPointerPressed,
                                }); ;

                            this.PointerMoved += PointerMoveDragRectangle;
                            this.PointerReleased += PointerPressedReleasedDragRectangle;
                        }

                        else if (mainWindowViewModel.IsDrawLine == true && pointerPressedEventArgs.Source is Ellipse eli)
                        {
                            if (control.DataContext is AbstractFig rectangle)
                            {
                                pointerPositionBegineLine = pointerPressedEventArgs.GetPosition(
                                    this.GetVisualDescendants()
                                    .OfType<Canvas>()
                                    .FirstOrDefault());
                                mainWindowViewModel.AbstractFigs.Add(
                                    new MyLine("Line")
                                    {
                                        StartPoint = pointerPositionBegineLine,
                                        FirstFig = rectangle,
                                        NameStart = rectangle.Name
                                    });;
                                this.PointerMoved += PointerMoveDrawLine;
                                this.PointerReleased += PointerPressedReleasedDrawLine;
                            }
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
        }
        private void PointerPressedReleasedDragRectangle(object? sender, PointerReleasedEventArgs pointerReleasedEventArgs)
        {
            if (DataContext is MainWindowViewModel mainWindowViewModel)
            {
                if (mainWindowViewModel.IsClass == true)
                {
                    MyClass editClass = mainWindowViewModel.AbstractFigs[mainWindowViewModel.AbstractFigs.Count - 1] as MyClass;
                    Point currentPointerPosition = pointerReleasedEventArgs
                        .GetPosition(
                        this.GetVisualDescendants()
                        .OfType<Canvas>()
                        .FirstOrDefault(canvas => string.IsNullOrEmpty(canvas.Name) == false &&
                        canvas.Name.Equals("canvas")));
                    editClass.UpX = editClass.StartPoint.X;
                    editClass.UpY = editClass.StartPoint.Y;
                    editClass.DownX = currentPointerPosition.X - pointPointerPressed.X;
                    editClass.DownY = currentPointerPosition.Y - pointPointerPressed.Y;
                    editClass.Elli1X = editClass.DownX / 2;
                    editClass.Elli1Y = editClass.UpY;
                    editClass.Elli2X = editClass.DownX;
                    editClass.Elli2Y = editClass.DownY / 2;
                    editClass.Elli3X = editClass.DownX / 2;
                    editClass.Elli3Y = editClass.DownY;
                    editClass.Elli4X = editClass.UpX;
                    editClass.Elli4Y = editClass.DownY / 2;
                    editClass.Width = currentPointerPosition.X - pointPointerPressed.X;
                    editClass.Height = currentPointerPosition.Y - pointPointerPressed.Y;
                }
                if (mainWindowViewModel.IsInterface == true)
                {
                    MyInterface editInterface = mainWindowViewModel.AbstractFigs[mainWindowViewModel.AbstractFigs.Count - 1] as MyInterface;
                    Point currentPointerPosition = pointerReleasedEventArgs
                        .GetPosition(
                        this.GetVisualDescendants()
                        .OfType<Canvas>()
                        .FirstOrDefault(canvas => string.IsNullOrEmpty(canvas.Name) == false &&
                        canvas.Name.Equals("canvas")));
                    editInterface.UpX = editInterface.StartPoint.X;
                    editInterface.UpY = editInterface.StartPoint.Y;
                    editInterface.DownX = currentPointerPosition.X - pointPointerPressed.X;
                    editInterface.DownY = currentPointerPosition.Y - pointPointerPressed.Y;
                    editInterface.Elli1X = editInterface.DownX / 2;
                    editInterface.Elli1Y = editInterface.UpY;
                    editInterface.Elli2X = editInterface.DownX;
                    editInterface.Elli2Y = editInterface.DownY / 2;
                    editInterface.Elli3X = editInterface.DownX / 2;
                    editInterface.Elli3Y = editInterface.DownY;
                    editInterface.Elli4X = editInterface.UpX;
                    editInterface.Elli4Y = editInterface.DownY / 2;
                    editInterface.Width = currentPointerPosition.X - pointPointerPressed.X;
                    editInterface.Height = currentPointerPosition.Y - pointPointerPressed.Y;
                }
                if (mainWindowViewModel.IsDrawLine == true && pointerReleasedEventArgs.Source is Ellipse eli)
                {
                    MyLine Line = mainWindowViewModel.AbstractFigs[mainWindowViewModel.AbstractFigs.Count - 1] as MyLine;
                    pointerPositionEndLine = pointerReleasedEventArgs
                        .GetPosition(
                        this.GetVisualDescendants()
                        .OfType<Canvas>()
                        .FirstOrDefault());
                    Line.EndPoint = pointerPositionEndLine;

                }
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
                    editClass.EndPoint = new Point(currentPointerPosition.X, currentPointerPosition.Y);
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
                    editInterface.EndPoint = new Point(currentPointerPosition.X, currentPointerPosition.Y);
                    editInterface.Width = currentPointerPosition.X - pointPointerPressed.X;
                    editInterface.Height = currentPointerPosition.Y - pointPointerPressed.Y;
                }
            }
        }
        private void PointerMoveDragShape(object? sender, PointerEventArgs pointerEventArgs)
        {
            if (DataContext is MainWindowViewModel mainWindowViewModel)
            {
                if (pointerEventArgs.Source is Shape shape)
                {
                    Point currentPointerPosition = pointerEventArgs
                        .GetPosition(
                        this.GetVisualDescendants()
                        .OfType<Canvas>()
                        .FirstOrDefault());

                    if (shape.DataContext is AbstractFig myShape)
                    {
                        myShape.StartPointGrid = new Point(
                           currentPointerPosition.X - pointerPositionIntoShape.X,
                           currentPointerPosition.Y - pointerPositionIntoShape.Y);
                        foreach (AbstractFig lineies in mainWindowViewModel.AbstractFigs)
                        {
                            if(lineies.Name == "Line")
                            {
                                int CountI = 0;
                                int CountJ = 0;
                                if (mainWindowViewModel.AbstractFigs[mainWindowViewModel.AbstractFigs.Count - 1] is MyLine hehe)
                                {
                                    int Flag_End_Y = 0;
                                    int Flag_End_X = 0;
                                    if (hehe.NameStart == myShape.Name)
                                    {
                                        for (int i = -10; i < 10; i++)
                                        {
                                            if (lineies.StartPoint.X >= myShape.StartPointGrid.X + myShape.Width / 2 + i && Flag_End_X != 1 && lineies.StartPoint.X < myShape.StartPointGrid.X + myShape.Width / 2 + 20)
                                            {
                                                for (int j = -10; j < 10; j++)
                                                {
                                                    if (lineies.StartPoint.Y >= myShape.StartPointGrid.Y + j && lineies.StartPoint.Y < myShape.StartPointGrid.Y + 20)
                                                    {
                                                        Flag_End_Y = 1;
                                                        CountJ = j;
                                                        break;
                                                    }
                                                }
                                                Flag_End_X = 1;

                                            }
                                            if (Flag_End_Y == 1)
                                            {
                                                CountI = i;
                                                break;
                                            }
                                        }
                                        if (Flag_End_X == 0) Flag_End_Y = 0;
                                        if (Flag_End_Y == 0) Flag_End_X = 0;
                                        if (Flag_End_X == 0 && Flag_End_Y == 0) 
                                        { 

                                            for (int i = -10; i < 10; i++)
                                            {
                                                if (lineies.StartPoint.X >= myShape.StartPointGrid.X + myShape.Width / 2 + i && Flag_End_X != 2 && lineies.StartPoint.X < myShape.StartPointGrid.X + myShape.Width / 2 + 20)
                                                {
                                                    for (int j = -10; j < 10; j++)
                                                    {
                                                        if (lineies.StartPoint.Y >= myShape.StartPointGrid.Y + myShape.Height + j && lineies.StartPoint.Y < myShape.StartPointGrid.Y + myShape.Height + 20)
                                                        {
                                                            Flag_End_Y = 2;
                                                            CountJ = j;
                                                            break;
                                                        }
                                                    }
                                                    Flag_End_X = 2;

                                                }
                                                if (Flag_End_Y == 2)
                                                {
                                                    CountI = i;
                                                    break;
                                                }
                                            }
                                        }
                                        if (Flag_End_X == 0) Flag_End_Y = 0;
                                        if (Flag_End_Y == 0) Flag_End_X = 0;
                                        if (Flag_End_X == 0 && Flag_End_Y == 0)
                                        {
                                            for (int i = -10; i < 10; i++)
                                            {
                                                if (lineies.StartPoint.X >= myShape.StartPointGrid.X + i && Flag_End_X != 3 && lineies.StartPoint.X < myShape.StartPointGrid.X + 20)
                                                {
                                                    for (int j = -10; j < 10; j++)
                                                    {
                                                        if (lineies.StartPoint.Y >= myShape.StartPointGrid.Y + myShape.Height / 2 + j && lineies.StartPoint.Y < myShape.StartPointGrid.Y + myShape.Height / 2 + 20)
                                                        {
                                                            Flag_End_Y = 3;
                                                            CountJ = j;
                                                            break;
                                                        }
                                                    }
                                                    Flag_End_X = 3;

                                                }
                                                if (Flag_End_Y == 3)
                                                {
                                                    CountI = i;
                                                    break;
                                                }
                                            }
                                        }
                                        if (Flag_End_X == 0) Flag_End_Y = 0;
                                        if (Flag_End_Y == 0) Flag_End_X = 0;
                                        if (Flag_End_X == 0 && Flag_End_Y == 0)
                                        {
                                            for (int i = -10; i < 10; i++)
                                            {
                                                if (lineies.StartPoint.X >= myShape.StartPointGrid.X + myShape.Width + i && Flag_End_X != 4 && lineies.StartPoint.X < myShape.StartPointGrid.X + myShape.Width + 20)
                                                {
                                                    for (int j = -10; j < 10; j++)
                                                    {
                                                        if (lineies.StartPoint.Y >= myShape.StartPointGrid.Y + myShape.Height / 2 + j && lineies.StartPoint.Y < myShape.StartPointGrid.Y + myShape.Height / 2 + 20)
                                                        {
                                                            Flag_End_Y = 4;
                                                            CountJ = j;
                                                            break;
                                                        }
                                                    }
                                                    Flag_End_X = 4;

                                                }
                                                if (Flag_End_Y == 4)
                                                {
                                                    CountI = i;
                                                    break;
                                                }
                                            }
                                        }
                                        if (Flag_End_X == 0) Flag_End_Y = 0;
                                        if (Flag_End_Y == 0) Flag_End_X = 0;
                                        if (Flag_End_Y == 1 && Flag_End_X == 1)
                                        {
                                            lineies.StartPoint = new Point(myShape.StartPointGrid.X + myShape.Width / 2, myShape.StartPointGrid.Y);
                                        }
                                        if (Flag_End_Y == 2 && Flag_End_X == 2)
                                        {
                                            lineies.StartPoint = new Point(myShape.StartPointGrid.X + myShape.Width / 2, myShape.StartPointGrid.Y + myShape.Height);
                                        }
                                        if (Flag_End_Y == 3 && Flag_End_X == 3)
                                        {
                                            lineies.StartPoint = new Point(myShape.StartPointGrid.X, myShape.StartPointGrid.Y + myShape.Height / 2);
                                        }
                                        if (Flag_End_Y == 4 && Flag_End_X == 4)
                                        {
                                            lineies.StartPoint = new Point(myShape.StartPointGrid.X + myShape.Width, myShape.StartPointGrid.Y + myShape.Height / 2);
                                        }
                                    }
                                }      
                            }                           
                        }
                    }
                }
            }
        }

        private void PointerPressedReleasedDragShape(object? sender, PointerReleasedEventArgs pointerReleasedEventArgs)
        {
            this.PointerMoved -= PointerMoveDragShape;
            this.PointerReleased -= PointerPressedReleasedDragShape;
        }
        private void PointerMoveDrawLine(object? sender, PointerEventArgs pointerEventArgs)
        {
            if (this.DataContext is MainWindowViewModel viewModel)
            {
                Debug.WriteLine(sender);
                MyLine connector = viewModel.AbstractFigs[viewModel.AbstractFigs.Count - 1] as MyLine;
                Point currentPointerPosition = pointerEventArgs
                    .GetPosition(
                    this.GetVisualDescendants()
                    .OfType<Canvas>()
                    .FirstOrDefault());

                connector.EndPoint = new Point(
                        currentPointerPosition.X - 1,
                        currentPointerPosition.Y - 1); // отнимать если уменьшилась прибавлять если увеличилась
            }
        }
        private void PointerPressedReleasedDrawLine(object? sender,
           PointerReleasedEventArgs pointerReleasedEventArgs)
        {
            this.PointerMoved -= PointerMoveDrawLine;
            this.PointerReleased -= PointerPressedReleasedDrawLine;

            var canvas = this.GetVisualDescendants()
                        .OfType<Canvas>()
                        .FirstOrDefault(canvas => string.IsNullOrEmpty(canvas.Name) == false &&
                        canvas.Name.Equals("canvas"));

            var coords = pointerReleasedEventArgs.GetPosition(canvas);

            var element = canvas.InputHitTest(coords);
            MainWindowViewModel viewModel = this.DataContext as MainWindowViewModel;

            if (element is Ellipse ellipse)
            {
                if (ellipse.DataContext is AbstractFig eli)
                {
                    MyLine connector = viewModel.AbstractFigs[viewModel.AbstractFigs.Count - 1] as MyLine;
                    connector.SecondFig = eli;
                    return;
                }
            }

            viewModel.AbstractFigs.RemoveAt(viewModel.AbstractFigs.Count - 1);
        }
    }
}
