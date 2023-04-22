using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicData.Binding;

namespace RedactorDiagramClassov.Models
{
    public class FillClass : AbstractNotifyPropertyChanged
    {
        private string nameC = "Zdarova";
        public string NameC
        {
            get => nameC;
            set => SetAndRaise(ref nameC, value);
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
        private string nameAt;
        public string ameAt
        {
            get => nameAt;
            set => SetAndRaise(ref nameAt, value);
        }
        private string tipAt;
        public string TipAt
        {
            get => tipAt;
            set => SetAndRaise(ref tipAt, value);
        }
        private string visionAt;
        public string VisionAt
        {
            get => visionAt;
            set => SetAndRaise(ref visionAt, value);
        }
        private string spesRSAt;
        public string SpesRSAt
        {
            get => spesRSAt;
            set => SetAndRaise(ref spesRSAt, value);
        }
        private string defoultValueAt;
        public string DefoultValueAt
        {
            get => defoultValueAt;
            set => SetAndRaise(ref defoultValueAt, value);
        }
        private string stereotipsAt;
        public string StereotipsAt
        {
            get => stereotipsAt;
            set => SetAndRaise(ref stereotipsAt, value);
        }
    }
}
