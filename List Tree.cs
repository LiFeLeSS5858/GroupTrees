using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика
{
    class List<T> : IPerfix<T>
    {
        private Node<T> root;
        public int Count { get; set; }
        public List()
        {
            root = new Node<T>('\0', default(T));
        }

        public void Add(string key, T data)
        {
            AddNode(key, data, root);
            Count++;
        }

        private void AddNode(string key, T data, Node<T> node)
        {
            if (string.IsNullOrEmpty(key))
            {
                if (node.Isword)
                {
                    node.Data = data;
                    node.Isword = true;
                }
            }
            else
            {
                var symbol = key[0];
                var subnode = node.TryFind(symbol);
                if (subnode != null)
                {
                    AddNode(key.Substring(1), data, subnode);
                }
                else
                {
                    var newNode = new Node<T>(key[0], data);
                    node.SubNodes.Add(key[0], newNode);
                    AddNode(key.Substring(1), data, newNode);
                }
            }
        }
        public int this[char key]
        {
            set { }
            get { return key; }
        }

        public bool Search(string key, out T value)
        {
            return SearchNode(key, root, out value);
        }

        private bool SearchNode(string key, Node<T> node, out T value)
        {
            value = default(T);
            var result = false;
            int col = 0;
            if (string.IsNullOrEmpty(key))
            {
                if (node.Isword != true)
                {
                    value = node.Data;
                    result = true;
                }
                col++;
            }
            else
            {
                var subnode = node.TryFind(key[0]);
                if (subnode != null)
                {
                    result = SearchNode(key.Substring(1), subnode, out value);
                }
            }

            return result;
        }
    }
}
