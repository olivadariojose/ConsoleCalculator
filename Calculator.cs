using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        public double Add(double x, double y) => Checked(()=> x + y);
        public double Substract(double x, double y) => Checked(() => x - y);
        public double Multiply(double x, double y) => Checked(() => x * y);
        public double Divide(double x, double y)
        {
            if(y == 0d || y == -0d)
                throw new DivideByZeroException("No se puede dividir entre cero.");

            return Checked(()=> x / y);
        }

        private static double Checked(Func<double> op)
        {
            double result;
            try
            {
                result = op();
            }
            catch (OverflowException)
            {
                throw;
            }

            if (double.IsNaN(result) || double.IsInfinity(result))
                throw new OverflowException("Resultado fuera del rango por tipo double");

            return result;
        }
    }
}
