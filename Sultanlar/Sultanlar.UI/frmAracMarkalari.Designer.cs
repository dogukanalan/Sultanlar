namespace Sultanlar.UI
{
    partial class frmAracMarkalari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAracMarkalari));
            this.lbMarkalar = new System.Windows.Forms.ListBox();
            this.txtMarkaEkle = new System.Windows.Forms.TextBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMarkaGuncelle = new System.Windows.Forms.TextBox();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSil = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMarkaSil = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbMarkalar
            // 
            this.lbMarkalar.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbMarkalar.FormattingEnabled = true;
            this.lbMarkalar.Location = new System.Drawing.Point(0, 0);
            this.lbMarkalar.Name = "lbMarkalar";
            this.lbMarkalar.Size = new System.Drawing.Size(169, 264);
            this.lbMarkalar.TabIndex = 0;
            this.lbMarkalar.SelectedIndexChanged += new System.EventHandler(this.lbMarkalar_SelectedIndexChanged);
            // 
            // txtMarkaEkle
            // 
            this.txtMarkaEkle.Location = new System.Drawing.Point(179, 48);
            this.txtMarkaEkle.Name = "txtMarkaEkle";
            this.txtMarkaEkle.Size = new System.Drawing.Size(128, 20);
            this.txtMarkaEkle.TabIndex = 1;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(179, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Yeni Marka Ekle:";
            // 
            // txtMarkaGuncelle
            // 
            this.txtMarkaGuncelle.Location = new System.Drawing.Point(179, 122);
            this.txtMarkaGuncelle.Name = "txtMarkaGuncelle";
            this.txtMarkaGuncelle.Size = new System.Drawing.Size(128, 20);
            this.txtMarkaGuncelle.TabIndex = 1;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(313, 120);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(75, 23);
            this.btnGuncelle.TabIndex = 2;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Seçili Markayı Güncelle:";
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(313, 201);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(75, 23);
            this.btnSil.TabIndex = 2;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(179, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Seçili Markayı Sil:";
            // 
            // txtMarkaSil
            // 
            this.txtMarkaSil.Enabled = false;
            this.txtMarkaSil.Location = new System.Drawing.Point(179, 203);
            this.txtMarkaSil.Name = "txtMarkaSil";
            this.txtMarkaSil.ReadOnly = true;
            this.txtMarkaSil.Size = new System.Drawing.Size(128, 20);
            this.txtMarkaSil.TabIndex = 1;
            // 
            // frmAracMarkalari
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
            this.Controls.Add(this.txtMarkaSil);
            this.Controls.Add(this.txtMarkaGuncelle);
            this.Controls.Add(this.txtMarkaEkle);
            this.Controls.Add(this.lbMarkalar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(415, 302);
            this.Name = "frmAracMarkalari";
            this.Text = "Markalar";
            this.Load += new System.EventHandler(this.frmAracMarkalari_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbMarkalar;
        private System.Windows.Forms.TextBox txtMarkaEkle;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMarkaGuncelle;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMarkaSil;
    }
}