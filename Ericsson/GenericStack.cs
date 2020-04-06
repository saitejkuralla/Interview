using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ericsson
{
    // Last in First Out
    public class GenericStack<T>
    {
        T[] inputData;
        int size = 5;
        int currentCursorPosition = 0;
        public GenericStack()
        {
            inputData = new T[size];
        }

        public void Push(T data)
        {
            if (currentCursorPosition == inputData.Length)
                ResizeArray();
            inputData[currentCursorPosition++] = data;
        }

        public T Pop()
        {
            if (currentCursorPosition != 0)
            {
                currentCursorPosition--;
                T removedData = inputData[currentCursorPosition];                
                return removedData;
            }
            return default(T);
        }
        private void ResizeArray()
        {
            T[] oldData = inputData;
            size += 5;
            inputData = new T[size];
            Array.Copy(oldData, 0, inputData, 0, oldData.Length);
        }

        public void Print()
        {
            Console.WriteLine("\n");
            for (int i = 0; i < currentCursorPosition; i++)
            {
                Console.Write("\t {0}", inputData[i]);
            }            
                
        }
    }
}
