using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.System
{
    interface IProcessorCalc
    {
        string Add(string x, string y);

        string Subtract(string x, string y);

        string Multiply(string x, string y);

        string Divide(string x, string y);

        string Percent(string x, string y);
    }
}
