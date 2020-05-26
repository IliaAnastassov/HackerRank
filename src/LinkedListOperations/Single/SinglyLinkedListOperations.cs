using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkedListOperations.Single
{
    public static class SinglyLinkedListOperations
    {
        public static SinglyLinkedListNode DeleteNode(SinglyLinkedListNode head, int position)
        {
            if (position != 0)
            {
                var current = head;
                SinglyLinkedListNode previous = null;
                for (int i = 0; i < position; i++)
                {
                    previous = current;
                    current = current.next;
                }

                previous.next = current.next;
            }
            else
            {
                head = head.next;
            }

            return head;
        }

        public static SinglyLinkedListNode Reverse(SinglyLinkedListNode head)
        {
            var current = head;
            SinglyLinkedListNode previous = null;
            SinglyLinkedListNode next;

            while (current != null)
            {
                // store the link for the next node and link the current node to the previous node
                next = current.next;
                current.next = previous;

                // set previous node to current and current to next
                previous = current;
                current = next;
            }

            return previous;
        }

        public static SinglyLinkedListNode ReverseRecursive(SinglyLinkedListNode node)
        {
            // last node or only one node
            if (node.next == null)
            {
                return node;
            }

            var head = ReverseRecursive(node.next);

            // change references for middle chain
            node.next.next = node;
            node.next = null;

            // send back new head node in every recursion
            return head;
        }

        public static SinglyLinkedListNode ReverseStack(SinglyLinkedListNode head)
        {
            var stack = new Stack<SinglyLinkedListNode>();

            // push all nodes in the stack
            var current = head;
            while (current != null)
            {
                stack.Push(current);
                current = current.next;
            }

            // store the top element of the stack as the head
            head = stack.Pop();
            current = head;
            while (stack.Any())
            {
                // build the links from head to tail
                current.next = stack.Pop();
                current = current.next;
            }
            current.next = null; // set tail's link to null

            return head;
        }

        public static IEnumerable<SinglyLinkedListNode> Traverse(SinglyLinkedListNode head)
        {
            var current = head;
            while (current != null)
            {
                yield return current;
                current = current.next;
            }
        }

        public static void PrintSinglyLinkedList(SinglyLinkedListNode node, string separator)
        {
            while (node != null)
            {
                Console.Write(node.data);
                node = node.next;

                if (node != null)
                {
                    Console.Write(separator);
                }
            }
        }

        public static void PrintReverse(SinglyLinkedListNode node)
        {
            if (node != null)
            {
                PrintReverse(node.next);
                Console.Write($"{node.data} ");
            }
        }
    }
}
