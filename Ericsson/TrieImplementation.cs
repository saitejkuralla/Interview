using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace Ericsson
{
    class TrieImplementation
    {


        static TrieNode root = new TrieNode();

        static void Main(string[] args)
        {

            int n = Convert.ToInt32(Console.ReadLine());
            for (int nItr = 0; nItr < n; nItr++)
            {
                string[] opContact = Console.ReadLine().Split(' ');
                string op = opContact[0];
                string contact = opContact[1];
                switch (op)
                {
                    case "add":
                        InsertTrieNode(contact.ToCharArray());
                        break;
                    case "find":
                        int totalCount = FindStartingWords(contact);
                        Console.WriteLine(totalCount);
                        break;
                }
            }
        }


        public static void InsertTrieNode(char[] chars)
        {
            TrieNode temproot = root;
            for (int i = 0; i < chars.Count(); i++)
            {
                TrieNode newTrie;
                if (temproot.children.Keys.Contains(chars[i]))
                    temproot = temproot.children[chars[i]];
                else
                {
                    newTrie = new TrieNode();
                    if (i == chars.Count() - 1)
                        newTrie.isEndOfWord = true;
                    temproot.children.Add(chars[i], newTrie);
                    temproot = newTrie;
                }
            }
        }

        public static int FindStartingWords(string startingWord)
        {
            int isCount = 0;            
            int iIndex = 0;
            bool isCompleted = false;
            TrieNode temprootNode = root;

            while (!isCompleted)
            {
                if (temprootNode.children.Keys.Count == 0)
                {
                    isCompleted = true;
                    break;
                }
                
                List<char> chars = new List<char>();
                if (iIndex == startingWord.Length )
                    chars.AddRange(temprootNode.children.Keys.ToArray());
                else
                    chars.Add(startingWord[iIndex++]);

                foreach(char inputChar in chars)
                {
                    TrieNode node = FindNode(inputChar, temprootNode);

                    if (node != null)
                    {
                        if (node.isEndOfWord && iIndex == startingWord.Length) isCount++;
                        temprootNode = node;
                    }
                    else
                        isCompleted = true;
                }
            }


            return isCount;
        }


        public static TrieNode FindNode(char characterToFind, TrieNode node)
        {
            TrieNode findTheNode = new TrieNode();
            if (node.children.ContainsKey(characterToFind))
                findTheNode = node.children[characterToFind];
            else
                findTheNode = null;
            return findTheNode;
        }
    }

    public class TrieNode
    {
        public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
        public bool isEndOfWord;
    }
}
