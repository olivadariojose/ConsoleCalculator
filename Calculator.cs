using System;

namespace ConsoleCalculator
{
    internal class Calculator
    {
        public double Add(double x, double y) => x + y;
        public double Substract(double x, double y) => x - y;
        public double Multiply(double x, double y) => x * y;
        public double Divide(double x, double y)
        {
            if(y == 0)
                throw new DivideByZeroException("No se puede dividir entre cero.");
            return x / y;
        }
    }
}
