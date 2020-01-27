namespace Sultanlar.UI
{
    partial class frmFinansCariHesapEklemeCikarma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFinansCariHesapEklemeCikarma));
            this.cmbAlinacak = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.clbCariHesaplar = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTumu = new System.Windows.Forms.CheckBox();
            this.clbAktarilacaklar = new System.Windows.Forms.CheckedListBox();
            this.btnAktar = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbAlinacak
            // 
            this.cmbAlinacak.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlinacak.FormattingEnabled = true;
            this.cmbAlinacak.Location = new System.Drawing.Point(105, 12);
            this.cmbAlinacak.Name = "cmbAlinacak";
            this.cmbAlinacak.Size = new System.Drawing.Size(280, 21);
            this.cmbAlinacak.TabIndex = 0;
            this.cmbAlinacak.SelectedIndexChanged += new System.EventHandler(this.cmbAlinacak_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Satış Temsilcisi:";
            // 
            // clbCariHesaplar
            // 
            this.clbCariHesaplar.FormattingEnabled = true;
            this.clbCariHesaplar.Location = new System.Drawing.Point(105, 39);
            this.clbCariHesaplar.Name = "clbCariHesaplar";
            this.clbCariHesaplar.Size = new System.Drawing.Size(673, 214);
            this.clbCariHesaplar.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cari Hesaplar:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 26);
            this.label3.TabIndex = 1;
            this.label3.Text = "C/H Aktarılacak\r\nSatış Temsilcileri:";
            // 
            // cbTumu
            // 
            this.cbTumu.AutoSize = true;
            this.cbTumu.Location = new System.Drawing.Point(108, 262);
            this.cbTumu.Name = "cbTumu";
            this.cbTumu.Size = new System.Drawing.Size(87, 17);
            this.cbTumu.TabIndex = 3;
            this.cbTumu.Text = "Tümünü Seç";
            this.cbTumu.UseVisualStyleBackColor = true;
            this.cbTumu.CheckedChanged += new System.EventHandler(this.cbTumu_CheckedChanged);
            // 
            // clbAktarilacaklar
            // 
            this.clbAktarilacaklar.FormattingEnabled = true;
            this.clbAktarilacaklar.Location = new System.Drawing.Point(105, 285);
            this.clbAktarilacaklar.Name = "clbAktarilacaklar";
            this.clbAktarilacaklar.Size = new System.Drawing.Size(280, 169);
            this.clbAktarilacaklar.TabIndex = 2;
            // 
            // btnAktar
            // 
            this.btnAktar.Location = new System.Drawing.Point(670, 418);
            this.btnAktar.Name = "btnAktar";
            this.btnAktar.Size = new System.Drawing.Size(108, 36);
            this.btnAktar.TabIndex = 4;
            this.btnAktar.Text = "Aktar";
            this.btnAktar.UseVisualStyleBackColor = true;
            this.btnAktar.Click += new System.EventHandler(this.btnAktar_Click);
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.White;
            this.txtLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtLog.Location = new System.Drawing.Point(391, 285);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(387, 118);
            this.txtLog.TabIndex = 5;
            this.txtLog.Text = "Henüz aktarım yapılmadı...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(388, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Aktarılanlar:";
            // 
            // btnTemizle
            // 
            this.btnTemizle.Location = new System.Drawing.Point(391, 418);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(108, 36);
            this.btnTemizle.TabIndex = 6;
            this.btnTemizle.Text = "Yeni Aktarım";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // frmFinansCariHesapEklemeCikarma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 462);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnAktar);
            this.Controls.Add(this.cbTumu);
            this.Controls.Add(this.clbAktarilacaklar);
            this.Controls.Add(this.clbCariHesaplar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbAlinacak);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFinansCariHesapEklemeCikarma";
            this.Text = "Finans : Satış Temsilcisi Cari Hesap Ekleme";
            this.Load += new System.EventHandler(this.frmFinansCariHesapEklemeCikarma_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbAlinacak;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox clbCariHesaplar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbTumu;
        private System.Windows.Forms.CheckedListBox clbAktarilacaklar;
        private System.Windows.Forms.Button btnAktar;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTemizle;
    }
}