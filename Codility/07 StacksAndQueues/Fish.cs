using System.Collections.Generic;

namespace ConsoleApp1._07_StacksAndQueues
{
    class Fish
    {
        //increment the leading fish is easier
        public int bestsolution(int[] A, int[] B)
        {
            if (A.Length == 0) return 0;
            if (A.Length == 1) return 1;

            Stack<int> aliveFishes = new Stack<int>();

            for (int i = 0; i < A.Length; i++)
            {
                if (aliveFishes.Count == 0)
                {
                    aliveFishes.Push(i);
                }
                else
                {
                    while (aliveFishes.Count > 0
                        && B[aliveFishes.Peek()] > B[i]
                        && A[aliveFishes.Peek()] < A[i])
                    {
                        aliveFishes.Pop();
                    }

                    if (aliveFishes.Count == 0
                        || B[aliveFishes.Peek()] <= B[i])
                    {
                        aliveFishes.Push(i);
                    }
                }
            }

            return aliveFishes.Count;
        }

        public int solution(int[] A, int[] B)
        {
            if (A.Length == 0) return 0;
            if (A.Length == 1) return 1;

            Stack<int> alliveFishes = new Stack<int>();

            bool noMoreEncounters = false;
            int leftFish = 0;
            int rightFish = 1;

            while (!noMoreEncounters)
            {
                //Check for encounter
                if (B[leftFish] == 1 && B[rightFish] == 0)
                {
                    //Left fish eats right fish
                    if (A[leftFish] > A[rightFish])
                    {
                        rightFish++;
                    }
                    //Right fish eats left fish
                    else
                    {
                        //No more fishes to the left, move to the next fish
                        if (alliveFishes.Count == 0)
                        {
                            leftFish = rightFish;
                            rightFish++;
                        }
                        //Check with the last alive fish
                        else
                        {
                            if (alliveFishes.Count > 0)
                            {
                                leftFish = alliveFishes.Pop();
                            }
                            else
                            {
                                leftFish = rightFish;
                                rightFish++;
                            }
                        }
                    }
                }
                else
                {
                    alliveFishes.Push(leftFish);
                    leftFish = rightFish;
                    rightFish++;
                }

                if (rightFish >= A.Length)
                {
                    alliveFishes.Push(leftFish);
                    noMoreEncounters = true;
                }
            }

            return alliveFishes.Count;
        }
    }
}
