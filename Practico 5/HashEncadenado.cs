using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Open.Numeric.Primes.Extensions;
namespace ConsoleApp1.Practico_5
{
    internal class HashEncadenado
    {
        private class Node 
        {
            public int Key;
            public Node Next;
            public Node(int key)
            {
                Key = key;
                Next = null;
            }
        }

        private Node[] tablaHashEncadenamiento; 
        int tamaño;
        int colisionesEsperadas = 3;


        public HashEncadenado(int tamaño)
        {
            tamaño = (int)(tamaño / colisionesEsperadas);
            if (!tamaño.IsPrime())
            {
                tamaño = (int)PrimeExtensions.NextPrime(tamaño);
            }
            this.tamaño = tamaño;

            tablaHashEncadenamiento = Enumerable.Repeat<Node>(null, tamaño).ToArray();
        }

        public int Insertar(int num)
        {
            int hashIndex = num % tamaño; //Metodo de la division
            Node newNode = new Node(num);
            if (tablaHashEncadenamiento[hashIndex] == null)
            {
                tablaHashEncadenamiento[hashIndex] = newNode;
            }
            else
            {
                Node current = tablaHashEncadenamiento[hashIndex];
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            return hashIndex;
        }

        private int Buscar(int num)
        {
            int hashIndex = num % tamaño;
            Node current = tablaHashEncadenamiento[hashIndex];
            while (current != null)
            {
                if (current.Key == num)
                {
                    return hashIndex; // Devuelve el índice del bucket donde se encuentra la clave
                }
                current = current.Next;
            }
            return -1; // No encontrado
        }



    }
}
