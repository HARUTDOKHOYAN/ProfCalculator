using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.Services
{

    //in scientific:
    //create Numbers Dictionary for Pi and others
    //if input is not an operator or number - check in Numbers Dictionary

    public class StandardCalc : INotifyPropertyChanged
    {
        private Dictionary<string, Func<decimal>> Operators = new Dictionary<string, Func<decimal>>();
        private Dictionary<string, Func<string>> ReactOperators = new Dictionary<string, Func<string>>();

        public StandardCalc()
        {
            Operators.Add("+", Add);
            Operators.Add("-", Subtract);
            Operators.Add("X", Multiply);
            Operators.Add("/", Divide);

            ReactOperators.Add(",", Comma);
            ReactOperators.Add("+/-", Negate);
            ReactOperators.Add("x^2", Square);
            ReactOperators.Add("√", Root);
            ReactOperators.Add("1/x", BelowOne);
            ReactOperators.Add("%", Precent);
        }

        private string _y;
        private string _x = "0";
        private string _info;

        public string Y {
            get { return _y; }
            set { _y = value; OnPropertyChanged(); }
        }
        public string X
        {
            get { return _x; }
            set { _x = value; OnPropertyChanged(); }
        }
        public decimal Ynum
        {
            get
            {
                if(decimal.TryParse(_y, out decimal res))
                    return res;
                return 0;
            }
        }
        public decimal Xnum
        {
            get
            {
                if (decimal.TryParse(_x, out decimal res))
                    return res;
                return 0;
            }
        }
        public string Info
        {
            get { return _info; }
            set { _info = value; OnPropertyChanged(); }
        }


        private string prev = "operator";
        private string activeOp = "";

        public void Input(string input)
        {
            //OPERATOR
            if (Operators.Keys.Contains(input))
            {
                if (prev == "number" & activeOp != "")
                    Y = Operators[activeOp].Invoke().ToString();
                else
                    Y = X;

                activeOp = input;
                Info = Y + " " + activeOp;
                prev = "operator";
            }
            //REACT OPERATOR
            else if (ReactOperators.Keys.Contains(input))
            {
                X = ReactOperators[input].Invoke();
                prev = "number";
            }
            //NUMBER
            else if (decimal.TryParse(input, out decimal number))
            {
                if (prev == "operator")
                    X = input;
                else if (prev == "number")
                    X += input;

                prev = "number";
            }
            //EQUALS
            else if (input == "=" & activeOp != "")
            {
                Info += " " + X + "=";
                X = Operators[activeOp].Invoke().ToString();
                Y = X;
                prev = "number";
            }
            else
            {
                switch (input)
                {
                    case "C":
                        Y = "";
                        X = "0";
                        Info = "";
                        activeOp = "";
                        prev = "operator";
                        break;
                    case "CE":
                        X = "0";
                        prev = "operator";
                        break;
                    case "<":

                        X = X.Length <= 1 ? "0" : X.Remove(X.Length - 1, 1);
                        break;
                    default:
                        break;
                }
            }
        }

        //ReactOperators

        private string Comma()
        {
            if (!X.Contains(","))
                return X + ",";
            return X;
        }

        private string Negate()
        {
            Info = $"negate({X})";
            return X[0] == '-' ? X.Remove(0, 1) : "-" + X;
        }

        private string Square()
        {
            Info = $"sqr({X})";
            return (Xnum * Xnum).ToString();
        }

        private string Root()
        {
            Info = $"√({X})";
            return Math.Sqrt(Convert.ToDouble(Xnum)).ToString();
        }

        private string BelowOne()
        {
            if(Xnum == 0)
            {
                Info = $"Cannot divide by zero";
                return X;
            } else
            {
                Info = $"1/({X})";
                return (1 / Xnum).ToString();
            }
        }

        private string Precent()
        {
            return (Ynum / 100 * Xnum).ToString();
        }

        //Operators

        private decimal Add()
        {
            return Ynum + Xnum;
        }

        private decimal Subtract()
        {
            return Ynum - Xnum;
        }

        private decimal Multiply()
        {
            return Ynum * Xnum;
        }

        private decimal Divide()
        {
            if(Xnum == 0)
            {
                return Ynum;
            }
            return Ynum / Xnum;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
