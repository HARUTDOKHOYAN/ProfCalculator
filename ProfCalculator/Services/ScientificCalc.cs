using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.Services
{
    public class ScientificCalc : BaseCalc, INotifyPropertyChanged
    {
        public ScientificCalc(): base()
        {
            ReactOperators.Add("+/-", Negate);
            ReactOperators.Add("x^2", Square);
            ReactOperators.Add("√", Root);
            ReactOperators.Add("1/x", BelowOne);

            //Update LineString on ObservableCollection change
            //_line.CollectionChanged += (sender, e) => LineString = "";
            expression.CollectionChanged += (sender, e) => ExpressionString = "";
        }

        protected Dictionary<string, Func<double, string[]>> ReactOperators = new Dictionary<string, Func<double, string[]>>();

        private string _x = "0";
        //private ObservableCollection<string> _line = new ObservableCollection<string>();
        //private ObservableCollection<string> _underline = new ObservableCollection<string>();
        private string prev = "number";
        private bool isEnd = false;

        //public ObservableCollection<string> Line
        //{
        //    get => _line;
        //    set { _line = value; OnPropertyChanged(); }
        //}
        //public string LineString
        //{
        //    get => string.Join(" ", _line);
        //    private set => OnPropertyChanged();
        //}
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






        //////////////////////////////////
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


        public override bool Input(string input)
        {
            var isCatch = base.Input(input);
            if (isCatch)
                return true;

            //REACT OPERATOR
            else if (ReactOperators.Keys.Contains(input))
            {
                OnReactOperator(input);
                return true;
            }
            //DOT
            if (input == ".")
            {
                OnDot(input);
                return true;
            }
            //BRACe OPEN
            if (input == "(")
            {
                OnBraceOpen(input);
                return true;
            }
            //BRACE CLOSE
            if (input == ")")
            {
                OnBraceClose(input);
                return true;
            }

            return false;
        }

        
        public void OnBraceOpen(string input)
        {
            Expression.Add(input);
        }

        public void OnBraceClose(string input)
        {
            if (Expression.Contains("("))
            {
                if (Operators.Keys.Contains(Expression.Last()))
                {
                    Expression.Add(Double.Parse(X).ToString());
                }
                Expression.Add(input);
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

        public override void OnC()
        {
            X = "0";
            Expression.Clear();
            prev = "number";
            isEnd = false;
        }

        public override void OnCE()
        {
            X = "0";
            prev = "number";
        }

        public override void OnEquals(string input)
        {
            //Eval(ExpressionString);
            
            //if (isEnd)
            //{
            //    Line.Clear();
            //    _underline.Clear();
            //}

            //if(prev == "number")
            //{
            //    Line.Add(X);
            //    _underline.Add(X);
            //}
            
            //var str = string.Join(" ", _underline).Replace('X', '*');
            //X = new DataTable().Compute(str, "") + "";
            //_underline.Clear();
            //Line.Add(input);
            //isEnd = true;
        }

        public override void OnNumber(string input)
        {
            if (isEnd)
            {
                Expression.Clear();
                prev = "number";
            }
            if (prev == "operator" | prev == "reactOperator")
                X = input;
            else if (prev == "number")
                if (X == "0")
                    X = input;
                else
                    X += input;

            prev = "number";
            isEnd = false;
        }

        public override void OnOperator(string input)
        {
            //Calc all and fill result in X
            if (isEnd)
            {
                Expression.Clear();
                prev = "number";
            }
            var lastItem = Expression.Count > 0 ? Expression.Last() : "";
            if (Operators.Keys.Contains(lastItem) & prev == "operator")
            {
                Expression.RemoveAt(Expression.Count - 1);
            } else if (prev == "number")
            {
                Expression.Add(X);
            }

            Expression.Add(input);

            prev = "operator";
            isEnd = false;
        }

        public override void OnReactOperator(string input)
        {
            var res = ReactOperators[input].Invoke(Xnum);
            var info = $"{res[1]}({X})";
            //X = res[0];

            if(Expression.Count > 0)
            {
                if (Operators.Keys.Contains(Expression.Last()))
                {
                    Expression.Add(X);
                }
                if (Expression.Last() == ")")
                {
                    for (var i = Expression.Count - 1; i >= 0; i--)
                    {
                        if (Expression[i] == "(")
                        {
                            Expression.Insert(i == 0 ? 0 : i - 1, res[1]);
                            break;
                        }
                    }
                }
                else
                {
                    Expression.Insert(Expression.Count - 1, res[1]);
                    Expression.Insert(Expression.Count - 1, "(");
                    Expression.Add(")");
                }
            }
            else
            {
                Expression.Add(X);
                Expression.Insert(0, res[1]);
                Expression.Insert(1, "(");
                Expression.Add(")");
            }
            prev = "reactOperator";
        }

        public override void OnRemove()
        {
            if (prev == "number")
            {
                if (X.Length <= 1)
                    X = "0";
                else
                    X = X.Remove(X.Length - 1, 1);
                prev = "number";
            }        }

        //ReactOperators
        public virtual string[] Negate(double x)
        {
            var str = x.ToString();
            var num = str[0] == '-' ? str.Remove(0, 1) : "-" + str;
            var info = "negate";
            return new[] { num, info };
        }

        public virtual string[] Square(double x)
        {
            var num = (x * x).ToString();
            var info = "sqr";
            return new[] { num, info };
        }

        public virtual string[] Root(double x)
        {
            var result = Math.Sqrt(Convert.ToDouble(x));
            var num = double.IsNaN(result) ? INVALID_INPUT_MESSAGE : result.ToString();
            var info = "√";
            return new[] { num, info };
        }

        public virtual string[] BelowOne(double x)
        {
            var num = Divide(1, x);
            var info = "1/";
            return new[] { num, info };
        }

        public override ICalcData GetData()
        {
            return new ScientificCalcData()
            {
                X = X,
                prev = prev,
                isEnd = isEnd,
                Line = Expression
            };
        }

        public override void SetData(ICalcData data)
        {
            var d = data as ScientificCalcData;
            X = d.X;
            prev = d.prev;
            isEnd = d.isEnd;
            Expression = d.Line;
        }
    }
}
