using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ProfCalculator.System;

namespace ProfCalculator.Models
{
    public class HistoryCell: INotifyPropertyChanged
    {
        private ICalcData _calcData;
        public ICalcData calcData
        {
            get { return _calcData; }
            set { _calcData = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

