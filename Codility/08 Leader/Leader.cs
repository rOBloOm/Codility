using System;
using System.Collections.Generic;

namespace ConsoleApp1._08_Leader
{
    class Leader
    {
        //Sorting the array first O(NLogN)
        public int LeaderWithSort(int[] A)
        {
            Array.Sort(A);

            int startIndex = A.Length / 2;
            int candidate = A[startIndex];
            int count = 0;

            for (int i = startIndex; i > 0; i--)
            {
                if (A[i] == candidate)
                {
                    count++;
                    if (count > A.Length / 2)
                        return candidate;
                }
                else
                {
                    break;
                }
            }

            for (int i = startIndex + 1; i < A.Length; i++)
            {
                if (A[i] == candidate)
                {
                    count++;
                    if (count > A.Length / 2)
                        return candidate;
                }
                else
                {
                    break;
                }
            }

            return -1;
        }

        //Bruteforce O(n**2);
        public int LeaderBruteforce(int[] A)
        {
            HashSet<int> checkedList = new HashSet<int>();

            for (int i = 0; i < A.Length; i++)
            {
                if (checkedList.Contains(A[i]))
                    continue;

                checkedList.Add(A[i]);

                int count = 0;
                for (int j = 0; j < A.Length; j++)
                {
                    if (A[j] == A[i]) count++;
                    if (count > A.Length / 2)
                        return A[i];
                }
            }

            return -1;
        }
    }
}
