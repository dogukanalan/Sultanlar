namespace Sultanlar.UI
{
    partial class frmAT2araclar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAT2araclar));
            this.lbAraclar = new System.Windows.Forms.ListBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.txtEklePlaka = new System.Windows.Forms.TextBox();
            this.cmbEkleAracTipi = new System.Windows.Forms.ComboBox();
            this.cmbEkleLojistikFirmasi = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEkleTonaj = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEkleHacim = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGuncellePlaka = new System.Windows.Forms.TextBox();
            this.txtGuncelleTonaj = new System.Windows.Forms.TextBox();
            this.txtGuncelleHacim = new System.Windows.Forms.TextBox();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbGuncelleAracTipi = new System.Windows.Forms.ComboBox();
            this.cmbGuncelleLojistikFirmasi = new System.Windows.Forms.ComboBox();
            this.btnSil = new System.Windows.Forms.Button();
            this.txtSil = new System.Windows.Forms.TextBox();
            this.btnYenile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEkleSorumlu = new System.Windows.Forms.TextBox();
            this.txtEkleYil = new System.Windows.Forms.TextBox();
            this.cmbEkleMuavin = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.cmbEkleSofor = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtGuncelleSorumlu = new System.Windows.Forms.TextBox();
            this.txtGuncelleYil = new System.Windows.Forms.TextBox();
            this.cmbGuncelleMuavin = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.cmbGuncelleSofor = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAracBedelleri = new System.Windows.Forms.Button();
            this.cmbAramaAracTipi = new System.Windows.Forms.ComboBox();
            this.cmbAramaLojistikFirmasi = new System.Windows.Forms.ComboBox();
            this.txtAramaPlaka = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cbPasifler = new System.Windows.Forms.CheckBox();
            this.lblYardim = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbAraclar
            // 
            this.lbAraclar.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbAraclar.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbAraclar.FormattingEnabled = true;
            this.lbAraclar.ItemHeight = 14;
            this.lbAraclar.Location = new System.Drawing.Point(0, 23);
            this.lbAraclar.Name = "lbAraclar";
            this.lbAraclar.Size = new System.Drawing.Size(169, 374);
            this.lbAraclar.TabIndex = 0;
            this.lbAraclar.SelectedIndexChanged += new System.EventHandler(this.lbAraclar_SelectedIndexChanged);
            this.lbAraclar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbAraclar_MouseDoubleClick);
            // 
            // btnEkle
            // 
            this.btnEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEkle.ForeColor = System.Drawing.Color.Black;
            this.btnEkle.Location = new System.Drawing.Point(139, 256);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 23);
            this.btnEkle.TabIndex = 6;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // txtEklePlaka
            // 
            this.txtEklePlaka.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEklePlaka.ForeColor = System.Drawing.Color.Black;
            this.txtEklePlaka.Location = new System.Drawing.Point(86, 152);
            this.txtEklePlaka.Name = "txtEklePlaka";
            this.txtEklePlaka.Size = new System.Drawing.Size(128, 20);
            this.txtEklePlaka.TabIndex = 3;
            // 
            // cmbEkleAracTipi
            // 
            this.cmbEkleAracTipi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEkleAracTipi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbEkleAracTipi.ForeColor = System.Drawing.Color.Black;
            this.cmbEkleAracTipi.FormattingEnabled = true;
            this.cmbEkleAracTipi.Location = new System.Drawing.Point(86, 20);
            this.cmbEkleAracTipi.Name = "cmbEkleAracTipi";
            this.cmbEkleAracTipi.Size = new System.Drawing.Size(128, 20);
            this.cmbEkleAracTipi.TabIndex = 1;
            // 
            // cmbEkleLojistikFirmasi
            // 
            this.cmbEkleLojistikFirmasi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEkleLojistikFirmasi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbEkleLojistikFirmasi.ForeColor = System.Drawing.Color.Black;
            this.cmbEkleLojistikFirmasi.FormattingEnabled = true;
            this.cmbEkleLojistikFirmasi.Location = new System.Drawing.Point(86, 47);
            this.cmbEkleLojistikFirmasi.Name = "cmbEkleLojistikFirmasi";
            this.cmbEkleLojistikFirmasi.Size = new System.Drawing.Size(128, 20);
            this.cmbEkleLojistikFirmasi.TabIndex = 2;
            this.cmbEkleLojistikFirmasi.SelectedIndexChanged += new System.EventHandler(this.cmbEkleLojistikFirmasi_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(2, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Araç Tipi:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(2, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Lojistik Firması:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(2, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Plaka:";
            // 
            // txtEkleTonaj
            // 
            this.txtEkleTonaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEkleTonaj.ForeColor = System.Drawing.Color.Black;
            this.txtEkleTonaj.Location = new System.Drawing.Point(86, 204);
            this.txtEkleTonaj.Name = "txtEkleTonaj";
            this.txtEkleTonaj.Size = new System.Drawing.Size(128, 20);
            this.txtEkleTonaj.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(2, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Tonaj (kg):";
            // 
            // txtEkleHacim
            // 
            this.txtEkleHacim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEkleHacim.ForeColor = System.Drawing.Color.Black;
            this.txtEkleHacim.Location = new System.Drawing.Point(86, 230);
            this.txtEkleHacim.Name = "txtEkleHacim";
            this.txtEkleHacim.Size = new System.Drawing.Size(128, 20);
            this.txtEkleHacim.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(2, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Hacim (dm3):";
            // 
            // txtGuncellePlaka
            // 
            this.txtGuncellePlaka.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGuncellePlaka.ForeColor = System.Drawing.Color.Black;
            this.txtGuncellePlaka.Location = new System.Drawing.Point(86, 152);
            this.txtGuncellePlaka.Name = "txtGuncellePlaka";
            this.txtGuncellePlaka.Size = new System.Drawing.Size(128, 20);
            this.txtGuncellePlaka.TabIndex = 9;
            // 
            // txtGuncelleTonaj
            // 
            this.txtGuncelleTonaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGuncelleTonaj.ForeColor = System.Drawing.Color.Black;
            this.txtGuncelleTonaj.Location = new System.Drawing.Point(86, 204);
            this.txtGuncelleTonaj.Name = "txtGuncelleTonaj";
            this.txtGuncelleTonaj.Size = new System.Drawing.Size(128, 20);
            this.txtGuncelleTonaj.TabIndex = 10;
            // 
            // txtGuncelleHacim
            // 
            this.txtGuncelleHacim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGuncelleHacim.ForeColor = System.Drawing.Color.Black;
            this.txtGuncelleHacim.Location = new System.Drawing.Point(86, 230);
            this.txtGuncelleHacim.Name = "txtGuncelleHacim";
            this.txtGuncelleHacim.Size = new System.Drawing.Size(128, 20);
            this.txtGuncelleHacim.TabIndex = 11;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncelle.ForeColor = System.Drawing.Color.Black;
            this.btnGuncelle.Location = new System.Drawing.Point(139, 256);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(75, 23);
            this.btnGuncelle.TabIndex = 12;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(2, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Araç Tipi:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(2, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "Lojistik Firması:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(2, 181);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 38;
            this.label10.Text = "Model Yılı:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(2, 207);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 38;
            this.label11.Text = "Tonaj (kg):";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(2, 233);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 13);
            this.label12.TabIndex = 38;
            this.label12.Text = "Hacim (dm3):";
            // 
            // cmbGuncelleAracTipi
            // 
            this.cmbGuncelleAracTipi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGuncelleAracTipi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbGuncelleAracTipi.ForeColor = System.Drawing.Color.Black;
            this.cmbGuncelleAracTipi.FormattingEnabled = true;
            this.cmbGuncelleAracTipi.Location = new System.Drawing.Point(86, 20);
            this.cmbGuncelleAracTipi.Name = "cmbGuncelleAracTipi";
            this.cmbGuncelleAracTipi.Size = new System.Drawing.Size(128, 20);
            this.cmbGuncelleAracTipi.TabIndex = 7;
            // 
            // cmbGuncelleLojistikFirmasi
            // 
            this.cmbGuncelleLojistikFirmasi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGuncelleLojistikFirmasi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbGuncelleLojistikFirmasi.ForeColor = System.Drawing.Color.Black;
            this.cmbGuncelleLojistikFirmasi.FormattingEnabled = true;
            this.cmbGuncelleLojistikFirmasi.Location = new System.Drawing.Point(86, 47);
            this.cmbGuncelleLojistikFirmasi.Name = "cmbGuncelleLojistikFirmasi";
            this.cmbGuncelleLojistikFirmasi.Size = new System.Drawing.Size(128, 20);
            this.cmbGuncelleLojistikFirmasi.TabIndex = 8;
            this.cmbGuncelleLojistikFirmasi.SelectedIndexChanged += new System.EventHandler(this.cmbGuncelleLojistikFirmasi_SelectedIndexChanged);
            // 
            // btnSil
            // 
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.ForeColor = System.Drawing.Color.Black;
            this.btnSil.Location = new System.Drawing.Point(361, 18);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(75, 23);
            this.btnSil.TabIndex = 14;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // txtSil
            // 
            this.txtSil.Enabled = false;
            this.txtSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSil.ForeColor = System.Drawing.Color.Black;
            this.txtSil.Location = new System.Drawing.Point(86, 20);
            this.txtSil.Name = "txtSil";
            this.txtSil.ReadOnly = true;
            this.txtSil.Size = new System.Drawing.Size(269, 20);
            this.txtSil.TabIndex = 13;
            // 
            // btnYenile
            // 
            this.btnYenile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnYenile.Image = global::Sultanlar.UI.Properties.Resources.Refresh_icon;
            this.btnYenile.Location = new System.Drawing.Point(602, 0);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(24, 24);
            this.btnYenile.TabIndex = 45;
            this.btnYenile.UseVisualStyleBackColor = true;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbEkleAracTipi);
            this.groupBox1.Controls.Add(this.txtEkleSorumlu);
            this.groupBox1.Controls.Add(this.txtEklePlaka);
            this.groupBox1.Controls.Add(this.txtEkleYil);
            this.groupBox1.Controls.Add(this.txtEkleTonaj);
            this.groupBox1.Controls.Add(this.txtEkleHacim);
            this.groupBox1.Controls.Add(this.btnEkle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbEkleMuavin);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.cmbEkleSofor);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.cmbEkleLojistikFirmasi);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox1.Location = new System.Drawing.Point(175, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 285);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ekleme";
            // 
            // txtEkleSorumlu
            // 
            this.txtEkleSorumlu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEkleSorumlu.ForeColor = System.Drawing.Color.Black;
            this.txtEkleSorumlu.Location = new System.Drawing.Point(86, 126);
            this.txtEkleSorumlu.Name = "txtEkleSorumlu";
            this.txtEkleSorumlu.ReadOnly = true;
            this.txtEkleSorumlu.Size = new System.Drawing.Size(128, 20);
            this.txtEkleSorumlu.TabIndex = 3;
            // 
            // txtEkleYil
            // 
            this.txtEkleYil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEkleYil.ForeColor = System.Drawing.Color.Black;
            this.txtEkleYil.Location = new System.Drawing.Point(86, 178);
            this.txtEkleYil.Name = "txtEkleYil";
            this.txtEkleYil.Size = new System.Drawing.Size(128, 20);
            this.txtEkleYil.TabIndex = 4;
            // 
            // cmbEkleMuavin
            // 
            this.cmbEkleMuavin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEkleMuavin.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbEkleMuavin.ForeColor = System.Drawing.Color.Black;
            this.cmbEkleMuavin.FormattingEnabled = true;
            this.cmbEkleMuavin.Location = new System.Drawing.Point(86, 99);
            this.cmbEkleMuavin.Name = "cmbEkleMuavin";
            this.cmbEkleMuavin.Size = new System.Drawing.Size(128, 20);
            this.cmbEkleMuavin.TabIndex = 2;
            this.cmbEkleMuavin.SelectedIndexChanged += new System.EventHandler(this.cmbEkleLojistikFirmasi_SelectedIndexChanged);
            this.cmbEkleMuavin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbGuncelleSofor_MouseDown);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label25.ForeColor = System.Drawing.Color.Red;
            this.label25.Location = new System.Drawing.Point(69, 102);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(11, 13);
            this.label25.TabIndex = 38;
            this.label25.Text = "*";
            this.label25.MouseLeave += new System.EventHandler(this.label22_MouseLeave);
            this.label25.MouseHover += new System.EventHandler(this.label22_MouseHover);
            // 
            // cmbEkleSofor
            // 
            this.cmbEkleSofor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEkleSofor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbEkleSofor.ForeColor = System.Drawing.Color.Black;
            this.cmbEkleSofor.FormattingEnabled = true;
            this.cmbEkleSofor.Location = new System.Drawing.Point(86, 73);
            this.cmbEkleSofor.Name = "cmbEkleSofor";
            this.cmbEkleSofor.Size = new System.Drawing.Size(128, 20);
            this.cmbEkleSofor.TabIndex = 2;
            this.cmbEkleSofor.SelectedIndexChanged += new System.EventHandler(this.cmbEkleLojistikFirmasi_SelectedIndexChanged);
            this.cmbEkleSofor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbGuncelleSofor_MouseDown);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(2, 102);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(45, 13);
            this.label24.TabIndex = 38;
            this.label24.Text = "Muavin:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(69, 76);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(11, 13);
            this.label22.TabIndex = 38;
            this.label22.Text = "*";
            this.label22.MouseLeave += new System.EventHandler(this.label22_MouseLeave);
            this.label22.MouseHover += new System.EventHandler(this.label22_MouseHover);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(2, 76);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(35, 13);
            this.label20.TabIndex = 38;
            this.label20.Text = "Şoför:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(2, 129);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 13);
            this.label15.TabIndex = 38;
            this.label15.Text = "Sorumlu:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(2, 181);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 38;
            this.label13.Text = "Model Yılı:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbGuncelleAracTipi);
            this.groupBox2.Controls.Add(this.txtGuncelleSorumlu);
            this.groupBox2.Controls.Add(this.txtGuncelleYil);
            this.groupBox2.Controls.Add(this.txtGuncellePlaka);
            this.groupBox2.Controls.Add(this.txtGuncelleTonaj);
            this.groupBox2.Controls.Add(this.txtGuncelleHacim);
            this.groupBox2.Controls.Add(this.btnGuncelle);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cmbGuncelleMuavin);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.cmbGuncelleSofor);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.cmbGuncelleLojistikFirmasi);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Enabled = false;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox2.Location = new System.Drawing.Point(399, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(218, 285);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Güncelleme";
            // 
            // txtGuncelleSorumlu
            // 
            this.txtGuncelleSorumlu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGuncelleSorumlu.ForeColor = System.Drawing.Color.Black;
            this.txtGuncelleSorumlu.Location = new System.Drawing.Point(86, 126);
            this.txtGuncelleSorumlu.Name = "txtGuncelleSorumlu";
            this.txtGuncelleSorumlu.ReadOnly = true;
            this.txtGuncelleSorumlu.Size = new System.Drawing.Size(128, 20);
            this.txtGuncelleSorumlu.TabIndex = 3;
            // 
            // txtGuncelleYil
            // 
            this.txtGuncelleYil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGuncelleYil.ForeColor = System.Drawing.Color.Black;
            this.txtGuncelleYil.Location = new System.Drawing.Point(86, 178);
            this.txtGuncelleYil.Name = "txtGuncelleYil";
            this.txtGuncelleYil.Size = new System.Drawing.Size(128, 20);
            this.txtGuncelleYil.TabIndex = 9;
            // 
            // cmbGuncelleMuavin
            // 
            this.cmbGuncelleMuavin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGuncelleMuavin.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbGuncelleMuavin.ForeColor = System.Drawing.Color.Black;
            this.cmbGuncelleMuavin.FormattingEnabled = true;
            this.cmbGuncelleMuavin.Location = new System.Drawing.Point(86, 99);
            this.cmbGuncelleMuavin.Name = "cmbGuncelleMuavin";
            this.cmbGuncelleMuavin.Size = new System.Drawing.Size(128, 20);
            this.cmbGuncelleMuavin.TabIndex = 2;
            this.cmbGuncelleMuavin.SelectedIndexChanged += new System.EventHandler(this.cmbEkleLojistikFirmasi_SelectedIndexChanged);
            this.cmbGuncelleMuavin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbGuncelleSofor_MouseDown);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label27.ForeColor = System.Drawing.Color.Red;
            this.label27.Location = new System.Drawing.Point(69, 101);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(11, 13);
            this.label27.TabIndex = 38;
            this.label27.Text = "*";
            this.label27.MouseLeave += new System.EventHandler(this.label22_MouseLeave);
            this.label27.MouseHover += new System.EventHandler(this.label22_MouseHover);
            // 
            // cmbGuncelleSofor
            // 
            this.cmbGuncelleSofor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGuncelleSofor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbGuncelleSofor.ForeColor = System.Drawing.Color.Black;
            this.cmbGuncelleSofor.FormattingEnabled = true;
            this.cmbGuncelleSofor.Location = new System.Drawing.Point(86, 73);
            this.cmbGuncelleSofor.Name = "cmbGuncelleSofor";
            this.cmbGuncelleSofor.Size = new System.Drawing.Size(128, 20);
            this.cmbGuncelleSofor.TabIndex = 2;
            this.cmbGuncelleSofor.SelectedIndexChanged += new System.EventHandler(this.cmbEkleLojistikFirmasi_SelectedIndexChanged);
            this.cmbGuncelleSofor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbGuncelleSofor_MouseDown);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(2, 102);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(45, 13);
            this.label26.TabIndex = 38;
            this.label26.Text = "Muavin:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label23.ForeColor = System.Drawing.Color.Red;
            this.label23.Location = new System.Drawing.Point(69, 75);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(11, 13);
            this.label23.TabIndex = 38;
            this.label23.Text = "*";
            this.label23.MouseLeave += new System.EventHandler(this.label22_MouseLeave);
            this.label23.MouseHover += new System.EventHandler(this.label22_MouseHover);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(2, 76);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 13);
            this.label21.TabIndex = 38;
            this.label21.Text = "Şoför:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(2, 155);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 13);
            this.label14.TabIndex = 38;
            this.label14.Text = "Plaka:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(2, 129);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 13);
            this.label16.TabIndex = 38;
            this.label16.Text = "Sorumlu:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSil);
            this.groupBox3.Controls.Add(this.txtSil);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Enabled = false;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox3.Location = new System.Drawing.Point(175, 343);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(442, 48);
            this.groupBox3.TabIndex = 48;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Silme";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Plaka:";
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(626, 23);
            this.label7.TabIndex = 51;
            // 
            // btnAracBedelleri
            // 
            this.btnAracBedelleri.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAracBedelleri.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAracBedelleri.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAracBedelleri.ForeColor = System.Drawing.Color.Black;
            this.btnAracBedelleri.Location = new System.Drawing.Point(169, 23);
            this.btnAracBedelleri.Name = "btnAracBedelleri";
            this.btnAracBedelleri.Size = new System.Drawing.Size(457, 23);
            this.btnAracBedelleri.TabIndex = 6;
            this.btnAracBedelleri.Text = "Araç Kira Bedelleri";
            this.btnAracBedelleri.UseVisualStyleBackColor = true;
            this.btnAracBedelleri.Click += new System.EventHandler(this.btnAracBedelleri_Click);
            // 
            // cmbAramaAracTipi
            // 
            this.cmbAramaAracTipi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAramaAracTipi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbAramaAracTipi.ForeColor = System.Drawing.Color.Black;
            this.cmbAramaAracTipi.FormattingEnabled = true;
            this.cmbAramaAracTipi.Location = new System.Drawing.Point(134, 2);
            this.cmbAramaAracTipi.Name = "cmbAramaAracTipi";
            this.cmbAramaAracTipi.Size = new System.Drawing.Size(120, 20);
            this.cmbAramaAracTipi.TabIndex = 1;
            this.cmbAramaAracTipi.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbAramaAracTipi_MouseDown);
            // 
            // cmbAramaLojistikFirmasi
            // 
            this.cmbAramaLojistikFirmasi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAramaLojistikFirmasi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbAramaLojistikFirmasi.ForeColor = System.Drawing.Color.Black;
            this.cmbAramaLojistikFirmasi.FormattingEnabled = true;
            this.cmbAramaLojistikFirmasi.Location = new System.Drawing.Point(314, 2);
            this.cmbAramaLojistikFirmasi.Name = "cmbAramaLojistikFirmasi";
            this.cmbAramaLojistikFirmasi.Size = new System.Drawing.Size(120, 20);
            this.cmbAramaLojistikFirmasi.TabIndex = 2;
            this.cmbAramaLojistikFirmasi.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbAramaAracTipi_MouseDown);
            // 
            // txtAramaPlaka
            // 
            this.txtAramaPlaka.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAramaPlaka.ForeColor = System.Drawing.Color.Black;
            this.txtAramaPlaka.Location = new System.Drawing.Point(497, 2);
            this.txtAramaPlaka.Name = "txtAramaPlaka";
            this.txtAramaPlaka.Size = new System.Drawing.Size(80, 18);
            this.txtAramaPlaka.TabIndex = 3;
            this.txtAramaPlaka.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAramaPlaka_KeyDown);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(103, 4);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(25, 13);
            this.label18.TabIndex = 38;
            this.label18.Text = "Tip:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(273, 4);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 13);
            this.label17.TabIndex = 38;
            this.label17.Text = "Firma:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(454, 4);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(37, 13);
            this.label19.TabIndex = 38;
            this.label19.Text = "Plaka:";
            // 
            // cbPasifler
            // 
            this.cbPasifler.AutoSize = true;
            this.cbPasifler.Location = new System.Drawing.Point(11, 4);
            this.cbPasifler.Name = "cbPasifler";
            this.cbPasifler.Size = new System.Drawing.Size(68, 17);
            this.cbPasifler.TabIndex = 52;
            this.cbPasifler.Text = "Silinenler";
            this.cbPasifler.UseVisualStyleBackColor = true;
            // 
            // lblYardim
            // 
            this.lblYardim.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblYardim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblYardim.ForeColor = System.Drawing.Color.DimGray;
            this.lblYardim.Location = new System.Drawing.Point(273, 122);
            this.lblYardim.Name = "lblYardim";
            this.lblYardim.Size = new System.Drawing.Size(186, 53);
            this.lblYardim.TabIndex = 38;
            this.lblYardim.Text = "Şoför veya muavin seçimini boş bırakmak için farenin sağ tuşuna basabilirsiniz.";
            this.lblYardim.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblYardim.Visible = false;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label28.ForeColor = System.Drawing.Color.Red;
            this.label28.Location = new System.Drawing.Point(260, 4);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(11, 13);
            this.label28.TabIndex = 38;
            this.label28.Text = "*";
            this.label28.MouseLeave += new System.EventHandler(this.label28_MouseLeave);
            this.label28.MouseHover += new System.EventHandler(this.label28_MouseHover);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label29.ForeColor = System.Drawing.Color.Red;
            this.label29.Location = new System.Drawing.Point(440, 4);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(11, 13);
            this.label29.TabIndex = 38;
            this.label29.Text = "*";
            this.label29.MouseLeave += new System.EventHandler(this.label28_MouseLeave);
            this.label29.MouseHover += new System.EventHandler(this.label28_MouseHover);
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label30.ForeColor = System.Drawing.Color.DimGray;
            this.label30.Location = new System.Drawing.Point(276, 1);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(158, 47);
            this.label30.TabIndex = 38;
            this.label30.Text = "Tip veya firma seçimini boş bırakmak için farenin sağ tuşuna basabilirsiniz.";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label30.Visible = false;
            // 
            // frmAT2araclar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 397);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.lblYardim);
            this.Controls.Add(this.cbPasifler);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cmbAramaAracTipi);
            this.Controls.Add(this.txtAramaPlaka);
            this.Controls.Add(this.btnAracBedelleri);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbAraclar);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cmbAramaLojistikFirmasi);
            this.Controls.Add(this.label7);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(642, 435);
            this.Name = "frmAT2araclar";
            this.Text = "Araçlar";
            this.Load += new System.EventHandler(this.frmAT2araclar_Load);
            this.SizeChanged += new System.EventHandler(this.frmAT2araclar_SizeChanged);
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

        private System.Windows.Forms.ListBox lbAraclar;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.TextBox txtEklePlaka;
        private System.Windows.Forms.ComboBox cmbEkleAracTipi;
        private System.Windows.Forms.ComboBox cmbEkleLojistikFirmasi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEkleTonaj;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEkleHacim;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGuncellePlaka;
        private System.Windows.Forms.TextBox txtGuncelleTonaj;
        private System.Windows.Forms.TextBox txtGuncelleHacim;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbGuncelleAracTipi;
        private System.Windows.Forms.ComboBox cmbGuncelleLojistikFirmasi;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.TextBox txtSil;
        private System.Windows.Forms.Button btnYenile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAracBedelleri;
        private System.Windows.Forms.TextBox txtEkleYil;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtGuncelleYil;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtEkleSorumlu;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtGuncelleSorumlu;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbAramaAracTipi;
        private System.Windows.Forms.ComboBox cmbAramaLojistikFirmasi;
        private System.Windows.Forms.TextBox txtAramaPlaka;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbEkleSofor;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbGuncelleSofor;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox cbPasifler;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblYardim;
        private System.Windows.Forms.ComboBox cmbEkleMuavin;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cmbGuncelleMuavin;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
    }
}