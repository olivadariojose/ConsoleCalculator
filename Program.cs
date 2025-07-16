using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            bool keepRunning;

            do
            {
                ShowMenu();
                int option = ReadMenuOption();

                if (option == 5)
                {
                    Console.WriteLine("Saliendo ...");
                    break;
                }

                double num1 = ReadNumber("Ingresa el primer numero: ");
                double num2 = ReadNumber("Ingresa el segundo numero: ");

                try
                {
                    double result;
                    switch (option)
                    {
                        case 1:
                            result = calculator.Add(num1, num2);
                            break;
                        case 2:
                            result = calculator.Substract(num1, num2);
                            break;
                        case 3:
                            result = calculator.Multiply(num1, num2);
                            break;
                        case 4:
                            result = calculator.Divide(num1, num2);
                            break;
                        default:
                            throw new InvalidOperationException("Opcion no valida");
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n >>> RESULTADO : {result} \n");
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error : {ex.Message}\n");
                }
                finally
                {
                    Console.ResetColor();
                }

                keepRunning = AskToContinue();
                if (keepRunning) Console.Clear();

            } while (keepRunning);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Programa finalizado correctamente");
            Console.ReadKey();
        }

        private static bool AskToContinue()
        {
            string response;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Desea realizar otra operacion? SI/NO: ");

                response = (Console.ReadLine() ?? "").Trim().ToUpperInvariant();
                if (response == "SI") return true;
                if (response == "NO") return false;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Respuesta invalida. Escriba SI o NO");
            }
        }

        private static void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Elija una opcion: ");
            Console.WriteLine("1. SUMA");
            Console.WriteLine("2. RESTA");
            Console.WriteLine("3. MULTIPLICACION");
            Console.WriteLine("4. DIVISION");
            Console.WriteLine("5. SALIR");
            Console.WriteLine("\n");
        }

        private static int ReadMenuOption()
        {
            int option;
            while (true)
            {
                Console.WriteLine("Opcion (1-5): ");
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out option) && option >= 1 && option <= 5)
                    return option;
                Console.WriteLine("Opcion invalida. Intente de nuevo");
            }
        }

        private static double ReadNumber(string message)
        {
            double number;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out number))
                    return number;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Entrada invalida. Intente de nuevo");
            }
        }



    }



}

