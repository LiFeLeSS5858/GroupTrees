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
            Stopwatch[] time= null;
            Stopwatch watch1 = new Stopwatch();
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

            chart1.Series["ListTree"].Points.AddXY(0, 0.1, 1, watch1,1);
            label1.Text = Convert.ToString(myfile.Length);
            label2.Text = Convert.ToString(listtree.Count);
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
            Stopwatch[] time = null;
            Stopwatch watch1 = new Stopwatch();
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

            chart1.Series["DictionaryTree"].Points.AddXY(0, 0.1, 1, watch1, 1);
            label1.Text = Convert.ToString(myfile.Length);
            label2.Text = Convert.ToString(dictionarytree.Count);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Stopwatch[] time = null;
            Stopwatch watch1 = new Stopwatch();
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

            chart1.Series["LinkedTree"].Points.AddXY(0, 0.1, 1, watch1, 1);
            label1.Text = Convert.ToString(myfile.Length);
            label2.Text = Convert.ToString(linkedtree.Count);
        }
    }
}
