namespace Sultanlar.UI
{
    partial class frmGorevler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGorevler));
            this.lbGorevler = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbAyrintiListe = new System.Windows.Forms.CheckBox();
            this.cbAyrintiWeb = new System.Windows.Forms.CheckBox();
            this.btnGorevDuzelt = new System.Windows.Forms.Button();
            this.btnGorevSil = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDepartmanlar = new System.Windows.Forms.ComboBox();
            this.txtGorev = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbEkleWeb = new System.Windows.Forms.CheckBox();
            this.cbEkleListe = new System.Windows.Forms.CheckBox();
            this.txtGorevEkleGorev = new System.Windows.Forms.TextBox();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.btnGorevEkle = new System.Windows.Forms.Button();
            this.cmbGorevEkleDepartman = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbGorevler
            // 
            this.lbGorevler.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbGorevler.FormattingEnabled = true;
            this.lbGorevler.Location = new System.Drawing.Point(0, 0);
            this.lbGorevler.Name = "lbGorevler";
            this.lbGorevler.Size = new System.Drawing.Size(208, 288);
            this.lbGorevler.TabIndex = 0;
            this.lbGorevler.SelectedIndexChanged += new System.EventHandler(this.lbGorevler_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbAyrintiListe);
            this.groupBox1.Controls.Add(this.cbAyrintiWeb);
            this.groupBox1.Controls.Add(this.btnGorevDuzelt);
            this.groupBox1.Controls.Add(this.btnGorevSil);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbDepartmanlar);
            this.groupBox1.Controls.Add(this.txtGorev);
            this.groupBox1.Location = new System.Drawing.Point(214, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 130);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ayrıntı";
            // 
            // cbAyrintiListe
            // 
            this.cbAyrintiListe.AutoSize = true;
            this.cbAyrintiListe.Enabled = false;
            this.cbAyrintiListe.Location = new System.Drawing.Point(135, 72);
            this.cbAyrintiListe.Name = "cbAyrintiListe";
            this.cbAyrintiListe.Size = new System.Drawing.Size(111, 17);
            this.cbAyrintiListe.TabIndex = 4;
            this.cbAyrintiListe.Text = "Listede Gözüksün";
            this.cbAyrintiListe.UseVisualStyleBackColor = true;
            // 
            // cbAyrintiWeb
            // 
            this.cbAyrintiWeb.AutoSize = true;
            this.cbAyrintiWeb.Enabled = false;
            this.cbAyrintiWeb.Location = new System.Drawing.Point(9, 72);
            this.cbAyrintiWeb.Name = "cbAyrintiWeb";
            this.cbAyrintiWeb.Size = new System.Drawing.Size(114, 17);
            this.cbAyrintiWeb.TabIndex = 4;
            this.cbAyrintiWeb.Text = "Web\'de Gözüksün";
            this.cbAyrintiWeb.UseVisualStyleBackColor = true;
            // 
            // btnGorevDuzelt
            // 
            this.btnGorevDuzelt.Location = new System.Drawing.Point(95, 95);
            this.btnGorevDuzelt.Name = "btnGorevDuzelt";
            this.btnGorevDuzelt.Size = new System.Drawing.Size(75, 23);
            this.btnGorevDuzelt.TabIndex = 3;
            this.btnGorevDuzelt.Text = "Düzelt";
            this.btnGorevDuzelt.UseVisualStyleBackColor = true;
            this.btnGorevDuzelt.Click += new System.EventHandler(this.btnGorevDuzelt_Click);
            // 
            // btnGorevSil
            // 
            this.btnGorevSil.Location = new System.Drawing.Point(171, 95);
            this.btnGorevSil.Name = "btnGorevSil";
            this.btnGorevSil.Size = new System.Drawing.Size(75, 23);
            this.btnGorevSil.TabIndex = 3;
            this.btnGorevSil.Text = "Sil";
            this.btnGorevSil.UseVisualStyleBackColor = true;
            this.btnGorevSil.Click += new System.EventHandler(this.btnGorevSil_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Departman:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Görev:";
            // 
            // cmbDepartmanlar
            // 
            this.cmbDepartmanlar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartmanlar.Enabled = false;
            this.cmbDepartmanlar.FormattingEnabled = true;
            this.cmbDepartmanlar.Location = new System.Drawing.Point(95, 45);
            this.cmbDepartmanlar.Name = "cmbDepartmanlar";
            this.cmbDepartmanlar.Size = new System.Drawing.Size(151, 21);
            this.cmbDepartmanlar.TabIndex = 1;
            // 
            // txtGorev
            // 
            this.txtGorev.Location = new System.Drawing.Point(95, 19);
            this.txtGorev.Name = "txtGorev";
            this.txtGorev.ReadOnly = true;
            this.txtGorev.Size = new System.Drawing.Size(151, 20);
            this.txtGorev.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbEkleWeb);
            this.groupBox2.Controls.Add(this.cbEkleListe);
            this.groupBox2.Controls.Add(this.txtGorevEkleGorev);
            this.groupBox2.Controls.Add(this.btnTemizle);
            this.groupBox2.Controls.Add(this.btnGorevEkle);
            this.groupBox2.Controls.Add(this.cmbGorevEkleDepartman);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(214, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(258, 130);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Görev Ekle";
            // 
            // cbEkleWeb
            // 
            this.cbEkleWeb.AutoSize = true;
            this.cbEkleWeb.Checked = true;
            this.cbEkleWeb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEkleWeb.Location = new System.Drawing.Point(9, 74);
            this.cbEkleWeb.Name = "cbEkleWeb";
            this.cbEkleWeb.Size = new System.Drawing.Size(114, 17);
            this.cbEkleWeb.TabIndex = 4;
            this.cbEkleWeb.Text = "Web\'de Gözüksün";
            this.cbEkleWeb.UseVisualStyleBackColor = true;
            // 
            // cbEkleListe
            // 
            this.cbEkleListe.AutoSize = true;
            this.cbEkleListe.Checked = true;
            this.cbEkleListe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEkleListe.Location = new System.Drawing.Point(135, 74);
            this.cbEkleListe.Name = "cbEkleListe";
            this.cbEkleListe.Size = new System.Drawing.Size(111, 17);
            this.cbEkleListe.TabIndex = 4;
            this.cbEkleListe.Text = "Listede Gözüksün";
            this.cbEkleListe.UseVisualStyleBackColor = true;
            // 
            // txtGorevEkleGorev
            // 
            this.txtGorevEkleGorev.Location = new System.Drawing.Point(95, 21);
            this.txtGorevEkleGorev.Name = "txtGorevEkleGorev";
            this.txtGorevEkleGorev.Size = new System.Drawing.Size(151, 20);
            this.txtGorevEkleGorev.TabIndex = 0;
            // 
            // btnTemizle
            // 
            this.btnTemizle.Location = new System.Drawing.Point(95, 97);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(75, 23);
            this.btnTemizle.TabIndex = 3;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // btnGorevEkle
            // 
            this.btnGorevEkle.Location = new System.Drawing.Point(171, 97);
            this.btnGorevEkle.Name = "btnGorevEkle";
            this.btnGorevEkle.Size = new System.Drawing.Size(75, 23);
            this.btnGorevEkle.TabIndex = 3;
            this.btnGorevEkle.Text = "Ekle";
            this.btnGorevEkle.UseVisualStyleBackColor = true;
            this.btnGorevEkle.Click += new System.EventHandler(this.btnGorevEkle_Click);
            // 
            // cmbGorevEkleDepartman
            // 
            this.cmbGorevEkleDepartman.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGorevEkleDepartman.FormattingEnabled = true;
            this.cmbGorevEkleDepartman.Location = new System.Drawing.Point(95, 47);
            this.cmbGorevEkleDepartman.Name = "cmbGorevEkleDepartman";
            this.cmbGorevEkleDepartman.Size = new System.Drawing.Size(151, 21);
            this.cmbGorevEkleDepartman.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Departman:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Görev:";
            // 
            // frmGorevler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 288);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbGorevler);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 326);
            this.Name = "frmGorevler";
            this.Text = "Görevler";
            this.Load += new System.EventHandler(this.frmGorevler_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbGorevler;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDepartmanlar;
        private System.Windows.Forms.TextBox txtGorev;
        private System.Windows.Forms.Button btnGorevDuzelt;
        private System.Windows.Forms.Button btnGorevSil;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtGorevEkleGorev;
        private System.Windows.Forms.Button btnGorevEkle;
        private System.Windows.Forms.ComboBox cmbGorevEkleDepartman;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.CheckBox cbAyrintiWeb;
        private System.Windows.Forms.CheckBox cbEkleListe;
        private System.Windows.Forms.CheckBox cbAyrintiListe;
        private System.Windows.Forms.CheckBox cbEkleWeb;
    }
}