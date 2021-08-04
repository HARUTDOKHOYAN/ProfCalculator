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
            MemoryList = new ObservableCollection<HistoryCalculator>();
            HistoryList = new ObservableCollection<HistoryCalculator>();
        }

        public ObservableCollection<HistoryCalculator> HistoryCalculator { get; set; }
        public ObservableCollection<HistoryCalculator> HistoryList { get; set; }
        public ObservableCollection<HistoryCalculator> MemoryList { get; set; }

        private HistoryCalculator _selectedItem;
        public HistoryCalculator SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public void InputMemory(string content, string X)
        {
            if(SelectedItem == null & content != "MS")
            {
                if (MemoryList.Count == 0)
                    MemoryList.Add(new HistoryCalculator { MemoryList = "0" });

                SelectedItem = MemoryList[0];
            }


            switch (content)
            {
                case "M+":

                    SelectedItem.MemoryList = (double.Parse(SelectedItem.MemoryList) + double.Parse(X)).ToString();
                    break;
                case "M-":
                    SelectedItem.MemoryList = (double.Parse(SelectedItem.MemoryList) - double.Parse(X)).ToString();
                    break;
                case "MS":
                    MemoryList.Add(new HistoryCalculator { MemoryList = X });
                    break;
                case "MC":
                    MemoryList.Clear();
                    break;
                case "MR":
                    X = SelectedItem.MemoryList;
                    break;
            }
        }

        public void HistoryChange(CalcData Data)
        {
            HistoryList.Add(new HistoryCalculator { CalcData = Data});
        }

        public void HistoryClear()
        {
            HistoryList.Clear();
        }

        public void DeleteList(HistoryCalculator data)
        {
            if (MemoryList.Count > 0)
                MemoryList.Remove(data);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}