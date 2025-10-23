using ConsoleApp1.DATs.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Practico_3
{
    internal static class Ej4___Suma_de_matriz_rala
    {
      
        public static void Start()
        {
            ListaEnlazadaParaMatriz matriz1 = new ListaEnlazadaParaMatriz();
            ListaEnlazadaParaMatriz matriz2 = new ListaEnlazadaParaMatriz();

            Node? NodoMatriz1 = matriz1.Primer_elemento();
            Node? NodoMatriz2 = matriz2.Primer_elemento();

            ListaEnlazadaParaMatriz resultado = new ListaEnlazadaParaMatriz();

            while (NodoMatriz1 != null && NodoMatriz2 != null) //Mientras las dos matrices tengan elementos
            {
                if(NodoMatriz1.fila == NodoMatriz2.fila && NodoMatriz1.columna == NodoMatriz2.columna) //Mismo elemento
                {
                    //Sumar
                    int suma = NodoMatriz1.value + NodoMatriz2.value;
                    if(suma != 0) //La suma de elementos negrativos con positivos puede dar 0
                    {
                        resultado.Insertar(NodoMatriz1.fila, NodoMatriz1.columna, suma);
                    }
                }
                else if(NodoMatriz1.fila < NodoMatriz2.fila || (NodoMatriz1.fila == NodoMatriz2.fila && NodoMatriz1.columna < NodoMatriz2.columna))  //El nodo de la matriz1 es menor
                {
                    //Agregar nodo de matriz1 e iteraramos NodoMatriz1
                    resultado.Insertar(NodoMatriz1.fila, NodoMatriz1.columna, NodoMatriz1.value);
                    NodoMatriz1 = matriz1.GetSiguiente(NodoMatriz1);

                }
                else //El nodo de la matriz2 es menor
                {
                    //Agregar nodo de matriz2 e iteraramos NodoMatriz2
                    resultado.Insertar(NodoMatriz2.fila, NodoMatriz2.columna, NodoMatriz2.value);
                    NodoMatriz2 = matriz2.GetSiguiente(NodoMatriz2);

                }

            }

            while(NodoMatriz1 != null)
            {
                resultado.Insertar(NodoMatriz1.fila, NodoMatriz1.columna, NodoMatriz1.value);
                NodoMatriz1 = matriz1.GetSiguiente(NodoMatriz1);
            }
            while(NodoMatriz2 != null)
            {
                resultado.Insertar(NodoMatriz2.fila, NodoMatriz2.columna, NodoMatriz2.value);
                NodoMatriz2 = matriz2.GetSiguiente(NodoMatriz2);
            }

            resultado.Recorrer();

        }
    }
}
