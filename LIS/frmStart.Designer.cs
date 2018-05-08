namespace LIS
{
    partial class frmStart
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
            this.components = new System.ComponentModel.Container();
            this.lblCheck = new System.Windows.Forms.Label();
            this.lblSQL = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.txt4th = new System.Windows.Forms.TextBox();
            this.txt3rd = new System.Windows.Forms.TextBox();
            this.txt2nd = new System.Windows.Forms.TextBox();
            this.txt1st = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.timChecker = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblCheck
            // 
            this.lblCheck.BackColor = System.Drawing.Color.Transparent;
            this.lblCheck.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheck.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCheck.Location = new System.Drawing.Point(12, 14);
            this.lblCheck.Name = "lblCheck";
            this.lblCheck.Size = new System.Drawing.Size(648, 21);
            this.lblCheck.TabIndex = 19;
            this.lblCheck.Text = "Checking MySQL Server...";
            this.lblCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSQL
            // 
            this.lblSQL.AutoSize = true;
            this.lblSQL.BackColor = System.Drawing.Color.Transparent;
            this.lblSQL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSQL.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSQL.Location = new System.Drawing.Point(12, 14);
            this.lblSQL.Name = "lblSQL";
            this.lblSQL.Size = new System.Drawing.Size(216, 21);
            this.lblSQL.TabIndex = 10;
            this.lblSQL.Text = "Set MySQL Server IP Address:";
            this.lblSQL.Visible = false;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl1.Location = new System.Drawing.Point(307, 12);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(13, 18);
            this.lbl1.TabIndex = 18;
            this.lbl1.Text = ".";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl3.Location = new System.Drawing.Point(429, 12);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(13, 18);
            this.lbl3.TabIndex = 17;
            this.lbl3.Text = ".";
            this.lbl3.Visible = false;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl2.Location = new System.Drawing.Point(368, 12);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(13, 18);
            this.lbl2.TabIndex = 16;
            this.lbl2.Text = ".";
            // 
            // txt4th
            // 
            this.txt4th.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt4th.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt4th.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt4th.Location = new System.Drawing.Point(448, 9);
            this.txt4th.MaxLength = 3;
            this.txt4th.Name = "txt4th";
            this.txt4th.Size = new System.Drawing.Size(36, 29);
            this.txt4th.TabIndex = 14;
            this.txt4th.Visible = false;
            this.txt4th.TextChanged += new System.EventHandler(this.txt4th_TextChanged);
            this.txt4th.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt4th_KeyPress);
            // 
            // txt3rd
            // 
            this.txt3rd.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt3rd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt3rd.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt3rd.Location = new System.Drawing.Point(387, 9);
            this.txt3rd.MaxLength = 3;
            this.txt3rd.Name = "txt3rd";
            this.txt3rd.Size = new System.Drawing.Size(36, 29);
            this.txt3rd.TabIndex = 13;
            this.txt3rd.Visible = false;
            this.txt3rd.TextChanged += new System.EventHandler(this.txt3rd_TextChanged);
            this.txt3rd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt3rd_KeyPress);
            // 
            // txt2nd
            // 
            this.txt2nd.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt2nd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt2nd.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt2nd.Location = new System.Drawing.Point(326, 9);
            this.txt2nd.MaxLength = 3;
            this.txt2nd.Name = "txt2nd";
            this.txt2nd.Size = new System.Drawing.Size(36, 29);
            this.txt2nd.TabIndex = 12;
            this.txt2nd.Visible = false;
            this.txt2nd.TextChanged += new System.EventHandler(this.txt2nd_TextChanged);
            this.txt2nd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt2nd_KeyPress);
            // 
            // txt1st
            // 
            this.txt1st.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt1st.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt1st.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt1st.Location = new System.Drawing.Point(265, 9);
            this.txt1st.MaxLength = 3;
            this.txt1st.Name = "txt1st";
            this.txt1st.Size = new System.Drawing.Size(36, 29);
            this.txt1st.TabIndex = 11;
            this.txt1st.Visible = false;
            this.txt1st.TextChanged += new System.EventHandler(this.txt1st_TextChanged);
            this.txt1st.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt1st_KeyPress);
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnCheck.Enabled = false;
            this.btnCheck.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.Location = new System.Drawing.Point(500, 9);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(141, 29);
            this.btnCheck.TabIndex = 15;
            this.btnCheck.Text = "Check Server";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Visible = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(220, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(1, 1);
            this.btnClose.TabIndex = 20;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // timChecker
            // 
            this.timChecker.Interval = 1000;
            this.timChecker.Tick += new System.EventHandler(this.timChecker_Tick);
            // 
            // frmStart
            // 
            this.AcceptButton = this.btnCheck;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(672, 44);
            this.Controls.Add(this.lblCheck);
            this.Controls.Add(this.lblSQL);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.txt4th);
            this.Controls.Add(this.txt3rd);
            this.Controls.Add(this.txt2nd);
            this.Controls.Add(this.txt1st);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmStart";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmStart_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCheck;
        private System.Windows.Forms.Label lblSQL;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.TextBox txt4th;
        private System.Windows.Forms.TextBox txt3rd;
        private System.Windows.Forms.TextBox txt2nd;
        private System.Windows.Forms.TextBox txt1st;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Timer timChecker;
    }
}