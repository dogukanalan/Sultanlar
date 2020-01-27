namespace Sultanlar.UI
{
    partial class frmAT2lojistikfirmalar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAT2lojistikfirmalar));
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.txtSil = new System.Windows.Forms.TextBox();
            this.txtGuncelleAd = new System.Windows.Forms.TextBox();
            this.txtEkleSorumlu = new System.Windows.Forms.TextBox();
            this.lbFirmalar = new System.Windows.Forms.ListBox();
            this.btnYenile = new System.Windows.Forms.Button();
            this.txtEkleAd = new System.Windows.Forms.TextBox();
            this.txtEkleTelefon = new System.Windows.Forms.TextBox();
            this.txtGuncelleTelefon = new System.Windows.Forms.TextBox();
            this.txtGuncelleSorumlu = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbPasifler = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSil
            // 
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.ForeColor = System.Drawing.Color.Black;
            this.btnSil.Location = new System.Drawing.Point(140, 18);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(75, 23);
            this.btnSil.TabIndex = 6;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncelle.ForeColor = System.Drawing.Color.Black;
            this.btnGuncelle.Location = new System.Drawing.Point(115, 44);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(99, 23);
            this.btnGuncelle.TabIndex = 4;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEkle.ForeColor = System.Drawing.Color.Black;
            this.btnEkle.Location = new System.Drawing.Point(112, 44);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(100, 23);
            this.btnEkle.TabIndex = 2;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // txtSil
            // 
            this.txtSil.Enabled = false;
            this.txtSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSil.ForeColor = System.Drawing.Color.Black;
            this.txtSil.Location = new System.Drawing.Point(6, 20);
            this.txtSil.Name = "txtSil";
            this.txtSil.ReadOnly = true;
            this.txtSil.Size = new System.Drawing.Size(128, 20);
            this.txtSil.TabIndex = 5;
            // 
            // txtGuncelleAd
            // 
            this.txtGuncelleAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGuncelleAd.ForeColor = System.Drawing.Color.Gray;
            this.txtGuncelleAd.Location = new System.Drawing.Point(6, 20);
            this.txtGuncelleAd.Name = "txtGuncelleAd";
            this.txtGuncelleAd.Size = new System.Drawing.Size(100, 20);
            this.txtGuncelleAd.TabIndex = 3;
            this.txtGuncelleAd.Text = "Firma";
            this.txtGuncelleAd.Enter += new System.EventHandler(this.txtEkleAd_Enter);
            this.txtGuncelleAd.Leave += new System.EventHandler(this.txtEkleAd_Leave);
            // 
            // txtEkleSorumlu
            // 
            this.txtEkleSorumlu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEkleSorumlu.ForeColor = System.Drawing.Color.Gray;
            this.txtEkleSorumlu.Location = new System.Drawing.Point(112, 20);
            this.txtEkleSorumlu.Name = "txtEkleSorumlu";
            this.txtEkleSorumlu.Size = new System.Drawing.Size(100, 20);
            this.txtEkleSorumlu.TabIndex = 1;
            this.txtEkleSorumlu.Text = "Sorumlu";
            this.txtEkleSorumlu.Enter += new System.EventHandler(this.txtEkleAd_Enter);
            this.txtEkleSorumlu.Leave += new System.EventHandler(this.txtEkleAd_Leave);
            // 
            // lbFirmalar
            // 
            this.lbFirmalar.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbFirmalar.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbFirmalar.FormattingEnabled = true;
            this.lbFirmalar.ItemHeight = 14;
            this.lbFirmalar.Location = new System.Drawing.Point(0, 0);
            this.lbFirmalar.Name = "lbFirmalar";
            this.lbFirmalar.Size = new System.Drawing.Size(169, 272);
            this.lbFirmalar.TabIndex = 0;
            this.lbFirmalar.SelectedIndexChanged += new System.EventHandler(this.lbFirmalar_SelectedIndexChanged);
            // 
            // btnYenile
            // 
            this.btnYenile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnYenile.Image = global::Sultanlar.UI.Properties.Resources.Refresh_icon;
            this.btnYenile.Location = new System.Drawing.Point(375, 0);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(24, 24);
            this.btnYenile.TabIndex = 48;
            this.btnYenile.UseVisualStyleBackColor = true;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // txtEkleAd
            // 
            this.txtEkleAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEkleAd.ForeColor = System.Drawing.Color.Gray;
            this.txtEkleAd.Location = new System.Drawing.Point(6, 20);
            this.txtEkleAd.Name = "txtEkleAd";
            this.txtEkleAd.Size = new System.Drawing.Size(100, 20);
            this.txtEkleAd.TabIndex = 49;
            this.txtEkleAd.Text = "Firma";
            this.txtEkleAd.Enter += new System.EventHandler(this.txtEkleAd_Enter);
            this.txtEkleAd.Leave += new System.EventHandler(this.txtEkleAd_Leave);
            // 
            // txtEkleTelefon
            // 
            this.txtEkleTelefon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEkleTelefon.ForeColor = System.Drawing.Color.Gray;
            this.txtEkleTelefon.Location = new System.Drawing.Point(6, 46);
            this.txtEkleTelefon.MaxLength = 11;
            this.txtEkleTelefon.Name = "txtEkleTelefon";
            this.txtEkleTelefon.Size = new System.Drawing.Size(100, 20);
            this.txtEkleTelefon.TabIndex = 50;
            this.txtEkleTelefon.Text = "Telefon";
            this.txtEkleTelefon.Enter += new System.EventHandler(this.txtEkleAd_Enter);
            this.txtEkleTelefon.Leave += new System.EventHandler(this.txtEkleAd_Leave);
            // 
            // txtGuncelleTelefon
            // 
            this.txtGuncelleTelefon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGuncelleTelefon.ForeColor = System.Drawing.Color.Gray;
            this.txtGuncelleTelefon.Location = new System.Drawing.Point(6, 46);
            this.txtGuncelleTelefon.MaxLength = 11;
            this.txtGuncelleTelefon.Name = "txtGuncelleTelefon";
            this.txtGuncelleTelefon.Size = new System.Drawing.Size(100, 20);
            this.txtGuncelleTelefon.TabIndex = 50;
            this.txtGuncelleTelefon.Text = "Telefon";
            this.txtGuncelleTelefon.Enter += new System.EventHandler(this.txtEkleAd_Enter);
            this.txtGuncelleTelefon.Leave += new System.EventHandler(this.txtEkleAd_Leave);
            // 
            // txtGuncelleSorumlu
            // 
            this.txtGuncelleSorumlu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGuncelleSorumlu.ForeColor = System.Drawing.Color.Gray;
            this.txtGuncelleSorumlu.Location = new System.Drawing.Point(115, 20);
            this.txtGuncelleSorumlu.Name = "txtGuncelleSorumlu";
            this.txtGuncelleSorumlu.Size = new System.Drawing.Size(100, 20);
            this.txtGuncelleSorumlu.TabIndex = 1;
            this.txtGuncelleSorumlu.Text = "Sorumlu";
            this.txtGuncelleSorumlu.Enter += new System.EventHandler(this.txtEkleAd_Enter);
            this.txtGuncelleSorumlu.Leave += new System.EventHandler(this.txtEkleAd_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEkleAd);
            this.groupBox1.Controls.Add(this.txtEkleSorumlu);
            this.groupBox1.Controls.Add(this.btnEkle);
            this.groupBox1.Controls.Add(this.txtEkleTelefon);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox1.Location = new System.Drawing.Point(175, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 74);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ekleme";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtGuncelleAd);
            this.groupBox2.Controls.Add(this.txtGuncelleSorumlu);
            this.groupBox2.Controls.Add(this.btnGuncelle);
            this.groupBox2.Controls.Add(this.txtGuncelleTelefon);
            this.groupBox2.Enabled = false;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox2.Location = new System.Drawing.Point(175, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(218, 73);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Güncelleme";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtSil);
            this.groupBox3.Controls.Add(this.btnSil);
            this.groupBox3.Enabled = false;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox3.Location = new System.Drawing.Point(175, 205);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(218, 47);
            this.groupBox3.TabIndex = 54;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Silme";
            // 
            // cbPasifler
            // 
            this.cbPasifler.AutoSize = true;
            this.cbPasifler.Location = new System.Drawing.Point(300, 5);
            this.cbPasifler.Name = "cbPasifler";
            this.cbPasifler.Size = new System.Drawing.Size(68, 17);
            this.cbPasifler.TabIndex = 56;
            this.cbPasifler.Text = "Silinenler";
            this.cbPasifler.UseVisualStyleBackColor = true;
            // 
            // frmAT2lojistikfirmalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 272);
            this.Controls.Add(this.cbPasifler);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbFirmalar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(415, 310);
            this.Name = "frmAT2lojistikfirmalar";
            this.Text = "Lojistik Firmaları";
            this.Load += new System.EventHandler(this.frmAT2lojistikfirmalar_Load);
            this.SizeChanged += new System.EventHandler(this.frmAT2lojistikfirmalar_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.TextBox txtSil;
        private System.Windows.Forms.TextBox txtGuncelleAd;
        private System.Windows.Forms.TextBox txtEkleSorumlu;
        private System.Windows.Forms.ListBox lbFirmalar;
        private System.Windows.Forms.Button btnYenile;
        private System.Windows.Forms.TextBox txtEkleAd;
        private System.Windows.Forms.TextBox txtEkleTelefon;
        private System.Windows.Forms.TextBox txtGuncelleTelefon;
        private System.Windows.Forms.TextBox txtGuncelleSorumlu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbPasifler;
    }
}