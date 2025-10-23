namespace ConsoleApp1.DATs.Implementation
{
    internal class ListaEnlazada : ILista
    {
        private class Nodo
        {

            public int data { get; set; }
            public Nodo sig { get; set; }
        }
        int cant;
        Nodo cabeza;

        public ListaEnlazada()
        {
            cabeza = null;
            cant = 0;
        }

        public int Insertar(int valor) //Se inserta al final
        {
            Nodo nuevoNodo = new Nodo { data = valor, sig = null };
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
            }
            else
            {
                Nodo aux = cabeza;
                while (aux.sig != null)
                {
                    aux = aux.sig;
                }
                aux.sig = nuevoNodo;

            }
            cant++;
            return valor;
        }

        public int InsertarEnPosicion(int valor, int posicion)
        {
            Nodo nuevoNodo = new Nodo { data = valor, sig = null };
            if (posicion < 0 || posicion > cant)
            {
                Console.WriteLine("Posicion Invalida");
                return 0;
            }
            if (posicion == 0) // Hay que chckear porque si la poscicion fuera 0 y entrara al while quedaria i < -1
            {
                nuevoNodo.sig = cabeza;
                cabeza = nuevoNodo;
            }
            else
            {
                int i = 0;
                Nodo aux = cabeza;
                while (i < posicion - 1)
                {
                    aux = aux.sig;
                    i++;
                }
                nuevoNodo.sig = aux.sig;
                aux.sig = nuevoNodo;
            }

            cant++;
            return valor;
        }

        public int Suprimir(int posicion)
        {
            if (posicion < 0 || posicion >= cant)
            {
                Console.WriteLine("Posicion Invalida");
                return 0;
            }
            int valor;
            if (posicion == 0)
            {
                valor = cabeza.data;
                cabeza = cabeza.sig;
            }
            else
            {
                int i = 0;
                Nodo aux = cabeza;
                while (i < posicion - 1)
                {
                    i++;
                    aux = aux.sig;
                }

                valor = aux.sig.data;
                aux.sig = aux.sig.sig;
            }
            cant--;
            return valor;
        }

        public int Buscar(int valor)
        {
            int i = 0;
            if (IsEmpty())
            {
                Console.WriteLine("Lista vacia");
                return -1;
            }

            Nodo aux = cabeza;
            while (aux != null && aux.data != valor)
            {
                i++;
                aux = aux.sig;
            }

            if (i < cant)
            {
                return i;
            }
            else
            {
                Console.WriteLine("Valor no existe en la lista");
            }
            return -1;
        }

        public void Mostrar()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Lista vacía.");
                return;
            }

            Nodo aux = cabeza;
            int i = 0;
            Console.Write("Contenido de la lista (" + cant + " elementos): ");
            while (aux != null)
            {
                Console.Write($"[{i}:{aux.data}] ");
                aux = aux.sig;
                i++;
            }
            Console.WriteLine();
        }



        public bool IsEmpty()
        {
            return cant == 0;
        }

        public int Insertar(int index, int num)
        {
            throw new NotImplementedException();
        }

        public int Eliminar(int index)
        {
            throw new NotImplementedException();
        }

        public int Recuperar(int index)
        {
            throw new NotImplementedException();
        }

        public int Primer_elemento(int num)
        {
            throw new NotImplementedException();
        }

        public int Ultimo_elemento(int num)
        {
            throw new NotImplementedException();
        }

        public void Recorrer()
        {
            throw new NotImplementedException();
        }

        public bool EstVacia()
        {
            throw new NotImplementedException();
        }

        public bool EstaLlena()
        {
            throw new NotImplementedException();
        }

        public void Test()
        {
            throw new NotImplementedException();
        }
    }
}
