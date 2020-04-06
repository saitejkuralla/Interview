using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ericsson
{

    public class CircularQueueImplementation
    {
        public static void Main()
        {
            CircularQueue<int> oCircularQueue = new CircularQueue<int>();

            oCircularQueue.Dequeue();

            oCircularQueue.Enqueue(1);
            oCircularQueue.Enqueue(2);
            oCircularQueue.Enqueue(3);


            oCircularQueue.Dequeue();
            oCircularQueue.Enqueue(4);
            oCircularQueue.Enqueue(5);
            oCircularQueue.Enqueue(6);
            //oCircularQueue.Print();        
            oCircularQueue.Dequeue();
            oCircularQueue.Dequeue();
            oCircularQueue.Dequeue();
            oCircularQueue.Enqueue(7);


            oCircularQueue.Enqueue(8);
            oCircularQueue.Enqueue(9);
            oCircularQueue.Print();
        }
    }

    public class CircularQueue<T>
    {
        int front = 0, rear = 0, size = 5, queueCount = 0;
        T[] queueData;

        public CircularQueue()
        {
            queueData = new T[size];
        }

        public void Enqueue(T data)
        {
            if (queueCount == size)
            {
                Console.WriteLine("Queue is Full");
                return;
            }

            if (front > 0 && rear == size) //cyclic
                rear = 0;

            queueData[rear++] = data;
            queueCount++;
        }

        public T Dequeue()
        {
            if (queueCount == 0)
            {
                Console.WriteLine("Queue is Empty");
                return default(T);
            }

            if (front == size && rear > 0)
                front = 0;


            T removedElement = queueData[front++];
            queueCount--;
            return removedElement;
        }

        public void Print()
        {
            if (front < rear)
            {
                for (int i = front; i < rear; i++)
                    Console.WriteLine(queueData[i]);
            }
            else if (rear <= front)
            {
                for (int i = front; i < queueData.Length; i++)
                    Console.WriteLine(queueData[i]);

                for (int i = 0; i < rear; i++)
                    Console.WriteLine(queueData[i]);
            }
        }
    }
}
