
using System.Collections.Generic;
using System.Linq;


namespace Практика
{
    public class ListTree : IPrefix
    {
        private class Node
        {
            public char c { set; get; }
            public List<Node> childs;
            public int value { set; get; }
            public bool isEndOfWord { set; get; }
            public Node(char ch)
            {
                c = ch;
                childs = new List<Node>();
                isEndOfWord = false;
            }
        }
        private Node root;
        public ListTree()
        {
            root = new Node(' ');
        }
        public void Add(string Key, int Value)
        {
            var p = root;
            foreach (var i in Key)
            {
                // находим интекс
                // в этом узле с совпадает с текущим символом i из сьроки Key
                int ind = p.childs.FindIndex(t => t.c == i);
                if (ind < 0)
                {
                    p.childs.Add(new Node(i));
                    p = p.childs.Last();
                }
                else
                    p = p.childs[ind];
            }
            if (!p.isEndOfWord)
                ++root.value; //Увеличиваю счётчик слов
            p.isEndOfWord = true;
            p.value = Value;

        }
        public int Count { get { return root.value; } }
        private Node FindNode(string Key)
        {
            var p = root;
            foreach (var i in Key)
            {
                int ind = p.childs.FindIndex(t => t.c == i);
                if (ind < 0)
                {
                    return null;
                }
                else
                    p = p.childs[ind];
            }
            return p;
        }
        public bool ContainsKey(string Key)
        {
            var p = FindNode(Key);
            return p == null ? false : p.isEndOfWord;
        }
        public int this[string Key]
        {
            set
            {
                Add(Key, value);
            }
            get
            {
                var res = FindNode(Key);
                if (res == null)
                {
                    throw new System.Collections.Generic.KeyNotFoundException();
                }
                else
                    return res.value;
            }
        }
    }
}