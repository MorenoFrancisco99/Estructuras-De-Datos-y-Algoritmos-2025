//using System.Diagnostics;
//using System.Security.Cryptography;

//namespace ConsoleApp1.DATs.Implementation
//{
//    internal class HuffmanTree
//    {
//        [DebuggerDisplay("Nodo {caracter}: {frecuencia} (Izq = {izquierdo?.valor}, Der = {derecho?.valor})")]
//        private class Nodo
//        {
//            public string caracter;
//            public int frecuencia = 0;
//            public Nodo izquierdo = null;
//            public Nodo derecho = null;
//        }
//        Nodo raiz;
//        public HuffmanTree()
//        {
//            raiz = null;
//        }


//        // <-------------------------------------------FUNCIONES BASICAS----------------------------------------------!>
//        public bool IsEmpty()
//        {
//            return raiz == null;
//        }


//        public int Insertar(int elemento)
//        {
//            try
//            {
//                raiz = InsertarRecursivo(raiz, elemento);

//            }
//            catch (InvalidOperationException ex)
//            {
//                Console.WriteLine(ex.Message);
//                return -1;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error inesperado: " + ex.Message);
//                return -1;
//            }
//            return 1;
//        }


//        private Nodo? InsertarRecursivo(Nodo nodo, int elemento) //Va a recibir el nodo actual y el elemento a insertar
//        {
//            if (nodo == null) //Llegamos a una hoja
//                return new Nodo(elemento);


//            if (elemento == nodo.valor) //Elemento duplicado. Retornamos error
//                throw new InvalidOperationException("Elemento duplicado");

//            if (elemento < nodo.valor)
//                nodo.izquierdo = InsertarRecursivo(nodo.izquierdo, elemento);
//            else
//                nodo.derecho = InsertarRecursivo(nodo.derecho, elemento);

//            return nodo;

//        }



//        public int Eliminar(int elemento)
//        {
//            try
//            {
//                raiz = EliminarRecursivo(raiz, elemento);
//            }
//            catch (InvalidOperationException ex)
//            {
//                Console.WriteLine(ex.Message);
//                return -1;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error inesperado: " + ex.Message);
//                return -1;
//            }
//            return 1;
//        }


//        private Nodo EliminarRecursivo(Nodo nodo, int elemento)
//        {
//            if (nodo == null)
//                throw new InvalidOperationException("Elemento no encontrado");
//            if (elemento < nodo.valor)
//                nodo.izquierdo = EliminarRecursivo(nodo.izquierdo, elemento);
//            else if (elemento > nodo.valor)
//                nodo.derecho = EliminarRecursivo(nodo.derecho, elemento);
//            else
//            {
//                // Nodo con un solo hijo o sin hijos
//                if (nodo.izquierdo == null)
//                    return nodo.derecho;
//                else if (nodo.derecho == null)
//                    return nodo.izquierdo;

//                //Obtienemos el siguiente valor inorder (el maximo del subarbol izquierdo )
//                nodo.valor = MaxValor(nodo.izquierdo);
//                // Eliminar el sucesor inorder, Se pasa el nodo izquierdo y el valor repetido, al final retornara null 
//                nodo.izquierdo = EliminarRecursivo(nodo.izquierdo, nodo.valor);
//            }
//            return nodo;
//        }

//        /// <summary>
//        /// Retorna el valor maximo del subarbol dado
//        /// </summary>
//        /// <param name="nodo"></param>
//        /// <returns></returns>
//        private int MaxValor(Nodo nodo)
//        {
//            if (nodo.derecho == null)
//                return nodo.valor;

//            return MaxValor(nodo.derecho);
//        }


//        public int Buscar(int elemento)
//        {
//            Nodo resultado = BuscarRecursivo(raiz, elemento);
//            if (resultado == null)
//            {
//                Console.WriteLine("Elemento no encontrado");
//                return -1;
//            }

//            Console.WriteLine("Elemento encontrado: ", resultado);

//            return 1; //CONSULTAR: Devolver el nodo encontrado en vez de 1 
//        }


