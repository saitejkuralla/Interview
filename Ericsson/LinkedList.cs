using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ericsson
{
    class LinkedList
    {
        public static void Main()
        {
            LinkedListNode rootNode = new LinkedListNode(7);
            rootNode = rootNode.AddSorted(rootNode, 6);
            rootNode = rootNode.AddSorted(rootNode, 5);
            rootNode = rootNode.AddSorted(rootNode, 8);
            rootNode = rootNode.AddSorted(rootNode, 9);
            rootNode.PrintNode(rootNode);
        }
    }

    public class LinkedListNode
    {
        public int Value;
        public LinkedListNode Next;

        public LinkedListNode(int value)
        {
            Value = value;
        }

        public LinkedListNode AddToBegining(LinkedListNode rootNode, int value)
        {
            if (rootNode == null)
                throw new Exception("Root Node cannot be Null");
            else
            {
                LinkedListNode newNode = new LinkedListNode(value);
                newNode.Next = rootNode;
                rootNode = newNode;
            }
            return rootNode;
        }

        public void AddToEnd(LinkedListNode rootNode, int value)
        {
            if (rootNode == null)
                throw new Exception("Root Node cannot be null");

            else if (rootNode.Next != null)
                AddToEnd(rootNode.Next, value);
            else if (rootNode.Next == null)
                rootNode.Next = new LinkedListNode(value);
        }

        public void PrintNode(LinkedListNode rootNode)
        {
            if (rootNode != null)
            {
                Console.Write("{0} --> \t", rootNode.Value);
                if (rootNode.Next != null)
                    PrintNode(rootNode.Next);
            }
        }

        public LinkedListNode AddSorted(LinkedListNode rootNode, int value)
        {
            if (rootNode == null)
                rootNode = new LinkedListNode(value);
            else
            {
                if (value > rootNode.Value && rootNode.Next == null) // Add
                    rootNode.Next  = new LinkedListNode(value);
                else if (rootNode.Value <= value)                
                    AddSorted(rootNode.Next, value);                
                else
                {
                    LinkedListNode newNode = new LinkedListNode(value);
                    newNode.Next = rootNode;
                    rootNode = newNode;
                }
            }
            return rootNode;
        }
    }
}
