using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Avalonia;
using Avalonia.Input;
using Avalonia.Media;
using DynamicData;
using Microsoft.CodeAnalysis;
using ReactiveUI;
using RedactorDiagramClassov.Models;

namespace RedactorDiagramClassov.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private bool isDrag;
        private bool isSkale;
        private bool isClass;
        private bool isInterface;
        private bool isDrawLine;
        private bool isAssotiatioin = true;
        private bool isNasledovanie;
        private bool isRealisation;
        private bool isZavisimost;
        private bool isAgrigation;
        private bool isComposition;
        private int countOfClass = 0;
        private int countOfInterface = 0;
        private string sss;

        public int GaudeStroke = 1;
        //public Brush ColorStroke = "Black"
        private ObservableCollection<AbstractFig> abstractFigs = new ObservableCollection<AbstractFig>();

        public MainWindowViewModel() 
        {
           
        }

        public ObservableCollection<AbstractFig> AbstractFigs
        {
            get => abstractFigs;
            set => this.RaiseAndSetIfChanged(ref abstractFigs, value);
        }
        
        public bool IsDrag
        {
            get => isDrag;
            set => this.RaiseAndSetIfChanged(ref isDrag, value);
        }
        public bool IsClass
        {
            get => isClass;
            set => this.RaiseAndSetIfChanged(ref isClass, value);
        }
        public bool IsInterface
        {
            get => isInterface;
            set => this.RaiseAndSetIfChanged(ref isInterface, value);
        }
        public bool IsSkale
        {
            get => isSkale;
            set => this.RaiseAndSetIfChanged(ref isSkale, value);
        }
        public bool IsDrawLine
        {
            get => isDrawLine;
            set => this.RaiseAndSetIfChanged(ref isDrawLine, value);
        }
        public int CountOfClass
        {
            get => countOfClass;
            set => this.RaiseAndSetIfChanged(ref countOfClass, value);
        }
        public int CountOfInterface
        {
            get => countOfInterface;
            set => this.RaiseAndSetIfChanged(ref countOfInterface, value);
        }
        public string Sss
        {
            get => sss;
            set => this.RaiseAndSetIfChanged(ref sss, value);
        }
        public bool IsAssotiatioin
        {
            get => isAssotiatioin;
            set => this.RaiseAndSetIfChanged(ref isAssotiatioin, value);
        }
        public bool IsNasledovanie
        {
            get => isNasledovanie;
            set => this.RaiseAndSetIfChanged(ref isNasledovanie, value);
        }
        public bool IsRealisation
        {
            get => isRealisation;
            set => this.RaiseAndSetIfChanged(ref isRealisation, value);
        }
        public bool IsZavisimost
        {
            get => isZavisimost;
            set => this.RaiseAndSetIfChanged(ref isZavisimost, value);
        }
        public bool IsAgrigation
        {
            get => isAgrigation;
            set => this.RaiseAndSetIfChanged(ref isAgrigation, value);
        }
        public bool IsComposition
        {
            get => isComposition;
            set => this.RaiseAndSetIfChanged(ref isComposition, value);
        }
    }
}
