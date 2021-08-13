using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.System
{
    class ScientificReactOps: ReactOps
    {
        public string[] Abs(double x)
        {
            var num = Math.Abs(x).ToString();
            var info = "abs";
            return new[] { num, info };
        }

        public string[] Factorial(double x)
        {
            double fact(double n)
            {
                if (n <= 1)
                    return 1;
                return n * fact(n - 1);
            }

            var num = fact(x).ToString();
            var info = "fact";
            return new[] { num, info };
        }

        public string[] Pi()
        {
            var num = Math.PI.ToString();
            var info = "";
            return new[] { num, info };
        }

        public string[] E()
        {
            var num = Math.E.ToString();
            var info = "";
            return new[] { num, info };
        }

        public string[] TenX(double x)
        {
            var num = Math.Pow(10, x).ToString();
            var info = "10^";
            return new[] { num, info };
        }

        public string[] TwoX(double x)
        {
            var num = Math.Pow(2, x).ToString();
            var info = "2^";
            return new[] { num, info };
        }

        public string[] EX(double x)
        {
            var num = Math.Pow(Math.E, x).ToString();
            var info = "e^";
            return new[] { num, info };
        }

        public string[] Log(double x)
        {
            var num = Math.Log10(x).ToString();
            var info = "log";
            return new[] { num, info };
        }

        public string[] Ln(double x)
        {
            var num = Math.Log(x).ToString();
            var info = "ln";
            return new[] { num, info };
        }

        public string[] Cube(double x)
        {
            var num = Math.Pow(x, 3).ToString();
            var info = "cube";
            return new[] { num, info };
        }

        public string[] CubeRoot(double x)
        {
            var num = Math.Pow(x, 1 / 3).ToString();
            var info = "cuberoot";
            return new[] { num, info };
        }

        public string[] Floor(double x)
        {
            var num = Math.Floor(x).ToString();
            
            var info = "floor";
            return new[] { num, info };
        }

        public string[] Ceil(double x)
        {
            var num = Math.Ceiling(x).ToString();

            var info = "ceil";
            return new[] { num, info };
        }

        public string[] Random()
        {
            var num = new Random().NextDouble().ToString();

            var info = "rand";
            return new[] { num, info };
        }

        //Trigonometry

        public string[] Sin(double x, string type = "")
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
        
        public string[] Cos(double x, string type = "")
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

        public string[] Tan(double x, string type = "")
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

        public string[] Cot(double x, string type = "")
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

        public string[] Sec(double x, string type = "")
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

        public string[] Csc(double x, string type = "")
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
