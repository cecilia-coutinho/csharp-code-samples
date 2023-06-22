using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCalculator
{
    internal class Calculator
    {
        private double Operand1 { get; set; }
        private double Operand2 { get; set; }
        private char Operation { get; set; }

        public Calculator(double operand1, double operand2, char operation)
        {
            Operand1 = operand1;
            Operand2 = operand2;
            Operation = operation;

            try
            {
                double result = PerformOperation();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Result: {result}");
                Console.ResetColor();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Call the appropriate method to perform the operation
        private double PerformOperation()
        {
            switch (Operation)
            {
                case '+':
                    return Addition();
                case '-':
                    return Subtraction();
                case '*':
                    return Multiplication();
                case '/':
                    return Divide();
                default:
                    string errorMessage = "Invalid operation.";
                    throw new InvalidOperationException(errorMessage);
            }
        }

        //Create a method for each basic arithmetic operation
        private double Addition()
        {
            return Operand1 + Operand2;
        }

        private double Subtraction()
        {
            return Operand1 - Operand2;
        }

        private double Multiplication()
        {
            return Operand1 * Operand2;
        }

        private double Divide()
        {
            return Operand1 / Operand2;
        }
    }
}
