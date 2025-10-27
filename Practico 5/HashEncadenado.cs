using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public HashEncadenado(int tamaño = 199)
        {
            if (IsPrime(tamaño) == 0)
            {
                Console.WriteLine($"El tamaño {tamaño} no es primo. Se utilizará el siguiente número primo.");
                tamaño = NextPrime(tamaño);
            }
            tablaHashEncadenamiento = new Node[tamaño];
            for (int i = 0; i < tamaño; i++)
            {
                tablaHashEncadenamiento[i] = null; // null indica que la posicion esta vacia
            }
            this.tamaño = tamaño;
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




        private int IsPrime(int num)
        {
            if (num <= 1) return 0;
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0) return 0;
            }
            return 1;
        }

        private int NextPrime(int num)
        {
            int next = num + 1;
            while (IsPrime(next) == 0)
            {
                next++;
            }
            return next;
        }
    }
}
