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
        public double width;
        public double height;
        public double upX;
        public double upY;
        public string Name
        {
            get => name;
            set => SetAndRaise(ref name, value);
        }
        public Point StartPoint
        {
            get => startPoint;
            set => SetAndRaise(ref startPoint, value);
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
            set
            {
                upX = EndPoint.X;
            }
        }
        public double UpY
        {
            get => upY;
            set
            {
                upY = EndPoint.Y*2;
            }
        }
    }

}
