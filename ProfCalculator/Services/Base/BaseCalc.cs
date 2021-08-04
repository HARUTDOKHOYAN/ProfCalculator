using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ProfCalculator.Services
{
    abstract class BaseCalc : INotifyPropertyChanged
    {
        public BaseCalc()
        {
            Operators.Add("+", Add);
            Operators.Add("-", Subtract);
            Operators.Add("X", Multiply);
            Operators.Add("/", Divide);
        }

        protected List<string> Numbers = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        protected Dictionary<string, Func<double, double, string>> Operators = new Dictionary<string, Func<double, double, string>>();

        protected readonly string DIVIDE_BY_ZERO_MESSAGE = "Cannot divide by zero";
        protected readonly string INVALID_INPUT_MESSAGE = "Invalid input";

        //returns true if input catches something
        //returns false if input didn't catch something
        public virtual bool Input(string input)
        {
            //OPERATOR
            if (Operators.Keys.Contains(input))
            {
                OnOperator(input);
                return true;
            }
            //NUMBER
            else if (Numbers.Contains(input))
            {
                OnNumber(input);
                return true;
            }
            //EQUALS
            else if (input == "=")
            {
                OnEquals(input);
                return true;
            }
            else
            {
                switch (input)
                {
                    case "C":
                        OnC();
                        return true;
                    case "CE":
                        OnCE();
                        return true;
                    case "<":
                        OnRemove();
                        return true;
                    default:
                        return false;
                }
            }
        }

        //Methods On Input
        public abstract void OnOperator(string input);
        public abstract void OnReactOperator(string input);
        public abstract void OnNumber(string input);
        public abstract void OnEquals(string input);
        public abstract void OnC();
        public abstract void OnCE();
        public abstract void OnRemove();

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


        //Export and Import Data
        public abstract CalcData GetData();
        public abstract void SetData(CalcData data);

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
