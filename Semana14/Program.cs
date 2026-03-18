using System;

namespace ArbolBinarioBusquedaApp
{
    // Clase Nodo: representa cada elemento del árbol
    public class Nodo
    {
        public int Valor;          // Valor que almacena el nodo
        public Nodo Izquierdo;     // Referencia al hijo izquierdo
        public Nodo Derecho;       // Referencia al hijo derecho

        // Constructor del nodo
        public Nodo(int valor)
        {
            Valor = valor;
            Izquierdo = null;
            Derecho = null;
        }
    }

    // Clase Árbol Binario de Búsqueda (BST)
    public class ArbolBinarioBusqueda
    {
        private Nodo raiz; // Nodo raíz del árbol

        public ArbolBinarioBusqueda()
        {
            raiz = null;
        }

        // ================= INSERTAR =================
        public void Insertar(int valor)
        {
            raiz = InsertarRecursivo(raiz, valor);
        }

        private Nodo InsertarRecursivo(Nodo nodo, int valor)
        {
            // Si el árbol está vacío, se crea un nuevo nodo
            if (nodo == null)
                return new Nodo(valor);

            // Si el valor es menor, va al subárbol izquierdo
            if (valor < nodo.Valor)
                nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, valor);

            // Si el valor es mayor, va al subárbol derecho
            else if (valor > nodo.Valor)
                nodo.Derecho = InsertarRecursivo(nodo.Derecho, valor);

            // No se permiten valores duplicados
            return nodo;
        }

        // ================= BUSCAR =================
        public bool Buscar(int valor)
        {
            return BuscarRecursivo(raiz, valor);
        }

        private bool BuscarRecursivo(Nodo nodo, int valor)
        {
            // Si no se encuentra el nodo
            if (nodo == null)
                return false;

            // Si encontramos el valor
            if (valor == nodo.Valor)
                return true;

            // Buscar en el subárbol correspondiente
            if (valor < nodo.Valor)
                return BuscarRecursivo(nodo.Izquierdo, valor);
            else
                return BuscarRecursivo(nodo.Derecho, valor);
        }

        // ================= ELIMINAR =================
        public void Eliminar(int valor)
        {
            raiz = EliminarRecursivo(raiz, valor);
        }

        private Nodo EliminarRecursivo(Nodo nodo, int valor)
        {
            if (nodo == null) return null;

            if (valor < nodo.Valor)
                nodo.Izquierdo = EliminarRecursivo(nodo.Izquierdo, valor);

            else if (valor > nodo.Valor)
                nodo.Derecho = EliminarRecursivo(nodo.Derecho, valor);

            else
            {
                // Caso 1: Nodo sin hijos
                if (nodo.Izquierdo == null && nodo.Derecho == null)
                    return null;

                // Caso 2: Nodo con un solo hijo
                if (nodo.Izquierdo == null)
                    return nodo.Derecho;

                if (nodo.Derecho == null)
                    return nodo.Izquierdo;

                // Caso 3: Nodo con dos hijos
                // Se reemplaza con el menor valor del subárbol derecho
                Nodo sucesor = EncontrarMin(nodo.Derecho);
                nodo.Valor = sucesor.Valor;
                nodo.Derecho = EliminarRecursivo(nodo.Derecho, sucesor.Valor);
            }

            return nodo;
        }

        // ================= RECORRIDOS =================

        // Preorden: Raíz → Izquierda → Derecha
        public void Preorden()
        {
            Console.Write("Preorden: ");
            PreordenRec(raiz);
            Console.WriteLine();
        }

        private void PreordenRec(Nodo nodo)
        {
            if (nodo != null)
            {
                Console.Write(nodo.Valor + " "); // Primero la raíz
                PreordenRec(nodo.Izquierdo);     // Luego izquierda
                PreordenRec(nodo.Derecho);       // Luego derecha
            }
        }

