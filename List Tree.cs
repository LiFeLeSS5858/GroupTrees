using System.Collections.Generic;
using System.Linq;


namespace Практика
{
    public class ListTree : IPrefix// Класс дерево
    {
        private class Node// Класс узла
        {
            public char c { set; get; }// Символ, хранимый в узле
            public List<Node> childs;// Список дочерних узлов
            public int value { set; get; }// Количество уникальных слов
            public bool isEndOfWord { set; get; } // Переменная означающая конец слово
            public Node(char ch)// Конструктор
            {
                c = ch;
                childs = new List<Node>();
                isEndOfWord = false;
            }
        }
        private Node root; // Корневой узел
        public ListTree() // Конструктор
        {
            root = new Node(' ');// Корень хранит символ ' '
        }
        public void Add(string Key, int Value)// Метод для добавления слова в дерево
        {
            var p = root;// Текущий узел - корень
            foreach (var i in Key)// Проходим циклом по символу
            {
                // находим интекс
                // в этом узле с совпадает с текущим символом i из строки Key
                int ind = p.childs.FindIndex(t => t.c == i);//Находим индекс текущего символа в списке дочерних узлов
                if (ind < 0)// Если этого символа нет в списке 
                {
                    p.childs.Add(new Node(i));// В список дочерних узлов добавляется временный узел
                    p = p.childs.Last();//Текущим становится последний добавленный в список дочерних узлов
                }
                else// Если этот символ есть в списке
                    p = p.childs[ind];// то узел с этим символом становится текущим
            }
            if (!p.isEndOfWord)// Если этот символ конец слова
                ++root.value; //Увеличиваю счётчик слов
            p.isEndOfWord = true;// Отмечаем текущий узел как конечный
            p.value = Value;// Значение текущего узла становится равным заданному

        }
        public int Count { get { return root.value; } } // Возвращает количество уникальных слов в дереве
        private Node FindNode(string Key)// Метод поиска конечного узла для слова
        {
            var p = root;// текущим становится корень
            foreach (var i in Key)// Проходим по слову
            {
                int ind = p.childs.FindIndex(t => t.c == i);// Находим индекс текущего символа в списке дочерних узлов
                if (ind < 0)// если текущего символа нет в списке дочерних узлов
                {
                    return null;// возвращаем null
                }
                else// иначе
                    p = p.childs[ind];//узел с этим символом становится текущим
            }
            return p;
        }
        public bool ContainsKey(string Key)
        {
            var p = FindNode(Key);// Находим конечный узел для введёного слова
            return p == null ? false : p.isEndOfWord;// если такого слова нет возвращает false иначе true
        }
        public int this[string Key]// возвращает или задает значение с указанным ключом
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
    }
}