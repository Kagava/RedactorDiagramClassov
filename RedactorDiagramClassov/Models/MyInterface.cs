﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedactorDiagramClassov.Models
{
    public class MyInterface : AbstractFig
    {
        public MyInterface(string name)
        {
            Name = name;
            NameI = name; 
        }
        private string nameI;
        public string NameI
        {
            get => nameI;
            set => SetAndRaise(ref nameI, value);
        }
        private string stereotip;
        public string Stereotip
        {
            get => stereotip;
            set => SetAndRaise(ref stereotip, value);
        }
        private string vision;
        public string Vision
        {
            get => vision;
            set => SetAndRaise(ref vision, value);
        }
        private string nameOp;
        public string NameOp
        {
            get => nameOp;
            set => SetAndRaise(ref nameOp, value);
        }
        private string tipReturnValue;
        public string TipReturnValue
        {
            get => tipReturnValue;
            set => SetAndRaise(ref tipReturnValue, value);
        }
        private string visionOp;
        public string VisionOp
        {
            get => visionOp;
            set => SetAndRaise(ref visionOp, value);
        }
        private string paramNameOp;
        public string ParamNameOp
        {
            get => paramNameOp;
            set => SetAndRaise(ref paramNameOp, value);
        }
        private string paramTipOp;
        public string ParamTipOp
        {
            get => paramTipOp;
            set => SetAndRaise(ref paramTipOp, value);
        }
        private string specOp;
        public string SpecOp
        {
            get => specOp;
            set => SetAndRaise(ref specOp, value);
        }
    }
}
