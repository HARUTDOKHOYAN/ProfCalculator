using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.System
{
    public class ScientificCalcData : CalcData
    {
        private string _x;
        public override string X
        {
            get { return _x; }
            set { _x = value; OnPropertyChanged(); }
        }
        private string _prev;
        public string prev
        {
            get { return _prev; }
            set { _prev = value; OnPropertyChanged(); }
        }

        private List<string> _expression;
        public List<string> Expression
        {
            get { return _expression; }
            set { _expression = value; OnPropertyChanged(); }
        }

        public string ExpressionString
        {
            get => string.Join(" ", _expression);
        }
    }
}
