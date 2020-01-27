namespace Sultanlar.UI
{
    partial class frmAT2soforlermuavinler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAT2soforlermuavinler));
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.txtSil = new System.Windows.Forms.TextBox();
            this.txtGuncelleAd = new System.Windows.Forms.TextBox();
            this.txtEkleAd = new System.Windows.Forms.TextBox();
            this.lbSoforlerMuavinler = new System.Windows.Forms.ListBox();
            this.rbEkleSofor = new System.Windows.Forms.RadioButton();
            this.rbEkleMuavin = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtEkleSoyad = new System.Windows.Forms.TextBox();
            this.txtEkleTelefon = new System.Windows.Forms.TextBox();
            this.txtGuncelleTelefon = new System.Windows.Forms.TextBox();
            this.txtGuncelleSoyad = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbGuncelleMuavin = new System.Windows.Forms.RadioButton();
            this.rbGuncelleSofor = new System.Windows.Forms.RadioButton();
            this.btnYenile = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.rbSofor = new System.Windows.Forms.RadioButton();
            this.rbMuavin = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEkleFirmalar = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbGuncelleFirmalar = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtAramaAd = new System.Windows.Forms.TextBox();
            this.txtAramaSoyad = new System.Windows.Forms.TextBox();
            this.cbPasifler = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSil
            // 
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.ForeColor = System.Drawing.Color.Black;
            this.btnSil.Location = new System.Drawing.Point(114, 18);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(101, 23);
            this.btnSil.TabIndex = 14;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncelle.ForeColor = System.Drawing.Color.Black;
            this.btnGuncelle.Location = new System.Drawing.Point(114, 93);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(100, 23);
            this.btnGuncelle.TabIndex = 12;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEkle.ForeColor = System.Drawing.Color.Black;
            this.btnEkle.Location = new System.Drawing.Point(114, 92);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(100, 23);
            this.btnEkle.TabIndex = 6;
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
            this.txtSil.Size = new System.Drawing.Size(99, 20);
            this.txtSil.TabIndex = 13;
            // 
            // txtGuncelleAd
            // 
            this.txtGuncelleAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGuncelleAd.ForeColor = System.Drawing.Color.Gray;
            this.txtGuncelleAd.Location = new System.Drawing.Point(5, 69);
            this.txtGuncelleAd.Name = "txtGuncelleAd";
            this.txtGuncelleAd.Size = new System.Drawing.Size(100, 20);
            this.txtGuncelleAd.TabIndex = 9;
            this.txtGuncelleAd.Text = "İsim";
            this.txtGuncelleAd.Enter += new System.EventHandler(this.txtEkleAd_Enter);
            this.txtGuncelleAd.Leave += new System.EventHandler(this.txtEkleAd_Leave);
            // 
            // txtEkleAd
            // 
            this.txtEkleAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEkleAd.ForeColor = System.Drawing.Color.Gray;
            this.txtEkleAd.Location = new System.Drawing.Point(5, 68);
            this.txtEkleAd.Name = "txtEkleAd";
            this.txtEkleAd.Size = new System.Drawing.Size(100, 20);
            this.txtEkleAd.TabIndex = 3;
            this.txtEkleAd.Text = "İsim";
            this.txtEkleAd.Enter += new System.EventHandler(this.txtEkleAd_Enter);
            this.txtEkleAd.Leave += new System.EventHandler(this.txtEkleAd_Leave);
            // 
            // lbSoforlerMuavinler
            // 
            this.lbSoforlerMuavinler.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbSoforlerMuavinler.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbSoforlerMuavinler.FormattingEnabled = true;
            this.lbSoforlerMuavinler.ItemHeight = 14;
            this.lbSoforlerMuavinler.Location = new System.Drawing.Point(0, 23);
            this.lbSoforlerMuavinler.Name = "lbSoforlerMuavinler";
            this.lbSoforlerMuavinler.Size = new System.Drawing.Size(169, 312);
            this.lbSoforlerMuavinler.TabIndex = 0;
            this.lbSoforlerMuavinler.SelectedIndexChanged += new System.EventHandler(this.lbSoforlerMuavinler_SelectedIndexChanged);
            // 
            // rbEkleSofor
            // 
            this.rbEkleSofor.AutoSize = true;
            this.rbEkleSofor.Checked = true;
            this.rbEkleSofor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbEkleSofor.ForeColor = System.Drawing.Color.Black;
            this.rbEkleSofor.Location = new System.Drawing.Point(37, -2);
            this.rbEkleSofor.Name = "rbEkleSofor";
            this.rbEkleSofor.Size = new System.Drawing.Size(50, 17);
            this.rbEkleSofor.TabIndex = 1;
            this.rbEkleSofor.TabStop = true;
            this.rbEkleSofor.Text = "Şoför";
            this.rbEkleSofor.UseVisualStyleBackColor = true;
            // 
            // rbEkleMuavin
            // 
            this.rbEkleMuavin.AutoSize = true;
            this.rbEkleMuavin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbEkleMuavin.ForeColor = System.Drawing.Color.Black;
            this.rbEkleMuavin.Location = new System.Drawing.Point(117, -2);
            this.rbEkleMuavin.Name = "rbEkleMuavin";
            this.rbEkleMuavin.Size = new System.Drawing.Size(60, 17);
            this.rbEkleMuavin.TabIndex = 2;
            this.rbEkleMuavin.Text = "Muavin";
            this.rbEkleMuavin.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbEkleMuavin);
            this.panel1.Controls.Add(this.rbEkleSofor);
            this.panel1.Location = new System.Drawing.Point(5, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(202, 14);
            this.panel1.TabIndex = 45;
            // 
            // txtEkleSoyad
            // 
            this.txtEkleSoyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEkleSoyad.ForeColor = System.Drawing.Color.Gray;
            this.txtEkleSoyad.Location = new System.Drawing.Point(114, 68);
            this.txtEkleSoyad.Name = "txtEkleSoyad";
            this.txtEkleSoyad.Size = new System.Drawing.Size(100, 20);
            this.txtEkleSoyad.TabIndex = 4;
            this.txtEkleSoyad.Text = "Soyisim";
            this.txtEkleSoyad.Enter += new System.EventHandler(this.txtEkleAd_Enter);
            this.txtEkleSoyad.Leave += new System.EventHandler(this.txtEkleAd_Leave);
            // 
            // txtEkleTelefon
            // 
            this.txtEkleTelefon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEkleTelefon.ForeColor = System.Drawing.Color.Gray;
            this.txtEkleTelefon.Location = new System.Drawing.Point(5, 94);
            this.txtEkleTelefon.MaxLength = 11;
            this.txtEkleTelefon.Name = "txtEkleTelefon";
            this.txtEkleTelefon.Size = new System.Drawing.Size(100, 20);
            this.txtEkleTelefon.TabIndex = 5;
            this.txtEkleTelefon.Text = "Telefon";
            this.txtEkleTelefon.Enter += new System.EventHandler(this.txtEkleAd_Enter);
            this.txtEkleTelefon.Leave += new System.EventHandler(this.txtEkleAd_Leave);
            // 
            // txtGuncelleTelefon
            // 
            this.txtGuncelleTelefon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGuncelleTelefon.ForeColor = System.Drawing.Color.Gray;
            this.txtGuncelleTelefon.Location = new System.Drawing.Point(5, 95);
            this.txtGuncelleTelefon.MaxLength = 11;
            this.txtGuncelleTelefon.Name = "txtGuncelleTelefon";
            this.txtGuncelleTelefon.Size = new System.Drawing.Size(100, 20);
            this.txtGuncelleTelefon.TabIndex = 11;
            this.txtGuncelleTelefon.Text = "Telefon";
            this.txtGuncelleTelefon.Enter += new System.EventHandler(this.txtEkleAd_Enter);
            this.txtGuncelleTelefon.Leave += new System.EventHandler(this.txtEkleAd_Leave);
            // 
            // txtGuncelleSoyad
            // 
            this.txtGuncelleSoyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGuncelleSoyad.ForeColor = System.Drawing.Color.Gray;
            this.txtGuncelleSoyad.Location = new System.Drawing.Point(114, 69);
            this.txtGuncelleSoyad.Name = "txtGuncelleSoyad";
            this.txtGuncelleSoyad.Size = new System.Drawing.Size(100, 20);
            this.txtGuncelleSoyad.TabIndex = 10;
            this.txtGuncelleSoyad.Text = "Soyisim";
            this.txtGuncelleSoyad.Enter += new System.EventHandler(this.txtEkleAd_Enter);
            this.txtGuncelleSoyad.Leave += new System.EventHandler(this.txtEkleAd_Leave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbGuncelleMuavin);
            this.panel2.Controls.Add(this.rbGuncelleSofor);
            this.panel2.Location = new System.Drawing.Point(5, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(202, 14);
            this.panel2.TabIndex = 45;
            // 
            // rbGuncelleMuavin
            // 
            this.rbGuncelleMuavin.AutoSize = true;
            this.rbGuncelleMuavin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbGuncelleMuavin.ForeColor = System.Drawing.Color.Black;
            this.rbGuncelleMuavin.Location = new System.Drawing.Point(117, -2);
            this.rbGuncelleMuavin.Name = "rbGuncelleMuavin";
            this.rbGuncelleMuavin.Size = new System.Drawing.Size(60, 17);
            this.rbGuncelleMuavin.TabIndex = 8;
            this.rbGuncelleMuavin.Text = "Muavin";
            this.rbGuncelleMuavin.UseVisualStyleBackColor = true;
            // 
            // rbGuncelleSofor
            // 
            this.rbGuncelleSofor.AutoSize = true;
            this.rbGuncelleSofor.Checked = true;
            this.rbGuncelleSofor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbGuncelleSofor.ForeColor = System.Drawing.Color.Black;
            this.rbGuncelleSofor.Location = new System.Drawing.Point(37, -2);
            this.rbGuncelleSofor.Name = "rbGuncelleSofor";
            this.rbGuncelleSofor.Size = new System.Drawing.Size(50, 17);
            this.rbGuncelleSofor.TabIndex = 7;
            this.rbGuncelleSofor.TabStop = true;
            this.rbGuncelleSofor.Text = "Şoför";
            this.rbGuncelleSofor.UseVisualStyleBackColor = true;
            // 
            // btnYenile
            // 
            this.btnYenile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnYenile.Image = global::Sultanlar.UI.Properties.Resources.Refresh_icon;
            this.btnYenile.Location = new System.Drawing.Point(375, 0);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(24, 24);
            this.btnYenile.TabIndex = 49;
            this.btnYenile.UseVisualStyleBackColor = true;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(399, 23);
            this.label4.TabIndex = 50;
            // 
            // rbSofor
            // 
            this.rbSofor.AutoSize = true;
            this.rbSofor.Checked = true;
            this.rbSofor.Location = new System.Drawing.Point(79, 3);
            this.rbSofor.Name = "rbSofor";
            this.rbSofor.Size = new System.Drawing.Size(61, 17);
            this.rbSofor.TabIndex = 1;
            this.rbSofor.TabStop = true;
            this.rbSofor.Text = "Şoförler";
            this.rbSofor.UseVisualStyleBackColor = true;
            this.rbSofor.CheckedChanged += new System.EventHandler(this.rbSofor_CheckedChanged);
            // 
            // rbMuavin
            // 
            this.rbMuavin.AutoSize = true;
            this.rbMuavin.Location = new System.Drawing.Point(139, 3);
            this.rbMuavin.Name = "rbMuavin";
            this.rbMuavin.Size = new System.Drawing.Size(71, 17);
            this.rbMuavin.TabIndex = 2;
            this.rbMuavin.Text = "Muavinler";
            this.rbMuavin.UseVisualStyleBackColor = true;
            this.rbMuavin.CheckedChanged += new System.EventHandler(this.rbSofor_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbEkleFirmalar);
            this.groupBox1.Controls.Add(this.txtEkleAd);
            this.groupBox1.Controls.Add(this.txtEkleSoyad);
            this.groupBox1.Controls.Add(this.txtEkleTelefon);
            this.groupBox1.Controls.Add(this.btnEkle);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox1.Location = new System.Drawing.Point(175, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 120);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ekleme";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 47;
            this.label2.Text = "Firma:";
            // 
            // cmbEkleFirmalar
            // 
            this.cmbEkleFirmalar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEkleFirmalar.FormattingEnabled = true;
            this.cmbEkleFirmalar.Location = new System.Drawing.Point(54, 39);
            this.cmbEkleFirmalar.Name = "cmbEkleFirmalar";
            this.cmbEkleFirmalar.Size = new System.Drawing.Size(161, 23);
            this.cmbEkleFirmalar.TabIndex = 46;
            this.cmbEkleFirmalar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbEkleFirmalar_MouseDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.txtGuncelleAd);
            this.groupBox2.Controls.Add(this.cmbGuncelleFirmalar);
            this.groupBox2.Controls.Add(this.txtGuncelleSoyad);
            this.groupBox2.Controls.Add(this.txtGuncelleTelefon);
            this.groupBox2.Controls.Add(this.btnGuncelle);
            this.groupBox2.Enabled = false;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox2.Location = new System.Drawing.Point(175, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(218, 121);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Güncelleme";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(6, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 15);
            this.label5.TabIndex = 47;
            this.label5.Text = "Firma:";
            // 
            // cmbGuncelleFirmalar
            // 
            this.cmbGuncelleFirmalar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGuncelleFirmalar.FormattingEnabled = true;
            this.cmbGuncelleFirmalar.Location = new System.Drawing.Point(54, 40);
            this.cmbGuncelleFirmalar.Name = "cmbGuncelleFirmalar";
            this.cmbGuncelleFirmalar.Size = new System.Drawing.Size(161, 23);
            this.cmbGuncelleFirmalar.TabIndex = 46;
            this.cmbGuncelleFirmalar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbEkleFirmalar_MouseDown);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtSil);
            this.groupBox3.Controls.Add(this.btnSil);
            this.groupBox3.Enabled = false;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox3.Location = new System.Drawing.Point(175, 284);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(218, 46);
            this.groupBox3.TabIndex = 53;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Silme";
            // 
            // txtAramaAd
            // 
            this.txtAramaAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAramaAd.ForeColor = System.Drawing.Color.Gray;
            this.txtAramaAd.Location = new System.Drawing.Point(218, 2);
            this.txtAramaAd.Name = "txtAramaAd";
            this.txtAramaAd.Size = new System.Drawing.Size(72, 20);
            this.txtAramaAd.TabIndex = 3;
            this.txtAramaAd.Text = "İsim";
            this.txtAramaAd.Enter += new System.EventHandler(this.txtEkleAd_Enter);
            this.txtAramaAd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAramaAd_KeyDown);
            this.txtAramaAd.Leave += new System.EventHandler(this.txtEkleAd_Leave);
            // 
            // txtAramaSoyad
            // 
            this.txtAramaSoyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAramaSoyad.ForeColor = System.Drawing.Color.Gray;
            this.txtAramaSoyad.Location = new System.Drawing.Point(292, 2);
            this.txtAramaSoyad.Name = "txtAramaSoyad";
            this.txtAramaSoyad.Size = new System.Drawing.Size(72, 20);
            this.txtAramaSoyad.TabIndex = 4;
            this.txtAramaSoyad.Text = "Soyisim";
            this.txtAramaSoyad.Enter += new System.EventHandler(this.txtEkleAd_Enter);
            this.txtAramaSoyad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAramaAd_KeyDown);
            this.txtAramaSoyad.Leave += new System.EventHandler(this.txtEkleAd_Leave);
            // 
            // cbPasifler
            // 
            this.cbPasifler.AutoSize = true;
            this.cbPasifler.Location = new System.Drawing.Point(5, 4);
            this.cbPasifler.Name = "cbPasifler";
            this.cbPasifler.Size = new System.Drawing.Size(68, 17);
            this.cbPasifler.TabIndex = 54;
            this.cbPasifler.Text = "Silinenler";
            this.cbPasifler.UseVisualStyleBackColor = true;
            // 
            // frmAT2soforlermuavinler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 335);
            this.Controls.Add(this.cbPasifler);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtAramaAd);
            this.Controls.Add(this.txtAramaSoyad);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rbMuavin);
            this.Controls.Add(this.rbSofor);
            this.Controls.Add(this.lbSoforlerMuavinler);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(415, 373);
            this.Name = "frmAT2soforlermuavinler";
            this.Text = "Şoför ve Muavinler";
            this.Load += new System.EventHandler(this.frmAT2soforlermuavinler_Load);
            this.SizeChanged += new System.EventHandler(this.frmAT2soforlermuavinler_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.TextBox txtEkleAd;
        private System.Windows.Forms.ListBox lbSoforlerMuavinler;
        private System.Windows.Forms.RadioButton rbEkleSofor;
        private System.Windows.Forms.RadioButton rbEkleMuavin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtEkleSoyad;
        private System.Windows.Forms.TextBox txtEkleTelefon;
        private System.Windows.Forms.TextBox txtGuncelleTelefon;
        private System.Windows.Forms.TextBox txtGuncelleSoyad;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbGuncelleMuavin;
        private System.Windows.Forms.RadioButton rbGuncelleSofor;
        private System.Windows.Forms.Button btnYenile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbSofor;
        private System.Windows.Forms.RadioButton rbMuavin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtAramaAd;
        private System.Windows.Forms.TextBox txtAramaSoyad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbEkleFirmalar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbGuncelleFirmalar;
        private System.Windows.Forms.CheckBox cbPasifler;
    }
}