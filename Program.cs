using System;
using System.Windows.Forms;

interface IPrefix
{
    int Count { get; }                    // количество уникальных ключей в словаре
    bool ContainsKey(string Key);         // определяет, содержится ли указанный ключ в словаре
    void Add(string Key, int Value);      // добавляет указанные ключ и значение в словарь
    int this[string Key] { set; get; }    // возвращает или задает значение с указанным ключом
}

namespace Практика
{
    

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
