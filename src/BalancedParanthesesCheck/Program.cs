using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParanthesesCheck
{
    public class Program
    {
        public static void Main()
        {
            var expression = "{[(a + b) * (c + d)] / (f ^ 5)} % PI";
            var isBalanced = CheckIfBalanced(expression);

            Console.WriteLine(isBalanced);
        }

        private static bool CheckIfBalanced(string expression)
        {
            var stack = new Stack<char>();

            foreach (var character in expression)
            {
                // push all opening paranthesis in the stack
                if (IsOpeningParanthesis(character))
                {
                    stack.Push(character);
                }
                // upon a closing parantheses the expression is checked whether it is balanced
                else if (IsClosingParanthesis(character))
                {
                    // if stack is empty at this point, the expression is not balanced
                    if (!stack.Any())
                    {
                        return false;
                    }

                    // pop the last opening paranthesis and check if it matches the closing one
                    var opening = stack.Pop();
                    if (!AreMatch(opening, character))
                    {
                        return false;
                    }
                }
            }

            // if the stack is not empty at this point, the expression is not balanced
            if (stack.Any())
            {
                return false;
            }

            return true;
        }

        private static bool IsOpeningParanthesis(char character)
        {
            return character == '(' || character == '[' || character == '{';
        }

        private static bool IsClosingParanthesis(char character)
        {
            return character == ')' || character == ']' || character == '}';
        }

        private static bool AreMatch(char opening, char closing)
        {
            if ((opening == '(' && closing == ')')
             || (opening == '[' && closing == ']')
             || (opening == '{' && closing == '}'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
