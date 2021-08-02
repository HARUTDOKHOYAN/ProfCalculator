using ProfCalculator.Models;
using ProfCalculator.Templates.DateTemplates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ProfCalculator.Templates
{
    public sealed partial class DateCalculation : UserControl, INotifyPropertyChanged
    {
        public DateCalculation()
        {
            this.InitializeComponent();
        }

        

        private string _contentName = "Difference between dates";

        public bool AllowDrop { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string ContentName
        {
            get { return _contentName; }
            set
            {
                _contentName = value;
                OnPropertyChanged();
            }
        }


        private void DropDownButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void MenuFlyoutItem_Click_1(object sender, RoutedEventArgs e)
        {
                ContentName = "Difference between dates";
        }

        private void MenuFlyoutItem_Click_2(object sender, RoutedEventArgs e)
        {
            ContentName = "Add or subtract days";
        }

    }
}
