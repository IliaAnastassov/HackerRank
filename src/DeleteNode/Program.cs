using System;

namespace DeleteNode
{
    public class Program
    {
        public static void Main()
        {
            var linkedList = new SinglyLinkedList();
            linkedList.InsertNode(0);
            linkedList.InsertNode(1);
            linkedList.InsertNode(2);

            var deleted = DeleteNode(linkedList.Head, 1);
            Console.WriteLine(deleted);
        }

        static SinglyLinkedListNode DeleteNode(SinglyLinkedListNode head, int position)
        {
            var current = head;
            SinglyLinkedListNode previous = null;
            for (int i = 0; i < position; i++)
            {
                previous = current;
                current = current.next;
            }

            previous.next = current.next;

            return current;
        }
    }

    class SinglyLinkedListNode
    {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int nodeData)
        {
            data = nodeData;
            next = null;
        }
    }

    class SinglyLinkedList
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