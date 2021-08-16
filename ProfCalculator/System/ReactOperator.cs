using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.System
{
    public class ReactOperator : IPrecendencable
    {
        public ReactOperator(string infoName, int precedence, Func<string, string> function)
        {
            InfoName = infoName;
            Precedence = precedence;
            Function = function;
        }
        public string InfoName { get; set; }
        public int Precedence { get; set; }
        public Func<string, string> Function { get; set; }
    }
}
