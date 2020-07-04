using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Diagnostics;

namespace Практика
{
    public partial class Form1 : Form
    {
        public string filename; // all file's words in one text 
        public string[] myfile; // files's words in list
        public Form1()
        {
            InitializeComponent();
        }

        void button2_Click(object sender, EventArgs e)
        {
            Stopwatch watch1 = new Stopwatch();
            watch1.Start();
            var listtree = new List<int>();
            for (int i = 0; i < myfile.Length;i++)
            {
                listtree.Add(myfile[i],1);
            }
            watch1.Stop();
            chart1.Series["ListTree"].Points.AddXY(0, 0.1, 1, watch1);
            label1.Text = Convert.ToString(myfile.Length);      
        }

        void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog() { Filter = "Текстовые файлы(*.txt)|*.txt" };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                myfile = File.ReadAllLines(filename);            
            }
        }
    }
}
