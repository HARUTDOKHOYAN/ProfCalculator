using ProfCalculator.Models;
using ProfCalculator.Services;
using ProfCalculator.System;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.ViewManagement;

namespace ProfCalculator.ViewModel
{
    public class StandardViewModel : INotifyPropertyChanged
    {
        public StandardViewModel()
        {
            var blue = "#b4d8fa";
            var gray = "#d5e7f7";

            UIButtons = new ObservableCollection<UIButton>()
            {
                new UIButton { Content = "%", Color = blue},
                new UIButton { Content = "CE", Color = blue},
                new UIButton { Content = "C",  Color = blue},
                new UIButton { Content = "<", Color = blue},
                new UIButton { Content = "1/x", Color = blue},
                new UIButton { Content = "√", Color = blue},
                new UIButton { Content = "x^2", Color = blue},
                new UIButton { Content = "/", Color = blue},
                new UIButton { Content = "7", Color = gray},
                new UIButton { Content = "8", Color = gray},
                new UIButton { Content = "9", Color = gray},
                new UIButton { Content = "X", Color = blue},
                new UIButton { Content = "4", Color = gray},
                new UIButton { Content = "5", Color = gray},
                new UIButton { Content = "6", Color = gray},
                new UIButton { Content = "-", Color = blue},
                new UIButton { Content = "1", Color = gray},
                new UIButton { Content = "2", Color = gray},
                new UIButton { Content = "3", Color = gray},
                new UIButton { Content = "+", Color = blue},
                new UIButton { Content = "+/-", Color = gray},
                new UIButton { Content = "0", Color = gray},
                new UIButton { Content = ".", Color = gray},
                new UIButton { Content = "=", Color = blue}
            };

            Operators.Add("+", doubleCalc.Add);
            Operators.Add("-", doubleCalc.Subtract);
            Operators.Add("X", doubleCalc.Multiply);
            Operators.Add("/", doubleCalc.Divide);

            ReactOperators.Add("+/-", ReactOps.Negate);
            ReactOperators.Add("x^2", ReactOps.Square);
            ReactOperators.Add("√", ReactOps.Root);
            ReactOperators.Add("1/x", ReactOps.BelowOne);
        }

        public ObservableCollection<UIButton> UIButtons { get; set; }

        private bool visibility = false;
        public bool Visibility
        {
            get => visibility;
            set { visibility = value; OnPropertyChanged(); }
        }

        public void WidthChange(double width)
        {
            foreach (var item in UIButtons)
                item.Width = width / 4.2;
        }

        public void HeightChange(double height)
        {
            foreach (var item in UIButtons)
                item.Height = height / 6;
        }

        private DoubleCalc doubleCalc = new DoubleCalc();
        protected Dictionary<string, Func<string, string, string>> Operators = new Dictionary<string, Func<string, string, string>>();
        private Dictionary<string, Func<double, string[]>> ReactOperators = new Dictionary<string, Func<double, string[]>>();
        private string _y;
        private string _x = "0";
        private string _info;
        private string prev = "number";
        private string activeOp = "";
        private bool isEnd = false;
        private string temp = "";
        public string Y
        {
            get => _y;
            set { _y = value; OnPropertyChanged(); }
        }
        public string X
        {
            get => _x;
            set { _x = value; OnPropertyChanged(); }
        }
        public double Ynum
        {
            get
            {
                if (double.TryParse(_y, out double res))
                    return res;
                return 0;
            }
        }
        public double Xnum
        {
            get
            {
                if (double.TryParse(_x, out double res))
                    return res;
                return 0;
            }
        }
        public string Info
        {
            get => _info;
            set { _info = value; OnPropertyChanged(); }
        }

        public void Input(string input)
        {
            //OPERATOR
            if (Operators.Keys.Contains(input))
            {
                OnOperator(input);
            }
            //EQUALS
            else if (input == "=")
            {
                OnEquals(input);
            }
            //REACT OPERATOR
            else if (ReactOperators.Keys.Contains(input))
            {
                OnReactOperator(input);
            }
            //DOT
            else if (input == ".")
            {
                OnDot(input);
            }
            else
            {
                switch (input)
                {
                    case "C":
                        OnC();
                        break;
                    case "CE":
                        OnCE();
                        break;
                    case "<":
                        OnRemove();
                        break;
                    default:
                        OnNumber(input);
                        break;
                }
            }
        }

        public void OnC()
        {
            temp = "";
            Y = "";
            X = "0";
            Info = "";
            activeOp = "";
            prev = "number";
            isEnd = false;
        }

        public void OnCE()
        {
            X = "0";
            prev = "number";
        }

        public void OnEquals(string input)
        {
            if (activeOp == "")
            {
                Y = X;
                Info = $"{Y} =";
                return;
            }

            if (!isEnd)
                temp = X;

            Info = $"{(Y == "" ? X : Y)} {activeOp} {temp} =";
            X = temp;
            X = Y = Operators[activeOp].Invoke(Y, X);

            prev = "operator";
            isEnd = true;
        }

        public void OnNumber(string input)
        {
            if (prev == "operator")
                X = input;
            else if (prev == "number")
                if (X == "0")
                    X = input;
                else
                    X += input;

            prev = "number";
            isEnd = false;
        }

        public void OnOperator(string input)
        {
            if (!isEnd)
            {
                if (activeOp != "" & prev == "number")
                    Y = X = Operators[activeOp].Invoke(Y, X);
                else
                    Y = X;
            }

            activeOp = input;
            Info = Y + " " + activeOp;
            prev = "operator";
            isEnd = false;
        }

        public void OnReactOperator(string input)
        {
            var res = ReactOperators[input].Invoke(Xnum);
            X = res[0];
            if (res[1] != "")
                Info = $"{res[1]}({res[0]})";

            prev = "operator";
        }

        public void OnRemove()
        {
            if (prev == "number")
            {
                if (X.Length <= 1)
                    X = "0";
                else
                    X = X.Remove(X.Length - 1, 1);
                prev = "number";
            }
        }

        public void OnDot(string input)
        {
            if (!X.Contains(input))
            {
                X += input;
                isEnd = false;
            }
        }

        public ICalcData GetData()
        {
            return new StandardCalcData()
            {
                X = X,
                Y = Y,
                Info = Info,
                prev = prev,
                activeOp = activeOp,
                isEnd = isEnd,
                temp = temp
            };
        }

        public void SetData(ICalcData data)
        {
            var d = data as StandardCalcData;
            X = d.X;
            Y = d.Y;
            Info = d.Info;
            prev = d.prev;
            activeOp = d.activeOp;
            isEnd = d.isEnd;
            temp = d.temp;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
