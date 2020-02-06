namespace ConsoleApp1._05_Prefix_Sums
{
    class PassingCars
    {
        public int solution(int[] A)
        {
            if (A.Length <= 1)
                return 0;

            int[] sums = new int[A.Length + 1];
            int counter = 0;
            for (int i = A.Length - 1; i >= 0; i--)
            {
                if (A[i] == 1)
                {
                    counter++;
                }
                sums[i] = counter;
            }

            int result = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == 0)
                {
                    result += sums[i];
                    if (result > 1000000000)
                    {
                        return -1;
                    }
                }
            }

            return result;
        }
    }
}
