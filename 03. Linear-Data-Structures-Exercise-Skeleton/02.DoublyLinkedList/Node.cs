namespace Problem02.DoublyLinkedList
{
    public class Node<T>
    {
        public Node()
        {

        }

        public Node(T item, Node<T> next, Node<T> previous)
        {
            this.Item = item;
            this.Previous = previous;
            this.Next = next;
        }

        public T Item { get; set; }

        public Node<T> Previous { get; set; }

        public Node<T> Next { get; set; }
    }
}