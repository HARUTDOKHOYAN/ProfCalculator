using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.Services {

    //Make ReactOperators portable
    //Move all operators into the base class
    public class StandardCalc : BaseCalc
    {
        public StandardCalc(): base()
        {
            ReactOperators.Add("+/-", Negate);
            ReactOperators.Add("x^2", Square);
            ReactOperators.Add("√", Root);
            ReactOperators.Add("1/x", BelowOne);
            ReactOperators.Add("%", Precent);
        }


        protected Dictionary<string, Func<double, string[]>> ReactOperators = new Dictionary<string, Func<double, string[]>>();

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
            var res = ReactOperators[input].Invoke(Xnum);
            X = res[0];
            if(res[1] != "")
                Info = $"{res[1]}({res[0]})";

            prev = "operator";
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
            var info = $"sqr";
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

        public virtual string[] Precent(double x)
        {
            var num = (x / 100 * Xnum).ToString();
            var info = "";
            return new[] { num, info };
        }

        public override ICalcData GetData()
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

        public override void SetData(ICalcData data)
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
