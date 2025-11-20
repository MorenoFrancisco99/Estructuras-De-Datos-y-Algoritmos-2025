using ConsoleApp1.DATs.Implementation;
using ConsoleApp1.Practico_6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DATs
{
    internal class DAT_s // Note: Class name changed from 'DATs' to 'DAT_s' to avoid conflict with namespace name
    {
        public ILista listaEnlazada;
        public IListaOrdenada listaOrdenadaEncadenada;
        public IStack<int> pilaSecuencial;
        public IStack<int> pilaEnlazada;
        public ICola<int> colaSecuencial;
        public ICola<int> colaEncadenada;
        public ArbolBinariodeBusqueda arbolBinarioDeBusqueda;
        public GrafoSecuencial grafoSecuencial;

        public DAT_s()
        {
            pilaSecuencial = new PilaSecuencial(32);
            pilaEnlazada = new PilaEnlazada<int>();
            listaEnlazada = new ListaEnlazada();
            listaOrdenadaEncadenada = new ListaOrdenadaEncadenada(32);
            colaSecuencial = new ColaSecuencial<int>(32);
            colaEncadenada = new ColaEncadenada<int>();
            arbolBinarioDeBusqueda = new ArbolBinariodeBusqueda();
            grafoSecuencial = new GrafoSecuencial(32);
        }

    }
}
