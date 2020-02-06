using System;
using System.Linq;

namespace ConsoleApp1
{
    class MissingInteger
    {
        public int solution(int[] A)
        {
            //Problem with sort: worst case is O(N*NlogN)
            Array.Sort(A);

            int candidate = 1;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] < 1)
                    continue;

                if (A[i] == candidate - 1)
                    continue;

                if (A[i] != candidate)
                {
                    return candidate;
                }
                else
                {
                    candidate++;
                }
            }

            return candidate;
        }

        //Does not perfom whel due to the initialization of pigeon hole array
        public int solution2(int[] A)
        {
            bool[] pigeonHole = Enumerable.Repeat(false, 100000001).ToArray();

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] < 1)
                    continue;

                pigeonHole[A[i]] = true;
            }

            for (int i = 1; i < pigeonHole.Length; i++)
            {
                if (!pigeonHole[i])
                    return i;
            }

            return 1;
        }
    }
}
