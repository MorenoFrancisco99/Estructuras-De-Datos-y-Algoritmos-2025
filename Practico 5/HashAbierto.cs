using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;





/*
 
CONSULTAS
- Como se implementa cuadrado medio
- Porque prueba lineal tiene que ser decendente
- Se usa variable de tamaño o length del array?
- El tema de las claves dadas en los parciales anteriores
- Si siempre tiene que ser primo el tamaño de la tabla hash,
 
 */




namespace ConsoleApp1.DATs.Implementation
{
    /// <summary>
    /// Clase destinada a proveer funcionalidades de hashing.
    /// Contiene todos las tecnicas de manejo de hashing y colisiones vistos en teoria
    /// </summary>
    internal class HashAbierto
    {
      
        private int[] tablaHash; //Tabla hash estandar
        private int tamaño;
        /// <summary>
        /// Por defecto inicializa las tablas hash con un tamaño primo de 199. Al ingresar otro tamaño, se cacula el primo siguiente mas cercano
        /// </summary>
        /// <param name="tamaño">Tamaño del arreglo hash. Conviene que sea un numero primo. Por defencto es 199</param>
        /// 
        public HashAbierto(int tamaño = 199)
        {
            if (IsPrime(tamaño) == 0)
            {
                Console.WriteLine($"El tamaño {tamaño} no es primo. Se utilizará el siguiente número primo.");
                tamaño = NextPrime(tamaño);
            }

            tablaHash = new int[tamaño];
            for (int i = 0; i < tamaño; i++)
            {
                tablaHash[i] = -1; // -1 indica que la posicion esta vacia
            }
            this.tamaño = tamaño;
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
        
        public string Simular()
        {
            return "Hashing Simulado";
        }


        public int Insertar(int num)
        {
            if (num <= 1) throw new ArgumentException("Invalid Number");

            int indice = HashDivision(num);
            if(tablaHash[indice] == -1)
            {
                tablaHash[indice] = num;
                return indice;
            }
            else
            {
                int newIndex = BusquedaLineal(indice, num);
                if(newIndex == -1)
                {
                    throw new InvalidOperationException("Tabla Hash llena");
                }
                tablaHash[newIndex] = num;
                return newIndex;
            }


            return 1;
        }




        //Hashing funcs
        
        /// <summary>
        /// Obitniene el indice en la tabla hash utilizando el metodo de la division
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int HashDivision(int key)
        {
            return key % tamaño;
        }
  

        /// <summary>
        /// Obtiene el indice tomando los ultimos digitos del valor y utilizando el modulo
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="key"></param>
        /// <returns></returns>
        private int HashExtraccion(int key)
        {
            int divisor = (int)Math.Pow(10, tamaño.ToString().Length); //Permite realziar el hashing en tablas de varios tamaños extrayendo la cantidad de digitos necesaria (1, 10, 100, 1000...)
            return (key % divisor) % tamaño;
        }

        /// <summary>
        /// Subdivide la clave y adiciona las partes
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int Plegado(int key)
        {
            int resultado = 0;
            foreach(int num in key.ToString())
            {
                resultado += num;
            }
            return resultado;
        }

        private int CuadradoMedio(int key)
        {
            //key = (int) Math.Pow(key, 2);
            throw new NotImplementedException();
            //return 1;
        }


        private int AlfanumericoSimple(string key)
        {
            int resultado = 0;
            foreach(char c in key)
            {
                resultado += (int) c;
            }
            return resultado % tamaño;
        }


        private int AlfanumericoPorPosicion(string key)
        {
            int resultado = 0;
            int i = 1;
            foreach (char c in key)
            {
                resultado = (int) c * (int) Math.Pow(10,i);
                i++;
            }
            return resultado;
        }


        // Colision func
        /// <summary>
        /// Busca la primera posicion libre o el elemento de forma circular acendente a partir de indice indicado
        /// </summary>
        /// <param name="startingIndex"></param>
        /// <returns>El indice de la primera posicion libre  o del mismo elemento si esta repetido. Si no hay posiciones libres, retorna -1</returns>
        private int BusquedaLineal(int startingIndex, int key)//CONSULTA
        {
            int currentIndex = startingIndex + 1;

            while (tablaHash[currentIndex] != -1 && tablaHash[currentIndex] != key)
            {
                if(currentIndex == startingIndex)
                    return -1;
                currentIndex = (currentIndex + 1) % this.tamaño;
            }
            return currentIndex;
        }



    }
}
