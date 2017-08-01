using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutocompleteTexboxDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> _sourceList = new List<string>();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            FileStream fileStrm = new FileStream("source.txt", FileMode.Open, FileAccess.Read);
            StreamReader strReader = new StreamReader(fileStrm);

            while (!strReader.EndOfStream)
            {
                _sourceList.Add(strReader.ReadLine());
            }

            listBox1.DataSource = _sourceList;
            textBox1.SourceList = _sourceList;
        }
    }
}
