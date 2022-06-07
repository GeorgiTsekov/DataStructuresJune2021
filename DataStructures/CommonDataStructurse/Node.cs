namespace CommonDataStructurse
{
    public class Node<T>
    {
        public Node(T value, Node<T> leftChild = null, Node<T> rightChild = null)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T Value { get; set; }

        public Node<T> LeftChild { get; set; }

        public Node<T> RightChild { get; set; }
    }
}
