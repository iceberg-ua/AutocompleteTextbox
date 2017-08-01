using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutocompleteTexboxDemo
{
    class AutocompleteTextbox : TextBox
    {
        public IEnumerable<string> SourceList { get; set; }

        protected override void WndProc(ref Message m)
        {
            bool handled = false;

            switch (m.Msg)
            {
                case (int)WinApi.WM_CHAR:
                    base.WndProc(ref m);
                    handled = true;

                    if (m.WParam == WinApi.VK_BACK || m.WParam == WinApi.VK_RETURN ||
                        m.WParam == WinApi.VK_UP || m.WParam == WinApi.VK_DOWN ||
                        m.WParam == WinApi.VK_NEXT || m.WParam == WinApi.VK_PRIOR)
                        break;

                    int selectionstart = Text.Length;
                    string currentValue = GetMatchedValueFromList();
                    if (currentValue != null)
                        Text = currentValue;
                    SelectionStart = selectionstart;
                    SelectionLength = Text.Length - selectionstart;
                    break;
                default:
                    break;
            }

            if(!handled)
                base.WndProc(ref m);
        }

        private string GetMatchedValueFromList()
        {
            try
            {
                string strPattern = "^" + Text;
                return SourceList.FirstOrDefault(item => Regex.IsMatch(item, strPattern));
            }
            catch
            {
                return null;
            }
        }
    }
}
