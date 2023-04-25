using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Avalonia;
using DynamicData.Binding;

namespace RedactorDiagramClassov.Models
{
    public class MyConnector : AbstractFig
    {
        
       
        public MyConnector(string name)
        {
            Name = name;
        }
    }
}
