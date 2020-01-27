namespace Sultanlar.UI
{
    partial class frmAracTurleri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAracTurleri));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.txtTurSil = new System.Windows.Forms.TextBox();
            this.txtTurGuncelle = new System.Windows.Forms.TextBox();
            this.txtTurEkle = new System.Windows.Forms.TextBox();
            this.lbTurler = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(179, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Seçili Türü Sil:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Seçili Türü Güncelle:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(179, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Yeni Tür Ekle:";
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(313, 201);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(75, 23);
            this.btnSil.TabIndex = 9;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(313, 120);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(75, 23);
            this.btnGuncelle.TabIndex = 10;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(313, 46);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 23);
            this.btnEkle.TabIndex = 8;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // txtTurSil
            // 
            this.txtTurSil.Enabled = false;
            this.txtTurSil.Location = new System.Drawing.Point(179, 203);
            this.txtTurSil.Name = "txtTurSil";
            this.txtTurSil.ReadOnly = true;
            this.txtTurSil.Size = new System.Drawing.Size(128, 20);
            this.txtTurSil.TabIndex = 5;
            // 
            // txtTurGuncelle
            // 
            this.txtTurGuncelle.Location = new System.Drawing.Point(179, 122);
            this.txtTurGuncelle.Name = "txtTurGuncelle";
            this.txtTurGuncelle.Size = new System.Drawing.Size(128, 20);
            this.txtTurGuncelle.TabIndex = 6;
            // 
            // txtTurEkle
            // 
            this.txtTurEkle.Location = new System.Drawing.Point(179, 48);
            this.txtTurEkle.Name = "txtTurEkle";
            this.txtTurEkle.Size = new System.Drawing.Size(128, 20);
            this.txtTurEkle.TabIndex = 7;
            // 
            // lbTurler
            // 
            this.lbTurler.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbTurler.FormattingEnabled = true;
            this.lbTurler.Location = new System.Drawing.Point(0, 0);
            this.lbTurler.Name = "lbTurler";
            this.lbTurler.Size = new System.Drawing.Size(169, 264);
            this.lbTurler.TabIndex = 4;
            this.lbTurler.SelectedIndexChanged += new System.EventHandler(this.lbTurler_SelectedIndexChanged);
            // 
            // frmAracTurleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 264);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.txtTurSil);
            this.Controls.Add(this.txtTurGuncelle);
            this.Controls.Add(this.txtTurEkle);
            this.Controls.Add(this.lbTurler);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(415, 302);
            this.Name = "frmAracTurleri";
            this.Text = "Türler";
            this.Load += new System.EventHandler(this.frmAracTurleri_Load);
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
        private System.Windows.Forms.TextBox txtTurSil;
        private System.Windows.Forms.TextBox txtTurGuncelle;
        private System.Windows.Forms.TextBox txtTurEkle;
        private System.Windows.Forms.ListBox lbTurler;
    }
}