namespace Sultanlar.UI
{
    partial class frmINTERNETfiyatlisteleri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmINTERNETfiyatlisteleri));
            this.btnEkle = new System.Windows.Forms.Button();
            this.txtDosya = new System.Windows.Forms.TextBox();
            this.btnDosya = new System.Windows.Forms.Button();
            this.cmbFiyatTipleri = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEkle
            // 
            this.btnEkle.Enabled = false;
            this.btnEkle.Location = new System.Drawing.Point(355, 10);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(89, 23);
            this.btnEkle.TabIndex = 0;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // txtDosya
            // 
            this.txtDosya.BackColor = System.Drawing.Color.White;
            this.txtDosya.Enabled = false;
            this.txtDosya.Location = new System.Drawing.Point(93, 39);
            this.txtDosya.Name = "txtDosya";
            this.txtDosya.ReadOnly = true;
            this.txtDosya.Size = new System.Drawing.Size(256, 20);
            this.txtDosya.TabIndex = 1;
            // 
            // btnDosya
            // 
            this.btnDosya.Enabled = false;
            this.btnDosya.Location = new System.Drawing.Point(12, 37);
            this.btnDosya.Name = "btnDosya";
            this.btnDosya.Size = new System.Drawing.Size(75, 23);
            this.btnDosya.TabIndex = 2;
            this.btnDosya.Text = "Dosya Seç";
            this.btnDosya.UseVisualStyleBackColor = true;
            this.btnDosya.Click += new System.EventHandler(this.btnDosya_Click);
            // 
            // cmbFiyatTipleri
            // 
            this.cmbFiyatTipleri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiyatTipleri.FormattingEnabled = true;
            this.cmbFiyatTipleri.Location = new System.Drawing.Point(93, 12);
            this.cmbFiyatTipleri.Name = "cmbFiyatTipleri";
            this.cmbFiyatTipleri.Size = new System.Drawing.Size(256, 21);
            this.cmbFiyatTipleri.TabIndex = 3;
            this.cmbFiyatTipleri.SelectedIndexChanged += new System.EventHandler(this.cmbFiyatTipleri_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fiyat Tipi:";
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Enabled = false;
            this.btnGuncelle.Location = new System.Drawing.Point(355, 36);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(89, 23);
            this.btnGuncelle.TabIndex = 0;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // frmINTERNETfiyatlisteleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 71);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbFiyatTipleri);
            this.Controls.Add(this.btnDosya);
            this.Controls.Add(this.txtDosya);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnEkle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmINTERNETfiyatlisteleri";
            this.Text = "Web Satış Bölümü : Fiyat Listeleri";
            this.Load += new System.EventHandler(this.frmINTERNETfiyatlisteleri_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.TextBox txtDosya;
        private System.Windows.Forms.Button btnDosya;
        private System.Windows.Forms.ComboBox cmbFiyatTipleri;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuncelle;
    }
}