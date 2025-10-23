using ConsoleApp1.DATs;
using ConsoleApp1.DATs.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Ejs
{
    internal class Ej2BinaryConverter
    {
        public void Start()
        {
            IStack<int> stack = new PilaSecuencial(32);

            try
            {
                Console.WriteLine("Enter a decimal number to convert to binary:");
                int number = Convert.ToInt32(Console.ReadLine());

                while (number > 0)
                {
                    int aux = number % 2;
                    stack.Insert(aux);
                    number = number / 2;
                }


                Console.Write("The binary representation is: ");
                while (!stack.IsEmpty())
                {
                    int? bit = stack.Pop();
                    if (bit != null)
                        Console.Write(bit);
                }
                Console.Write('\n');
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");

            }

        }
    }
}