using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DATs
{
    internal interface IListaOrdenada
    {
        int Insertar(int numero);
        bool EstaLlena();
        bool EstaVacia();
        void Recorrer();
        int Eliminar(int numero);
        int Buscar(int numero);
        int Recuperar(int posicion);
        int GetPrimerElemento();
        int GetUltimoElemento();
        int GetSiguente(int pos);
        int GetAnterior(int pos);
        int Test();

    }
}
