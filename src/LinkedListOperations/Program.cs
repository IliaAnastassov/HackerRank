using System;

namespace LinkedListOperations
{
    public class Program
    {
        public static void Main()
        {
            var linkedList = new SinglyLinkedList();
            linkedList.InsertNode(0);
            linkedList.InsertNode(1);
            linkedList.InsertNode(2);
            linkedList.InsertNode(3);
            linkedList.InsertNode(4);
            linkedList.InsertNode(5);

            var head = ReverseRecursive(linkedList.Head);
            PrintSinglyLinkedList(head, " ");
        }

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
                // Store the link for the next node and link the current node to the previous node
                next = current.next;
                current.next = previous;

                // Set previous node to current and current to next
                previous = current;
                current = next;
            }

            return previous;
        }

        public static SinglyLinkedListNode ReverseRecursive(SinglyLinkedListNode node)
        {
            if (node == null)
            {
                return node;
            }

            // Last node or only one node
            if (node.next == null)
            {
                return node;
            }

            var head = ReverseRecursive(node.next);

            // Change references for middle chain
            node.next.next = node;
            node.next = null;

            // Send back new head node in every recursion
            return head;
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

    public class SinglyLinkedListNode
    {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int nodeData)
        {
            data = nodeData;
            next = null;
        }
    }

    public class SinglyLinkedList
    {
        public SinglyLinkedListNode Head;
        public SinglyLinkedListNode Tail;

        public SinglyLinkedList()
        {
            Head = null;
            Tail = null;
        }

        public void InsertNode(int nodeData)
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

            if (Head == null)
            {
                Head = node;
            }
            else
            {
                Tail.next = node;
            }

            Tail = node;
        }
    }
}
