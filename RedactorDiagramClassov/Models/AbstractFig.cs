﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Media;
using DynamicData.Binding;

namespace RedactorDiagramClassov.Models
{
    public abstract class AbstractFig : AbstractNotifyPropertyChanged
    {
        public string? name;
        public Point startPoint;
        public Point startPointGrid;
        public Point endPoint;
        public double width;
        public double height;
        public double upX;
        public double upY;
        public double downX;
        public double downY;
        public double elli1X;
        public double elli1Y;
        public double elli2X;
        public double elli2Y;
        public double elli3X;
        public double elli3Y;
        public double elli4X;
        public double elli4Y;
        public string Name
        {
            get => name;
            set => SetAndRaise(ref name, value);
        }
        public Point StartPoint
        {
            get => startPoint;
            set
            {
                Point oldPoint = StartPoint;

                SetAndRaise(ref startPoint, value);

                if (ChangeStartPoint != null)
                {
                    ChangeStartPointEventArgs args = new ChangeStartPointEventArgs
                    {
                        OldStartPoint = oldPoint,
                        NewStartPoint = StartPoint,
                    };

                    ChangeStartPoint(this, args);
                }
            }
        }
        public Point EndPoint
        {
            get => endPoint;
            set => SetAndRaise(ref endPoint, value);
        }
        public double Width
        {
            get => width;
            set => SetAndRaise(ref width, value);
        }
        public double Height
        {
            get => height;
            set => SetAndRaise(ref height, value);
        }
        public Point StartPointGrid
        {
            get => startPointGrid;
            set => SetAndRaise(ref startPointGrid, value);
        }
        public double UpX
        {
            get => upX;
            set => SetAndRaise(ref upX, value);
        }
        public double UpY
        {
            get => upY;
            set => SetAndRaise(ref upY, value);
        }
        public double DownX
        {
            get => downX;
            set => SetAndRaise(ref downX, value);
        }
        public double DownY
        {
            get => downY;
            set => SetAndRaise(ref downY, value);
        }
        public double Elli1X
        {
            get => elli1X;
            set => SetAndRaise(ref elli1X, value);
        }
        public double Elli1Y
        {
            get => elli1Y;
            set => SetAndRaise(ref elli1Y, value);
        }
        public double Elli2X
        {
            get => elli2X;
            set => SetAndRaise(ref elli2X, value);
        }
        public double Elli2Y
        {
            get => elli2Y;
            set => SetAndRaise(ref elli2Y, value);
        }
        public double Elli3X
        {
            get => elli3X;
            set => SetAndRaise(ref elli3X, value);
        }
        public double Elli3Y
        {
            get => elli3Y;
            set => SetAndRaise(ref elli3Y, value);
        }
        public double Elli4X
        {
            get => elli4X;
            set => SetAndRaise(ref elli4X, value);
        }
        public double Elli4Y
        {
            get => elli4Y;
            set => SetAndRaise(ref elli4Y, value);
        }
        public event EventHandler<ChangeStartPointEventArgs> ChangeStartPoint;
    }

}
