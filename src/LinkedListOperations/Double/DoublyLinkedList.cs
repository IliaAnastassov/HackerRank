namespace LinkedListOperations.Double
{
    public class DoublyLinkedList<T>
    {
        public DoublyLinkedList()
        {
            Head = null;
            Tail = null;
        }

        public DoublyLinkedListNode<T> Head { get; set; }

        public DoublyLinkedListNode<T> Tail { get; set; }

        public void Add(T value)
        {
            var newNode = new DoublyLinkedListNode<T>(value);

            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                Tail.Next = newNode;
                newNode.Previous = Tail;
            }

            Tail = newNode;
        }

        public void Reverse()
        {
            var current = Head;
            DoublyLinkedListNode<T> temp = null;

            while (current != null)
            {
                temp = current.Previous;
                current.Previous = current.Next;
                current.Next = temp;

                current = current.Previous;
            }

            Tail = Head;

            if (temp != null)
            {
                Head = temp.Previous;
            }
        }
    }
}
