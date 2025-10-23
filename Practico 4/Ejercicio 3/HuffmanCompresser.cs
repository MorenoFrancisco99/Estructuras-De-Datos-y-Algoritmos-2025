using ConsoleApp1.Practico_3;
using System.Diagnostics;
using System.Text;

namespace ConsoleApp1.DATs.Implementation
{
    /// <summary>
    /// Lista ordenada para el algoritmo de Huffman. Toma caracteres y cuenta su frecuencia.
    /// </summary>
    /// <remarks>
    /// La  lista se mantiene ordenada en base al valor ASCII de los caracteres. Esto permite un acceso más eficiente y una mejor organización de los datos. 
    /// Esto dejará el array con la frecuencia de cada caracter en su posicion correspondiente al valor ASCII del mismo.
    /// </remarks>

    [DebuggerDisplay("{DebuggerDisplay}")]
    internal class HuffmanCompresser
    {
        private string DebuggerDisplay => GetDotRepresentation();



        Nodo[] listaDeFrecuencias; // Array de nodos para almacenar la frecuencia de cada caracter ASCII.
        Nodo cabeza; // Cabeza de la lista enlazada de nodos para construir el árbol de Huffman.
        Nodo ultimo; // La insercion siempre va a ser al final de la lista. Conviene tener una referencia al ultimo nodo.

        private struct HuffmanCodes //Para poder almacenar los codigos de forma mas comoda
        {
            public int frecuencia;
            public string codigo;
        }
        Dictionary<char, HuffmanCodes> tablaDeCodigos; // Tabla de códigos de Huffman para cada caracter.
        
        
        string texto; 
        private class Nodo
        {
            public string caracter;
            public int frecuencia = 0;
            public Nodo izquierdo = null;
            public Nodo derecho = null;
            public Nodo siguiente = null;

        }

        public HuffmanCompresser()
        {
            listaDeFrecuencias = new Nodo[256]; // Tamaño fijo para todos los caracteres ASCII. 
            cabeza = null;
            ultimo = null;
            foreach (int i in Enumerable.Range(0, 256)) //Inicializamos cada nodo en el array
            {
                listaDeFrecuencias[i] = new Nodo();
            }

            tablaDeCodigos = new Dictionary<char, HuffmanCodes>();
            
        }

        /*
         Codigo en el main para probar HuffmanCompresser
         
            HuffmanCompresser huffman = new HuffmanCompresser();
            string texto = "Ejemplo de texto para comprimir utilizando el algoritmo de Huffman.";
            huffman.CrearCodigoHuffman(texto); 
            huffman.MostrarFrecuenciaDeCaracteres();
            huffman.MostrarTabla();
            huffman.Comprimir();
         
         */



