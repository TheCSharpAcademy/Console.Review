using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary
{
    public class TrigCalculation : Calculation
    {
        public TrigCalculation(double num1, double num2, double result, string op) : base(num1, num2, result, op)
        {
            this.num1 = num1;
            this.num2 = num2;
            this.Result = result;
            this.operatorSymbol = op;
        }

        public override string ToString()
        {
            return $"{operatorSymbol}({num1}) = {Result}\n";
        }
    }
}
