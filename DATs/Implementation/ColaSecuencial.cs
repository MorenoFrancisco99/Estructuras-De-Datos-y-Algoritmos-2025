
namespace ConsoleApp1.DATs.Implementation
{
    internal class ColaSecuencial<T> : ICola<T>
    {
        private int[] arr;
        private int primero;
        private int ultimo;
        private int cant;
        private int tamaño;

        public ColaSecuencial(int tamaño)
        {
            primero = 0;
            ultimo = 0;//ultimo apunta al primer lugar vacio
            cant = 0;
            this.tamaño = tamaño;
            arr = new int[tamaño];
        }

        public int Insertar(int x)
        {
            if (!IsFull())
            {
                arr[ultimo] = x;
                ultimo = (ultimo + 1) % tamaño; // premite cola circular. Ultimo apunta a la posicion libre despues del ultimo elemento 
                cant++;            //Al tomar el resto de (utlimo + 1) siempre va a dar el mismo valor de (utlimo + 1) EXEPTO cuando (ultimo + 1) == tamaño. En ese caso devuelve 0, permitiendo insertar al principio
                return x;
            }
            else
            {
                Console.WriteLine("Cola Llena");
                return -1;
            }
        }

        public int Suprimir()
        {
            int x;
            if (!IsEmpty())
            {
                x = arr[primero];
                primero = (primero + 1) % tamaño; // misma logica que en el insertar.
                cant--;
                return (x);
            }
            else
            {
                Console.WriteLine("Cola Vacia");
                return 0;
            }
        }

        public bool IsEmpty()
        {
            return cant == 0;
        }

        public bool IsFull()
        {
            return cant == tamaño;
        }

        public void Recorrer()
        {
            int i, j;
            if (!IsEmpty())
            {
                i = primero;
                j = 0;
                for (; j < cant; i = (i + 1) % tamaño, j++) //La verdadera variable de control es j. Se inicia en 0 y el loop termina cuando j = cant. 
                                                            //La variable i sirve para poder acceder a los campos correspondientes en el array bajo la mimsa logica que explique en el insertar.
                {
                    Console.WriteLine(arr[i]);
                }

            }
        }

        public int Insertar(T elemento)
        {
            throw new NotImplementedException();
        }

        public T? Pop()
        {
            throw new NotImplementedException();
        }

        public bool isEmpty()
        {
            throw new NotImplementedException();
        }

        public T Peek()
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            throw new NotImplementedException();
        }

        public void Test(IEnumerable<T> values)
        {
            throw new NotImplementedException();
        }
    }
}
    
