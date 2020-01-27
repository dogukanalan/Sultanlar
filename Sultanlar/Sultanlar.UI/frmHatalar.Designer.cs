namespace Sultanlar.UI
{
    partial class frmHatalar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHatalar));
            this.dgvHatalar = new System.Windows.Forms.DataGridView();
            this.clpkHataID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrHataKodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrHataKaynak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrHataYeri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrHataAciklama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cldtHataZamani = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvErisimler = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPDA = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.clpkID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cldtBaslangic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cldtBitis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrYer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrLog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHatalar)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErisimler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPDA)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvHatalar
            // 
            this.dgvHatalar.AllowUserToAddRows = false;
            this.dgvHatalar.AllowUserToDeleteRows = false;
            this.dgvHatalar.AllowUserToResizeColumns = false;
            this.dgvHatalar.AllowUserToResizeRows = false;
            this.dgvHatalar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHatalar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clpkHataID,
            this.clstrHataKodu,
            this.clstrHataKaynak,
            this.clstrHataYeri,
            this.clstrHataAciklama,
            this.cldtHataZamani});
            this.dgvHatalar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHatalar.Location = new System.Drawing.Point(3, 16);
            this.dgvHatalar.MultiSelect = false;
            this.dgvHatalar.Name = "dgvHatalar";
            this.dgvHatalar.ReadOnly = true;
            this.dgvHatalar.RowHeadersVisible = false;
            this.dgvHatalar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvHatalar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHatalar.Size = new System.Drawing.Size(878, 130);
            this.dgvHatalar.TabIndex = 14;
            this.dgvHatalar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHatalar_CellClick);
            // 
            // clpkHataID
            // 
            this.clpkHataID.DataPropertyName = "pkHataID";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            this.clpkHataID.DefaultCellStyle = dataGridViewCellStyle1;
            this.clpkHataID.HeaderText = "ID";
            this.clpkHataID.Name = "clpkHataID";
            this.clpkHataID.ReadOnly = true;
            this.clpkHataID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clpkHataID.Width = 50;
            // 
            // clstrHataKodu
            // 
            this.clstrHataKodu.DataPropertyName = "strHataKodu";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            this.clstrHataKodu.DefaultCellStyle = dataGridViewCellStyle2;
            this.clstrHataKodu.HeaderText = "Kod";
            this.clstrHataKodu.Name = "clstrHataKodu";
            this.clstrHataKodu.ReadOnly = true;
            this.clstrHataKodu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clstrHataKodu.Width = 130;
            // 
            // clstrHataKaynak
            // 
            this.clstrHataKaynak.DataPropertyName = "strHataKaynak";
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            this.clstrHataKaynak.DefaultCellStyle = dataGridViewCellStyle3;
            this.clstrHataKaynak.HeaderText = "Kaynak";
            this.clstrHataKaynak.Name = "clstrHataKaynak";
            this.clstrHataKaynak.ReadOnly = true;
            this.clstrHataKaynak.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clstrHataKaynak.Width = 180;
            // 
            // clstrHataYeri
            // 
            this.clstrHataYeri.DataPropertyName = "strHataYeri";
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            this.clstrHataYeri.DefaultCellStyle = dataGridViewCellStyle4;
            this.clstrHataYeri.HeaderText = "Yer";
            this.clstrHataYeri.Name = "clstrHataYeri";
            this.clstrHataYeri.ReadOnly = true;
            this.clstrHataYeri.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clstrHataYeri.Width = 180;
            // 
            // clstrHataAciklama
            // 
            this.clstrHataAciklama.DataPropertyName = "strHataAciklama";
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            this.clstrHataAciklama.DefaultCellStyle = dataGridViewCellStyle5;
            this.clstrHataAciklama.HeaderText = "Açıklama";
            this.clstrHataAciklama.Name = "clstrHataAciklama";
            this.clstrHataAciklama.ReadOnly = true;
            this.clstrHataAciklama.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clstrHataAciklama.Width = 220;
            // 
            // cldtHataZamani
            // 
            this.cldtHataZamani.DataPropertyName = "dtHataZamani";
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            this.cldtHataZamani.DefaultCellStyle = dataGridViewCellStyle6;
            this.cldtHataZamani.HeaderText = "Tarih";
            this.cldtHataZamani.Name = "cldtHataZamani";
            this.cldtHataZamani.ReadOnly = true;
            this.cldtHataZamani.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cldtHataZamani.Width = 98;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvErisimler);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 332);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(884, 150);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Program Erişimleri";
            // 
            // dgvErisimler
            // 
            this.dgvErisimler.AllowUserToAddRows = false;
            this.dgvErisimler.AllowUserToDeleteRows = false;
            this.dgvErisimler.AllowUserToResizeColumns = false;
            this.dgvErisimler.AllowUserToResizeRows = false;
            this.dgvErisimler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErisimler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgvErisimler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvErisimler.Location = new System.Drawing.Point(3, 16);
            this.dgvErisimler.MultiSelect = false;
            this.dgvErisimler.Name = "dgvErisimler";
            this.dgvErisimler.ReadOnly = true;
            this.dgvErisimler.RowHeadersVisible = false;
            this.dgvErisimler.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvErisimler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvErisimler.Size = new System.Drawing.Size(878, 131);
            this.dgvErisimler.TabIndex = 14;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "pkID";
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "strTerminal";
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn2.HeaderText = "Terminal";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 208;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "dtGirisTarih";
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle9.Format = "G";
            dataGridViewCellStyle9.NullValue = null;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn3.HeaderText = "Giriş Tarihi";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 300;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "dtCikisTarih";
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle10.Format = "G";
            dataGridViewCellStyle10.NullValue = null;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn4.HeaderText = "Çıkış Tarihi";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 300;
            // 
            // dgvPDA
            // 
            this.dgvPDA.AllowUserToAddRows = false;
            this.dgvPDA.AllowUserToDeleteRows = false;
            this.dgvPDA.AllowUserToResizeColumns = false;
            this.dgvPDA.AllowUserToResizeRows = false;
            this.dgvPDA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPDA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clpkID,
            this.cldtBaslangic,
            this.cldtBitis,
            this.clstrYer,
            this.clstrLog});
            this.dgvPDA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPDA.Location = new System.Drawing.Point(3, 16);
            this.dgvPDA.MultiSelect = false;
            this.dgvPDA.Name = "dgvPDA";
            this.dgvPDA.ReadOnly = true;
            this.dgvPDA.RowHeadersVisible = false;
            this.dgvPDA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvPDA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPDA.Size = new System.Drawing.Size(878, 164);
            this.dgvPDA.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvHatalar);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(884, 149);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hatalar";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvPDA);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 149);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(884, 183);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tablo Güncellemeleri";
            // 
            // clpkID
            // 
            this.clpkID.DataPropertyName = "pkID";
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            this.clpkID.DefaultCellStyle = dataGridViewCellStyle11;
            this.clpkID.HeaderText = "ID";
            this.clpkID.Name = "clpkID";
            this.clpkID.ReadOnly = true;
            this.clpkID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clpkID.Width = 50;
            // 
            // cldtBaslangic
            // 
            this.cldtBaslangic.DataPropertyName = "dtBaslangic";
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle12.Format = "G";
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            this.cldtBaslangic.DefaultCellStyle = dataGridViewCellStyle12;
            this.cldtBaslangic.HeaderText = "Başlangıç";
            this.cldtBaslangic.Name = "cldtBaslangic";
            this.cldtBaslangic.ReadOnly = true;
            this.cldtBaslangic.Width = 150;
            // 
            // cldtBitis
            // 
            this.cldtBitis.DataPropertyName = "dtBitis";
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle13.Format = "G";
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            this.cldtBitis.DefaultCellStyle = dataGridViewCellStyle13;
            this.cldtBitis.HeaderText = "Bitiş";
            this.cldtBitis.Name = "cldtBitis";
            this.cldtBitis.ReadOnly = true;
            this.cldtBitis.Width = 150;
            // 
            // clstrYer
            // 
            this.clstrYer.DataPropertyName = "strYer";
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            this.clstrYer.DefaultCellStyle = dataGridViewCellStyle14;
            this.clstrYer.HeaderText = "Açıklama";
            this.clstrYer.Name = "clstrYer";
            this.clstrYer.ReadOnly = true;
            this.clstrYer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clstrYer.Width = 208;
            // 
            // clstrLog
            // 
            this.clstrLog.DataPropertyName = "strLog";
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            this.clstrLog.DefaultCellStyle = dataGridViewCellStyle15;
            this.clstrLog.HeaderText = "Log";
            this.clstrLog.Name = "clstrLog";
            this.clstrLog.ReadOnly = true;
            this.clstrLog.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clstrLog.Width = 300;
            // 
            // frmHatalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 482);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "frmHatalar";
            this.Text = "Loglar";
            this.Load += new System.EventHandler(this.frmHatalar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHatalar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvErisimler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPDA)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHatalar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvPDA;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvErisimler;
        private System.Windows.Forms.DataGridViewTextBoxColumn clpkHataID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrHataKodu;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrHataKaynak;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrHataYeri;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrHataAciklama;
        private System.Windows.Forms.DataGridViewTextBoxColumn cldtHataZamani;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn clpkID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cldtBaslangic;
        private System.Windows.Forms.DataGridViewTextBoxColumn cldtBitis;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrYer;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrLog;
    }
}