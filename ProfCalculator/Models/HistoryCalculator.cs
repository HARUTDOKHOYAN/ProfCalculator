using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ProfCalculator.Services;

namespace ProfCalculator.Models
{
    public class HistoryCalculator: INotifyPropertyChanged
    {
        private string _content;
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
                OnPropertyChanged();
            }
        }
        private string _historyList;
        public string HistoryList
        {
            get
            {
                return _historyList;
            }
            set
            {
                _historyList = value;
                OnPropertyChanged();
            }
        }
        private string _memoryList;
        public string MemoryList
        {
            get
            {
                return _memoryList;
            }
            set
            {
                _memoryList = value;
                OnPropertyChanged();
            }
        }
        private CalcData _calcData;
        public CalcData CalcData
        {
            get { return _calcData; }
            set { _calcData = value; OnPropertyChanged(); }
        }

        private string _x;
        public string X
        {
            get { return _x; }
            set { _x = value; OnPropertyChanged(); }
        }
        private string _info;
        public string Info
        {
            get { return _info; }
            set { _info = value; OnPropertyChanged(); }
        }
        private bool _visibility;
        public bool Visibility
        {
            get => _visibility;
            set
            {
                _visibility = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

