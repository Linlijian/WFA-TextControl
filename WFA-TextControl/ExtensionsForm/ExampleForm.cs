using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFA_TextControl.Extensions;

namespace WFA_TextControl.ExtensionsForm
{
    public partial class ExampleForm : Form
    {
        public ExampleForm(ExampleModel ex)
        {
            InitializeComponent();

            //set new windown title
            this.Text = !ex.ExTitle.IsNullOrEmpty() ? ex.ExTitle : ExampleType.Example;

            //set new size
            if(!ex.ExPropHeight.IsNullOrEmpty() && !ex.ExPropWidth.IsNullOrEmpty())
                this.ClientSize = new System.Drawing.Size(ex.ExPropWidth, ex.ExPropHeight);

            lblExheader.Text = !ex.ExHeader.IsNullOrEmpty() ? ex.ExHeader : ExampleType.Example;
            lblExfooter.Text = !ex.ExFooter.IsNullOrEmpty() ? ex.ExFooter : string.Empty;

            string _body = string.Empty;

            if (ex.ExType == ExampleType.SingleText)
            {
                _body = "SELECT COUNT(*)\n";
                _body += "FROM table\n";
                _body += "WHERE Field_1 = @Field_1\n";
                _body += "AND Field_2 = @Field_2\n";
                _body += "AND Field_3 = @Field_3";
                lblExbody.Text = _body;
            }
            else if (ex.ExType == ExampleType.Parameter)
            {
                _body = "1.NomalField\n";
                _body += "Field_1\n";
                _body += "Field_2\n";
                _body += "2.DBField\n";
                _body += "[Field_1],\n";
                _body += "[Field_2]\n";
                lblExbody.Text = _body;
            }
            else if (ex.ExType == ExampleType.Concut)
            {
                _body = "[Field1] [datatype](50) Null,\n";
                _body += "[Field2] [datatype](1) Not Null,\n";
                _body += "[Field3] [datatype] Null,\n";
                _body += "[Field4] [datatype] Null\n";
                lblExbody.Text = _body;
            }
            else if (ex.ExType == ExampleType.LinkReport)
            {
                _body = "http://x.x.xx.xxx/ReportServer/Parameters=false&parameter1=0&parameter0=xxx&parameter3=xxx";
                lblExbody.Text = _body;
            }


        }

        private void ExampleForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
                this.Close();
            }
        }
    }
}
