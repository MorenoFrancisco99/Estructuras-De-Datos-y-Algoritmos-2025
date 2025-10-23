using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DATs
{
    internal interface ICola<T>
    {
        int Insertar(T elemento);
        T? Pop();
        bool IsFull();
        bool isEmpty();
        T Peek();
        void Show();
        void Test(IEnumerable<T> values);
    }
}
