namespace Sultanlar.UI
{
    partial class frmINTERNETsatistemsilcileriseflerekleme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmINTERNETsatistemsilcileriseflerekleme));
            this.lb1 = new System.Windows.Forms.ListBox();
            this.lb2 = new System.Windows.Forms.ListBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnCikar = new System.Windows.Forms.Button();
            this.btnTumunuEkle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb1
            // 
            this.lb1.FormattingEnabled = true;
            this.lb1.Location = new System.Drawing.Point(12, 12);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(204, 290);
            this.lb1.TabIndex = 1;
            this.lb1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lb1_MouseDoubleClick);
            // 
            // lb2
            // 
            this.lb2.FormattingEnabled = true;
            this.lb2.Location = new System.Drawing.Point(316, 12);
            this.lb2.Name = "lb2";
            this.lb2.Size = new System.Drawing.Size(204, 290);
            this.lb2.TabIndex = 1;
            this.lb2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lb2_MouseDoubleClick);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(219, 146);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(94, 28);
            this.btnEkle.TabIndex = 2;
            this.btnEkle.Text = "Ekle >";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnCikar
            // 
            this.btnCikar.Location = new System.Drawing.Point(219, 180);
            this.btnCikar.Name = "btnCikar";
            this.btnCikar.Size = new System.Drawing.Size(94, 28);
            this.btnCikar.TabIndex = 2;
            this.btnCikar.Text = "< Çıkar";
            this.btnCikar.UseVisualStyleBackColor = true;
            this.btnCikar.Click += new System.EventHandler(this.btnCikar_Click);
            // 
            // btnTumunuEkle
            // 
            this.btnTumunuEkle.Location = new System.Drawing.Point(219, 86);
            this.btnTumunuEkle.Name = "btnTumunuEkle";
            this.btnTumunuEkle.Size = new System.Drawing.Size(94, 44);
            this.btnTumunuEkle.TabIndex = 3;
            this.btnTumunuEkle.Text = "Tümünü Ekle >>";
            this.btnTumunuEkle.UseVisualStyleBackColor = true;
            this.btnTumunuEkle.Click += new System.EventHandler(this.btnTumunuEkle_Click);
            // 
            // frmINTERNETsatistemsilcileriseflerekleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 314);
            this.Controls.Add(this.btnTumunuEkle);
            this.Controls.Add(this.btnCikar);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.lb2);
            this.Controls.Add(this.lb1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(548, 352);
            this.MinimumSize = new System.Drawing.Size(548, 352);
            this.Name = "frmINTERNETsatistemsilcileriseflerekleme";
            this.Text = "Düzenleme";
            this.Load += new System.EventHandler(this.frmINTERNETsatistemsilcileriseflerekleme_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lb1;
        private System.Windows.Forms.ListBox lb2;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnCikar;
        private System.Windows.Forms.Button btnTumunuEkle;
    }
}