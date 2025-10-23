using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DATs.Implementation
{
    internal class ListaOrdenadaEncadenada : IListaOrdenada
    {
        private class Node
        {
            internal int? data;
            internal Node? sig;
        }
        private Node? cabeza;
        private int cant;
        private int tamaño;

        public ListaOrdenadaEncadenada(int xtamaño)
        {
            cant = 0;
            tamaño = xtamaño;
        }

        public int Insertar(int numero)
        {
            Node newNode = new Node{ data = numero, sig = null};

            if (EstaLlena())
            {
                Console.WriteLine("La lista esta llena");
                return -1;
            }

            if (EstaVacia())
            {
                cabeza = newNode;
                cant++;
                return 1;
            }

            if(numero < cabeza.data)
            {
                newNode.sig = cabeza;
                cabeza = newNode;
                cant++;
                return 1;
            }

            //Se compara el numero con el siguiente del nodo actuaL 
            //Si se estuviera comparado si es mayor al actual, siempre daria verdadero despues del primero elemento, terminando con una lista desordenada
            //Si se estuvera comparando si es menor al actual y da verdadero, se deberia insertar antes del actual, pero no tenemos referencia del anterior
            Node actual = cabeza;
            while(actual.sig != null && numero >= actual.sig.data) 
            {
                actual = actual.sig;
            }

            newNode.sig = actual.sig;
            actual.sig = newNode;
            cant++;

            return 1;
        }

        public bool EstaVacia()
        {
            if (cant == 0)
            {
                return true;
            }
            return false;
        }

        public bool EstaLlena()
        {
            if (cant == tamaño)
            {
                return true;
            }
            return false;
        }

        public void Recorrer()
        {
            Node xprimero = cabeza;
            for (int i = 0; i < cant; i++)
            {
                Console.Write($" {xprimero.data},");
                xprimero = xprimero.sig;

            }
            Console.Write("\n");
        }

        public int Eliminar(int numero)
        {
            if (EstaVacia())
            {
                Console.WriteLine("La lista esta vacia");
                return -1;
            }
            if (cabeza.data == numero)
            {
                cabeza = cabeza.sig;
                cant--;
                return 1;
            }

            Node actual = cabeza;
            while(actual.sig != null && actual.sig.data != numero)
            {
                actual = actual.sig;
            }

            if (actual.sig == null)
            {
                Console.WriteLine("El numero no se encuentra en la lista");
                return -1;
            }
            else
            {
                actual.sig = actual.sig.sig;
                cant--;
            }
                return 1;
        }

       

        public int Buscar(int numero)
        {
            int cont = 1;
            if (EstaVacia()) //Se podria obviar y dejar que el while no se cumpla. Se repite en eliminar. Pero queda mas claro
            {
               Console.WriteLine("La lista esta vacia");
                return -1;  
            }
            else
            {
                Node actual = cabeza;
                while(actual != null && actual.data != numero)
                {
                    actual = actual.sig;
                    cont++;
                }
                if (actual == null)
                {
                    Console.WriteLine("El numero no se encuentra en la lista");
                    return -1;
                }
                else
                {
                    Console.WriteLine($"El numero se encuentra en la posicion {cont}");
                    return cont;
                }
            }
        }

        public int Recuperar(int posicion)
        {
            if (EstaVacia())
            {
                Console.WriteLine("La lista esta vacia");
                return -1;
            }
            if (posicion < 1 || posicion > cant)
            {
                Console.WriteLine("Posicion invalida");
                return -1;
            }
            Node actual = cabeza;
            for (int i = 1; i < posicion; i++)
            {
                actual = actual.sig;
            }

            Console.WriteLine($"El numero en la posicion {posicion} es {actual.data}");
            return actual.data.Value;
        }

        public int GetPrimerElemento()
        {
            if (EstaVacia())
            {
                Console.WriteLine("La lista esta vacia");
                return -1;
            }
            Console.WriteLine($"El primer elemento es {cabeza.data}");
            return cabeza.data.Value;
        }

        public int GetUltimoElemento()
        {
            if (EstaVacia())
            {
                Console.WriteLine("La lista esta vacia");
                return -1;
            }
            Node actual = cabeza;
            while(actual.sig != null)
            {
                actual = actual.sig;
            }
            Console.WriteLine($"El ultimo elemento es {actual.data}");
            return actual.data.Value;
        }

        public int GetSiguente(int pos)
        {
            if(EstaVacia())
            {
                Console.WriteLine("La lista esta vacia");
                return -1;
            }
            if(pos < 1 || pos >= cant)
            {
                Console.WriteLine("Posicion invalida");
                return -1;
            }
            Node actual = cabeza;
            for(int i = 1; i < pos; i++)
            {
                actual = actual.sig;
            }
            Console.WriteLine($"El siguiente elemento a la posicion {pos} es {actual.sig.data}");
            return actual.sig.data.Value;

        }

        public int GetAnterior(int pos)
        {
            if (EstaVacia())
            {
                Console.WriteLine("La lista esta vacia");
                return -1;
            }
            if (pos <= 1 || pos > cant)
            {
                Console.WriteLine("Posicion invalida");
                return -1;
            }
            Node actual = cabeza;
            for (int i = 1; i < pos - 1; i++)
            {
                actual = actual.sig;
            }
            Console.WriteLine($"El elemento anterior a la posicion {pos} es {actual.data}");
            return actual.data.Value;
        }
        public int Test()
        {
            Insertar(5);
            Insertar(3);
            Insertar(8);
            Insertar(1);
            Insertar(4);
            Insertar(7);
            Insertar(2);
            Insertar(6);
            Recorrer();

            Eliminar(5);
            Eliminar(8);
            Eliminar(10);
            Recorrer();
            
            Buscar(4);
            Recuperar(3);
            GetSiguente(2);
            GetAnterior(4);
            GetPrimerElemento();
            GetUltimoElemento();
            return 1;


        }

  
       
    }
}
