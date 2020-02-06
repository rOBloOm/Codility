namespace ConsoleApp1
{
    class FrogJmp
    {
        public int solution(int X, int[] A)
        {
            bool[] passable = new bool[X];
            for (int i = 0; i < passable.Length; i++)
                passable[i] = false;

            int leaves_remaining = X;

            for (int i = 0; i < A.Length; i++)
            {
                if (!passable[A[i] - 1])
                {
                    passable[A[i] - 1] = true;
                    leaves_remaining--;
                    if (leaves_remaining == 0)
                        return i;
                }

            }
            return -1;
        }
    }
}
