using System;
using System.Collections.Generic;

class Ejercicio4_ProductoEscalar
{
    public void Ejecutar()
    {
        List<int> vector1 = new List<int> { 1, 2, 3 };
        List<int> vector2 = new List<int> { -1, 0, 2 };

        int productoEscalar = 0;

        for (int i = 0; i < vector1.Count; i++)
        {
            productoEscalar += vector1[i] * vector2[i];
        }

        Console.WriteLine("Producto escalar: " + productoEscalar);
    }
}
