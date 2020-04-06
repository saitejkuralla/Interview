using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ericsson
{
    // First In First Out
    class GenericQueue<T>
    {
        int size = 5;
        T[] queueData;
        int currentCursorPosition = 0;
        public GenericQueue()
        {
            queueData = new T[size];
        }

        public void Enqueue(T data)
        {
            if (currentCursorPosition == queueData.Length)
                ResizeQueue();

            queueData[currentCursorPosition] = data;
            currentCursorPosition++;
        }

        public T Dequeue()
        {
            T removedElement = queueData[0];
            Array.Copy(queueData, 1, queueData, 0, queueData.Length - 1);
            currentCursorPosition--;
            return removedElement;
        }

        private void ResizeQueue()
        {
            T[] oldQueueData = queueData;
            size += 5;
            Array.Copy(oldQueueData, 0, queueData, 0, oldQueueData.Length);
        }

        public void Print()
        {
            Console.WriteLine("\n");
            for (int i = 0; i < currentCursorPosition; i++)
            {
                Console.Write("\t {0}", queueData[i]);
            }
        }
    }
}
