﻿using System;
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
                _body = "SELECT COUNT(*)\n";
                _body += "FROM table\n";
                _body += "WHERE Field_1 = @Field_1\n";
                _body += "AND Field_2 = @Field_2\n";
                _body += "AND Field_3 = @Field_3";
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
