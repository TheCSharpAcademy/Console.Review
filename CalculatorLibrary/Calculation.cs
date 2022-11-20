namespace CalculatorLibrary;

public class Calculation
{
    protected double num1 = 0;
    protected double num2 = 0;
    public double Result { get; protected set; } = 0;
    protected string operatorSymbol = "";

    public Calculation(double num1, double num2, double result, string op)
    {
        this.num1 = num1;
        this.num2 = num2;
        Result = result;
        this.operatorSymbol = PrettifyOperator(op);
    }

    public override string ToString()
    {
        return $"{num1} {operatorSymbol} {num2} = {Result}\n";
    }

    private static string PrettifyOperator(string operationSymbol)
    {
        switch (operationSymbol)
        {
            case "a":
                operationSymbol = "+";
                break;
            case "s":
                operationSymbol = "-";
                break;
            case "m":
                operationSymbol = "*";
                break;
            case "d":
                operationSymbol = "/";
                break;
            case "p":
                operationSymbol = "^";
                break;
            default:
                break;
        }
        return operationSymbol;
    }
}
