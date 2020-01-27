namespace Sultanlar.UI
{
    partial class frmAraclar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAraclar));
            this.lbArabalar = new System.Windows.Forms.ListBox();
            this.gbAyrintilar = new System.Windows.Forms.GroupBox();
            this.dtpKiraBitis = new System.Windows.Forms.DateTimePicker();
            this.dtpKiraBaslangic = new System.Windows.Forms.DateTimePicker();
            this.btnArabaTemizle = new System.Windows.Forms.Button();
            this.btnArabaSil = new System.Windows.Forms.Button();
            this.btnArabaGuncelle = new System.Windows.Forms.Button();
            this.btnArabaEkle = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbLogoYok = new System.Windows.Forms.RadioButton();
            this.rbLogoVar = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbK2BelgeYok = new System.Windows.Forms.RadioButton();
            this.rbK2BelgeVar = new System.Windows.Forms.RadioButton();
            this.txtArabaPlaka = new System.Windows.Forms.TextBox();
            this.txtArabaModeli = new System.Windows.Forms.TextBox();
            this.cmbArabaTurleri = new System.Windows.Forms.ComboBox();
            this.cmbArabaKimeAit = new System.Windows.Forms.ComboBox();
            this.cmbMarkalar = new System.Windows.Forms.ComboBox();
            this.cmbDepartmanlar = new System.Windows.Forms.ComboBox();
            this.cmbModelYillari = new System.Windows.Forms.ComboBox();
            this.cmbYakitTurleri = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbMuayeneler = new System.Windows.Forms.GroupBox();
            this.dtpMuayeneBitis = new System.Windows.Forms.DateTimePicker();
            this.dtpMuayeneBaslangic = new System.Windows.Forms.DateTimePicker();
            this.dgvMuayeneler = new System.Windows.Forms.DataGridView();
            this.cldtMuayeneBaslangic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cldtMuayeneBitis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnMuayeneEkle = new System.Windows.Forms.Button();
            this.gbSigortalar = new System.Windows.Forms.GroupBox();
            this.dtpSigortaBitis = new System.Windows.Forms.DateTimePicker();
            this.dgvSigortalar = new System.Windows.Forms.DataGridView();
            this.cldtSigortaBaslangic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cldtSigortaBitis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpSigortaBaslangic = new System.Windows.Forms.DateTimePicker();
            this.btnSigortaEkle = new System.Windows.Forms.Button();
            this.btnSigortaBitis = new System.Windows.Forms.Button();
            this.btnMuayeneBitis = new System.Windows.Forms.Button();
            this.btnSigortaBiten = new System.Windows.Forms.Button();
            this.btnMuayeneBiten = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gbAyrintilar.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbMuayeneler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMuayeneler)).BeginInit();
            this.gbSigortalar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSigortalar)).BeginInit();
            this.SuspendLayout();
            // 
            // lbArabalar
            // 
            this.lbArabalar.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbArabalar.FormattingEnabled = true;
            this.lbArabalar.Location = new System.Drawing.Point(0, 0);
            this.lbArabalar.Name = "lbArabalar";
            this.lbArabalar.Size = new System.Drawing.Size(187, 632);
            this.lbArabalar.TabIndex = 0;
            this.lbArabalar.SelectedIndexChanged += new System.EventHandler(this.lbArabalar_SelectedIndexChanged);
            // 
            // gbAyrintilar
            // 
            this.gbAyrintilar.Controls.Add(this.dtpKiraBitis);
            this.gbAyrintilar.Controls.Add(this.dtpKiraBaslangic);
            this.gbAyrintilar.Controls.Add(this.btnArabaTemizle);
            this.gbAyrintilar.Controls.Add(this.btnArabaSil);
            this.gbAyrintilar.Controls.Add(this.btnArabaGuncelle);
            this.gbAyrintilar.Controls.Add(this.btnArabaEkle);
            this.gbAyrintilar.Controls.Add(this.panel2);
            this.gbAyrintilar.Controls.Add(this.panel1);
            this.gbAyrintilar.Controls.Add(this.txtArabaPlaka);
            this.gbAyrintilar.Controls.Add(this.txtArabaModeli);
            this.gbAyrintilar.Controls.Add(this.cmbArabaTurleri);
            this.gbAyrintilar.Controls.Add(this.cmbArabaKimeAit);
            this.gbAyrintilar.Controls.Add(this.cmbMarkalar);
            this.gbAyrintilar.Controls.Add(this.cmbDepartmanlar);
            this.gbAyrintilar.Controls.Add(this.cmbModelYillari);
            this.gbAyrintilar.Controls.Add(this.cmbYakitTurleri);
            this.gbAyrintilar.Controls.Add(this.label3);
            this.gbAyrintilar.Controls.Add(this.label6);
            this.gbAyrintilar.Controls.Add(this.label4);
            this.gbAyrintilar.Controls.Add(this.label7);
            this.gbAyrintilar.Controls.Add(this.label8);
            this.gbAyrintilar.Controls.Add(this.label5);
            this.gbAyrintilar.Controls.Add(this.label10);
            this.gbAyrintilar.Controls.Add(this.label9);
            this.gbAyrintilar.Controls.Add(this.label11);
            this.gbAyrintilar.Controls.Add(this.label2);
            this.gbAyrintilar.Controls.Add(this.label1);
            this.gbAyrintilar.Location = new System.Drawing.Point(193, 37);
            this.gbAyrintilar.Name = "gbAyrintilar";
            this.gbAyrintilar.Size = new System.Drawing.Size(512, 219);
            this.gbAyrintilar.TabIndex = 4;
            this.gbAyrintilar.TabStop = false;
            this.gbAyrintilar.Text = "Ayrıntılar";
            // 
            // dtpKiraBitis
            // 
            this.dtpKiraBitis.Enabled = false;
            this.dtpKiraBitis.Location = new System.Drawing.Point(329, 131);
            this.dtpKiraBitis.Name = "dtpKiraBitis";
            this.dtpKiraBitis.Size = new System.Drawing.Size(170, 20);
            this.dtpKiraBitis.TabIndex = 15;
            // 
            // dtpKiraBaslangic
            // 
            this.dtpKiraBaslangic.Enabled = false;
            this.dtpKiraBaslangic.Location = new System.Drawing.Point(86, 131);
            this.dtpKiraBaslangic.Name = "dtpKiraBaslangic";
            this.dtpKiraBaslangic.Size = new System.Drawing.Size(170, 20);
            this.dtpKiraBaslangic.TabIndex = 8;
            // 
            // btnArabaTemizle
            // 
            this.btnArabaTemizle.Location = new System.Drawing.Point(354, 185);
            this.btnArabaTemizle.Name = "btnArabaTemizle";
            this.btnArabaTemizle.Size = new System.Drawing.Size(75, 23);
            this.btnArabaTemizle.TabIndex = 19;
            this.btnArabaTemizle.Text = "Temizle";
            this.btnArabaTemizle.UseVisualStyleBackColor = true;
            this.btnArabaTemizle.Click += new System.EventHandler(this.btnArabaTemizle_Click);
            // 
            // btnArabaSil
            // 
            this.btnArabaSil.Enabled = false;
            this.btnArabaSil.Location = new System.Drawing.Point(273, 185);
            this.btnArabaSil.Name = "btnArabaSil";
            this.btnArabaSil.Size = new System.Drawing.Size(75, 23);
            this.btnArabaSil.TabIndex = 18;
            this.btnArabaSil.Text = "Sil";
            this.btnArabaSil.UseVisualStyleBackColor = true;
            this.btnArabaSil.Click += new System.EventHandler(this.btnArabaSil_Click);
            // 
            // btnArabaGuncelle
            // 
            this.btnArabaGuncelle.Enabled = false;
            this.btnArabaGuncelle.Location = new System.Drawing.Point(192, 185);
            this.btnArabaGuncelle.Name = "btnArabaGuncelle";
            this.btnArabaGuncelle.Size = new System.Drawing.Size(75, 23);
            this.btnArabaGuncelle.TabIndex = 17;
            this.btnArabaGuncelle.Text = "Güncelle";
            this.btnArabaGuncelle.UseVisualStyleBackColor = true;
            this.btnArabaGuncelle.Click += new System.EventHandler(this.btnArabaGuncelle_Click);
            // 
            // btnArabaEkle
            // 
            this.btnArabaEkle.Location = new System.Drawing.Point(111, 185);
            this.btnArabaEkle.Name = "btnArabaEkle";
            this.btnArabaEkle.Size = new System.Drawing.Size(75, 23);
            this.btnArabaEkle.TabIndex = 16;
            this.btnArabaEkle.Text = "Ekle";
            this.btnArabaEkle.UseVisualStyleBackColor = true;
            this.btnArabaEkle.EnabledChanged += new System.EventHandler(this.btnArabaEkle_EnabledChanged);
            this.btnArabaEkle.Click += new System.EventHandler(this.btnArabaEkle_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbLogoYok);
            this.panel2.Controls.Add(this.rbLogoVar);
            this.panel2.Location = new System.Drawing.Point(329, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(170, 23);
            this.panel2.TabIndex = 12;
            // 
            // rbLogoYok
            // 
            this.rbLogoYok.AutoSize = true;
            this.rbLogoYok.Checked = true;
            this.rbLogoYok.Location = new System.Drawing.Point(86, 2);
            this.rbLogoYok.Name = "rbLogoYok";
            this.rbLogoYok.Size = new System.Drawing.Size(44, 17);
            this.rbLogoYok.TabIndex = 12;
            this.rbLogoYok.TabStop = true;
            this.rbLogoYok.Text = "Yok";
            this.rbLogoYok.UseVisualStyleBackColor = true;
            // 
            // rbLogoVar
            // 
            this.rbLogoVar.AutoSize = true;
            this.rbLogoVar.Location = new System.Drawing.Point(21, 2);
            this.rbLogoVar.Name = "rbLogoVar";
            this.rbLogoVar.Size = new System.Drawing.Size(41, 17);
            this.rbLogoVar.TabIndex = 12;
            this.rbLogoVar.Text = "Var";
            this.rbLogoVar.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbK2BelgeYok);
            this.panel1.Controls.Add(this.rbK2BelgeVar);
            this.panel1.Location = new System.Drawing.Point(329, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(170, 23);
            this.panel1.TabIndex = 11;
            // 
            // rbK2BelgeYok
            // 
            this.rbK2BelgeYok.AutoSize = true;
            this.rbK2BelgeYok.Checked = true;
            this.rbK2BelgeYok.Location = new System.Drawing.Point(86, 2);
            this.rbK2BelgeYok.Name = "rbK2BelgeYok";
            this.rbK2BelgeYok.Size = new System.Drawing.Size(44, 17);
            this.rbK2BelgeYok.TabIndex = 11;
            this.rbK2BelgeYok.TabStop = true;
            this.rbK2BelgeYok.Text = "Yok";
            this.rbK2BelgeYok.UseVisualStyleBackColor = true;
            // 
            // rbK2BelgeVar
            // 
            this.rbK2BelgeVar.AutoSize = true;
            this.rbK2BelgeVar.Location = new System.Drawing.Point(21, 2);
            this.rbK2BelgeVar.Name = "rbK2BelgeVar";
            this.rbK2BelgeVar.Size = new System.Drawing.Size(41, 17);
            this.rbK2BelgeVar.TabIndex = 11;
            this.rbK2BelgeVar.Text = "Var";
            this.rbK2BelgeVar.UseVisualStyleBackColor = true;
            // 
            // txtArabaPlaka
            // 
            this.txtArabaPlaka.Location = new System.Drawing.Point(86, 24);
            this.txtArabaPlaka.Name = "txtArabaPlaka";
            this.txtArabaPlaka.Size = new System.Drawing.Size(170, 20);
            this.txtArabaPlaka.TabIndex = 4;
            // 
            // txtArabaModeli
            // 
            this.txtArabaModeli.Location = new System.Drawing.Point(329, 104);
            this.txtArabaModeli.Name = "txtArabaModeli";
            this.txtArabaModeli.Size = new System.Drawing.Size(97, 20);
            this.txtArabaModeli.TabIndex = 13;
            // 
            // cmbArabaTurleri
            // 
            this.cmbArabaTurleri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArabaTurleri.FormattingEnabled = true;
            this.cmbArabaTurleri.Location = new System.Drawing.Point(86, 50);
            this.cmbArabaTurleri.Name = "cmbArabaTurleri";
            this.cmbArabaTurleri.Size = new System.Drawing.Size(170, 21);
            this.cmbArabaTurleri.TabIndex = 5;
            // 
            // cmbArabaKimeAit
            // 
            this.cmbArabaKimeAit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArabaKimeAit.FormattingEnabled = true;
            this.cmbArabaKimeAit.Location = new System.Drawing.Point(86, 156);
            this.cmbArabaKimeAit.Name = "cmbArabaKimeAit";
            this.cmbArabaKimeAit.Size = new System.Drawing.Size(170, 21);
            this.cmbArabaKimeAit.TabIndex = 9;
            this.cmbArabaKimeAit.SelectedIndexChanged += new System.EventHandler(this.cmbArabaKimeAit_SelectedIndexChanged);
            // 
            // cmbMarkalar
            // 
            this.cmbMarkalar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarkalar.FormattingEnabled = true;
            this.cmbMarkalar.Location = new System.Drawing.Point(86, 104);
            this.cmbMarkalar.Name = "cmbMarkalar";
            this.cmbMarkalar.Size = new System.Drawing.Size(170, 21);
            this.cmbMarkalar.TabIndex = 7;
            // 
            // cmbDepartmanlar
            // 
            this.cmbDepartmanlar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartmanlar.FormattingEnabled = true;
            this.cmbDepartmanlar.Location = new System.Drawing.Point(86, 77);
            this.cmbDepartmanlar.Name = "cmbDepartmanlar";
            this.cmbDepartmanlar.Size = new System.Drawing.Size(170, 21);
            this.cmbDepartmanlar.TabIndex = 6;
            // 
            // cmbModelYillari
            // 
            this.cmbModelYillari.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModelYillari.FormattingEnabled = true;
            this.cmbModelYillari.Items.AddRange(new object[] {
            "1990",
            "1991",
            "1992",
            "1993",
            "1994",
            "1995",
            "1996",
            "1997",
            "1998",
            "1999",
            "2000",
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013"});
            this.cmbModelYillari.Location = new System.Drawing.Point(432, 104);
            this.cmbModelYillari.Name = "cmbModelYillari";
            this.cmbModelYillari.Size = new System.Drawing.Size(67, 21);
            this.cmbModelYillari.TabIndex = 14;
            // 
            // cmbYakitTurleri
            // 
            this.cmbYakitTurleri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYakitTurleri.FormattingEnabled = true;
            this.cmbYakitTurleri.Location = new System.Drawing.Point(329, 24);
            this.cmbYakitTurleri.Name = "cmbYakitTurleri";
            this.cmbYakitTurleri.Size = new System.Drawing.Size(170, 21);
            this.cmbYakitTurleri.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tür:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(264, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Logo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(264, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "K2 Belge:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Plaka:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(264, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Model:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Departman:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(264, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Kira Bitiş:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Kira Başlangıç:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 159);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Kime Ait:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Marka:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(264, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Yakıt Türü:";
            // 
            // gbMuayeneler
            // 
            this.gbMuayeneler.Controls.Add(this.dtpMuayeneBitis);
            this.gbMuayeneler.Controls.Add(this.dtpMuayeneBaslangic);
            this.gbMuayeneler.Controls.Add(this.dgvMuayeneler);
            this.gbMuayeneler.Controls.Add(this.btnMuayeneEkle);
            this.gbMuayeneler.Location = new System.Drawing.Point(193, 262);
            this.gbMuayeneler.Name = "gbMuayeneler";
            this.gbMuayeneler.Size = new System.Drawing.Size(512, 165);
            this.gbMuayeneler.TabIndex = 20;
            this.gbMuayeneler.TabStop = false;
            this.gbMuayeneler.Text = "Muayeneler";
            // 
            // dtpMuayeneBitis
            // 
            this.dtpMuayeneBitis.Enabled = false;
            this.dtpMuayeneBitis.Location = new System.Drawing.Point(215, 133);
            this.dtpMuayeneBitis.Name = "dtpMuayeneBitis";
            this.dtpMuayeneBitis.Size = new System.Drawing.Size(200, 20);
            this.dtpMuayeneBitis.TabIndex = 22;
            // 
            // dtpMuayeneBaslangic
            // 
            this.dtpMuayeneBaslangic.Enabled = false;
            this.dtpMuayeneBaslangic.Location = new System.Drawing.Point(9, 133);
            this.dtpMuayeneBaslangic.Name = "dtpMuayeneBaslangic";
            this.dtpMuayeneBaslangic.Size = new System.Drawing.Size(200, 20);
            this.dtpMuayeneBaslangic.TabIndex = 21;
            // 
            // dgvMuayeneler
            // 
            this.dgvMuayeneler.AllowUserToAddRows = false;
            this.dgvMuayeneler.AllowUserToDeleteRows = false;
            this.dgvMuayeneler.AllowUserToResizeColumns = false;
            this.dgvMuayeneler.AllowUserToResizeRows = false;
            this.dgvMuayeneler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMuayeneler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cldtMuayeneBaslangic,
            this.cldtMuayeneBitis});
            this.dgvMuayeneler.Location = new System.Drawing.Point(9, 19);
            this.dgvMuayeneler.MultiSelect = false;
            this.dgvMuayeneler.Name = "dgvMuayeneler";
            this.dgvMuayeneler.ReadOnly = true;
            this.dgvMuayeneler.RowHeadersVisible = false;
            this.dgvMuayeneler.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvMuayeneler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMuayeneler.Size = new System.Drawing.Size(490, 108);
            this.dgvMuayeneler.TabIndex = 20;
            // 
            // cldtMuayeneBaslangic
            // 
            this.cldtMuayeneBaslangic.DataPropertyName = "dtMuayeneBaslangic";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.cldtMuayeneBaslangic.DefaultCellStyle = dataGridViewCellStyle1;
            this.cldtMuayeneBaslangic.HeaderText = "Muayene Başlangıç";
            this.cldtMuayeneBaslangic.Name = "cldtMuayeneBaslangic";
            this.cldtMuayeneBaslangic.ReadOnly = true;
            this.cldtMuayeneBaslangic.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cldtMuayeneBaslangic.Width = 234;
            // 
            // cldtMuayeneBitis
            // 
            this.cldtMuayeneBitis.DataPropertyName = "dtMuayeneBitis";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.cldtMuayeneBitis.DefaultCellStyle = dataGridViewCellStyle2;
            this.cldtMuayeneBitis.HeaderText = "Muayene Bitiş";
            this.cldtMuayeneBitis.Name = "cldtMuayeneBitis";
            this.cldtMuayeneBitis.ReadOnly = true;
            this.cldtMuayeneBitis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cldtMuayeneBitis.Width = 234;
            // 
            // btnMuayeneEkle
            // 
            this.btnMuayeneEkle.Enabled = false;
            this.btnMuayeneEkle.Location = new System.Drawing.Point(421, 131);
            this.btnMuayeneEkle.Name = "btnMuayeneEkle";
            this.btnMuayeneEkle.Size = new System.Drawing.Size(78, 23);
            this.btnMuayeneEkle.TabIndex = 23;
            this.btnMuayeneEkle.Text = "Ekle";
            this.btnMuayeneEkle.UseVisualStyleBackColor = true;
            this.btnMuayeneEkle.Click += new System.EventHandler(this.btnMuayeneEkle_Click);
            // 
            // gbSigortalar
            // 
            this.gbSigortalar.Controls.Add(this.dtpSigortaBitis);
            this.gbSigortalar.Controls.Add(this.dgvSigortalar);
            this.gbSigortalar.Controls.Add(this.dtpSigortaBaslangic);
            this.gbSigortalar.Controls.Add(this.btnSigortaEkle);
            this.gbSigortalar.Location = new System.Drawing.Point(193, 433);
            this.gbSigortalar.Name = "gbSigortalar";
            this.gbSigortalar.Size = new System.Drawing.Size(512, 164);
            this.gbSigortalar.TabIndex = 24;
            this.gbSigortalar.TabStop = false;
            this.gbSigortalar.Text = "Sigortalar";
            // 
            // dtpSigortaBitis
            // 
            this.dtpSigortaBitis.Enabled = false;
            this.dtpSigortaBitis.Location = new System.Drawing.Point(215, 133);
            this.dtpSigortaBitis.Name = "dtpSigortaBitis";
            this.dtpSigortaBitis.Size = new System.Drawing.Size(200, 20);
            this.dtpSigortaBitis.TabIndex = 26;
            // 
            // dgvSigortalar
            // 
            this.dgvSigortalar.AllowUserToAddRows = false;
            this.dgvSigortalar.AllowUserToDeleteRows = false;
            this.dgvSigortalar.AllowUserToResizeColumns = false;
            this.dgvSigortalar.AllowUserToResizeRows = false;
            this.dgvSigortalar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSigortalar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cldtSigortaBaslangic,
            this.cldtSigortaBitis});
            this.dgvSigortalar.Location = new System.Drawing.Point(9, 19);
            this.dgvSigortalar.MultiSelect = false;
            this.dgvSigortalar.Name = "dgvSigortalar";
            this.dgvSigortalar.ReadOnly = true;
            this.dgvSigortalar.RowHeadersVisible = false;
            this.dgvSigortalar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvSigortalar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSigortalar.Size = new System.Drawing.Size(490, 108);
            this.dgvSigortalar.TabIndex = 24;
            // 
            // cldtSigortaBaslangic
            // 
            this.cldtSigortaBaslangic.DataPropertyName = "dtSigortaBaslangic";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.cldtSigortaBaslangic.DefaultCellStyle = dataGridViewCellStyle3;
            this.cldtSigortaBaslangic.HeaderText = "Sigorta Başlangıç";
            this.cldtSigortaBaslangic.Name = "cldtSigortaBaslangic";
            this.cldtSigortaBaslangic.ReadOnly = true;
            this.cldtSigortaBaslangic.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cldtSigortaBaslangic.Width = 234;
            // 
            // cldtSigortaBitis
            // 
            this.cldtSigortaBitis.DataPropertyName = "dtSigortaBitis";
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.cldtSigortaBitis.DefaultCellStyle = dataGridViewCellStyle4;
            this.cldtSigortaBitis.HeaderText = "Sigorta Bitiş";
            this.cldtSigortaBitis.Name = "cldtSigortaBitis";
            this.cldtSigortaBitis.ReadOnly = true;
            this.cldtSigortaBitis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cldtSigortaBitis.Width = 234;
            // 
            // dtpSigortaBaslangic
            // 
            this.dtpSigortaBaslangic.Enabled = false;
            this.dtpSigortaBaslangic.Location = new System.Drawing.Point(9, 133);
            this.dtpSigortaBaslangic.Name = "dtpSigortaBaslangic";
            this.dtpSigortaBaslangic.Size = new System.Drawing.Size(200, 20);
            this.dtpSigortaBaslangic.TabIndex = 25;
            // 
            // btnSigortaEkle
            // 
            this.btnSigortaEkle.Enabled = false;
            this.btnSigortaEkle.Location = new System.Drawing.Point(421, 131);
            this.btnSigortaEkle.Name = "btnSigortaEkle";
            this.btnSigortaEkle.Size = new System.Drawing.Size(78, 23);
            this.btnSigortaEkle.TabIndex = 27;
            this.btnSigortaEkle.Text = "Ekle";
            this.btnSigortaEkle.UseVisualStyleBackColor = true;
            this.btnSigortaEkle.Click += new System.EventHandler(this.btnSigortaEkle_Click);
            // 
            // btnSigortaBitis
            // 
            this.btnSigortaBitis.BackColor = System.Drawing.Color.Red;
            this.btnSigortaBitis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSigortaBitis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSigortaBitis.ForeColor = System.Drawing.Color.White;
            this.btnSigortaBitis.Location = new System.Drawing.Point(450, 8);
            this.btnSigortaBitis.Name = "btnSigortaBitis";
            this.btnSigortaBitis.Size = new System.Drawing.Size(255, 23);
            this.btnSigortaBitis.TabIndex = 3;
            this.btnSigortaBitis.Text = "Sigorta bitişi yaklaşan 0 araç var";
            this.btnSigortaBitis.UseVisualStyleBackColor = false;
            this.btnSigortaBitis.Click += new System.EventHandler(this.btnSigortaBitis_Click);
            // 
            // btnMuayeneBitis
            // 
            this.btnMuayeneBitis.BackColor = System.Drawing.Color.Red;
            this.btnMuayeneBitis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMuayeneBitis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMuayeneBitis.ForeColor = System.Drawing.Color.White;
            this.btnMuayeneBitis.Location = new System.Drawing.Point(193, 8);
            this.btnMuayeneBitis.Name = "btnMuayeneBitis";
            this.btnMuayeneBitis.Size = new System.Drawing.Size(251, 23);
            this.btnMuayeneBitis.TabIndex = 2;
            this.btnMuayeneBitis.Text = "Muayene bitişi yaklaşan 0 araç var";
            this.btnMuayeneBitis.UseVisualStyleBackColor = false;
            this.btnMuayeneBitis.Click += new System.EventHandler(this.btnMuayeneBitis_Click);
            // 
            // btnSigortaBiten
            // 
            this.btnSigortaBiten.BackColor = System.Drawing.Color.Red;
            this.btnSigortaBiten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSigortaBiten.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSigortaBiten.ForeColor = System.Drawing.Color.White;
            this.btnSigortaBiten.Location = new System.Drawing.Point(450, 603);
            this.btnSigortaBiten.Name = "btnSigortaBiten";
            this.btnSigortaBiten.Size = new System.Drawing.Size(255, 23);
            this.btnSigortaBiten.TabIndex = 29;
            this.btnSigortaBiten.Text = "Sigortası biten 0 araç var";
            this.btnSigortaBiten.UseVisualStyleBackColor = false;
            this.btnSigortaBiten.Click += new System.EventHandler(this.btnSigortaBiten_Click);
            // 
            // btnMuayeneBiten
            // 
            this.btnMuayeneBiten.BackColor = System.Drawing.Color.Red;
            this.btnMuayeneBiten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMuayeneBiten.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMuayeneBiten.ForeColor = System.Drawing.Color.White;
            this.btnMuayeneBiten.Location = new System.Drawing.Point(193, 603);
            this.btnMuayeneBiten.Name = "btnMuayeneBiten";
            this.btnMuayeneBiten.Size = new System.Drawing.Size(255, 23);
            this.btnMuayeneBiten.TabIndex = 28;
            this.btnMuayeneBiten.Text = "Muayenesi biten 0 araç var";
            this.btnMuayeneBiten.UseVisualStyleBackColor = false;
            this.btnMuayeneBiten.Click += new System.EventHandler(this.btnMuayeneBiten_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(137, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 45);
            this.button1.TabIndex = 1;
            this.button1.Text = "Excel\'e Aktar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmAraclar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(728, 632);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnMuayeneBitis);
            this.Controls.Add(this.btnMuayeneBiten);
            this.Controls.Add(this.btnSigortaBiten);
            this.Controls.Add(this.btnSigortaBitis);
            this.Controls.Add(this.gbSigortalar);
            this.Controls.Add(this.gbMuayeneler);
            this.Controls.Add(this.gbAyrintilar);
            this.Controls.Add(this.lbArabalar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(744, 400);
            this.Name = "frmAraclar";
            this.Text = "Araçlar";
            this.Load += new System.EventHandler(this.frmAraclar_Load);
            this.gbAyrintilar.ResumeLayout(false);
            this.gbAyrintilar.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbMuayeneler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMuayeneler)).EndInit();
            this.gbSigortalar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSigortalar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbArabalar;
        private System.Windows.Forms.GroupBox gbAyrintilar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbLogoYok;
        private System.Windows.Forms.RadioButton rbLogoVar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbK2BelgeYok;
        private System.Windows.Forms.RadioButton rbK2BelgeVar;
        private System.Windows.Forms.ComboBox cmbArabaTurleri;
        private System.Windows.Forms.ComboBox cmbDepartmanlar;
        private System.Windows.Forms.ComboBox cmbYakitTurleri;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbMuayeneler;
        private System.Windows.Forms.DataGridView dgvMuayeneler;
        private System.Windows.Forms.GroupBox gbSigortalar;
        private System.Windows.Forms.DataGridView dgvSigortalar;
        private System.Windows.Forms.Button btnArabaTemizle;
        private System.Windows.Forms.Button btnArabaSil;
        private System.Windows.Forms.Button btnArabaGuncelle;
        private System.Windows.Forms.Button btnArabaEkle;
        private System.Windows.Forms.DateTimePicker dtpMuayeneBitis;
        private System.Windows.Forms.DateTimePicker dtpMuayeneBaslangic;
        private System.Windows.Forms.Button btnMuayeneEkle;
        private System.Windows.Forms.DateTimePicker dtpSigortaBitis;
        private System.Windows.Forms.DateTimePicker dtpSigortaBaslangic;
        private System.Windows.Forms.Button btnSigortaEkle;
        private System.Windows.Forms.TextBox txtArabaPlaka;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn cldtMuayeneBaslangic;
        private System.Windows.Forms.DataGridViewTextBoxColumn cldtMuayeneBitis;
        private System.Windows.Forms.DataGridViewTextBoxColumn cldtSigortaBaslangic;
        private System.Windows.Forms.DataGridViewTextBoxColumn cldtSigortaBitis;
        private System.Windows.Forms.TextBox txtArabaModeli;
        private System.Windows.Forms.ComboBox cmbMarkalar;
        private System.Windows.Forms.ComboBox cmbModelYillari;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSigortaBitis;
        private System.Windows.Forms.Button btnMuayeneBitis;
        private System.Windows.Forms.Button btnSigortaBiten;
        private System.Windows.Forms.Button btnMuayeneBiten;
        private System.Windows.Forms.DateTimePicker dtpKiraBitis;
        private System.Windows.Forms.DateTimePicker dtpKiraBaslangic;
        private System.Windows.Forms.ComboBox cmbArabaKimeAit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
    }
}