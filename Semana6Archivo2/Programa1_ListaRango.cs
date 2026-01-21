using System;

namespace ListaEnlazadaRango
{
    // Clase Nodo: representa cada elemento de la lista
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

        // Eliminar nodos fuera del rango
        public void EliminarFueraDeRango(int min, int max)
        {
            // Primero limpiamos la cabeza si está fuera del rango
            while (cabeza != null && (cabeza.Dato < min || cabeza.Dato > max))
            {
                cabeza = cabeza.Siguiente;
            }

            Nodo actual = cabeza;

            while (actual != null && actual.Siguiente != null)
            {
                if (actual.Siguiente.Dato < min || actual.Siguiente.Dato > max)
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                }
                else
                {
                    actual = actual.Siguiente;
                }
            }
        }

        // Mostrar la lista
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
            Console.WriteLine("Lista enlazada con eliminación por rango\n");

            ListaEnlazada lista = new ListaEnlazada();
            Random rnd = new Random();

            // Generar 50 números aleatorios
            for (int i = 0; i < 50; i++)
            {
                lista.InsertarFinal(rnd.Next(1, 1000));
            }

            Console.WriteLine("Lista original:");
            lista.Mostrar();

            // Pedir rango al usuario
            Console.Write("\nIngrese el valor mínimo: ");
            int min = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el valor máximo: ");
            int max = int.Parse(Console.ReadLine());

            // Eliminar valores fuera del rango
            lista.EliminarFueraDeRango(min, max);

            Console.WriteLine("\nLista después de eliminar valores fuera del rango:");
            lista.Mostrar();

            Console.ReadKey();
        }
    }
}