//        private Nodo BuscarRecursivo(Nodo nodo, int elemento)
//        {
//            if (nodo == null || nodo.valor == elemento)
//                return nodo;
//            if (elemento < nodo.valor)
//                return BuscarRecursivo(nodo.izquierdo, elemento);
//            return BuscarRecursivo(nodo.derecho, elemento);
//        }




//        // <-------------------------------------------RECORRIDOS----------------------------------------------!>


//        public void RecorrerInOrden()
//        {
//            Console.Write("[");
//            InOrden(raiz);
//            Console.WriteLine("]");
//        }

//        private void InOrden(Nodo nodo)
//        {
//            if (nodo != null)
//            {
//                InOrden(nodo.izquierdo);
//                Console.Write("," + nodo.valor);
//                InOrden(nodo.derecho);

//            }

//        }

//        public void RecorrerPreOrden()
//        {
//            Console.Write("[");
//            PreOrden(raiz);
//            Console.WriteLine("]");
//        }

//        private void PreOrden(Nodo nodo)
//        {
//            if (nodo != null)
//            {
//                Console.Write("," + nodo.valor);
//                PreOrden(nodo.izquierdo);
//                PreOrden(nodo.derecho);
//            }
//        }


//        public void RecorrerPostOrden()
//        {
//            Console.Write("[");
//            PostOrden(raiz);
//            Console.WriteLine("]");
//        }
//        private void PostOrden(Nodo nodo)
//        {
//            if (nodo != null)
//            {
//                PostOrden(nodo.izquierdo);
//                PostOrden(nodo.derecho);
//                Console.Write("," + nodo.valor);
//            }
//        }





//        // <-------------------------------------------FUNCIONES SECUNDARIAS----------------------------------------------!>

//        /// <summary>
//        /// Verifica si "hijo" es hijo directo de "padre"
//        /// </summary>
//        /// <param name="padre"></param>
//        /// <param name="hijo"></param>
//        /// <returns></returns>
//        public bool Hijo(int padre, int hijo)
//        {
//            Nodo resultado = BuscarRecursivo(raiz, padre);
//            if (resultado == null)
//            {
//                Console.WriteLine("Padre no encontrado");
//                return false;
//            }

//            if ((resultado.izquierdo != null && resultado.izquierdo.valor == hijo) || (resultado.derecho != null && resultado.derecho.valor == hijo))  //El izquierdo o derecho es el hijo
//                return true;

//            return false;

//        }
//        public bool Padre(int padre, int hijo)
//        {
//            return Hijo(padre, hijo);
//        }


//        /// <summary>
//        /// Retorna el nivel del elemento en el arbol. Si no existe retorna -1
//        /// </summary>
//        /// <param name="elemento"></param>
//        /// <returns></returns>
//        public int Nivel(int elemento)
//        {
//            return NivelRecursivo(raiz, elemento, 1);
//        }

//        private int NivelRecursivo(Nodo nodo, int elemento, int nivel)
//        {
//            if (nodo == null)
//                return -1; //Elemento no encontrado

//            if (nodo.valor == elemento)
//                return nivel;

//            if (elemento < nodo.valor)
//                return NivelRecursivo(nodo.izquierdo, elemento, nivel + 1);
//            else
//                return NivelRecursivo(nodo.derecho, elemento, nivel + 1);

//        }



//        /// <summary>
//        /// Chequea si el elemento es una hoja (no tiene hijos)
//        /// </summary>
//        /// <param name="elemento"></param>
//        /// <returns></returns>
//        public bool Hoja(int elemento)
//        {
//            Nodo resultado = BuscarRecursivo(raiz, elemento);
//            if (resultado == null)
//            {
//                Console.WriteLine("Elemento no encontrado");
//                return false;
//            }
//            if (resultado.izquierdo == null && resultado.derecho == null)
//                return true;
//            return false;
//        }


//        /// <summary>
//        /// Determina la altura del arbol
//        /// </summary>
//        /// <returns></returns>
//        public int Altura()
//        {
//            if (IsEmpty())
//            {
//                Console.WriteLine("El árbol está vacío");
//                return -1;
//            }


//            int resultado = AlturaRecursivo(raiz);

//            return resultado; // Altura de un árbol vacío es -1
//        }

