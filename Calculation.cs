using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary
{
    public class Calculation
    {
        protected double num1 = 0;
        protected double num2 = 0;
        public double Result { get; protected set; } = 0;
        protected string op = "";

        public Calculation(double num1, double num2, double result, string op)
        {
            this.num1 = num1;
            this.num2 = num2;
            this.Result = result;
            this.op = PrettifyOperator(op);
        }

        public override string ToString()
        {
            return $"{num1} {op} {num2} = {Result}\n";
        }

        private static string PrettifyOperator(string op)
        {
            switch (op)
            {
                case "a":
                    op = "+";
                    break;
                case "s":
                    op = "-";
                    break;
                case "m":
                    op = "*";
                    break;
                case "d":
                    op = "/";
                    break;
                case "p":
                    op = "^";
                    break;
                default:
                    break;
            }
            return op;
        }
    }
}
