using System;

namespace ListaEnlazadaBusqueda
{
    // Clase Nodo
    class Nodo
    {
        public int Dato;
        public Nodo Siguiente;

        public Nodo(int dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }

    // Clase Lista Enlazada
    class ListaEnlazada
    {
        private Nodo cabeza;

        // Insertar al final de la lista
        public void InsertarFinal(int dato)
        {
            Nodo nuevo = new Nodo(dato);
            if (cabeza == null)
            {
                cabeza = nuevo;
            }
            else
            {
                Nodo actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevo;
            }
        }

        // Método de búsqueda: cuenta cuántas veces aparece un dato
        public void Buscar(int valor)
        {
            Nodo actual = cabeza;
            int contador = 0;

            while (actual != null)
            {
                if (actual.Dato == valor)
                {
                    contador++;
                }
                actual = actual.Siguiente;
            }

            if (contador > 0)
            {
                Console.WriteLine($"\nEl valor {valor} se encontró {contador} veces en la lista.");
            }
            else
            {
                Console.WriteLine($"\nEl valor {valor} no fue encontrado en la lista.");
            }
        }

        // Mostrar lista
        public void Mostrar()
        {
            Nodo actual = cabeza;
            while (actual != null)
            {
                Console.Write(actual.Dato + " -> ");
                actual = actual.Siguiente;
            }
            Console.WriteLine("null");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Programa desarrollado por: Nancy Campos");
            Console.WriteLine("Lista enlazada con búsqueda de un valor\n");

            ListaEnlazada lista = new ListaEnlazada();
            Random rnd = new Random();

            // Generar 50 números aleatorios entre 1 y 100
            for (int i = 0; i < 50; i++)
            {
                lista.InsertarFinal(rnd.Next(1, 101));
            }

            Console.WriteLine("Lista generada:");
            lista.Mostrar();

            // Pedir valor a buscar
            Console.Write("\nIngrese el valor a buscar: ");
            int valor = int.Parse(Console.ReadLine());

            // Buscar el valor en la lista
            lista.Buscar(valor);

            Console.ReadKey();
        }
    }
}
