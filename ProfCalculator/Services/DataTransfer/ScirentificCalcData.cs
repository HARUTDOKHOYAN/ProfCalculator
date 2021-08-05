using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.Services
{
    public class ScientificCalcData : CalcData
    {
        private string _x;
        public string X
        {
            get { return _x; }
            set { _x = value; OnPropertyChanged(); }
        }
        private string _prev;
        public string prev
        {
            get { return _prev; }
            set { _prev = value; OnPropertyChanged(); }
        }

        private bool _isEnd;
        public bool isEnd
        {
            get { return _isEnd; }
            set { _isEnd = value; OnPropertyChanged(); }
        }
        private ObservableCollection<string> _line;
        public ObservableCollection<string> Line
        {
            get { return _line; }
            set { _line = value; OnPropertyChanged(); }
        }
        private ObservableCollection<string> _underline = new ObservableCollection<string>();
        public ObservableCollection<string> Underline
        {
            get { return _underline; }
            set { _underline = value; OnPropertyChanged(); }
        }

        public string LineString
        {
            get => string.Join(" ", _line);
        }
    }
}
