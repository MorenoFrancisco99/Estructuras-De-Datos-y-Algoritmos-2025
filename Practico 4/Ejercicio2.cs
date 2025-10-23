using ConsoleApp1.DATs.Implementation;

namespace ConsoleApp1.Practica_4
{
    internal class Ejercicio2
    {
        ArbolBinariodeBusqueda arbol = new ArbolBinariodeBusqueda();
        int[] valores = { 1, 6, 8, 42, 64, 23, 75, 25, 13, 75, 76, 98, 343, 542, 65, 56, 52 };

        public Ejercicio2()
        {
            foreach (var item in valores)
            {
                arbol.Insertar(item);
            }
        }

        /// <summary>
        /// Displays information about the parent and sibling nodes of a specified node in the tree.
        /// </summary>
        /// <remarks>This method prompts the user to input a value from the tree and then processes the
        /// input to determine and display the parent and sibling nodes of the specified value.</remarks>
        /// <returns>Always returns <see langword="1"/>.</returns>
        public int IncisoA()
        {
            Console.WriteLine("Ejercicio 2 - Inciso A- Nodo padre y hermano de un nodo dado");
            Console.WriteLine("Ingrese un valor del arbol. Valores disponibles en el testeo: [1, 6, 8, 42, 64, 23, 75, 25, 13, 75, 76, 98, 343, 542, 65, 56, 52]");
            int valorIngresado = int.Parse(Console.ReadLine());

            arbol.MostrarPadreYHermano(valorIngresado);

            return 1;
        }

        /// <summary>
        /// Muestra la cantidad de nodos del árbol en forma recursiva
        /// </summary>
        /// <returns></returns>
        public int IncisoB()
        {
            Console.WriteLine("Ejercicio 2 - Inciso B- Cantidad de nodos del arbol (recursivo)");
            Console.WriteLine($"La cantidad de nodos del arbol es: {arbol.CantidadNodosRecursivo()}");
            return 1;
        }


        /// <summary>
        /// Muestra la altura del árbol
        /// </summary>
        /// <returns></returns>
        public int IncisoC()
        {
            Console.WriteLine("Ejercicio 2 - Inciso C- Muestra la altura del arbol");
            Console.WriteLine($"La altura del arbol es: {arbol.MostrarAltura()}");
            return 1;
        }

        /// <summary>
        /// Muestra los sucesores de un nodo dado
        /// </summary>
        /// <returns></returns>
        public int IncisoD()
        {
            Console.WriteLine("Ejercicio 2 - Inciso D- Mostrar los sucesores de un nodo dado");
            Console.WriteLine("Ingrese un valor del arbol. Valores disponibles en el testeo: [1, 6, 8, 42, 64, 23, 75, 25, 13, 75, 76, 98, 343, 542, 65, 56, 52]");
            int valorIngresado = int.Parse(Console.ReadLine());
            arbol.MostrarSucesores(valorIngresado);
            return 1;

        }
    }
}
