using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.System
{
    class Operator
    {
        public Operator(int precedence)
        {
            Precedence = precedence;
        }
        public int Precedence { get; set; }
    }
}