//        private int AlturaRecursivo(Nodo nodo)
//        {
//            if (nodo == null)
//                return 0;
//            int alturaIzquierda = AlturaRecursivo(nodo.izquierdo); //Forna alternativa de contar a la del nivel. Se recorre hasta el final y se va sumando  1 por cada nivel
//            int alturaDerecha = AlturaRecursivo(nodo.derecho);
//            return Math.Max(alturaIzquierda, alturaDerecha) + 1; //Elige la mayor altura entre los dos subarboles y le suma 1 por el nivel actual

//        }



//        /// <summary>
//        /// Muestra el camino desde el nodo "padre" hasta el nodo "hijo"
//        /// </summary>
//        /// <param name="padre"></param>
//        /// <param name="hijo"></param>
//        /// <returns></returns>
//        public int Camino(int padre, int hijo)
//        {
//            Nodo inicio = BuscarRecursivo(raiz, padre);
//            if (inicio == null)
//            {
//                Console.WriteLine("El padre no existe");
//                return -1;
//            }
//            int[] arr = new int[12];

//            if (!CaminoRecursivo(inicio, hijo, ref arr)) //El arreglo es enviado por referencia para poder reasignar el contenido
//            {
//                Console.WriteLine("El hijo no existe en el subarbol del padre");
//                return -1;
//            }

//            Console.Write("Camino: ");
//            foreach (var val in arr)
//            {
//                if (val != 0)
//                    Console.Write(val + " ");
//            }
//            return 1;

//        }
//        private bool CaminoRecursivo(Nodo nodo, int objetivo, ref int[] arr)
//        {
//            if (nodo == null)
//                return false;
//            arr = arr.Append(nodo.valor).ToArray(); //CONSULTAR: Poder usar otra estructura de datos para evitar la copia sucesiva del arreglo

//            if (nodo.valor == objetivo)
//            {
//                return true;
//            }

//            if (objetivo < nodo.valor)
//                return CaminoRecursivo(nodo.izquierdo, objetivo, ref arr);
//            else
//                return CaminoRecursivo(nodo.derecho, objetivo, ref arr);

//        }



//        // <-------------------------------------------INCISOS----------------------------------------------!>

//        // a) Mostrar el nodo padre y el nodo hermano, de un nodo previamente ingresado por teclado; éste puede o no existir en el árbol
//        /// <summary>
//        ///Muestra el nodo padre y el nodo hermano, de un nodo previamente ingresado por teclado; éste puede o no existir en el árbol 
//        /// </summary>
//        /// <param name="valorDelNodo">Dato del nodo</param>
//        /// <returns>Muestra por consola el padre y el hermano del nodo si existe. Devuelve -1 si el nodo no existe, 1 en cualquier otro caso.</returns>
//        public int MostrarPadreYHermano(int valorDelNodo)
//        {
//            Nodo anterior = null, actual = raiz;


//            while (actual != null && actual.valor != valorDelNodo)
//            {
//                anterior = actual;

//                if (valorDelNodo < actual.valor)
//                    actual = actual.izquierdo;
//                else
//                    actual = actual.derecho;
//            }

//            if (actual == null)
//            {
//                Console.WriteLine("El elemento no existe en el árbol");
//                return -1;
//            }
//            else if (actual.valor == raiz.valor)
//            {
//                Console.WriteLine("El elemento es la raíz y no tiene padre ni hermano");
//                return 1;
//            }

//            Console.WriteLine("Padre: " + anterior.valor);
//            if (anterior.izquierdo != null && anterior.izquierdo.valor == actual.valor) //El actual es hijo izquierdo
//            {
//                if (anterior.derecho != null)
//                    Console.WriteLine("Hermano: " + anterior.derecho.valor);
//                else
//                    Console.WriteLine("El elemento no tiene hermano");
//            }
//            else //El actual es hijo derecho
//            {
//                if (anterior.izquierdo != null)
//                    Console.WriteLine("Hermano: " + anterior.izquierdo.valor);
//                else
//                    Console.WriteLine("El elemento no tiene hermano");
//            }
//            return 1;
//        }

//        // b) Mostrar la cantidad de nodos del árbol en forma recursiva
//        /// <summary>
//        /// Muestra la cantidad de nodos del árbol en forma recursiva
//        /// </summary>
//        /// <returns></returns>
//        public int CantidadNodosRecursivo()
//        {
//            int cantidad = IncisoBRecursivo(raiz);
//            Console.WriteLine("Cantidad de nodos: " + cantidad);
//            return cantidad;

