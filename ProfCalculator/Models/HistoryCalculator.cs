using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
                OnPropertyChanged("Content");
            }
        }
        private string _histeryList;
        public string HisteryList
        {
            get
            {
                return _histeryList;
            }
            set
            {
                _histeryList = value;
                OnPropertyChanged("HisteryList");
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
                OnPropertyChanged("MemoryList");
            }
        }
        private string _x ;
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
                OnPropertyChanged("Visibility");
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

