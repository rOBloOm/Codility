using System;

namespace ConsoleApp1._06_Sorting
{
    class Distinct
    {
        public int solution(int[] A)
        {
            if (A.Length == 0)
                return 0;

            if (A.Length == 1)
                return 1;

            Array.Sort(A);

            int result = 1;
            for (int i = 1; i < A.Length; i++)
            {
                if (A[i] != A[i - 1])
                    result++;
            }

            return result;
        }
    }
}
