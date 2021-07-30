using ProfCalculator.Models;
using ProfCalculator.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.VIewModel
{
    public class HistoryCalculatorVM : INotifyPropertyChanged
    {
        public HistoryCalculatorVM()
        {
            HistoryCalculator = new ObservableCollection<HistoryCalculator>
            {
                new HistoryCalculator{Content="MC"},
                new HistoryCalculator{Content="MR"},
                new HistoryCalculator{Content="M+"},
                new HistoryCalculator{Content="M-"},
                new HistoryCalculator{Content="MS"},
            };
            MemoryList = new ObservableCollection<HistoryCalculator>
            {
                new HistoryCalculator{MemoryList = "MemoryList empty" }
            };
            HistoryList = new ObservableCollection<HistoryCalculator>
            {
                new HistoryCalculator{X ="HistoryList empty",Info=""}
            };
            SelectedItems = MemoryList[0];
        }
        public ObservableCollection<HistoryCalculator> HistoryCalculator { get; set; }
        public ObservableCollection<HistoryCalculator> HistoryList { get; set; }
        public ObservableCollection<HistoryCalculator> MemoryList { get; set; }

        private HistoryCalculator _selectedItem;
        public HistoryCalculator SelectedItems
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItems");
            }
        }

        internal void InputMemory(string content, StandardCalc calc)
        {
            int i;
            if (MemoryList[0].MemoryList == "MemoryList empty")
            {
                MemoryList[0].MemoryList = "0";
            }
            if (SelectedItems == null)
                SelectedItems = MemoryList[0];
            i = MemoryList.IndexOf(SelectedItems);


            switch (content)
            {
                case "M+":
                    SelectedItems.MemoryList = (double.Parse(SelectedItems.MemoryList) + double.Parse(calc.X)).ToString();
                    MemoryList[i].MemoryList = SelectedItems.MemoryList;
                    break;
                case "M-":

                    SelectedItems.MemoryList = (double.Parse(SelectedItems.MemoryList) - double.Parse(calc.X)).ToString();
                    break;
                case "MS":
                    if (MemoryList.Count == 1 && MemoryList[0].MemoryList == "0")
                    {
                        MemoryList[0].MemoryList = calc.X;
                    }
                    else
                    {
                        MemoryList.Insert(0, new HistoryCalculator { MemoryList = calc.X });
                    }
                    break;
                case "MC":
                    MemoryList.Clear();
                    MemoryList.Add(new HistoryCalculator { MemoryList = "MemoryList empty" });
                    break;
                case "MR":
                    calc.X = SelectedItems.MemoryList;
                    break;
            }
        }

        internal void Histerycheng(string buttonName, StandardCalc calc)
        {
            List<string> arr = new List<string> { "%", "1/x", "√", "=", "x^2", };

            if (arr.Exists(x => x == buttonName) && HistoryList[0].X != "HistoryList empty")
            {
                HistoryList.Add(new HistoryCalculator { Info = calc.Info, X = calc.X });
            }
            else if (arr.Exists(x => x == buttonName))
            {
                HistoryList[0].X = calc.X;
                HistoryList[0].Info = calc.Info;
            }
        }

        internal void DeletList(HistoryCalculator data)
        {
            if (MemoryList.Count > 1)
                MemoryList.Remove(data);
            else
            {
                MemoryList[0].MemoryList = "MemoryList empty";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}