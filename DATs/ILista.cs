using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DATs
{
    internal interface ILista
    {
        public int Insertar (int index, int num);
        public int Eliminar (int index);
        public int Recuperar(int index);
        public int Buscar(int num);
        public int Primer_elemento(int num);
        public int Ultimo_elemento(int num);
        public void Recorrer();
        public bool EstVacia();

        public bool EstaLlena();
        public void Test();

    }
}
