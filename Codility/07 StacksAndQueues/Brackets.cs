using System.Collections.Generic;

namespace ConsoleApp1._07_StacksAndQueues
{
    class Brackets
    {
        public int solution(string S)
        {
            if (string.IsNullOrEmpty(S))
                return 1;

            if (!S.StartsWith("(") && !S.StartsWith("[") && !S.StartsWith("{"))
                return 0;

            Stack<char> validationStack = new Stack<char>();

            foreach (char current in S)
            {
                if (IsPush(current))
                {
                    validationStack.Push(current);
                }
                else
                {
                    if (validationStack.Count == 0)
                        return 0;

                    char last = validationStack.Pop();
                    if (!IsValidPop(current, last))
                    {
                        return 0;
                    }
                }
            }

            if (validationStack.Count == 0)
            {
                return 1;
            }

            return 0;
        }

        private bool IsPush(char c)
        {
            return c == '(' || c == '[' || c == '{';
        }

        private bool IsValidPop(char current, char last)
        {
            if (last == '(' && current == ')') return true;
            if (last == '[' && current == ']') return true;
            if (last == '{' && current == '}') return true;

            return false;
        }
    }
}
