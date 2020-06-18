using System;

namespace Offer
{
    public class QuickSort
    {
        public int[] ExecuteSort(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (array.Length == 0)
                return array;

            SortCore(array, 0, array.Length - 1);
            return array;
        }

        private void SortCore(int[] array, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
                return;

            int partition = Partition(array, startIndex, endIndex);

            SortCore(array, startIndex, partition - 1);
            SortCore(array, partition + 1, endIndex);
        }

        private int Partition(int[] array, int startIndex, int endIndex)
        {
            int leftIndex = startIndex, rightIndex = endIndex - 1;
            while (leftIndex <= rightIndex)
            {
                if (array[leftIndex] < array[endIndex])
                {
                    leftIndex++;
                }
                else
                {
                    Swap(ref array[leftIndex], ref array[rightIndex]);
                    rightIndex--;
                }
            }

            Swap(ref array[leftIndex], ref array[endIndex]);
            return leftIndex;
        }

        private void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }
    }
}
