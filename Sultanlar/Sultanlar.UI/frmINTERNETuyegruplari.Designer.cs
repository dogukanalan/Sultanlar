namespace Sultanlar.UI
{
    partial class frmINTERNETuyegruplari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmINTERNETuyegruplari));
            this.lbUyeGruplari = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbOzelKodYetkileri = new System.Windows.Forms.GroupBox();
            this.btnOzelKodYetkiKaldir = new System.Windows.Forms.Button();
            this.btnOzelKodYetkiEkle = new System.Windows.Forms.Button();
            this.lbOzelKodlarYetkili = new System.Windows.Forms.ListBox();
            this.lbOzelKodlar = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnGrupKodYetkiKaldir = new System.Windows.Forms.Button();
            this.btnGrupKodYetkiEkle = new System.Windows.Forms.Button();
            this.lbGrupKodlarYetkili = new System.Windows.Forms.ListBox();
            this.lbGrupKodlar = new System.Windows.Forms.ListBox();
            this.gbFiyatTipiYetkileri = new System.Windows.Forms.GroupBox();
            this.btnFiyatTipiYetkiKaldir = new System.Windows.Forms.Button();
            this.btnFiyatTipiYetkiEkle = new System.Windows.Forms.Button();
            this.lbFiyatTipleriYetkili = new System.Windows.Forms.ListBox();
            this.lbFiyatTipleri = new System.Windows.Forms.ListBox();
            this.cbTaksitPlani = new System.Windows.Forms.CheckBox();
            this.lbMusteriler = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGrupEkle = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gbOzelKodYetkileri.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbFiyatTipiYetkileri.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbUyeGruplari
            // 
            this.lbUyeGruplari.FormattingEnabled = true;
            this.lbUyeGruplari.Location = new System.Drawing.Point(12, 25);
            this.lbUyeGruplari.Name = "lbUyeGruplari";
            this.lbUyeGruplari.Size = new System.Drawing.Size(208, 238);
            this.lbUyeGruplari.TabIndex = 0;
            this.lbUyeGruplari.SelectedIndexChanged += new System.EventHandler(this.lbUyeGruplari_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gbOzelKodYetkileri);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.gbFiyatTipiYetkileri);
            this.groupBox1.Controls.Add(this.cbTaksitPlani);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(226, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(619, 350);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ayrıntılar";
            // 
            // gbOzelKodYetkileri
            // 
            this.gbOzelKodYetkileri.Controls.Add(this.btnOzelKodYetkiKaldir);
            this.gbOzelKodYetkileri.Controls.Add(this.btnOzelKodYetkiEkle);
            this.gbOzelKodYetkileri.Controls.Add(this.lbOzelKodlarYetkili);
            this.gbOzelKodYetkileri.Controls.Add(this.lbOzelKodlar);
            this.gbOzelKodYetkileri.Location = new System.Drawing.Point(6, 185);
            this.gbOzelKodYetkileri.Name = "gbOzelKodYetkileri";
            this.gbOzelKodYetkileri.Size = new System.Drawing.Size(300, 160);
            this.gbOzelKodYetkileri.TabIndex = 5;
            this.gbOzelKodYetkileri.TabStop = false;
            this.gbOzelKodYetkileri.Text = "Özel Kod Yetkisi";
            // 
            // btnOzelKodYetkiKaldir
            // 
            this.btnOzelKodYetkiKaldir.Location = new System.Drawing.Point(132, 85);
            this.btnOzelKodYetkiKaldir.Name = "btnOzelKodYetkiKaldir";
            this.btnOzelKodYetkiKaldir.Size = new System.Drawing.Size(36, 23);
            this.btnOzelKodYetkiKaldir.TabIndex = 1;
            this.btnOzelKodYetkiKaldir.Text = "<<";
            this.btnOzelKodYetkiKaldir.UseVisualStyleBackColor = true;
            this.btnOzelKodYetkiKaldir.Click += new System.EventHandler(this.btnOzelKodYetkiKaldir_Click);
            // 
            // btnOzelKodYetkiEkle
            // 
            this.btnOzelKodYetkiEkle.Location = new System.Drawing.Point(132, 56);
            this.btnOzelKodYetkiEkle.Name = "btnOzelKodYetkiEkle";
            this.btnOzelKodYetkiEkle.Size = new System.Drawing.Size(36, 23);
            this.btnOzelKodYetkiEkle.TabIndex = 1;
            this.btnOzelKodYetkiEkle.Text = ">>";
            this.btnOzelKodYetkiEkle.UseVisualStyleBackColor = true;
            this.btnOzelKodYetkiEkle.Click += new System.EventHandler(this.btnOzelKodYetkiEkle_Click);
            // 
            // lbOzelKodlarYetkili
            // 
            this.lbOzelKodlarYetkili.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbOzelKodlarYetkili.FormattingEnabled = true;
            this.lbOzelKodlarYetkili.ItemHeight = 12;
            this.lbOzelKodlarYetkili.Location = new System.Drawing.Point(174, 19);
            this.lbOzelKodlarYetkili.Name = "lbOzelKodlarYetkili";
            this.lbOzelKodlarYetkili.Size = new System.Drawing.Size(120, 136);
            this.lbOzelKodlarYetkili.Sorted = true;
            this.lbOzelKodlarYetkili.TabIndex = 0;
            this.lbOzelKodlarYetkili.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbOzelKodlarYetkili_MouseDoubleClick);
            // 
            // lbOzelKodlar
            // 
            this.lbOzelKodlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbOzelKodlar.FormattingEnabled = true;
            this.lbOzelKodlar.ItemHeight = 12;
            this.lbOzelKodlar.Location = new System.Drawing.Point(6, 19);
            this.lbOzelKodlar.Name = "lbOzelKodlar";
            this.lbOzelKodlar.Size = new System.Drawing.Size(120, 136);
            this.lbOzelKodlar.Sorted = true;
            this.lbOzelKodlar.TabIndex = 0;
            this.lbOzelKodlar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbOzelKodlar_MouseDoubleClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnGrupKodYetkiKaldir);
            this.groupBox3.Controls.Add(this.btnGrupKodYetkiEkle);
            this.groupBox3.Controls.Add(this.lbGrupKodlarYetkili);
            this.groupBox3.Controls.Add(this.lbGrupKodlar);
            this.groupBox3.Location = new System.Drawing.Point(312, 185);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(300, 160);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Grup Kod Yetkisi";
            // 
            // btnGrupKodYetkiKaldir
            // 
            this.btnGrupKodYetkiKaldir.Location = new System.Drawing.Point(132, 85);
            this.btnGrupKodYetkiKaldir.Name = "btnGrupKodYetkiKaldir";
            this.btnGrupKodYetkiKaldir.Size = new System.Drawing.Size(36, 23);
            this.btnGrupKodYetkiKaldir.TabIndex = 1;
            this.btnGrupKodYetkiKaldir.Text = "<<";
            this.btnGrupKodYetkiKaldir.UseVisualStyleBackColor = true;
            this.btnGrupKodYetkiKaldir.Click += new System.EventHandler(this.btnGrupKodYetkiKaldir_Click);
            // 
            // btnGrupKodYetkiEkle
            // 
            this.btnGrupKodYetkiEkle.Location = new System.Drawing.Point(132, 56);
            this.btnGrupKodYetkiEkle.Name = "btnGrupKodYetkiEkle";
            this.btnGrupKodYetkiEkle.Size = new System.Drawing.Size(36, 23);
            this.btnGrupKodYetkiEkle.TabIndex = 1;
            this.btnGrupKodYetkiEkle.Text = ">>";
            this.btnGrupKodYetkiEkle.UseVisualStyleBackColor = true;
            this.btnGrupKodYetkiEkle.Click += new System.EventHandler(this.btnGrupKodYetkiEkle_Click);
            // 
            // lbGrupKodlarYetkili
            // 
            this.lbGrupKodlarYetkili.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbGrupKodlarYetkili.FormattingEnabled = true;
            this.lbGrupKodlarYetkili.ItemHeight = 12;
            this.lbGrupKodlarYetkili.Location = new System.Drawing.Point(174, 19);
            this.lbGrupKodlarYetkili.Name = "lbGrupKodlarYetkili";
            this.lbGrupKodlarYetkili.Size = new System.Drawing.Size(120, 136);
            this.lbGrupKodlarYetkili.Sorted = true;
            this.lbGrupKodlarYetkili.TabIndex = 0;
            this.lbGrupKodlarYetkili.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbGrupKodlarYetkili_MouseDoubleClick);
            // 
            // lbGrupKodlar
            // 
            this.lbGrupKodlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbGrupKodlar.FormattingEnabled = true;
            this.lbGrupKodlar.ItemHeight = 12;
            this.lbGrupKodlar.Location = new System.Drawing.Point(6, 19);
            this.lbGrupKodlar.Name = "lbGrupKodlar";
            this.lbGrupKodlar.Size = new System.Drawing.Size(120, 136);
            this.lbGrupKodlar.Sorted = true;
            this.lbGrupKodlar.TabIndex = 0;
            this.lbGrupKodlar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbGrupKodlar_MouseDoubleClick);
            // 
            // gbFiyatTipiYetkileri
            // 
            this.gbFiyatTipiYetkileri.Controls.Add(this.btnFiyatTipiYetkiKaldir);
            this.gbFiyatTipiYetkileri.Controls.Add(this.btnFiyatTipiYetkiEkle);
            this.gbFiyatTipiYetkileri.Controls.Add(this.lbFiyatTipleriYetkili);
            this.gbFiyatTipiYetkileri.Controls.Add(this.lbFiyatTipleri);
            this.gbFiyatTipiYetkileri.Location = new System.Drawing.Point(6, 19);
            this.gbFiyatTipiYetkileri.Name = "gbFiyatTipiYetkileri";
            this.gbFiyatTipiYetkileri.Size = new System.Drawing.Size(300, 160);
            this.gbFiyatTipiYetkileri.TabIndex = 5;
            this.gbFiyatTipiYetkileri.TabStop = false;
            this.gbFiyatTipiYetkileri.Text = "Fiyat Tipi Yetkileri";
            // 
            // btnFiyatTipiYetkiKaldir
            // 
            this.btnFiyatTipiYetkiKaldir.Location = new System.Drawing.Point(132, 85);
            this.btnFiyatTipiYetkiKaldir.Name = "btnFiyatTipiYetkiKaldir";
            this.btnFiyatTipiYetkiKaldir.Size = new System.Drawing.Size(36, 23);
            this.btnFiyatTipiYetkiKaldir.TabIndex = 1;
            this.btnFiyatTipiYetkiKaldir.Text = "<<";
            this.btnFiyatTipiYetkiKaldir.UseVisualStyleBackColor = true;
            this.btnFiyatTipiYetkiKaldir.Click += new System.EventHandler(this.btnFiyatTipiYetkiKaldir_Click);
            // 
            // btnFiyatTipiYetkiEkle
            // 
            this.btnFiyatTipiYetkiEkle.Location = new System.Drawing.Point(132, 56);
            this.btnFiyatTipiYetkiEkle.Name = "btnFiyatTipiYetkiEkle";
            this.btnFiyatTipiYetkiEkle.Size = new System.Drawing.Size(36, 23);
            this.btnFiyatTipiYetkiEkle.TabIndex = 1;
            this.btnFiyatTipiYetkiEkle.Text = ">>";
            this.btnFiyatTipiYetkiEkle.UseVisualStyleBackColor = true;
            this.btnFiyatTipiYetkiEkle.Click += new System.EventHandler(this.btnFiyatTipiYetkiEkle_Click);
            // 
            // lbFiyatTipleriYetkili
            // 
            this.lbFiyatTipleriYetkili.FormattingEnabled = true;
            this.lbFiyatTipleriYetkili.Location = new System.Drawing.Point(174, 19);
            this.lbFiyatTipleriYetkili.Name = "lbFiyatTipleriYetkili";
            this.lbFiyatTipleriYetkili.Size = new System.Drawing.Size(120, 134);
            this.lbFiyatTipleriYetkili.Sorted = true;
            this.lbFiyatTipleriYetkili.TabIndex = 0;
            this.lbFiyatTipleriYetkili.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbFiyatTipleriYetkili_MouseDoubleClick);
            // 
            // lbFiyatTipleri
            // 
            this.lbFiyatTipleri.FormattingEnabled = true;
            this.lbFiyatTipleri.Location = new System.Drawing.Point(6, 19);
            this.lbFiyatTipleri.Name = "lbFiyatTipleri";
            this.lbFiyatTipleri.Size = new System.Drawing.Size(120, 134);
            this.lbFiyatTipleri.Sorted = true;
            this.lbFiyatTipleri.TabIndex = 0;
            this.lbFiyatTipleri.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbFiyatTipleri_MouseDoubleClick);
            // 
            // cbTaksitPlani
            // 
            this.cbTaksitPlani.AutoSize = true;
            this.cbTaksitPlani.Location = new System.Drawing.Point(328, 28);
            this.cbTaksitPlani.Name = "cbTaksitPlani";
            this.cbTaksitPlani.Size = new System.Drawing.Size(115, 17);
            this.cbTaksitPlani.TabIndex = 2;
            this.cbTaksitPlani.Text = "Taksit Planı Yetkisi";
            this.cbTaksitPlani.UseVisualStyleBackColor = true;
            this.cbTaksitPlani.CheckedChanged += new System.EventHandler(this.cbTakistPlani_CheckedChanged);
            // 
            // lbMusteriler
            // 
            this.lbMusteriler.FormattingEnabled = true;
            this.lbMusteriler.Location = new System.Drawing.Point(12, 288);
            this.lbMusteriler.Name = "lbMusteriler";
            this.lbMusteriler.Size = new System.Drawing.Size(208, 95);
            this.lbMusteriler.Sorted = true;
            this.lbMusteriler.TabIndex = 0;
            this.lbMusteriler.SelectedIndexChanged += new System.EventHandler(this.lbMusteriler_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seçilen Gruptaki Üyeler:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Üye Grupları:";
            // 
            // btnGrupEkle
            // 
            this.btnGrupEkle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGrupEkle.Location = new System.Drawing.Point(711, 3);
            this.btnGrupEkle.Name = "btnGrupEkle";
            this.btnGrupEkle.Size = new System.Drawing.Size(133, 32);
            this.btnGrupEkle.TabIndex = 2;
            this.btnGrupEkle.Text = "Yeni Grup Oluştur";
            this.btnGrupEkle.UseVisualStyleBackColor = true;
            this.btnGrupEkle.Click += new System.EventHandler(this.btnGrupEkle_Click);
            // 
            // frmINTERNETuyegruplari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 401);
            this.Controls.Add(this.btnGrupEkle);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbUyeGruplari);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbMusteriler);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(819, 429);
            this.Name = "frmINTERNETuyegruplari";
            this.Text = "Üye Grupları";
            this.Load += new System.EventHandler(this.frmINTERNETuyegruplari_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbOzelKodYetkileri.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.gbFiyatTipiYetkileri.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbUyeGruplari;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbMusteriler;
        private System.Windows.Forms.CheckBox cbTaksitPlani;
        private System.Windows.Forms.GroupBox gbOzelKodYetkileri;
        private System.Windows.Forms.Button btnOzelKodYetkiKaldir;
        private System.Windows.Forms.Button btnOzelKodYetkiEkle;
        private System.Windows.Forms.ListBox lbOzelKodlarYetkili;
        private System.Windows.Forms.ListBox lbOzelKodlar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnGrupKodYetkiKaldir;
        private System.Windows.Forms.Button btnGrupKodYetkiEkle;
        private System.Windows.Forms.ListBox lbGrupKodlarYetkili;
        private System.Windows.Forms.ListBox lbGrupKodlar;
        private System.Windows.Forms.GroupBox gbFiyatTipiYetkileri;
        private System.Windows.Forms.Button btnFiyatTipiYetkiKaldir;
        private System.Windows.Forms.Button btnFiyatTipiYetkiEkle;
        private System.Windows.Forms.ListBox lbFiyatTipleriYetkili;
        private System.Windows.Forms.ListBox lbFiyatTipleri;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGrupEkle;
    }
}