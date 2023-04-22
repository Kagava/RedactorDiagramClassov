using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedactorDiagramClassov.Models
{
    public class MyClass : AbstractFig
    {
        private ObservableCollection<FillClass> fillClasses;
        public MyClass(string name)
        {
            fillClasses = new ObservableCollection<FillClass>();
            Name = name;
        }
        public ObservableCollection<FillClass> FillClasses
        {
            get => fillClasses;
            set => SetAndRaise(ref fillClasses, value);
        }
        
    }
}
