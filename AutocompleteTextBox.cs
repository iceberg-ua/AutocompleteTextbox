using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutocompleteTextboxProject
{
    public partial class AutocompleteTextBox : TextBox
    {
        public event EventHandler ItemAdded;

        List<string> _valueList;

        #region Contruction

        public AutocompleteTextBox()
            : base()
        {
            InitializeComponent();
        }

        public AutocompleteTextBox(List<string> valueList)
            : this()
        {
            _valueList = valueList;
        }

        #endregion

        private void AddValueToList(string value)
        {
            if (value == string.Empty)
                return;

            _valueList.Add(value);
            ItemAdded?.Invoke(this, null);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    AddValueToList(Text);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    Text = string.Empty;
                    break;
            }

            base.OnKeyDown(e);
        }
    }
}
