using ProfCalculator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.VIewModel
{
    public class HistoryCalculatorVM
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
            HistoryList = new ObservableCollection<string>
            {
                "HistoryList",
                
            };
            MemeryList = new ObservableCollection<string>
            {
                "MemeryList",
                
            }
                ;
        }
        public ObservableCollection<HistoryCalculator> HistoryCalculator { get; set; }
        public ObservableCollection<string> HistoryList { get; set; }
        public ObservableCollection<string> MemeryList { get; set; }
    }
}
