using System;
using System.Collections.Generic;

namespace TorresHanoi
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Resolución Torres de Hanoi con pilas\n");
            Console.Write("Ingrese el número de discos: ");
            int n = int.Parse(Console.ReadLine());

            Stack<int> torreA = new Stack<int>();
            Stack<int> torreB = new Stack<int>();
            Stack<int> torreC = new Stack<int>();

            for (int i = n; i >= 1; i--)
            {
                torreA.Push(i);
            }

            MostrarTorres(torreA, torreB, torreC, "Estado inicial");
            Hanoi(n, torreA, torreC, torreB, "A", "C", "B");
            Console.WriteLine("\n¡Resolución completa!");
            Console.ReadKey();
        }

        static void Hanoi(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar, string nomOrigen, string nomDestino, string nomAux)
        {
            if (n == 1)
            {
                int disco = origen.Pop();
                destino.Push(disco);
                Console.WriteLine($"Mover disco {disco} de {nomOrigen} a {nomDestino}");
                MostrarTorres(origen, auxiliar, destino, "");
                return;
            }

            Hanoi(n - 1, origen, auxiliar, destino, nomOrigen, nomAux, nomDestino);
            Hanoi(1, origen, destino, auxiliar, nomOrigen, nomDestino, nomAux);
            Hanoi(n - 1, auxiliar, destino, origen, nomAux, nomDestino, nomOrigen);
        }

        static void MostrarTorres(Stack<int> A, Stack<int> B, Stack<int> C, string mensaje)
        {
            Console.WriteLine($"\n{mensaje}");
            Console.WriteLine($"A: {string.Join(",", A)}");
            Console.WriteLine($"B: {string.Join(",", B)}");
            Console.WriteLine($"C: {string.Join(",", C)}\n");
        }
    }
}
