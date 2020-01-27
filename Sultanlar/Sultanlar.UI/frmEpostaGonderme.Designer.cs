namespace Sultanlar.UI
{
    partial class frmEpostaGonderme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEpostaGonderme));
            this.txtKonu = new System.Windows.Forms.TextBox();
            this.txtIcerik = new System.Windows.Forms.TextBox();
            this.btnGonder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExcel = new System.Windows.Forms.TextBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEkle = new System.Windows.Forms.Button();
            this.cblDosyalar = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSure = new System.Windows.Forms.Label();
            this.lbGonderilenler = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSonGonderilen = new System.Windows.Forms.Label();
            this.lbSonGonderilenler = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSatirSayisi = new System.Windows.Forms.Button();
            this.txtSatirSayisi = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDakikada = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnYardim = new System.Windows.Forms.Button();
            this.txtSaniye = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnResimEkle = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.cblResimler = new System.Windows.Forms.CheckedListBox();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtKonu
            // 
            this.txtKonu.Location = new System.Drawing.Point(60, 73);
            this.txtKonu.Name = "txtKonu";
            this.txtKonu.Size = new System.Drawing.Size(532, 20);
            this.txtKonu.TabIndex = 1;
            // 
            // txtIcerik
            // 
            this.txtIcerik.Location = new System.Drawing.Point(60, 99);
            this.txtIcerik.Multiline = true;
            this.txtIcerik.Name = "txtIcerik";
            this.txtIcerik.Size = new System.Drawing.Size(822, 250);
            this.txtIcerik.TabIndex = 2;
            this.txtIcerik.Visible = false;
            // 
            // btnGonder
            // 
            this.btnGonder.Enabled = false;
            this.btnGonder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGonder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGonder.Location = new System.Drawing.Point(674, 381);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(208, 134);
            this.btnGonder.TabIndex = 4;
            this.btnGonder.Text = "Göndermeye Başla";
            this.btnGonder.UseVisualStyleBackColor = true;
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Konu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "İçerik:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kime:";
            // 
            // txtExcel
            // 
            this.txtExcel.ForeColor = System.Drawing.Color.White;
            this.txtExcel.Location = new System.Drawing.Point(60, 47);
            this.txtExcel.Name = "txtExcel";
            this.txtExcel.ReadOnly = true;
            this.txtExcel.Size = new System.Drawing.Size(532, 20);
            this.txtExcel.TabIndex = 0;
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(598, 45);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(78, 23);
            this.btnExcel.TabIndex = 0;
            this.btnExcel.Text = "Excel\'den Al";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 464);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Diğer Ekler:";
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(568, 462);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(60, 64);
            this.btnEkle.TabIndex = 3;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // cblDosyalar
            // 
            this.cblDosyalar.FormattingEnabled = true;
            this.cblDosyalar.Location = new System.Drawing.Point(88, 462);
            this.cblDosyalar.Name = "cblDosyalar";
            this.cblDosyalar.Size = new System.Drawing.Size(474, 64);
            this.cblDosyalar.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(790, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Süre:";
            // 
            // lblSure
            // 
            this.lblSure.AutoSize = true;
            this.lblSure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSure.Location = new System.Drawing.Point(828, 9);
            this.lblSure.Name = "lblSure";
            this.lblSure.Size = new System.Drawing.Size(49, 13);
            this.lblSure.TabIndex = 6;
            this.lblSure.Text = "00:00:01";
            // 
            // lbGonderilenler
            // 
            this.lbGonderilenler.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbGonderilenler.FormattingEnabled = true;
            this.lbGonderilenler.Location = new System.Drawing.Point(477, 52);
            this.lbGonderilenler.Name = "lbGonderilenler";
            this.lbGonderilenler.Size = new System.Drawing.Size(400, 446);
            this.lbGonderilenler.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Son Gönderilen:";
            // 
            // lblSonGonderilen
            // 
            this.lblSonGonderilen.AutoSize = true;
            this.lblSonGonderilen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSonGonderilen.Location = new System.Drawing.Point(96, 9);
            this.lblSonGonderilen.Name = "lblSonGonderilen";
            this.lblSonGonderilen.Size = new System.Drawing.Size(0, 13);
            this.lblSonGonderilen.TabIndex = 6;
            // 
            // lbSonGonderilenler
            // 
            this.lbSonGonderilenler.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbSonGonderilenler.FormattingEnabled = true;
            this.lbSonGonderilenler.Location = new System.Drawing.Point(7, 52);
            this.lbSonGonderilenler.Name = "lbSonGonderilenler";
            this.lbSonGonderilenler.Size = new System.Drawing.Size(400, 446);
            this.lbSonGonderilenler.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Son Gönderilenler:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(477, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Tüm Gönderilenler:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSatirSayisi);
            this.panel1.Controls.Add(this.txtSatirSayisi);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(5, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(885, 139);
            this.panel1.TabIndex = 8;
            this.panel1.Visible = false;
            // 
            // btnSatirSayisi
            // 
            this.btnSatirSayisi.Location = new System.Drawing.Point(505, 108);
            this.btnSatirSayisi.Name = "btnSatirSayisi";
            this.btnSatirSayisi.Size = new System.Drawing.Size(75, 23);
            this.btnSatirSayisi.TabIndex = 2;
            this.btnSatirSayisi.Text = "Tamam";
            this.btnSatirSayisi.UseVisualStyleBackColor = true;
            this.btnSatirSayisi.Click += new System.EventHandler(this.btnSatirSayisi_Click);
            // 
            // txtSatirSayisi
            // 
            this.txtSatirSayisi.Location = new System.Drawing.Point(461, 110);
            this.txtSatirSayisi.Name = "txtSatirSayisi";
            this.txtSatirSayisi.Size = new System.Drawing.Size(38, 20);
            this.txtSatirSayisi.TabIndex = 1;
            this.txtSatirSayisi.Text = "2";
            this.txtSatirSayisi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSatirSayisi_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(299, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(156, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Excel Dosyasındaki Satır Sayısı:";
            // 
            // txtDakikada
            // 
            this.txtDakikada.Enabled = false;
            this.txtDakikada.Location = new System.Drawing.Point(462, 6);
            this.txtDakikada.MaxLength = 2;
            this.txtDakikada.Name = "txtDakikada";
            this.txtDakikada.Size = new System.Drawing.Size(26, 20);
            this.txtDakikada.TabIndex = 9;
            this.txtDakikada.Text = "1";
            this.txtDakikada.TextChanged += new System.EventHandler(this.txtDakikada_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(411, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "saniyede";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(494, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "tane gönder.";
            // 
            // btnYardim
            // 
            this.btnYardim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYardim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnYardim.Location = new System.Drawing.Point(682, 45);
            this.btnYardim.Name = "btnYardim";
            this.btnYardim.Size = new System.Drawing.Size(21, 23);
            this.btnYardim.TabIndex = 10;
            this.btnYardim.Text = "?";
            this.btnYardim.UseVisualStyleBackColor = true;
            this.btnYardim.Click += new System.EventHandler(this.btnYardim_Click);
            // 
            // txtSaniye
            // 
            this.txtSaniye.Enabled = false;
            this.txtSaniye.Location = new System.Drawing.Point(380, 6);
            this.txtSaniye.MaxLength = 2;
            this.txtSaniye.Name = "txtSaniye";
            this.txtSaniye.Size = new System.Drawing.Size(26, 20);
            this.txtSaniye.TabIndex = 9;
            this.txtSaniye.Text = "10";
            this.txtSaniye.TextChanged += new System.EventHandler(this.txtDakikada_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(353, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Her";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lblSonGonderilen);
            this.panel2.Controls.Add(this.lblSure);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lbSonGonderilenler);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.lbGonderilenler);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(5, 258);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(885, 36);
            this.panel2.TabIndex = 11;
            this.panel2.Visible = false;
            // 
            // btnResimEkle
            // 
            this.btnResimEkle.Location = new System.Drawing.Point(568, 381);
            this.btnResimEkle.Name = "btnResimEkle";
            this.btnResimEkle.Size = new System.Drawing.Size(60, 49);
            this.btnResimEkle.TabIndex = 3;
            this.btnResimEkle.Text = "Ekle";
            this.btnResimEkle.UseVisualStyleBackColor = true;
            this.btnResimEkle.Click += new System.EventHandler(this.btnResimEkle_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 381);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 26);
            this.label13.TabIndex = 4;
            this.label13.Text = "İletiye \r\nResim Ekle:";
            // 
            // cblResimler
            // 
            this.cblResimler.FormattingEnabled = true;
            this.cblResimler.Location = new System.Drawing.Point(88, 381);
            this.cblResimler.Name = "cblResimler";
            this.cblResimler.Size = new System.Drawing.Size(474, 49);
            this.cblResimler.TabIndex = 5;
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(88, 436);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(474, 20);
            this.txtLink.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 439);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Resim Linki:";
            // 
            // frmEpostaGonderme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 537);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cblResimler);
            this.Controls.Add(this.cblDosyalar);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnResimEkle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.btnGonder);
            this.Controls.Add(this.txtIcerik);
            this.Controls.Add(this.txtExcel);
            this.Controls.Add(this.txtKonu);
            this.Controls.Add(this.btnYardim);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtSaniye);
            this.Controls.Add(this.txtDakikada);
            this.Controls.Add(this.txtLink);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(555, 565);
            this.Name = "frmEpostaGonderme";
            this.Text = "Eposta Gönderme";
            this.Load += new System.EventHandler(this.frmEpostaGonderme_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKonu;
        private System.Windows.Forms.TextBox txtIcerik;
        private System.Windows.Forms.Button btnGonder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExcel;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.CheckedListBox cblDosyalar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSure;
        private System.Windows.Forms.ListBox lbGonderilenler;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblSonGonderilen;
        private System.Windows.Forms.ListBox lbSonGonderilenler;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSatirSayisi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSatirSayisi;
        private System.Windows.Forms.TextBox txtDakikada;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnYardim;
        private System.Windows.Forms.TextBox txtSaniye;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnResimEkle;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckedListBox cblResimler;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.Label label14;
    }
}