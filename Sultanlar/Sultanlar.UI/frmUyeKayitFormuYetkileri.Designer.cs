namespace Sultanlar.UI
{
    partial class frmUyeKayitFormuYetkileri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUyeKayitFormuYetkileri));
            this.lbYetkisizler = new System.Windows.Forms.ListBox();
            this.lbYetkililer = new System.Windows.Forms.ListBox();
            this.cmbDurumlar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnKaldir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbYetkisizler
            // 
            this.lbYetkisizler.FormattingEnabled = true;
            this.lbYetkisizler.Location = new System.Drawing.Point(12, 12);
            this.lbYetkisizler.Name = "lbYetkisizler";
            this.lbYetkisizler.Size = new System.Drawing.Size(216, 290);
            this.lbYetkisizler.Sorted = true;
            this.lbYetkisizler.TabIndex = 0;
            this.lbYetkisizler.SelectedIndexChanged += new System.EventHandler(this.lbYetkisizler_SelectedIndexChanged);
            this.lbYetkisizler.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbYetkisizler_MouseDoubleClick);
            // 
            // lbYetkililer
            // 
            this.lbYetkililer.FormattingEnabled = true;
            this.lbYetkililer.Location = new System.Drawing.Point(472, 12);
            this.lbYetkililer.Name = "lbYetkililer";
            this.lbYetkililer.Size = new System.Drawing.Size(216, 290);
            this.lbYetkililer.Sorted = true;
            this.lbYetkililer.TabIndex = 0;
            this.lbYetkililer.SelectedIndexChanged += new System.EventHandler(this.lbYetkililer_SelectedIndexChanged);
            this.lbYetkililer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbYetkililer_MouseDoubleClick);
            // 
            // cmbDurumlar
            // 
            this.cmbDurumlar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDurumlar.FormattingEnabled = true;
            this.cmbDurumlar.Location = new System.Drawing.Point(234, 35);
            this.cmbDurumlar.Name = "cmbDurumlar";
            this.cmbDurumlar.Size = new System.Drawing.Size(232, 21);
            this.cmbDurumlar.TabIndex = 1;
            this.cmbDurumlar.SelectedIndexChanged += new System.EventHandler(this.cmbDurumlar_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(245, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "İşlemler:";
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(274, 130);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(156, 38);
            this.btnEkle.TabIndex = 3;
            this.btnEkle.Text = "Ekle >>";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnKaldir
            // 
            this.btnKaldir.Location = new System.Drawing.Point(274, 183);
            this.btnKaldir.Name = "btnKaldir";
            this.btnKaldir.Size = new System.Drawing.Size(156, 38);
            this.btnKaldir.TabIndex = 3;
            this.btnKaldir.Text = "<< Kaldır";
            this.btnKaldir.UseVisualStyleBackColor = true;
            this.btnKaldir.Click += new System.EventHandler(this.btnKaldir_Click);
            // 
            // frmUyeKayitFormuYetkileri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 315);
            this.Controls.Add(this.btnKaldir);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDurumlar);
            this.Controls.Add(this.lbYetkililer);
            this.Controls.Add(this.lbYetkisizler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmUyeKayitFormuYetkileri";
            this.Text = "Üye Kayıt Formu Yetkileri";
            this.Load += new System.EventHandler(this.frmUyeKayitFormuYetkileri_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbYetkisizler;
        private System.Windows.Forms.ListBox lbYetkililer;
        private System.Windows.Forms.ComboBox cmbDurumlar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnKaldir;
    }
}