using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
// poluyan
namespace Практика
{
    interface IPerfix<T>
    {
        int Count { get; set; }                    // количество уникальных ключей в словаре
        bool Search(string Key, out T Value);         // определяет, содержится ли указанный ключ в словаре
        void Add(string Key, T data);      // добавляет указанные ключ и значение в словарь
        int this[char key] { set; get; }    // возвращает или задает значение с указанным ключом
    }
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    class Node<T>
    {
        public char Symbol { get; set; }
        public T Data { get; set; }
        public bool Isword { get; set; }


        public Dictionary<char, Node<T>> SubNodes { get; set; }

        public Node(char symbol, T data)
        {
            Symbol = symbol;
            Data = data;
            SubNodes = new Dictionary<char, Node<T>>();
        }

        public override string ToString()
        {
            return $"{Data} [{SubNodes.Count}]";
        }

        public Node<T> TryFind(char symbol)
        {
            if (SubNodes.TryGetValue(symbol, out Node<T> value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Node<T> item)
            {
                return Data.Equals(item);
            }
            else
            {
                return false;
            }
        }
    }

}
