using ConsoleApp1.DATs;
using ConsoleApp1.DATs.Implementation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 El Laboratorio de Computación tiene una única impresora, a la cual llegan trabajos para
imprimir de cualquiera de las máquinas. Los trabajos a imprimir tienen asociado la cantidad
de páginas (se aceptan, como máximo, trabajos de 100 páginas).
Considerando que los trabajos llegan en promedio cada 5 minutos a la cola de impresión y
que la impresora imprime a una velocidad de 10 ppm:
Se requiere simular el comportamiento de dicha cola, teniendo en cuenta que la impresora
tiene un tiempo máximo para procesar cada trabajo de 3 minutos. El trabajo que no se
terminó de imprimir porque excedía su tiempo de proceso ingresa nuevamente a la cola con
la cantidad de páginas que restan por imprimir.

Suponer el tiempo de simulación de 1 hora y que la cantidad de páginas del trabajo es
aleatoria. Se pide:
    a) Informar cantidad de trabajos que quedaron sin atender.
    b) Indicar el promedio de espera de los trabajos impresos.

 */
namespace ConsoleApp1.Practco_2
{
    internal class Ej7_Impresoras
    {

        public Ej7_Impresoras() //Constructor vacio
        {
            
        }
        
        public void Start(int tiempoMinutos)
        {
            Console.WriteLine(" Iniciando Ejercicio 7");

            Random rand = new Random();

            
            ICola<int[]> cola = new ColaEncadenada<int[]>();
            int[]? trabajoActual = null; //cantidad de paginas / tiempo esperado
            int[]? nuevoTrabajo = new int[2]; //cantidad de paginas / tiempo esperado
            
            int esperaTotal = 0;
            int trabajosAtendidos = 0;

            int contMaximaRafaga = 0;
            int i = 0;

            while (i < tiempoMinutos) //Simulacion de 1 hora = 60 minutos = 3600 segundos
            { 
                if (rand.NextDouble() < 0.2)
                {
                    nuevoTrabajo[0] = rand.Next(1, 101); 
                    nuevoTrabajo[1] = 0; //tiempo de espera inicial

                    cola.Insertar(nuevoTrabajo);
                    Console.WriteLine($"{i}: Llego un nuevo trabajo con {nuevoTrabajo[0]} paginas");
                    nuevoTrabajo = new int[2]; //reiniciamos el array para el proximo trabajo. IMPORTANTE porque sino el nodo a trabajar tiene 2 referencias
                }
                
                
                
                if (trabajoActual == null) // No hay trabajo siendo procesado
                {
                    if (cola.isEmpty())
                    {
                        i++;
                        Console.WriteLine($"{i}: No hay trabajo activo y en cola");
                        continue; //No hay trabajo para hacer. Hay que esperar que llegue un trabajo
                    }
                    trabajoActual = cola.Pop();
                    int tiempoEsperado = i - trabajoActual[1] - 3;
                    trabajoActual[1] += tiempoEsperado; //actualizamos el tiempo de espera del trabajo (tiempo actual - tiempo de la ultima vez que se ejecuto - 3 minutos que se tarda en procesar)
                    contMaximaRafaga = 0;
                    Console.WriteLine($"{i}: Se comienza a procesar un nuevo trabajo de {trabajoActual[0]} paginas");
                }

                trabajoActual[0] -= 10;
                Console.WriteLine($"{i}: Trabajando en el trabajo actual, quedan {trabajoActual[0]} paginas");


                if (trabajoActual[0] <= 0) //termino el trabajo
                {
                    trabajosAtendidos++;
                    esperaTotal += trabajoActual[1];
                    trabajoActual = null;
                    Console.WriteLine($"{i}: Se termino el trabajo");
                }
                else
                {
                    contMaximaRafaga++;
                    if (contMaximaRafaga == 3) //se cumplio la rafaga maxima
                    {
                        Console.WriteLine($"{i}: Se interrumpe el trabajo y se vuelve a encolar con {trabajoActual[0]} paginas restantes");
                        cola.Insertar(trabajoActual);
                        trabajoActual = null;
                    }
                }
                
                i++;
            }
            Console.WriteLine("Se termino el tiempo de simulacion");
            Console.WriteLine("Resultados:");
            int trabajosRestantes = 0;
            while (!cola.isEmpty())
            {
                cola.Pop();
                trabajosRestantes++;
            }

            Console.WriteLine($"Trabajos sin atender: {trabajosRestantes}");
            Console.WriteLine($"Promedio de espera de los trabajos atendidos: {(trabajosAtendidos == 0 ? 0 : (double)esperaTotal / trabajosAtendidos)} minutos en base a {trabajosAtendidos} trabajos");
            Console.WriteLine("Fin Ejercicio 7");


        }
    }
}
