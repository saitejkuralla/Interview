using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ericsson
{
    class RansomNote
    {
       public static void checkMagazine(string[] magazine, string[] note)
        {
            Array.Sort(note);
            Array.Sort(magazine);

            if (note.Length > magazine.Length)
            {
                Console.Write("No");
                return;
            }

            bool isResult = true;
            Dictionary<string, int> notes = new Dictionary<string, int>();

            foreach (var input in note)
            {
                if (notes.ContainsKey(input))
                    notes[input]++;
                else
                    notes.Add(input, 1);
            }

            int iCount = 0;
            foreach (var input in magazine)
            {
                if (notes.ContainsKey(input))
                {
                    notes[input] = notes[input] - 1;                    
                    iCount++;
                    if (iCount == notes.Count)
                        break;
                }
            }

            if (isResult)
            {
                foreach (var item in notes)
                {
                    if (item.Value > 0)
                    {
                        isResult = false;
                        break;
                    }
                }
            }

            if (isResult) Console.Write("Yes"); else Console.Write("No");

        }

        static void Main(string[] args)
        {           
            
            string[] magazine = "apgo clm w lxkvg mwz elo bg elo lxkvg elo apgo apgo w elo bg".Split(' ');

            string[] note = "elo lxkvg bg mwz clm w".Split(' ');

            checkMagazine(magazine, note);
        }
    }
}
