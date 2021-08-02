using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.Services.DataTransfer
{
    class StandardCalcData: CalcData
    {
        private string _x;
        public string X
        {
            get { return _x; }
            set { _x = value; OnPropertyChanged(); }
        }
        private string _y;
        public string Y
        {
            get { return _y; }
            set { _y = value; OnPropertyChanged(); }
        }
        private string _info;
        public string Info
        {
            get { return _info; }
            set { _info = value; OnPropertyChanged(); }
        }
        private string _prev;
        public string prev
        {
            get { return _prev; }
            set { _prev = value; OnPropertyChanged(); }
        }

        private string _activeOp;
        public string activeOp
        {
            get { return _activeOp; }
            set { _activeOp = value; OnPropertyChanged(); }
        }

        private bool _isEnd;
        public bool isEnd
        {
            get { return _isEnd; }
            set { _isEnd = value; OnPropertyChanged(); }
        }

        private string _temp;
        public string temp
        {
            get { return _temp; }
            set { _temp = value; OnPropertyChanged(); }
        }
    }
}
