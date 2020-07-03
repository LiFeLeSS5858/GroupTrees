using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    
}
