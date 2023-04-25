using System;
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
        public string colorLine;
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
        private string nameStart;
        private string nameEnd;
        private string typeLine;
        public List<Point> listPoint;
        private bool flagList;
        private int gaudeOfLine;
        public int GaudeOFLine
        {
            get => gaudeOfLine;
            set => SetAndRaise(ref gaudeOfLine, value);
        }
        public string ColorLine
        {
            get => colorLine;
            set => SetAndRaise(ref colorLine, value);
        }
        public bool FlagList
        {
            get => flagList;
            set => SetAndRaise(ref flagList, value);
        }
        public List<Point> ListPoint
        {
            get => listPoint;
            set => SetAndRaise(ref listPoint, value);
        }
        public string TypeLine
        {
            get => typeLine;
            set => SetAndRaise(ref typeLine, value);
        }
        public string NameStart
        {
            get => nameStart;
            set => SetAndRaise(ref nameStart, value);
        }
        public string NameEnd
        {
            get => nameEnd;
            set => SetAndRaise(ref nameEnd, value);
        }
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
            set 
            {
                SetAndRaise(ref endPoint, value);
            }

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
       
        private string nameConnector;
        public double xPointToCanvas;
        public double yPointToCanvas;
        public double angleToChange;
        public double centerX;
        public double centerY;
        public double CenterX
        {
            get => centerX;
            set => SetAndRaise(ref centerX, value);
        }
        public double CenterY
        {
            get => centerY;
            set => SetAndRaise(ref centerY, value);
        }
        public double AngleToChange
        {
            get => angleToChange;
            set
            {
                SetAndRaise(ref angleToChange, value);
            }
        }
        public double XPointToCanvas
        {
            get => xPointToCanvas;
            set
            {
                SetAndRaise(ref xPointToCanvas, value);
            }
        }
        public double YPointToCanvas
        {
            get => yPointToCanvas;
            set
            {
                SetAndRaise(ref yPointToCanvas, value);
            }

        }
        public string NameConnector
        {
            get => nameConnector;
            set => SetAndRaise(ref nameConnector, value);
        }
    }

}
