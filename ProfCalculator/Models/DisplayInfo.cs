using ProfCalculator.Convertor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.Models
{
    public class DisplayInfo : INotifyPropertyChanged
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
                if (BitSizeSet(value) == true)
                        _display = value;
                INotifyPropertyChanged("Display");
            }
        }

        private bool BitSizeSet(string value)
        {
            string cont ;
            if (BitStatus == 0)
                BitStatus = 16;

            switch (CalculatorModе)
            {
                case "HEX":
                    cont = ConvertorRepresentation.HexToDec(value, 64);
                    break;
                    
                case "BIN":
                    cont = ConvertorRepresentation.BinToDec(value, 64);
                    break;
                case "OCT":
                    cont =  ConvertorRepresentation.OctToDec(value, 64);
                    break;
                default:
                    cont = value;
                    break;
            }
            switch (BitStatus)
            {
                case 8:
                    if(long.Parse(cont) > sbyte.MinValue || long.Parse(cont) < sbyte.MaxValue)
                    {
                        return true;
                    }
                    return false;
                default:
                    return true;
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
