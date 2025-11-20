namespace ConsoleApp1.Practico_6.TADs
{
    internal class DigrafoEncadenado
    {
        private class Nodo
        {
            public int Vertice;
            public Nodo Siguiente;
            public List<int> entradas = new List<int>();

            public Nodo(int vertice)
            {
                Vertice = vertice; 
                Siguiente = null;
            }
        }
        private Nodo[] listaAdyacencia;
        private int tamaño;
        public DigrafoEncadenado(int numVertices)
        {
            listaAdyacencia = new Nodo[numVertices];
            tamaño = numVertices;
        }

        public int AgregarArista(int origen, int destino)
        {
            if (origen < 0 || origen >= tamaño || destino < 0 || destino >= tamaño)
            {
                throw new ArgumentOutOfRangeException("Los vértices están fuera de rango.");
            }
            Nodo nuevoNodo = new Nodo(destino);
            //La insercion va a ser ordenada por simplicidad en busquedas futuras
            if (listaAdyacencia[origen] == null || listaAdyacencia[origen].Vertice > destino)
            {
                nuevoNodo.Siguiente = listaAdyacencia[origen];
                listaAdyacencia[origen] = nuevoNodo;
            }
            else
            {
                Nodo actual = listaAdyacencia[origen];
                while (actual.Siguiente != null && actual.Siguiente.Vertice < destino)
                {
                    actual = actual.Siguiente;
                }
                if (actual.Vertice == destino)
                {
                    return 0; // La arista ya existe
                }
                nuevoNodo.Siguiente = actual.Siguiente;
                actual.Siguiente = nuevoNodo;
            }
            return 1; // Retorna 1 para indicar éxito
        }

        public int[] GetAdyacentes(int vertice)
        {
            List<int> adyacentes = new List<int>();
            if (vertice < 0 || vertice >= tamaño)
            {
                throw new ArgumentOutOfRangeException("El vértice está fuera de rango.");
            }
            Nodo actual = listaAdyacencia[vertice];
            while (actual != null)
            {
                adyacentes.Add(actual.Vertice);
                actual = actual.Siguiente;
            }
            return adyacentes.ToArray();
        }

        private int GradoEntrada(int vertice)
        {
            int grado = 0;
            for (int i = 0; i < tamaño; i++)
            {
                Nodo actual = listaAdyacencia[i];
                while (actual != null && actual.Vertice < vertice)
                {
                    actual = actual.Siguiente;
                }
                if (actual != null && actual.Vertice == vertice)
                {
                    grado++;
                }
            }
            return grado;
        }

        /// <summary>
        /// Calculates the out-degree of a specified vertex in the graph.
        /// </summary>
        /// <param name="vertice">The index of the vertex whose out-degree is to be calculated.</param>
        /// <returns>The out-degree of the specified vertex, representing the number of edges originating from it.</returns>
        private int GradoSalida(int vertice)
        {
            int grado = 0;
            while (listaAdyacencia[vertice] != null)
            {
                grado++;
                listaAdyacencia[vertice] = listaAdyacencia[vertice].Siguiente;
            }
            return grado;
        }

        public bool EsSumidero(int vertice)
        {
            if(vertice < 0 || vertice >= tamaño)
            {
                throw new ArgumentOutOfRangeException("El vértice está fuera de rango.");
            }
            if(GradoEntrada(vertice) != tamaño - 1 || GradoSalida(vertice) != 0) //Para que un nodo sea sumidero, su grado de entrada debe ser n-1 y su grado de salida 0
            {
                return false;
            }

            return true;
        }


    }
}
