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

            var head = Reverse(linkedList.Head);
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

        public static void ReversePrint(SinglyLinkedListNode head)
        {
            if (head != null)
            {
                ReversePrint(head.next);
                Console.WriteLine(head.data);
            }
        }

        public static SinglyLinkedListNode Reverse(SinglyLinkedListNode head)
        {
            var current = head;
            SinglyLinkedListNode previous = null;
            SinglyLinkedListNode next;

            while (current != null)
            {
                next = current.next;
                current.next = previous;
                previous = current;
                current = next;
            }

            return previous;
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
