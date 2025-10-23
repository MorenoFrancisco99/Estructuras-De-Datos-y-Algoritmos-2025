namespace ConsoleApp1.DATs.Implementation
{

    internal class ListaSecuencial : ILista
    {
        private int[] arr;
        private int tamaño;
        private int cant;

        public ListaSecuencial(int tamaño)
        {
            cant = 0; //apunta al primer lugar vacio
            this.tamaño = tamaño;
            arr = new int[tamaño];
        }

        public int Insertar(int valor) // inserta al final
        {
            if (!IsFull())
            {
                arr[cant] = valor;
                cant++;
                return valor;
            }
            else
            {
                Console.WriteLine("Lista Llena");
                return 0;
            }
        }

        public int InsertarPorPosicion(int valor, int posicion)
        {
            if (posicion < 0 || posicion > cant)
            {
                Console.WriteLine("Posicion Invalida");
                return 0;
            }
            if (IsFull())
            {
                Console.WriteLine("Lista Llena");
                return 0;
            }

            if (posicion == cant)
            {
                arr[posicion] = valor;
            }
            else
            {
                for (int i = cant; i > posicion; i--)
                {
                    arr[i] = arr[i - 1];
                }

                arr[posicion] = valor;
            }

            cant++;
            return valor;
        }

        public int Suprimir(int posicion)
        {
            int valor;

            if (posicion < 0 || posicion >= cant) //La posicion puede ser igual a la cantidad. En ese caso se elimina el ultimo
            {
                Console.WriteLine("Posicion Invalida");
                return 0;
            }
            valor = arr[posicion];
            for (int i = posicion; i < cant - 1; i++) //cant-1 ya que cant apunta a un lugar vacio. si no se dejara el - 1 arr[i+1] apuntaria directamente a cant y seria invalido
            {
                arr[i] = arr[i + 1];
            }
            cant--;

            return valor;
        }

        public int Recuperar(int posicion)
        {
            int valor;
            if (posicion < 0 || posicion >= cant) //La posicion puede ser igual a la cantidad. En ese caso se elimina el ultimo
            {
                Console.WriteLine("Posicion Invalida");
                return 0;
            }
            valor = arr[posicion];
            return valor;
        }

        public int Buscar(int valor)
        {
            int i = 0;
            while (i < cant && arr[i] != valor)
            {
                i++;
            }
            if (i < cant)
            {
                return i;
            }
            else
            {
                Console.WriteLine("El valor no existe en la lista");
            }
            return 0;
        }

        public bool IsFull()
        {
            return cant == tamaño;
        }

        public bool IsEmpty()
        {
            return cant == 0;
        }

        public void Recorrer()
        {
            if (IsEmpty())
            {
                Console.Write("[Lista Vacía]");
                return;
            }
            Console.Write("[");
            for (int i = 0; i < cant; i++)
            {
                Console.Write(arr[i]);
                if (i < cant - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine($"] (cant: {cant})");
        }

        public int Insertar(int index, int num)
        {
            throw new NotImplementedException();
        }

        public int Eliminar(int index)
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
