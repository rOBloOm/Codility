using System.Collections.Generic;

namespace ConsoleApp1._07_StacksAndQueues
{
    class Nesting
    {
        public int solution(string S)
        {
            if (string.IsNullOrEmpty(S))
                return 1;

            Stack<char> bracketStack = new Stack<char>();

            for (int i = 0; i < S.Length; i++)
            {
                if ('(' == S[i])
                {
                    bracketStack.Push(S[i]);
                }
                else
                {
                    if (bracketStack.Count == 0)
                        return 0;

                    char top = bracketStack.Pop();
                    if (S[i] == ')' && top == '(') continue;

                    return 0;
                }
            }

            if (bracketStack.Count == 0)
                return 1;

            return 0;
        }
    }
}
