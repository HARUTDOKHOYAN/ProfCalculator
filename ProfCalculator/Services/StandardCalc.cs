using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.Services
{
    class StandardCalc : BaseCalc
    {
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

        public override bool Input(string input)
        {
            var isCatch = base.Input(input);
            if (isCatch)
                return true;

            //ON DOT
            if (input == ".")
            {
                OnDot(input);
                return true;
            }

            return false;
        }

        public override void OnC()
        {
            temp = "";
            Y = "";
            X = "0";
            Info = "";
            activeOp = "";
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

        public override void OnNumber(string input)
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

        public override void OnOperator(string input)
        {
            if (!isEnd)
            {
                if (activeOp != "" & prev == "number")
                    Y = X = Operators[activeOp].Invoke(Ynum, Xnum);
                else
                    Y = X;
            }

            activeOp = input;
            Info = Y + " " + activeOp;
            prev = "operator";
            isEnd = false;
        }

        public override void OnReactOperator(string input)
        {
            X = ReactOperators[input].Invoke(Ynum, Xnum);
            prev = "operator";
        }

        public override void OnRemove()
        {
            if (X.Length <= 1)
                X = "0";
            else
                X = X.Remove(X.Length - 1, 1);
            prev = "number";
        }

        public void OnDot(string input)
        {
            if (!X.Contains(input))
            {
                X += input;
                isEnd = false;
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

        public override CalcData GetData()
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

        public override void SetData(CalcData data)
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
    }
}
