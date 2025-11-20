using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Practico_6
{
    internal class GrafoSecuencial
    {
        private int[,] grafo;
        private int tamaño;

        public GrafoSecuencial(int cantidadDeVertices)
        {
            grafo = new int[cantidadDeVertices, cantidadDeVertices];
            this.tamaño = cantidadDeVertices;
        }

        /// <summary>
        /// Agrega una arista dirigida desde el vértice 'origen' al vértice 'destino'.
        /// </summary>
        /// <param name="origen"></param>
        /// <param name="destino"></param>
        public void AgregarArista(int origen, int destino)
        {
            if(origen < 0 || origen >= tamaño || destino < 0 || destino >= tamaño)
            {
                throw new ArgumentOutOfRangeException("Los índices de los vértices están fuera de los límites del grafo.");
            }
            if(grafo[origen, destino] == 1)
            {
                throw new InvalidOperationException($"La arista {origen},{destino} ya existe en el grafo.");
            }
            grafo[origen, destino] = 1;
            grafo[destino, origen] = 1;
            
        }

        public void EliminarArista(int origen, int destino)
        {
            if (origen < 0 || origen >= tamaño || destino < 0 || destino >= tamaño)
            {
                throw new ArgumentOutOfRangeException("Los índices de los vértices están fuera de los límites del grafo.");
            }
            if (grafo[origen, destino] == 0)
            {
                throw new InvalidOperationException("La arista no existe en el grafo.");
            }
            grafo[origen, destino] = 0;
        }

        /// <summary>
        /// Busca y devuelve un arreglo con los vértices adyacentes al vértice dado.
        /// </summary>
        /// <param name="vertice"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public int[] Adyacentes(int vertice)
        {
            if (vertice < 0 || vertice >= tamaño)
            {
                throw new ArgumentOutOfRangeException("El índice del vértice está fuera de los límites del grafo.");
            }
            List<int> adyacentes = new List<int>();
            for (int i = 0; i < tamaño; i++)
            {
                if (grafo[vertice, i] == 1)
                {
                    adyacentes.Add(i);
                }
            }
            return adyacentes.ToArray();
        }


        public List<int> Camino(int origen, int destino)
        {
            int[] dist = new int[tamaño];
            int[] predecesor = new int[tamaño];
            for (int i = 0; i < tamaño; i++)
            {
                dist[i] = int.MaxValue;
                predecesor[i] = -1;
            }

            Queue<int> cola = new Queue<int>();
            cola.Enqueue(origen);
            dist[origen] = 0;

            while (cola.Count > 0)
            {
                int v = cola.Dequeue();
                foreach (int u in Adyacentes(v))
                {
                    if (dist[u] == int.MaxValue)
                    {
                        dist[u] = dist[v] + 1;
                        predecesor[u] = v;
                        cola.Enqueue(u);
                        if (u == destino)
                            break;
                    }
                }
            }

            // reconstruir el camino
            List<int> camino = new List<int>();
            if (predecesor[destino] == -1 && origen != destino)
                return camino; // no hay camino

            for (int actual = destino; actual != -1; actual = predecesor[actual])
                camino.Add(actual);

            camino.Reverse();
            return camino;
        }


        /// <summary>
        /// Busqueda en amplitud desde un vértice origen, devolviendo las distancias mínimas a cada vértice alcanzable.
        /// </summary>
        /// <param name="origen">Vertice a partir del que se realizara la busqueda</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public int BEA(int origen)
        {
            if(origen < 0 || origen >= tamaño)
            {
                throw new ArgumentOutOfRangeException("El índice del vértice está fuera de los límites del grafo.");
            }

            int[] dist = new int[tamaño]; // arreglo de distancias del origen a cada vértice
            for (int i = 0; i < tamaño; i++)
            {   
                dist[i] = int.MaxValue; // inicializar distancias como infinito
            }
            dist[origen] = 0; // la distancia del origen a sí mismo es 0

            Queue<int> cola = new Queue<int>();
            cola.Enqueue(origen); // agregar el vértice origen a la cola


            while (cola.Count > 0)
            {
                int v = cola.Dequeue(); // obtener el siguiente vértice de la cola

                int[] adyacentes = Adyacentes(v); // obtener los vértices adyacentes a v

                foreach (int u in adyacentes) //para cada adyacente
                {
                    if (dist[u] == int.MaxValue) // si no ha sido visitado. Esto permite evitar ciclos y que se obtengan las distancias mínimas
                    {
                        dist[u] = dist[v] + 1; // actualizar la distancia. La distancia al adyacente es la distancia al vértice actual + 1
                        cola.Enqueue(u); // agregar a la cola para explorar sus adyacentes
                    }  
                }
            }

            for(int i = 0; i < tamaño; i++)
            {
                
                Console.WriteLine($"Distancia desde el nodo {origen} hasta el nodo {i}: {dist[i]}");
            }


            return 1;
        }

        /// <summary>
        /// Iniciar una busqueda en profundidad desde todos los nodos del grafo
        /// </summary>
        /// <returns></returns>
        public int BEPGeneral()
        {
            int[] dist = new int[tamaño];
            for(int u = 0; u < tamaño; u++)
            { dist[u] = 0; }

            int tiempo = 0; 
            foreach(int s in dist)
            {
                if(dist[s] == 0)
                {
                    BEPVisita(s, ref dist, ref tiempo);
                }
            }
            

            return 1;
        }

        public int BEP(int origen)
        {
            int[] dist = new int[tamaño]; //Arreglo de distancias
            for (int i = 0; i < tamaño; i++)
            { dist[i] = 0; } //Iniciaizamos como 0
            int tiempo = 0; //Para marcar el momento de llegada
            BEPVisita(origen, ref dist, ref tiempo);
            return 1;
        }


        private int BEPVisita(int s, ref int[] dist, ref int tiempo)
        {
            tiempo++;
            dist[s] = tiempo;
            int[] adyacentes = Adyacentes(s);
            foreach (int u in adyacentes)
            {
                if (dist[u] == 0)
                    BEPVisita(u, ref dist, ref tiempo);
            }


            return 1;
        }

  

      
    }
}
