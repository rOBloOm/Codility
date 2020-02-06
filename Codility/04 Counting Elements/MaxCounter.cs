using System;

namespace ConsoleApp1
{
    class MaxCounter
    {
        public int[] solution(int N, int[] A)
        {
            int[] counters = new int[N];
            for (int i = 0; i < counters.Length; i++)
                counters[i] = 0;

            int maxCounter = 0;
            int lastUpdate = 0;
            foreach (int i in A)
            {
                if (i <= N)
                {
                    if (counters[i - 1] < lastUpdate)
                    {
                        counters[i - 1] = lastUpdate + 1;
                    }
                    else
                    {
                        counters[i - 1]++;
                    }
                    maxCounter = Math.Max(maxCounter, counters[i - 1]);
                }
                else
                {
                    lastUpdate = maxCounter;
                }
            }

            for (int i = 0; i < counters.Length; i++)
            {
                if (counters[i] < lastUpdate)
                    counters[i] = lastUpdate;
            }

            return counters;
        }
    }
}
