using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraConsola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calculadora = new Calculadora();

            while (true)
            {
                MostrarMenu();

                int opcion = LeerOpcionMenu();

                if (opcion == 5)
                {
                    Console.WriteLine("Saliendo de la calculadora...");
                    break;
                }

                double num1 = LeerNumero("Ingresa el primer numero: ");
                double num2 = LeerNumero("Ingrese el segundo numero:");

                try
                {
                    double resultado = 0;
                    switch (opcion)
                    {
                        case 1:
                            resultado = calculadora.Sumar(num1, num2);
                            break;
                        case 2:
                            resultado = calculadora.Restar(num1, num2);
                            break;
                        case 3:
                            resultado = calculadora.Multiplicar(num1, num2);
                            break;
                        case 4:
                            resultado = calculadora.Dividir(num1, num2);
                            break;

                    }
                    Console.WriteLine($"\n>>> Resultado: {resultado}\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error : {ex.Message}\n");
                }


                Console.WriteLine("Presione Cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }


            private static void MostrarMenu()
            {
                Console.WriteLine("Elija una opcion: ");
                Console.WriteLine("1. SUMA");
                Console.WriteLine("2. RESTA");
                Console.WriteLine("3. MULTIPLICACION");
                Console.WriteLine("4. DIVISION");
                Console.WriteLine("5. SALIR");
            }

            private static int LeerOpcionMenu()
            {
                int opcion;
                while (true)
                {
                    Console.WriteLine("Opcion (1-5): ");
                    string entrada = Console.ReadLine();
                    if (int.TryParse(entrada, out opcion) && opcion >= 1 && opcion <= 5)
                        return opcion;
                    Console.WriteLine("Opcion invalida. Intente de nuevo");
                }
            }

            private static double LeerNumero(string mensaje)
            {
                double numero;
                while (true)
                {
                    Console.Write(mensaje);
                    if (double.TryParse(Console.ReadLine(), out numero))
                        return numero;
                    Console.WriteLine("Entrada invalida. Intente de nuevo");
                }
            }
  

        }



    }

