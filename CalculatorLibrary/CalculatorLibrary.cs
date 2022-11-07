using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;

namespace CalculatorLibrary
{
    public class CalculatorProgram
    {
        JsonWriter writer;
        private int _calUsageCount = 0;
        List<double> calResults = new List<double>();

        public CalculatorProgram()
        {
            StreamWriter logFile = File.CreateText("calculatorlog.json");
            logFile.AutoFlush = true;
            writer = new JsonTextWriter(logFile);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Operations");
            writer.WriteStartArray();
        }

        public double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // Default value is "not-a-number" if an operation, such as division, could result in an error.
            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(num1);
            writer.WritePropertyName("Operand2");
            writer.WriteValue(num2);
            writer.WritePropertyName("Operation");
            // Use a switch statement to do the math.
            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    calResults.Add(result);
                    writer.WriteValue("Add");
                    break;
                case "s":
                    result = num1 - num2;
                    calResults.Add(result);
                    writer.WriteValue("Subtract");
                    break;
                case "m":
                    result = num1 * num2;
                    calResults.Add(result);
                    writer.WriteValue("Multiply");
                    break;
                case "d":
                    // Ask the user to enter a non-zero divisor.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        calResults.Add(result);
                        writer.WriteValue("Divide");
                    }
                    break;
                // Return text for an incorrect option entry.
                default:
                    break;
            }
            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();

            // increment the Calculator usage, used with the Cal_Usage Method.
            _calUsageCount++;
            return result;
        }
        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }
        public int Cal_Usage()
        {
            return _calUsageCount;
        }
        public void EndHistory()
        {
            Console.WriteLine("\n<---- History ---->\n");
            PrintList();
            Console.WriteLine("\n<----------------->\n");
        }
        public void ClearHistory()
        {
            calResults.Clear();
        }
        public void PrintList()
        {
            int i = 1;
            foreach (double calResult in calResults)
            {                
                Console.WriteLine(i + ". " + calResult);
                i++;
            }
        }
    }

}