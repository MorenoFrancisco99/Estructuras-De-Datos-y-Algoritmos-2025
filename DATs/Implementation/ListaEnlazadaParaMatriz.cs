using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Practico_3;

namespace ConsoleApp1.DATs.Implementation
{
    internal class ListaEnlazadaParaMatriz 
    {
        
        private int cant;
        Node cabeza;

        public ListaEnlazadaParaMatriz()
        {
            cant = 0;
            cabeza = null;
        }

        public int Buscar(int num)
        {
            throw new NotImplementedException();
        }

        
        public int Eliminar(int index)
        {
            throw new NotImplementedException();
        }

        public bool EstaLlena()
        {
            throw new NotImplementedException();
        }

        public bool EstVacia()
        { 
            if(cant == 0) { return true; };
            return false;
        }

        public int Insertar(int fila, int columna, int num)
        {
            Node newNode = new Node { fila = fila, columna = columna, value = num };
            
            if (EstVacia())
            {
                cabeza = newNode;
                cant++;
                return 1;
            }

            Node actual = cabeza;
            while (actual.sig !=  null && fila < actual.sig.fila  ) //TERMIANR
            {
                actual = actual.sig;
            }

            

            return 1;
        }

        public Node? GetSiguiente(Node nodo)
        {
        
            return nodo.sig;
        }
        public Node? Primer_elemento()
        {
            if (EstVacia())
            {
                Console.WriteLine("La lista esta vacia");
                return null;
            }
            return cabeza;
        }

        public void Recorrer()
        {
            throw new NotImplementedException();
        }

        public int Recuperar(int index)
        {
            if(index < 0 || index >= cant)
            {
                Console.WriteLine("Indice fuera de rango");
                return -1;
            }
            if (!EstVacia())
            {
                Node aux = cabeza;
                int i = 0;
                while(i < index && aux != null)
                {
                    aux = aux.sig;
                    i++;
                }
                return aux.value;
            }
            else
            {
                Console.WriteLine("La lista esta vacia");
                return -1;
            }
        }

        public int Ultimo_elemento(int num)
        {
            throw new NotImplementedException();
        }
    }
}
