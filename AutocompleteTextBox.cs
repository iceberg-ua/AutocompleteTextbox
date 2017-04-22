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
        List<string> _valueList;

        public event EventHandler ItemAdded;

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

        #region Properties

        public List<string> ValueList
        {
            get { return _valueList; }
            set { _valueList = value; }
        }

        #endregion

        #region Helpers functions

        private void AddValueToList(string value)
        {
            if (value == string.Empty)
                return;

            _valueList.Add(value);
            ItemAdded?.Invoke(this, null);
        }

        #endregion

        #region Events handling

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

        #endregion
    }
}
