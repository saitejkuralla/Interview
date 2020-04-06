using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ericsson
{
    class BalancedBracket
    {
        static void Main(string[] args)
        {

            string[] inputds = { "{{}(" };
            foreach (var item in inputds)
            {


                string expression = item;

                char[] bracketCharacters = expression.ToCharArray();
                Stack<char> bracketStack = new Stack<char>();
                bool isResult = true;
                foreach (char bracket in bracketCharacters)
                {
                    switch (bracket)
                    {
                        case '(':
                        case '{':
                        case '[':
                            bracketStack.Push(bracket);
                            break;
                        case ')':
                            if (bracketStack.Count == 0 || bracketStack.Peek() != '(')
                                isResult = false;
                            else
                                bracketStack.Pop();
                            break;
                        case ']':
                            if (bracketStack.Count == 0 || bracketStack.Peek() != '[')
                                isResult = false;
                            else
                                bracketStack.Pop();
                            break;
                        case '}':
                            if (bracketStack.Count == 0 || bracketStack.Peek() != '{')
                                isResult = false;
                            else
                                bracketStack.Pop();
                            break;
                    }
                    if (!isResult) break;
                }

                if (bracketStack.Count != 0) isResult = false;

                if (isResult) Console.WriteLine("YES"); else Console.WriteLine("NO");

            }
        }
    }
}
