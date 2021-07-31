using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ProfCalculator.Services
{

    public class CalcData : INotifyPropertyChanged
    {
        private string _x;
        public string X
        {
            get { return _x; }
            set { _x = value; OnPropertyChanged(); }
        }
        private string _y;
        public string Y
        {
            get { return _y; }
            set { _y = value; OnPropertyChanged(); }
        }
        private string _info;
        public string Info
        {
            get { return _info; }
            set { _info = value; OnPropertyChanged(); }
        }
        private string _prev;
        public string prev
        {
            get { return _prev; }
            set { _prev = value; OnPropertyChanged(); }
        }

        private string _activeOp;
        public string activeOp
        {
            get { return _activeOp; }
            set { _activeOp = value; OnPropertyChanged(); }
        }

        private bool _isEnd;
        public bool isEnd
        {
            get { return _isEnd; }
            set { _isEnd = value; OnPropertyChanged(); }
        }

        private string _temp;
        public string temp
        {
            get { return _temp; }
            set { _temp = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class StandardCalc : INotifyPropertyChanged
    {
        protected List<string> Numbers;
        protected Dictionary<string, string> Constants = new Dictionary<string, string>();
        protected Dictionary<string, Func<double, double, string>> Operators = new Dictionary<string, Func<double, double, string>>();
        protected Dictionary<string, Func<double, double, string>> ReactOperators = new Dictionary<string, Func<double, double, string>>();

        public StandardCalc()
        {
            Numbers = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            Operators.Add("+", Add);
            Operators.Add("-", Subtract);
            Operators.Add("X", Multiply);
            Operators.Add("/", Divide);

            ReactOperators.Add("+/-", Negate);
            ReactOperators.Add("x^2", Square);
            ReactOperators.Add("√", Root);
            ReactOperators.Add("1/x", BelowOne);
            ReactOperators.Add("%", Precent);
        }

        private readonly string DIVIDE_BY_ZERO_MESSAGE = "Cannot divide by zero";
        private readonly string INVALID_INPUT_MESSAGE = "Invalid input";

        private string _y;
        private string _x = "0";
        private string _info;
        private string prev = "number";
        private string activeOp = "";
        private bool isEnd = false;
        private string temp = "";

        public string Y
        {
            get { return _y; }
            set { _y = value; OnPropertyChanged(); }
        }
        public string X
        {
            get { return _x; }
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
            get { return _info; }
            set { _info = value; OnPropertyChanged(); }
        }

        public CalcData GetData()
        {
            return new CalcData()
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
        public void SetData(CalcData data)
        {
            X = data.X;
            Y = data.Y;
            Info = data.Info;
            prev = data.prev;
            activeOp = data.activeOp;
            isEnd = data.isEnd;
            temp = data.temp;
        }

        public void Input(string input)
        {
            //OPERATOR
            if (Operators.Keys.Contains(input))
            {
                if (!isEnd)
                    if (activeOp != "")
                        Y = X = Operators[activeOp].Invoke(Ynum, Xnum);
                    else
                        Y = X;

                activeOp = input;
                Info = Y + " " + activeOp;
                prev = "operator";
                isEnd = false;
            }
            //REACT OPERATOR
            else if (ReactOperators.Keys.Contains(input))
            {
                X = ReactOperators[input].Invoke(Ynum, Xnum);
                prev = "operator";
            }
            //NUMBER
            else if (Numbers.Contains(input))
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
            //CONSTANT
            else if (Constants.Keys.Contains(input))
            {
                X = Constants[input];
                prev = "number";
                isEnd = false;
            }
            //DOT
            else if (input == ".")
            {
                if (!X.Contains("."))
                {
                    X += ".";
                    isEnd = false;
                }
            }
            //EQUALS
            else if (input == "=")
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
                X = Y = Operators[activeOp].Invoke(Ynum, Xnum);

                prev = "operator";
                isEnd = true;
            }
            else
            {
                switch (input)
                {
                    case "C":
                        temp = "";
                        Y = "";
                        X = "0";
                        Info = "";
                        activeOp = "";
                        prev = "number";
                        isEnd = false;
                        break;
                    case "CE":
                        X = "0";
                        prev = "number";
                        break;
                    case "<":
                        if (X.Length <= 1)
                            X = "0";
                        else
                            X = X.Remove(X.Length - 1, 1);
                        prev = "number";
                        break;
                    default:
                        break;
                }
            }
        }

        //ReactOperators

        public virtual string Negate(double x, double y)
        {
            var str = y.ToString();
            Info = $"negate({str})";
            return str[0] == '-' ? str.Remove(0, 1) : "-" + str;
        }

        public virtual string Square(double x, double y)
        {
            Info = $"sqr({y})";
            return (y * y).ToString();
        }

        public virtual string Root(double x, double y)
        {
            Info = $"√({y})";
            var result = Math.Sqrt(Convert.ToDouble(y));
            return double.IsNaN(result) ? INVALID_INPUT_MESSAGE : result.ToString();
        }

        public virtual string BelowOne(double x, double y)
        {
            Info = $"1/({y})";
            return Divide(1, y);
        }

        public virtual string Precent(double x, double y)
        {
            return (x / 100 * y).ToString();
        }

        //Operators

        public virtual string Add(double x, double y)
        {
            return (x + y).ToString();
        }

        public virtual string Subtract(double x, double y)
        {
            return (x - y).ToString();
        }

        public virtual string Multiply(double x, double y)
        {
            return (x * y).ToString();
        }

        public virtual string Divide(double x, double y)
        {
            if (y == 0)
                return DIVIDE_BY_ZERO_MESSAGE;
            return (x / y).ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
