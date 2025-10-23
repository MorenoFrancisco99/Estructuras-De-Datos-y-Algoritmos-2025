using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.DATs.Implementation.ListaEnlazadaParaMatriz;

namespace ConsoleApp1.DATs.Implementation
{
    internal class ColaEncadenada<T> : ICola<T>
    {
        private class Nodo
        {

            public int data { get; set; }
            public Nodo sig { get; set; }
        }
        private int cant;
        private Nodo primero;
        private Nodo ultimo;

        public ColaEncadenada()
        {
            cant = 0;
            primero = null;
            ultimo = null;
        }

        public int Insertar(int x)
        {
            Nodo nuevoNodo = new Nodo { data = x, sig = null };
            if (IsEmpty())
            {
                primero = nuevoNodo;
            }
            else
            {
                ultimo.sig = nuevoNodo;
            }
            ultimo = nuevoNodo;
            cant++;
            return x;
        }

        public int Suprimir()
        {
            int x;
            if (!IsEmpty())
            {
                x = primero.data;
                primero = primero.sig;
                cant--;
                if (primero == null)
                {
                    ultimo = null;
                }

                return x;
            }
            else
            {
                Console.WriteLine("Cola Vacia");
                return 0;
            }
        }

        public bool IsEmpty()
        {
            return cant == 0;
        }

        public void Recorrer()
        {
            Nodo aux = primero;
            while (aux != null)
            {
                Console.WriteLine(aux.data);
                aux = aux.sig;
            }
        }

        public int Insertar(T elemento)
        {
            throw new NotImplementedException();
        }

        public T? Pop()
        {
            throw new NotImplementedException();
        }

        public bool IsFull()
        {
            throw new NotImplementedException();
        }

        public bool isEmpty()
        {
            throw new NotImplementedException();
        }

        public T Peek()
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            throw new NotImplementedException();
        }

        public void Test(IEnumerable<T> values)
        {
            throw new NotImplementedException();
        }
    }
}