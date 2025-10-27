using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Practico_5
{
    internal class HashBucket
    {
        private int[,] tablaHashBuckets; //Tabla hash con buckets

        private int tamaño;
        private int bucketSize;

        string PATH = "C:\\Users\\FRANCISCO\\Documentos\\proj\\LCC Ej\\ConsoleApp1\\Practico 5\\overflow.txt";

        public HashBucket(int tamaño = 199, int bucketSize = 10)
        {
            if (IsPrime(tamaño) == 0)
            {
                Console.WriteLine($"El tamaño {tamaño} no es primo. Se utilizará el siguiente número primo.");
                tamaño = NextPrime(tamaño);
            }
            tablaHashBuckets = new int[tamaño, bucketSize];
            for (int i = 0; i < tamaño; i++)
            {
                for (int j = 0; j < bucketSize; j++)
                {
                    tablaHashBuckets[i, j] = -1; // -1 indica que la posicion esta vacia
                }
            }
            this.tamaño = tamaño;
            this.bucketSize = bucketSize;
        }


        public int Insertar(int num)
        {
            int hashIndex = num % tamaño; //Metodo de la division
            for (int j = 0; j < bucketSize; j++)
            {
                if (tablaHashBuckets[hashIndex, j] == -1)
                {
                    tablaHashBuckets[hashIndex, j] = num; //Encontró espacio en el bucket
                    return hashIndex;
                }
            }
            Console.WriteLine($"Bucket lleno en el índice {hashIndex} para el número {num}. Insertando en espacio de overflow");

            InsertarOverflow(num, hashIndex);
            return -1; // Indica que el bucket está lleno
        }


        private int InsertarOverflow(int num, int hashIndex)
        {
            string[] content = System.IO.File.ReadAllLines(PATH);
            

            return 0;
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
