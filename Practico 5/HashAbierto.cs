using Open.Numeric.Primes.Extensions;




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




        public HashAbierto(int cantClaves)
        {
            cantClaves = (int)(cantClaves / 0.7);
            if (!cantClaves.IsPrime())
            {
                cantClaves = (int)PrimeExtensions.NextPrime(cantClaves);
            }
            tablaHash = new int[cantClaves];
            this.tamaño = cantClaves;

            Random rand = new Random();



        }




        public string Simular()
        {
            return "Hashing Simulado";
        }


        public int Insertar(int num)
        {
            if (num <= 1) throw new ArgumentException("Invalid Number");

            int indice = HashDivision(num);
            if (tablaHash[indice] == -1)
            {
                tablaHash[indice] = num;
                return indice;
            }
            else
            {
                int newIndex = BusquedaLineal(indice, num);
                if (newIndex == -1)
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
            foreach (int num in key.ToString())
            {
                resultado += num;
            }
            return resultado;
        }

        private int CuadradoMedio(int key)
        {
            long sq = key * key;
            string sqString = sq.ToString();
            int cantidadDigitos = tamaño.ToString().Length;

            if (sqString.Length < cantidadDigitos)
            {
                sqString = sqString.PadLeft(cantidadDigitos, '0');
            }

            int inicio = (sqString.Length - cantidadDigitos) / 2;
            string medio = sqString.Substring(inicio, cantidadDigitos);

            return int.Parse(medio) % tamaño;
        }


        private int AlfanumericoSimple(string key)
        {
            int resultado = 0;
            foreach (char c in key)
            {
                resultado += (int)c;
            }
            return resultado % tamaño;
        }


        private int AlfanumericoPorPosicion(string key)
        {
            int resultado = 0;
            int i = 1;
            foreach (char c in key)
            {
                resultado = (int)c * (int)Math.Pow(10, i);
                i++;
            }
            return resultado;
        }


        // <----------------------------------MANEJO DE COLISIONES---------------------------------->   
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
                if (currentIndex == startingIndex)
                    return -1;
                currentIndex = (currentIndex + 1) % this.tamaño;
            }
            return currentIndex;
        }




        //<---------------------------------EXTRAS------------------------------------>

 
    }
}
