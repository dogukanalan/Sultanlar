namespace Sultanlar.UI
{
    partial class frmAT2bolgeler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAT2bolgeler));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.txtSil = new System.Windows.Forms.TextBox();
            this.txtGuncelle = new System.Windows.Forms.TextBox();
            this.txtEkle = new System.Windows.Forms.TextBox();
            this.lbBolgeler = new System.Windows.Forms.ListBox();
            this.btnYenile = new System.Windows.Forms.Button();
            this.cbPasifler = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(179, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "Seçilen Bölgeyi Sil";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(179, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "Seçilen Bölgeyi Güncelle";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(179, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "Yeni Bölge Ekle";
            // 
            // btnSil
            // 
            this.btnSil.Enabled = false;
            this.btnSil.Location = new System.Drawing.Point(313, 201);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(75, 23);
            this.btnSil.TabIndex = 6;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Enabled = false;
            this.btnGuncelle.Location = new System.Drawing.Point(313, 120);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(75, 23);
            this.btnGuncelle.TabIndex = 4;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(313, 46);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 23);
            this.btnEkle.TabIndex = 2;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // txtSil
            // 
            this.txtSil.Enabled = false;
            this.txtSil.Location = new System.Drawing.Point(179, 203);
            this.txtSil.Name = "txtSil";
            this.txtSil.ReadOnly = true;
            this.txtSil.Size = new System.Drawing.Size(128, 20);
            this.txtSil.TabIndex = 5;
            // 
            // txtGuncelle
            // 
            this.txtGuncelle.Enabled = false;
            this.txtGuncelle.Location = new System.Drawing.Point(179, 122);
            this.txtGuncelle.Name = "txtGuncelle";
            this.txtGuncelle.Size = new System.Drawing.Size(128, 20);
            this.txtGuncelle.TabIndex = 3;
            // 
            // txtEkle
            // 
            this.txtEkle.Location = new System.Drawing.Point(179, 48);
            this.txtEkle.Name = "txtEkle";
            this.txtEkle.Size = new System.Drawing.Size(128, 20);
            this.txtEkle.TabIndex = 1;
            // 
            // lbBolgeler
            // 
            this.lbBolgeler.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbBolgeler.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbBolgeler.FormattingEnabled = true;
            this.lbBolgeler.ItemHeight = 14;
            this.lbBolgeler.Location = new System.Drawing.Point(0, 0);
            this.lbBolgeler.Name = "lbBolgeler";
            this.lbBolgeler.Size = new System.Drawing.Size(169, 272);
            this.lbBolgeler.TabIndex = 0;
            this.lbBolgeler.SelectedIndexChanged += new System.EventHandler(this.lbBolgeler_SelectedIndexChanged);
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
            // cbPasifler
            // 
            this.cbPasifler.AutoSize = true;
            this.cbPasifler.Location = new System.Drawing.Point(300, 5);
            this.cbPasifler.Name = "cbPasifler";
            this.cbPasifler.Size = new System.Drawing.Size(68, 17);
            this.cbPasifler.TabIndex = 55;
            this.cbPasifler.Text = "Silinenler";
            this.cbPasifler.UseVisualStyleBackColor = true;
            // 
            // frmAT2bolgeler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 272);
            this.Controls.Add(this.cbPasifler);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.txtSil);
            this.Controls.Add(this.txtGuncelle);
            this.Controls.Add(this.txtEkle);
            this.Controls.Add(this.lbBolgeler);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(415, 310);
            this.Name = "frmAT2bolgeler";
            this.Text = "Bölgeler";
            this.Load += new System.EventHandler(this.frmAT2bolgeler_Load);
            this.SizeChanged += new System.EventHandler(this.frmAT2bolgeler_SizeChanged);
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
        private System.Windows.Forms.ListBox lbBolgeler;
        private System.Windows.Forms.Button btnYenile;
        private System.Windows.Forms.CheckBox cbPasifler;
    }
}