using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.VIewModel
{
    class DateViewModel
    {

        public string DifferentDates(DateTimeOffset? selecteddate1, DateTimeOffset? selecteddate2)
        {
            string DatesDiff = "";
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
                int month = ((date1.Year - date2.Year) * 12) + date1.Month - date2.Month;
                month = Math.Abs(month);
                if (date1.Day > date2.Day && date1.Month < date2.Month)
                    --month;
                int year = 0;
                if (month >= 12)
                {
                    year = month / 12;
                    month -= 12 * year;
                    if (year == 1)
                        DatesDiff = $"{year} year";
                    else if (year > 1)
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
            return DatesDiff;
        }

        public string DaysDiff(DateTimeOffset? selecteddate1, DateTimeOffset? selecteddate2)
        {
            string DaysDiff = "";
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
            }
            return DaysDiff;
        }

        public string UpdateDate(DateTimeOffset? Date, string Day, string Month, string Year, int k)
        {
            string Result = "";
            if (Date.HasValue == true)
            {

                int d = Date.Value.Day;
                int m = Date.Value.Month;
                int y = Date.Value.Year;
                DateTime LastDate = new DateTime(y, m, d);
                var ResultDate = LastDate.AddDays(k * double.Parse(Day));
                ResultDate = ResultDate.AddMonths(k * Int32.Parse(Month));
                ResultDate = ResultDate.AddYears(k * Int32.Parse(Year));
                Result = ResultDate.ToString();
                Result = Result.Substring(0, 10);
            }
            return Result;
        }

    }
}
