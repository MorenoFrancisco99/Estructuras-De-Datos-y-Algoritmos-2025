using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Open.Collections;
using Open.Numeric.Primes.Extensions;

namespace ConsoleApp1.Practico_5
{
    internal class HashBucket
    {
        private int[,] tablaHash; //Tabla hash con buckets
        private int[] tablaContadora;
        private int tamaño;
        private int bucketSize = 3; //Tamaño fijo de los buckets


        public HashBucket(int cantClaves)
        {
            tamaño = (int)(cantClaves / bucketSize);
            if (!tamaño.IsPrime())
            {
                tamaño = (int)PrimeExtensions.NextPrime(tamaño);
            }

            tablaHash = new int[(int)(tamaño * 1.2), bucketSize];
            tablaContadora = Enumerable.Repeat(-1, tamaño).ToArray(); //Inicializo la tabla contadora en 0
        }


        public int Insertar(int num)
        {
            int indice = num % tamaño;
            if (tablaContadora[indice] + 1< bucketSize)
            {
                tablaContadora[indice]++;
                tablaHash[indice, tablaContadora[indice]] = num;
            }
            else//Si el bucket esta lleno, insertar en overflow
            {
                int indiceOverflow = tamaño, indiceBucket = 0; //Empiezo a buscar en la zona de overflow
                while (indiceOverflow < tablaHash.GetLength(0)) //Mientras no me salga de la tabla
                {
                    if (tablaHash[indiceOverflow, indiceBucket] == 0) //Si encuentro un lugar libre en overflow
                    {
                        tablaHash[indiceOverflow, indiceBucket] = num;
                        break;
                    }
                    indiceBucket++; //Sigo buscando en el bucket
                    if (indiceBucket == bucketSize) //Si termine el bucket, paso al siguiente
                    {
                        indiceOverflow++;
                        indiceBucket = 0;
                    }
                }
            }
            return 1;

        }

        /* ALTERNATIVA DE OVERFLOW LINEAL
         
         for (int i = tamaño; i < tablaHash.GetLength(0); i++)
    {
        for (int j = 0; j < bucketSize; j++)
        {
            if (tablaHash[i, j] == -1)
            {
                tablaHash[i, j] = num;
                return 0; // OK
            }
        }
    }
         */


        public int Busqueda(int num)
        {
            int indice = num % tamaño;
            for (int i = 0; i < tablaContadora[indice]; i++)
            {
                if (tablaHash[indice, i] == num)
                {
                    return 1; //Encontrado
                }
            }
            //Si no lo encontre en el bucket, busco en overflow
            int indiceOverflow = tamaño + 1, indiceBucket = 0;
            while (indiceOverflow < tablaHash.GetLength(0))
            {
                if (tablaHash[indiceOverflow, indiceBucket] == num)
                {
                    return tablaHash[indiceOverflow,indiceBucket]; //Encontrado
                }
                indiceBucket++;
                if (indiceBucket == bucketSize)
                {
                    indiceOverflow++;
                    indiceBucket = 0;
                }
            }
            return -1; //No encontrado
        }




    }
}
