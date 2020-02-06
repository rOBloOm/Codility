namespace ConsoleApp1
{
    class PrefixSumsTemplate
    {
        private int[] BuildPrefixSum(int[] A)
        {
            int[] result = new int[A.Length];
            result[0] = A[0];

            for (int i = 1; i < A.Length; i++)
                result[i] = result[i - 1] + A[i];

            return result;
        }

        private int[] BuildPostfixSum(int[] A)
        {
            int[] result = new int[A.Length];
            result[A.Length - 1] = A[A.Length - 1];
            for (int i = A.Length - 2; i >= 0; i--)
                result[i] = A[i] + result[i + 1];

            return result;
        }
    }
}
