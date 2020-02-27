using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA_TextControl.Extensions
{
    public partial class SplitModel : StandardModel
    {
        private bool isFirst = true;
        private int outputCase = 0;
        string txt = string.Empty;
        string[] txtas = null;
        string[] txtafter = null;
        string txt_input = string.Empty;

        public bool FirstLoop
        {
            get { return isFirst; }
            set { isFirst = value; }
        }
        public bool AtSign
        {
            get { return isFirst; }
            set { isFirst = value; }
        }
        public bool Comma
        {
            get { return isFirst; }
            set { isFirst = value; }
        }
        public int OutputCase
        {
            get { return outputCase; }
            set { outputCase = value; }
        }
        public string StringText
        {
            get { return txt; }
            set { txt = value; }
        }
        public string[] TextArea
        {
            get { return txtas; }
            set { txtas = value; }
        }
        public string[] TextFindAll
        {
            get { return txtafter; }
            set { txtafter = value; }
        }
        public string TextInput
        {
            get { return txt_input; }
            set { txt_input = value; }
        }
    }
}
