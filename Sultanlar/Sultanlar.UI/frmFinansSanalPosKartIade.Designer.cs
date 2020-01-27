namespace Sultanlar.UI
{
    partial class frmFinansSanalPosKartIade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFinansSanalPosKartIade));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.txtKartNo = new System.Windows.Forms.TextBox();
            this.txtAy = new System.Windows.Forms.TextBox();
            this.txtYil = new System.Windows.Forms.TextBox();
            this.txtCv2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnYap = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTutar = new System.Windows.Forms.TextBox();
            this.txtSipNo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(-1, 203);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(831, 20);
            this.webBrowser1.TabIndex = 0;
            // 
            // txtKartNo
            // 
            this.txtKartNo.Location = new System.Drawing.Point(109, 80);
            this.txtKartNo.MaxLength = 16;
            this.txtKartNo.Name = "txtKartNo";
            this.txtKartNo.Size = new System.Drawing.Size(94, 20);
            this.txtKartNo.TabIndex = 1;
            // 
            // txtAy
            // 
            this.txtAy.Location = new System.Drawing.Point(109, 106);
            this.txtAy.MaxLength = 2;
            this.txtAy.Name = "txtAy";
            this.txtAy.Size = new System.Drawing.Size(44, 20);
            this.txtAy.TabIndex = 1;
            // 
            // txtYil
            // 
            this.txtYil.Location = new System.Drawing.Point(159, 106);
            this.txtYil.MaxLength = 2;
            this.txtYil.Name = "txtYil";
            this.txtYil.Size = new System.Drawing.Size(44, 20);
            this.txtYil.TabIndex = 1;
            // 
            // txtCv2
            // 
            this.txtCv2.Location = new System.Drawing.Point(109, 132);
            this.txtCv2.MaxLength = 3;
            this.txtCv2.Name = "txtCv2";
            this.txtCv2.Size = new System.Drawing.Size(44, 20);
            this.txtCv2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kart Numarası:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Son Kul. (Ay/Yıl):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "cv2:";
            // 
            // btnYap
            // 
            this.btnYap.Location = new System.Drawing.Point(16, 174);
            this.btnYap.Name = "btnYap";
            this.btnYap.Size = new System.Drawing.Size(187, 23);
            this.btnYap.TabIndex = 3;
            this.btnYap.Text = "İade Yap";
            this.btnYap.UseVisualStyleBackColor = true;
            this.btnYap.Click += new System.EventHandler(this.btnYap_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Sipariş No:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Ödenecek Tutar:";
            // 
            // txtTutar
            // 
            this.txtTutar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTutar.ForeColor = System.Drawing.Color.DarkRed;
            this.txtTutar.Location = new System.Drawing.Point(109, 38);
            this.txtTutar.MaxLength = 100;
            this.txtTutar.Name = "txtTutar";
            this.txtTutar.ReadOnly = true;
            this.txtTutar.Size = new System.Drawing.Size(94, 13);
            this.txtTutar.TabIndex = 1;
            // 
            // txtSipNo
            // 
            this.txtSipNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSipNo.ForeColor = System.Drawing.Color.DarkRed;
            this.txtSipNo.Location = new System.Drawing.Point(109, 13);
            this.txtSipNo.MaxLength = 100;
            this.txtSipNo.Name = "txtSipNo";
            this.txtSipNo.ReadOnly = true;
            this.txtSipNo.Size = new System.Drawing.Size(94, 13);
            this.txtSipNo.TabIndex = 1;
            // 
            // frmFinansSanalPosKartIade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 224);
            this.Controls.Add(this.btnYap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtYil);
            this.Controls.Add(this.txtCv2);
            this.Controls.Add(this.txtAy);
            this.Controls.Add(this.txtSipNo);
            this.Controls.Add(this.txtTutar);
            this.Controls.Add(this.txtKartNo);
            this.Controls.Add(this.webBrowser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmFinansSanalPosKartIade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kart İade";
            this.Load += new System.EventHandler(this.frmFinansSanalPosKartIade_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox txtKartNo;
        private System.Windows.Forms.TextBox txtAy;
        private System.Windows.Forms.TextBox txtYil;
        private System.Windows.Forms.TextBox txtCv2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnYap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTutar;
        private System.Windows.Forms.TextBox txtSipNo;
    }
}