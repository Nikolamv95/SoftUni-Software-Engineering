namespace ImplementingLinkedList
{
    /// <summary>
    /// Implementing Limkled List
    /// </summary>
    public class ListNode
    {
        /// <summary>
        /// Refference to next value
        /// </summary>
        public ListNode Next { get; set; }
        /// <summary>
        /// Value of the current Node
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Create new node 
        /// </summary>
        /// <param name="value">Node value</param>
        public ListNode(int value)
        {
            this.Value = value;
        }
    }
}
