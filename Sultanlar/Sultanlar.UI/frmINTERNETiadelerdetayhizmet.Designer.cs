namespace Sultanlar.UI
{
    partial class frmINTERNETiadelerdetayhizmet
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmINTERNETiadelerdetayhizmet));
            this.cbAnaSube = new System.Windows.Forms.CheckBox();
            this.lblKalan = new System.Windows.Forms.Label();
            this.lblSecilen = new System.Windows.Forms.Label();
            this.lblSecilecek = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSecimiSifirla = new System.Windows.Forms.Button();
            this.btnAsagidan = new System.Windows.Forms.Button();
            this.btnYukaridan = new System.Windows.Forms.Button();
            this.btnOnayla = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblHizmetTop = new System.Windows.Forms.Label();
            this.lblTedarikci = new System.Windows.Forms.Label();
            this.pnlBilgiler = new System.Windows.Forms.Panel();
            this.lblSatisIadeOran = new System.Windows.Forms.Label();
            this.lblHizmet = new System.Windows.Forms.Label();
            this.lblHizmetGenel = new System.Windows.Forms.Label();
            this.lblYuzde = new System.Windows.Forms.Label();
            this.lblGenelSatis = new System.Windows.Forms.Label();
            this.lblUrunSatis = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.clSTRREF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clGMREF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSMREF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clFATTAR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clFATNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clHIZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTIGACIK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTEXT1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNETKDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTUTIADE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTUTFARK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clOZELKOD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlBilgiler.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbAnaSube
            // 
            this.cbAnaSube.AutoSize = true;
            this.cbAnaSube.Location = new System.Drawing.Point(12, 10);
            this.cbAnaSube.Name = "cbAnaSube";
            this.cbAnaSube.Size = new System.Drawing.Size(104, 17);
            this.cbAnaSube.TabIndex = 27;
            this.cbAnaSube.Text = "Tüm Şubelerden";
            this.cbAnaSube.UseVisualStyleBackColor = true;
            this.cbAnaSube.Visible = false;
            this.cbAnaSube.CheckedChanged += new System.EventHandler(this.cbAnaSube_CheckedChanged);
            // 
            // lblKalan
            // 
            this.lblKalan.AutoSize = true;
            this.lblKalan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblKalan.Location = new System.Drawing.Point(353, 443);
            this.lblKalan.Name = "lblKalan";
            this.lblKalan.Size = new System.Drawing.Size(13, 13);
            this.lblKalan.TabIndex = 23;
            this.lblKalan.Text = "0";
            this.lblKalan.TextChanged += new System.EventHandler(this.lblKalan_TextChanged);
            // 
            // lblSecilen
            // 
            this.lblSecilen.AutoSize = true;
            this.lblSecilen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSecilen.Location = new System.Drawing.Point(229, 443);
            this.lblSecilen.Name = "lblSecilen";
            this.lblSecilen.Size = new System.Drawing.Size(13, 13);
            this.lblSecilen.TabIndex = 22;
            this.lblSecilen.Text = "0";
            this.lblSecilen.TextChanged += new System.EventHandler(this.lblSecilen_TextChanged);
            // 
            // lblSecilecek
            // 
            this.lblSecilecek.AutoSize = true;
            this.lblSecilecek.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSecilecek.Location = new System.Drawing.Point(100, 443);
            this.lblSecilecek.Name = "lblSecilecek";
            this.lblSecilecek.Size = new System.Drawing.Size(13, 13);
            this.lblSecilecek.TabIndex = 21;
            this.lblSecilecek.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(285, 443);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Kalan Tutar:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(153, 443);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Seçilen Tutar:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 443);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Seçilecek Tutar:";
            // 
            // btnSecimiSifirla
            // 
            this.btnSecimiSifirla.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSecimiSifirla.Location = new System.Drawing.Point(815, 5);
            this.btnSecimiSifirla.Name = "btnSecimiSifirla";
            this.btnSecimiSifirla.Size = new System.Drawing.Size(46, 22);
            this.btnSecimiSifirla.TabIndex = 17;
            this.btnSecimiSifirla.Text = "Sıfırla";
            this.btnSecimiSifirla.UseVisualStyleBackColor = true;
            this.btnSecimiSifirla.Click += new System.EventHandler(this.btnSecimiSifirla_Click);
            // 
            // btnAsagidan
            // 
            this.btnAsagidan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAsagidan.Location = new System.Drawing.Point(433, 5);
            this.btnAsagidan.Name = "btnAsagidan";
            this.btnAsagidan.Size = new System.Drawing.Size(76, 22);
            this.btnAsagidan.TabIndex = 16;
            this.btnAsagidan.Text = "İlk Tarihten";
            this.btnAsagidan.UseVisualStyleBackColor = true;
            this.btnAsagidan.Click += new System.EventHandler(this.btnAsagidan_Click);
            // 
            // btnYukaridan
            // 
            this.btnYukaridan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnYukaridan.Location = new System.Drawing.Point(353, 5);
            this.btnYukaridan.Name = "btnYukaridan";
            this.btnYukaridan.Size = new System.Drawing.Size(76, 22);
            this.btnYukaridan.TabIndex = 19;
            this.btnYukaridan.Text = "Son Tarihten";
            this.btnYukaridan.UseVisualStyleBackColor = true;
            this.btnYukaridan.Click += new System.EventHandler(this.btnYukaridan_Click);
            // 
            // btnOnayla
            // 
            this.btnOnayla.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOnayla.Location = new System.Drawing.Point(765, 437);
            this.btnOnayla.Name = "btnOnayla";
            this.btnOnayla.Size = new System.Drawing.Size(115, 24);
            this.btnOnayla.TabIndex = 18;
            this.btnOnayla.Text = "Onayla";
            this.btnOnayla.UseVisualStyleBackColor = true;
            this.btnOnayla.Click += new System.EventHandler(this.btnOnayla_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 50;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clSTRREF,
            this.clGMREF,
            this.clSMREF,
            this.clFATTAR,
            this.clFATNO,
            this.clHIZ,
            this.clTIGACIK,
            this.clTEXT1,
            this.clNETKDV,
            this.clTUTIADE,
            this.clTUTFARK,
            this.clCheck,
            this.clOZELKOD});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 30);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(884, 373);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Location = new System.Drawing.Point(0, 403);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(884, 61);
            this.label3.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Otomatik Tarihe Göre Seçim:";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(884, 30);
            this.label1.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.Location = new System.Drawing.Point(490, 443);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 13);
            this.label14.TabIndex = 24;
            this.label14.Text = "Hizmet Toplam:";
            // 
            // lblHizmetTop
            // 
            this.lblHizmetTop.AutoSize = true;
            this.lblHizmetTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblHizmetTop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblHizmetTop.Location = new System.Drawing.Point(590, 443);
            this.lblHizmetTop.Name = "lblHizmetTop";
            this.lblHizmetTop.Size = new System.Drawing.Size(14, 13);
            this.lblHizmetTop.TabIndex = 21;
            this.lblHizmetTop.Text = "0";
            // 
            // lblTedarikci
            // 
            this.lblTedarikci.AutoSize = true;
            this.lblTedarikci.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTedarikci.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTedarikci.Location = new System.Drawing.Point(12, 10);
            this.lblTedarikci.Name = "lblTedarikci";
            this.lblTedarikci.Size = new System.Drawing.Size(60, 13);
            this.lblTedarikci.TabIndex = 28;
            this.lblTedarikci.Text = "Tedarikçi";
            // 
            // pnlBilgiler
            // 
            this.pnlBilgiler.Controls.Add(this.lblSatisIadeOran);
            this.pnlBilgiler.Controls.Add(this.lblHizmet);
            this.pnlBilgiler.Controls.Add(this.lblHizmetGenel);
            this.pnlBilgiler.Controls.Add(this.lblYuzde);
            this.pnlBilgiler.Controls.Add(this.lblGenelSatis);
            this.pnlBilgiler.Controls.Add(this.lblUrunSatis);
            this.pnlBilgiler.Controls.Add(this.label8);
            this.pnlBilgiler.Controls.Add(this.label15);
            this.pnlBilgiler.Controls.Add(this.label13);
            this.pnlBilgiler.Controls.Add(this.label11);
            this.pnlBilgiler.Controls.Add(this.label9);
            this.pnlBilgiler.Controls.Add(this.label7);
            this.pnlBilgiler.Location = new System.Drawing.Point(8, 411);
            this.pnlBilgiler.Name = "pnlBilgiler";
            this.pnlBilgiler.Size = new System.Drawing.Size(818, 26);
            this.pnlBilgiler.TabIndex = 29;
            // 
            // lblSatisIadeOran
            // 
            this.lblSatisIadeOran.AutoSize = true;
            this.lblSatisIadeOran.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSatisIadeOran.Location = new System.Drawing.Point(740, 7);
            this.lblSatisIadeOran.Name = "lblSatisIadeOran";
            this.lblSatisIadeOran.Size = new System.Drawing.Size(13, 13);
            this.lblSatisIadeOran.TabIndex = 28;
            this.lblSatisIadeOran.Text = "0";
            // 
            // lblHizmet
            // 
            this.lblHizmet.AutoSize = true;
            this.lblHizmet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblHizmet.Location = new System.Drawing.Point(581, 7);
            this.lblHizmet.Name = "lblHizmet";
            this.lblHizmet.Size = new System.Drawing.Size(13, 13);
            this.lblHizmet.TabIndex = 29;
            this.lblHizmet.Text = "0";
            // 
            // lblHizmetGenel
            // 
            this.lblHizmetGenel.AutoSize = true;
            this.lblHizmetGenel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblHizmetGenel.Location = new System.Drawing.Point(475, 7);
            this.lblHizmetGenel.Name = "lblHizmetGenel";
            this.lblHizmetGenel.Size = new System.Drawing.Size(13, 13);
            this.lblHizmetGenel.TabIndex = 30;
            this.lblHizmetGenel.Text = "0";
            // 
            // lblYuzde
            // 
            this.lblYuzde.AutoSize = true;
            this.lblYuzde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblYuzde.Location = new System.Drawing.Point(338, 7);
            this.lblYuzde.Name = "lblYuzde";
            this.lblYuzde.Size = new System.Drawing.Size(13, 13);
            this.lblYuzde.TabIndex = 25;
            this.lblYuzde.Text = "0";
            // 
            // lblGenelSatis
            // 
            this.lblGenelSatis.AutoSize = true;
            this.lblGenelSatis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblGenelSatis.Location = new System.Drawing.Point(92, 7);
            this.lblGenelSatis.Name = "lblGenelSatis";
            this.lblGenelSatis.Size = new System.Drawing.Size(13, 13);
            this.lblGenelSatis.TabIndex = 26;
            this.lblGenelSatis.Text = "0";
            // 
            // lblUrunSatis
            // 
            this.lblUrunSatis.AutoSize = true;
            this.lblUrunSatis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblUrunSatis.Location = new System.Drawing.Point(233, 7);
            this.lblUrunSatis.Name = "lblUrunSatis";
            this.lblUrunSatis.Size = new System.Drawing.Size(13, 13);
            this.lblUrunSatis.TabIndex = 27;
            this.lblUrunSatis.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(641, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Satış / İade Oranı:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(539, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 13);
            this.label15.TabIndex = 35;
            this.label15.Text = "Hizmet:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(402, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "Hizmet Genel:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(298, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Yüzde:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Genel Satış Top.:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(149, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Ürün Satış Top.:";
            // 
            // clSTRREF
            // 
            this.clSTRREF.DataPropertyName = "STRREF";
            this.clSTRREF.HeaderText = "STRREF";
            this.clSTRREF.Name = "clSTRREF";
            this.clSTRREF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clSTRREF.Visible = false;
            // 
            // clGMREF
            // 
            this.clGMREF.DataPropertyName = "GMREF";
            this.clGMREF.HeaderText = "GMREF";
            this.clGMREF.Name = "clGMREF";
            this.clGMREF.ReadOnly = true;
            this.clGMREF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clGMREF.Visible = false;
            // 
            // clSMREF
            // 
            this.clSMREF.DataPropertyName = "SMREF";
            this.clSMREF.HeaderText = "SMREF";
            this.clSMREF.Name = "clSMREF";
            this.clSMREF.ReadOnly = true;
            this.clSMREF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clSMREF.Visible = false;
            // 
            // clFATTAR
            // 
            this.clFATTAR.DataPropertyName = "FAT TAR";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clFATTAR.DefaultCellStyle = dataGridViewCellStyle2;
            this.clFATTAR.HeaderText = "Fatura Tarihi";
            this.clFATTAR.Name = "clFATTAR";
            this.clFATTAR.ReadOnly = true;
            this.clFATTAR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clFATTAR.Width = 80;
            // 
            // clFATNO
            // 
            this.clFATNO.DataPropertyName = "FAT NO";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clFATNO.DefaultCellStyle = dataGridViewCellStyle3;
            this.clFATNO.HeaderText = "Fatura No";
            this.clFATNO.Name = "clFATNO";
            this.clFATNO.ReadOnly = true;
            this.clFATNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clFATNO.Width = 70;
            // 
            // clHIZ
            // 
            this.clHIZ.DataPropertyName = "HIZ";
            this.clHIZ.HeaderText = "Hizmet";
            this.clHIZ.Name = "clHIZ";
            this.clHIZ.Width = 125;
            // 
            // clTIGACIK
            // 
            this.clTIGACIK.DataPropertyName = "TIG ACIK";
            this.clTIGACIK.HeaderText = "Tic.İş.Grubu";
            this.clTIGACIK.Name = "clTIGACIK";
            this.clTIGACIK.Width = 125;
            // 
            // clTEXT1
            // 
            this.clTEXT1.DataPropertyName = "TEXT-1";
            this.clTEXT1.HeaderText = "Açıklama";
            this.clTEXT1.Name = "clTEXT1";
            this.clTEXT1.Width = 146;
            // 
            // clNETKDV
            // 
            this.clNETKDV.DataPropertyName = "NET+KDV";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C3";
            this.clNETKDV.DefaultCellStyle = dataGridViewCellStyle4;
            this.clNETKDV.HeaderText = "Tutar";
            this.clNETKDV.Name = "clNETKDV";
            this.clNETKDV.ReadOnly = true;
            this.clNETKDV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clNETKDV.Width = 90;
            // 
            // clTUTIADE
            // 
            this.clTUTIADE.DataPropertyName = "TUTIADE";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C3";
            this.clTUTIADE.DefaultCellStyle = dataGridViewCellStyle5;
            this.clTUTIADE.HeaderText = "İade Ed. Tut.";
            this.clTUTIADE.Name = "clTUTIADE";
            this.clTUTIADE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clTUTIADE.Width = 90;
            // 
            // clTUTFARK
            // 
            this.clTUTFARK.DataPropertyName = "TUTFARK";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "C3";
            this.clTUTFARK.DefaultCellStyle = dataGridViewCellStyle6;
            this.clTUTFARK.HeaderText = "Kalan Tutar";
            this.clTUTFARK.Name = "clTUTFARK";
            this.clTUTFARK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clTUTFARK.Width = 90;
            // 
            // clCheck
            // 
            this.clCheck.HeaderText = "Seçim";
            this.clCheck.Name = "clCheck";
            this.clCheck.Width = 50;
            // 
            // clOZELKOD
            // 
            this.clOZELKOD.DataPropertyName = "OZEL KOD";
            this.clOZELKOD.HeaderText = "OZELKOD";
            this.clOZELKOD.Name = "clOZELKOD";
            this.clOZELKOD.Visible = false;
            // 
            // frmINTERNETiadelerdetayhizmet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 464);
            this.Controls.Add(this.pnlBilgiler);
            this.Controls.Add(this.lblTedarikci);
            this.Controls.Add(this.cbAnaSube);
            this.Controls.Add(this.lblKalan);
            this.Controls.Add(this.lblSecilen);
            this.Controls.Add(this.lblHizmetTop);
            this.Controls.Add(this.lblSecilecek);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSecimiSifirla);
            this.Controls.Add(this.btnAsagidan);
            this.Controls.Add(this.btnYukaridan);
            this.Controls.Add(this.btnOnayla);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(900, 502);
            this.MinimumSize = new System.Drawing.Size(900, 502);
            this.Name = "frmINTERNETiadelerdetayhizmet";
            this.Text = "İade Hizmet";
            this.Load += new System.EventHandler(this.frmINTERNETiadelerdetayhizmet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlBilgiler.ResumeLayout(false);
            this.pnlBilgiler.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbAnaSube;
        private System.Windows.Forms.Label lblKalan;
        private System.Windows.Forms.Label lblSecilen;
        private System.Windows.Forms.Label lblSecilecek;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSecimiSifirla;
        private System.Windows.Forms.Button btnAsagidan;
        private System.Windows.Forms.Button btnYukaridan;
        private System.Windows.Forms.Button btnOnayla;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblHizmetTop;
        private System.Windows.Forms.Label lblTedarikci;
        private System.Windows.Forms.Panel pnlBilgiler;
        private System.Windows.Forms.Label lblSatisIadeOran;
        private System.Windows.Forms.Label lblHizmet;
        private System.Windows.Forms.Label lblHizmetGenel;
        private System.Windows.Forms.Label lblYuzde;
        private System.Windows.Forms.Label lblGenelSatis;
        private System.Windows.Forms.Label lblUrunSatis;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSTRREF;
        private System.Windows.Forms.DataGridViewTextBoxColumn clGMREF;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSMREF;
        private System.Windows.Forms.DataGridViewTextBoxColumn clFATTAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn clFATNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn clHIZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTIGACIK;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTEXT1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNETKDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTUTIADE;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTUTFARK;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn clOZELKOD;

    }
}