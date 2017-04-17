using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutocompleteTextboxProject
{
    public partial class MainForm : Form
    {
        private AutocompleteTextBox _textBox;
        private List<string> _valueList = new List<string>();

        public MainForm()
        {
            InitializeComponent();

            _textBox = new AutocompleteTextBox(_valueList);
            _textBox.Location = new Point(12, 12);
            _textBox.Size = new Size(157, 20);
            _textBox.ItemAdded += TextBoxItemAdded;
            Controls.Add(_textBox);
        }

        private void TextBoxItemAdded(object sender, EventArgs e)
        {
            RefreshListView();
        }

        private void RefreshListView()
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(_valueList.ToArray<object>());
        }
    }
}