        /// <summary>
        /// Genera los códigos de Huffman basados en las frecuencias de los caracteres de un texto cargado. 
        /// </summary>
        /// <remarks>
        /// La insercion de caracteres de control puede causar errores, se recomienda usar texto plano.
        /// </remarks>
        /// <returns>
        /// Tabla de códigos de Huffman para cada caracter.
        /// </returns>
        public int CrearCodigoHuffman(string texto) 
        {
            if (string.IsNullOrEmpty(texto))
            {
                Console.WriteLine("Error: El texto proporcionado es nulo o vacío.");
                return -1;
            }

            foreach (char c in texto) // Insertamos cada caracter en la lista y contamos su frecuencia
            {
                InsertarArray(c);
            }

            this.texto = texto;
            //Ordenamos los nodos por frecuencia
            listaDeFrecuencias = OrdenarArrayAcendente(listaDeFrecuencias);

            //Construimos la lista enlazada con los nodos ordenados
            cabeza = listaDeFrecuencias[0];
            ultimo = cabeza;
            for (int i = 1; i < listaDeFrecuencias.Length ; i++)
            {
                ultimo.siguiente = listaDeFrecuencias[i];
                ultimo = ultimo.siguiente;
            }

            //Comenzamos a construir el arbol de Huffman
            //Todo esto podria estar en una funcion aparte pero no se rehusa
            while (cabeza != null && cabeza.siguiente != null) // Mientras haya al menos dos nodos en la lista
            {
                Nodo primerNodo = cabeza;
                Nodo segundoNodo = cabeza.siguiente;
               
                Nodo nuevoNodo = new Nodo
                {
                    caracter = primerNodo.caracter + segundoNodo.caracter,
                    frecuencia = primerNodo.frecuencia + segundoNodo.frecuencia,
                    izquierdo = primerNodo, //El mas pequeño va a la izquierda
                    derecho = segundoNodo, //El segundo mas pequeño va a la derecha
                };
                cabeza = cabeza.siguiente.siguiente; // Avanzamos la cabeza dos posiciones
                InsertarListaOrdenada(nuevoNodo); 
            }

            //Ahora cabeza apunta al nodo raiz del arbol de Huffman
            
            GenerarTablaDeCodigos(cabeza, ""); // Inicia la generación de códigos desde la raíz del árbol
            Console.WriteLine("Árbol de Huffman construido.");

            return 1;
        }




     

        /// <summary>
        /// Convierte el texto original en una secuencia comprimida utilizando los códigos de Huffman generados.
        /// </summary>
        /// <returns>
        /// Un string representando el texto comprimido.
        /// </returns>
        public void Comprimir()
        {
            string textoComprimido = string.Empty;

            foreach(char c in texto)
            {
                if(tablaDeCodigos.ContainsKey(c))
                {
                    textoComprimido += tablaDeCodigos[c].codigo;
                }
                else
                {
                    Console.WriteLine($"Error: El caracter '{c}' no tiene un código de Huffman asignado.");
                    return;
                }
            }
            Console.WriteLine($"Texto comprimido: {textoComprimido}");

        }

        /// <summary>
        /// Extrae el texto original a partir de la secuencia comprimida utilizando los códigos de Huffman.
        /// </summary>
        /// <remarks>
        /// Esta función debe reconstruir el texto original utilizando la tabla de códigos de Huffman.
        /// </remarks>
        /// <returns>
        /// String del texto descomprimido.
        /// </returns>
        public void Descomprimir()
        {
            //No implementado
        }



        /// <summary>
        /// Muestra de la lista los caracteres y sus frecuencias
        /// </summary>
        public void MostrarFrecuenciaDeCaracteres()
        {
            Console.WriteLine("Caracter (ASCII) : Frecuencia");
            for (int i = 0; i < listaDeFrecuencias.Length; i++)
            {
                if (listaDeFrecuencias[i] != null && listaDeFrecuencias[i].frecuencia > 0)
                {
                    Console.WriteLine($"   '{listaDeFrecuencias[i].caracter}' ({i}) : {listaDeFrecuencias[i].frecuencia}");
                }
            }
        }

        /// <summary>
        /// Muestra la tabla de codigos de Huffman
        /// </summary>
        public void MostrarTabla()
        {
            Console.WriteLine("Caracter\t Frecuencia\t Codigo");
            foreach (var entry in tablaDeCodigos)
            {
                Console.WriteLine($"   '{entry.Key}'\t\t {entry.Value.frecuencia}\t\t {entry.Value.codigo}");
            }

        }



