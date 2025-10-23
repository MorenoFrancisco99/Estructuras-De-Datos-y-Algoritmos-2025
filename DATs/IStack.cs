using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DATs
{
    /// <summary>
    /// Contract for a Stack data structure.
    /// </summary>
    /// <remarks>
    /// new LinkedStack<T>() for linked implementation.
    /// new StackSecuencial<T>(capacity) for sequential implementation.
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    internal interface IStack<T>
    {
        public void Insert(T value);
        public T? Pop();
        public T? Peek();
        public bool IsEmpty();
        public int Size();
        public void Traverse();
        public T[] GetValues();
        public void Test();
    }
}
