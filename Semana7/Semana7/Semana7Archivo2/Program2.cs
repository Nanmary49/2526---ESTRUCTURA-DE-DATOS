using System;

/*
 Programa 2:
 Manejo de dos listas enlazadas:
 - Lista 1: números primos (insertados al final)
 - Lista 2: números Armstrong (insertados al inicio)
 Autor: Nancy Campos
*/

namespace PrimosYArmstrong
{
    // Representa un nodo de la lista enlazada
    class Nodo
    {
        public int Dato;
        public Nodo? Siguiente;

        public Nodo(int dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }

    // Implementación de la lista enlazada
    class ListaEnlazada
    {
        private Nodo? cabeza;
        private int contador;

        public ListaEnlazada()
        {
            cabeza = null;
            contador = 0;
        }

        // Inserta un elemento al final de la lista (primos)
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
            contador++;
        }

        // Inserta un elemento al inicio de la lista (Armstrong)
        public void InsertarInicio(int dato)
        {
            Nodo nuevo = new Nodo(dato);
            nuevo.Siguiente = cabeza;
            cabeza = nuevo;
            contador++;
        }

        // Devuelve cuántos elementos tiene la lista
        public int Contar()
        {
            return contador;
        }

        // Muestra todos los elementos de la lista
        public void Mostrar()
        {
            Nodo? actual = cabeza;
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
        // Determina si un número es primo
        static bool EsPrimo(int num)
        {
            if (num <= 1) return false;

            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }

        // Determina si un número es Armstrong
        static bool EsArmstrong(int num)
        {
            int original = num;
            int suma = 0;
            int digitos = num.ToString().Length;

            while (num > 0)
            {
                int d = num % 10;
                suma += (int)Math.Pow(d, digitos);
                num /= 10;
            }
            return suma == original;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Programa desarrollado por: Nancy Campos\n");

            ListaEnlazada listaPrimos = new ListaEnlazada();
            ListaEnlazada listaArmstrong = new ListaEnlazada();

            Console.Write("Ingrese cuántos números desea evaluar: ");
            int n = int.Parse(Console.ReadLine()!);

            for (int i = 1; i <= n; i++)
            {
                Console.Write($"Ingrese el número {i}: ");
                int valor = int.Parse(Console.ReadLine()!);

                if (EsPrimo(valor))
                    listaPrimos.InsertarFinal(valor);

                if (EsArmstrong(valor))
                    listaArmstrong.InsertarInicio(valor);
            }

            Console.WriteLine("\nLista de números primos:");
            listaPrimos.Mostrar();

            Console.WriteLine("\nLista de números Armstrong:");
            listaArmstrong.Mostrar();

            Console.WriteLine("\nCantidad de elementos en la lista de primos: " + listaPrimos.Contar());
            Console.WriteLine("Cantidad de elementos en la lista de Armstrong: " + listaArmstrong.Contar());

            if (listaPrimos.Contar() > listaArmstrong.Contar())
                Console.WriteLine("La lista con más elementos es la de PRIMOS.");
            else if (listaArmstrong.Contar() > listaPrimos.Contar())
                Console.WriteLine("La lista con más elementos es la de ARMSTRONG.");
            else
                Console.WriteLine("Ambas listas tienen la misma cantidad de elementos.");

            Console.ReadKey();
        }
    }
}
