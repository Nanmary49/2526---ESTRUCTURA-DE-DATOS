using System;
using System.Collections.Generic;

class Ejercicio3_ContarVocales
{
    public void Ejecutar()
    {
        Console.Write("Ingrese una palabra: ");
        string palabra = Console.ReadLine().ToLower();

        Dictionary<char, int> vocales = new Dictionary<char, int>()
        {
            {'a', 0},
            {'e', 0},
            {'i', 0},
            {'o', 0},
            {'u', 0}
        };

        foreach (char letra in palabra)
        {
            if (vocales.ContainsKey(letra))
            {
                vocales[letra]++;
            }
        }

        Console.WriteLine("\nCantidad de vocales:");
        foreach (var v in vocales)
        {
            Console.WriteLine($"{v.Key}: {v.Value}");
        }
    }
}
