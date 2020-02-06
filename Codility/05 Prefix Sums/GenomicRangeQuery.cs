using System;

namespace ConsoleApp1._05_Prefix_Sums
{
    class GenomicRangeQuery
    {
        //We are at 62% with this. Not Performing well
        public int[] solution(string S, int[] P, int[] Q)
        {
            int[] result = new int[P.Length];
            int[] factors = ImpactFactors(S);

            for (int i = 0; i < P.Length; i++)
            {
                int min = factors[P[i]];
                for (int y = P[i]; y <= Q[i]; y++)
                {
                    min = Math.Min(min, factors[y]);
                    if (min == 1)
                        break;
                }
                result[i] = min;
            }

            return result;
        }

        private int[] ImpactFactors(string S)
        {
            int[] factors = new int[S.Length];
            for (int i = 0; i < S.Length; i++)
            {
                factors[i] =
                      S[i] == 'A' ? 1
                    : S[i] == 'C' ? 2
                    : S[i] == 'G' ? 3 : 4;
            }

            return factors;
        }

        // 100% solution using prefix sum
        public int[] solution2(string S, int[] P, int[] Q)
        {
            int sLen = S.Length;
            int[][] arr = new int[sLen][];

            int[] result = new int[P.Length];


            for (int i = 0; i < sLen; i++)
            {
                arr[i] = new int[4];
                char c = S[i];
                if (c == 'A') arr[i][0] = 1;
                if (c == 'C') arr[i][1] = 1;
                if (c == 'G') arr[i][2] = 1;
                if (c == 'T') arr[i][3] = 1;
            }

            for (int i = 1; i < sLen; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    arr[i][j] += arr[i - 1][j];
                }
            }

            for (int i = 0; i < P.Length; i++)
            {
                int start = P[i];
                int end = Q[i];

                for (int j = 0; j < 4; j++)
                {
                    int sub = 0;
                    if (start - 1 >= 0)
                    {
                        sub = arr[start - 1][j];
                    }
                    if (arr[end][j] - sub > 0)
                    {
                        result[i] = j + 1;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
