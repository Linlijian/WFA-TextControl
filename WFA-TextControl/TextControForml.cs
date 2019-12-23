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
using WFA_TextControl.ExtensionsForm;

namespace WFA_TextControl
{
    public partial class TextControForml : Form
    {
        #region Main
        private void TextControForml_Load(object sender, EventArgs e)
        {
            ckbDelLastCom.SetDisableCheckBox();
            ckbNomalField.SetDefualtCheck();
        }
        public TextControForml()
        {
            InitializeComponent();
        }
        #endregion

        #region Method
        private SplitModel SetDefualtData(SplitModel model, string mode)
        {
            if (mode == ExampleType.SingleText)
            {
                model.FirstLoop = true;
                model.StringText = txtSingleText_From.Text;
                model.TextArea = model.StringText.Replace("\r\n", "").Replace(",", "").Split(null);
                model.TextFindAll = Array.FindAll(model.TextArea, element => element.StartsWith("@", StringComparison.Ordinal));
            }
            else if (mode == ExampleType.Parameter)
            {
                if (ckbNomalField.Checked)
                {
                    model.FirstLoop = true;
                    model.StringText = txtParameter_From.Text;
                    model.TextArea = model.StringText.Replace("\r\n", " ").Split(null);
                    model.TextFindAll = model.TextArea;
                }
                else
                {
                    model.FirstLoop = true;
                    model.StringText = txtParameter_From.Text;
                    model.TextArea = model.StringText.Replace("\r\n", "").Replace(",", "").Replace("[", "").Replace("]", "").Split(null);
                    model.TextFindAll = model.TextArea.Where(a => !a.IsNullOrEmpty()).ToArray();
                }
            }

            return model;
        }
        private void FetchData2Output(SplitModel model)
        {
            try
            {
                int a = ckbAtSign.Checked ? 112 : 0;
                a += ckbComma.Checked ? 113 : 0;
                string last = model.TextFindAll.Last();

                foreach (var intem in model.TextFindAll)
                {
                    if (model.FirstLoop)
                    {
                        txtSingleText_To.Text = CaseOutput(intem, a);
                        model.FirstLoop = false;
                    }
                    else
                    {
                        txtSingleText_To.Text += CaseOutput(intem, a);
                    }

                    if (last.Equals(intem) && ckbDelLastCom.Checked)
                    {
                        DeleteLastComma();
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = "query text";
                MessageBox.Show("Check input text in format " + msg + " or null\nHelp: Lock Example!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FetchData2AddParameter(SplitModel model)
        {
            try
            {
                string last = model.TextFindAll.Last();

                foreach (var intem in model.TextFindAll)
                {
                    if (model.FirstLoop)
                    {
                        txtParameter_To.Text = CaseOutput(intem, 119);
                        model.FirstLoop = false;
                    }
                    else
                    {
                        if (!intem.IsNullOrEmpty())
                            txtParameter_To.Text += CaseOutput(intem, 119);
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = "add parameter";
                MessageBox.Show("Check input text in format " + msg + " or null\nHelp: Lock Example!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string CaseOutput(string txt, int intCase)
        {
            string t = string.Empty;
            string r = string.Empty;

            if (intCase == 112) //AtSign
            {
                t = txt + "\r\n";
            }
            else if (intCase == 0) // default
            {
                t = txt.Replace("@", "") + "\r\n";
            }
            else if (intCase == 113) // comma
            {
                t = txt.Replace("@", "") + ',' + "\r\n";
            }
            else if (intCase == 225) // comma + AtSign
            {
                //c = txt[txt.Length - 1];
                t = txt + ',' + "\r\n";
            }
            else if (intCase == 119) // AddParameter
            {
                t = "parameters.AddParameter(\"" + txt + "\"" + ", dto.Model." + txt + ");" + "\r\n";
            }

            return t;
        }
        private void DeleteLastComma()
        {
            string t = txtSingleText_To.Text;
            txtSingleText_To.Text = t.Substring(0, t.Length - 3);
        }
        #endregion       

        #region Single Text Tab
        private void btnGenSingleText_Click(object sender, EventArgs e)
        {
            var model = new SplitModel();

            SetDefualtData(model, ExampleType.SingleText);
            FetchData2Output(model);
        }
        private void ckbComma_CheckedChanged(object sender, EventArgs e)
        {
            ckbDelLastCom.SetDisableCheckBox(ckbComma);
        }
        private void btnCopySingleText_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtSingleText_To.Text);
        }
        private void lblExSingleText_Click(object sender, EventArgs e)
        {
            var ex = new ExampleModel();
            ex.ExTitle = ExampleType.Example;
            ex.ExType = ExampleType.SingleText;
            ex.ExHeader = ExampleType.SingleText + " " + ExampleType.Example;

            ExampleForm exf = new ExampleForm(ex);
            exf.Show();
        }

        private void btnGenParameter_Click(object sender, EventArgs e)
        {
            var model = new SplitModel();
            if (ckbNomalField.Checked || ckbDBField.Checked)
            {
                ckbDBField.BackColor = Color.Empty;
                ckbNomalField.BackColor = Color.Empty;

                SetDefualtData(model, ExampleType.Parameter);
                FetchData2AddParameter(model);
            }
            else
            {
                ckbDBField.BackColor = Color.Red;
                ckbNomalField.BackColor = Color.Red;
            }

        }
        private void ckbNomalField_CheckedChanged(object sender, EventArgs e)
        {
            ckbNomalField.ClearCheckBox(ckbDBField);
        }
        private void ckbDBField_CheckedChanged(object sender, EventArgs e)
        {
            ckbDBField.ClearCheckBox(ckbNomalField);
        }
        private void btnCopyParameter_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtParameter_To.Text);
        }
        private void lblExParameter_Click(object sender, EventArgs e)
        {
            var ex = new ExampleModel();
            ex.ExTitle = ExampleType.Example;
            ex.ExType = ExampleType.Parameter;
            ex.ExHeader = ExampleType.Parameter + " " + ExampleType.Example;

            ExampleForm exf = new ExampleForm(ex);
            exf.Show();
        }
        private void btnClearTab1_Click(object sender, EventArgs e)
        {
            Helper.ClearGruopBox(gboxParameter);
            Helper.ClearGruopBox(gboxSingleText);
        }
        #endregion

        #region DECLARE Tab

        #endregion

    }
}
