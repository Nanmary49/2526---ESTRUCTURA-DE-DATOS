using System;
using System.Collections.Generic;

namespace ParentesisBalanceados
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Verificación de paréntesis balanceados\n");
            Console.Write("Ingrese una expresión matemática: ");
            string expresion = Console.ReadLine();

            if (EstaBalanceada(expresion))
            {
                Console.WriteLine("Fórmula balanceada.");
            }
            else
            {
                Console.WriteLine("Fórmula NO balanceada.");
            }

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }

        static bool EstaBalanceada(string expr)
        {
            Stack<char> pila = new Stack<char>();

            foreach (char c in expr)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    pila.Push(c);
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (pila.Count == 0)
                        return false;

                    char ultimo = pila.Pop();
                    if (!Corresponde(ultimo, c))
                        return false;
                }
            }

            return pila.Count == 0;
        }

        static bool Corresponde(char abierto, char cerrado)
        {
            return (abierto == '(' && cerrado == ')') ||
                   (abierto == '{' && cerrado == '}') ||
                   (abierto == '[' && cerrado == ']');
        }
    }
}
