using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ericsson
{
    public class MergeSortedArray
    {
        public int[] MergeSortedArrays(int[] aSortedArray,int[] bSortedArray)
        {
            int aIndex = 0, bIndex = 0, resultIndex = 0;
            int[] result = new int[aSortedArray.Length + bSortedArray.Length];

            while (aIndex < aSortedArray.Length && bIndex < bSortedArray.Length)
            {
                if (aSortedArray[aIndex] < bSortedArray[bIndex])
                    result[resultIndex++] = aSortedArray[aIndex++];

                else if (bSortedArray[bIndex] < aSortedArray[aIndex])
                    result[resultIndex++] = bSortedArray[bIndex++];                
            }

            while (aIndex < aSortedArray.Length)
                result[resultIndex++] = aSortedArray[aIndex++];

            while(bIndex < bSortedArray.Length)
                result[resultIndex++] = bSortedArray[bIndex++];

            return result;
        }
    }
}
