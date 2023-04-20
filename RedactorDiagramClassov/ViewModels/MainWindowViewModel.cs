using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Avalonia;
using Avalonia.Input;
using Avalonia.Media;
using DynamicData;
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
    }
}