using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.System
{
    class ScientificReactOps: ReactOps
    {
        public static string Abs(string x)
        {
            var _x = Convert.ToDouble(x);
            return Math.Abs(_x).ToString();
        }

        public static string Factorial(string x)
        {
            var _x = Convert.ToDouble(x);
            double fact(double n)
            {
                if (n <= 1)
                    return 1;
                return n * fact(n - 1);
            }

            return fact(_x).ToString();
        }

        public static string TenX(string x)
        {
            var _x = Convert.ToDouble(x);
            return Math.Pow(10, _x).ToString();
        }

        public static string TwoX(string x)
        {
            var _x = Convert.ToDouble(x);
            return Math.Pow(2, _x).ToString();
        }

        public static string EX(string x)
        {
            var _x = Convert.ToDouble(x);
            return Math.Pow(Math.E, _x).ToString();
        }

        public static string Log(string x)
        {
            var _x = Convert.ToDouble(x);
            return Math.Log10(_x).ToString();
        }

        public static string Ln(string x)
        {
            var _x = Convert.ToDouble(x);
            return Math.Log(_x).ToString();
        }

        public static string Cube(string x)
        {
            var _x = Convert.ToDouble(x);
            return Math.Pow(_x, 3).ToString();
        }

        public static string CubeRoot(string x)
        {
            var _x = Convert.ToDouble(x);
            return Math.Pow(_x, 1 / 3).ToString();
        }

        public static string Floor(string x)
        {
            var _x = Convert.ToDouble(x);
            return Math.Floor(_x).ToString();
        }

        public static string Ceil(string x)
        {
            var _x = Convert.ToDouble(x);
            return Math.Ceiling(_x).ToString();
        }

        public static string Random(string x)
        {
            return new Random().NextDouble().ToString();
        }

        //Trigonometry

        public static string[] Sin(double x, string type = "")
        {
            double num;
            switch (type)
            {
                case "-1":
                    num = Math.Asin(x);
                    break;
                case "hyp":
                    num = Math.Sinh(x);
                    break;
                default:
                    num = Math.Sin(x);
                    break;
            }
            
            var info = "sin";
            return new[] { num.ToString(), info };
        }
        
        public static string[] Cos(double x, string type = "")
        {
            double num;
            switch (type)
            {
                case "-1":
                    num = Math.Acos(x);
                    break;
                case "hyp":
                    num = Math.Cosh(x);
                    break;
                default:
                    num = Math.Cos(x);
                    break;
            }
            var info = "cos";
            return new[] { num.ToString(), info };
        }

        public static string[] Tan(double x, string type = "")
        {
            double num;
            switch (type)
            {
                case "-1":
                    num = Math.Atan(x);
                    break;
                case "hyp":
                    num = Math.Tanh(x);
                    break;
                default:
                    num = Math.Tan(x);
                    break;
            }
            var info = "tan";
            return new[] { num.ToString(), info };
        }

        public static string[] Cot(double x, string type = "")
        {
            double num;
            switch (type)
            {
                case "-1":
                    num = 1 / Math.Atan(x);
                    break;
                case "hyp":
                    num = Math.Cosh(x) / Math.Sinh(x);
                    break;
                default:
                    num = 1 / Math.Tan(x);
                    break;
            }
            var info = "cot";
            return new[] { num.ToString(), info };
        }

        public static string[] Sec(double x, string type = "")
        {
            double num;
            switch (type)
            {
                case "-1":
                    num = 1 / Math.Acos(x);
                    break;
                case "hyp":
                    num = 1 / Math.Cosh(x);
                    break;
                default:
                    num = 1 / Math.Cos(x);
                    break;
            }
            var info = "sec";
            return new[] { num.ToString(), info };
        }

        public static string[] Csc(double x, string type = "")
        {
            double num;
            switch (type)
            {
                case "-1":
                    num = 1 / Math.Asin(x);
                    break;
                case "hyp":
                    num = 1 / Math.Sinh(x);
                    break;
                default:
                    num = 1 / Math.Sin(x);
                    break;
            }
            var info = "csc";
            return new[] { num.ToString(), info };
        }
    }
}
