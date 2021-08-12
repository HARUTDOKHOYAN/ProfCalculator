using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.System
{
    class ReactOps
    {
        public static string[] Negate(double x)
        {
            var str = x.ToString();
            var num = str[0] == '-' ? str.Remove(0, 1) : "-" + str;
            var info = "negate";
            return new[] { num, info };
        }

        public static string[] Square(double x)
        {
            var num = (x * x).ToString();
            var info = $"sqr";
            return new[] { num, info };
        }

        public static string[] Root(double x)
        {
            var result = Math.Sqrt(Convert.ToDouble(x));
            var num = double.IsNaN(result) ? ErrorMessages.INVALID_INPUT : result.ToString();
            var info = "√";
            return new[] { num, info };
        }

        public static string[] BelowOne(double x)
        {
            var num = x == 0 ? ErrorMessages.DIVIDE_BY_ZERO : (1 / x).ToString();
            var info = "1/";
            return new[] { num, info };
        }
    }
}
