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
            if (BitStatus == 0)
                BitStatus = 16;

            void BitStatusCheck(string val, int mode)
            {
                switch (BitStatus)
                {
                    case 8:
                        Convert.ToSByte(val, mode);
                        break;
                    case 16:
                        Convert.ToInt16(val, mode);
                        break;
                    case 32:
                        Convert.ToInt32(val, mode);
                        break;
                    case 64:
                        Convert.ToInt64(val, mode);
                        break;
                }
            }
            switch (CalculatorModе)
            {
                case "HEX":
                    try
                    {
                        BitStatusCheck(value, 16);
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                    return true;
                case "BIN":
                    try
                    {
                        BitStatusCheck(value, 2);
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                    return true;
                case "OCT":
                    try
                    {
                        BitStatusCheck(value, 8);
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                    return true;
                default:
                    try
                    {
                        BitStatusCheck(value, 10);
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
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
