using System;
using System.Linq;

namespace ConsoleApp1._06_Sorting
{
    class Algorythms
    {
        public int[] SelectionSort(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < A.Length; j++)
                {
                    if (A[j] < A[minIndex])
                        minIndex = j;
                }

                if (minIndex != i)
                {
                    int mem = A[i];
                    A[i] = A[minIndex];
                    A[minIndex] = mem;
                }
            }

            return A;
        }

        public int[] CountingSort(int[] A)
        {
            int[] count = Enumerable.Repeat(0, A.Max() + 1).ToArray();

            //Create Count Array
            for (int i = 0; i < A.Length; i++)
                count[A[i]]++;

            //Add previous Counts
            for (int i = 1; i < count.Length; i++)
                count[i] += count[i - 1];

            Console.WriteLine(string.Join(",", count));

            //Fill in the result
            int[] result = new int[A.Length];
            for (int i = 0; i < A.Length; i++)
            {
                result[count[A[i]] - 1] = A[i];
                count[A[i]]--;
            }

            return result;
        }

        public int[] MergeSort(int[] A)
        {
            return RecursiveMergeSort(A);
        }

        private int[] RecursiveMergeSort(int[] A)
        {
            int[] head = A.Take(A.Length / 2).ToArray();
            int[] tail = A.Skip(A.Length / 2).ToArray();

            if (head.Length > 1)
            {
                head = RecursiveMergeSort(head);
            }

            if (tail.Length > 1)
            {
                tail = RecursiveMergeSort(tail);
            }

            return Merge(head, tail);
        }

        private int[] Merge(int[] head, int[] tail)
        {
            int[] merged = new int[head.Length + tail.Length];
            int ih = 0;
            int it = 0;
            int im = 0;

            bool isMerged = false;

            while (!isMerged)
            {
                if (head[ih] < tail[it])
                {
                    merged[im] = head[ih];
                    ih++;
                }
                else
                {
                    merged[im] = tail[it];
                    it++;
                }
                im++;

                if (ih >= head.Length)
                {
                    while (it < tail.Length)
                    {
                        merged[im] = tail[it];
                        it++;
                        im++;
                    }
                    isMerged = true;
                }

                if (it >= tail.Length)
                {
                    while (ih < head.Length)
                    {
                        merged[im] = head[ih];
                        ih++;
                        im++;
                    }
                    isMerged = true;
                }
            }

            return merged;
        }
    }
}
