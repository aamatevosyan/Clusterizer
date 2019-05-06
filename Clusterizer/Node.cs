using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clusterizer
{
    /// <summary>
    /// Класс Дерева
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        /// <summary>
        /// Контент
        /// </summary>
        /// <value>
        public T Contents { get; set; }
        /// <summary>
        /// Поддерева
        /// </summary>
        public List<Node<T>> ChildrenNodes { get; set; }

        /// <summary>
        /// Конструктор класса <see cref="Node{T}"/>.
        /// </summary>
        /// <param name="contents">Контент</param>
        public Node(T contents)
        {
            Contents = contents;
            ChildrenNodes = new List<Node<T>>();
        }

        /// <summary>
        /// Конструктор класса <see cref="Node{T}"/>.
        /// </summary>
        /// <param name="child0">Первое поддерево</param>
        /// <param name="child1">Второе поддерево</param>
        public Node(Node<T> child0, Node<T> child1)
        {
            Contents = default(T);

            ChildrenNodes = new List<Node<T>>();
            ChildrenNodes.Add(child0);
            ChildrenNodes.Add(child1);
        }
    }
}
