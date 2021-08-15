using ProfCalculator.Models;
using ProfCalculator.System;
using ProfCalculator.Convertor;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace ProfCalculator.ViewModel
{
    public class ProgrammerViewModel : INotifyPropertyChanged
    {
        public ProgrammerViewModel()
        {
            var blue = "#b4d8fa";
            var gray = "#d5e7f7";

            UIButtons = new ObservableCollection<UIButton>()
            {
                new UIButton { Content = "A", Color = gray},
                new UIButton { Content = "<<", Color = blue},
                new UIButton { Content = ">>", Color = blue},
                new UIButton { Content = "C.", Color = blue},
                new UIButton { Content = "<", Color = blue},
                new UIButton { Content = "B", Color = gray},
                new UIButton { Content = "(", Color = blue},
                new UIButton { Content = ")", Color = blue},
                new UIButton { Content = "%", Color = blue},
                new UIButton { Content = "/", Color = blue},
                new UIButton { Content = "C", Color = gray},
                new UIButton { Content = "7", Color = gray},
                new UIButton { Content = "8", Color = gray},
                new UIButton { Content = "9", Color = gray},
                new UIButton { Content = "X", Color = blue},
                new UIButton { Content = "D", Color = gray},
                new UIButton { Content = "4", Color = gray},
                new UIButton { Content = "5", Color = gray},
                new UIButton { Content = "6", Color = gray},
                new UIButton { Content = "-", Color = blue},
                new UIButton { Content = "E", Color = gray},
                new UIButton { Content = "1", Color = gray},
                new UIButton { Content = "2", Color = gray},
                new UIButton { Content = "3", Color = gray},
                new UIButton { Content = "+", Color = blue},
                new UIButton { Content = "F", Color = gray},
                new UIButton { Content = "+/-", Color = gray},
                new UIButton { Content = "0", Color = gray},
                new UIButton { Content = ".", Color = gray},
                new UIButton { Content = "=", Color = blue},
            };
            Visibility = true;
            displayInfo = new DisplayInfo() { CalculatorModе = "HEX", Display = "0", BitName = "WORD", BitStatus = 16 };
            BitCount = 0;

            //expression.CollectionChanged += (sender, e) => ExpressionString = "";
        }

        private DisplayInfo _displayInfo;
        public DisplayInfo displayInfo
        {
            get => _displayInfo;
            set {
                UpdateByMode(value.CalculatorModе, _displayInfo == null ? "HEX" : _displayInfo.CalculatorModе);
                _displayInfo = value;
            }
        }  //propertyChanged

        public void UpdateByMode(string mode, string oldMode)
        {
            IProcessorCalc calc;
            var newExp = new ObservableCollection<string>();

            switch (mode)
            {
                case "DEC":
                    //for (var i = 0; i < Expression.Count; i++)
                    //{
                    //    try
                    //    {
                    //        newExp[i] = displayConvertor.DecConvert(Expression[i], oldMode, displayInfo.BitStatus);
                    //    }
                    //    catch (Exception)
                    //    {
                    //        newExp.Add(Expression[i]);
                    //    }
                    //}
                    calc = decCalc;
                    break;
                case "OCT":
                    //for (var i = 0; i < Expression.Count; i++)
                    //{
                    //    try
                    //    {
                    //        newExp[i] = displayConvertor.OctConvert(Expression[i], oldMode, displayInfo.BitStatus);
                    //    }
                    //    catch (Exception)
                    //    {
                    //        newExp.Add(Expression[i]);
                    //    }
                    //}
                    calc = octCalc;
                    break;
                case "BIN":
                    //for (var i = 0; i < Expression.Count; i++)
                    //{
                    //    try
                    //    {
                    //        newExp[i] = displayConvertor.BinConvert(Expression[i], oldMode, displayInfo.BitStatus);
                    //    }
                    //    catch (Exception)
                    //    {
                    //        newExp.Add(Expression[i]);
                    //    }
                    //}
                    calc = binCalc;
                    break;
                default:
                    //for (var i = 0; i < Expression.Count; i++)
                    //{
                    //    try
                    //    {
                    //        newExp[i] = displayConvertor.HexConvert(Expression[i], oldMode, displayInfo.BitStatus);
                    //    }
                    //    catch (Exception)
                    //    {
                    //        newExp.Add(Expression[i]);
                    //    }
                    //}
                    calc = hexCalc;
                    break;
            }

            Expression = newExp;
            ExpressionString = "";

            Operators.Clear();
            Operators.Add("+", new Operator(1, calc.Add));
            Operators.Add("-", new Operator(1, calc.Subtract));
            Operators.Add("X", new Operator(2, calc.Multiply));
            Operators.Add("/", new Operator(2, calc.Divide));
            Operators.Add("%", new Operator(2, calc.Percent));

            rpn = new RPNEval(Operators);
        }

        public ObservableCollection<UIButton> UIButtons { get; set; }
        public int BitCount;
        private bool visibility;
        public bool Visibility
        {
            get => visibility;
            set {
                if (visibility.Equals(value)) return;
                visibility = value; 
                INotifyPropertyChanged(); }
        }

        private DisplayConvertor displayConvertor = new DisplayConvertor();

        private Dictionary<string, Operator> Operators = new Dictionary<string, Operator>();

        private RPNEval rpn;

        private BinCalc binCalc = new BinCalc();
        private OctCalc octCalc = new OctCalc();
        private DecCalc decCalc = new DecCalc();
        private HexCalc hexCalc = new HexCalc();

        private string _x = "0";
        private string prev = "number";
        private bool isEnd = false;

        public string X
        {
            get => displayInfo.Display;
            set
            {
                displayInfo.Display = value;
                INotifyPropertyChanged("displayInfo");
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

        private ObservableCollection<string> expression = new ObservableCollection<string>();

        public ObservableCollection<string> Expression
        {
            get { return expression; }
            set { expression = value; expression.CollectionChanged += (sender, e) => ExpressionString = ""; }
        }

        public string ExpressionString
        {
            get => string.Join(" ", expression);
            private set => INotifyPropertyChanged();
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
            //BRACE OPEN
            else if (input == "(")
            {
                OnBraceOpen(input);
            }
            //BRACE CLOSE
            else if (input == ")")
            {
                OnBraceClose(input);
            }
            else
            {
                switch (input)
                {
                    case "C.":
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

        public void OnBraceOpen(string input)
        {
            Expression.Add(input);
            prev = "braceOpen";
        }

        public void OnBraceClose(string input)
        {
            if (Expression.Contains("("))
            {
                if (Operators.Keys.Contains(Expression.Last()))
                {
                    Expression.Add(X);
                }
                Expression.Add(input);
                prev = "braceClose";
            }
        }

        public void OnC()
        {
            X = "0";
            Expression.Clear();
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
            if (isEnd)
            {
                Expression.Clear();
            }

            if (prev != "braceClose")
            {
                Expression.Add(X);
            }
            
            X = rpn.Eval(ExpressionString);
            prev = "operator";
            isEnd = true;
        }

        public void OnNumber(string input)
        {
            if (isEnd)
            {
                Expression.Clear();
                prev = "number";
            }
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
            if (isEnd)
            {
                Expression.Clear();
                prev = "number";
            }

            var lastItem = Expression.Count > 0 ? Expression.Last() : "";
            if (Operators.Keys.Contains(lastItem) & prev == "operator")
            {
                Expression.RemoveAt(Expression.Count - 1);
            }
            else if (prev == "number")
            {
                Expression.Add(X);
            }

            Expression.Add(input);

            prev = "operator";
            isEnd = false;
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

        public void BitChanged()
        {
            List<string> BitName = new List<string> { "WORD", "BYTE", "QWORD", "DWORD" };
            List<int> BitStatus = new List<int> { 16, 8, 64, 32 };
            if (BitCount <= 3)
            {
                displayInfo.BitName = BitName[BitCount];
                displayInfo.BitStatus = BitStatus[BitCount];
            }
            else
            {
                BitCount = 0;
                displayInfo.BitName = BitName[BitCount];
                displayInfo.BitStatus = BitStatus[BitCount];
            }
        }

        public void WidthChange(double width)
        {
            foreach (var item in UIButtons)
                item.Width = width / 5.2;
        }

        public void HeightChange(double height)
        {
            foreach (var item in UIButtons)
                item.Height = height / 6;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void INotifyPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}