namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            var stack = new Stack<char>();

            foreach (var parenthese in parentheses)
            {
                if (parenthese == '(' || parenthese == '[' || parenthese == '{')
                {
                    stack.Push(parenthese);
                }
                else if (parenthese == ')' || parenthese == ']' || parenthese == '}')
                {
                    if (!stack.Any())
                    {
                        return false;
                    }
                    switch (parenthese)
                    {
                        case ')':
                            if (stack.Pop() != '(')
                            {
                                return false;
                            }
                            break;
                        case ']':
                            if (stack.Pop() != '[')
                            {
                                return false;
                            }
                            break;
                        case '}':
                            if (stack.Pop() != '{')
                            {
                                return false;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            if (!stack.Any())
            {
                return true;
            }

            return false;
        }
    }
}
