namespace Sultanlar.UI
{
    partial class frmBrosur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBrosur));
            this.txtDosyaYolu = new System.Windows.Forms.TextBox();
            this.btnDosyaYolu = new System.Windows.Forms.Button();
            this.btnOlustur = new System.Windows.Forms.Button();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb4 = new System.Windows.Forms.RadioButton();
            this.rb6 = new System.Windows.Forms.RadioButton();
            this.rb9 = new System.Windows.Forms.RadioButton();
            this.rb12 = new System.Windows.Forms.RadioButton();
            this.rb16 = new System.Windows.Forms.RadioButton();
            this.rb20 = new System.Windows.Forms.RadioButton();
            this.txtCiktiYolu = new System.Windows.Forms.TextBox();
            this.btnCiktiYolu = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbArkaplansiz = new System.Windows.Forms.CheckBox();
            this.pnlAciklama = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbBarkodTur = new System.Windows.Forms.ComboBox();
            this.cbKaynaktakiDosyalariSilme = new System.Windows.Forms.CheckBox();
            this.cmbRenkler = new System.Windows.Forms.ComboBox();
            this.lblAciklama = new System.Windows.Forms.Label();
            this.txtExcel = new System.Windows.Forms.TextBox();
            this.txtRenk = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKoliAdedi = new System.Windows.Forms.TextBox();
            this.btnExcelDosyasi = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnYazdir = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtBarkodRenk = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlAciklama.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDosyaYolu
            // 
            this.txtDosyaYolu.BackColor = System.Drawing.Color.White;
            this.txtDosyaYolu.Location = new System.Drawing.Point(12, 12);
            this.txtDosyaYolu.Name = "txtDosyaYolu";
            this.txtDosyaYolu.Size = new System.Drawing.Size(270, 20);
            this.txtDosyaYolu.TabIndex = 0;
            this.txtDosyaYolu.TextChanged += new System.EventHandler(this.txtDosyaYolu_TextChanged);
            // 
            // btnDosyaYolu
            // 
            this.btnDosyaYolu.Location = new System.Drawing.Point(288, 11);
            this.btnDosyaYolu.Name = "btnDosyaYolu";
            this.btnDosyaYolu.Size = new System.Drawing.Size(75, 21);
            this.btnDosyaYolu.TabIndex = 1;
            this.btnDosyaYolu.Text = "Dosya Yolu";
            this.btnDosyaYolu.UseVisualStyleBackColor = true;
            this.btnDosyaYolu.Click += new System.EventHandler(this.btnDosyaYolu_Click);
            // 
            // btnOlustur
            // 
            this.btnOlustur.Enabled = false;
            this.btnOlustur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOlustur.Location = new System.Drawing.Point(677, 37);
            this.btnOlustur.Name = "btnOlustur";
            this.btnOlustur.Size = new System.Drawing.Size(75, 49);
            this.btnOlustur.TabIndex = 2;
            this.btnOlustur.Text = "Broşürü Oluştur";
            this.btnOlustur.UseVisualStyleBackColor = true;
            this.btnOlustur.Click += new System.EventHandler(this.btnOlustur_Click);
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Checked = true;
            this.rb1.Enabled = false;
            this.rb1.Location = new System.Drawing.Point(314, 38);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(37, 17);
            this.rb1.TabIndex = 3;
            this.rb1.TabStop = true;
            this.rb1.Text = "1\'li";
            this.rb1.UseVisualStyleBackColor = true;
            this.rb1.CheckedChanged += new System.EventHandler(this.rb1_CheckedChanged);
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Enabled = false;
            this.rb2.Location = new System.Drawing.Point(356, 38);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(37, 17);
            this.rb2.TabIndex = 3;
            this.rb2.Text = "2\'li";
            this.rb2.UseVisualStyleBackColor = true;
            this.rb2.CheckedChanged += new System.EventHandler(this.rb1_CheckedChanged);
            // 
            // rb4
            // 
            this.rb4.AutoSize = true;
            this.rb4.Enabled = false;
            this.rb4.Location = new System.Drawing.Point(398, 38);
            this.rb4.Name = "rb4";
            this.rb4.Size = new System.Drawing.Size(41, 17);
            this.rb4.TabIndex = 3;
            this.rb4.Text = "4\'lü";
            this.rb4.UseVisualStyleBackColor = true;
            this.rb4.CheckedChanged += new System.EventHandler(this.rb1_CheckedChanged);
            // 
            // rb6
            // 
            this.rb6.AutoSize = true;
            this.rb6.Enabled = false;
            this.rb6.Location = new System.Drawing.Point(444, 38);
            this.rb6.Name = "rb6";
            this.rb6.Size = new System.Drawing.Size(37, 17);
            this.rb6.TabIndex = 3;
            this.rb6.Text = "6\'lı";
            this.rb6.UseVisualStyleBackColor = true;
            this.rb6.CheckedChanged += new System.EventHandler(this.rb1_CheckedChanged);
            // 
            // rb9
            // 
            this.rb9.AutoSize = true;
            this.rb9.Enabled = false;
            this.rb9.Location = new System.Drawing.Point(486, 38);
            this.rb9.Name = "rb9";
            this.rb9.Size = new System.Drawing.Size(41, 17);
            this.rb9.TabIndex = 3;
            this.rb9.Text = "9\'lu";
            this.rb9.UseVisualStyleBackColor = true;
            this.rb9.CheckedChanged += new System.EventHandler(this.rb1_CheckedChanged);
            // 
            // rb12
            // 
            this.rb12.AutoSize = true;
            this.rb12.Enabled = false;
            this.rb12.Location = new System.Drawing.Point(532, 38);
            this.rb12.Name = "rb12";
            this.rb12.Size = new System.Drawing.Size(43, 17);
            this.rb12.TabIndex = 3;
            this.rb12.Text = "12\'li";
            this.rb12.UseVisualStyleBackColor = true;
            this.rb12.CheckedChanged += new System.EventHandler(this.rb1_CheckedChanged);
            // 
            // rb16
            // 
            this.rb16.AutoSize = true;
            this.rb16.Enabled = false;
            this.rb16.Location = new System.Drawing.Point(580, 38);
            this.rb16.Name = "rb16";
            this.rb16.Size = new System.Drawing.Size(43, 17);
            this.rb16.TabIndex = 3;
            this.rb16.Text = "16\'lı";
            this.rb16.UseVisualStyleBackColor = true;
            this.rb16.CheckedChanged += new System.EventHandler(this.rb1_CheckedChanged);
            // 
            // rb20
            // 
            this.rb20.AutoSize = true;
            this.rb20.Enabled = false;
            this.rb20.Location = new System.Drawing.Point(628, 38);
            this.rb20.Name = "rb20";
            this.rb20.Size = new System.Drawing.Size(43, 17);
            this.rb20.TabIndex = 3;
            this.rb20.Text = "20\'li";
            this.rb20.UseVisualStyleBackColor = true;
            this.rb20.CheckedChanged += new System.EventHandler(this.rb1_CheckedChanged);
            // 
            // txtCiktiYolu
            // 
            this.txtCiktiYolu.BackColor = System.Drawing.Color.White;
            this.txtCiktiYolu.Enabled = false;
            this.txtCiktiYolu.Location = new System.Drawing.Point(482, 11);
            this.txtCiktiYolu.Name = "txtCiktiYolu";
            this.txtCiktiYolu.ReadOnly = true;
            this.txtCiktiYolu.Size = new System.Drawing.Size(270, 20);
            this.txtCiktiYolu.TabIndex = 0;
            this.txtCiktiYolu.Visible = false;
            this.txtCiktiYolu.TextChanged += new System.EventHandler(this.txtDosyaYolu_TextChanged);
            // 
            // btnCiktiYolu
            // 
            this.btnCiktiYolu.Enabled = false;
            this.btnCiktiYolu.Location = new System.Drawing.Point(677, 11);
            this.btnCiktiYolu.Name = "btnCiktiYolu";
            this.btnCiktiYolu.Size = new System.Drawing.Size(75, 21);
            this.btnCiktiYolu.TabIndex = 1;
            this.btnCiktiYolu.Text = "Çıktı Yolu";
            this.btnCiktiYolu.UseVisualStyleBackColor = true;
            this.btnCiktiYolu.Visible = false;
            this.btnCiktiYolu.Click += new System.EventHandler(this.btnCiktiYolu_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.cbArkaplansiz);
            this.splitContainer1.Panel1.Controls.Add(this.cmbBarkodTur);
            this.splitContainer1.Panel1.Controls.Add(this.cbKaynaktakiDosyalariSilme);
            this.splitContainer1.Panel1.Controls.Add(this.cmbRenkler);
            this.splitContainer1.Panel1.Controls.Add(this.lblAciklama);
            this.splitContainer1.Panel1.Controls.Add(this.txtExcel);
            this.splitContainer1.Panel1.Controls.Add(this.txtRenk);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.txtKoliAdedi);
            this.splitContainer1.Panel1.Controls.Add(this.txtBarkodRenk);
            this.splitContainer1.Panel1.Controls.Add(this.txtDosyaYolu);
            this.splitContainer1.Panel1.Controls.Add(this.btnExcelDosyasi);
            this.splitContainer1.Panel1.Controls.Add(this.btnDosyaYolu);
            this.splitContainer1.Panel1.Controls.Add(this.rb20);
            this.splitContainer1.Panel1.Controls.Add(this.txtCiktiYolu);
            this.splitContainer1.Panel1.Controls.Add(this.rb16);
            this.splitContainer1.Panel1.Controls.Add(this.btnCiktiYolu);
            this.splitContainer1.Panel1.Controls.Add(this.rb12);
            this.splitContainer1.Panel1.Controls.Add(this.btnOlustur);
            this.splitContainer1.Panel1.Controls.Add(this.rb4);
            this.splitContainer1.Panel1.Controls.Add(this.rb1);
            this.splitContainer1.Panel1.Controls.Add(this.rb9);
            this.splitContainer1.Panel1.Controls.Add(this.rb6);
            this.splitContainer1.Panel1.Controls.Add(this.rb2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.webBrowser1);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.pnlAciklama);
            this.splitContainer1.Size = new System.Drawing.Size(774, 482);
            this.splitContainer1.SplitterDistance = 96;
            this.splitContainer1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(613, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 23);
            this.button2.TabIndex = 30;
            this.button2.Text = "Barkod Oluştur (Çoklu)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(468, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 23);
            this.button1.TabIndex = 30;
            this.button1.Text = "Barkod Oluştur (Tekli)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbArkaplansiz
            // 
            this.cbArkaplansiz.AutoSize = true;
            this.cbArkaplansiz.Checked = true;
            this.cbArkaplansiz.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbArkaplansiz.Location = new System.Drawing.Point(580, 66);
            this.cbArkaplansiz.Name = "cbArkaplansiz";
            this.cbArkaplansiz.Size = new System.Drawing.Size(80, 17);
            this.cbArkaplansiz.TabIndex = 29;
            this.cbArkaplansiz.Text = "Arkaplansız";
            this.cbArkaplansiz.UseVisualStyleBackColor = true;
            // 
            // pnlAciklama
            // 
            this.pnlAciklama.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAciklama.Controls.Add(this.label5);
            this.pnlAciklama.Location = new System.Drawing.Point(193, 25);
            this.pnlAciklama.Name = "pnlAciklama";
            this.pnlAciklama.Size = new System.Drawing.Size(200, 72);
            this.pnlAciklama.TabIndex = 26;
            this.pnlAciklama.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(2, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 65);
            this.label5.TabIndex = 0;
            this.label5.Text = "Excel dosyasında;\r\n\r\n1. kolon koli adedini belirtir,\r\n2. kolon ürün adı ve açıkla" +
    "masını belirtir,\r\n3. kolon barkod numarasını belirtir.";
            // 
            // cmbBarkodTur
            // 
            this.cmbBarkodTur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBarkodTur.Enabled = false;
            this.cmbBarkodTur.FormattingEnabled = true;
            this.cmbBarkodTur.Items.AddRange(new object[] {
            "EAN-13",
            "EAN-8"});
            this.cmbBarkodTur.Location = new System.Drawing.Point(567, 64);
            this.cmbBarkodTur.Name = "cmbBarkodTur";
            this.cmbBarkodTur.Size = new System.Drawing.Size(104, 21);
            this.cmbBarkodTur.TabIndex = 28;
            this.cmbBarkodTur.Visible = false;
            // 
            // cbKaynaktakiDosyalariSilme
            // 
            this.cbKaynaktakiDosyalariSilme.AutoSize = true;
            this.cbKaynaktakiDosyalariSilme.Location = new System.Drawing.Point(466, 67);
            this.cbKaynaktakiDosyalariSilme.Name = "cbKaynaktakiDosyalariSilme";
            this.cbKaynaktakiDosyalariSilme.Size = new System.Drawing.Size(15, 14);
            this.cbKaynaktakiDosyalariSilme.TabIndex = 27;
            this.toolTip1.SetToolTip(this.cbKaynaktakiDosyalariSilme, "Kaynak dosyaları silme");
            this.cbKaynaktakiDosyalariSilme.UseVisualStyleBackColor = true;
            this.cbKaynaktakiDosyalariSilme.Visible = false;
            // 
            // cmbRenkler
            // 
            this.cmbRenkler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRenkler.Enabled = false;
            this.cmbRenkler.FormattingEnabled = true;
            this.cmbRenkler.Items.AddRange(new object[] {
            "Beyaz",
            "Gri"});
            this.cmbRenkler.Location = new System.Drawing.Point(200, 37);
            this.cmbRenkler.Name = "cmbRenkler";
            this.cmbRenkler.Size = new System.Drawing.Size(52, 21);
            this.cmbRenkler.TabIndex = 22;
            this.cmbRenkler.SelectedIndexChanged += new System.EventHandler(this.cmbRenkler_SelectedIndexChanged);
            // 
            // lblAciklama
            // 
            this.lblAciklama.AutoSize = true;
            this.lblAciklama.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAciklama.ForeColor = System.Drawing.Color.Red;
            this.lblAciklama.Location = new System.Drawing.Point(398, 67);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(58, 13);
            this.lblAciklama.TabIndex = 25;
            this.lblAciklama.Text = "Açıklama";
            this.lblAciklama.MouseLeave += new System.EventHandler(this.lblAciklama_MouseLeave);
            this.lblAciklama.MouseHover += new System.EventHandler(this.lblAciklama_MouseHover);
            // 
            // txtExcel
            // 
            this.txtExcel.BackColor = System.Drawing.Color.White;
            this.txtExcel.Enabled = false;
            this.txtExcel.Location = new System.Drawing.Point(12, 64);
            this.txtExcel.Name = "txtExcel";
            this.txtExcel.Size = new System.Drawing.Size(270, 20);
            this.txtExcel.TabIndex = 24;
            // 
            // txtRenk
            // 
            this.txtRenk.Enabled = false;
            this.txtRenk.Location = new System.Drawing.Point(255, 38);
            this.txtRenk.Name = "txtRenk";
            this.txtRenk.Size = new System.Drawing.Size(56, 20);
            this.txtRenk.TabIndex = 22;
            this.txtRenk.Text = "#FFFFFF";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Renk:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(498, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Barkod Tür:";
            this.label3.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Koli Adedi Kısmı:";
            // 
            // txtKoliAdedi
            // 
            this.txtKoliAdedi.Enabled = false;
            this.txtKoliAdedi.Location = new System.Drawing.Point(95, 37);
            this.txtKoliAdedi.MaxLength = 8;
            this.txtKoliAdedi.Name = "txtKoliAdedi";
            this.txtKoliAdedi.Size = new System.Drawing.Size(68, 20);
            this.txtKoliAdedi.TabIndex = 5;
            this.txtKoliAdedi.Text = "KOLİ AD.";
            // 
            // btnExcelDosyasi
            // 
            this.btnExcelDosyasi.Enabled = false;
            this.btnExcelDosyasi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnExcelDosyasi.Location = new System.Drawing.Point(288, 63);
            this.btnExcelDosyasi.Name = "btnExcelDosyasi";
            this.btnExcelDosyasi.Size = new System.Drawing.Size(103, 21);
            this.btnExcelDosyasi.TabIndex = 1;
            this.btnExcelDosyasi.Text = "Bilgiler Dosya Yolu";
            this.btnExcelDosyasi.UseVisualStyleBackColor = true;
            this.btnExcelDosyasi.Click += new System.EventHandler(this.btnExcelDosyasi_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(774, 352);
            this.webBrowser1.TabIndex = 4;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnYazdir);
            this.panel1.Controls.Add(this.btnKaydet);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 352);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(774, 30);
            this.panel1.TabIndex = 23;
            // 
            // btnYazdir
            // 
            this.btnYazdir.BackColor = System.Drawing.Color.White;
            this.btnYazdir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYazdir.Image = global::Sultanlar.UI.Properties.Resources.yazdir;
            this.btnYazdir.Location = new System.Drawing.Point(4, 3);
            this.btnYazdir.Name = "btnYazdir";
            this.btnYazdir.Size = new System.Drawing.Size(32, 24);
            this.btnYazdir.TabIndex = 21;
            this.btnYazdir.UseVisualStyleBackColor = false;
            this.btnYazdir.Click += new System.EventHandler(this.btnYazdir_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnKaydet.Enabled = false;
            this.btnKaydet.Location = new System.Drawing.Point(654, 0);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(120, 30);
            this.btnKaydet.TabIndex = 22;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtBarkodRenk
            // 
            this.txtBarkodRenk.BackColor = System.Drawing.Color.White;
            this.txtBarkodRenk.Location = new System.Drawing.Point(418, 12);
            this.txtBarkodRenk.Name = "txtBarkodRenk";
            this.txtBarkodRenk.Size = new System.Drawing.Size(44, 20);
            this.txtBarkodRenk.TabIndex = 0;
            this.txtBarkodRenk.Text = "000000";
            this.txtBarkodRenk.TextChanged += new System.EventHandler(this.txtDosyaYolu_TextChanged);
            // 
            // frmBrosur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 482);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(790, 520);
            this.Name = "frmBrosur";
            this.Text = "Broşür Hazırlama";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBrosur_FormClosing);
            this.Load += new System.EventHandler(this.frmBrosur_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlAciklama.ResumeLayout(false);
            this.pnlAciklama.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDosyaYolu;
        private System.Windows.Forms.Button btnDosyaYolu;
        private System.Windows.Forms.Button btnOlustur;
        private System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.RadioButton rb2;
        private System.Windows.Forms.RadioButton rb4;
        private System.Windows.Forms.RadioButton rb6;
        private System.Windows.Forms.RadioButton rb9;
        private System.Windows.Forms.RadioButton rb12;
        private System.Windows.Forms.RadioButton rb16;
        private System.Windows.Forms.RadioButton rb20;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox txtCiktiYolu;
        private System.Windows.Forms.Button btnCiktiYolu;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtKoliAdedi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnYazdir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtExcel;
        private System.Windows.Forms.Button btnExcelDosyasi;
        private System.Windows.Forms.Label lblAciklama;
        private System.Windows.Forms.Panel pnlAciklama;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbRenkler;
        private System.Windows.Forms.TextBox txtRenk;
        private System.Windows.Forms.CheckBox cbKaynaktakiDosyalariSilme;
        private System.Windows.Forms.ComboBox cmbBarkodTur;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbArkaplansiz;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtBarkodRenk;
    }
}