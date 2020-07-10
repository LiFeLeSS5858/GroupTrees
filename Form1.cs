using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace Практика
{
    public partial class Form1 : Form
    {
        public string filename; // all file's words in one text 
        public string myfile; // files's words in list
        public string str="";
        public Form1()
        {
            InitializeComponent();
        }

        void button2_Click(object sender, EventArgs e)
        {
            int N = 25;
            double[] time = new double[N];
            double tmin=300000, tmax=0, tmed=0, median=0,sum=0;
            for (int j = 0; j < N; j++)
            {
                System.Diagnostics.Stopwatch watch; // объявляем метод 
                long elapsedMs; // объявляем переменную 
                watch = System.Diagnostics.Stopwatch.StartNew(); // запускаем таймер 
                var listtree = new ListTree();
                str = "";
                foreach (var i in myfile)
                {
                    if (i >= 'a' && i <= 'z' || i >= 'A' && i <= 'Z' || i == '\'')
                        str += i;
                    else if (str.Length > 0)
                    {
                        if (listtree.ContainsKey(str))
                            ++listtree[str];
                        else
                            listtree.Add(str, 1);
                        str = "";
                    }
                }
                watch.Stop(); // останавливаем таймер 
                elapsedMs = watch.ElapsedMilliseconds; // присваиваем значение времени 
                time[j] = (int)elapsedMs; // добавляем в массив

            }
            for (int i = 0; i < N; i++)
            {
                if(time[i]<tmin)
                {
                    tmin = time[i];
                }
                if (time[i] > tmax)
                {
                    tmax = time[i];
                }
                sum += time[i];
            }
            tmed = (tmax + tmin) / 2;
            median = sum / N;
            chart1.Series["ListTree"].Points.AddXY(1,tmin,tmax,((tmed+tmin)/2), ((tmed + tmax) / 2), tmed);
        }

        void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog() { Filter = "Текстовые файлы(*.txt)|*.txt" };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                myfile = File.ReadAllText(filename);            
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            int N = 25;
            double[] time = new double[N];
            double tmin = 300000, tmax = 0, tmed = 0, median = 0, sum = 0;
            for (int j = 0; j < N; j++)
            {
                System.Diagnostics.Stopwatch watch; // объявляем метод 
                long elapsedMs; // объявляем переменную 
                watch = System.Diagnostics.Stopwatch.StartNew(); // запускаем таймер 
                var dictionarytree = new DictionaryTree();
                str = "";
                foreach (var i in myfile)
                {
                    if (i >= 'a' && i <= 'z' || i >= 'A' && i <= 'Z' || i == '\'')
                        str += i;
                    else if (str.Length > 0)
                    {
                        if (dictionarytree.ContainsKey(str))
                            ++dictionarytree[str];
                        else
                            dictionarytree.Add(str, 1);
                        str = "";
                    }
                }
                watch.Stop(); // останавливаем таймер 
                elapsedMs = watch.ElapsedMilliseconds; // присваиваем значение времени 
                time[j] = (int)elapsedMs; // добавляем в массив

            }
            for (int i = 0; i < N; i++)
            {
                if (time[i] < tmin)
                {
                    tmin = time[i];
                }
                if (time[i] > tmax)
                {
                    tmax = time[i];
                }
                sum += time[i];
            }
            tmed = (tmax + tmin) / 2;
            median = sum / N;
            chart1.Series["DictionaryTree"].Points.AddXY(4, tmin, tmax, ((tmed + tmin) / 2), ((tmed + tmax) / 2), tmed);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            int N = 25;
            double[] time = new double[N];
            double tmin = 300000, tmax = 0, tmed = 0, median = 0, sum = 0;
            for (int j = 0; j < N; j++)
            {
                System.Diagnostics.Stopwatch watch; // объявляем метод 
                long elapsedMs; // объявляем переменную 
                watch = System.Diagnostics.Stopwatch.StartNew(); // запускаем таймер 
                var linkedtree = new LinkedTree();
                str = "";
                foreach (var i in myfile)
                {
                    if (i >= 'a' && i <= 'z' || i >= 'A' && i <= 'Z' || i == '\'')
                        str += i;
                    else if (str.Length > 0)
                    {
                        if (linkedtree.ContainsKey(str))
                            ++linkedtree[str];
                        else
                            linkedtree.Add(str, 1);
                        str = "";
                    }
                }
                watch.Stop(); // останавливаем таймер 
                elapsedMs = watch.ElapsedMilliseconds; // присваиваем значение времени 
                time[j] = (int)elapsedMs; // добавляем в массив

            }
            for (int i = 0; i < N; i++)
            {
                if (time[i] < tmin)
                {
                    tmin = time[i];
                }
                if (time[i] > tmax)
                {
                    tmax = time[i];
                }
                sum += time[i];
            }
            tmed = (tmax + tmin) / 2;
            median = sum / N;
            chart1.Series["LinkedTree"].Points.AddXY(2, tmin, tmax, ((tmed + tmin) / 2), ((tmed + tmax) / 2), tmed);
        }
    }
}
