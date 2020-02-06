using System;

namespace ConsoleApp1._07_StacksAndQueues
{
    class Triangle
    {
        public int solution(int[] A)
        {
            if (A.Length < 3)
                return 0;

            Array.Sort(A);

            for (int i = 0; i < A.Length - 2; i++)
            {
                if (A[i] + A[i + 1] > A[i + 2])
                    return 1;

                //Check for Integer overflow
                if (A[i + 2] > 0 && A[i] + A[i + 1] < 0)
                    return 1;
            }

            return 0;
        }
    }
}
