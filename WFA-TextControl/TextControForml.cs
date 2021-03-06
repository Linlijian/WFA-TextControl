﻿using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WFA_TextControl.Extensions;
using WFA_TextControl.ExtensionsForm;
using AutoUpdaterDotNET;

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
            AutoUpdater.Start("https://raw.githubusercontent.com/Linlijian/WFA-TextControl/master/WFA-TextControl/AutoUpdater.xml");
            lblVersion.Text = System.Windows.Forms.Application.ProductVersion.ToString();
        }
        #endregion

        #region Method
        private SplitModel SetDefualtData(SplitModel model, string mode)
        {
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
                        txtSingleText_To.DeleteLastComma();
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = "query text";
                MessageBox.Show("Check input text in format " + msg + " or null\nHelp: Lock Example!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FetchData2DDL(SplitModel model)
        {
            try
            {               
                string last = model.TextFindAll.Last();

                foreach (var intem in model.TextFindAll)
                {
                    if (model.FirstLoop)
                    {
                        txtDDLTo.Text = CaseOutput(intem, 112);
                        model.FirstLoop = false;
                    }
                    else
                    {
                        txtDDLTo.Text += CaseOutput(intem, 112);
                    }

                    if (last.Equals(intem))
                    {
                        txtDDLTo.DeleteATSign();
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = "query text";
                MessageBox.Show("Check input text in format " + msg + " or null\nHelp: Lock Example!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FetchLinkReport2Output(SplitModel model)
        {
            try
            {
                int a = 112;
                string last = model.TextFindAll.Last();

                foreach (var intem in model.TextFindAll)
                {
                    if (model.FirstLoop)
                    {
                        txtLink_to.Text = CaseOutput(intem, a);
                        model.FirstLoop = false;
                    }
                    else
                    {
                        txtLink_to.Text += CaseOutput(intem, a);
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = "Report Parameter";
                MessageBox.Show("Check input text in format " + msg + " or null\nHelp: Lock Example!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConcatData2Output(SplitModel model)
        {
            try
            {
                string last = model.TextFindAll.Last();

                foreach (var intem in model.TextFindAll)
                {
                    if (model.FirstLoop)
                    {
                        txtDECLARE_to_cur.Text = Text2Cur(intem, 114);
                        model.FirstLoop = false;
                    }
                    else
                    {
                        txtDECLARE_to_cur.Text += Text2Cur(intem, 114);
                    }

                    if (last.Equals(intem))
                    {
                        txtDECLARE_to_cur.DeleteLastComma();
                        model.StringText = txtDECLARE_to_cur.Text;
                        txtDECLARE_to_val.Text = model.StringText.Replace("@C_", "@V_");
                    }
                }

                txtDECLARE_to_val.Text = txtDECLARE_to_val.Text.ToUpper();
                txtDECLARE_to_cur.Text = txtDECLARE_to_cur.Text.ToUpper();
            }
            catch (Exception ex)
            {
                string msg = "concut";
                MessageBox.Show("Check input text in format " + msg + " or null\nHelp: Lock Example!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConcatAData2Output(SplitModel model)
        {
            try
            {
                string last = model.TextFindAll.Last();

                foreach (var intem in model.TextFindAll)
                {
                    if (model.FirstLoop)
                    {
                        txtConcatATo.Text = 'A' + intem + "\r\n";
                        model.FirstLoop = false;
                    }
                    else
                    {
                        txtConcatATo.Text += 'A' + intem + "\r\n";
                    }

                    if (last.Equals(intem))
                    {
                        txtConcatATo.Text += 'A' + intem;
                    }
                }
                
            }
            catch (Exception ex)
            {
                string msg = "concut";
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
            if (ckbNomalField.Checked || ckbDBField.Checked)
            {
                ckbDBField.BackColor = Color.Empty;
                ckbNomalField.BackColor = Color.Empty;

                var da = new baseDA();

                da.DTO.Model.FirstLoop = true;
                da.DTO.Model.StringText = txtParameter_From.Text;
                da.DTO.Model.OutputCase = ckbNomalField.Checked ? 1 : 0;
                da.DTO.Model.ExecuteType = ExampleType.Parameter;
                da.Setting(da.DTO);

                FetchData2AddParameter(da.DTO.Model);
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
        private void btnGenerateConcut_Click(object sender, EventArgs e)
        {
            var da = new baseDA();

            da.DTO.Model.FirstLoop = true;
            da.DTO.Model.StringText = txtDECLARE_to_cur.Text;
            da.DTO.Model.ExecuteType = ExampleType.Parameter;
            da.Setting(da.DTO);

            ConcatData2Output(da.DTO.Model);
        }
        private string Text2Cur(string txt, int type)
        {
            string t = string.Empty;
            if (type == 111)
            {
                t = txt + " ";
            }
            else if (type == 112)
            {
                t = txt;
            }
            else if (type == 113)
            {
                t = txt + " ";
            }
            else if (type == 114)
            {
                t = "@C_" + txt + ',' + "\r\n";
            }

            return t;
        }
        private void btnCopyCur_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtDECLARE_to_cur.Text);
        }
        private void btnCopyVal_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtDECLARE_to_val.Text);
        }
        private void btnClearTab2_Click(object sender, EventArgs e)
        {
            Helper.ClearGruopBox(gboxConcat);
        }
        private void lblExConcat_Click(object sender, EventArgs e)
        {
            var ex = new ExampleModel();
            ex.ExTitle = ExampleType.Example;
            ex.ExType = ExampleType.Concut;
            ex.ExFooter = "Example from table design";
            ex.ExHeader = ExampleType.Concut + " " + ExampleType.Example;

            ExampleForm exf = new ExampleForm(ex);
            exf.Show();
        }

        #endregion

        #region Link Report Tab
        private void btnLinkReport_Click(object sender, EventArgs e)
        {
            var da = new baseDA();

            da.DTO.Model.FirstLoop = true;
            da.DTO.Model.StringText = txtLink_from.Text;
            da.DTO.Model.ExecuteType = ExampleType.LinkReport;
            da.Setting(da.DTO);

            FetchLinkReport2Output(da.DTO.Model);
        }

        private void lblExLinkReport_Click(object sender, EventArgs e)
        {
            var ex = new ExampleModel();
            ex.ExTitle = ExampleType.Example;
            ex.ExType = ExampleType.LinkReport;
            ex.ExFooter = "Example from Link Report";
            ex.ExHeader = ExampleType.LinkReport + " " + ExampleType.Example;
            ex.ExPropHeight = 80;
            ex.ExPropWidth = 600;

            ExampleForm exf = new ExampleForm(ex);
            exf.Show();
        }
        #endregion

        #region DDLInspect
        private void btnGenerateDDL_Click(object sender, EventArgs e)
        {
            var da = new baseDA();

            da.DTO.Model.FirstLoop = true;
            da.DTO.Model.StringText = txtDDLFrom.Text;
            da.DTO.Model.ExecuteType = ExampleType.DDLInspect;
            da.Setting(da.DTO);

            FetchData2DDL(da.DTO.Model);
        }
        private void btnCopyDDL_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtDDLTo.Text);
        }
        private void btnClearTab4_Click(object sender, EventArgs e)
        {
            Helper.ClearGruopBox(gboxDDLOnInspect);
        }

        #endregion

        private void GenerateConcat_Click(object sender, EventArgs e)
        {
            var da = new baseDA();

            da.DTO.Model.FirstLoop = true;
            da.DTO.Model.StringText = txtConcatAFrom.Text;
            da.DTO.Model.ExecuteType = ExampleType.ConcutA;
            da.Setting(da.DTO);

            ConcatAData2Output(da.DTO.Model);
        }

        private void CopyConcat_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtConcatATo.Text);
        }
    }
}
