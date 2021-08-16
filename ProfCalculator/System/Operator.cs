using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.System
{
    public class Operator: IPrecendencable
    {
        public Operator(int precedence, Func<string, string, string> function)
        {
            Precedence = precedence;
            Function = function;
        }
        public int Precedence { get; set; }
        public Func<string, string, string> Function { get; set; }
    }
}
