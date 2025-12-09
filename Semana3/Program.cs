using System;

namespace RegistroEstudianteSemana3
{
    // Código desarrollado por Nancy Campos para la Semana 3
    // Este programa registra los datos de un estudiante
    // incluyendo 3 números telefónicos almacenados en un array.

    class Estudiante
    {
        public string ID;
        public string Nombres;
        public string Apellidos;
        public string Direccion;

        // Array para almacenar los tres números de teléfono
        public string[] Telefonos = new string[3];

        public void MostrarInformacion()
        {
            Console.WriteLine("\n===== INFORMACIÓN DEL ESTUDIANTE =====");
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Nombres: {Nombres}");
            Console.WriteLine($"Apellidos: {Apellidos}");
            Console.WriteLine($"Dirección: {Direccion}");

            Console.WriteLine("\nTeléfonos registrados:");

            for (int i = 0; i < Telefonos.Length; i++)
            {
                Console.WriteLine($"Teléfono {i + 1}: {Telefonos[i]}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REGISTRO DE ESTUDIANTE - SEMANA 3 ===");

            // Crear el objeto estudiante
            Estudiante estudiante = new Estudiante();

            // Solicitar datos
            Console.Write("Ingrese el ID: ");
            estudiante.ID = Console.ReadLine();

            Console.Write("Ingrese los nombres: ");
            estudiante.Nombres = Console.ReadLine();

            Console.Write("Ingrese los apellidos: ");
            estudiante.Apellidos = Console.ReadLine();

            Console.Write("Ingrese la dirección: ");
            estudiante.Direccion = Console.ReadLine();

            Console.WriteLine("\nAhora ingrese los 3 números telefónicos:");

            for (int i = 0; i < estudiante.Telefonos.Length; i++)
            {
                Console.Write($"Teléfono {i + 1}: ");
                estudiante.Telefonos[i] = Console.ReadLine();
            }

            // Mostrar resultados
            estudiante.MostrarInformacion();

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
