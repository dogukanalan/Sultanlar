namespace Sultanlar.UI
{
    partial class frmTekUrunKargoSirketleri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTekUrunKargoSirketleri));
            this.lbKargoSirketleri = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.txtSilSirket = new System.Windows.Forms.TextBox();
            this.txtGuncelleSirket = new System.Windows.Forms.TextBox();
            this.txtEkleSirket = new System.Windows.Forms.TextBox();
            this.txtEkleFiyat = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtGuncelleFiyat = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEkleFiyatDesi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGuncelleFiyatDesi = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbKargoSirketleri
            // 
            this.lbKargoSirketleri.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbKargoSirketleri.FormattingEnabled = true;
            this.lbKargoSirketleri.Location = new System.Drawing.Point(0, 0);
            this.lbKargoSirketleri.Name = "lbKargoSirketleri";
            this.lbKargoSirketleri.Size = new System.Drawing.Size(133, 229);
            this.lbKargoSirketleri.TabIndex = 1;
            this.lbKargoSirketleri.SelectedIndexChanged += new System.EventHandler(this.lbKargoSirketleri_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "İsim:";
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(229, 17);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(82, 23);
            this.btnSil.TabIndex = 9;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(229, 19);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(82, 46);
            this.btnGuncelle.TabIndex = 8;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(229, 19);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(82, 44);
            this.btnEkle.TabIndex = 7;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // txtSilSirket
            // 
            this.txtSilSirket.Enabled = false;
            this.txtSilSirket.Location = new System.Drawing.Point(44, 19);
            this.txtSilSirket.Name = "txtSilSirket";
            this.txtSilSirket.ReadOnly = true;
            this.txtSilSirket.Size = new System.Drawing.Size(179, 20);
            this.txtSilSirket.TabIndex = 4;
            // 
            // txtGuncelleSirket
            // 
            this.txtGuncelleSirket.Location = new System.Drawing.Point(44, 19);
            this.txtGuncelleSirket.Name = "txtGuncelleSirket";
            this.txtGuncelleSirket.Size = new System.Drawing.Size(179, 20);
            this.txtGuncelleSirket.TabIndex = 5;
            // 
            // txtEkleSirket
            // 
            this.txtEkleSirket.Location = new System.Drawing.Point(44, 19);
            this.txtEkleSirket.Name = "txtEkleSirket";
            this.txtEkleSirket.Size = new System.Drawing.Size(179, 20);
            this.txtEkleSirket.TabIndex = 6;
            // 
            // txtEkleFiyat
            // 
            this.txtEkleFiyat.Location = new System.Drawing.Point(79, 43);
            this.txtEkleFiyat.Name = "txtEkleFiyat";
            this.txtEkleFiyat.Size = new System.Drawing.Size(54, 20);
            this.txtEkleFiyat.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEkleSirket);
            this.groupBox1.Controls.Add(this.txtEkleFiyatDesi);
            this.groupBox1.Controls.Add(this.txtEkleFiyat);
            this.groupBox1.Controls.Add(this.btnEkle);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(139, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 72);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Yeni Şirket Ekle";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "gram";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtGuncelleFiyatDesi);
            this.groupBox2.Controls.Add(this.txtGuncelleFiyat);
            this.groupBox2.Controls.Add(this.txtGuncelleSirket);
            this.groupBox2.Controls.Add(this.btnGuncelle);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(139, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(317, 72);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seçili Şirket Bilgilerini Güncelle";
            // 
            // txtGuncelleFiyat
            // 
            this.txtGuncelleFiyat.Location = new System.Drawing.Point(79, 45);
            this.txtGuncelleFiyat.Name = "txtGuncelleFiyat";
            this.txtGuncelleFiyat.Size = new System.Drawing.Size(54, 20);
            this.txtGuncelleFiyat.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Fiyat:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "İsim:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtSilSirket);
            this.groupBox3.Controls.Add(this.btnSil);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(139, 177);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(317, 46);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Seçili Şirketi Sil";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "İsim:";
            // 
            // txtEkleFiyatDesi
            // 
            this.txtEkleFiyatDesi.Location = new System.Drawing.Point(169, 43);
            this.txtEkleFiyatDesi.Name = "txtEkleFiyatDesi";
            this.txtEkleFiyatDesi.Size = new System.Drawing.Size(54, 20);
            this.txtEkleFiyatDesi.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(139, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "desi";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Fiyat:";
            // 
            // txtGuncelleFiyatDesi
            // 
            this.txtGuncelleFiyatDesi.Location = new System.Drawing.Point(169, 45);
            this.txtGuncelleFiyatDesi.Name = "txtGuncelleFiyatDesi";
            this.txtGuncelleFiyatDesi.Size = new System.Drawing.Size(54, 20);
            this.txtGuncelleFiyatDesi.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(137, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "desi";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(43, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "gram";
            // 
            // frmTekUrunKargoSirketleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 229);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbKargoSirketleri);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(480, 267);
            this.Name = "frmTekUrunKargoSirketleri";
            this.Text = "Tek Ürün Satışı : Kargo Şirketleri Listesi";
            this.Load += new System.EventHandler(this.frmTekUrunKargoSirketleri_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbKargoSirketleri;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.TextBox txtSilSirket;
        private System.Windows.Forms.TextBox txtGuncelleSirket;
        private System.Windows.Forms.TextBox txtEkleSirket;
        private System.Windows.Forms.TextBox txtEkleFiyat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtGuncelleFiyat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEkleFiyatDesi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGuncelleFiyatDesi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}