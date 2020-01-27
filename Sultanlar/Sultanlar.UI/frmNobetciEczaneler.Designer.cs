namespace Sultanlar.UI
{
    partial class frmNobetciEczaneler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNobetciEczaneler));
            this.label7 = new System.Windows.Forms.Label();
            this.cmbGunler = new System.Windows.Forms.ComboBox();
            this.btnEczaneGuncelle = new System.Windows.Forms.Button();
            this.lblDurum = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvEczaneler = new System.Windows.Forms.DataGridView();
            this.cltintEczaneGunID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrEczaneAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbIlceler = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEczaneler)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(189, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Hangi güne kadar güncelleme yapılsın:";
            // 
            // cmbGunler
            // 
            this.cmbGunler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGunler.FormattingEnabled = true;
            this.cmbGunler.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cmbGunler.Location = new System.Drawing.Point(205, 12);
            this.cmbGunler.Name = "cmbGunler";
            this.cmbGunler.Size = new System.Drawing.Size(52, 21);
            this.cmbGunler.TabIndex = 9;
            // 
            // btnEczaneGuncelle
            // 
            this.btnEczaneGuncelle.Location = new System.Drawing.Point(263, 11);
            this.btnEczaneGuncelle.Name = "btnEczaneGuncelle";
            this.btnEczaneGuncelle.Size = new System.Drawing.Size(120, 23);
            this.btnEczaneGuncelle.TabIndex = 8;
            this.btnEczaneGuncelle.Text = "Eczaneleri Güncelle";
            this.btnEczaneGuncelle.UseVisualStyleBackColor = true;
            this.btnEczaneGuncelle.Click += new System.EventHandler(this.btnEczaneGuncelle_Click);
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.Location = new System.Drawing.Point(56, 272);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(58, 13);
            this.lblDurum.TabIndex = 11;
            this.lblDurum.Text = "Form hazır.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Durum:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvEczaneler);
            this.groupBox1.Controls.Add(this.cmbIlceler);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(16, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 228);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Eczaneler";
            // 
            // dgvEczaneler
            // 
            this.dgvEczaneler.AllowUserToAddRows = false;
            this.dgvEczaneler.AllowUserToResizeColumns = false;
            this.dgvEczaneler.AllowUserToResizeRows = false;
            this.dgvEczaneler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEczaneler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cltintEczaneGunID,
            this.clstrEczaneAdi});
            this.dgvEczaneler.Location = new System.Drawing.Point(9, 44);
            this.dgvEczaneler.MultiSelect = false;
            this.dgvEczaneler.Name = "dgvEczaneler";
            this.dgvEczaneler.ReadOnly = true;
            this.dgvEczaneler.RowHeadersVisible = false;
            this.dgvEczaneler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEczaneler.Size = new System.Drawing.Size(348, 176);
            this.dgvEczaneler.TabIndex = 11;
            // 
            // cltintEczaneGunID
            // 
            this.cltintEczaneGunID.DataPropertyName = "tintEczaneGunID";
            this.cltintEczaneGunID.HeaderText = "Gün";
            this.cltintEczaneGunID.Name = "cltintEczaneGunID";
            this.cltintEczaneGunID.ReadOnly = true;
            this.cltintEczaneGunID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cltintEczaneGunID.Width = 50;
            // 
            // clstrEczaneAdi
            // 
            this.clstrEczaneAdi.DataPropertyName = "strEczaneAdi";
            this.clstrEczaneAdi.HeaderText = "Eczane Adı";
            this.clstrEczaneAdi.Name = "clstrEczaneAdi";
            this.clstrEczaneAdi.ReadOnly = true;
            this.clstrEczaneAdi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clstrEczaneAdi.Width = 270;
            // 
            // cmbIlceler
            // 
            this.cmbIlceler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIlceler.FormattingEnabled = true;
            this.cmbIlceler.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cmbIlceler.Location = new System.Drawing.Point(185, 19);
            this.cmbIlceler.Name = "cmbIlceler";
            this.cmbIlceler.Size = new System.Drawing.Size(172, 21);
            this.cmbIlceler.TabIndex = 9;
            this.cmbIlceler.SelectedIndexChanged += new System.EventHandler(this.cmbIlceler_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "İlçeler:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(254, 272);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(129, 13);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "İstanbul Sağlık Müdürlüğü";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // frmNobetciEczaneler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 292);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblDurum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbGunler);
            this.Controls.Add(this.btnEczaneGuncelle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(414, 330);
            this.Name = "frmNobetciEczaneler";
            this.Text = "Nöbetçi Eczaneler";
            this.Load += new System.EventHandler(this.frmNobetciEczaneler_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEczaneler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbGunler;
        private System.Windows.Forms.Button btnEczaneGuncelle;
        private System.Windows.Forms.Label lblDurum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbIlceler;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvEczaneler;
        private System.Windows.Forms.DataGridViewTextBoxColumn cltintEczaneGunID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrEczaneAdi;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}