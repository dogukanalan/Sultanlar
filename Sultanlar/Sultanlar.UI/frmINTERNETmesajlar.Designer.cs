namespace Sultanlar.UI
{
    partial class frmINTERNETmesajlar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmINTERNETmesajlar));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clpkMesajID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clintMusteriID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrMusteri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cltintDepartmanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrDepartman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrKonu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrIcerik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cldtGondermeZamani = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cldtOkunmaZamani = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clblOkundu = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clblGonderenSil = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clblOkuyanSil = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clCevapla = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cmbDepartmanlar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKonu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMesaj = new System.Windows.Forms.TextBox();
            this.lblZaman = new System.Windows.Forms.Label();
            this.btnSil = new System.Windows.Forms.Button();
            this.rbGelenKutusu = new System.Windows.Forms.RadioButton();
            this.rbGidenKutusu = new System.Windows.Forms.RadioButton();
            this.btnMesajYaz = new System.Windows.Forms.Button();
            this.btnYenile = new System.Windows.Forms.Button();
            this.lblMesajSayisi = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clpkMesajID,
            this.clintMusteriID,
            this.clstrMusteri,
            this.cltintDepartmanID,
            this.clstrDepartman,
            this.clstrKonu,
            this.clstrIcerik,
            this.cldtGondermeZamani,
            this.cldtOkunmaZamani,
            this.clblOkundu,
            this.clblGonderenSil,
            this.clblOkuyanSil,
            this.clCevapla});
            this.dataGridView1.Location = new System.Drawing.Point(12, 48);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(711, 214);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DataSourceChanged += new System.EventHandler(this.dataGridView1_DataSourceChanged);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // clpkMesajID
            // 
            this.clpkMesajID.DataPropertyName = "pkMesajID";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clpkMesajID.DefaultCellStyle = dataGridViewCellStyle1;
            this.clpkMesajID.HeaderText = "Mesaj No";
            this.clpkMesajID.Name = "clpkMesajID";
            this.clpkMesajID.ReadOnly = true;
            this.clpkMesajID.Width = 60;
            // 
            // clintMusteriID
            // 
            this.clintMusteriID.DataPropertyName = "intMusteriID";
            this.clintMusteriID.HeaderText = "Üye No";
            this.clintMusteriID.Name = "clintMusteriID";
            this.clintMusteriID.ReadOnly = true;
            this.clintMusteriID.Visible = false;
            this.clintMusteriID.Width = 68;
            // 
            // clstrMusteri
            // 
            this.clstrMusteri.DataPropertyName = "strMusteri";
            this.clstrMusteri.HeaderText = "Üye";
            this.clstrMusteri.Name = "clstrMusteri";
            this.clstrMusteri.ReadOnly = true;
            this.clstrMusteri.Width = 220;
            // 
            // cltintDepartmanID
            // 
            this.cltintDepartmanID.DataPropertyName = "tintDepartmanID";
            this.cltintDepartmanID.HeaderText = "Departman No";
            this.cltintDepartmanID.Name = "cltintDepartmanID";
            this.cltintDepartmanID.ReadOnly = true;
            this.cltintDepartmanID.Visible = false;
            this.cltintDepartmanID.Width = 101;
            // 
            // clstrDepartman
            // 
            this.clstrDepartman.DataPropertyName = "strDepartman";
            this.clstrDepartman.HeaderText = "Departman";
            this.clstrDepartman.Name = "clstrDepartman";
            this.clstrDepartman.ReadOnly = true;
            this.clstrDepartman.Visible = false;
            this.clstrDepartman.Width = 84;
            // 
            // clstrKonu
            // 
            this.clstrKonu.DataPropertyName = "strKonu";
            this.clstrKonu.HeaderText = "Konu";
            this.clstrKonu.Name = "clstrKonu";
            this.clstrKonu.ReadOnly = true;
            this.clstrKonu.Width = 183;
            // 
            // clstrIcerik
            // 
            this.clstrIcerik.DataPropertyName = "strIcerik";
            this.clstrIcerik.HeaderText = "Mesaj";
            this.clstrIcerik.Name = "clstrIcerik";
            this.clstrIcerik.ReadOnly = true;
            this.clstrIcerik.Visible = false;
            this.clstrIcerik.Width = 60;
            // 
            // cldtGondermeZamani
            // 
            this.cldtGondermeZamani.DataPropertyName = "dtGondermeZamani";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cldtGondermeZamani.DefaultCellStyle = dataGridViewCellStyle2;
            this.cldtGondermeZamani.HeaderText = "Gönderme Zamanı";
            this.cldtGondermeZamani.Name = "cldtGondermeZamani";
            this.cldtGondermeZamani.ReadOnly = true;
            this.cldtGondermeZamani.Width = 119;
            // 
            // cldtOkunmaZamani
            // 
            this.cldtOkunmaZamani.DataPropertyName = "dtOkunmaZamani";
            this.cldtOkunmaZamani.HeaderText = "Okunma Zamanı";
            this.cldtOkunmaZamani.Name = "cldtOkunmaZamani";
            this.cldtOkunmaZamani.ReadOnly = true;
            this.cldtOkunmaZamani.Visible = false;
            this.cldtOkunmaZamani.Width = 110;
            // 
            // clblOkundu
            // 
            this.clblOkundu.DataPropertyName = "blOkundu";
            this.clblOkundu.HeaderText = "Okundu";
            this.clblOkundu.Name = "clblOkundu";
            this.clblOkundu.ReadOnly = true;
            this.clblOkundu.Width = 51;
            // 
            // clblGonderenSil
            // 
            this.clblGonderenSil.DataPropertyName = "blGonderenSil";
            this.clblGonderenSil.HeaderText = "Gönderen Sildi";
            this.clblGonderenSil.Name = "clblGonderenSil";
            this.clblGonderenSil.ReadOnly = true;
            this.clblGonderenSil.Visible = false;
            this.clblGonderenSil.Width = 82;
            // 
            // clblOkuyanSil
            // 
            this.clblOkuyanSil.DataPropertyName = "blOkuyanSil";
            this.clblOkuyanSil.HeaderText = "Okuyan Sildi";
            this.clblOkuyanSil.Name = "clblOkuyanSil";
            this.clblOkuyanSil.ReadOnly = true;
            this.clblOkuyanSil.Visible = false;
            this.clblOkuyanSil.Width = 72;
            // 
            // clCevapla
            // 
            this.clCevapla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clCevapla.HeaderText = "Cevapla";
            this.clCevapla.Name = "clCevapla";
            this.clCevapla.ReadOnly = true;
            this.clCevapla.Width = 60;
            // 
            // cmbDepartmanlar
            // 
            this.cmbDepartmanlar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartmanlar.FormattingEnabled = true;
            this.cmbDepartmanlar.Location = new System.Drawing.Point(157, 25);
            this.cmbDepartmanlar.Name = "cmbDepartmanlar";
            this.cmbDepartmanlar.Size = new System.Drawing.Size(243, 21);
            this.cmbDepartmanlar.TabIndex = 1;
            this.cmbDepartmanlar.SelectedIndexChanged += new System.EventHandler(this.cmbDepartmanlar_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Departman:";
            // 
            // txtKonu
            // 
            this.txtKonu.BackColor = System.Drawing.Color.White;
            this.txtKonu.Location = new System.Drawing.Point(101, 268);
            this.txtKonu.Name = "txtKonu";
            this.txtKonu.ReadOnly = true;
            this.txtKonu.Size = new System.Drawing.Size(243, 20);
            this.txtKonu.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Konu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mesaj:";
            // 
            // txtMesaj
            // 
            this.txtMesaj.BackColor = System.Drawing.Color.White;
            this.txtMesaj.Location = new System.Drawing.Point(101, 294);
            this.txtMesaj.Multiline = true;
            this.txtMesaj.Name = "txtMesaj";
            this.txtMesaj.ReadOnly = true;
            this.txtMesaj.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMesaj.Size = new System.Drawing.Size(622, 156);
            this.txtMesaj.TabIndex = 3;
            // 
            // lblZaman
            // 
            this.lblZaman.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblZaman.Location = new System.Drawing.Point(350, 271);
            this.lblZaman.Name = "lblZaman";
            this.lblZaman.Size = new System.Drawing.Size(117, 13);
            this.lblZaman.TabIndex = 2;
            this.lblZaman.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(545, 456);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(178, 23);
            this.btnSil.TabIndex = 4;
            this.btnSil.Text = "Mesajı Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // rbGelenKutusu
            // 
            this.rbGelenKutusu.AutoSize = true;
            this.rbGelenKutusu.Checked = true;
            this.rbGelenKutusu.Location = new System.Drawing.Point(470, 16);
            this.rbGelenKutusu.Name = "rbGelenKutusu";
            this.rbGelenKutusu.Size = new System.Drawing.Size(95, 17);
            this.rbGelenKutusu.TabIndex = 5;
            this.rbGelenKutusu.TabStop = true;
            this.rbGelenKutusu.Text = "Gelen Mesajlar";
            this.rbGelenKutusu.UseVisualStyleBackColor = true;
            this.rbGelenKutusu.CheckedChanged += new System.EventHandler(this.rbGelenKutusu_CheckedChanged);
            // 
            // rbGidenKutusu
            // 
            this.rbGidenKutusu.AutoSize = true;
            this.rbGidenKutusu.Location = new System.Drawing.Point(600, 16);
            this.rbGidenKutusu.Name = "rbGidenKutusu";
            this.rbGidenKutusu.Size = new System.Drawing.Size(118, 17);
            this.rbGidenKutusu.TabIndex = 5;
            this.rbGidenKutusu.Text = "Gönderilen Mesajlar";
            this.rbGidenKutusu.UseVisualStyleBackColor = true;
            this.rbGidenKutusu.CheckedChanged += new System.EventHandler(this.rbGidenKutusu_CheckedChanged);
            // 
            // btnMesajYaz
            // 
            this.btnMesajYaz.Location = new System.Drawing.Point(12, 456);
            this.btnMesajYaz.Name = "btnMesajYaz";
            this.btnMesajYaz.Size = new System.Drawing.Size(178, 23);
            this.btnMesajYaz.TabIndex = 4;
            this.btnMesajYaz.Text = "Yeni Mesaj Yaz";
            this.btnMesajYaz.UseVisualStyleBackColor = true;
            this.btnMesajYaz.Click += new System.EventHandler(this.btnMesajYaz_Click);
            // 
            // btnYenile
            // 
            this.btnYenile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnYenile.Image = global::Sultanlar.UI.Properties.Resources.refresh;
            this.btnYenile.Location = new System.Drawing.Point(12, 6);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(35, 36);
            this.btnYenile.TabIndex = 31;
            this.btnYenile.UseVisualStyleBackColor = true;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // lblMesajSayisi
            // 
            this.lblMesajSayisi.ForeColor = System.Drawing.Color.Red;
            this.lblMesajSayisi.Location = new System.Drawing.Point(623, 268);
            this.lblMesajSayisi.Name = "lblMesajSayisi";
            this.lblMesajSayisi.Size = new System.Drawing.Size(100, 19);
            this.lblMesajSayisi.TabIndex = 32;
            this.lblMesajSayisi.Text = "999";
            this.lblMesajSayisi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(157, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(243, 20);
            this.dateTimePicker1.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(95, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Başlangıç:";
            // 
            // frmINTERNETmesajlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 491);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lblMesajSayisi);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.rbGidenKutusu);
            this.Controls.Add(this.rbGelenKutusu);
            this.Controls.Add(this.btnMesajYaz);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.txtMesaj);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtKonu);
            this.Controls.Add(this.lblZaman);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDepartmanlar);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmINTERNETmesajlar";
            this.Text = "Mesajlar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmINTERNETmesajlar_FormClosing);
            this.Load += new System.EventHandler(this.frmINTERNETmesajlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbDepartmanlar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKonu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMesaj;
        private System.Windows.Forms.Label lblZaman;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.RadioButton rbGelenKutusu;
        private System.Windows.Forms.RadioButton rbGidenKutusu;
        private System.Windows.Forms.DataGridViewTextBoxColumn clpkMesajID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clintMusteriID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrMusteri;
        private System.Windows.Forms.DataGridViewTextBoxColumn cltintDepartmanID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrDepartman;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrKonu;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrIcerik;
        private System.Windows.Forms.DataGridViewTextBoxColumn cldtGondermeZamani;
        private System.Windows.Forms.DataGridViewTextBoxColumn cldtOkunmaZamani;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clblOkundu;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clblGonderenSil;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clblOkuyanSil;
        private System.Windows.Forms.DataGridViewButtonColumn clCevapla;
        private System.Windows.Forms.Button btnMesajYaz;
        private System.Windows.Forms.Button btnYenile;
        private System.Windows.Forms.Label lblMesajSayisi;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
    }
}