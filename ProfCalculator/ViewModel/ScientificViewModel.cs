using ProfCalculator.Models;
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
    public class ScientificViewModel : INotifyPropertyChanged
    {
        public ScientificViewModel()
        {
            var blue = "#b4d8fa";
            var gray = "#d5e7f7";

            UIButtons = new ObservableCollection<UIButton>()
            {
                new UIButton { Content = "", Color = blue},
                new UIButton { Content = "π", Color = blue},
                new UIButton { Content = "e",  Color = blue},
                new UIButton { Content = "C",  Color = blue},
                new UIButton { Content = "CE",  Color = blue},
                new UIButton { Content = "<", Color = blue},

                new UIButton { Content = "x^3", Color = blue},
                new UIButton { Content = "x^2", Color = blue},
                new UIButton { Content = "1/x", Color = blue},
                new UIButton { Content = "|x|", Color = blue},
                new UIButton { Content = "exp", Color = blue},
                new UIButton { Content = "mod", Color = blue},

                new UIButton { Content = "3√", Color = blue},
                new UIButton { Content = "√", Color = blue},
                new UIButton { Content = "(", Color = blue},
                new UIButton { Content = ")", Color = blue},
                new UIButton { Content = "n!", Color = blue},
                new UIButton { Content = "/", Color = blue},

                new UIButton { Content = "x√y", Color = blue},
                new UIButton { Content = "x^y", Color = blue},
                new UIButton { Content = "7", Color = gray},
                new UIButton { Content = "8", Color = gray},
                new UIButton { Content = "9", Color = gray},
                new UIButton { Content = "×", Color = blue},

                new UIButton { Content = "2^x", Color = blue},
                new UIButton { Content = "10^x", Color = blue},
                new UIButton { Content = "4", Color = gray},
                new UIButton { Content = "5", Color = gray},
                new UIButton { Content = "6", Color = gray},
                new UIButton { Content = "-", Color = blue},

                new UIButton { Content = "logyx", Color = blue},
                new UIButton { Content = "log", Color = blue},
                new UIButton { Content = "1", Color = gray},
                new UIButton { Content = "2", Color = gray},
                new UIButton { Content = "3", Color = gray},
                new UIButton { Content = "+", Color = blue},

                new UIButton { Content = "e^x", Color = blue},
                new UIButton { Content = "ln", Color = blue},
                new UIButton { Content = "+/-", Color = gray},
                new UIButton { Content = "0", Color = gray},
                new UIButton { Content = ".", Color = gray},
                new UIButton { Content = "=", Color = blue}
            };

            expression.CollectionChanged += (sender, e) => ExpressionString = "";

            Operators.Add("+", new Operator(1, doubleCalc.Add));
            Operators.Add("-", new Operator(1, doubleCalc.Subtract));
            Operators.Add("×", new Operator(2, doubleCalc.Multiply));
            Operators.Add("/", new Operator(2, doubleCalc.Divide));

            ReactOperators.Add("negate", new ReactOperator("+/-", 3, ScientificReactOps.Negate));
            ReactOperators.Add("sqr", new ReactOperator("x^2", 3, ScientificReactOps.Square));
            ReactOperators.Add("√", new ReactOperator("√", 3, ScientificReactOps.Root));
            ReactOperators.Add("1/", new ReactOperator("1/x", 3, ScientificReactOps.BelowOne));
            ReactOperators.Add("abs", new ReactOperator("|x|", 3, ScientificReactOps.Abs));
            ReactOperators.Add("fact", new ReactOperator("n!", 3, ScientificReactOps.Factorial));
            ReactOperators.Add("10^", new ReactOperator("10^x", 3, ScientificReactOps.TenX));
            ReactOperators.Add("2^", new ReactOperator("2^x", 3, ScientificReactOps.TwoX));
            ReactOperators.Add("e^", new ReactOperator("e^x", 3, ScientificReactOps.EX));
            ReactOperators.Add("log", new ReactOperator("log", 3, ScientificReactOps.Log));
            ReactOperators.Add("ln", new ReactOperator("ln", 3, ScientificReactOps.Ln));
            ReactOperators.Add("cube", new ReactOperator("x^3", 3, ScientificReactOps.Cube));
            ReactOperators.Add("cuberoot", new ReactOperator("3√", 3, ScientificReactOps.CubeRoot));

            rpn = new RPNEval(Operators, ReactOperators);
        }

        private bool visibility = false;
        public bool Visibility
        {
            get => visibility;
            set { visibility = value; OnPropertyChanged(); }
        }

        public ObservableCollection<UIButton> UIButtons { get; set; }

        public void WidthChange(double width)
        {
            foreach (var item in UIButtons)
                item.Width = width / 6.2;
        }

        public void HeightChange(double height)
        {
            foreach (var item in UIButtons)
                item.Height = height / 7;
        }

        private RPNEval rpn;

        DoubleCalc doubleCalc = new DoubleCalc();

        private string _x = "0";
        private string prev = "number";
        private bool isEnd = false;

        public string X
        {
            get => _x;
            set { _x = value; OnPropertyChanged(); }
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
            set { expression = value; }
        }

        public string ExpressionString
        {
            get => string.Join(" ", expression);
            private set => OnPropertyChanged();
        }

        public void Input(string input)
        {
            //OPERATOR
            if (Operators.Keys.Contains(input))
            {
                OnOperator(input);
            }
            //REACT OPERATOR
            else if (ReactOperators.Values.FirstOrDefault((ReactOperator x) => x.InfoName == input) != null)
            {
                var reactOp = ReactOperators.FirstOrDefault((x) => x.Value.InfoName == input);
                OnReactOperator(reactOp.Key);
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
                    case "=":
                        OnEquals(input);
                        break;
                    case "(":
                        OnBraceOpen(input);
                        break;
                    case ")":
                        OnBraceClose(input);
                        break;
                    case "C":
                        OnC();
                        break;
                    case "CE":
                        OnCE();
                        break;
                    case "<":
                        OnRemove();
                        break;
                    case "π":
                        X = Math.PI.ToString();
                        prev = "ReactOperator";
                        break;
                    case "e":
                        X = Math.E.ToString();
                        prev = "ReactOperator";
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


        public void OnDot(string input)
        {
            if (!X.Contains(input))
            {
                X += input;
                isEnd = false;
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

            if(prev != "braceClose" & prev != "reactOperator")
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
            if (prev == "operator" | prev == "reactOperator" | prev == "braceOpen")
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
            else if (prev == "number" | prev == "braceOpen")
            {
                Expression.Add(X);
            }

            Expression.Add(input);

            prev = "operator";
            isEnd = false;
        }

        public void OnReactOperator(string name)
        {
            if (Expression.Count > 0)
            {
                if (Operators.Keys.Contains(Expression.Last()))
                {
                    Expression.Add(X);
                }
                if (Expression.Last() == ")")
                {
                    var index = 0;
                    var openBraces = 0;
                    for (var i = Expression.Count - 1; i >= 0; i--)
                    {
                        if (Expression[i] == ")" && openBraces > 0) break;
                        if (Expression[i] == "(")
                        {
                            openBraces++;
                            index = i;
                        }
                    }
                    index = index == 0 ? 0 : index - 1;

                    if (ReactOperators.ContainsKey(Expression[index]))
                    {
                        Expression.Insert(index, name);
                        Expression.Insert(index + 1, "(");
                        Expression.Insert(Expression.Count - 1, ")");
                    }
                    else
                    {
                        Expression.Insert(index + 1, name);
                    }
                }
                else
                {
                    Expression.Insert(Expression.Count - 1, name);
                    Expression.Insert(Expression.Count - 1, "(");
                    Expression.Add(")");
                }
            }
            else
            {
                Expression.Add(X);
                Expression.Insert(0, name);
                Expression.Insert(1, "(");
                Expression.Add(")");
            }
            prev = "reactOperator";
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

        private Dictionary<string, Operator> Operators = new Dictionary<string, Operator>();
        private Dictionary<string, ReactOperator> ReactOperators = new Dictionary<string, ReactOperator>();

        public ICalcData GetData()
        {
            return new ScientificCalcData()
            {
                X = X,
                prev = prev,
                isEnd = isEnd,
                Line = Expression
            };
        }

        public void SetData(ICalcData data)
        {
            var d = data as ScientificCalcData;
            X = d.X;
            prev = d.prev;
            isEnd = d.isEnd;
            Expression = d.Line;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
