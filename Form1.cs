using System;
using System.IO;
using System.Windows.Forms;

namespace Практика
{
    public partial class Form1 : Form
    {
        public string filename; // Выбранный файл для чтения
        public string myfile; // слова из файла
        public string str = "";// пустое слово
        public Form1()
        {
            InitializeComponent();
        }
        public double Findup(double[] time)// Поиск верхнего квартиля
        {
            double a = 0;
            Array.Sort(time);
            double q3 = (3 / 4) * (time.Length + 1);
            Math.Truncate(q3);
            int i = Convert.ToInt32(q3);
            a = (time[i] + time[i + 2]) / 2;
            return a;
        }
        public double Finddown(double[] time)// Поиск нижнего квартиля
        {
            double a;
            Array.Sort(time);
            double q3 = (1 / 4) * (time.Length + 1);
            Math.Truncate(q3);
            int i = Convert.ToInt32(q3);
            a = (time[i] + time[i + 1]) / 2;
            return a;
        }
        public double Findmed(double[] time)// Поиск медианы
        {
            Array.Sort(time);
            double q3 = (1 / 4) * (time.Length + 1);
            Math.Truncate(q3);
            int i = Convert.ToInt32(q3);
            return time[i];
        }


        void button2_Click(object sender, EventArgs e)// создаёт List Tree и считает время создания дерева
        {
            int N = 5;// количетсво создаваемых деревьев
            double[] time = new double[N];// список времени
            for (int j = 0; j < N; j++)// запускаем цикл по созданию количетсва деревьев равное N
            {
                System.Diagnostics.Stopwatch watch1; // объявляем метод по созданию таймера
                double elapsedMs; // объявляем переменную 
                watch1 = System.Diagnostics.Stopwatch.StartNew(); // запускаем таймер 
                var listtree = new ListTree(); // создаём новое дерево List
                str = "";// первое слово пустое
                foreach (var i in myfile)// пока не кончится текстовый документ
                {
                    if (i >= 'a' && i <= 'z' || i >= 'A' && i <= 'Z' || i == '\'')// проверяем наличие символа
                        str += i;// меняем значение символа
                    else if (str.Length > 0)// если имеется символ
                    {
                        if (listtree.ContainsKey(str))// идём в конечный узел
                            ++listtree[str];// добавляем значение
                        else// иначе
                            listtree.Add(str, 1);// добавляем новое значение в дерево
                        str = "";// пустое слоло
                    }
                }
                watch1.Stop(); // останавливаем таймер 
                elapsedMs = watch1.ElapsedMilliseconds; // присваиваем значение времени 
                time[j] = elapsedMs; // добавляем в массив

            }
            Array.Sort(time);// сортируем время по возростанию
            chart1.Series["ListTree"].Points.AddXY(1, time[0], time[N - 1], Finddown(time), Findup(time), Findmed(time));//добавляем значения на график(название дерева,(осьх,минимальное,максимальное,нижний квартиль, верхний квартиль,медиана))
            label1.Text = Convert.ToString(Finddown(time));
            label2.Text = Convert.ToString(Findup(time));
            Refresh();// обновляем форму
        }

        void button1_Click(object sender, EventArgs e)// Выбор любого текстового файла с устройства
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog() { Filter = "Текстовые файлы(*.txt)|*.txt" };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                myfile = File.ReadAllText(filename);
            }
        }

        private void Button5_Click(object sender, EventArgs e)// создаёт Dictionary Tree и считает время создания дерева
        {
            int N = 5;// количетсво создаваемых деревьев
            double[] time = new double[N];// список времени
            for (int j = 0; j < N; j++)// запускаем цикл по созданию количетсва деревьев равное N
            {
                System.Diagnostics.Stopwatch watch1; // объявляем метод по созданию таймера
                double elapsedMs; // объявляем переменную 
                watch1 = System.Diagnostics.Stopwatch.StartNew(); // запускаем таймер 
                var listtree = new DictionaryTree(); // создаём новое дерево Dictionary
                str = "";// первое слово пустое
                foreach (var i in myfile)// пока не кончится текстовый документ
                {
                    if (i >= 'a' && i <= 'z' || i >= 'A' && i <= 'Z' || i == '\'')// проверяем наличие символа
                        str += i;// меняем значение символа
                    else if (str.Length > 0)// если имеется символ
                    {
                        if (listtree.ContainsKey(str))// идём в конечный узел
                            ++listtree[str];// добавляем значение
                        else// иначе
                            listtree.Add(str, 1);// добавляем новое значение в дерево
                        str = "";// пустое слоло
                    }
                }
                watch1.Stop(); // останавливаем таймер 
                elapsedMs = watch1.ElapsedMilliseconds; // присваиваем значение времени 
                time[j] = elapsedMs; // добавляем в массив

            }
            Array.Sort(time);// сортируем время по возростанию
            chart1.Series["DictionaryTree"].Points.AddXY(4, time[0], time[N - 1], Finddown(time), Findup(time), Findmed(time));//добавляем значения на график(название дерева,(осьх,минимальное,максимальное,нижний квартиль, верхний квартиль,медиана))
            label1.Text = Convert.ToString(Finddown(time));
            label2.Text = Convert.ToString(Findup(time));
            Refresh();// обновляем форму
        }

        private void Button3_Click(object sender, EventArgs e)// создаёт Linked Tree и считает время создания дерева
        {
            int N = 5;// количетсво создаваемых деревьев
            double[] time = new double[N];// список времени
            for (int j = 0; j < N; j++)// запускаем цикл по созданию количетсва деревьев равное N
            {
                System.Diagnostics.Stopwatch watch1; // объявляем метод по созданию таймера
                double elapsedMs; // объявляем переменную 
                watch1 = System.Diagnostics.Stopwatch.StartNew(); // запускаем таймер 
                var listtree = new LinkedTree(); // создаём новое дерево Linked
                str = "";// первое слово пустое
                foreach (var i in myfile)// пока не кончится текстовый документ
                {
                    if (i >= 'a' && i <= 'z' || i >= 'A' && i <= 'Z' || i == '\'')// проверяем наличие символа
                        str += i;// меняем значение символа
                    else if (str.Length > 0)// если имеется символ
                    {
                        if (listtree.ContainsKey(str))// идём в конечный узел
                            ++listtree[str];// добавляем значение
                        else// иначе
                            listtree.Add(str, 1);// добавляем новое значение в дерево
                        str = "";// пустое слоло
                    }
                }
                watch1.Stop(); // останавливаем таймер 
                elapsedMs = watch1.ElapsedMilliseconds; // присваиваем значение времени 
                time[j] = elapsedMs; // добавляем в массив

            }
            Array.Sort(time);// сортируем время по возростанию
            chart1.Series["LinkedTree"].Points.AddXY(2, time[0], time[N - 1], Finddown(time), Findup(time), Findmed(time));//добавляем значения на график(название дерева,(осьх,минимальное,максимальное,нижний квартиль, верхний квартиль,медиана))
            label1.Text = Convert.ToString(Finddown(time));
            label2.Text = Convert.ToString(Findup(time));
            Refresh();// обновляем форму
        }
    }
}
