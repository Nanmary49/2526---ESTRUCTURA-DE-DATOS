using System;
using System.Collections.Generic;

class Ejercicio2_Abecedario
{
    public void Ejecutar()
    {
        List<char> letras = new List<char>();

        for (char c = 'A'; c <= 'Z'; c++)
        {
            letras.Add(c);
        }

        for (int i = letras.Count; i >= 1; i--)
        {
            if (i % 3 == 0)
            {
                letras.RemoveAt(i - 1);
            }
        }

        Console.WriteLine("Resultado:");
        foreach (char letra in letras)
        {
            Console.Write(letra + " ");
        }
    }
}
