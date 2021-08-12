using ProfCalculator.VIewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class AddSubtract : UserControl, INotifyPropertyChanged
    {
        public AddSubtract()
        {
            this.InitializeComponent();
            List<string> l = new List<string>();
            l.AddRange(Enumerable.Range(0, 100).Select(x => x.ToString()));
            NumberCollection = new ObservableCollection<string>(l);
        }

        DateViewModel ViewModel = new DateViewModel();

        private string _year = "0";
        private string _month = "0";
        private string _day = "0";

        private string _result;

        public string Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }


        public string Year
        {
            get
            {
                return _year;
            }
            set
            {
                _year = value;
                OnPropertyChanged();
            }
        }
        public string Month
        {
            get
            {
                return _month;
            }
            set
            {
                _month = value;
                OnPropertyChanged();
            }
        }
        public string Day
        {
            get
            {
                return _day;
            }
            set
            {
                _day = value;
                OnPropertyChanged();
            }
        }
        private int k = 1;


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        ObservableCollection<string> NumberCollection;


        private void Years_ItemClick(object sender, ItemClickEventArgs e)
        {
            Year = e.ClickedItem as string;
            DateTimeOffset? Date = MyDate.Date;
            Result = ViewModel.UpdateDate(Date, Day, Month, Year, k);
            //dropdown.
        }

        private void Months_ItemClick(object sender, ItemClickEventArgs e)
        {
            Month = e.ClickedItem as string;
            DateTimeOffset? Date = MyDate.Date;
            Result = ViewModel.UpdateDate(Date, Day, Month, Year, k);
        }

        private void Days_ItemClick(object sender, ItemClickEventArgs e)
        {
            Day = e.ClickedItem as string;
            DateTimeOffset? Date = MyDate.Date;
            Result = ViewModel.UpdateDate(Date, Day, Month, Year, k);
        }

        private void CalendarDatePicker_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            DateTimeOffset? Date = MyDate.Date;
            Result = ViewModel.UpdateDate(Date, Day, Month, Year, k);
        }

        private void Add_Checked(object sender, RoutedEventArgs e)
        {
            k = 1;
            DateTimeOffset? Date = MyDate.Date;
            Result = ViewModel.UpdateDate(Date, Day, Month, Year, k);
        }

        private void Subtract_Checked(object sender, RoutedEventArgs e)
        {
            k = -1;
            DateTimeOffset? Date = MyDate.Date;
            Result = ViewModel.UpdateDate(Date, Day, Month, Year, k);
        }
    }

}