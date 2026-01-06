using System;
using System.Collections.Generic;

class Ejercicio1_Loteria
{
    public void Ejecutar()
    {
        List<int> numeros = new List<int>();

        Console.WriteLine("Ingrese 6 números ganadores:");

        for (int i = 0; i < 6; i++)
        {
            Console.Write($"Número {i + 1}: ");
            numeros.Add(int.Parse(Console.ReadLine()));
        }

        numeros.Sort();

        Console.WriteLine("\nNúmeros ordenados:");
        foreach (int n in numeros)
        {
            Console.Write(n + " ");
        }
    }
}
