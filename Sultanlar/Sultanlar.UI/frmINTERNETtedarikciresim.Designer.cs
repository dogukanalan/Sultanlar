namespace Sultanlar.UI
{
    partial class frmINTERNETtedarikciresim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmINTERNETtedarikciresim));
            this.lbTedarikciler = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.lblBoyut = new System.Windows.Forms.Label();
            this.lblEklenme = new System.Windows.Forms.Label();
            this.lblEkleyen = new System.Windows.Forms.Label();
            this.lbResimler = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTedarikciler
            // 
            this.lbTedarikciler.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbTedarikciler.FormattingEnabled = true;
            this.lbTedarikciler.Location = new System.Drawing.Point(12, 12);
            this.lbTedarikciler.Name = "lbTedarikciler";
            this.lbTedarikciler.Size = new System.Drawing.Size(265, 420);
            this.lbTedarikciler.TabIndex = 7;
            this.lbTedarikciler.SelectedIndexChanged += new System.EventHandler(this.lbTedarikciler_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::Sultanlar.UI.Properties.Resources.resimyok;
            this.pictureBox1.Location = new System.Drawing.Point(336, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 400);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btnEkle
            // 
            this.btnEkle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEkle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEkle.Location = new System.Drawing.Point(283, 353);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(47, 59);
            this.btnEkle.TabIndex = 10;
            this.btnEkle.Text = "Resim\r\n\r\nEkle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnSil
            // 
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSil.ForeColor = System.Drawing.Color.DarkRed;
            this.btnSil.Location = new System.Drawing.Point(283, 266);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(47, 22);
            this.btnSil.TabIndex = 11;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // lblBoyut
            // 
            this.lblBoyut.AutoSize = true;
            this.lblBoyut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBoyut.Location = new System.Drawing.Point(340, 420);
            this.lblBoyut.Name = "lblBoyut";
            this.lblBoyut.Size = new System.Drawing.Size(0, 13);
            this.lblBoyut.TabIndex = 16;
            // 
            // lblEklenme
            // 
            this.lblEklenme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEklenme.Location = new System.Drawing.Point(436, 420);
            this.lblEklenme.Name = "lblEklenme";
            this.lblEklenme.Size = new System.Drawing.Size(108, 13);
            this.lblEklenme.TabIndex = 15;
            this.lblEklenme.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEkleyen
            // 
            this.lblEkleyen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEkleyen.Location = new System.Drawing.Point(569, 420);
            this.lblEkleyen.Name = "lblEkleyen";
            this.lblEkleyen.Size = new System.Drawing.Size(167, 13);
            this.lblEkleyen.TabIndex = 14;
            this.lblEkleyen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbResimler
            // 
            this.lbResimler.FormattingEnabled = true;
            this.lbResimler.Location = new System.Drawing.Point(283, 12);
            this.lbResimler.Name = "lbResimler";
            this.lbResimler.Size = new System.Drawing.Size(47, 160);
            this.lbResimler.TabIndex = 17;
            this.lbResimler.SelectedIndexChanged += new System.EventHandler(this.lbResimler_SelectedIndexChanged);
            // 
            // frmINTERNETtedarikciresim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 443);
            this.Controls.Add(this.lbResimler);
            this.Controls.Add(this.lblBoyut);
            this.Controls.Add(this.lblEklenme);
            this.Controls.Add(this.lblEkleyen);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbTedarikciler);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmINTERNETtedarikciresim";
            this.Text = "Tedarikçi Resim Ekleme";
            this.Load += new System.EventHandler(this.frmINTERNETtedarikciresim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbTedarikciler;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Label lblBoyut;
        private System.Windows.Forms.Label lblEklenme;
        private System.Windows.Forms.Label lblEkleyen;
        private System.Windows.Forms.ListBox lbResimler;
    }
}