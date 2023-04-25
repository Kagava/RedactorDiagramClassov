using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.VisualTree;
using DynamicData;
using JetBrains.Annotations;
using Microsoft.CodeAnalysis;
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
        public double cat1 = 0;
        public double cat2 = 0;
        public double cat3 = 0;
        public int count = 0;
        public int countCons = 0;

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
                            string typeLine = string.Empty;
                            int gaude = 0;
                            if (mainWindowViewModel.IsAssotiatioin == true)
                            {
                                typeLine = "Assotiatioin";

                            }
                            if (mainWindowViewModel.IsNasledovanie == true)
                            {
                                typeLine = "Nasledovanie";
                            }
                            if (mainWindowViewModel.IsRealisation == true)
                            {
                                gaude = 2;
                                typeLine = "Realisation";
                            }
                            if (mainWindowViewModel.IsZavisimost == true)
                            {
                                gaude = 2;
                                typeLine = "Zavisimost";
                            }
                            if (mainWindowViewModel.IsAgrigation == true)
                            {
                                typeLine = "Agrigation";
                            }
                            if (mainWindowViewModel.IsComposition == true)
                            {
                                typeLine = "Composition";
                            }
                            pointerPositionBegineLine = pointerPressedEventArgs.GetPosition(
                                    this.GetVisualDescendants()
                                    .OfType<Canvas>()
                                    .FirstOrDefault());

                                mainWindowViewModel.AbstractFigs.Add(
                                    new MyLine("Line")
                                    {
                                        StartPoint = pointerPositionBegineLine,
                                        FirstFig = rectangle,
                                        NameStart = rectangle.Name,
                                       GaudeOFLine = gaude,
                                        TypeLine = typeLine,
                                        FlagList = true
                                    });

                            if (mainWindowViewModel.IsAssotiatioin == true)
                            {

                                mainWindowViewModel.AbstractFigs.Add(
                                         new MyConnector("Connnect")
                                         {
                                             GaudeOFLine = 0,
                                             TypeLine = typeLine,
                                             AngleToChange = 0
                                         }) ;
                            }
                            if (mainWindowViewModel.IsNasledovanie == true)
                            {
                                mainWindowViewModel.AbstractFigs.Add(
                                          new MyNasledovanie("Connnect")
                                          {
                                              GaudeOFLine = 0,
                                              TypeLine = typeLine,
                                              AngleToChange = 0
                                          });
                            }
                            if (mainWindowViewModel.IsRealisation == true)
                            {
                                mainWindowViewModel.AbstractFigs.Add(
                                          new MyRealisation("Connnect")
                                          {
                                              GaudeOFLine = 3,
                                              TypeLine = typeLine,
                                              AngleToChange = 0
                                          });
                            }
                            if (mainWindowViewModel.IsZavisimost == true)
                            {
                                mainWindowViewModel.AbstractFigs.Add(
                                          new MyZavisimost("Connnect")
                                          {

                                              GaudeOFLine = 3,
                                              TypeLine = typeLine,
                                              AngleToChange = 0
                                          });
                            }
                            if (mainWindowViewModel.IsAgrigation == true)
                            {
                                mainWindowViewModel.AbstractFigs.Add(
                                          new MyAgrigation("Connnect")
                                          {
                                              GaudeOFLine = 0,
                                              TypeLine = typeLine,
                                              AngleToChange = 0
                                          });
                            }
                            if (mainWindowViewModel.IsComposition == true)
                            {
                                mainWindowViewModel.AbstractFigs.Add(
                                         new MyComposition("Connnect")
                                         {
                                             GaudeOFLine = 0,
                                             TypeLine = typeLine,
                                             AngleToChange = 0
                                         });
                            }
                            /* MyLine lll = mainWindowViewModel.AbstractFigs[mainWindowViewModel.AbstractFigs.Count - 1] as MyLine;
                         lll.ListPoint.Add(new Point(12, 12));
                         lll.ListPoint.Add(new Point(120, 120));
                         lll.ListPoint.Add(new Point(50, 50));*/
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
                /*if (mainWindowViewModel.IsDrawLine == true && pointerReleasedEventArgs.Source is Ellipse eli)
                {
                    MyLine Line = mainWindowViewModel.AbstractFigs[mainWindowViewModel.AbstractFigs.Count - 1] as MyLine;
                    pointerPositionEndLine = pointerReleasedEventArgs
                        .GetPosition(
                        this.GetVisualDescendants()
                        .OfType<Canvas>()
                        .FirstOrDefault());
                    Line.EndPoint = pointerPositionEndLine;
                    if (Line.TypeLine == "Assotiatioin")
                    {
                        /*lineies.PointsBline.Add(lineies.EndPoint);
                        lineies.PointsBline.Add(new Point(lineies.EndPoint.X - 10, lineies.EndPoint.Y - 10));
                        lineies.PointsBline.Add(lineies.EndPoint);
                        lineies.PointsBline.Add(new Point(lineies.EndPoint.X + 10, lineies.EndPoint.Y - 10));
                        Line.PointsBline.Add(new Point(10, 10));
                        Line.PointsBline.Add(new Point(20, 10));
                        Line.PointsBline.Add(new Point(10, 20));
                        lineies.PointsBline.Add(new Point(20, 20));
                    }

                }*/
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
                                //if (mainWindowViewModel.AbstractFigs[mainWindowViewModel.AbstractFigs.Count - 1] is MyLine hehe)
                                //{
                                //MyLine hehe = ;
                                    int Flag_End_Y = 0;
                                    int Flag_End_X = 0;
                                    if (lineies.NameStart == myShape.Name)
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
                                            lineies.StartPoint = new Point(myShape.StartPointGrid.X + myShape.Width / 2 + 6, myShape.StartPointGrid.Y+ 3.5);
                                        }
                                        if (Flag_End_Y == 2 && Flag_End_X == 2)
                                        {
                                            lineies.StartPoint = new Point(myShape.StartPointGrid.X + myShape.Width / 2+6, myShape.StartPointGrid.Y + myShape.Height+3.5);
                                        }
                                        if (Flag_End_Y == 3 && Flag_End_X == 3)
                                        {
                                            lineies.StartPoint = new Point(myShape.StartPointGrid.X+6, myShape.StartPointGrid.Y + myShape.Height / 2+3.5);
                                        }
                                        if (Flag_End_Y == 4 && Flag_End_X == 4)
                                        {
                                            lineies.StartPoint = new Point(myShape.StartPointGrid.X + myShape.Width+6, myShape.StartPointGrid.Y + myShape.Height / 2+3.5);
                                        }
                                    }
                                //}      
                            }
                            
                        }
                        count = 0;
                        
                        foreach (AbstractFig lineies in mainWindowViewModel.AbstractFigs)
                        {
                            countCons = 0;
                            if (lineies.Name == "Line")
                            {
                                count++;
                                int CountI = 0;
                                int CountJ = 0;
                                //if (mainWindowViewModel.AbstractFigs[mainWindowViewModel.AbstractFigs.Count - 1] is MyLine hehe)
                                //{
                                //MyLine hehe = ;
                                int Flag_End_Y = 0;
                                int Flag_End_X = 0;
                                if (lineies.NameEnd == myShape.Name)
                                {
                                    for (int i = -10; i < 10; i++)
                                    {
                                        if (lineies.EndPoint.X >= myShape.StartPointGrid.X + myShape.Width / 2 + i && Flag_End_X != 1 && lineies.EndPoint.X < myShape.StartPointGrid.X + myShape.Width / 2 + 20)
                                        {
                                            for (int j = -10; j < 10; j++)
                                            {
                                                if (lineies.EndPoint.Y >= myShape.StartPointGrid.Y + j && lineies.EndPoint.Y < myShape.StartPointGrid.Y + 20)
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
                                            if (lineies.EndPoint.X >= myShape.StartPointGrid.X + myShape.Width / 2 + i && Flag_End_X != 2 && lineies.EndPoint.X < myShape.StartPointGrid.X + myShape.Width / 2 + 20)
                                            {
                                                for (int j = -10; j < 10; j++)
                                                {
                                                    if (lineies.EndPoint.Y >= myShape.StartPointGrid.Y + myShape.Height + j && lineies.EndPoint.Y < myShape.StartPointGrid.Y + myShape.Height + 20)
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
                                            if (lineies.EndPoint.X >= myShape.StartPointGrid.X + i && Flag_End_X != 3 && lineies.EndPoint.X < myShape.StartPointGrid.X + 20)
                                            {
                                                for (int j = -10; j < 10; j++)
                                                {
                                                    if (lineies.EndPoint.Y >= myShape.StartPointGrid.Y + myShape.Height / 2 + j && lineies.EndPoint.Y < myShape.StartPointGrid.Y + myShape.Height / 2 + 20)
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
                                            if (lineies.EndPoint.X >= myShape.StartPointGrid.X + myShape.Width + i && Flag_End_X != 4 && lineies.EndPoint.X < myShape.StartPointGrid.X + myShape.Width + 20)
                                            {
                                                for (int j = -10; j < 10; j++)
                                                {
                                                    if (lineies.EndPoint.Y >= myShape.StartPointGrid.Y + myShape.Height / 2 + j && lineies.EndPoint.Y < myShape.StartPointGrid.Y + myShape.Height / 2 + 20)
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
                                        lineies.EndPoint = new Point(myShape.StartPointGrid.X + myShape.Width / 2 + 6, myShape.StartPointGrid.Y+3.5);
                                    }
                                    if (Flag_End_Y == 2 && Flag_End_X == 2)
                                    {
                                        lineies.EndPoint = new Point(myShape.StartPointGrid.X + myShape.Width / 2 +6 , myShape.StartPointGrid.Y + myShape.Height+3.5);
                                    }
                                    if (Flag_End_Y == 3 && Flag_End_X == 3)
                                    {
                                        lineies.EndPoint = new Point(myShape.StartPointGrid.X+6, myShape.StartPointGrid.Y + myShape.Height / 2+3.5);
                                    }
                                    if (Flag_End_Y == 4 && Flag_End_X == 4)
                                    {
                                        lineies.EndPoint = new Point(myShape.StartPointGrid.X + myShape.Width+6, myShape.StartPointGrid.Y + myShape.Height / 2+3.5);
                                    }
                                   

                                }
                                foreach (AbstractFig connectors in mainWindowViewModel.AbstractFigs)
                                {
                                   
                                    if (connectors.Name == "Connnect")
                                    {
                                        countCons++;
                                        if(count == countCons)
                                        {
                                            connectors.XPointToCanvas = lineies.EndPoint.X - 10;
                                            connectors.YPointToCanvas = lineies.EndPoint.Y - 10;
                                            connectors.CenterX = connectors.XPointToCanvas;
                                            connectors.CenterY = connectors.YPointToCanvas;
                                            cat2 = lineies.EndPoint.X - lineies.StartPoint.X;
                                            cat1 = lineies.EndPoint.Y - lineies.StartPoint.Y;
                                            cat3 = cat1 / cat2;
                                            if (lineies.EndPoint.X <= lineies.StartPoint.X)
                                            {
                                                connectors.AngleToChange = Math.Atan(cat3) * 180 / Math.PI - 180;
                                            }
                                            else
                                            {
                                                connectors.AngleToChange = Math.Atan(cat3) * 180 / Math.PI;
                                            }
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
                MyLine connector = viewModel.AbstractFigs[viewModel.AbstractFigs.Count - 2] as MyLine;
                AbstractFig que = viewModel.AbstractFigs[viewModel.AbstractFigs.Count - 1];
                Point currentPointerPosition = pointerEventArgs
                    .GetPosition(
                    this.GetVisualDescendants()
                    .OfType<Canvas>()
                    .FirstOrDefault());
                connector.EndPoint = new Point(
                        currentPointerPosition.X - 1,
                        currentPointerPosition.Y - 1);
               
                que.CenterX = que.XPointToCanvas;
                que.CenterY = que.YPointToCanvas;
                cat2 = connector.EndPoint.X - connector.StartPoint.X;
                cat1 = connector.EndPoint.Y - connector.StartPoint.Y;
                cat3 = cat1 / cat2;
                if (connector.EndPoint.X <= connector.StartPoint.X)
                {
                    que.AngleToChange = Math.Atan(cat3) * 180 / Math.PI - 180;
                }
                else
                {
                    que.AngleToChange = Math.Atan(cat3) * 180 / Math.PI;
                }
                // отнимать если уменьшилась прибавлять если увеличилась

            }
        }
        private void PointerPressedReleasedDrawLine(object? sender, PointerReleasedEventArgs pointerReleasedEventArgs)
        {
            this.PointerMoved -= PointerMoveDrawLine;
            this.PointerReleased -= PointerPressedReleasedDrawLine;
           
           var canvas = this.GetVisualDescendants()
                        .OfType<Canvas>()
                        .FirstOrDefault(canvas => string.IsNullOrEmpty(canvas.Name) == false &&
                        canvas.Name.Equals("canvas"));

            var coords = pointerReleasedEventArgs.GetPosition(canvas);

            var element = canvas.InputHitTest(coords);
            MainWindowViewModel mainWindowViewModel = this.DataContext as MainWindowViewModel;

            if (element is Ellipse ellipse)
            {
                if (ellipse.DataContext is AbstractFig eli)
                {
                    MyLine connector = mainWindowViewModel.AbstractFigs[mainWindowViewModel.AbstractFigs.Count - 2] as MyLine;
                    connector.SecondFig = eli;
                    connector.NameEnd = eli.Name;
                    if (mainWindowViewModel.IsAssotiatioin == true)
                    {
                        MyConnector connectorEnd = mainWindowViewModel.AbstractFigs[mainWindowViewModel.AbstractFigs.Count - 1] as MyConnector;
                        connectorEnd.XPointToCanvas = connector.EndPoint.X - 10;
                        connectorEnd.YPointToCanvas = connector.EndPoint.Y - 10;
                        connectorEnd.CenterX = connectorEnd.XPointToCanvas;
                        connectorEnd.CenterY = connectorEnd.YPointToCanvas;
                        cat2 = connector.EndPoint.X - connector.StartPoint.X;
                        cat1 = connector.EndPoint.Y - connector.StartPoint.Y;
                        cat3 = cat1 / cat2;
                        if (connector.EndPoint.X <= connector.StartPoint.X)
                        {
                            connectorEnd.AngleToChange = Math.Atan(cat3) * 180 / Math.PI - 180;
                        }
                        else
                        {
                            connectorEnd.AngleToChange = Math.Atan(cat3) * 180 / Math.PI;
                        }
                    }
                    if (mainWindowViewModel.IsNasledovanie == true)
                    {
                        MyNasledovanie connectorEnd = mainWindowViewModel.AbstractFigs[mainWindowViewModel.AbstractFigs.Count - 1] as MyNasledovanie;
                        connectorEnd.XPointToCanvas = connector.EndPoint.X - 10;
                        connectorEnd.YPointToCanvas = connector.EndPoint.Y - 10;
                        connectorEnd.CenterX = connectorEnd.XPointToCanvas;
                        connectorEnd.CenterY = connectorEnd.YPointToCanvas;
                        cat2 = connector.EndPoint.X - connector.StartPoint.X;
                        cat1 = connector.EndPoint.Y - connector.StartPoint.Y;
                        cat3 = cat1 / cat2;
                        if (connector.EndPoint.X <= connector.StartPoint.X)
                        {
                            connectorEnd.AngleToChange = Math.Atan(cat3) * 180 / Math.PI - 180;
                        }
                        else
                        {
                            connectorEnd.AngleToChange = Math.Atan(cat3) * 180 / Math.PI;
                        }

                    }
                    if (mainWindowViewModel.IsRealisation == true)
                    {
                        MyRealisation connectorEnd = mainWindowViewModel.AbstractFigs[mainWindowViewModel.AbstractFigs.Count - 1] as MyRealisation;
                        connectorEnd.XPointToCanvas = connector.EndPoint.X - 10;
                        connectorEnd.YPointToCanvas = connector.EndPoint.Y - 10;
                        connectorEnd.CenterX = connectorEnd.XPointToCanvas;
                        connectorEnd.CenterY = connectorEnd.YPointToCanvas;
                        cat2 = connector.EndPoint.X - connector.StartPoint.X;
                        cat1 = connector.EndPoint.Y - connector.StartPoint.Y;
                        cat3 = cat1 / cat2;
                        if (connector.EndPoint.X <= connector.StartPoint.X)
                        {
                            connectorEnd.AngleToChange = Math.Atan(cat3) * 180 / Math.PI - 180;
                        }
                        else
                        {
                            connectorEnd.AngleToChange = Math.Atan(cat3) * 180 / Math.PI;
                        }
                    }
                    if (mainWindowViewModel.IsZavisimost == true)
                    {
                        MyZavisimost connectorEnd = mainWindowViewModel.AbstractFigs[mainWindowViewModel.AbstractFigs.Count - 1] as MyZavisimost;
                        connectorEnd.XPointToCanvas = connector.EndPoint.X - 10;
                        connectorEnd.YPointToCanvas = connector.EndPoint.Y - 10;
                        connectorEnd.CenterX = connectorEnd.XPointToCanvas;
                        connectorEnd.CenterY = connectorEnd.YPointToCanvas;
                        cat2 = connector.EndPoint.X - connector.StartPoint.X;
                        cat1 = connector.EndPoint.Y - connector.StartPoint.Y;
                        cat3 = cat1 / cat2;
                        if (connector.EndPoint.X <= connector.StartPoint.X)
                        {
                            connectorEnd.AngleToChange = Math.Atan(cat3) * 180 / Math.PI - 180;
                        }
                        else
                        {
                            connectorEnd.AngleToChange = Math.Atan(cat3) * 180 / Math.PI;
                        }
                    }
                    if (mainWindowViewModel.IsAgrigation == true)
                    {
                        MyAgrigation connectorEnd = mainWindowViewModel.AbstractFigs[mainWindowViewModel.AbstractFigs.Count - 1] as MyAgrigation;
                        connectorEnd.XPointToCanvas = connector.EndPoint.X - 10;
                        connectorEnd.YPointToCanvas = connector.EndPoint.Y - 10;
                        connectorEnd.CenterX = connectorEnd.XPointToCanvas;
                        connectorEnd.CenterY = connectorEnd.YPointToCanvas;
                        cat2 = connector.EndPoint.X - connector.StartPoint.X;
                        cat1 = connector.EndPoint.Y - connector.StartPoint.Y;
                        cat3 = cat1 / cat2;
                        if (connector.EndPoint.X <= connector.StartPoint.X)
                        {
                            connectorEnd.AngleToChange = Math.Atan(cat3) * 180 / Math.PI - 180;
                        }
                        else
                        {
                            connectorEnd.AngleToChange = Math.Atan(cat3) * 180 / Math.PI;
                        }
                    }
                    if (mainWindowViewModel.IsComposition == true)
                    {
                        MyComposition connectorEnd = mainWindowViewModel.AbstractFigs[mainWindowViewModel.AbstractFigs.Count - 1] as MyComposition;
                        connectorEnd.XPointToCanvas = connector.EndPoint.X - 10;
                        connectorEnd.YPointToCanvas = connector.EndPoint.Y - 10;
                        connectorEnd.CenterX = connectorEnd.XPointToCanvas;
                        connectorEnd.CenterY = connectorEnd.YPointToCanvas;
                        cat2 = connector.EndPoint.X - connector.StartPoint.X;
                        cat1 = connector.EndPoint.Y - connector.StartPoint.Y;
                        cat3 = cat1 / cat2;
                        if (connector.EndPoint.X <= connector.StartPoint.X)
                        {
                            connectorEnd.AngleToChange = Math.Atan(cat3) * 180 / Math.PI - 180;
                        }
                        else
                        {
                            connectorEnd.AngleToChange = Math.Atan(cat3) * 180 / Math.PI;
                        }
                    }
                    

                }
                else
                {

                    mainWindowViewModel.AbstractFigs.RemoveAt(mainWindowViewModel.AbstractFigs.Count - 2);
                }
            }
            else
            {
                mainWindowViewModel.AbstractFigs.RemoveAt(mainWindowViewModel.AbstractFigs.Count - 2);
            }
           
        }
    }
}
