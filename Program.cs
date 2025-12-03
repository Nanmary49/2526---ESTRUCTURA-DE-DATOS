using System;
using FigurasGeometricas;

namespace ProyectoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear un círculo con radio 5
            Circulo miCirculo = new Circulo(5);
            Console.WriteLine("Círculo:");
            Console.WriteLine("Área: " + miCirculo.CalcularArea());
            Console.WriteLine("Perímetro: " + miCirculo.CalcularPerimetro());

            Console.WriteLine();

            // Crear un cuadrado con lado 4
            Cuadrado miCuadrado = new Cuadrado(4);
            Console.WriteLine("Cuadrado:");
            Console.WriteLine("Área: " + miCuadrado.CalcularArea());
            Console.WriteLine("Perímetro: " + miCuadrado.CalcularPerimetro());

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
