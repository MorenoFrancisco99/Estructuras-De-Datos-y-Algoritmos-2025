using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Practico_6
{
    internal class GrafoSecuencial
    {
        private int[] grafo;


        public GrafoSecuencial(int cantidadDeVertices)
        {
            grafo = new int[cantidadDeVertices * cantidadDeVertices];
            for (int i = 0; i < grafo.Length; i++)
            {
                grafo[i] = 0;
            }
        }

    }
}
