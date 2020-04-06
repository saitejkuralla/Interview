using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ericsson
{
    public class GenericList<T>
    {

        T[] listData;
        int size = 5;
        int currentCursorPosition = 0;
        public GenericList()
        {            
            listData = new T[size];
        }

        public void Add(T data)
        {
            if(currentCursorPosition == size)
            {
                ResizeList();
            }
            listData[currentCursorPosition] = data;
            currentCursorPosition++;
        }

        public void Remove(T data)
        {            
            for(int i=0;i<listData.Length;i++)
            {
                if(Object.Equals(listData[i],data))
                {
                    Array.Copy(listData, i + 1, listData, i, (listData.Length - 1) - i);
                    currentCursorPosition--;                    
                    break;
                }

            }                        
        }

        private void ResizeList()
        {
            T[] oldData = listData;
            size = size + 5;
            listData = new T[size];
            Array.Copy(oldData, listData, oldData.Length);
        }

        public void PrintValues()
        {
            Console.WriteLine("\n");
            for(int i=0;i<currentCursorPosition;i++)            
                Console.Write("\t {0}", listData[i]);            
        }

    }
}
