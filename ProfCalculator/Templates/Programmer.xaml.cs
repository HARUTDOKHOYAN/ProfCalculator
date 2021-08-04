using ProfCalculator.VIewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace ProfCalculator.Templates
{
    public sealed partial class Programmer : UserControl , INotifyPropertyChanged
    {
        public Programmer()
        {
            this.InitializeComponent();
            _programmerVM = new ProgrammerVM();
        }


        private void Root_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            _programmerVM.WidthCheing(e.NewSize.Width);
            _programmerVM.HeightCheing(e.NewSize.Height);

        }



        public ProgrammerVM _programmerVM
        {
            get { return (ProgrammerVM)GetValue(_programmerVMProperty); }
            set { SetValue(_programmerVMProperty, value); }
        }
        public static readonly DependencyProperty _programmerVMProperty =
            DependencyProperty.Register("_programmerVM", typeof(ProgrammerVM), typeof(Programmer), new PropertyMetadata(0));

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
