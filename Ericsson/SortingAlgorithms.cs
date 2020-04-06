using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ericsson
{
    class SortingAlgorithms
    {
        public static void Main()
        {
            MergeSort oMergeSort = new MergeSort();
            int[] inputArray = { 5, 1, 9, 7,6 };
            inputArray = oMergeSort.DoMergeSort(inputArray);

            for (int i = 0; i < inputArray.Length; i++)
                Console.Write("\t {0}", inputArray[i]);
        }
    }

    public class MergeSort
    {
        public int[] DoMergeSort(int[] inputArray)
        {
            if (inputArray.Length == 1)
                return inputArray;
            int middle;

            if (inputArray.Length % 2 == 0)
                middle = inputArray.Length / 2;
            else
                middle = (inputArray.Length / 2) + 1;

            int[] left = new int[middle];
            int[] right = new int[inputArray.Length - middle];

            Array.Copy(inputArray, 0, left,0, middle);
            Array.Copy(inputArray, middle , right, 0, inputArray.Length - middle);

            left = DoMergeSort(left);
            right = DoMergeSort(right);

            inputArray = MergeSortedArray(left, right);
            return inputArray;
        }

        public int[] MergeSortedArray(int[] left,int[] right)
        {
            int leftIndex = 0, rightIndex = 0, resultIndex = 0;
            int[] result = new int[left.Length + right.Length];

            while(leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex] < right[rightIndex])
                    result[resultIndex++] = left[leftIndex++];

                else if (right[rightIndex] < left[leftIndex])
                    result[resultIndex++] = right[rightIndex++];
            }

            while (leftIndex < left.Length)
                result[resultIndex++] = left[leftIndex++];

            while (rightIndex< right.Length)
                result[resultIndex++] = right[rightIndex++];

            return result;
        }
    }

    public class QuickSort
    {
        public void DoQuickSort(int[] inputArray, int left, int right)
        {
            int pivot = Partition(inputArray, left, right);
            if (left < right)
            {
                if (pivot > 1)
                    DoQuickSort(inputArray, left, pivot - 1);
                else if (pivot + 1 < right)
                    DoQuickSort(inputArray, pivot + 1, right);
            }
        }

        public int Partition(int[] inputArray, int left, int right)
        {
            int pivotValue = inputArray[left];
            while (true)
            {
                while (inputArray[left] < pivotValue)
                    left++;

                while (inputArray[right] > pivotValue)
                    right--;

                if (left < right)
                {
                    if (inputArray[left] == inputArray[right]) return right;
                    int temp = inputArray[left];
                    inputArray[left] = inputArray[right];
                    inputArray[right] = temp;
                }
                else
                    return right;
            }
        }
    }

}
