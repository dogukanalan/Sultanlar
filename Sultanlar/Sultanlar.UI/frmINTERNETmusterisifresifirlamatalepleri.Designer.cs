namespace Sultanlar.UI
{
    partial class frmINTERNETmusterisifresifirlamatalepleri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmINTERNETmusterisifresifirlamatalepleri));
            this.lbTalepler = new System.Windows.Forms.ListBox();
            this.btnSifreGonder = new System.Windows.Forms.Button();
            this.rbTalepler = new System.Windows.Forms.RadioButton();
            this.rbTaleplerPasif = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lbTalepler
            // 
            this.lbTalepler.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbTalepler.FormattingEnabled = true;
            this.lbTalepler.Location = new System.Drawing.Point(0, 0);
            this.lbTalepler.Name = "lbTalepler";
            this.lbTalepler.Size = new System.Drawing.Size(264, 212);
            this.lbTalepler.TabIndex = 0;
            // 
            // btnSifreGonder
            // 
            this.btnSifreGonder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSifreGonder.Location = new System.Drawing.Point(270, 171);
            this.btnSifreGonder.Name = "btnSifreGonder";
            this.btnSifreGonder.Size = new System.Drawing.Size(119, 29);
            this.btnSifreGonder.TabIndex = 2;
            this.btnSifreGonder.Text = "Şifre Gönder";
            this.btnSifreGonder.UseVisualStyleBackColor = true;
            this.btnSifreGonder.Click += new System.EventHandler(this.btnSifreGonder_Click);
            // 
            // rbTalepler
            // 
            this.rbTalepler.AutoSize = true;
            this.rbTalepler.Checked = true;
            this.rbTalepler.Location = new System.Drawing.Point(271, 13);
            this.rbTalepler.Name = "rbTalepler";
            this.rbTalepler.Size = new System.Drawing.Size(94, 17);
            this.rbTalepler.TabIndex = 3;
            this.rbTalepler.TabStop = true;
            this.rbTalepler.Text = "Gelen Talepler";
            this.rbTalepler.UseVisualStyleBackColor = true;
            this.rbTalepler.CheckedChanged += new System.EventHandler(this.rbTalepler_CheckedChanged);
            // 
            // rbTaleplerPasif
            // 
            this.rbTaleplerPasif.AutoSize = true;
            this.rbTaleplerPasif.Location = new System.Drawing.Point(271, 36);
            this.rbTaleplerPasif.Name = "rbTaleplerPasif";
            this.rbTaleplerPasif.Size = new System.Drawing.Size(111, 17);
            this.rbTaleplerPasif.TabIndex = 3;
            this.rbTaleplerPasif.Text = "Şifre Gönderilenler";
            this.rbTaleplerPasif.UseVisualStyleBackColor = true;
            this.rbTaleplerPasif.CheckedChanged += new System.EventHandler(this.rbTalepler_CheckedChanged);
            // 
            // frmINTERNETmusterisifresifirlamatalepleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 212);
            this.Controls.Add(this.rbTaleplerPasif);
            this.Controls.Add(this.rbTalepler);
            this.Controls.Add(this.btnSifreGonder);
            this.Controls.Add(this.lbTalepler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmINTERNETmusterisifresifirlamatalepleri";
            this.Text = "Şifre Sıfırlama Talepleri";
            this.Load += new System.EventHandler(this.frmINTERNETmusterisifresifirlamatalepleri_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbTalepler;
        private System.Windows.Forms.Button btnSifreGonder;
        private System.Windows.Forms.RadioButton rbTalepler;
        private System.Windows.Forms.RadioButton rbTaleplerPasif;
    }
}