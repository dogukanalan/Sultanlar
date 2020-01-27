namespace Sultanlar.UI
{
    partial class frmArananGorevler
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArananGorevler));
            this.dgvTecrubeler = new System.Windows.Forms.DataGridView();
            this.clpkArananGorevID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrGorev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrOgrenimDurumu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrAskerlikDurumu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrMedeniDurum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrIl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrIlce = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrTecrube = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cldtSonTarih = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clblPasif = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clSil = new System.Windows.Forms.DataGridViewButtonColumn();
            this.gbEkle = new System.Windows.Forms.GroupBox();
            this.dtpSonTarih = new System.Windows.Forms.DateTimePicker();
            this.btnEkle = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTecrube = new System.Windows.Forms.TextBox();
            this.cmbIlceler = new System.Windows.Forms.ComboBox();
            this.cmbIller = new System.Windows.Forms.ComboBox();
            this.cmbMedeniDurumlar = new System.Windows.Forms.ComboBox();
            this.cmbAskerlikDurumlari = new System.Windows.Forms.ComboBox();
            this.cmbOgrenimDurumlari = new System.Windows.Forms.ComboBox();
            this.cmbGorevler = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTecrubeler)).BeginInit();
            this.gbEkle.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTecrubeler
            // 
            this.dgvTecrubeler.AllowUserToAddRows = false;
            this.dgvTecrubeler.AllowUserToDeleteRows = false;
            this.dgvTecrubeler.AllowUserToResizeColumns = false;
            this.dgvTecrubeler.AllowUserToResizeRows = false;
            this.dgvTecrubeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTecrubeler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clpkArananGorevID,
            this.clstrGorev,
            this.clstrOgrenimDurumu,
            this.clstrAskerlikDurumu,
            this.clstrMedeniDurum,
            this.clstrIl,
            this.clstrIlce,
            this.clstrTecrube,
            this.cldtSonTarih,
            this.clblPasif,
            this.clSil});
            this.dgvTecrubeler.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvTecrubeler.Location = new System.Drawing.Point(0, 170);
            this.dgvTecrubeler.MultiSelect = false;
            this.dgvTecrubeler.Name = "dgvTecrubeler";
            this.dgvTecrubeler.ReadOnly = true;
            this.dgvTecrubeler.RowHeadersVisible = false;
            this.dgvTecrubeler.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvTecrubeler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTecrubeler.Size = new System.Drawing.Size(884, 242);
            this.dgvTecrubeler.TabIndex = 0;
            this.dgvTecrubeler.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTecrubeler_CellClick);
            // 
            // clpkArananGorevID
            // 
            this.clpkArananGorevID.DataPropertyName = "pkArananGorevID";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            this.clpkArananGorevID.DefaultCellStyle = dataGridViewCellStyle1;
            this.clpkArananGorevID.HeaderText = "ID";
            this.clpkArananGorevID.Name = "clpkArananGorevID";
            this.clpkArananGorevID.ReadOnly = true;
            this.clpkArananGorevID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clpkArananGorevID.Width = 30;
            // 
            // clstrGorev
            // 
            this.clstrGorev.DataPropertyName = "strGorev";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            this.clstrGorev.DefaultCellStyle = dataGridViewCellStyle2;
            this.clstrGorev.HeaderText = "Görev";
            this.clstrGorev.Name = "clstrGorev";
            this.clstrGorev.ReadOnly = true;
            this.clstrGorev.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clstrGorev.Width = 90;
            // 
            // clstrOgrenimDurumu
            // 
            this.clstrOgrenimDurumu.DataPropertyName = "strOgrenimDurumu";
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            this.clstrOgrenimDurumu.DefaultCellStyle = dataGridViewCellStyle3;
            this.clstrOgrenimDurumu.HeaderText = "Öğrenim Durumu";
            this.clstrOgrenimDurumu.Name = "clstrOgrenimDurumu";
            this.clstrOgrenimDurumu.ReadOnly = true;
            this.clstrOgrenimDurumu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clstrOgrenimDurumu.Width = 110;
            // 
            // clstrAskerlikDurumu
            // 
            this.clstrAskerlikDurumu.DataPropertyName = "strAskerlikDurumu";
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            this.clstrAskerlikDurumu.DefaultCellStyle = dataGridViewCellStyle4;
            this.clstrAskerlikDurumu.HeaderText = "Askerlik Durumu";
            this.clstrAskerlikDurumu.Name = "clstrAskerlikDurumu";
            this.clstrAskerlikDurumu.ReadOnly = true;
            this.clstrAskerlikDurumu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clstrMedeniDurum
            // 
            this.clstrMedeniDurum.DataPropertyName = "strMedeniDurum";
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            this.clstrMedeniDurum.DefaultCellStyle = dataGridViewCellStyle5;
            this.clstrMedeniDurum.HeaderText = "Medeni Durum";
            this.clstrMedeniDurum.Name = "clstrMedeniDurum";
            this.clstrMedeniDurum.ReadOnly = true;
            this.clstrMedeniDurum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clstrMedeniDurum.Width = 90;
            // 
            // clstrIl
            // 
            this.clstrIl.DataPropertyName = "strIl";
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            this.clstrIl.DefaultCellStyle = dataGridViewCellStyle6;
            this.clstrIl.HeaderText = "İl";
            this.clstrIl.Name = "clstrIl";
            this.clstrIl.ReadOnly = true;
            this.clstrIl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clstrIl.Width = 90;
            // 
            // clstrIlce
            // 
            this.clstrIlce.DataPropertyName = "strIlce";
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            this.clstrIlce.DefaultCellStyle = dataGridViewCellStyle7;
            this.clstrIlce.HeaderText = "İlçe";
            this.clstrIlce.Name = "clstrIlce";
            this.clstrIlce.ReadOnly = true;
            this.clstrIlce.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clstrIlce.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clstrIlce.Width = 90;
            // 
            // clstrTecrube
            // 
            this.clstrTecrube.DataPropertyName = "strTecrube";
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            this.clstrTecrube.DefaultCellStyle = dataGridViewCellStyle8;
            this.clstrTecrube.HeaderText = "Tecrübe";
            this.clstrTecrube.Name = "clstrTecrube";
            this.clstrTecrube.ReadOnly = true;
            this.clstrTecrube.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clstrTecrube.Width = 90;
            // 
            // cldtSonTarih
            // 
            this.cldtSonTarih.DataPropertyName = "dtSonTarih";
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            this.cldtSonTarih.DefaultCellStyle = dataGridViewCellStyle9;
            this.cldtSonTarih.HeaderText = "Geçerlilik";
            this.cldtSonTarih.Name = "cldtSonTarih";
            this.cldtSonTarih.ReadOnly = true;
            this.cldtSonTarih.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cldtSonTarih.Width = 70;
            // 
            // clblPasif
            // 
            this.clblPasif.DataPropertyName = "blPasif";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle10.NullValue = false;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            this.clblPasif.DefaultCellStyle = dataGridViewCellStyle10;
            this.clblPasif.HeaderText = "Silinmiş";
            this.clblPasif.Name = "clblPasif";
            this.clblPasif.ReadOnly = true;
            this.clblPasif.TrueValue = "";
            this.clblPasif.Width = 50;
            // 
            // clSil
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            this.clSil.DefaultCellStyle = dataGridViewCellStyle11;
            this.clSil.HeaderText = "Sil";
            this.clSil.Name = "clSil";
            this.clSil.ReadOnly = true;
            this.clSil.Text = "Sil";
            this.clSil.Width = 50;
            // 
            // gbEkle
            // 
            this.gbEkle.Controls.Add(this.dtpSonTarih);
            this.gbEkle.Controls.Add(this.btnEkle);
            this.gbEkle.Controls.Add(this.label4);
            this.gbEkle.Controls.Add(this.label3);
            this.gbEkle.Controls.Add(this.label2);
            this.gbEkle.Controls.Add(this.label8);
            this.gbEkle.Controls.Add(this.label7);
            this.gbEkle.Controls.Add(this.label6);
            this.gbEkle.Controls.Add(this.label5);
            this.gbEkle.Controls.Add(this.label9);
            this.gbEkle.Controls.Add(this.label1);
            this.gbEkle.Controls.Add(this.txtTecrube);
            this.gbEkle.Controls.Add(this.cmbIlceler);
            this.gbEkle.Controls.Add(this.cmbIller);
            this.gbEkle.Controls.Add(this.cmbMedeniDurumlar);
            this.gbEkle.Controls.Add(this.cmbAskerlikDurumlari);
            this.gbEkle.Controls.Add(this.cmbOgrenimDurumlari);
            this.gbEkle.Controls.Add(this.cmbGorevler);
            this.gbEkle.Location = new System.Drawing.Point(12, 12);
            this.gbEkle.Name = "gbEkle";
            this.gbEkle.Size = new System.Drawing.Size(811, 130);
            this.gbEkle.TabIndex = 0;
            this.gbEkle.TabStop = false;
            this.gbEkle.Text = "İş İsteği Yap";
            // 
            // dtpSonTarih
            // 
            this.dtpSonTarih.Location = new System.Drawing.Point(545, 100);
            this.dtpSonTarih.Name = "dtpSonTarih";
            this.dtpSonTarih.Size = new System.Drawing.Size(180, 20);
            this.dtpSonTarih.TabIndex = 8;
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(731, 98);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 23);
            this.btnEkle.TabIndex = 9;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Medeni Durum:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Askerlik Durumu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Öğrenim Durumu:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(420, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Son Geçerlilik Tarihi:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(420, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Tecrübe:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(420, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Adres İlçesi:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(420, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Adres İli:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(131, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Görev:";
            // 
            // txtTecrube
            // 
            this.txtTecrube.Location = new System.Drawing.Point(545, 73);
            this.txtTecrube.Name = "txtTecrube";
            this.txtTecrube.Size = new System.Drawing.Size(261, 20);
            this.txtTecrube.TabIndex = 7;
            // 
            // cmbIlceler
            // 
            this.cmbIlceler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIlceler.FormattingEnabled = true;
            this.cmbIlceler.Location = new System.Drawing.Point(545, 46);
            this.cmbIlceler.Name = "cmbIlceler";
            this.cmbIlceler.Size = new System.Drawing.Size(260, 21);
            this.cmbIlceler.TabIndex = 6;
            // 
            // cmbIller
            // 
            this.cmbIller.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIller.FormattingEnabled = true;
            this.cmbIller.Location = new System.Drawing.Point(545, 19);
            this.cmbIller.Name = "cmbIller";
            this.cmbIller.Size = new System.Drawing.Size(260, 21);
            this.cmbIller.TabIndex = 5;
            this.cmbIller.SelectedIndexChanged += new System.EventHandler(this.cmbIller_SelectedIndexChanged);
            // 
            // cmbMedeniDurumlar
            // 
            this.cmbMedeniDurumlar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedeniDurumlar.FormattingEnabled = true;
            this.cmbMedeniDurumlar.Location = new System.Drawing.Point(145, 100);
            this.cmbMedeniDurumlar.Name = "cmbMedeniDurumlar";
            this.cmbMedeniDurumlar.Size = new System.Drawing.Size(260, 21);
            this.cmbMedeniDurumlar.TabIndex = 4;
            // 
            // cmbAskerlikDurumlari
            // 
            this.cmbAskerlikDurumlari.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAskerlikDurumlari.FormattingEnabled = true;
            this.cmbAskerlikDurumlari.Location = new System.Drawing.Point(145, 73);
            this.cmbAskerlikDurumlari.Name = "cmbAskerlikDurumlari";
            this.cmbAskerlikDurumlari.Size = new System.Drawing.Size(260, 21);
            this.cmbAskerlikDurumlari.TabIndex = 3;
            // 
            // cmbOgrenimDurumlari
            // 
            this.cmbOgrenimDurumlari.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOgrenimDurumlari.FormattingEnabled = true;
            this.cmbOgrenimDurumlari.Location = new System.Drawing.Point(145, 46);
            this.cmbOgrenimDurumlari.Name = "cmbOgrenimDurumlari";
            this.cmbOgrenimDurumlari.Size = new System.Drawing.Size(260, 21);
            this.cmbOgrenimDurumlari.TabIndex = 2;
            // 
            // cmbGorevler
            // 
            this.cmbGorevler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGorevler.FormattingEnabled = true;
            this.cmbGorevler.Location = new System.Drawing.Point(145, 19);
            this.cmbGorevler.Name = "cmbGorevler";
            this.cmbGorevler.Size = new System.Drawing.Size(260, 21);
            this.cmbGorevler.TabIndex = 1;
            // 
            // frmArananGorevler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 412);
            this.Controls.Add(this.gbEkle);
            this.Controls.Add(this.dgvTecrubeler);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(850, 450);
            this.Name = "frmArananGorevler";
            this.Text = "Eleman Talepleri";
            this.Load += new System.EventHandler(this.frmArananGorevler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTecrubeler)).EndInit();
            this.gbEkle.ResumeLayout(false);
            this.gbEkle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTecrubeler;
        private System.Windows.Forms.GroupBox gbEkle;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTecrube;
        private System.Windows.Forms.ComboBox cmbIlceler;
        private System.Windows.Forms.ComboBox cmbIller;
        private System.Windows.Forms.ComboBox cmbMedeniDurumlar;
        private System.Windows.Forms.ComboBox cmbAskerlikDurumlari;
        private System.Windows.Forms.ComboBox cmbOgrenimDurumlari;
        private System.Windows.Forms.ComboBox cmbGorevler;
        private System.Windows.Forms.DateTimePicker dtpSonTarih;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn clpkArananGorevID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrGorev;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrOgrenimDurumu;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrAskerlikDurumu;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrMedeniDurum;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrIl;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrIlce;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrTecrube;
        private System.Windows.Forms.DataGridViewTextBoxColumn cldtSonTarih;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clblPasif;
        private System.Windows.Forms.DataGridViewButtonColumn clSil;

    }
}