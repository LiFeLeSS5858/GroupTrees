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

namespace Практика
{
    public partial class Form1 : Form
    {
        public string filename;
        public string[] myfile;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = Convert.ToString(myfile.Length);
        }

        private void button8_Click(object sender, EventArgs e)
        {
           
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
