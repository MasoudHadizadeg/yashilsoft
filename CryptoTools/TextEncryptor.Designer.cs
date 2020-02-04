namespace CryptoTools
{
    partial class TextEncryptor
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
            this.txtInputStr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkEncrypt = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtInputStr
            // 
            this.txtInputStr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputStr.Location = new System.Drawing.Point(62, 72);
            this.txtInputStr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtInputStr.Multiline = true;
            this.txtInputStr.Name = "txtInputStr";
            this.txtInputStr.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtInputStr.Size = new System.Drawing.Size(1204, 82);
            this.txtInputStr.TabIndex = 0;
            this.txtInputStr.Text = "Data Source=.;Initial Catalog=YashilDb;Persist Security Info=True;User ID=sa;Pass" +
    "word=salam;MultipleActiveResultSets=True";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 99);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "متن";
            // 
            // txtRes
            // 
            this.txtRes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRes.Location = new System.Drawing.Point(62, 239);
            this.txtRes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRes.Multiline = true;
            this.txtRes.Name = "txtRes";
            this.txtRes.Size = new System.Drawing.Size(1204, 82);
            this.txtRes.TabIndex = 0;
            this.txtRes.TextChanged += new System.EventHandler(this.txtRes_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 269);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "متن";
            // 
            // chkEncrypt
            // 
            this.chkEncrypt.AutoSize = true;
            this.chkEncrypt.Checked = true;
            this.chkEncrypt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEncrypt.Location = new System.Drawing.Point(62, 179);
            this.chkEncrypt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkEncrypt.Name = "chkEncrypt";
            this.chkEncrypt.Size = new System.Drawing.Size(92, 24);
            this.chkEncrypt.TabIndex = 2;
            this.chkEncrypt.Text = "رمز نگاری";
            this.chkEncrypt.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(174, 348);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(112, 35);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "تایید";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // TextEncryptor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1314, 692);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.chkEncrypt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRes);
            this.Controls.Add(this.txtInputStr);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TextEncryptor";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "رمز نگاری";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInputStr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkEncrypt;
        private System.Windows.Forms.Button btnOk;
    }
}

