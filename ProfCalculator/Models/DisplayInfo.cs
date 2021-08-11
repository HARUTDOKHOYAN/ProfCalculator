using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.Models
{
    public class DisplayInfo: INotifyPropertyChanged
    {
        private string _calculatorMode;
        public string CalculatorModе
        {
            get
            {
                return _calculatorMode;
            }
            set
            {
                _calculatorMode = value;
                INotifyPropertyChanged("CalculatorModе");
            }
        }

        private string _display;
        public string Display
        {
            get
            {
                return _display;
            }
            set
            {
                _display = value;
                INotifyPropertyChanged("Display");
            }
        }

        private string _bitName;
        public string BitName
        {
            get
            {
                return _bitName;
            }
            set
            {
                _bitName = value;
                INotifyPropertyChanged("BitName");
            }
        }

        private int _bitStatus;
        public int BitStatus
        {
            get
            {
                return _bitStatus;
            }
            set
            {
                _bitStatus = value;
                INotifyPropertyChanged("BitStatus");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void INotifyPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
