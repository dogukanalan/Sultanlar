namespace Sultanlar.UI
{
    partial class frmAracGiderleri
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAracGiderleri));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbArabalar = new System.Windows.Forms.ListBox();
            this.dgvAracGiderleri = new System.Windows.Forms.DataGridView();
            this.clpkAracGiderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrArabaPlaka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrAracFirma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cldtTarih = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clflYakit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrFaturaNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrFaturaDetayi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clflTutar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cltintKDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clflToplamTutar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cltintVade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cldtOdemeTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnFirmaEkle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnExcel = new System.Windows.Forms.Button();
            this.txtVade = new System.Windows.Forms.TextBox();
            this.txtToplamTutar = new System.Windows.Forms.TextBox();
            this.txtKDV = new System.Windows.Forms.TextBox();
            this.txtTutar = new System.Windows.Forms.TextBox();
            this.txtFaturaDetayi = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFaturaNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtYakit = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpOdemeTarihi = new System.Windows.Forms.DateTimePicker();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFirmalar = new System.Windows.Forms.ComboBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAracGiderleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbArabalar);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvAracGiderleri);
            this.splitContainer1.Size = new System.Drawing.Size(1004, 329);
            this.splitContainer1.SplitterDistance = 96;
            this.splitContainer1.TabIndex = 1;
            // 
            // lbArabalar
            // 
            this.lbArabalar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbArabalar.FormattingEnabled = true;
            this.lbArabalar.Location = new System.Drawing.Point(0, 0);
            this.lbArabalar.Name = "lbArabalar";
            this.lbArabalar.Size = new System.Drawing.Size(96, 329);
            this.lbArabalar.TabIndex = 0;
            this.lbArabalar.SelectedIndexChanged += new System.EventHandler(this.lbArabalar_SelectedIndexChanged);
            // 
            // dgvAracGiderleri
            // 
            this.dgvAracGiderleri.AllowUserToAddRows = false;
            this.dgvAracGiderleri.AllowUserToDeleteRows = false;
            this.dgvAracGiderleri.AllowUserToResizeColumns = false;
            this.dgvAracGiderleri.AllowUserToResizeRows = false;
            this.dgvAracGiderleri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAracGiderleri.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clpkAracGiderID,
            this.clstrArabaPlaka,
            this.clstrAracFirma,
            this.cldtTarih,
            this.clflYakit,
            this.clstrFaturaNo,
            this.clstrFaturaDetayi,
            this.clflTutar,
            this.cltintKDV,
            this.clflToplamTutar,
            this.cltintVade,
            this.cldtOdemeTarihi});
            this.dgvAracGiderleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAracGiderleri.Location = new System.Drawing.Point(0, 0);
            this.dgvAracGiderleri.MultiSelect = false;
            this.dgvAracGiderleri.Name = "dgvAracGiderleri";
            this.dgvAracGiderleri.ReadOnly = true;
            this.dgvAracGiderleri.RowHeadersVisible = false;
            this.dgvAracGiderleri.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAracGiderleri.Size = new System.Drawing.Size(904, 329);
            this.dgvAracGiderleri.TabIndex = 1;
            this.dgvAracGiderleri.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAracGiderleri_RowEnter);
            this.dgvAracGiderleri.SelectionChanged += new System.EventHandler(this.dgvAracGiderleri_SelectionChanged);
            // 
            // clpkAracGiderID
            // 
            this.clpkAracGiderID.DataPropertyName = "pkAracGiderID";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clpkAracGiderID.DefaultCellStyle = dataGridViewCellStyle1;
            this.clpkAracGiderID.HeaderText = "ID";
            this.clpkAracGiderID.Name = "clpkAracGiderID";
            this.clpkAracGiderID.ReadOnly = true;
            this.clpkAracGiderID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clpkAracGiderID.Width = 42;
            // 
            // clstrArabaPlaka
            // 
            this.clstrArabaPlaka.DataPropertyName = "strArabaPlaka";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clstrArabaPlaka.DefaultCellStyle = dataGridViewCellStyle2;
            this.clstrArabaPlaka.HeaderText = "Araç";
            this.clstrArabaPlaka.Name = "clstrArabaPlaka";
            this.clstrArabaPlaka.ReadOnly = true;
            this.clstrArabaPlaka.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clstrArabaPlaka.Width = 80;
            // 
            // clstrAracFirma
            // 
            this.clstrAracFirma.DataPropertyName = "strAracFirma";
            this.clstrAracFirma.HeaderText = "Firma";
            this.clstrAracFirma.Name = "clstrAracFirma";
            this.clstrAracFirma.ReadOnly = true;
            this.clstrAracFirma.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // cldtTarih
            // 
            this.cldtTarih.DataPropertyName = "dtTarih";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cldtTarih.DefaultCellStyle = dataGridViewCellStyle3;
            this.cldtTarih.HeaderText = "Tarih";
            this.cldtTarih.Name = "cldtTarih";
            this.cldtTarih.ReadOnly = true;
            this.cldtTarih.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cldtTarih.Width = 80;
            // 
            // clflYakit
            // 
            this.clflYakit.DataPropertyName = "flYakit";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.clflYakit.DefaultCellStyle = dataGridViewCellStyle4;
            this.clflYakit.HeaderText = "Yakıt";
            this.clflYakit.Name = "clflYakit";
            this.clflYakit.ReadOnly = true;
            this.clflYakit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clflYakit.Width = 60;
            // 
            // clstrFaturaNo
            // 
            this.clstrFaturaNo.DataPropertyName = "strFaturaNo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clstrFaturaNo.DefaultCellStyle = dataGridViewCellStyle5;
            this.clstrFaturaNo.HeaderText = "Fatura No";
            this.clstrFaturaNo.Name = "clstrFaturaNo";
            this.clstrFaturaNo.ReadOnly = true;
            this.clstrFaturaNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clstrFaturaNo.Width = 60;
            // 
            // clstrFaturaDetayi
            // 
            this.clstrFaturaDetayi.DataPropertyName = "strFaturaDetayi";
            this.clstrFaturaDetayi.HeaderText = "Fatura Detayı";
            this.clstrFaturaDetayi.Name = "clstrFaturaDetayi";
            this.clstrFaturaDetayi.ReadOnly = true;
            this.clstrFaturaDetayi.Width = 150;
            // 
            // clflTutar
            // 
            this.clflTutar.DataPropertyName = "flTutar";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.clflTutar.DefaultCellStyle = dataGridViewCellStyle6;
            this.clflTutar.HeaderText = "Tutar";
            this.clflTutar.Name = "clflTutar";
            this.clflTutar.ReadOnly = true;
            this.clflTutar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clflTutar.Width = 70;
            // 
            // cltintKDV
            // 
            this.cltintKDV.DataPropertyName = "tintKDV";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cltintKDV.DefaultCellStyle = dataGridViewCellStyle7;
            this.cltintKDV.HeaderText = "KDV";
            this.cltintKDV.Name = "cltintKDV";
            this.cltintKDV.ReadOnly = true;
            this.cltintKDV.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cltintKDV.Width = 45;
            // 
            // clflToplamTutar
            // 
            this.clflToplamTutar.DataPropertyName = "flToplamTutar";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = null;
            this.clflToplamTutar.DefaultCellStyle = dataGridViewCellStyle8;
            this.clflToplamTutar.HeaderText = "T. Tutar";
            this.clflToplamTutar.Name = "clflToplamTutar";
            this.clflToplamTutar.ReadOnly = true;
            this.clflToplamTutar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clflToplamTutar.Width = 70;
            // 
            // cltintVade
            // 
            this.cltintVade.DataPropertyName = "tintVade";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cltintVade.DefaultCellStyle = dataGridViewCellStyle9;
            this.cltintVade.HeaderText = "Vade";
            this.cltintVade.Name = "cltintVade";
            this.cltintVade.ReadOnly = true;
            this.cltintVade.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cltintVade.Width = 45;
            // 
            // cldtOdemeTarihi
            // 
            this.cldtOdemeTarihi.DataPropertyName = "dtOdemeTarihi";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cldtOdemeTarihi.DefaultCellStyle = dataGridViewCellStyle10;
            this.cldtOdemeTarihi.HeaderText = "Ö. Tarihi";
            this.cldtOdemeTarihi.Name = "cldtOdemeTarihi";
            this.cldtOdemeTarihi.ReadOnly = true;
            this.cldtOdemeTarihi.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cldtOdemeTarihi.Width = 80;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnFirmaEkle);
            this.splitContainer2.Panel2.Controls.Add(this.btnSil);
            this.splitContainer2.Panel2.Controls.Add(this.btnGuncelle);
            this.splitContainer2.Panel2.Controls.Add(this.progressBar1);
            this.splitContainer2.Panel2.Controls.Add(this.btnExcel);
            this.splitContainer2.Panel2.Controls.Add(this.txtVade);
            this.splitContainer2.Panel2.Controls.Add(this.txtToplamTutar);
            this.splitContainer2.Panel2.Controls.Add(this.txtKDV);
            this.splitContainer2.Panel2.Controls.Add(this.txtTutar);
            this.splitContainer2.Panel2.Controls.Add(this.txtFaturaDetayi);
            this.splitContainer2.Panel2.Controls.Add(this.label10);
            this.splitContainer2.Panel2.Controls.Add(this.txtFaturaNo);
            this.splitContainer2.Panel2.Controls.Add(this.label9);
            this.splitContainer2.Panel2.Controls.Add(this.txtYakit);
            this.splitContainer2.Panel2.Controls.Add(this.label8);
            this.splitContainer2.Panel2.Controls.Add(this.dtpOdemeTarihi);
            this.splitContainer2.Panel2.Controls.Add(this.dtpTarih);
            this.splitContainer2.Panel2.Controls.Add(this.label7);
            this.splitContainer2.Panel2.Controls.Add(this.label6);
            this.splitContainer2.Panel2.Controls.Add(this.label5);
            this.splitContainer2.Panel2.Controls.Add(this.label4);
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Panel2.Controls.Add(this.cmbFirmalar);
            this.splitContainer2.Panel2.Controls.Add(this.btnEkle);
            this.splitContainer2.Panel2.Controls.Add(this.btnTemizle);
            this.splitContainer2.Size = new System.Drawing.Size(1004, 472);
            this.splitContainer2.SplitterDistance = 329;
            this.splitContainer2.TabIndex = 2;
            // 
            // btnFirmaEkle
            // 
            this.btnFirmaEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFirmaEkle.Location = new System.Drawing.Point(413, 4);
            this.btnFirmaEkle.Name = "btnFirmaEkle";
            this.btnFirmaEkle.Size = new System.Drawing.Size(23, 23);
            this.btnFirmaEkle.TabIndex = 17;
            this.btnFirmaEkle.Text = "+";
            this.btnFirmaEkle.UseVisualStyleBackColor = true;
            this.btnFirmaEkle.Click += new System.EventHandler(this.btnFirmaEkle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(896, 108);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(96, 23);
            this.btnSil.TabIndex = 16;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(896, 79);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(96, 23);
            this.btnGuncelle.TabIndex = 15;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 87);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(96, 23);
            this.progressBar1.TabIndex = 14;
            this.progressBar1.Visible = false;
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(0, 116);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(96, 23);
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Text = "Excel\'e Aktar";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // txtVade
            // 
            this.txtVade.Location = new System.Drawing.Point(582, 83);
            this.txtVade.Name = "txtVade";
            this.txtVade.Size = new System.Drawing.Size(200, 20);
            this.txtVade.TabIndex = 11;
            this.txtVade.TextChanged += new System.EventHandler(this.txtKDV_TextChanged);
            // 
            // txtToplamTutar
            // 
            this.txtToplamTutar.BackColor = System.Drawing.Color.White;
            this.txtToplamTutar.Location = new System.Drawing.Point(582, 57);
            this.txtToplamTutar.Name = "txtToplamTutar";
            this.txtToplamTutar.ReadOnly = true;
            this.txtToplamTutar.Size = new System.Drawing.Size(200, 20);
            this.txtToplamTutar.TabIndex = 10;
            // 
            // txtKDV
            // 
            this.txtKDV.Location = new System.Drawing.Point(582, 31);
            this.txtKDV.Name = "txtKDV";
            this.txtKDV.Size = new System.Drawing.Size(200, 20);
            this.txtKDV.TabIndex = 9;
            this.txtKDV.TextChanged += new System.EventHandler(this.txtKDV_TextChanged);
            // 
            // txtTutar
            // 
            this.txtTutar.Location = new System.Drawing.Point(582, 5);
            this.txtTutar.Name = "txtTutar";
            this.txtTutar.Size = new System.Drawing.Size(200, 20);
            this.txtTutar.TabIndex = 8;
            this.txtTutar.TextChanged += new System.EventHandler(this.txtTutar_TextChanged);
            // 
            // txtFaturaDetayi
            // 
            this.txtFaturaDetayi.Location = new System.Drawing.Point(209, 110);
            this.txtFaturaDetayi.Name = "txtFaturaDetayi";
            this.txtFaturaDetayi.Size = new System.Drawing.Size(200, 20);
            this.txtFaturaDetayi.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(489, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Ödeme Tarihi";
            // 
            // txtFaturaNo
            // 
            this.txtFaturaNo.Location = new System.Drawing.Point(209, 84);
            this.txtFaturaNo.Name = "txtFaturaNo";
            this.txtFaturaNo.Size = new System.Drawing.Size(200, 20);
            this.txtFaturaNo.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(489, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Vade";
            // 
            // txtYakit
            // 
            this.txtYakit.Location = new System.Drawing.Point(209, 58);
            this.txtYakit.Name = "txtYakit";
            this.txtYakit.Size = new System.Drawing.Size(200, 20);
            this.txtYakit.TabIndex = 5;
            this.txtYakit.TextChanged += new System.EventHandler(this.txtYakit_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(489, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "T. Tutar";
            // 
            // dtpOdemeTarihi
            // 
            this.dtpOdemeTarihi.Location = new System.Drawing.Point(582, 110);
            this.dtpOdemeTarihi.Name = "dtpOdemeTarihi";
            this.dtpOdemeTarihi.Size = new System.Drawing.Size(200, 20);
            this.dtpOdemeTarihi.TabIndex = 12;
            // 
            // dtpTarih
            // 
            this.dtpTarih.Location = new System.Drawing.Point(209, 32);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(200, 20);
            this.dtpTarih.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(489, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "KDV";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(489, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Tutar";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(116, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Fatura Detayı";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(116, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Fatura No";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Yakıt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tarih";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Firma";
            // 
            // cmbFirmalar
            // 
            this.cmbFirmalar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFirmalar.FormattingEnabled = true;
            this.cmbFirmalar.Location = new System.Drawing.Point(209, 5);
            this.cmbFirmalar.Name = "cmbFirmalar";
            this.cmbFirmalar.Size = new System.Drawing.Size(200, 21);
            this.cmbFirmalar.TabIndex = 3;
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(896, 50);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(96, 23);
            this.btnEkle.TabIndex = 13;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.Location = new System.Drawing.Point(0, 3);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(96, 23);
            this.btnTemizle.TabIndex = 2;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // frmAracGiderleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 472);
            this.Controls.Add(this.splitContainer2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1020, 510);
            this.Name = "frmAracGiderleri";
            this.Text = "Araç Giderleri";
            this.Load += new System.EventHandler(this.frmAracGiderleri_Load);
            this.SizeChanged += new System.EventHandler(this.frmAracGiderleri_SizeChanged);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAracGiderleri)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lbArabalar;
        private System.Windows.Forms.DataGridView dgvAracGiderleri;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.TextBox txtVade;
        private System.Windows.Forms.TextBox txtToplamTutar;
        private System.Windows.Forms.TextBox txtKDV;
        private System.Windows.Forms.TextBox txtTutar;
        private System.Windows.Forms.TextBox txtFaturaDetayi;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFaturaNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtYakit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFirmalar;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.DateTimePicker dtpOdemeTarihi;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.DataGridViewTextBoxColumn clpkAracGiderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrArabaPlaka;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrAracFirma;
        private System.Windows.Forms.DataGridViewTextBoxColumn cldtTarih;
        private System.Windows.Forms.DataGridViewTextBoxColumn clflYakit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrFaturaNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrFaturaDetayi;
        private System.Windows.Forms.DataGridViewTextBoxColumn clflTutar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cltintKDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn clflToplamTutar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cltintVade;
        private System.Windows.Forms.DataGridViewTextBoxColumn cldtOdemeTarihi;
        private System.Windows.Forms.Button btnFirmaEkle;
    }
}