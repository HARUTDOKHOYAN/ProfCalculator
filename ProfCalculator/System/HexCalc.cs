using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.System
{
    class HexCalc: IProcessorCalc
    {
        public string Add(string x, string y)
        {
            return Result(Convertor(x) + Convertor(y));
        }

        public string Subtract(string x, string y)
        {
            return Result(Convertor(x) - Convertor(y));
        }

        public string Multiply(string x, string y)
        {
            return Result(Convertor(x) * Convertor(y));
        }

        public string Percent(string x, string y)
        {
            return Result(Convertor(x) / 100 * Convertor(y));
        }

        public string Divide(string x, string y)
        {
            return Result(Convertor(x) / Convertor(y));
        }

        private string Result(int num)
        {
            return Convert.ToString(num, 16).ToUpper();
        }

        private int Convertor(string x)
        {
            return Convert.ToInt32(x, 16);
        }
    }
}