//        }
//        private int IncisoBRecursivo(Nodo nodo)
//        {
//            if (nodo == null)
//                return 0;
//            Console.WriteLine(nodo.valor);
//            int valorA = IncisoBRecursivo(nodo.izquierdo);
//            int valorB = IncisoBRecursivo(nodo.derecho);
//            return valorA + valorB + 1;
//        }

//        // c) Mostrar la altura de un árbol.
//        /// <summary>
//        /// Muestra la altura del árbol
//        /// </summary>
//        public int MostrarAltura()
//        {
//            int altura = Altura();
//            if (altura == -1)
//                Console.WriteLine("El arbol esta vacio");
//            return altura;
//        }

//        //d) Mostrar los sucesores de un nodo ingresado previamente por teclado.
//        /// <summary>
//        /// Muestra los sucesores in order de un nodo ingresado previamente por teclado.
//        /// </summary>
//        /// <param name="elemento">Valor del nodo a mostrar sucesores</param>
//        /// <returns></returns>
//        public int MostrarSucesores(int elemento)
//        {
//            Nodo nodo = BuscarRecursivo(raiz, elemento);
//            if (nodo == null)
//            {
//                Console.WriteLine("El elemento no existe en el árbol");
//                return -1;
//            }

//            Console.WriteLine($"Sucesores in order del nodo {elemento}");
//            IncisoBRecursivo(nodo);
//            return 1;
//        }
//        public void Test()
//        {
//            Console.WriteLine("===================Iniciando Teste de Arbol Binario de Busqueda======================");
//            Console.WriteLine("-->Insertando valores [6, 85 ,31, 96, 7, 3, 17, 50]");

//            int[] valores = new int[] { 6, 85, 31, 96, 7, 3, 17, 50 };

//            foreach (var valor in valores)
//            {
//                int result = Insertar(valor);
//                if (result == 1)
//                {
//                    Console.WriteLine($"Valor {valor} insertado correctamente");
//                }
//                else if (result == -1)
//                {
//                    Console.WriteLine($"Hubo un error intentando insertar el valor {valor}");
//                    Console.WriteLine("Retornando...");
//                    return;
//                }
//            }

//            Console.WriteLine("Recorriendo el arbol en orden.");
//            Console.WriteLine("Esperado: [3,6,7,17,31,50,85,96]");
//            Console.Write("Obtenido: ");
//            RecorrerInOrden();


//            Console.WriteLine("\n-->Eliminacion de valores");
//            Console.WriteLine("Eliminando el valor 31 (nodo con dos hijos)");
//            int res = Eliminar(31);
//            if (res == 1)
//            {
//                Console.WriteLine("Valor eliminado correctamente");
//            }
//            else if (res == -1)
//            {
//                Console.WriteLine("Hubo un error intentando eliminar el valor 31");
//                Console.WriteLine("Retornando...");
//                return;
//            }
//            Console.WriteLine("Eliminando hoja 3 (nodo sin hijos)");
//            res = Eliminar(3);
//            if (res == 1)
//            {
//                Console.WriteLine("Valor eliminado correctamente");
//            }
//            else if (res == -1)
//            {
//                Console.WriteLine("Hubo un error intentando eliminar el valor 3");
//                Console.WriteLine("Retornando...");
//                return;
//            }
//            Console.WriteLine("Eliminando raiz 6");
//            res = Eliminar(6);
//            if (res == 1)
//            {
//                Console.WriteLine("Valor eliminado correctamente");
//            }
//            else if (res == -1)
//            {
//                Console.WriteLine("Hubo un error intentando eliminar el valor 6");
//                Console.WriteLine("Retornando...");
//                return;
//            }
//            Console.WriteLine("Intentando eliminar un valor no existente 100");
//            res = Eliminar(100);
//            if (res == -1)
//            {
//                Console.WriteLine("Error capturado correctamente");
//            }
//            Console.WriteLine("Recorriendo el arbol en orden.");
//            Console.WriteLine("Esperado: [7,17,50,85,96]");
//            Console.Write("Obtenido: ");
//            RecorrerInOrden();

