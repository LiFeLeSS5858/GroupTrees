using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;

namespace pre_tree3
{
    
    
        public class Tree : IPrefix // Класс дерево
        {
            public Node root; // Корневой узел
            public int leaf = 0; // Количество листьев дерева
            public Tree() // Конструктор
            {
                root = new Node(' '); // Корень хранит символ ' '
                root.parent = null;// У корневого узла, родительский узел отсутсвует

            }
            public class Node // Класс узла
            {
                public char c; // Символ, хранимый в узле
                public LinkedList<Node> childs = new LinkedList<Node>(); // Список дочерних узло (в данном случае список связанный)
                public int value; // Количество уникальных слов
                public Node parent; // Родительский узел

                public bool isEndOfWord = false; // Переменная означающая конец слово
                public Node(char ch) // Конструктор
                {
                    c = ch;
                }

                public int FindIndex(char i) // Метод определяющий идекс символа в списке дочерних узлов (Метод создавался для замены List.FindIndex)
                {
                    var ind = 0; // индекс = 0
                    foreach (var node in childs) // проходим циклом по элементам дочернего списка
                    {
                        if (node.c == i)// если символ текущего элемента равен данному символу
                        {
                            return ind; // возвращает индекс
                        }
                        ind++;
                    }
                    return -1; // По умолчанию -1
                }
            }
            public void Add(string Key, int Value) // Метод для добавления слова в дерево
            {
                var p = root; // Текущий узел - корень
                foreach (var i in Key) // Проходим циклом по слову
                {

                    int ind = p.FindIndex(i); //Находим индекс текущего символа в списке дочерних узлов

                    if (ind < 0) // Если этого символа нет в списке 
                    {
                        Node tmp = new Node(i); // Создаём временный узел
                        tmp.parent = p; // Родителем временного узла становится текущий узел
                        p.childs.AddLast(tmp); // В список дочерних узлов добавляется временный узел
                        p = p.childs.Last(); //Текущим становится последний добавленный в список дочерних узлов
                    }
                    else // Если этот символ есть в списке
                        p = p.childs.ElementAt(ind); // то узел с этим символом становится текущим
                }
                if (!p.isEndOfWord) // Если этот символ конец слова
                    ++root.value; // увеличиваю счетчик уникальных слов
                p.isEndOfWord = true; // Отмечаем текущий узел как конечный
                p.value = Value; // Значение текущего узла становится равным заданному
            }
            public int Count { get { return root.value; } } // Возвращает количество уникальных слов в дереве
            public Node FindNode(string Key) // Метод поиска конечного узла для слова
            {
                var p = root; // текущим становится корень
                foreach (var i in Key) // Проходим по слову
                {
                    int ind = p.FindIndex(i); // Находим индекс текущего символа в списке дочерних узлов

                    if (ind < 0) // если текущего символа нет в списке дочерних узлов
                        return null; // возвращаем null
                    else// иначе
                        p = p.childs.ElementAt(ind); //узел с этим символом становится текущим
                }
                return p;
            }
            public bool ContainsKey(string Key)
            {
                var p = FindNode(Key); // Находим конечный узел для введёного слова
                return p == null ? false : p.isEndOfWord; // если такого слова нет возвращает false иначе true
            }
            public int this[string Key] // возвращает или задает значение с указанным ключом
            {
                set // если задаём
                {
                    Add(Key, value); // Вызываем метод Add
                }
                get // если полуаем
                {
                    var res = FindNode(Key); //Находим конечный узел для введёного слова

                    if (res == null) // если такого слова нет 
                        throw new System.Collections.Generic.KeyNotFoundException();//вызываем ошибку
                    else
                        return res.value; // если есть, возвращаем количество вхождений
                }
            }

            public int LeafCount // число листьев дерева
            {
                get
                {
                    leaf = 0; // количество листьев = 0
                    leafCount(root);// вызываем вспомагательынй метод
                    return leaf;
                }
            }

            private void leafCount(Node curent) // вспомагательный метод для метода LeafCount
            {
                // При первом вызове метода текущий узел - корень
                if (curent.childs.Count == 0)  // если у текущего узла нет дочерних узлов
                {
                    leaf++; // Тогда это лист. Увеличиваем счётчик
                }
                else // Если есть
                {
                    foreach (var i in curent.childs) // Проходим по дочерним узлам текущего
                    {
                        leafCount(i); // вызываем метод для каждого из них
                    }
                }
            }
            // Заглушки
            public int InternalNodeCount // число внутренних узлов
            {
                get { throw new NotImplementedException(); }
            }
            public int SamePrefixCount(string prefix) // число слов с префиксом prefix
            {
                throw new NotImplementedException();
            }
            public List<string> SamePrefixWords(string prefix)
            {
                throw new NotImplementedException(); // вывод всех слова с префиксом prefix
            }


        }

    
}
