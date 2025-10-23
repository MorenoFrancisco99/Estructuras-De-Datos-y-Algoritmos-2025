namespace ConsoleApp1.DATs.Implementation
{
    internal class ListaCursores 
    {
        private class Nodo
        {
            public int Dato;
            public int Siguiente;
        }
        private Nodo[] arr;
        private int cant;
        private int tam;
        private int libre;
        private int inicio;

        public ListaCursores(int tam)
        {
            this.tam = tam;
            arr = new Nodo[tam];
            for (int i = 0; i < tam; i++)
            {
                arr[i] = new Nodo {Dato = 0, Siguiente = i + 1};
            }
            arr[tam - 1].Siguiente = -1;
            libre = 0;
            inicio = -1;
            cant = 0;
        }


        public int Buscar(int num)
        {
            int indiceFisico = inicio, indiceLogico = 0;
            while (indiceFisico != -1 && arr[indiceFisico].Dato != num)
            {
                indiceFisico = arr[indiceFisico].Siguiente;
                indiceLogico++;
            }
            if (indiceFisico != -1)
                return indiceLogico;
            else
                return -1;
        }

        public string ImprimirLista()
        {
            if (EstVacia()) return "Lista: []";

            string result = "Lista: [";
            int cursor = inicio;
            while (cursor != -1)
            {
                result += arr[cursor].Dato;
                cursor = arr[cursor].Siguiente;
                if (cursor != -1)
                {
                    result += ", ";
                }
            }
            result += "]\n";
            result += $"Cant: {cant}, Inicio: {inicio}, Libre: {libre}";
            return result;
        }

        public int Eliminar(int index)
        {
            int valor, indiceEliminado;
            if (EstVacia())
                return -1;
            if(index < 0 || index >= cant) 
                return -1;

            if(index == 0)
            {
                valor = arr[inicio].Dato;
                indiceEliminado = inicio;
                inicio = arr[inicio].Siguiente;
            }
            else
            {
                int anterior = Anterior(index); //Indice del nodo anterior al que queremos eliminar

                indiceEliminado = arr[anterior].Siguiente; //Indice del nodo a eliminar
                valor = arr[indiceEliminado].Dato; //Guardamos el valor a eliminar

                int sig = arr[indiceEliminado].Siguiente; //Guardamos el indice siguiente del nodo a eliminar                
                arr[anterior].Siguiente = sig; //El proximo del anterior es el siguiente del nodo a eliminar

             
            }

            arr[indiceEliminado].Siguiente = libre; //El siguiente del nodo que acabamos de eliminar sera el indice libre
            libre = indiceEliminado;//El indice libre ahora es el nodo que acabamos de eliminar
            cant--;

            return valor;

        }

        public bool EstaLlena()
        {
            return cant == tam;
        }

        public bool EstVacia()
        {
            return cant == 0;
        }
        public int Insertar(int index, int num)
        {
            if (EstaLlena())
                return -1;
            if (index < 0 || index > cant)
                return -1;


            int nuevo = libre; //Guardamos el indice del nuevo nodo
            libre = arr[libre].Siguiente; //Actualizamos el libre para que apunte al siguiente nodo libre
            arr[nuevo].Dato = num;

            if (index == 0) //Si se inserta al principio
            {
                arr[nuevo].Siguiente = inicio; //El siguiente es el inicio, que puede ser -1 o el primer nodo
                inicio = nuevo; //El inicio ahora sera el nuevo nodo
            }
            else
            {
                int ant = Anterior(index);
                arr[nuevo].Siguiente = arr[ant].Siguiente; //El siguiente del nuevo nodo sera el siguiente del anterior
                arr[ant].Siguiente = nuevo; //El siguiente del anterior sera el nuevo nodo
            }

            cant++;
            return 1;
        }


        public int Anterior(int index)
        {
            int indiceFisico = inicio, indiceLogico = 0;
            while (indiceLogico < index - 1) // Recorremos hasta llegar al indice anterior. Si el indice es 0, no entra al while. i nunca deberia ser -1 pero se agrega por las dudas
            {
                indiceFisico = arr[indiceFisico].Siguiente;
                indiceLogico++;

            }

            return indiceFisico;
        }


        public int Recuperar(int index)
        {
            if(EstVacia() || index < 0 || index >= cant)
                                return -1;
            int valor;
            int indicefisico = inicio, indiceLogico = 0;

            while (indiceLogico < index)
            {
                indicefisico = arr[indicefisico].Siguiente;
                indiceLogico++;
            }
            valor = arr[indicefisico].Dato;

            return valor;

        }

    
    }
}
