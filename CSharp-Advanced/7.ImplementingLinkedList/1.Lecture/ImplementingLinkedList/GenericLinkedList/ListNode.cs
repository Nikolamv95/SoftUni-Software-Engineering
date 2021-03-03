namespace ImplementingLinkedList
{
    /// <summary>
    /// Implementing Limkled List
    /// </summary>
    public class ListNode<T>
    {
        /// <summary>
        /// Refference to next value
        /// </summary>
        public ListNode<T> Next { get; set; }
        /// <summary>
        /// Value of the current Node
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Create new node 
        /// </summary>
        /// <param name="value">Node value</param>
        public ListNode(T value)
        {
            this.Value = value;
        }
    }
}
