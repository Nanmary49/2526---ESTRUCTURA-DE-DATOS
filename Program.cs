// ==========================================================
// Traductor Básico Inglés - Español
// Autora: Nancy CAMPOS
// Proyecto académico - Diccionarios en C#
// ==========================================================

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // ==============================
        // Diccionario principal
        // ==============================
        // La clave será la palabra en inglés
        // El valor será la palabra en español

        Dictionary<string, string> diccionario = new Dictionary<string, string>()
        {
            {"day", "día"},        // palabra del ejemplo
            {"eye", "ojo"},        // palabra del ejemplo
            {"world", "mundo"},    // palabra base conservada
            {"life", "vida"},
            {"love", "amor"},
            {"family", "familia"},
            {"home", "hogar"},
            {"food", "comida"},
            {"water", "agua"},
            {"friend", "amigo"}
        };

        int opcion;

        // ==============================
        // Menú interactivo
        // ==============================

        do
        {
            Console.WriteLine("\n=======================================");
            Console.WriteLine("   TRADUCTOR BÁSICO - Nancy CAMPOS");
            Console.WriteLine("=======================================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    TraducirFrase(diccionario);
                    break;

                case 2:
                    AgregarPalabra(diccionario);
                    break;

                case 0:
                    Console.WriteLine("Gracias por usar el programa, Nancy 😊");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

        } while (opcion != 0);
    }

    // ==========================================================
    // MÉTODO PARA TRADUCIR FRASES
    // ==========================================================
    static void TraducirFrase(Dictionary<string, string> diccionario)
    {
        Console.Write("\nIngrese la frase a traducir: ");
        string frase = Console.ReadLine().ToLower();

        // Separamos la frase en palabras
        string[] palabras = frase.Split(' ');

        string traduccion = "";

        foreach (string palabra in palabras)
        {
            // Quitamos signos básicos de puntuación
            string palabraLimpia = palabra.Replace(".", "")
                                          .Replace(",", "")
                                          .Replace(";", "")
                                          .Replace(":", "");

            // Si la palabra existe en el diccionario → traducimos
            if (diccionario.ContainsKey(palabraLimpia))
            {
                traduccion += diccionario[palabraLimpia] + " ";
            }
            else
            {
                // Si no existe → dejamos la palabra original
                traduccion += palabra + " ";
            }
        }

        Console.WriteLine("\nTraducción parcial:");
        Console.WriteLine(traduccion);
    }

    // ==========================================================
    // MÉTODO PARA AGREGAR NUEVAS PALABRAS
    // ==========================================================
    static void AgregarPalabra(Dictionary<string, string> diccionario)
    {
        Console.Write("\nIngrese la palabra en inglés: ");
        string ingles = Console.ReadLine().ToLower();

        Console.Write("Ingrese la traducción en español: ");
        string espanol = Console.ReadLine().ToLower();

        if (!diccionario.ContainsKey(ingles))
        {
            diccionario.Add(ingles, espanol);
            Console.WriteLine("Palabra agregada correctamente ✔");
        }
        else
        {
            Console.WriteLine("Esa palabra ya existe en el diccionario.");
        }
    }
}