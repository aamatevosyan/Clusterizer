using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clusterizer
{
    /// <summary>
    /// Data structure of node
    /// </summary>
    /// <typeparam name="T">Item Type</typeparam>
    public class Node<T>
    {
        /// <summary>
        /// Gets or sets the contents.
        /// </summary>
        /// <value>
        /// The contents.
        /// </value>
        public T Contents { get; set; }

        /// <summary>
        /// Gets or sets the children nodes.
        /// </summary>
        /// <value>
        /// The children nodes.
        /// </value>
        public List<Node<T>> ChildrenNodes { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Node{T}"/> class.
        /// </summary>
        /// <param name="contents">The contents.</param>
        public Node(T contents)
        {
            Contents = contents;
            ChildrenNodes = new List<Node<T>>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Node{T}"/> class.
        /// </summary>
        /// <param name="child0">The child0.</param>
        /// <param name="child1">The child1.</param>
        public Node(Node<T> child0, Node<T> child1)
        {
            Contents = default(T);

            ChildrenNodes = new List<Node<T>> {child0, child1};
        }
    }
}
