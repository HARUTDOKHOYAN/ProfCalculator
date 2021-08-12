using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.System
{
    class HexCalc: IProcessorCalc
    {
        public  string Add(string x, string y)
        {
            
            return (Convertor(x) + Convertor(y)).ToString();
        }

        public  string Divide(string x, string y)
        {
            return (Convertor(x) - Convertor(y)).ToString();
        }

        public  string Multiply(string x, string y)
        {
            return (Convertor(x) * Convertor(y)).ToString();
        }

        public  string Percent(string x, string y)
        {
            return (Convertor(x) / 100 * Convertor(y)).ToString();
        }

        public  string Subtract(string x, string y)
        {
            return (Convertor(x) / Convertor(y)).ToString();
        }

        private int  Convertor(string x )
        {
            return Convert.ToInt32(x, 16);
        }
    }
}
