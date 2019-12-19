namespace WFA_TextControl.ExtensionsForm
{
    partial class ExampleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblExheader = new System.Windows.Forms.Label();
            this.lblExbody = new System.Windows.Forms.Label();
            this.lblExfooter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblExheader
            // 
            this.lblExheader.AutoSize = true;
            this.lblExheader.Font = new System.Drawing.Font("Itim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExheader.Location = new System.Drawing.Point(12, 9);
            this.lblExheader.Name = "lblExheader";
            this.lblExheader.Size = new System.Drawing.Size(0, 24);
            this.lblExheader.TabIndex = 0;
            // 
            // lblExbody
            // 
            this.lblExbody.AutoSize = true;
            this.lblExbody.Font = new System.Drawing.Font("Itim", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExbody.Location = new System.Drawing.Point(12, 50);
            this.lblExbody.Name = "lblExbody";
            this.lblExbody.Size = new System.Drawing.Size(0, 20);
            this.lblExbody.TabIndex = 0;
            // 
            // lblExfooter
            // 
            this.lblExfooter.AutoSize = true;
            this.lblExfooter.Font = new System.Drawing.Font("Itim", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExfooter.Location = new System.Drawing.Point(12, 224);
            this.lblExfooter.Name = "lblExfooter";
            this.lblExfooter.Size = new System.Drawing.Size(0, 20);
            this.lblExfooter.TabIndex = 0;
            // 
            // ExampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.lblExfooter);
            this.Controls.Add(this.lblExbody);
            this.Controls.Add(this.lblExheader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExampleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Example";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ExampleForm_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblExheader;
        private System.Windows.Forms.Label lblExbody;
        private System.Windows.Forms.Label lblExfooter;
    }
}