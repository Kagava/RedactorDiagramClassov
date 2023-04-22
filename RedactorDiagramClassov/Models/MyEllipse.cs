using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicData.Binding;

namespace RedactorDiagramClassov.Models
{
    public class MyEllipse : AbstractNotifyPropertyChanged
    {
        public double elli4X;
        public double elli4Y;
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
    }
}
