namespace Sultanlar.UI
{
    partial class frmINTERNETiadelersevk
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmINTERNETiadelersevk));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clpkID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clintIadeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrSofor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrMuavin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cldtTarihGidis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cldtTarihGelis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrAciklama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSofor = new System.Windows.Forms.TextBox();
            this.txtMuavin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGelis = new System.Windows.Forms.Button();
            this.dtpTarihGelis = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbEkleme = new System.Windows.Forms.GroupBox();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.dtpTarihGidis = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpSaatGidis = new System.Windows.Forms.DateTimePicker();
            this.gbGuncelleme = new System.Windows.Forms.GroupBox();
            this.dtpSaatGelis = new System.Windows.Forms.DateTimePicker();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAciklama = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbEkleme.SuspendLayout();
            this.gbGuncelleme.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 32;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clpkID,
            this.clintIadeID,
            this.clstrSofor,
            this.clstrMuavin,
            this.cldtTarihGidis,
            this.cldtTarihGelis,
            this.clstrAciklama});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(718, 185);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // clpkID
            // 
            this.clpkID.DataPropertyName = "pkID";
            this.clpkID.HeaderText = "No";
            this.clpkID.Name = "clpkID";
            this.clpkID.ReadOnly = true;
            this.clpkID.Visible = false;
            // 
            // clintIadeID
            // 
            this.clintIadeID.DataPropertyName = "intIadeID";
            this.clintIadeID.HeaderText = "Iade No";
            this.clintIadeID.Name = "clintIadeID";
            this.clintIadeID.ReadOnly = true;
            this.clintIadeID.Visible = false;
            // 
            // clstrSofor
            // 
            this.clstrSofor.DataPropertyName = "strSofor";
            this.clstrSofor.HeaderText = "Şoför";
            this.clstrSofor.Name = "clstrSofor";
            this.clstrSofor.ReadOnly = true;
            this.clstrSofor.Width = 120;
            // 
            // clstrMuavin
            // 
            this.clstrMuavin.DataPropertyName = "strMuavin";
            this.clstrMuavin.HeaderText = "Muavin";
            this.clstrMuavin.Name = "clstrMuavin";
            this.clstrMuavin.ReadOnly = true;
            this.clstrMuavin.Width = 120;
            // 
            // cldtTarihGidis
            // 
            this.cldtTarihGidis.DataPropertyName = "dtTarihGidis";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "G";
            this.cldtTarihGidis.DefaultCellStyle = dataGridViewCellStyle2;
            this.cldtTarihGidis.HeaderText = "Verilme Tarihi";
            this.cldtTarihGidis.Name = "cldtTarihGidis";
            this.cldtTarihGidis.ReadOnly = true;
            this.cldtTarihGidis.Width = 128;
            // 
            // cldtTarihGelis
            // 
            this.cldtTarihGelis.DataPropertyName = "dtTarihGelis";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "G";
            dataGridViewCellStyle3.NullValue = null;
            this.cldtTarihGelis.DefaultCellStyle = dataGridViewCellStyle3;
            this.cldtTarihGelis.HeaderText = "Geliş Tarihi";
            this.cldtTarihGelis.Name = "cldtTarihGelis";
            this.cldtTarihGelis.ReadOnly = true;
            this.cldtTarihGelis.Width = 128;
            // 
            // clstrAciklama
            // 
            this.clstrAciklama.DataPropertyName = "strAciklama";
            this.clstrAciklama.HeaderText = "Açıklama";
            this.clstrAciklama.Name = "clstrAciklama";
            this.clstrAciklama.ReadOnly = true;
            this.clstrAciklama.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Şoför:";
            // 
            // txtSofor
            // 
            this.txtSofor.Location = new System.Drawing.Point(160, 21);
            this.txtSofor.Name = "txtSofor";
            this.txtSofor.Size = new System.Drawing.Size(116, 20);
            this.txtSofor.TabIndex = 2;
            // 
            // txtMuavin
            // 
            this.txtMuavin.Location = new System.Drawing.Point(341, 21);
            this.txtMuavin.Name = "txtMuavin";
            this.txtMuavin.Size = new System.Drawing.Size(116, 20);
            this.txtMuavin.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Muavin:";
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(517, 19);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(171, 23);
            this.btnEkle.TabIndex = 6;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Enabled = false;
            this.btnSil.Location = new System.Drawing.Point(607, 161);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(110, 23);
            this.btnSil.TabIndex = 1;
            this.btnSil.Text = "Satırı Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Visible = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGelis
            // 
            this.btnGelis.Location = new System.Drawing.Point(122, 19);
            this.btnGelis.Name = "btnGelis";
            this.btnGelis.Size = new System.Drawing.Size(566, 23);
            this.btnGelis.TabIndex = 9;
            this.btnGelis.Text = "Geliş Tarihini Yaz";
            this.btnGelis.UseVisualStyleBackColor = true;
            this.btnGelis.Click += new System.EventHandler(this.btnGelis_Click);
            // 
            // dtpTarihGelis
            // 
            this.dtpTarihGelis.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTarihGelis.Location = new System.Drawing.Point(160, 21);
            this.dtpTarihGelis.Name = "dtpTarihGelis";
            this.dtpTarihGelis.Size = new System.Drawing.Size(116, 20);
            this.dtpTarihGelis.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tarih:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(303, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Saat:";
            // 
            // gbEkleme
            // 
            this.gbEkleme.Controls.Add(this.btnGuncelle);
            this.gbEkleme.Controls.Add(this.btnEkle);
            this.gbEkleme.Controls.Add(this.dtpTarihGidis);
            this.gbEkleme.Controls.Add(this.label1);
            this.gbEkleme.Controls.Add(this.label2);
            this.gbEkleme.Controls.Add(this.txtSofor);
            this.gbEkleme.Controls.Add(this.label6);
            this.gbEkleme.Controls.Add(this.txtMuavin);
            this.gbEkleme.Controls.Add(this.label5);
            this.gbEkleme.Controls.Add(this.dtpSaatGidis);
            this.gbEkleme.Enabled = false;
            this.gbEkleme.Location = new System.Drawing.Point(12, 222);
            this.gbEkleme.Name = "gbEkleme";
            this.gbEkleme.Size = new System.Drawing.Size(694, 74);
            this.gbEkleme.TabIndex = 6;
            this.gbEkleme.TabStop = false;
            this.gbEkleme.Text = "Ekleme";
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(517, 45);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(171, 23);
            this.btnGuncelle.TabIndex = 6;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // dtpTarihGidis
            // 
            this.dtpTarihGidis.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTarihGidis.Location = new System.Drawing.Point(160, 47);
            this.dtpTarihGidis.Name = "dtpTarihGidis";
            this.dtpTarihGidis.Size = new System.Drawing.Size(116, 20);
            this.dtpTarihGidis.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(303, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Saat:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(119, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Tarih:";
            // 
            // dtpSaatGidis
            // 
            this.dtpSaatGidis.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpSaatGidis.Location = new System.Drawing.Point(341, 47);
            this.dtpSaatGidis.Name = "dtpSaatGidis";
            this.dtpSaatGidis.ShowUpDown = true;
            this.dtpSaatGidis.Size = new System.Drawing.Size(116, 20);
            this.dtpSaatGidis.TabIndex = 5;
            // 
            // gbGuncelleme
            // 
            this.gbGuncelleme.Controls.Add(this.btnGelis);
            this.gbGuncelleme.Controls.Add(this.label3);
            this.gbGuncelleme.Controls.Add(this.dtpTarihGelis);
            this.gbGuncelleme.Controls.Add(this.label4);
            this.gbGuncelleme.Controls.Add(this.dtpSaatGelis);
            this.gbGuncelleme.Enabled = false;
            this.gbGuncelleme.Location = new System.Drawing.Point(12, 302);
            this.gbGuncelleme.Name = "gbGuncelleme";
            this.gbGuncelleme.Size = new System.Drawing.Size(694, 54);
            this.gbGuncelleme.TabIndex = 7;
            this.gbGuncelleme.TabStop = false;
            this.gbGuncelleme.Text = "Güncelleme";
            // 
            // dtpSaatGelis
            // 
            this.dtpSaatGelis.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpSaatGelis.Location = new System.Drawing.Point(341, 21);
            this.dtpSaatGelis.Name = "dtpSaatGelis";
            this.dtpSaatGelis.ShowUpDown = true;
            this.dtpSaatGelis.Size = new System.Drawing.Size(116, 20);
            this.dtpSaatGelis.TabIndex = 8;
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(127, 195);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.ReadOnly = true;
            this.txtAciklama.Size = new System.Drawing.Size(359, 20);
            this.txtAciklama.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(52, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Açıklama:";
            // 
            // btnAciklama
            // 
            this.btnAciklama.Enabled = false;
            this.btnAciklama.Location = new System.Drawing.Point(529, 193);
            this.btnAciklama.Name = "btnAciklama";
            this.btnAciklama.Size = new System.Drawing.Size(171, 23);
            this.btnAciklama.TabIndex = 10;
            this.btnAciklama.Text = "Açıklama Güncelle";
            this.btnAciklama.UseVisualStyleBackColor = true;
            this.btnAciklama.Click += new System.EventHandler(this.btnAciklama_Click);
            // 
            // frmINTERNETiadelersevk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 366);
            this.Controls.Add(this.btnAciklama);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.gbGuncelleme);
            this.Controls.Add(this.gbEkleme);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmINTERNETiadelersevk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sevk Bilgisi";
            this.Load += new System.EventHandler(this.frmINTERNETiadelersevk_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbEkleme.ResumeLayout(false);
            this.gbEkleme.PerformLayout();
            this.gbGuncelleme.ResumeLayout(false);
            this.gbGuncelleme.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSofor;
        private System.Windows.Forms.TextBox txtMuavin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGelis;
        private System.Windows.Forms.DateTimePicker dtpTarihGelis;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbEkleme;
        private System.Windows.Forms.DateTimePicker dtpTarihGidis;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbGuncelleme;
        private System.Windows.Forms.DateTimePicker dtpSaatGelis;
        private System.Windows.Forms.DateTimePicker dtpSaatGidis;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAciklama;
        private System.Windows.Forms.DataGridViewTextBoxColumn clpkID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clintIadeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrSofor;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrMuavin;
        private System.Windows.Forms.DataGridViewTextBoxColumn cldtTarihGidis;
        private System.Windows.Forms.DataGridViewTextBoxColumn cldtTarihGelis;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrAciklama;
        private System.Windows.Forms.Button btnGuncelle;
    }
}