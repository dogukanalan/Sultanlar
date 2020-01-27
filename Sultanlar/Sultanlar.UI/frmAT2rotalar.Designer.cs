namespace Sultanlar.UI
{
    partial class frmAT2rotalar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAT2rotalar));
            this.lbRotalar = new System.Windows.Forms.ListBox();
            this.btnYenile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEkleAraclar = new System.Windows.Forms.ComboBox();
            this.txtEkleRota = new System.Windows.Forms.TextBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.cmbEkleBolgeler = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbGuncelleBolgeler = new System.Windows.Forms.ComboBox();
            this.cmbGuncelleAraclar = new System.Windows.Forms.ComboBox();
            this.txtGuncelleRota = new System.Windows.Forms.TextBox();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtSil = new System.Windows.Forms.TextBox();
            this.btnSil = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cbPasifler = new System.Windows.Forms.CheckBox();
            this.lblYardim = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbRotalar
            // 
            this.lbRotalar.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbRotalar.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbRotalar.FormattingEnabled = true;
            this.lbRotalar.ItemHeight = 14;
            this.lbRotalar.Location = new System.Drawing.Point(0, 0);
            this.lbRotalar.Name = "lbRotalar";
            this.lbRotalar.Size = new System.Drawing.Size(169, 386);
            this.lbRotalar.TabIndex = 1;
            this.lbRotalar.SelectedIndexChanged += new System.EventHandler(this.lbRotalar_SelectedIndexChanged);
            // 
            // btnYenile
            // 
            this.btnYenile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnYenile.Image = global::Sultanlar.UI.Properties.Resources.Refresh_icon;
            this.btnYenile.Location = new System.Drawing.Point(375, 0);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(24, 24);
            this.btnYenile.TabIndex = 47;
            this.btnYenile.UseVisualStyleBackColor = true;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbEkleBolgeler);
            this.groupBox1.Controls.Add(this.cmbEkleAraclar);
            this.groupBox1.Controls.Add(this.txtEkleRota);
            this.groupBox1.Controls.Add(this.btnEkle);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox1.Location = new System.Drawing.Point(175, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 133);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ekleme";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 47;
            this.label2.Text = "Vars.Araç:";
            // 
            // cmbEkleAraclar
            // 
            this.cmbEkleAraclar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEkleAraclar.FormattingEnabled = true;
            this.cmbEkleAraclar.Location = new System.Drawing.Point(70, 49);
            this.cmbEkleAraclar.Name = "cmbEkleAraclar";
            this.cmbEkleAraclar.Size = new System.Drawing.Size(142, 23);
            this.cmbEkleAraclar.TabIndex = 46;
            this.cmbEkleAraclar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbEkleAraclar_MouseDown);
            // 
            // txtEkleRota
            // 
            this.txtEkleRota.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEkleRota.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEkleRota.Location = new System.Drawing.Point(70, 78);
            this.txtEkleRota.Name = "txtEkleRota";
            this.txtEkleRota.Size = new System.Drawing.Size(142, 20);
            this.txtEkleRota.TabIndex = 3;
            // 
            // btnEkle
            // 
            this.btnEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEkle.ForeColor = System.Drawing.Color.Black;
            this.btnEkle.Location = new System.Drawing.Point(111, 102);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(100, 23);
            this.btnEkle.TabIndex = 6;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // cmbEkleBolgeler
            // 
            this.cmbEkleBolgeler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEkleBolgeler.FormattingEnabled = true;
            this.cmbEkleBolgeler.Location = new System.Drawing.Point(70, 20);
            this.cmbEkleBolgeler.Name = "cmbEkleBolgeler";
            this.cmbEkleBolgeler.Size = new System.Drawing.Size(142, 23);
            this.cmbEkleBolgeler.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 47;
            this.label1.Text = "Bölge:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(3, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 47;
            this.label3.Text = "Rota:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmbGuncelleBolgeler);
            this.groupBox2.Controls.Add(this.cmbGuncelleAraclar);
            this.groupBox2.Controls.Add(this.txtGuncelleRota);
            this.groupBox2.Controls.Add(this.btnGuncelle);
            this.groupBox2.Enabled = false;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox2.Location = new System.Drawing.Point(175, 169);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(218, 133);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Güncelleme";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(3, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 47;
            this.label4.Text = "Bölge:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(3, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 15);
            this.label5.TabIndex = 47;
            this.label5.Text = "Rota:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(3, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 15);
            this.label6.TabIndex = 47;
            this.label6.Text = "Vars.Araç:";
            // 
            // cmbGuncelleBolgeler
            // 
            this.cmbGuncelleBolgeler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGuncelleBolgeler.FormattingEnabled = true;
            this.cmbGuncelleBolgeler.Location = new System.Drawing.Point(70, 20);
            this.cmbGuncelleBolgeler.Name = "cmbGuncelleBolgeler";
            this.cmbGuncelleBolgeler.Size = new System.Drawing.Size(142, 23);
            this.cmbGuncelleBolgeler.TabIndex = 46;
            // 
            // cmbGuncelleAraclar
            // 
            this.cmbGuncelleAraclar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGuncelleAraclar.FormattingEnabled = true;
            this.cmbGuncelleAraclar.Location = new System.Drawing.Point(70, 49);
            this.cmbGuncelleAraclar.Name = "cmbGuncelleAraclar";
            this.cmbGuncelleAraclar.Size = new System.Drawing.Size(142, 23);
            this.cmbGuncelleAraclar.TabIndex = 46;
            this.cmbGuncelleAraclar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbEkleAraclar_MouseDown);
            // 
            // txtGuncelleRota
            // 
            this.txtGuncelleRota.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGuncelleRota.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtGuncelleRota.Location = new System.Drawing.Point(70, 78);
            this.txtGuncelleRota.Name = "txtGuncelleRota";
            this.txtGuncelleRota.Size = new System.Drawing.Size(142, 20);
            this.txtGuncelleRota.TabIndex = 3;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncelle.ForeColor = System.Drawing.Color.Black;
            this.btnGuncelle.Location = new System.Drawing.Point(111, 102);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(100, 23);
            this.btnGuncelle.TabIndex = 6;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtSil);
            this.groupBox3.Controls.Add(this.btnSil);
            this.groupBox3.Enabled = false;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox3.Location = new System.Drawing.Point(175, 308);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(218, 72);
            this.groupBox3.TabIndex = 52;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Silme";
            // 
            // txtSil
            // 
            this.txtSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSil.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSil.Location = new System.Drawing.Point(70, 18);
            this.txtSil.Name = "txtSil";
            this.txtSil.Size = new System.Drawing.Size(142, 20);
            this.txtSil.TabIndex = 3;
            // 
            // btnSil
            // 
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.ForeColor = System.Drawing.Color.Black;
            this.btnSil.Location = new System.Drawing.Point(111, 42);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(100, 23);
            this.btnSil.TabIndex = 6;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(3, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 15);
            this.label8.TabIndex = 47;
            this.label8.Text = "Rota:";
            // 
            // cbPasifler
            // 
            this.cbPasifler.AutoSize = true;
            this.cbPasifler.Location = new System.Drawing.Point(175, 5);
            this.cbPasifler.Name = "cbPasifler";
            this.cbPasifler.Size = new System.Drawing.Size(68, 17);
            this.cbPasifler.TabIndex = 55;
            this.cbPasifler.Text = "Silinenler";
            this.cbPasifler.UseVisualStyleBackColor = true;
            // 
            // lblYardim
            // 
            this.lblYardim.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblYardim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblYardim.ForeColor = System.Drawing.Color.DimGray;
            this.lblYardim.Location = new System.Drawing.Point(214, 131);
            this.lblYardim.Name = "lblYardim";
            this.lblYardim.Size = new System.Drawing.Size(172, 55);
            this.lblYardim.TabIndex = 49;
            this.lblYardim.Text = "Varsayılan araç seçimini boş bırakmak için farenin sağ tuşuna basabilirsiniz.";
            this.lblYardim.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblYardim.Visible = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(59, 54);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(11, 13);
            this.label22.TabIndex = 48;
            this.label22.Text = "*";
            this.label22.MouseLeave += new System.EventHandler(this.label22_MouseLeave);
            this.label22.MouseHover += new System.EventHandler(this.label22_MouseHover);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(59, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = "*";
            this.label7.MouseLeave += new System.EventHandler(this.label22_MouseLeave);
            this.label7.MouseHover += new System.EventHandler(this.label22_MouseHover);
            // 
            // frmAT2rotalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 386);
            this.Controls.Add(this.lblYardim);
            this.Controls.Add(this.cbPasifler);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.lbRotalar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(415, 310);
            this.Name = "frmAT2rotalar";
            this.Text = "Rotalar";
            this.Load += new System.EventHandler(this.frmAT2rotalar_Load);
            this.SizeChanged += new System.EventHandler(this.frmAT2rotalar_SizeChanged);
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

        private System.Windows.Forms.ListBox lbRotalar;
        private System.Windows.Forms.Button btnYenile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbEkleAraclar;
        private System.Windows.Forms.TextBox txtEkleRota;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbEkleBolgeler;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbGuncelleBolgeler;
        private System.Windows.Forms.ComboBox cmbGuncelleAraclar;
        private System.Windows.Forms.TextBox txtGuncelleRota;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtSil;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbPasifler;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblYardim;
    }
}