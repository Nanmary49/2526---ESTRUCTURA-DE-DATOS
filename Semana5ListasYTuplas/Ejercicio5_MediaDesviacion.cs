using System;
using System.Collections.Generic;
using System.Linq;

class Ejercicio5_MediaDesviacion
{
    public void Ejecutar()
    {
        Console.Write("Ingrese números separados por comas: ");
        string entrada = Console.ReadLine();

        List<double> numeros = entrada
            .Split(',')
            .Select(n => double.Parse(n.Trim()))
            .ToList();

        double media = numeros.Average();

        double suma = 0;
        foreach (double n in numeros)
        {
            suma += Math.Pow(n - media, 2);
        }

        double desviacion = Math.Sqrt(suma / numeros.Count);

        Console.WriteLine($"Media: {media}");
        Console.WriteLine($"Desviación típica: {desviacion}");
    }
}
