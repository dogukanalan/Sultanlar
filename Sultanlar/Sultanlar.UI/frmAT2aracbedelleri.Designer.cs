namespace Sultanlar.UI
{
    partial class frmAT2aracbedelleri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAT2aracbedelleri));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.txtSil = new System.Windows.Forms.TextBox();
            this.txtGuncelle = new System.Windows.Forms.TextBox();
            this.txtEkle = new System.Windows.Forms.TextBox();
            this.cmbEkleBolge = new System.Windows.Forms.ComboBox();
            this.cmbGuncelle = new System.Windows.Forms.ComboBox();
            this.cmbEkleArac = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpEkleBitis = new System.Windows.Forms.DateTimePicker();
            this.dtpEkleBaslangic = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpGuncelleBitis = new System.Windows.Forms.DateTimePicker();
            this.dtpGuncelleBaslangic = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnKopyala = new System.Windows.Forms.Button();
            this.btnYenile = new System.Windows.Forms.Button();
            this.cbPasifler = new System.Windows.Forms.CheckBox();
            this.lbAracBedelleri = new Sultanlar.UI.VListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(31, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Plaka - Bölge";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Bölge:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Plaka:";
            // 
            // btnSil
            // 
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.ForeColor = System.Drawing.Color.Black;
            this.btnSil.Location = new System.Drawing.Point(138, 37);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(75, 23);
            this.btnSil.TabIndex = 9;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncelle.ForeColor = System.Drawing.Color.Black;
            this.btnGuncelle.Location = new System.Drawing.Point(138, 94);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(75, 23);
            this.btnGuncelle.TabIndex = 7;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEkle.ForeColor = System.Drawing.Color.Black;
            this.btnEkle.Location = new System.Drawing.Point(138, 122);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 23);
            this.btnEkle.TabIndex = 4;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // txtSil
            // 
            this.txtSil.Enabled = false;
            this.txtSil.ForeColor = System.Drawing.Color.Black;
            this.txtSil.Location = new System.Drawing.Point(4, 38);
            this.txtSil.Name = "txtSil";
            this.txtSil.ReadOnly = true;
            this.txtSil.Size = new System.Drawing.Size(128, 21);
            this.txtSil.TabIndex = 8;
            // 
            // txtGuncelle
            // 
            this.txtGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGuncelle.ForeColor = System.Drawing.Color.Black;
            this.txtGuncelle.Location = new System.Drawing.Point(46, 95);
            this.txtGuncelle.Name = "txtGuncelle";
            this.txtGuncelle.Size = new System.Drawing.Size(88, 20);
            this.txtGuncelle.TabIndex = 6;
            // 
            // txtEkle
            // 
            this.txtEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEkle.ForeColor = System.Drawing.Color.Black;
            this.txtEkle.Location = new System.Drawing.Point(46, 124);
            this.txtEkle.Name = "txtEkle";
            this.txtEkle.Size = new System.Drawing.Size(86, 20);
            this.txtEkle.TabIndex = 3;
            // 
            // cmbEkleBolge
            // 
            this.cmbEkleBolge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEkleBolge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbEkleBolge.ForeColor = System.Drawing.Color.Black;
            this.cmbEkleBolge.FormattingEnabled = true;
            this.cmbEkleBolge.Location = new System.Drawing.Point(46, 50);
            this.cmbEkleBolge.Name = "cmbEkleBolge";
            this.cmbEkleBolge.Size = new System.Drawing.Size(167, 21);
            this.cmbEkleBolge.TabIndex = 2;
            // 
            // cmbGuncelle
            // 
            this.cmbGuncelle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbGuncelle.ForeColor = System.Drawing.Color.Black;
            this.cmbGuncelle.FormattingEnabled = true;
            this.cmbGuncelle.Location = new System.Drawing.Point(46, 19);
            this.cmbGuncelle.Name = "cmbGuncelle";
            this.cmbGuncelle.Size = new System.Drawing.Size(167, 21);
            this.cmbGuncelle.TabIndex = 5;
            // 
            // cmbEkleArac
            // 
            this.cmbEkleArac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEkleArac.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbEkleArac.ForeColor = System.Drawing.Color.Black;
            this.cmbEkleArac.FormattingEnabled = true;
            this.cmbEkleArac.Location = new System.Drawing.Point(46, 25);
            this.cmbEkleArac.Name = "cmbEkleArac";
            this.cmbEkleArac.Size = new System.Drawing.Size(167, 21);
            this.cmbEkleArac.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpEkleBitis);
            this.groupBox1.Controls.Add(this.dtpEkleBaslangic);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtEkle);
            this.groupBox1.Controls.Add(this.btnEkle);
            this.groupBox1.Controls.Add(this.cmbEkleArac);
            this.groupBox1.Controls.Add(this.cmbEkleBolge);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox1.Location = new System.Drawing.Point(275, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 150);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ekleme";
            // 
            // dtpEkleBitis
            // 
            this.dtpEkleBitis.Location = new System.Drawing.Point(46, 100);
            this.dtpEkleBitis.Name = "dtpEkleBitis";
            this.dtpEkleBitis.Size = new System.Drawing.Size(167, 21);
            this.dtpEkleBitis.TabIndex = 44;
            // 
            // dtpEkleBaslangic
            // 
            this.dtpEkleBaslangic.Location = new System.Drawing.Point(46, 75);
            this.dtpEkleBaslangic.Name = "dtpEkleBaslangic";
            this.dtpEkleBaslangic.Size = new System.Drawing.Size(167, 21);
            this.dtpEkleBaslangic.TabIndex = 44;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(6, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 43;
            this.label9.Text = "Bitiş:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(6, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "Başl.:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(6, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Bölge:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(6, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "Bedel:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpGuncelleBitis);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtpGuncelleBaslangic);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtGuncelle);
            this.groupBox2.Controls.Add(this.btnGuncelle);
            this.groupBox2.Controls.Add(this.cmbGuncelle);
            this.groupBox2.Enabled = false;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox2.Location = new System.Drawing.Point(275, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(218, 124);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Güncelleme";
            // 
            // dtpGuncelleBitis
            // 
            this.dtpGuncelleBitis.Location = new System.Drawing.Point(46, 70);
            this.dtpGuncelleBitis.Name = "dtpGuncelleBitis";
            this.dtpGuncelleBitis.Size = new System.Drawing.Size(167, 21);
            this.dtpGuncelleBitis.TabIndex = 44;
            // 
            // dtpGuncelleBaslangic
            // 
            this.dtpGuncelleBaslangic.Location = new System.Drawing.Point(46, 45);
            this.dtpGuncelleBaslangic.Name = "dtpGuncelleBaslangic";
            this.dtpGuncelleBaslangic.Size = new System.Drawing.Size(167, 21);
            this.dtpGuncelleBaslangic.TabIndex = 44;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(6, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "Bitiş:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(6, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "Bedel:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(6, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 43;
            this.label10.Text = "Başl.:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtSil);
            this.groupBox3.Controls.Add(this.btnSil);
            this.groupBox3.Enabled = false;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox3.Location = new System.Drawing.Point(275, 304);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(218, 68);
            this.groupBox3.TabIndex = 47;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Silme";
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(499, 23);
            this.label7.TabIndex = 52;
            // 
            // btnKopyala
            // 
            this.btnKopyala.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnKopyala.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKopyala.ForeColor = System.Drawing.Color.Black;
            this.btnKopyala.Location = new System.Drawing.Point(0, 0);
            this.btnKopyala.Name = "btnKopyala";
            this.btnKopyala.Size = new System.Drawing.Size(269, 23);
            this.btnKopyala.TabIndex = 9;
            this.btnKopyala.Text = "Kopyalama";
            this.btnKopyala.UseVisualStyleBackColor = true;
            this.btnKopyala.Click += new System.EventHandler(this.btnKopyala_Click);
            // 
            // btnYenile
            // 
            this.btnYenile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnYenile.Image = global::Sultanlar.UI.Properties.Resources.Refresh_icon;
            this.btnYenile.Location = new System.Drawing.Point(475, 0);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(24, 24);
            this.btnYenile.TabIndex = 44;
            this.btnYenile.UseVisualStyleBackColor = true;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // cbPasifler
            // 
            this.cbPasifler.AutoSize = true;
            this.cbPasifler.Location = new System.Drawing.Point(400, 4);
            this.cbPasifler.Name = "cbPasifler";
            this.cbPasifler.Size = new System.Drawing.Size(68, 17);
            this.cbPasifler.TabIndex = 53;
            this.cbPasifler.Text = "Silinenler";
            this.cbPasifler.UseVisualStyleBackColor = true;
            // 
            // lbAracBedelleri
            // 
            this.lbAracBedelleri.Count = 1;
            this.lbAracBedelleri.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbAracBedelleri.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbAracBedelleri.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbAracBedelleri.FormattingEnabled = true;
            this.lbAracBedelleri.ItemHeight = 16;
            this.lbAracBedelleri.Location = new System.Drawing.Point(0, 23);
            this.lbAracBedelleri.Name = "lbAracBedelleri";
            this.lbAracBedelleri.Size = new System.Drawing.Size(269, 355);
            this.lbAracBedelleri.TabIndex = 0;
            this.lbAracBedelleri.SelectedIndexChanged += new System.EventHandler(this.lbAracBedelleri_SelectedIndexChanged);
            // 
            // frmAT2aracbedelleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 378);
            this.Controls.Add(this.cbPasifler);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnKopyala);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbAracBedelleri);
            this.Controls.Add(this.label7);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(515, 416);
            this.Name = "frmAT2aracbedelleri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Araç Kira Bedelleri";
            this.Load += new System.EventHandler(this.frmAT2aracbedelleri_Load);
            this.SizeChanged += new System.EventHandler(this.frmAT2aracbedelleri_SizeChanged);
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

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.TextBox txtSil;
        private System.Windows.Forms.TextBox txtGuncelle;
        private System.Windows.Forms.TextBox txtEkle;
        private System.Windows.Forms.ComboBox cmbEkleBolge;
        private System.Windows.Forms.ComboBox cmbGuncelle;
        private System.Windows.Forms.ComboBox cmbEkleArac;
        private System.Windows.Forms.Button btnYenile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnKopyala;
        private System.Windows.Forms.DateTimePicker dtpEkleBitis;
        private System.Windows.Forms.DateTimePicker dtpEkleBaslangic;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpGuncelleBitis;
        private System.Windows.Forms.DateTimePicker dtpGuncelleBaslangic;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private VListBox lbAracBedelleri;
        private System.Windows.Forms.CheckBox cbPasifler;
    }
}