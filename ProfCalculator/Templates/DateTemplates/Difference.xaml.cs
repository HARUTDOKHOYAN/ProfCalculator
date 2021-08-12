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
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ProfCalculator.Templates.DateTemplates
{
    public sealed partial class Difference : UserControl, INotifyPropertyChanged
    {
        public Difference()
        {
            this.InitializeComponent();

        }
        DateViewModel ViewModel = new DateViewModel();

        private string _datesDiff;

        public string DatesDiff
        {
            get
            {
                return _datesDiff;
            }
            set
            {
                _datesDiff = value;
                OnPropertyChanged();
            }
        }

        private string _daysDiff;

        public string DaysDiff
        {
            get
            {
                return _daysDiff;
            }
            set
            {
                _daysDiff = value;
                OnPropertyChanged();
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void FirstDate_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            DateTimeOffset? selecteddate1 = FirstDate.Date;
            DateTimeOffset? selecteddate2 = LastDate.Date;
            DatesDiff = ViewModel.DifferentDates(selecteddate1, selecteddate2);
            DaysDiff = ViewModel.DaysDiff(selecteddate1, selecteddate2);
        }

        private void LastDate_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            DateTimeOffset? selecteddate1 = FirstDate.Date;
            DateTimeOffset? selecteddate2 = LastDate.Date;
            DatesDiff = ViewModel.DifferentDates(selecteddate1, selecteddate2);
            DaysDiff = ViewModel.DaysDiff(selecteddate1, selecteddate2);
        }
    }
}