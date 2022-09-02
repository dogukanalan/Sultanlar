namespace Sultanlar.UI
{
    partial class frmINTERNETiadegirmeliste
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmINTERNETiadegirmeliste));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnKapat = new System.Windows.Forms.Button();
            this.btnBarkod = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBarkodBulunamadi = new System.Windows.Forms.Label();
            this.lblBarkodBulundu = new System.Windows.Forms.Label();
            this.cbAramadanAktar = new System.Windows.Forms.CheckBox();
            this.lblAramadanAktar = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.clpkIadeDetayID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clintIadeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clintUrunID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrUrunAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clintMiktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnFiyat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clBARKOD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnToplam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSil = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clstrDepoUY = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clstrDepoKod = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clstrPartiNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 35;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clpkIadeDetayID,
            this.clintIadeID,
            this.clintUrunID,
            this.clstrUrunAdi,
            this.clintMiktar,
            this.clmnFiyat,
            this.clBARKOD,
            this.clmnToplam,
            this.clSil,
            this.clstrDepoUY,
            this.clstrDepoKod,
            this.clstrPartiNo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(2, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(784, 290);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(679, 329);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(106, 23);
            this.btnGuncelle.TabIndex = 9;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnKapat
            // 
            this.btnKapat.Location = new System.Drawing.Point(3, 329);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(106, 23);
            this.btnKapat.TabIndex = 9;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = true;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // btnBarkod
            // 
            this.btnBarkod.Location = new System.Drawing.Point(286, 6);
            this.btnBarkod.Name = "btnBarkod";
            this.btnBarkod.Size = new System.Drawing.Size(91, 23);
            this.btnBarkod.TabIndex = 10;
            this.btnBarkod.Text = "Ara ve Ekle";
            this.btnBarkod.UseVisualStyleBackColor = true;
            this.btnBarkod.Click += new System.EventHandler(this.btnBarkod_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Barkod İle Ürün Ekleme:";
            // 
            // lblBarkodBulunamadi
            // 
            this.lblBarkodBulunamadi.AutoSize = true;
            this.lblBarkodBulunamadi.ForeColor = System.Drawing.Color.Red;
            this.lblBarkodBulunamadi.Location = new System.Drawing.Point(423, 9);
            this.lblBarkodBulunamadi.Name = "lblBarkodBulunamadi";
            this.lblBarkodBulunamadi.Size = new System.Drawing.Size(101, 13);
            this.lblBarkodBulunamadi.TabIndex = 15;
            this.lblBarkodBulunamadi.Text = "Barkod bulunamadı.";
            this.lblBarkodBulunamadi.Visible = false;
            // 
            // lblBarkodBulundu
            // 
            this.lblBarkodBulundu.AutoSize = true;
            this.lblBarkodBulundu.ForeColor = System.Drawing.Color.Green;
            this.lblBarkodBulundu.Location = new System.Drawing.Point(423, 9);
            this.lblBarkodBulundu.Name = "lblBarkodBulundu";
            this.lblBarkodBulundu.Size = new System.Drawing.Size(85, 13);
            this.lblBarkodBulundu.TabIndex = 15;
            this.lblBarkodBulundu.Text = "Barkod bulundu.";
            this.lblBarkodBulundu.Visible = false;
            // 
            // cbAramadanAktar
            // 
            this.cbAramadanAktar.AutoSize = true;
            this.cbAramadanAktar.Checked = true;
            this.cbAramadanAktar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAramadanAktar.Location = new System.Drawing.Point(383, 11);
            this.cbAramadanAktar.Name = "cbAramadanAktar";
            this.cbAramadanAktar.Size = new System.Drawing.Size(15, 14);
            this.cbAramadanAktar.TabIndex = 18;
            this.cbAramadanAktar.UseVisualStyleBackColor = true;
            this.cbAramadanAktar.MouseLeave += new System.EventHandler(this.cbAramadanAktar_MouseLeave);
            this.cbAramadanAktar.MouseHover += new System.EventHandler(this.cbAramadanAktar_MouseHover);
            // 
            // lblAramadanAktar
            // 
            this.lblAramadanAktar.ForeColor = System.Drawing.Color.Red;
            this.lblAramadanAktar.Location = new System.Drawing.Point(404, 3);
            this.lblAramadanAktar.Name = "lblAramadanAktar";
            this.lblAramadanAktar.Size = new System.Drawing.Size(171, 28);
            this.lblAramadanAktar.TabIndex = 19;
            this.lblAramadanAktar.Text = "İşaretli ise, arama yapmadan önce güncelleme yapar.";
            this.lblAramadanAktar.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblAramadanAktar);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.cbAramadanAktar);
            this.panel1.Controls.Add(this.btnGuncelle);
            this.panel1.Controls.Add(this.lblBarkodBulundu);
            this.panel1.Controls.Add(this.btnKapat);
            this.panel1.Controls.Add(this.lblBarkodBulunamadi);
            this.panel1.Controls.Add(this.btnBarkod);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(790, 358);
            this.panel1.TabIndex = 20;
            // 
            // clpkIadeDetayID
            // 
            this.clpkIadeDetayID.DataPropertyName = "pkIadeDetayID";
            this.clpkIadeDetayID.HeaderText = "IadeDetayID";
            this.clpkIadeDetayID.Name = "clpkIadeDetayID";
            this.clpkIadeDetayID.ReadOnly = true;
            this.clpkIadeDetayID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clpkIadeDetayID.Visible = false;
            // 
            // clintIadeID
            // 
            this.clintIadeID.DataPropertyName = "intIadeID";
            this.clintIadeID.HeaderText = "IadeID";
            this.clintIadeID.Name = "clintIadeID";
            this.clintIadeID.ReadOnly = true;
            this.clintIadeID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clintIadeID.Visible = false;
            // 
            // clintUrunID
            // 
            this.clintUrunID.DataPropertyName = "intUrunID";
            this.clintUrunID.HeaderText = "UrunID";
            this.clintUrunID.Name = "clintUrunID";
            this.clintUrunID.ReadOnly = true;
            this.clintUrunID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clintUrunID.Visible = false;
            // 
            // clstrUrunAdi
            // 
            this.clstrUrunAdi.DataPropertyName = "strUrunAdi";
            this.clstrUrunAdi.HeaderText = "Ürün";
            this.clstrUrunAdi.Name = "clstrUrunAdi";
            this.clstrUrunAdi.ReadOnly = true;
            this.clstrUrunAdi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clstrUrunAdi.Width = 320;
            // 
            // clintMiktar
            // 
            this.clintMiktar.DataPropertyName = "intMiktar";
            this.clintMiktar.HeaderText = "Miktar";
            this.clintMiktar.Name = "clintMiktar";
            this.clintMiktar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clintMiktar.Width = 54;
            // 
            // clmnFiyat
            // 
            this.clmnFiyat.DataPropertyName = "mnFiyat";
            this.clmnFiyat.HeaderText = "Fiyat";
            this.clmnFiyat.Name = "clmnFiyat";
            this.clmnFiyat.ReadOnly = true;
            this.clmnFiyat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmnFiyat.Visible = false;
            // 
            // clBARKOD
            // 
            this.clBARKOD.DataPropertyName = "BARKOD";
            this.clBARKOD.HeaderText = "Barkod";
            this.clBARKOD.Name = "clBARKOD";
            this.clBARKOD.ReadOnly = true;
            this.clBARKOD.Visible = false;
            // 
            // clmnToplam
            // 
            this.clmnToplam.DataPropertyName = "mnToplam";
            this.clmnToplam.HeaderText = "Toplam";
            this.clmnToplam.Name = "clmnToplam";
            this.clmnToplam.ReadOnly = true;
            this.clmnToplam.Visible = false;
            // 
            // clSil
            // 
            this.clSil.HeaderText = "Sil";
            this.clSil.Name = "clSil";
            this.clSil.ReadOnly = true;
            this.clSil.Width = 50;
            // 
            // clstrDepoUY
            // 
            this.clstrDepoUY.DataPropertyName = "strDepoUY";
            this.clstrDepoUY.HeaderText = "ÜY";
            this.clstrDepoUY.Items.AddRange(new object[] {
            "TB10",
            "TB13",
            "TB20",
            "TB60",
            "TB80"});
            this.clstrDepoUY.Name = "clstrDepoUY";
            this.clstrDepoUY.Width = 60;
            // 
            // clstrDepoKod
            // 
            this.clstrDepoKod.DataPropertyName = "strDepoKod";
            this.clstrDepoKod.HeaderText = "Depo";
            this.clstrDepoKod.Items.AddRange(new object[] {
            "SP53-SP53 Depo Yeri",
            "TB10-Tibet Hammadde",
            "TB11-Tibet Ambalaj",
            "TB13-Teslim Tesellüm",
            "TB14-Tibet Üretim",
            "TB15-İhracat Deposu",
            "TB16-Tibet Silolar",
            "TB17-Tibet Kırtasiye",
            "TB18-Tibet Sevkiyat",
            "TB19-Tibet Sevk. Adet",
            "TB1A-İade Depo",
            "TB1B-İmha Depo",
            "TB1C-Karantina Depo",
            "TB1D-Promosyon Depo",
            "TB1E-Re-Work Depo",
            "TB20-Tib.Transfer Dep",
            "TB21-Teknik Depo Y.",
            "TB22-Ü.İade Tesellüm",
            "TBEF-Envanter Farkı",
            "TBS1-Sultanlar Kat 1",
            "TBS2-Sultanlar Kat 2",
            "TBS3-Sultanlar Kat 3",
            "TS1A-Sultanlar İade D",
            "TS1B-Sultanlar İmha D",
            "TS5A-Sult.Kurt İade D",
            "TS5B-Sult.Kurt İmha D",
            "TBET-E-Ticaret",
            "TB10-YEG Hammadde",
            "TB11-YEG Ambalaj",
            "TB12-Tibet YEG deposu",
            "TB14-YEG Üretim Depo",
            "TB18-YEG Sevkiyat",
            "TB19-YEG Sevk. Adet",
            "TB20-Ü.İade Tesellüm",
            "TS2B-Sultanlar İmha D",
            "TS2A-Sultanlar İade D",
            "TB30-Ü.İade Tesellüm",
            "TB2E-Re-Work Depo",
            "TB2D-Promosyon Depo",
            "TB2C-Karantina Depo",
            "TB2B-İmha Depo",
            "TB2A-İade Depo",
            "TB29-Teknik Depo Y.",
            "TB28-Dış Depolar",
            "TB27-Hyt.Transfer Dep",
            "TB26-Teslim Tesellüm",
            "TB25-İhracat Deposu",
            "TB24-Hayat Üretim",
            "TB23-Hayat Sevk. ADET",
            "TB22-Hayat Sevkiyat",
            "TB21-Hayat Ambalaj",
            "TB20-Hayat Hammadde",
            "TB81-Sultanlar Kat 1",
            "TB82-Sultanlar Kat 2",
            "TB83-Sultanlar Kat 3",
            "TB85-Transfer depo",
            "TB8A-İade depo",
            "TB8B-İmha Depo",
            "TB8E-Sultanlar Rework"});
            this.clstrDepoKod.Name = "clstrDepoKod";
            this.clstrDepoKod.Width = 170;
            // 
            // clstrPartiNo
            // 
            this.clstrPartiNo.DataPropertyName = "strPartiNo";
            this.clstrPartiNo.HeaderText = "Parti No";
            this.clstrPartiNo.Name = "clstrPartiNo";
            this.clstrPartiNo.Width = 70;
            // 
            // frmINTERNETiadegirmeliste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(790, 358);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmINTERNETiadegirmeliste";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liste";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmINTERNETiadegirmeliste_FormClosing);
            this.Load += new System.EventHandler(this.frmINTERNETiadegirmeliste_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.Button btnBarkod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBarkodBulunamadi;
        private System.Windows.Forms.Label lblBarkodBulundu;
        private System.Windows.Forms.CheckBox cbAramadanAktar;
        private System.Windows.Forms.Label lblAramadanAktar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clpkIadeDetayID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clintIadeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clintUrunID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrUrunAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn clintMiktar;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnFiyat;
        private System.Windows.Forms.DataGridViewTextBoxColumn clBARKOD;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnToplam;
        private System.Windows.Forms.DataGridViewButtonColumn clSil;
        private System.Windows.Forms.DataGridViewComboBoxColumn clstrDepoUY;
        private System.Windows.Forms.DataGridViewComboBoxColumn clstrDepoKod;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrPartiNo;
    }
}