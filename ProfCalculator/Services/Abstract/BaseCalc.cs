using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ProfCalculator.Services
{
    public abstract class BaseCalc : INotifyPropertyChanged
    {
        protected List<string> Numbers;
        protected Dictionary<string, Func<double, double, string>> Operators = new Dictionary<string, Func<double, double, string>>();
        protected Dictionary<string, Func<double, double, string>> ReactOperators = new Dictionary<string, Func<double, double, string>>();

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
            //REACT OPERATOR
            else if (ReactOperators.Keys.Contains(input))
            {
                OnReactOperator(input);
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

        //Export and Import Data
        public abstract ICalcData GetData();
        public abstract void SetData(ICalcData data);

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
