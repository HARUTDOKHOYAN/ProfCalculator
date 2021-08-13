using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.System
{
    class RPNEval
    {
        public RPNEval(Dictionary<string, Operator> opers, Dictionary<string, ReactOperator> reactOpers = null)
        {
            ops = opers;
            reactOps = reactOpers;
            ops.ToList().ForEach(x => allOps.Add(x.Key, x.Value));
            if(reactOps != null) reactOps.ToList().ForEach(x => allOps.Add(x.Key, x.Value));
        }
        Dictionary<string, Operator> ops;
        Dictionary<string, ReactOperator> reactOps;

        Dictionary<string, IPrecendencable> allOps = new Dictionary<string, IPrecendencable>();

        public string Eval(string expression)
        {
            var rpnExpression = ToRPN(expression);
            var result = evalRPN(new Stack<string>(rpnExpression.Split(' '))).ToString();
            return result;
        }

        private string evalRPN(Stack<string> tks)
        {
            string tk = tks.Pop();
            string x, y;
            x = tk;
            if (reactOps != null && reactOps.ContainsKey(tk))
            {
                x = evalRPN(tks);
                x = reactOps[tk].Function.Invoke(x);
            }
            else if(ops.ContainsKey(tk))
            {
                x = evalRPN(tks);
                y = evalRPN(tks);
                x = ops[tk].Function.Invoke(y.ToString(), x.ToString());
            }
            return x;
        }
        public string ToRPN(string input)
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

            return string.Join(" ", reversed);
        }
    }
}