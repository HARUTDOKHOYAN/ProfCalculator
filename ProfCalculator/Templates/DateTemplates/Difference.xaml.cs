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

        private void DifferentDates()
        {
            DatesDiff = "";
            DateTimeOffset? selecteddate1 = FirstDate.Date;
            DateTimeOffset? selecteddate2 = LastDate.Date;
            if (selecteddate1.HasValue == true && selecteddate2.HasValue == true)
            {
                int d1 = selecteddate1.Value.Day;
                int m1 = selecteddate1.Value.Month;
                int y1 = selecteddate1.Value.Year;
                int d2 = selecteddate2.Value.Day;
                int m2 = selecteddate2.Value.Month;
                int y2 = selecteddate2.Value.Year;

                DateTime date1 = new DateTime(y1, m1, d1);
                DateTime date2 = new DateTime(y2, m2, d2);
                if (date1 > date2)
                {
                    var date = date1;
                    date1 = date2;
                    date2 = date;
                }
                double days = (date1 - date2).TotalDays;
                days = Math.Abs(days);
                DaysDiff = days.ToString() + " days";
                int month = ((date1.Year - date2.Year) * 12) + date1.Month - date2.Month;
                month = Math.Abs(month);
                if (date1.Day > date2.Day && date1.Month < date2.Month)
                    --month;
                int year = 0;
                if (month > 12)
                {
                    year = month / 12;
                    month -= 12 * year;
                    if (year == 1)
                        DatesDiff = $"{year} year";
                    else if(year > 1)
                        DatesDiff = $"{year} years";
                }

                if (month == 1)
                    DatesDiff += $" {month} month";
                else if (month > 1)
                    DatesDiff += $" {month} months";

                month = Math.Abs(month);
                var date3 = date1.AddMonths(month + 12 * year);
                double days1 = (date2 - date3).TotalDays;
                days1 = Math.Abs(days1);
                int week = (int)days1 / 7;
                int day = (int)days1 - week * 7;
                if (week == 1)
                    DatesDiff += $" {week} week";
                else if (week > 1)
                    DatesDiff += $" {week} weeks";
                if (day == 1)
                    DatesDiff += $" {day} day";
                else if (day > 1)
                    DatesDiff += $" {day} days";
            }
        }

       
        private int MonthCount(DateTime ddd1, DateTime ddd2)
        {
            int month1 = ((ddd1.Year - ddd2.Year) * 12) + ddd1.Month - ddd2.Month;
            month1 = Math.Abs(month1);
            if (ddd1.Day > ddd2.Day && ddd1.Month <= ddd2.Month)
                --month1;
            return month1;
        }
        private void FirstDate_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            DifferentDates();
        }

        private void LastDate_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            DifferentDates();
        }
    }
}


    


