using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Calculator
{

    public sealed partial class MainPage : Page , INotifyPropertyChanged
    {
        public MainPage()
        {
            this.InitializeComponent();
            
        }

        private bool _end = false;
        private bool _isOper = false;
        private bool _isC = false;
        private string _Op;
        public string Op
        {
            get { return _Op; }
            set { _Op = value; }
        }
        private string _XNumber = "0";
        public string XNumber
        {
            get
            {
                return _XNumber;
            }
            set
            {
                _XNumber = value;
                OnPropertyChanged("XNumber");
            }
        }

        private string _YNumber;
        public string YNumber
        {
            get
            {
                return _YNumber;
            }
            set
            {
                _YNumber = value; 
                OnPropertyChanged("YNumber");
            }
        }

        private string _temp;
        private string temp
        {
            get
            {
                return _temp;
            }
            set
            {
                _temp = value;
            }
        }

        private string _ZNumber;

        public string ZNumber
        {
            get { return _ZNumber; }
            set { _ZNumber = value; }
        }

        private void ReadNumber(string number)
        {
            if (_isC)
            {
                XNumber = ZNumber;
                ZNumber = "";
                //YNumber = $"{XNumber} = ";
                Op = "";
                _isC = false;
            }
            if (_isOper)
            {
                XNumber = "";
                _isOper = false;
            }
            if (_end)
            {
                XNumber = "";
                YNumber = "";
                _end = false;
            }
            if (XNumber == "0")
                XNumber = "";
            XNumber += number;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void Percent_Click(object sender, RoutedEventArgs e)
        {
            Op = "%" ;
            ZNumber = XNumber;
            YNumber = XNumber + " % ";
            XNumber = "0";
            _end = true;
        }

        private void OneDiv_Click(object sender, RoutedEventArgs e)
        {
            double x = double.Parse(XNumber);
            double y = 1 / x;
            XNumber = y.ToString();
            YNumber = string.IsNullOrEmpty(YNumber) ? $"1/({x})" : $"1/({YNumber})";
            Op = string.Empty;
            _end = true;
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            ReadNumber("7");
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            ReadNumber("4");
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            ReadNumber("1");
        }

        private void Sign_Click(object sender, RoutedEventArgs e)
        {
            if (XNumber != "0")
            {
                if (XNumber[0] != '-')
                {
                    YNumber = $"negate({XNumber})";
                    XNumber = XNumber.Insert(0, "-");
                }
                else
                {
                    YNumber = $"negate({XNumber})";
                    XNumber = XNumber.Remove(0, 1);
                }
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            XNumber = "0";
        }

        private void Pow2_Click(object sender, RoutedEventArgs e)
        {
            double x = double.Parse(XNumber);
            double y = x * x;
            XNumber = y.ToString();
            YNumber =string.IsNullOrEmpty(YNumber) ? $"sqr({x})":$"sqr({YNumber})";
            Op = string.Empty;
            _end = true;

        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            ReadNumber("8");
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            ReadNumber("5");
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            ReadNumber("2");
        }

        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            ReadNumber("0");
        }

        private void RemoveAll_Click(object sender, RoutedEventArgs e)
        {
            XNumber = "0";
            YNumber = "";
            _isC = true;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (_end)
                YNumber = "";
            else if (XNumber != "" && XNumber != "0")
            {
                if ((XNumber.Length == 2 && XNumber[0] == '-') || XNumber.Length == 1)
                    XNumber = "0";
                else
                    XNumber = XNumber.Remove(XNumber.Length - 1);
            }
        }
        private void Sqrt_Click(object sender, RoutedEventArgs e)
        {
            double x = double.Parse(XNumber);
            double y = Math.Sqrt(x);
            XNumber = y.ToString();
            YNumber = string.IsNullOrEmpty(YNumber) ? $"sqrt({x})" : $"sqrt({YNumber})";
            Op = string.Empty;
            _end = true;
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            ReadNumber("9");
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            ReadNumber("6");
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            ReadNumber("3");
        }

        private void Point_Click(object sender, RoutedEventArgs e)
        {
            if(XNumber.Contains(".") == false && XNumber != "")
                XNumber += ".";
        }

        private void Division_Click(object sender, RoutedEventArgs e)
        {
            if (!XNumber.Contains("+") && !XNumber.Contains("-") && !XNumber.Contains("*") && !XNumber.Contains("/"))
            {
                Op = "/";
                ZNumber = XNumber;
                YNumber = XNumber + " / ";
                _isOper = true;
                //XNumber = "0";
            }
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            if (!XNumber.Contains("+") && !XNumber.Contains("-") && !XNumber.Contains("*") && !XNumber.Contains("/"))
            {
                Op = "*";
                ZNumber = XNumber;
                YNumber = XNumber + " * ";
                _isOper = true;
                //XNumber = "0";
            }
        }

        private void Subtraction_Click(object sender, RoutedEventArgs e)
        {
            if (!XNumber.Contains("+") && !XNumber.Contains("-") && !XNumber.Contains("*") && !XNumber.Contains("/"))
            {
                Op = "-";
                ZNumber = XNumber;
                YNumber = XNumber + " - ";
                _isOper = true;
                //XNumber = "0";
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (!XNumber.Contains("+") && !XNumber.Contains("-") && !XNumber.Contains("*") && !XNumber.Contains("/"))
            {
                Op = "+";
                ZNumber = XNumber;
                YNumber = XNumber + " + ";
                _isOper = true;
                //XNumber = "";
            }
        }


        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            double.TryParse(XNumber, out var res);
            switch (Op)
            {
                case "%":
                    if (!_end)
                        temp = XNumber;
                    res = (double.Parse(ZNumber) * double.Parse(temp)) / 100;
                    YNumber = ZNumber + " % " + temp;
                    
                    break;
                case "+":
                    if (!_end)
                        temp = XNumber;
                    res = double.Parse(ZNumber) + double.Parse(temp);
                    YNumber = ZNumber + " + " + temp;
                    break;
                case "-":
                    if (!_end)
                        temp = XNumber;
                    res = double.Parse(ZNumber) - double.Parse(temp);
                    YNumber = ZNumber + " - " + temp;
                    break;
                case "*":
                    if (!_end)
                        temp = XNumber;
                    res = double.Parse(ZNumber) * double.Parse(temp);
                    YNumber = ZNumber + " * " + temp;
                    break;
                case "/":
                    if (!_end)
                        temp = XNumber;
                    res = double.Parse(ZNumber) /    double.Parse(temp);
                    YNumber = ZNumber + " / " + temp;
                    break;
                default:
                    break;
            }
            XNumber = res.ToString();
            ZNumber = XNumber;
            _end = true;
        }

        private void root_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            switch (e.Key)
            {
                case Windows.System.VirtualKey.Number0:
                    Zero_Click(null,null);
                    break;
                case Windows.System.VirtualKey.Number1:
                    One_Click(null,null);
                    break;
                case Windows.System.VirtualKey.Number2:
                    Two_Click(null, null);
                    break;
                case Windows.System.VirtualKey.Number3:
                    Three_Click(null, null);
                    break;
                case Windows.System.VirtualKey.Number4:
                    Four_Click(null, null);
                    break;
                case Windows.System.VirtualKey.Number5:
                    Five_Click(null, null);
                    break;
                case Windows.System.VirtualKey.Number6:
                    Six_Click(null, null);
                    break;
                case Windows.System.VirtualKey.Number7:
                    Seven_Click(null, null);
                    break;
                case Windows.System.VirtualKey.Number8:
                    Eight_Click(null, null);
                    break;
                case Windows.System.VirtualKey.Number9:
                    Nine_Click(null, null);
                    break;
                case Windows.System.VirtualKey.Back:
                    Back_Click(null, null);
                    break;
                case Windows.System.VirtualKey.Delete:
                    RemoveAll_Click(null, null);
                    break;
            }
        }
    }
}
