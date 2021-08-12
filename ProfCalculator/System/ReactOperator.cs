using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.System
{
    class ReactOperator : IPrecendencable
    {
        public ReactOperator(string infoName, int precedence, Func<double, string[]> function)
        {
            InfoName = infoName;
            Precedence = precedence;
            Function = function;
        }
        public string InfoName { get; set; }
        public int Precedence { get; set; }
        public Func<double, string[]> Function { get; set; }
    }
}
