using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ericsson
{
    // Less than the root Node value will be left side node and Greater than the root Node value will be right side node
    class BinarySearchTree
    {
        public static Node InsertNode(Node node, int value)
        {
            if (node == null)
                return new Node(value);

            if (value > node.value)
            {
                if (node.right == null)
                {
                    node.right = new Node(value);
                    return node;
                }
                else
                    InsertNode(node.right, value);
            }
            else if (value < node.value)
            {
                if (node.left == null)
                {
                    node.left = new Node(value);
                    return node;
                }
                else
                    InsertNode(node.left, value);
            }

            return node;
        }

        public static bool SearchNode(Node node, int value)
        {
            bool isSearch = false;
            if (node == null)
                return false;

            if (node != null && node.value == value)
                return true;

            if (value > node.value)
                SearchNode(node.right, value);
            if (value < node.value)
                SearchNode(node.left, value);

            return isSearch;
        }

        // Left - Root - Right
        public static void PrintInOrderTraversal(Node node)
        {
            if (node != null)
            {
                PrintInOrderTraversal(node.left);
                Console.Write("\t {0}", node.value);
                PrintInOrderTraversal(node.right);
            }
        }

        //Root - Left - Right
        public static void PrintPreOrderTraversal(Node node)
        {
            if (node != null)
            {
                Console.Write("\t {0}", node.value);
                PrintPreOrderTraversal(node.left);
                PrintPreOrderTraversal(node.right);
            }
        }

        // Left - Right - Root
        public static void PrintPostOrderTraversal(Node node)
        {
            if (node != null)
            {
                PrintPostOrderTraversal(node.left);
                PrintPostOrderTraversal(node.right);
                Console.Write("\t {0}", node.value);
            }
        }

        /*
         * All Level Order - 14, 5, 30, 4, 16, 15, 35
         */
        public static void PrintAllLevelOrderTraversal(Node node)
        {
            int height = HeightofTheTree(node);
            for (int i = 0; i < height; i++)
            {
                Console.WriteLine("\n");
                bool isReverse = false;
                if (i % 2 != 0) // If the Row is odd number then printing the value in reverse order
                    isReverse = true;
                PrintValues(node, i, isReverse);
            }
        }

        // Whether both the nodes are in same level or not
        public static bool CheckTwoNodesAreCousins(Node node, int aValue,int bValue)
        {
            int height = HeightofTheTree(node);

            for (int i = 0; i < height; i++)
            {
                int[] oLevelData = new int[2];               
                 FindCousinNodes(node, i,aValue,bValue, oLevelData);

                if(oLevelData[0] == aValue && oLevelData[1] == bValue)                
                    return true;
                if (oLevelData[0] == aValue || oLevelData[1] == bValue)
                    return false;
            }
            return false;
        }

        
        
        private static void FindCousinNodes(Node node,int level,int aValue,int bValue,int[] levelData)
        {
            if (node == null)
                return;

            if(level == 0)
            {
                if (aValue == node.value)
                    levelData[0] = node.value;
                if (bValue == node.value)
                    levelData[1] = node.value;
            }
            else
            {
                FindCousinNodes(node.left, level - 1, aValue,bValue, levelData);
                FindCousinNodes(node.right, level - 1, aValue, bValue, levelData);
            }
            
        }

        private static int HeightofTheTree(Node node)
        {
            if (node == null)
                return 0;

            int left = 0, right = 0;

            left = HeightofTheTree(node.left);
            right = HeightofTheTree(node.right);
            if (left > right)
                return left + 1;
            else
                return right + 1;
        }

        public static void PrintValues(Node node, int level,bool isReverse)
        {
            if (node == null)
                return;

            if (level == 0)
                Console.Write("\t {0}", node.value);
            else
            {
                if (isReverse)
                {
                    PrintValues(node.right, level - 1, isReverse);
                    PrintValues(node.left, level - 1, isReverse);
                }
                else
                {
                    PrintValues(node.left, level - 1,isReverse);
                    PrintValues(node.right, level - 1, isReverse);
                }                
            }
        }



        public static int FindTheCommonNode(Node node, int aValue, int bValue)
        {
            int commonNode = -1;

            if (aValue < node.value && bValue > node.value)
                return node.value;

            // Node Left Side
            if(aValue < node.value && bValue < node.value)
            {
                if (node.left != null && (aValue == node.left.value || bValue == node.left.value))
                    return node.value;
                else
                    commonNode = FindTheCommonNode(node.left, aValue, bValue);
            }

            //Node Right Side
            if(aValue > node.value && bValue > node.value)
            {
                if (node.right != null && (aValue == node.right.value || bValue == node.right.value))
                    return node.value;
                else
                    commonNode = FindTheCommonNode(node.right, aValue, bValue);
            }

            return commonNode;
        }

        //public static void FlatenBinaryTreeToLinkedList(Node rootNode,LinkedList linkedList)
        //{
        //    if (rootNode == null)
        //        return;

        //    FlatenBinaryTreeToLinkedList(rootNode.left,linkedList);
        //    FlatenBinaryTreeToLinkedList(rootNode.right, linkedList);                        
        //   linkedList.InsertNewNode(linkedList, rootNode.value);
            

        //}

        public static int SumofLeafNodes(Node node)
        {
            int sum = 0;
            if (node == null)
                return 0;

            if (node.left == null && node.right == null)
                return node.value;

            if (node.left != null)
                sum = sum + SumofLeafNodes(node.left);
            if (node.right != null)
                sum = sum + SumofLeafNodes(node.right);

            return sum;
        }
    }

    public class Node
    {
        public Node left;
        public Node right;
        public int value;
        public Node(int _value)
        {
            value = _value;
        }
    }

}
