using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.System
{
    class RPNEval
    {
        //private List<Operator> ops {
        //    get
        //    {
        //        return ops;
        //    }
        //    set
        //    {
        //        opsNames = value.Select(item => item.Name).ToList();
        //        ops = value;
        //    }
        //}
        //private List<string> opsNames;

        
        public RPNEval(Dictionary<string, Operator> opers, Dictionary<string, ReactOperator> reactOpers = null)
        {
            ops = opers;
            reactOps = reactOpers;
            ops.ToList().ForEach(x => allOps.Add(x.Key, x.Value));
            reactOps.ToList().ForEach(x => allOps.Add(x.Key, x.Value));
        }
        Dictionary<string, Operator> ops;
        Dictionary<string, ReactOperator> reactOps;

        Dictionary<string, IPrecendencable> allOps = new Dictionary<string, IPrecendencable>();
        //= new Dictionary<string, Operator>()
        //{
        //    ["+"] = new Operator(1),
        //    ["-"] = new Operator(1),
        //    ["*"] = new Operator(2),
        //    ["/"] = new Operator(2),
        //    ["sin"] = new Operator(3),
        //    ["sqr"] = new Operator(3)
        //};
        private double evalRPN(Stack<string> tks)
        {
            string tk = tks.Pop();
            double x, y;
            if (!Double.TryParse(tk, out x))
            {
                x = evalRPN(tks);
                if (tk != "sin")
                {
                    y = evalRPN(tks);
                    if (tk == "+") x = y + x;
                    else if (tk == "-") x = y - x;
                    else if (tk == "*") x = y * x;
                    else if (tk == "/") x = y / x;
                    else throw new Exception("Unknown operator");
                }
                else
                {
                    if (tk == "sin") x = Math.Sin(x);
                    else throw new Exception("Unknown operator");
                }

            }
            return x;
        }
        public Stack<string> ToRPN(string input)
        {

            var tokens = new Queue<string>(input.Split(' '));
            var output = new Stack<string>();
            var operators = new Stack<string>();

            while (tokens.Count > 0)
            {
                var token = tokens.Dequeue();

                if (allOps.ContainsKey(token))
                {
                    IPrecendencable op = allOps[token];
                    if (op != null && operators.Count > 0)
                    {
                        var lastOp = operators.Peek();
                        if (allOps.ContainsKey(lastOp))
                        {
                            if (op.Precedence <= allOps[lastOp].Precedence)
                            {
                                output.Push(operators.Pop());
                                if (operators.Count > 0)
                                {
                                    if (allOps.ContainsKey(operators.Peek()))
                                    {
                                        output.Push(operators.Pop());
                                    }
                                }
                            }
                        }
                    }
                    operators.Push(token);
                }
                else if (token == "(")
                {
                    operators.Push(token);
                }
                else if (token == ")")
                {
                    while (operators.Peek() != "(")
                    {
                        output.Push(operators.Pop());
                    }
                    if (operators.Peek() == "(")
                        operators.Pop();
                }
                else
                {
                    output.Push(token);
                }
            }

            while (operators.Count > 0)
                output.Push(operators.Pop());

            var reversed = new Stack<string>();

            while (output.Count > 0)
                reversed.Push(output.Pop());

            return reversed;
        }
    }
}