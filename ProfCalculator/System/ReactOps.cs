using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.System
{
    class ReactOps
    {
        public static string Negate(string x)
        {
            return x[0] == '-' ? x.Remove(0, 1) : "-" + x;
        }

        public static string Square(string x)
        {
            var _x = Convert.ToDouble(x);
            return (_x * _x).ToString();
        }

        public static string Root(string x)
        {
            var result = Math.Sqrt(Convert.ToDouble(x));
            return double.IsNaN(result) ? ErrorMessages.INVALID_INPUT : result.ToString();
        }

        public static string BelowOne(string x)
        {
            var _x = Convert.ToDouble(x);
            return _x == 0 ? ErrorMessages.DIVIDE_BY_ZERO : (1 / _x).ToString();
        }
    }
}
