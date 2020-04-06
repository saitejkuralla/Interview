using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ericsson
{
    class PossibleStringPallindrome
    {
        public void PerformStringCombinations(string input)
        {
            List<string> lStrings = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                int endPoint = 1;
                for (int j = 0; j < input.Length - i; j++)
                    lStrings.Add(input.Substring(i, endPoint++));
            }

            foreach (string inputString in lStrings)
            {
                bool isPallindromeString = IsPallindrome(inputString, 0, inputString.Length - 1);
                Console.WriteLine("{0} \t\t, IsPallindrome {1}", inputString, IsPallindrome(inputString, 0, inputString.Length - 1));
            }
        }

        private bool IsPallindrome(string inputString, int startIndex, int endIndex)
        {
            if (inputString[startIndex] != inputString[endIndex])
                return false;
            else
            {
                if (startIndex < endIndex)
                {
                    startIndex++;
                    endIndex--;
                    IsPallindrome(inputString, startIndex, endIndex);
                }
                return true;
            }
        }
    }
}
