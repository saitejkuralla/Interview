using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ericsson
{
    public class GenericDictionary<K, V>
    {
        K[] keys;
        V[] values;
        int size = 5;
        int currentCursorPosition = 0;
        public GenericDictionary()
        {
            values = new V[size];
            keys = new K[size];
        }

        public void Add(K key, V value)
        {
            if (currentCursorPosition == keys.Length)
                ResizeDictionary();


            if (checkDuplicateKey(key))
            {
                keys[currentCursorPosition] = key;
                values[currentCursorPosition] = value;
                currentCursorPosition++;
            }
            else
                throw new Exception("Duplicate Key");
        }

        public bool Remove(K key)
        {
            bool isRemoved = false;
            for (int i = 0; i < keys.Length; i++)
            {
                if (Object.Equals(key, keys[i]))
                {
                    isRemoved = true;
                    Array.Copy(keys, i + 1, keys, i, keys.Length - currentCursorPosition);
                    Array.Copy(values, i + 1, values, i, values.Length - currentCursorPosition);
                    currentCursorPosition--;
                    break;
                }
            }
            return isRemoved;
        }

        public void print()
        {
            Console.WriteLine("\n");
            for (int i = 0; i < currentCursorPosition; i++)
            {
                Console.Write("\t Key {0} Value {1}", keys[i], values[i]);
            }
        }

        public bool checkDuplicateKey(K key)
        {            

            foreach (var item in keys)
            {
                if (Object.Equals(item, key))
                    return false;
            }
            return true;
        }

        private void ResizeDictionary()
        {
            size += 5;

            K[] oldKeys = keys;
            keys = new K[size];
            Array.Copy(oldKeys, keys, oldKeys.Length);

            V[] oldValues = values;
            values = new V[size];
            Array.Copy(oldValues, values, oldValues.Length);
        }
    }
}