//            Console.WriteLine("\n-->Busqueda de valores");
//            Console.WriteLine("Buscando el valor 50 (debe existir)");
//            res = Buscar(50);
//            if (res == 1)
//            {
//                Console.WriteLine("Valor encontrado correctamente");
//            }
//            else if (res == -1)
//            {
//                Console.WriteLine("Hubo un error intentando buscar el valor 50");
//                Console.WriteLine("Retornando...");
//                return;
//            }
//            Console.WriteLine("Buscando el valor 100 (no debe existir)");
//            res = Buscar(100);
//            if (res == -1)
//            {
//                Console.WriteLine("Error capturado correctamente");
//            }


//            Console.WriteLine("\n-->Verificaciones de propiedades");
//            Console.WriteLine("Verificando si 85 es padre de 96 (debe ser cierto)");
//            bool esPadre = Padre(85, 96);
//            Console.WriteLine("Esperado: true");
//            Console.WriteLine("Resultado: " + esPadre);
//            Console.WriteLine("Verificando si 85 es hijo de 50 (debe ser falso)");
//            Console.WriteLine("Esperado: false");
//            Console.WriteLine("Resultado: " + Hijo(50, 85));


//            Console.WriteLine("Verificando si 7 es hoja (debe ser cierto)");
//            Console.WriteLine("Esperado: true");
//            Console.WriteLine("Resultado: " + Hoja(7));
//            Console.WriteLine("Verificando si 85 es hoja (debe ser falso)");
//            Console.WriteLine("Esperado: false");
//            Console.WriteLine("Resultado: " + Hoja(85));
//            Console.WriteLine("Verificando el nivel de 17 (debe ser 2)");
//            Console.WriteLine("Esperado: 2");
//            Console.WriteLine("Resultado: " + Nivel(17));
//            Console.WriteLine("Verificando el nivel de 96 (debe ser 3)");
//            Console.WriteLine("Esperado: 3");
//            Console.WriteLine("Resultado: " + Nivel(96));
//            Console.WriteLine("Verificando el nivel de 100 (no existe, debe retornar -1)");
//            Console.WriteLine("Esperado: -1");
//            Console.WriteLine("Resultado: " + Nivel(100));



//            Console.WriteLine("Verificando la altura del arbol (debe ser 3)");
//            Console.WriteLine("Esperado: 3");
//            Console.WriteLine("Resultado: " + Altura());

//            Console.WriteLine("Ingresando nuevos valores");
//            int[] nuevosValores = new int[] { 90, 95, 97 };
//            foreach (var valor in nuevosValores)
//            {
//                int result = Insertar(valor);
//                if (result == 1)
//                {
//                    Console.WriteLine($"Valor {valor} insertado correctamente");
//                }
//                else if (result == -1)
//                {
//                    Console.WriteLine($"Hubo un error intentando insertar el valor {valor}");
//                    Console.WriteLine("Retornando...");
//                    return;
//                }
//            }
//            Console.WriteLine("Recorriendo el arbol en orden.");
//            Console.WriteLine("Esperado: [7,17,50,85,90,95,96,97]");
//            Console.Write("Obtenido: ");
//            RecorrerInOrden();

//            Console.WriteLine("Verificando la altura del arbol (debe ser 5)");
//            Console.WriteLine("Esperado: 4");
//            Console.WriteLine("Resultado: " + Altura());
//            Console.WriteLine("Verificando el nivel de 97");
//            Console.WriteLine("Esperado: 3");
//            Console.WriteLine("Resultado: " + Nivel(97));
//            Console.WriteLine("Verificando el nivel de 90");
//            Console.WriteLine("Esperado: 3");
//            Console.WriteLine("Resultado: " + Nivel(90));

//            Console.WriteLine("Mostrando el camino desde 85 hasta 97");
//            res = Camino(85, 97);
//            if (res == -1)
//            {
//                Console.WriteLine("Hubo un error intentando mostrar el camino");
//                Console.WriteLine("Retornando...");
//                return;
//            }

//            Console.WriteLine("===================Fin del Teste de Arbol Binario de Busqueda======================");

//        }



//    }
//}
