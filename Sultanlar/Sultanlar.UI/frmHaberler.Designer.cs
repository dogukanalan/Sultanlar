namespace Sultanlar.UI
{
    partial class frmHaberler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHaberler));
            this.txtHaberEkleBaslik = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHaberEkleIcerik = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnResimEkle = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHaberEkleTemizle = new System.Windows.Forms.Button();
            this.lblDurum = new System.Windows.Forms.Label();
            this.pbHaberEkle = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnHaberEkle = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnResimDegistir = new System.Windows.Forms.Button();
            this.lblHaberDurum = new System.Windows.Forms.Label();
            this.txtHaberBaslik = new System.Windows.Forms.TextBox();
            this.btnHaberGuncelle = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnHaberSil = new System.Windows.Forms.Button();
            this.pbHaber = new System.Windows.Forms.PictureBox();
            this.txtHaberIcerik = new System.Windows.Forms.TextBox();
            this.cmbHaberler = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHaberEkle)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHaber)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHaberEkleBaslik
            // 
            this.txtHaberEkleBaslik.Location = new System.Drawing.Point(175, 95);
            this.txtHaberEkleBaslik.MaxLength = 50;
            this.txtHaberEkleBaslik.Name = "txtHaberEkleBaslik";
            this.txtHaberEkleBaslik.Size = new System.Drawing.Size(244, 20);
            this.txtHaberEkleBaslik.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Başlık:";
            // 
            // txtHaberEkleIcerik
            // 
            this.txtHaberEkleIcerik.Location = new System.Drawing.Point(67, 121);
            this.txtHaberEkleIcerik.Multiline = true;
            this.txtHaberEkleIcerik.Name = "txtHaberEkleIcerik";
            this.txtHaberEkleIcerik.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHaberEkleIcerik.Size = new System.Drawing.Size(352, 119);
            this.txtHaberEkleIcerik.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "İçerik:";
            // 
            // btnResimEkle
            // 
            this.btnResimEkle.Location = new System.Drawing.Point(318, 66);
            this.btnResimEkle.Name = "btnResimEkle";
            this.btnResimEkle.Size = new System.Drawing.Size(100, 23);
            this.btnResimEkle.TabIndex = 4;
            this.btnResimEkle.Text = "Resim Ekle";
            this.btnResimEkle.UseVisualStyleBackColor = true;
            this.btnResimEkle.Click += new System.EventHandler(this.btnResimEkle_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Resim:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnHaberEkleTemizle);
            this.groupBox1.Controls.Add(this.lblDurum);
            this.groupBox1.Controls.Add(this.pbHaberEkle);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnHaberEkle);
            this.groupBox1.Controls.Add(this.txtHaberEkleIcerik);
            this.groupBox1.Controls.Add(this.txtHaberEkleBaslik);
            this.groupBox1.Controls.Add(this.btnResimEkle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(447, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 316);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Haber Ekle";
            // 
            // btnHaberEkleTemizle
            // 
            this.btnHaberEkleTemizle.Location = new System.Drawing.Point(213, 246);
            this.btnHaberEkleTemizle.Name = "btnHaberEkleTemizle";
            this.btnHaberEkleTemizle.Size = new System.Drawing.Size(100, 23);
            this.btnHaberEkleTemizle.TabIndex = 8;
            this.btnHaberEkleTemizle.Text = "Temizle";
            this.btnHaberEkleTemizle.UseVisualStyleBackColor = true;
            this.btnHaberEkleTemizle.Click += new System.EventHandler(this.btnHaberEkleTemizle_Click);
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.Location = new System.Drawing.Point(53, 290);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(58, 13);
            this.lblDurum.TabIndex = 7;
            this.lblDurum.Text = "Form hazır.";
            // 
            // pbHaberEkle
            // 
            this.pbHaberEkle.Location = new System.Drawing.Point(344, 14);
            this.pbHaberEkle.Name = "pbHaberEkle";
            this.pbHaberEkle.Size = new System.Drawing.Size(75, 75);
            this.pbHaberEkle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbHaberEkle.TabIndex = 5;
            this.pbHaberEkle.TabStop = false;
            this.pbHaberEkle.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Durum:";
            // 
            // btnHaberEkle
            // 
            this.btnHaberEkle.Location = new System.Drawing.Point(319, 246);
            this.btnHaberEkle.Name = "btnHaberEkle";
            this.btnHaberEkle.Size = new System.Drawing.Size(100, 23);
            this.btnHaberEkle.TabIndex = 5;
            this.btnHaberEkle.Text = "Haberi Ekle";
            this.btnHaberEkle.UseVisualStyleBackColor = true;
            this.btnHaberEkle.Click += new System.EventHandler(this.btnHaberEkle_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnResimDegistir);
            this.groupBox2.Controls.Add(this.lblHaberDurum);
            this.groupBox2.Controls.Add(this.txtHaberBaslik);
            this.groupBox2.Controls.Add(this.btnHaberGuncelle);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnHaberSil);
            this.groupBox2.Controls.Add(this.pbHaber);
            this.groupBox2.Controls.Add(this.txtHaberIcerik);
            this.groupBox2.Controls.Add(this.cmbHaberler);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(425, 316);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Haberler";
            // 
            // btnResimDegistir
            // 
            this.btnResimDegistir.Location = new System.Drawing.Point(238, 66);
            this.btnResimDegistir.Name = "btnResimDegistir";
            this.btnResimDegistir.Size = new System.Drawing.Size(100, 23);
            this.btnResimDegistir.TabIndex = 7;
            this.btnResimDegistir.Text = "Resmi Değiştir";
            this.btnResimDegistir.UseVisualStyleBackColor = true;
            this.btnResimDegistir.Visible = false;
            this.btnResimDegistir.Click += new System.EventHandler(this.btnResimDegistir_Click);
            // 
            // lblHaberDurum
            // 
            this.lblHaberDurum.AutoSize = true;
            this.lblHaberDurum.Location = new System.Drawing.Point(53, 290);
            this.lblHaberDurum.Name = "lblHaberDurum";
            this.lblHaberDurum.Size = new System.Drawing.Size(58, 13);
            this.lblHaberDurum.TabIndex = 7;
            this.lblHaberDurum.Text = "Form hazır.";
            // 
            // txtHaberBaslik
            // 
            this.txtHaberBaslik.Location = new System.Drawing.Point(175, 95);
            this.txtHaberBaslik.MaxLength = 50;
            this.txtHaberBaslik.Name = "txtHaberBaslik";
            this.txtHaberBaslik.Size = new System.Drawing.Size(244, 20);
            this.txtHaberBaslik.TabIndex = 6;
            this.txtHaberBaslik.Visible = false;
            // 
            // btnHaberGuncelle
            // 
            this.btnHaberGuncelle.Location = new System.Drawing.Point(213, 246);
            this.btnHaberGuncelle.Name = "btnHaberGuncelle";
            this.btnHaberGuncelle.Size = new System.Drawing.Size(100, 23);
            this.btnHaberGuncelle.TabIndex = 5;
            this.btnHaberGuncelle.Text = "Haberi Güncelle";
            this.btnHaberGuncelle.UseVisualStyleBackColor = true;
            this.btnHaberGuncelle.Click += new System.EventHandler(this.btnHaberGuncelle_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 290);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Durum:";
            // 
            // btnHaberSil
            // 
            this.btnHaberSil.Location = new System.Drawing.Point(319, 246);
            this.btnHaberSil.Name = "btnHaberSil";
            this.btnHaberSil.Size = new System.Drawing.Size(100, 23);
            this.btnHaberSil.TabIndex = 5;
            this.btnHaberSil.Text = "Haberi Sil";
            this.btnHaberSil.UseVisualStyleBackColor = true;
            this.btnHaberSil.Click += new System.EventHandler(this.btnHaberSil_Click);
            // 
            // pbHaber
            // 
            this.pbHaber.Location = new System.Drawing.Point(344, 19);
            this.pbHaber.Name = "pbHaber";
            this.pbHaber.Size = new System.Drawing.Size(75, 75);
            this.pbHaber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbHaber.TabIndex = 5;
            this.pbHaber.TabStop = false;
            // 
            // txtHaberIcerik
            // 
            this.txtHaberIcerik.Location = new System.Drawing.Point(67, 121);
            this.txtHaberIcerik.Multiline = true;
            this.txtHaberIcerik.Name = "txtHaberIcerik";
            this.txtHaberIcerik.ReadOnly = true;
            this.txtHaberIcerik.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtHaberIcerik.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHaberIcerik.Size = new System.Drawing.Size(352, 119);
            this.txtHaberIcerik.TabIndex = 3;
            // 
            // cmbHaberler
            // 
            this.cmbHaberler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHaberler.FormattingEnabled = true;
            this.cmbHaberler.Location = new System.Drawing.Point(175, 95);
            this.cmbHaberler.Name = "cmbHaberler";
            this.cmbHaberler.Size = new System.Drawing.Size(244, 21);
            this.cmbHaberler.TabIndex = 0;
            this.cmbHaberler.SelectedIndexChanged += new System.EventHandler(this.cmbHaberler_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Başlık:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "İçerik:";
            // 
            // frmHaberler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 336);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 374);
            this.Name = "frmHaberler";
            this.Text = "Haberler";
            this.Load += new System.EventHandler(this.frmHaberler_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHaberEkle)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHaber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtHaberEkleBaslik;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHaberEkleIcerik;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnResimEkle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pbHaber;
        private System.Windows.Forms.TextBox txtHaberIcerik;
        private System.Windows.Forms.ComboBox cmbHaberler;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnHaberEkle;
        private System.Windows.Forms.Button btnHaberGuncelle;
        private System.Windows.Forms.Button btnHaberSil;
        private System.Windows.Forms.Label lblDurum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnHaberEkleTemizle;
        private System.Windows.Forms.PictureBox pbHaberEkle;
        private System.Windows.Forms.TextBox txtHaberBaslik;
        private System.Windows.Forms.Button btnResimDegistir;
        private System.Windows.Forms.Label lblHaberDurum;
        private System.Windows.Forms.Label label7;
    }
}