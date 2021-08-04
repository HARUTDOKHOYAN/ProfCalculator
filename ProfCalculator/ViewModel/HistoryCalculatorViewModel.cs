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

namespace ProfCalculator.ViewModel
{
    public class HistoryCalculatorViewModel : INotifyPropertyChanged
    {
        public HistoryCalculatorViewModel()
        {
            MemoryButtons = new ObservableCollection<UIButton>
            {
                new UIButton{Content="MC"},
                new UIButton{Content="MR"},
                new UIButton{Content="M+"},
                new UIButton{Content="M-"},
                new UIButton{Content="MS"}
            };

            HistoryList = new ObservableCollection<HistoryCell>();
            MemoryList = new ObservableCollection<MemoryCell>();
        }
        public ObservableCollection<UIButton> MemoryButtons { get; set; }
        public ObservableCollection<HistoryCell> HistoryList { get; set; }
        public ObservableCollection<MemoryCell> MemoryList { get; set; }

        private MemoryCell _selectedItem;
        public MemoryCell SelectedItem
        {
            get => _selectedItem;
            set { _selectedItem = value; OnPropertyChanged(); }
        }

        public string InputMemory(string content, string X)
        {
            if(SelectedItem == null & content != "MS")
            {
                if (MemoryList.Count == 0)
                    MemoryList.Add(new MemoryCell());

                SelectedItem = MemoryList[0];
            }


            switch (content)
            {
                case "M+":
                    SelectedItem.Number = (double.Parse(SelectedItem.Number) + double.Parse(X)).ToString();
                    break;
                case "M-":
                    SelectedItem.Number = (double.Parse(SelectedItem.Number) - double.Parse(X)).ToString();
                    break;
                case "MS":
                    MemoryList.Add(new MemoryCell());
                    break;
                case "MC":
                    MemoryList.Clear();
                    break;
                case "MR":
                    return SelectedItem.Number;
            }

            return "";
        }

        public void InputHistory(ICalcData data)
        {
            HistoryList.Add(new HistoryCell() { calcData = data });
        }

        public void CleanHistory()
        {
            HistoryList.Clear();
        }

        public void RemoveMemory(MemoryCell data)
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