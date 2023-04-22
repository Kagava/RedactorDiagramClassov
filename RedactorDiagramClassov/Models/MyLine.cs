using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicData.Binding;

namespace RedactorDiagramClassov.Models
{
    public class MyLine : AbstractFig, IDisposable 
    {
        private AbstractFig firstFig;
        private AbstractFig secondFig;
        private string nameStart;
        private string nameEnd;
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
        public MyLine(string name)
        {
            Name = name;
        }
        public AbstractFig FirstFig
        {
            get => firstFig;
            set
            {
                if (firstFig != null)
                {
                    firstFig.ChangeStartPoint -= OnFirstRectanglePositionChanged;
                }

                firstFig = value;

                if (firstFig != null)
                {
                    firstFig.ChangeStartPoint += OnFirstRectanglePositionChanged;
                }
            }
        }

        public AbstractFig SecondFig
        {
            get => secondFig;
            set
            {
                if (secondFig != null)
                {
                    secondFig.ChangeStartPoint -= OnSecondRectanglePositionChanged;
                }

                secondFig = value;

                if (secondFig != null)
                {
                    secondFig.ChangeStartPoint += OnSecondRectanglePositionChanged;
                }
            }
        }

        private void OnFirstRectanglePositionChanged(object? sender, ChangeStartPointEventArgs e)
        {
            StartPoint += e.NewStartPoint - e.OldStartPoint;
        }

        private void OnSecondRectanglePositionChanged(object? sender, ChangeStartPointEventArgs e)
        {
            EndPoint += e.NewStartPoint - e.OldStartPoint;
        }

        public void Dispose()
        {
            if (FirstFig != null)
            {
                FirstFig.ChangeStartPoint -= OnFirstRectanglePositionChanged;
            }

            if (SecondFig != null)
            {
                SecondFig.ChangeStartPoint -= OnSecondRectanglePositionChanged;
            }
        }
    }
}
