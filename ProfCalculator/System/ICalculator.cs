using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.System
{
     public interface ICalculator
    {
          string Add(string x, string y);
          string Subtraction(string x, string y);
          string Multiply(string x, string y);
          string Division(string x, string y);
        string Percent(string x, string y);
    }
}
