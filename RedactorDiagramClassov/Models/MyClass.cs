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
        public MyClass(string name)
        {
            
            Name = name;
            DisplayName = name;
        }
        
    }
}
