using ConsoleApp1.DATs;
using ConsoleApp1.DATs.Implementation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Ejs
{
    internal class Ej3_StairClimb
    {
        public void Start()
        {

            try
            {
                Console.WriteLine("Enter the number of stairs:");
                int stairs = Convert.ToInt32(Console.ReadLine());
                IStack<int> stack = new PilaSecuencial(stairs);


            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
////Empezamos con la escalera "llena"



//1.baja un escalon
//2. Quedan escalones por subir?

//		Si
//		Puede realizar un Salto? 
//			Si-> sube2 
//			No ->sube 1
//		No
//		Imprime
//		Baja un escalon -> vueve a 1


//-------------------------------
//for i=n; i <; i--

//    stack.insert(1)

//current level = -1

//while () //TODO condicion de parada final 
//{
// if current level == n-1
// {
//	current level = -1
// }
//current level++
//stack.pop

//while (!flag)
//{
//if stack.count() +2 > n
//	stack.pop()
//	current level++
//else	

//	{
//	if ! stack.coount+2 >n
//		stack.insert(2)
//		stack.count == n?
//			print
//			stack.pop()current level times
//			!flag
//		else
//			stack.insert(1)
//			stac.count == n?
//				stack.pop current level times
//				!flag
//	else
//		stak.intert(1)
//		print
//		!flag
//	}
//}
//}
//-------------------------------------

//n = 4

//escalon actual = 3












