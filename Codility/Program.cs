using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] A = new int[30];

            //int leader = -1;
            //while (leader == -1)
            //{
            //    Random rnd = new Random();
            //    for (int i = 0; i < A.Length; i++)
            //    {
            //        A[i] = rnd.Next(1, 10);
            //    }

            //    Console.WriteLine(string.Join(",", A));

            //    Leader leaderp = new Leader();
            //    Console.WriteLine(leaderp.LeaderBruteforce(A));
            //}

            //int[] A = { 3, 3, 1, 1, 3, 5, 7, 3, 5, 6, 3, 3, 3, 5, 9, 10, 3, 3, 3, 3 };
            //Leader leaderp = new Leader();
            //Console.WriteLine(leaderp.LeaderWithSort(A));


            Program p = new Program();
            int[] A = { 1, 1, 3, 4, 3, 3, 4 };
            int max = p.solution(A, 2);
            Console.WriteLine($"5, {max}");

            int[] A2 = { 1, 3, 3, 2 };
            int max2 = p.solution(A2, 2);
            Console.WriteLine($"4, {max2}");

            int[] A3 = { 4, 5, 5, 4, 2, 2, 4 };
            int max3 = p.solution(A3, 0);
            Console.WriteLine($"2, {max3}");

            int[] A4 = { 4, 5, 5, 4, 5, 5, 4 };
            int max4 = p.solution(A4, 3);
            Console.WriteLine($"7, {max4}");

            int[] A5 = { 4, 2, 1, 3, 3, 3, 1, 3, 1, 1, 5, 5, 1, 1, 1, 3, 2, 2, 2 };
            int max5 = p.solution(A5, 2);
            Console.WriteLine($"7, {max5}");

            int[] A6 = { 4, 2, 1, 3, 3, 3, 1, 3, 3, 3, 3, 1, 1, 5, 5, 1, 1, 1, 3, 2, 2, 2 };
            int max6 = p.solution(A6, 2);
            Console.WriteLine($"9, {max6}");
        }

        public int solution(int[] A, int K)
        {
            if (A.Length == 0)
                return 0;

            int maxCount = 0;

            int count = 0;
            int candidate = A[0];
            int exchanges = K;
            int lastCandidatePosition = -1;

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == candidate)
                {
                    count++;
                }
                else
                {
                    if (lastCandidatePosition == -1)
                        lastCandidatePosition = i;

                    if (exchanges == 0)
                    {
                        exchanges = K;
                        count = 1;

                        if (lastCandidatePosition != -1)
                        {
                            i = lastCandidatePosition;
                            lastCandidatePosition = -1;
                        }

                        candidate = A[i];
                    }
                    else
                    {
                        if (i < A.Length - 1)
                        {
                            exchanges--;
                            count++;
                        }
                        else
                        {
                            count += Math.Min(i + 1, exchanges);
                        }
                    }
                }

                if (count > maxCount)
                {
                    maxCount = count;
                }
            }


            return maxCount;
        }
    }
}