using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.DATs.Implementation.ListaEnlazadaParaMatriz;

namespace ConsoleApp1.DATs.Implementation
{
    internal class PilaEnlazada<T> : IStack<T>
    {
        private class Node
        {

            public int data { get; set; }
            public Node sig { get; set; }
        }
        private int cant;
        private Node cab;

        public PilaEnlazada()
        {
            cab = null;
            cant = 0; //A diferencia de la pila secuencial, esta se inicializa en 0 en vez de -1 
        }

        public int Insertar(int x)
        {
            Node nuevoNodo = new Node { data = x, sig = cab };
            cab = nuevoNodo;
            cant++;
            return x;
        }

        public int Suprimir()
        {
            int val;
            if (!IsEmpty())
            {
                val = cab.data;
                cab = cab.sig;
                cant--;
                return val;
            }
            else
            {
                Console.WriteLine("Pila Vacia");
                return -1;
            }
        }

        public bool IsEmpty()
        {
            return cant == 0;
        }

        public void Mostrar()
        {
            if (IsEmpty())
            {
                Console.Write("[Pila Vacía]");
                return;
            }

            Console.Write("[");
            Node actual = cab; // Empezamos en el tope
            while (actual != null)
            {
                Console.Write(actual.data);
                actual = actual.sig; // Avanzamos al siguiente nodo
                if (actual != null)
                {
                    Console.Write(" | ");
                }
            }
            Console.Write("] (Tope)");
        }
        

        public void Insert(T value)
        {
            throw new NotImplementedException();
        }

        public T? Pop()
        {
            throw new NotImplementedException();
        }

        public T? Peek()
        {
            throw new NotImplementedException();
        }

        public int Size()
        {
            throw new NotImplementedException();
        }

        public void Traverse()
        {
            throw new NotImplementedException();
        }

        public T[] GetValues()
        {
            throw new NotImplementedException();
        }

        public void Test()
        {
            throw new NotImplementedException();
        }
    }
}
