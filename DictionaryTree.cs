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
        public char K { set; get; } // символ 
        public Dictionary<char, Node> childs; // список дочерних узлов  
        public bool EndWord { set; get; } // переменная для проверки конца слова 
        public int value { set; get; } // количество вхождений 

        public Node(char k) // конструктор 
        {
            K = k; // присваиваем сдантартное значение 
            childs = new Dictionary<char, Node>(); // выделям паямать под список дочерних узлов 
            EndWord = false; // присваиваем сдантартное значение 
        }
    }
    class DictionaryTree : IPrefix
    {
        private Node root; // обявляем корневой узел 
        public Tree()
        {
            root = new Node(' '); // создаем корневой узел 
        }
        private int data = 0; // объявляем переменную для подсчета внутренних узлов 


        public int Count
        {
            get { return root.value; } // счетчик уникальных слов в дереве
        }
        public int InternalNodeCount
        {
            get { data = 0; chek(root); return data; } // количество внутренних узлов 
        }
        public void Add(string Key, int Value)
        {
            var p = root; // объявляем переменную р типа Node
            foreach (var i in Key) // перебирам символы
            {
                if (!p.childs.ContainsKey(i)) // проверяем есть ли такой сивомвл в списке дочерних узлов 
                {
                    p.childs.Add(i, new Node(i)); // добавляем в символ в список 
                    p = p.childs[i]; // переходим в узел 
                }
                else
                    p = p.childs[i]; // переходим в узел 
            }
            if (!p.EndWord) // проверяем закончилось ли слово  
                ++root.value; // увеличиваем счетчик уникальных слов в дереве
            p.EndWord = true; //  помечаем узел, что он является концом слова
            p.value = Value; //  добавляем число вхождений слова в последнем узле
        }
        private void chek(Node p)
        {
            int t = 0;
            foreach (KeyValuePair<char, Node> keyValue in p.childs) //перебираем все символы в списке 
            {
                chek(keyValue.Value); // рекурсивно обходим дерево 
                if (p.childs.Count != 0) // если есть значение в узле
                {
                    data++; //увеличиваем счетчик узлов 
                }
            }
            if (p.childs.Count == 0) // проверяем у каких узлов нет потомков 
                t++;
            data = data - t; // из всех узлов вычиатем, те у которых нет потомков          
        }
        private Node FindNode(string Key)
        {
            var p = root; // объявляем переменную р типа Node
            foreach (var i in Key) // перебирам символы
            {
                if (!p.childs.ContainsKey(i)) // проверяем есть ли такой сивомвл в списке дочерних узлов 
                {
                    return null; // если нет, возвращем null
                }
                else
                    p = p.childs[i]; // если есть, переходим в узел 
            }
            return p; // возвращаем найденый узел 
        }
        public bool ContainsKey(string Key)
        {
            var p = FindNode(Key); // вызываем функцию FindNode 
            return p == null ? false : p.EndWord; // если p=null выведет False, если нет, то значение конца слова 
        }
        public int this[string Key]
        {
            set { Add(Key, value); } // добавляем слово в дерево
            get
            {
                var res = FindNode(Key); // ищем слово
                if (res == null) // проверяем есть ли оно 
                    throw new KeyNotFoundException(); // если нет, то вызываем ошибку 
                else
                    return res.value; // если да, то возвращаем количество вхождений  

            }
        }
        public int LeafCount { get { throw new NotImplementedException(); } }
        public int SamePrefixCount(string prefix) { throw new NotImplementedException(); }
        public List<string> SamePrefixWords(string prefix) { throw new NotImplementedException(); }
    }
}