        /// <summary>
        /// Genera la tabla de caracteres y sus códigos de Huffman a partir del árbol.
        /// 
        /// </summary>
        /// <param name="nodo"></param>
        /// <param name="codigoActual"></param>
        private void GenerarTablaDeCodigos(Nodo nodo, string codigoActual) //Pasa el nodo actual y el codigo generado hasta el momento
        {
            //Bsca de forma recursiva las hojas del arbol
            if (nodo == null)
                return;
            // Si es una hoja, agregar el código a la tabla
            if (nodo.izquierdo == null && nodo.derecho == null)
            {
                char caracter = nodo.caracter[0];
                tablaDeCodigos[caracter] = new HuffmanCodes
                {
                    frecuencia = nodo.frecuencia,
                    codigo = codigoActual
                };
            }
            // Recorrer el subárbol izquierdo y derecho
            GenerarTablaDeCodigos(nodo.izquierdo, codigoActual + "0");
            GenerarTablaDeCodigos(nodo.derecho, codigoActual + "1");
        }




        /// <summary>
        /// Suma 1 a la frecuencia del caracter en su posición correspondiente del array.
        /// </summary>
        /// <remarks>
        /// Convierte el caracter a su valor ASCII y utiliza este valor como índice en el array para incrementar la frecuencia.
        /// </remarks>
        /// <param name="caracter"></param>
        /// <returns></returns>
        private int InsertarArray(char caracter)
        {
            try
            {
                int ASCIIvalue = (int)caracter;

                listaDeFrecuencias[ASCIIvalue].caracter = caracter.ToString(); //Se repite pero no afecta el resultado
                listaDeFrecuencias[ASCIIvalue].frecuencia++;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Error: Caracter fuera del rango ASCII.");
                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// Inserta un nuevo nodo en la lista enlazada manteniendo el orden basado en la frecuencia.
        /// </summary>
        /// <param name="nuevoNodo"></param>
        /// <returns></returns>
        private int InsertarListaOrdenada(Nodo nuevoNodo)
        {
            if (cabeza == null || nuevoNodo.frecuencia < cabeza.frecuencia)
            {
                nuevoNodo.siguiente = cabeza;
                cabeza = nuevoNodo;
                return 1;
            }
            if(ultimo.frecuencia <= nuevoNodo.frecuencia)
            {
                ultimo.siguiente = nuevoNodo;
                ultimo = nuevoNodo;
                return 1;
            }
            Nodo actual = cabeza;
            while (actual.siguiente != null && actual.siguiente.frecuencia <= nuevoNodo.frecuencia)
            {
                actual = actual.siguiente;
            }


            nuevoNodo.siguiente = actual.siguiente;
            actual.siguiente = nuevoNodo;

            return 1;
        }


    



        /// <summary>
        /// Ordena la lista en orden ascendente basado en la frecuencia de los caracteres.\n 
        /// Debe aplicarse unicamente despues de haber insertado todos los caracteres.
        /// Los cambios son irreversibles, no se puede volver al orden original y elimina los caracteres con frecuencia 0.
        /// </summary>
        ///<remarks>
        /// Utiliza Bubble Sort para ordenar la lista.
        /// </remarks>
        /// <returns></returns>
        private Nodo[] OrdenarArrayAcendente(Nodo[] listaAOrdenar) 
        {
            listaAOrdenar = listaAOrdenar.Where(nodo => nodo.frecuencia > 0)
                                            .OrderBy(x => x.frecuencia)
                                            .ToArray();
            return listaAOrdenar;
        }



        ///tomado de: https://stackoverflow.com/questions/11653204/visualize-a-binary-tree-in-vs
        public string GetDotRepresentation()
        {
            var sb = new StringBuilder();

            sb.AppendLine("digraph BST {");
            GetDotRepresentation(this.cabeza, sb);
            sb.AppendLine("}");

            return sb.ToString();
        }

        private void GetDotRepresentation(Nodo root, StringBuilder sb)
        {
            if (root == null) return;

            if (root.izquierdo != null)
            {
                sb.AppendLine($"{root.caracter} -> {root.izquierdo.caracter}");
            }

            if (root.derecho != null)
            {
                sb.AppendLine($"{root.caracter} -> {root.derecho.caracter}");
            }

            GetDotRepresentation(root.izquierdo, sb);
            GetDotRepresentation(root.derecho, sb);
        }
    }
}
