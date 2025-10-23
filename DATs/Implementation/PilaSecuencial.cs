namespace ConsoleApp1.DATs.Implementation
{
    internal class PilaSecuencial : IStack<int>
    {

        private int[] arr;
        private int tamaño;
        private int cant; //Apunta al indice del ultimo elemento. La cantidad total de elementos es cant + 1

        public PilaSecuencial(int tamaño)
        {
            cant = -1;
            this.tamaño = tamaño;
            arr = new int[tamaño];
        }

        public int Insertar(int x)
        {
            if (!IsFull())
            {
                cant++;
                arr[cant] = x;
                return x;
            }
            else
            {
                return -1;
            }
        }

        public int Suprimir()
        {
            int x;
            if (!IsEmpty())
            {
                x = arr[cant];
                cant--;
                return x;
            }
            else
            {
                Console.WriteLine("Pila Vacia");
                return -1;
            }
        }

        public void Mostrar()
        {
            if (IsEmpty())
            {
                Console.Write("[Pila Vacía]");
                return;
            }

            // Se recorre desde el tope (cant) hasta la base (0)
            Console.Write("[");
            for (int i = cant; i >= 0; i--)
            {
                Console.Write(arr[i]);
                if (i > 0)
                {
                    Console.Write(" | ");
                }
            }
            Console.Write("] (Tope)");
        }
        

        public bool IsEmpty()
        {
            return cant == -1;
        }

        public bool IsFull()
        {
            return cant == tamaño - 1;
        }

        public void Insert(int value)
        {
            throw new NotImplementedException();
        }

        public int Pop()
        {
            throw new NotImplementedException();
        }

        public int Peek()
        {
            throw new NotImplementedException();
        }

        public int Size()
        {
            throw new NotImplementedException();
        }

        public void Traverse()
        {
            throw new NotImplementedException();
        }

        public int[] GetValues()
        {
            throw new NotImplementedException();
        }

        public void Test()
        {
            throw new NotImplementedException();
        }
    }
}
