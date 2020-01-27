namespace Sultanlar.UI
{
    partial class frmINTERNETresimler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmINTERNETresimler));
            this.lbUrunler = new System.Windows.Forms.ListBox();
            this.lbResimler = new System.Windows.Forms.ListBox();
            this.cmbTedarikciler = new System.Windows.Forms.ComboBox();
            this.cmbKategoriler = new System.Windows.Forms.ComboBox();
            this.txtUrun = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBarkod = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAra = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.rbResimli = new System.Windows.Forms.RadioButton();
            this.rbResimsiz = new System.Windows.Forms.RadioButton();
            this.rbTumu = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.lblToplam = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblAranmis = new System.Windows.Forms.Label();
            this.lblBoyut = new System.Windows.Forms.Label();
            this.cbYeniler = new System.Windows.Forms.CheckBox();
            this.lblEkleyen = new System.Windows.Forms.Label();
            this.lblEklenme = new System.Windows.Forms.Label();
            this.cbAlfabetik = new System.Windows.Forms.CheckBox();
            this.btnRapor = new System.Windows.Forms.Button();
            this.btnLogoEkle = new System.Windows.Forms.Button();
            this.btnLogoSil = new System.Windows.Forms.Button();
            this.cbLogo = new System.Windows.Forms.CheckBox();
            this.btnResimKaydet = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUrunKod = new System.Windows.Forms.TextBox();
            this.lblCozunurluk = new System.Windows.Forms.Label();
            this.btnYazdir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbUrunler
            // 
            this.lbUrunler.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbUrunler.FormattingEnabled = true;
            this.lbUrunler.Location = new System.Drawing.Point(12, 84);
            this.lbUrunler.Name = "lbUrunler";
            this.lbUrunler.Size = new System.Drawing.Size(411, 368);
            this.lbUrunler.TabIndex = 6;
            this.lbUrunler.SelectedIndexChanged += new System.EventHandler(this.lbUrunler_SelectedIndexChanged);
            // 
            // lbResimler
            // 
            this.lbResimler.FormattingEnabled = true;
            this.lbResimler.Location = new System.Drawing.Point(429, 97);
            this.lbResimler.Name = "lbResimler";
            this.lbResimler.Size = new System.Drawing.Size(47, 160);
            this.lbResimler.TabIndex = 7;
            this.lbResimler.SelectedIndexChanged += new System.EventHandler(this.lbResimler_SelectedIndexChanged);
            // 
            // cmbTedarikciler
            // 
            this.cmbTedarikciler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTedarikciler.FormattingEnabled = true;
            this.cmbTedarikciler.Location = new System.Drawing.Point(407, 5);
            this.cmbTedarikciler.Name = "cmbTedarikciler";
            this.cmbTedarikciler.Size = new System.Drawing.Size(205, 21);
            this.cmbTedarikciler.TabIndex = 2;
            this.cmbTedarikciler.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbTedarikciler_MouseDown);
            // 
            // cmbKategoriler
            // 
            this.cmbKategoriler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKategoriler.FormattingEnabled = true;
            this.cmbKategoriler.Location = new System.Drawing.Point(407, 31);
            this.cmbKategoriler.Name = "cmbKategoriler";
            this.cmbKategoriler.Size = new System.Drawing.Size(205, 21);
            this.cmbKategoriler.TabIndex = 4;
            this.cmbKategoriler.Visible = false;
            this.cmbKategoriler.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbTedarikciler_MouseDown);
            // 
            // txtUrun
            // 
            this.txtUrun.Location = new System.Drawing.Point(69, 5);
            this.txtUrun.Name = "txtUrun";
            this.txtUrun.Size = new System.Drawing.Size(225, 20);
            this.txtUrun.TabIndex = 0;
            this.txtUrun.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUrun_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ürün Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tedarikçi:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(318, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Reyon Kategori:";
            this.label3.Visible = false;
            // 
            // txtBarkod
            // 
            this.txtBarkod.Location = new System.Drawing.Point(69, 31);
            this.txtBarkod.Name = "txtBarkod";
            this.txtBarkod.Size = new System.Drawing.Size(87, 20);
            this.txtBarkod.TabIndex = 1;
            this.txtBarkod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUrun_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Barkod:";
            // 
            // btnAra
            // 
            this.btnAra.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAra.Location = new System.Drawing.Point(817, 31);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(65, 21);
            this.btnAra.TabIndex = 5;
            this.btnAra.Text = "BUL";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEkle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEkle.Location = new System.Drawing.Point(429, 399);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(47, 59);
            this.btnEkle.TabIndex = 9;
            this.btnEkle.Text = "Resim\r\n\r\nEkle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnSil
            // 
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSil.ForeColor = System.Drawing.Color.DarkRed;
            this.btnSil.Location = new System.Drawing.Point(429, 263);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(47, 22);
            this.btnSil.TabIndex = 8;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(434, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 26);
            this.label5.TabIndex = 5;
            this.label5.Text = "Resim\r\nNo:";
            // 
            // rbResimli
            // 
            this.rbResimli.AutoSize = true;
            this.rbResimli.Location = new System.Drawing.Point(701, 6);
            this.rbResimli.Name = "rbResimli";
            this.rbResimli.Size = new System.Drawing.Size(69, 17);
            this.rbResimli.TabIndex = 10;
            this.rbResimli.Text = "Resimliler";
            this.rbResimli.UseVisualStyleBackColor = true;
            // 
            // rbResimsiz
            // 
            this.rbResimsiz.AutoSize = true;
            this.rbResimsiz.Location = new System.Drawing.Point(776, 6);
            this.rbResimsiz.Name = "rbResimsiz";
            this.rbResimsiz.Size = new System.Drawing.Size(77, 17);
            this.rbResimsiz.TabIndex = 10;
            this.rbResimsiz.Text = "Resimsizler";
            this.rbResimsiz.UseVisualStyleBackColor = true;
            // 
            // rbTumu
            // 
            this.rbTumu.AutoSize = true;
            this.rbTumu.Checked = true;
            this.rbTumu.Location = new System.Drawing.Point(643, 6);
            this.rbTumu.Name = "rbTumu";
            this.rbTumu.Size = new System.Drawing.Size(52, 17);
            this.rbTumu.TabIndex = 10;
            this.rbTumu.TabStop = true;
            this.rbTumu.Text = "Tümü";
            this.rbTumu.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 462);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Toplam Ürün Sayısı:";
            this.label6.Visible = false;
            // 
            // lblToplam
            // 
            this.lblToplam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblToplam.Location = new System.Drawing.Point(119, 462);
            this.lblToplam.Name = "lblToplam";
            this.lblToplam.Size = new System.Drawing.Size(37, 13);
            this.lblToplam.TabIndex = 12;
            this.lblToplam.Text = "99999";
            this.lblToplam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblToplam.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(234, 462);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Seçilen (aranmış) Ürün Sayısı:";
            // 
            // lblAranmis
            // 
            this.lblAranmis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAranmis.Location = new System.Drawing.Point(386, 462);
            this.lblAranmis.Name = "lblAranmis";
            this.lblAranmis.Size = new System.Drawing.Size(37, 13);
            this.lblAranmis.TabIndex = 12;
            this.lblAranmis.Text = "99999";
            this.lblAranmis.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBoyut
            // 
            this.lblBoyut.AutoSize = true;
            this.lblBoyut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBoyut.Location = new System.Drawing.Point(486, 462);
            this.lblBoyut.Name = "lblBoyut";
            this.lblBoyut.Size = new System.Drawing.Size(0, 13);
            this.lblBoyut.TabIndex = 13;
            // 
            // cbYeniler
            // 
            this.cbYeniler.AutoSize = true;
            this.cbYeniler.Location = new System.Drawing.Point(643, 34);
            this.cbYeniler.Name = "cbYeniler";
            this.cbYeniler.Size = new System.Drawing.Size(98, 17);
            this.cbYeniler.TabIndex = 14;
            this.cbYeniler.Text = "Sadece Yeniler";
            this.cbYeniler.UseVisualStyleBackColor = true;
            // 
            // lblEkleyen
            // 
            this.lblEkleyen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEkleyen.Location = new System.Drawing.Point(765, 462);
            this.lblEkleyen.Name = "lblEkleyen";
            this.lblEkleyen.Size = new System.Drawing.Size(117, 13);
            this.lblEkleyen.TabIndex = 12;
            this.lblEkleyen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEklenme
            // 
            this.lblEklenme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEklenme.Location = new System.Drawing.Point(582, 462);
            this.lblEklenme.Name = "lblEklenme";
            this.lblEklenme.Size = new System.Drawing.Size(108, 13);
            this.lblEklenme.TabIndex = 12;
            this.lblEklenme.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbAlfabetik
            // 
            this.cbAlfabetik.AutoSize = true;
            this.cbAlfabetik.Checked = true;
            this.cbAlfabetik.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAlfabetik.Location = new System.Drawing.Point(764, 34);
            this.cbAlfabetik.Name = "cbAlfabetik";
            this.cbAlfabetik.Size = new System.Drawing.Size(47, 17);
            this.cbAlfabetik.TabIndex = 16;
            this.cbAlfabetik.Text = "ABC";
            this.cbAlfabetik.UseVisualStyleBackColor = true;
            // 
            // btnRapor
            // 
            this.btnRapor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRapor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRapor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRapor.Location = new System.Drawing.Point(12, 62);
            this.btnRapor.Name = "btnRapor";
            this.btnRapor.Size = new System.Drawing.Size(70, 23);
            this.btnRapor.TabIndex = 17;
            this.btnRapor.Text = "Rapor";
            this.btnRapor.UseVisualStyleBackColor = true;
            this.btnRapor.Click += new System.EventHandler(this.btnRapor_Click);
            // 
            // btnLogoEkle
            // 
            this.btnLogoEkle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogoEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLogoEkle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLogoEkle.Location = new System.Drawing.Point(165, 62);
            this.btnLogoEkle.Name = "btnLogoEkle";
            this.btnLogoEkle.Size = new System.Drawing.Size(98, 23);
            this.btnLogoEkle.TabIndex = 17;
            this.btnLogoEkle.Text = "Logo Resmi Ekle";
            this.btnLogoEkle.UseVisualStyleBackColor = true;
            this.btnLogoEkle.Visible = false;
            this.btnLogoEkle.Click += new System.EventHandler(this.btnLogoEkle_Click);
            // 
            // btnLogoSil
            // 
            this.btnLogoSil.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogoSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLogoSil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLogoSil.Location = new System.Drawing.Point(265, 62);
            this.btnLogoSil.Name = "btnLogoSil";
            this.btnLogoSil.Size = new System.Drawing.Size(98, 23);
            this.btnLogoSil.TabIndex = 17;
            this.btnLogoSil.Text = "Logo Resmi Sil";
            this.btnLogoSil.UseVisualStyleBackColor = true;
            this.btnLogoSil.Visible = false;
            this.btnLogoSil.Click += new System.EventHandler(this.btnLogoSil_Click);
            // 
            // cbLogo
            // 
            this.cbLogo.AutoSize = true;
            this.cbLogo.Location = new System.Drawing.Point(114, 66);
            this.cbLogo.Name = "cbLogo";
            this.cbLogo.Size = new System.Drawing.Size(50, 17);
            this.cbLogo.TabIndex = 18;
            this.cbLogo.Text = "Logo";
            this.cbLogo.UseVisualStyleBackColor = true;
            this.cbLogo.Visible = false;
            this.cbLogo.CheckedChanged += new System.EventHandler(this.cbLogo_CheckedChanged);
            // 
            // btnResimKaydet
            // 
            this.btnResimKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResimKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnResimKaydet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnResimKaydet.Location = new System.Drawing.Point(429, 334);
            this.btnResimKaydet.Name = "btnResimKaydet";
            this.btnResimKaydet.Size = new System.Drawing.Size(47, 59);
            this.btnResimKaydet.TabIndex = 9;
            this.btnResimKaydet.Text = "Resimi\r\n\r\nKaydet";
            this.btnResimKaydet.UseVisualStyleBackColor = true;
            this.btnResimKaydet.Click += new System.EventHandler(this.btnResimKaydet_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(172, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Kod:";
            // 
            // txtUrunKod
            // 
            this.txtUrunKod.Location = new System.Drawing.Point(207, 31);
            this.txtUrunKod.Name = "txtUrunKod";
            this.txtUrunKod.Size = new System.Drawing.Size(87, 20);
            this.txtUrunKod.TabIndex = 1;
            this.txtUrunKod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUrun_KeyDown);
            // 
            // lblCozunurluk
            // 
            this.lblCozunurluk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCozunurluk.Location = new System.Drawing.Point(696, 462);
            this.lblCozunurluk.Name = "lblCozunurluk";
            this.lblCozunurluk.Size = new System.Drawing.Size(63, 13);
            this.lblCozunurluk.TabIndex = 12;
            this.lblCozunurluk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnYazdir
            // 
            this.btnYazdir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnYazdir.Image = global::Sultanlar.UI.Properties.Resources.yazdir;
            this.btnYazdir.Location = new System.Drawing.Point(393, 62);
            this.btnYazdir.Name = "btnYazdir";
            this.btnYazdir.Size = new System.Drawing.Size(30, 23);
            this.btnYazdir.TabIndex = 15;
            this.btnYazdir.UseVisualStyleBackColor = true;
            this.btnYazdir.Click += new System.EventHandler(this.btnYazdir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::Sultanlar.UI.Properties.Resources.hazirlaniyor;
            this.pictureBox1.Location = new System.Drawing.Point(482, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 400);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // frmINTERNETresimler
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 483);
            this.Controls.Add(this.cbLogo);
            this.Controls.Add(this.btnLogoSil);
            this.Controls.Add(this.btnLogoEkle);
            this.Controls.Add(this.btnRapor);
            this.Controls.Add(this.cbAlfabetik);
            this.Controls.Add(this.btnYazdir);
            this.Controls.Add(this.cbYeniler);
            this.Controls.Add(this.lblBoyut);
            this.Controls.Add(this.lblEklenme);
            this.Controls.Add(this.lblCozunurluk);
            this.Controls.Add(this.lblEkleyen);
            this.Controls.Add(this.lblAranmis);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblToplam);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rbResimsiz);
            this.Controls.Add(this.rbTumu);
            this.Controls.Add(this.rbResimli);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnResimKaydet);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUrunKod);
            this.Controls.Add(this.txtBarkod);
            this.Controls.Add(this.txtUrun);
            this.Controls.Add(this.cmbKategoriler);
            this.Controls.Add(this.cmbTedarikciler);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbResimler);
            this.Controls.Add(this.lbUrunler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmINTERNETresimler";
            this.Text = "Resimler";
            this.Load += new System.EventHandler(this.frmINTERNETresimler_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmINTERNETresimler_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmINTERNETresimler_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbUrunler;
        private System.Windows.Forms.ListBox lbResimler;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmbTedarikciler;
        private System.Windows.Forms.ComboBox cmbKategoriler;
        private System.Windows.Forms.TextBox txtUrun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBarkod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbResimli;
        private System.Windows.Forms.RadioButton rbResimsiz;
        private System.Windows.Forms.RadioButton rbTumu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblToplam;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblAranmis;
        private System.Windows.Forms.Label lblBoyut;
        private System.Windows.Forms.CheckBox cbYeniler;
        private System.Windows.Forms.Button btnYazdir;
        private System.Windows.Forms.Label lblEkleyen;
        private System.Windows.Forms.Label lblEklenme;
        private System.Windows.Forms.CheckBox cbAlfabetik;
        private System.Windows.Forms.Button btnRapor;
        private System.Windows.Forms.Button btnLogoEkle;
        private System.Windows.Forms.Button btnLogoSil;
        private System.Windows.Forms.CheckBox cbLogo;
        private System.Windows.Forms.Button btnResimKaydet;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUrunKod;
        private System.Windows.Forms.Label lblCozunurluk;
    }
}