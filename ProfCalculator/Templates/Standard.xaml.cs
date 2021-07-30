using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Controls;
using ProfCalculator.Models;
using ProfCalculator.Services;
using System;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ProfCalculator.Templates
{
    public sealed partial class Standard : UserControl, INotifyPropertyChanged
    {
        public Standard()
        {
            this.InitializeComponent();
            uiViewModel = new StandardViewModel();
            calc = new StandardCalc();
            calcSci = new ScientificCalc();
        }
        private StandardCalc calc;
        private ScientificCalc calcSci;

        //private string _xnumber = "0";
        //private string _ynumber;
        //private string _znumber;
        //private bool _end = false;
        //private bool _isOper = false;
        //private string _temp;
        //private string temp
        //{
        //    get
        //    {
        //        return _temp;
        //    }
        //    set
        //    {
        //        _temp = value;
        //    }
        //}
        //private string _Op;
        //public string Op
        //{
        //    get { return _Op; }
        //    set { _Op = value; }
        //}

        //public string XNumber
        //{
        //    get
        //    {
        //        return _xnumber;
        //    }
        //    set
        //    {
        //        _xnumber = value;
        //        OnPropertyChanged("XNumber");
        //    }

        //}
        //public string YNumber
        //{
        //    get
        //    {
        //        return _ynumber;
        //    }
        //    set
        //    {
        //        _ynumber = value;
        //        OnPropertyChanged("YNumber");
        //    }

        //}
        //public string ZNumber
        //{
        //    get
        //    {
        //        return _znumber;
        //    }
        //    set
        //    {
        //        _znumber = value;
        //        OnPropertyChanged("ZNumber");
        //    }

        //}

        public StandardViewModel uiViewModel
        {
            get { return (StandardViewModel)GetValue(uiViewModelProperty); }
            set { SetValue(uiViewModelProperty, value); }
        }


        public static readonly DependencyProperty uiViewModelProperty =
            DependencyProperty.Register("uiViewModel", typeof(StandardViewModel), typeof(Standard), new PropertyMetadata(null));

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void Root_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var h = e.NewSize.Height - op.Height - nu.Height;
            uiViewModel.WidthCheing(e.NewSize.Width);
            uiViewModel.HeightCheing(h);

        }

        private void ListviewRoot_ItemClick(object sender, ItemClickEventArgs e)
        {
            calc.Input((e.ClickedItem as Buttoncontent).Content);
            
            //return;
            //var buttonName = e.ClickedItem as Buttoncontent;
            //if (buttonName == null) return;
            //if(int.TryParse(buttonName.Content, out int num))
            //{
            //    ReadNumber(buttonName.Content);
            //}
            //switch (buttonName.Content)
            //{
            //    case "%":
            //        Op = "%";
            //        ZNumber = XNumber;
            //        YNumber = XNumber + " % ";
            //        _isOper = true;
            //        break;
            //    case "1/x":
            //        double x = double.Parse(XNumber);
            //        double y = 1 / x;
            //        XNumber = y.ToString();
            //        YNumber = string.IsNullOrEmpty(YNumber) ? $"1/({x})" : $"1/({YNumber})";
            //        Op = string.Empty;
            //        _end = true;
            //        break;
            //    case "+/-":
            //        if (XNumber != "0")
            //        {
            //            if (XNumber[0] != '-')
            //            {
            //                YNumber = $"negate({XNumber})";
            //                XNumber = XNumber.Insert(0, "-");
            //            }
            //            else
            //            {
            //                YNumber = $"negate({XNumber})";
            //                XNumber = XNumber.Remove(0, 1);
            //            }
            //        }
            //        break;
            //    case "CE":
            //        XNumber = "0";
            //        break;
            //    case "x^2":
            //        x = double.Parse(XNumber);
            //        y = x * x;
            //        XNumber = y.ToString();
            //        YNumber = string.IsNullOrEmpty(YNumber) ? $"sqr({x})" : $"sqr({YNumber})";
            //        Op = string.Empty;
            //        _end = true;
            //        break;
            //    case "C":
            //        XNumber = "0";
            //        YNumber = "";
            //        break;
            //    case "√":
            //        x = double.Parse(XNumber);
            //        y = Math.Sqrt(x);
            //        XNumber = y.ToString();
            //        YNumber = string.IsNullOrEmpty(YNumber) ? $"sqrt({x})" : $"sqrt({YNumber})";
            //        Op = string.Empty;
            //        _end = true;
            //        break;
            //    case ".":
            //        if (XNumber.Contains(".") == false && XNumber != "")
            //            XNumber += ".";
            //        break;
            //    case "<":
            //        if (_end)
            //            YNumber = "";
            //        else if (XNumber != "" && XNumber != "0")
            //        {
            //            if ((XNumber.Length == 2 && XNumber[0] == '-') || XNumber.Length == 1)
            //                XNumber = "0";
            //            else
            //                XNumber = XNumber.Remove(XNumber.Length - 1);
            //        }
            //        break;
            //    case "/":
            //        Op = "/";
            //        ZNumber = XNumber;
            //        YNumber = XNumber + " / ";
            //        _isOper = true;
            //        break;
            //    case "X":
            //        Op = "*";
            //        ZNumber = XNumber;
            //        YNumber = XNumber + " * ";
            //        _isOper = true;
            //        break;
            //    case "-":
            //        Op = "-";
            //        ZNumber = XNumber;
            //        YNumber = XNumber + " - ";
            //        _isOper = true;
            //        break;
            //    case "+":
            //        Op = "+";
            //        ZNumber = XNumber;
            //        YNumber = XNumber + " + ";
            //        _isOper = true;
            //        break;
            //    case "=":
            //        double.TryParse(XNumber, out var res);
            //        switch (Op)
            //        {
            //            case "%":
            //                if (!_end)
            //                    temp = XNumber;
            //                res = (double.Parse(ZNumber) * double.Parse(temp)) / 100;
            //                YNumber = ZNumber + " % " + temp;

            //                break;
            //            case "+":
            //                if (!_end)
            //                    temp = XNumber;
            //                res = double.Parse(ZNumber) + double.Parse(temp);
            //                YNumber = ZNumber + " + " + temp;
            //                break;
            //            case "-":
            //                if (!_end)
            //                    temp = XNumber;
            //                res = double.Parse(ZNumber) - double.Parse(temp);
            //                YNumber = ZNumber + " - " + temp;
            //                break;
            //            case "*":
            //                if (!_end)
            //                    temp = XNumber;
            //                res = double.Parse(ZNumber) * double.Parse(temp);
            //                YNumber = ZNumber + " * " + temp;
            //                break;
            //            case "/":
            //                if (!_end)
            //                    temp = XNumber;
            //                res = double.Parse(ZNumber) / double.Parse(temp);
            //                YNumber = ZNumber + " / " + temp;
            //                break;
            //            default:
            //                break;
            //        }
            //        XNumber = res.ToString();
            //        ZNumber = XNumber;
            //        _end = true;
            //        break;

            //}
        }

        //private void ReadNumber(string number)
        //{
        //    if (_isOper)
        //    {
        //        XNumber = "";
        //        _isOper = false;
        //    }
        //    if (_end)
        //    {
        //        XNumber = "";
        //        YNumber = "";
        //        _end = false;
        //    }
        //    if (XNumber == "0")
        //        XNumber = "";
        //    XNumber += number;
        //}

        private void ListviewRoot_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
    }
}