        // Inorden: Izquierda → Raíz → Derecha
        public void Inorden()
        {
            Console.Write("Inorden: ");
            InordenRec(raiz);
            Console.WriteLine();
        }

        private void InordenRec(Nodo nodo)
        {
            if (nodo != null)
            {
                InordenRec(nodo.Izquierdo);      // Primero izquierda
                Console.Write(nodo.Valor + " "); // Luego raíz
                InordenRec(nodo.Derecho);        // Finalmente derecha
            }
        }

        // Postorden: Izquierda → Derecha → Raíz
        public void Postorden()
        {
            Console.Write("Postorden: ");
            PostordenRec(raiz);
            Console.WriteLine();
        }

        private void PostordenRec(Nodo nodo)
        {
            if (nodo != null)
            {
                PostordenRec(nodo.Izquierdo);    // Izquierda
                PostordenRec(nodo.Derecho);      // Derecha
                Console.Write(nodo.Valor + " "); // Raíz al final
            }
        }

        // ================= MIN, MAX =================
        public int Minimo()
        {
            Nodo actual = raiz;
            while (actual.Izquierdo != null)
                actual = actual.Izquierdo;

            return actual.Valor;
        }

        public int Maximo()
        {
            Nodo actual = raiz;
            while (actual.Derecho != null)
                actual = actual.Derecho;

            return actual.Valor;
        }

        private Nodo EncontrarMin(Nodo nodo)
        {
            while (nodo.Izquierdo != null)
                nodo = nodo.Izquierdo;

            return nodo;
        }

        // ================= ALTURA =================
        public int Altura()
        {
            return AlturaRec(raiz);
        }

        private int AlturaRec(Nodo nodo)
        {
            if (nodo == null)
                return -1; // Árbol vacío

            int alturaIzq = AlturaRec(nodo.Izquierdo);
            int alturaDer = AlturaRec(nodo.Derecho);

            // Se retorna la mayor altura + 1
            return Math.Max(alturaIzq, alturaDer) + 1;
        }

        // ================= LIMPIAR =================
        public void Limpiar()
        {
            raiz = null;
        }

        public bool EstaVacio()
        {
            return raiz == null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ArbolBinarioBusqueda arbol = new ArbolBinarioBusqueda();
            int opcion, valor;

            do
            {
                Console.WriteLine("\n===== MENÚ ÁRBOL BINARIO =====");
                Console.WriteLine("1. Insertar");
                Console.WriteLine("2. Buscar");
                Console.WriteLine("3. Eliminar");
                Console.WriteLine("4. Mostrar recorridos");
                Console.WriteLine("5. Mostrar mínimo, máximo y altura");
                Console.WriteLine("6. Limpiar árbol");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese valor: ");
                        valor = int.Parse(Console.ReadLine());
                        arbol.Insertar(valor);
                        Console.WriteLine("Valor insertado.");
                        break;

                    case 2:
                        Console.Write("Ingrese valor a buscar: ");
                        valor = int.Parse(Console.ReadLine());
                        Console.WriteLine(arbol.Buscar(valor) ? "Encontrado" : "No encontrado");
                        break;

                    case 3:
                        Console.Write("Ingrese valor a eliminar: ");
                        valor = int.Parse(Console.ReadLine());
                        arbol.Eliminar(valor);
                        Console.WriteLine("Valor eliminado.");
                        break;

                    case 4:
                        arbol.Preorden();
                        arbol.Inorden();
                        arbol.Postorden();
                        break;

                    case 5:
                        if (!arbol.EstaVacio())
                        {
                            Console.WriteLine("Mínimo: " + arbol.Minimo());
                            Console.WriteLine("Máximo: " + arbol.Maximo());
                            Console.WriteLine("Altura: " + arbol.Altura());
                        }
                        else
                            Console.WriteLine("El árbol está vacío.");
                        break;

                    case 6:
                        arbol.Limpiar();
                        Console.WriteLine("Árbol limpiado.");
                        break;
                }

            } while (opcion != 0);
        }
    }
}