using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика
{
    interface IPrefix
    {
        int Count { get; }                    // количество уникальных ключей в словаре
        bool ContainsKey(string Key);         // определяет, содержится ли указанный ключ в словаре
        void Add(string Key, int Value);      // добавляет указанные ключ и значение в словарь
        int this[string Key] { set; get; }    // возвращает или задает значение с указанным ключом

        int LeafCount { get; }  // число листьев дерева
        int InternalNodeCount { get; } // число внутренних узлов
        int SamePrefixCount(string prefix); // число слов с префиксом prefix
        List<string> SamePrefixWords(string prefix); // вывод всех слова с префиксом prefix
    }
    public class Node
    {
        public char K { set; get; } 
        public Dictionary<char, Node> childs; 
        public bool EndWord { set; get; } 
        public int value { set; get; } 

        public Node(char k) 
        {
            K = k; 
            childs = new Dictionary<char, Node>(); 
            EndWord = false; 
        }
    }
    class DictionaryTree : IPrefix
    {
        private Node root; 
        public DictionaryTree()
        {
            root = new Node(' ');
        }
        private int data = 0; 


        public int Count
        { 
            get { return root.value; } 
        }
        public int InternalNodeCount
        {
            get { data = 0; chek(root); return data; } 
        }
        public void Add(string Key, int Value)
        {
            var p = root; 
            foreach (var i in Key) 
            {
                if (!p.childs.ContainsKey(i))  
                {
                    p.childs.Add(i, new Node(i));  
                    p = p.childs[i];  
                }
                else
                    p = p.childs[i];  
            }
            if (!p.EndWord)    
                ++root.value;  
            p.EndWord = true;   
            p.value = Value;   
        }
        private void chek(Node p)
        {
            int t = 0;
            foreach (KeyValuePair<char, Node> keyValue in p.childs) 
            {
                chek(keyValue.Value); 
                if (p.childs.Count != 0) 
                {
                    data++; 
                }
            }
            if (p.childs.Count == 0) 
                t++;
            data = data - t;       
        }
        private Node FindNode(string Key)
        {
            var p = root; 
            foreach (var i in Key) 
            {
                if (!p.childs.ContainsKey(i))  
                {
                    return null; 
                }
                else
                    p = p.childs[i];  
            }
            return p; 
        }
        public bool ContainsKey(string Key)
        {
            var p = FindNode(Key);  
            return p == null ? false : p.EndWord;  
        }
        public int this[string Key]
        {
            set { Add(Key, value); } 
            get
            {
                var res = FindNode(Key); 
                if (res == null)  
                    throw new KeyNotFoundException(); 
                else
                    return res.value; 

            }
        }
        public int LeafCount { get { throw new NotImplementedException(); } }
        public int SamePrefixCount(string prefix) { throw new NotImplementedException(); }
        public List<string> SamePrefixWords(string prefix) { throw new NotImplementedException(); }
    }
}
