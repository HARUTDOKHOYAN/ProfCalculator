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
        protected Dictionary<string, Func<string>> Operators = new Dictionary<string, Func<string>>();
        protected Dictionary<string, Func<string>> ReactOperators = new Dictionary<string, Func<string>>();

        public StandardCalc()
        {
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

        private string temp;
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
                if (prev == "number")
                    if(activeOp != "")
                        Y = X = Operators[activeOp].Invoke();
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
                prev = "operator";
            }
            //NUMBER
            else if (decimal.TryParse(input, out decimal number))
            {
                if (prev == "operator")
                    X = input;
                else if (prev == "number")
                    if (X == "0")
                        X = input;
                    else
                        X += input;

                prev = "number";
            }
            //DOT
            else if (input == ".")
            {
                if (!X.Contains("."))
                    X += ".";
            }
            //EQUALS
            else if (input == "=" & activeOp != "")
            {
                if(prev == "number")
                    temp = X;
                Info = $"{Y} {activeOp} {temp} =";
                X = temp;
                Y = Operators[activeOp].Invoke();
                X = Y;
                
                prev = "operator";
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
                        prev = "operator";
                        break;
                    case "CE":
                        X = "0";
                        prev = "operator";
                        break;
                    case "<":
                        if(X.Length <= 1)
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

        public virtual string Negate()
        {
            Info = $"negate({X})";
            return X[0] == '-' ? X.Remove(0, 1) : "-" + X;
        }

        public virtual string Square()
        {
            Info = $"sqr({X})";
            return (Xnum * Xnum).ToString();
        }

        public virtual string Root()
        {
            Info = $"√({X})";
            return Math.Sqrt(Convert.ToDouble(Xnum)).ToString();
        }

        public virtual string BelowOne()
        {
            if(Xnum == 0)
            {
                Info = DIVIDE_BY_ZERO_MESSAGE;
                return X;
            } else
            {
                Info = $"1/({X})";
                return (1 / Xnum).ToString();
            }
        }

        public virtual string Precent()
        {
            return (Ynum / 100 * Xnum).ToString();
        }

        //Operators
        
        public virtual string Add()
        {
            return (Ynum + Xnum).ToString();
        }

        public virtual string Subtract()
        {
            return (Ynum - Xnum).ToString();
        }

        public virtual string Multiply()
        {
            return (Ynum * Xnum).ToString();
        }

        public virtual string Divide()
        {
            if(Xnum == 0)
            {
                return DIVIDE_BY_ZERO_MESSAGE;
            }
            return (Ynum / Xnum).ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
