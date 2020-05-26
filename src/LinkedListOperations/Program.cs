using System;
using LinkedListOperations.Double;

namespace LinkedListOperations
{
    public class Program
    {
        public static void Main()
        {
            ////var linkedList = new SinglyLinkedList();
            ////linkedList.InsertNode(0);
            ////linkedList.InsertNode(1);
            ////linkedList.InsertNode(2);
            ////linkedList.InsertNode(3);
            ////linkedList.InsertNode(4);
            ////linkedList.InsertNode(5);

            ////var head = SinglyLinkedListOperations.Reverse(linkedList.Head);
            ////SinglyLinkedListOperations.PrintSinglyLinkedList(head, " ");

            var linkedList = new DoublyLinkedList<int>();
            linkedList.Add(0);
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Add(4);
            linkedList.Add(5);

            linkedList.Reverse();
            Print(linkedList);
        }

        public static void Print<T>(DoublyLinkedList<T> linkedList)
        {
            var current = linkedList.Head;
            while (current != null)
            {
                Console.Write($"{current.Value} ");
                current = current.Next;
            }
        }
    }
}
