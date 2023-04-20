using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedactorDiagramClassov.Models
{
    public class MyInterface : AbstractFig
    {
        private ObservableCollection<LBFillInterface> downStairsInterface= new ObservableCollection<LBFillInterface>();
        public MyInterface(string name)
        {
            Name = name;

        }
    }
}
