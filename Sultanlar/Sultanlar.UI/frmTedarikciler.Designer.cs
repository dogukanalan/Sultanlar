namespace Sultanlar.UI
{
    partial class frmTedarikciler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTedarikciler));
            this.lbTedarikciler = new System.Windows.Forms.ListBox();
            this.pbResim = new System.Windows.Forms.PictureBox();
            this.gbAyrinti = new System.Windows.Forms.GroupBox();
            this.btnResimDegistir = new System.Windows.Forms.Button();
            this.btnDuzelt = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTedarikci = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbEkleme = new System.Windows.Forms.GroupBox();
            this.btnEkleResimEkle = new System.Windows.Forms.Button();
            this.txtEkleAciklama = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEkleTedarikci = new System.Windows.Forms.TextBox();
            this.pbEkleResim = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbResim)).BeginInit();
            this.gbAyrinti.SuspendLayout();
            this.gbEkleme.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEkleResim)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTedarikciler
            // 
            this.lbTedarikciler.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbTedarikciler.FormattingEnabled = true;
            this.lbTedarikciler.Location = new System.Drawing.Point(0, 0);
            this.lbTedarikciler.Name = "lbTedarikciler";
            this.lbTedarikciler.Size = new System.Drawing.Size(188, 490);
            this.lbTedarikciler.TabIndex = 0;
            this.lbTedarikciler.SelectedIndexChanged += new System.EventHandler(this.lbTedarikciler_SelectedIndexChanged);
            // 
            // pbResim
            // 
            this.pbResim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbResim.Location = new System.Drawing.Point(632, 27);
            this.pbResim.Name = "pbResim";
            this.pbResim.Size = new System.Drawing.Size(140, 140);
            this.pbResim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbResim.TabIndex = 1;
            this.pbResim.TabStop = false;
            // 
            // gbAyrinti
            // 
            this.gbAyrinti.Controls.Add(this.btnResimDegistir);
            this.gbAyrinti.Controls.Add(this.btnDuzelt);
            this.gbAyrinti.Controls.Add(this.btnSil);
            this.gbAyrinti.Controls.Add(this.txtAciklama);
            this.gbAyrinti.Controls.Add(this.label3);
            this.gbAyrinti.Controls.Add(this.txtTedarikci);
            this.gbAyrinti.Controls.Add(this.label2);
            this.gbAyrinti.Controls.Add(this.lblID);
            this.gbAyrinti.Controls.Add(this.label1);
            this.gbAyrinti.Controls.Add(this.pbResim);
            this.gbAyrinti.Location = new System.Drawing.Point(194, 12);
            this.gbAyrinti.Name = "gbAyrinti";
            this.gbAyrinti.Size = new System.Drawing.Size(778, 231);
            this.gbAyrinti.TabIndex = 2;
            this.gbAyrinti.TabStop = false;
            this.gbAyrinti.Text = "Ayrıntı";
            // 
            // btnResimDegistir
            // 
            this.btnResimDegistir.Enabled = false;
            this.btnResimDegistir.Location = new System.Drawing.Point(632, 173);
            this.btnResimDegistir.Name = "btnResimDegistir";
            this.btnResimDegistir.Size = new System.Drawing.Size(140, 23);
            this.btnResimDegistir.TabIndex = 5;
            this.btnResimDegistir.Text = "Resmi Değiştir";
            this.btnResimDegistir.UseVisualStyleBackColor = true;
            this.btnResimDegistir.Visible = false;
            this.btnResimDegistir.Click += new System.EventHandler(this.btnResimDegistir_Click);
            // 
            // btnDuzelt
            // 
            this.btnDuzelt.Location = new System.Drawing.Point(632, 199);
            this.btnDuzelt.Name = "btnDuzelt";
            this.btnDuzelt.Size = new System.Drawing.Size(68, 23);
            this.btnDuzelt.TabIndex = 4;
            this.btnDuzelt.Text = "Düzelt";
            this.btnDuzelt.UseVisualStyleBackColor = true;
            this.btnDuzelt.Click += new System.EventHandler(this.btnDuzelt_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(704, 199);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(68, 23);
            this.btnSil.TabIndex = 4;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(66, 72);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.ReadOnly = true;
            this.txtAciklama.Size = new System.Drawing.Size(560, 153);
            this.txtAciklama.TabIndex = 3;
            this.txtAciklama.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Açıklama:";
            // 
            // txtTedarikci
            // 
            this.txtTedarikci.Location = new System.Drawing.Point(66, 48);
            this.txtTedarikci.Name = "txtTedarikci";
            this.txtTedarikci.ReadOnly = true;
            this.txtTedarikci.Size = new System.Drawing.Size(560, 20);
            this.txtTedarikci.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tedarikçi:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.ForeColor = System.Drawing.Color.Red;
            this.lblID.Location = new System.Drawing.Point(68, 27);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(13, 13);
            this.lblID.TabIndex = 2;
            this.lblID.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID:";
            // 
            // gbEkleme
            // 
            this.gbEkleme.Controls.Add(this.btnEkleResimEkle);
            this.gbEkleme.Controls.Add(this.txtEkleAciklama);
            this.gbEkleme.Controls.Add(this.label6);
            this.gbEkleme.Controls.Add(this.btnTemizle);
            this.gbEkleme.Controls.Add(this.btnEkle);
            this.gbEkleme.Controls.Add(this.label4);
            this.gbEkleme.Controls.Add(this.txtEkleTedarikci);
            this.gbEkleme.Controls.Add(this.pbEkleResim);
            this.gbEkleme.Location = new System.Drawing.Point(194, 249);
            this.gbEkleme.Name = "gbEkleme";
            this.gbEkleme.Size = new System.Drawing.Size(778, 233);
            this.gbEkleme.TabIndex = 3;
            this.gbEkleme.TabStop = false;
            this.gbEkleme.Text = "Ekleme";
            // 
            // btnEkleResimEkle
            // 
            this.btnEkleResimEkle.Location = new System.Drawing.Point(632, 176);
            this.btnEkleResimEkle.Name = "btnEkleResimEkle";
            this.btnEkleResimEkle.Size = new System.Drawing.Size(140, 23);
            this.btnEkleResimEkle.TabIndex = 4;
            this.btnEkleResimEkle.Text = "Resim Ekle";
            this.btnEkleResimEkle.UseVisualStyleBackColor = true;
            this.btnEkleResimEkle.Click += new System.EventHandler(this.btnEkleResimEkle_Click);
            // 
            // txtEkleAciklama
            // 
            this.txtEkleAciklama.Location = new System.Drawing.Point(66, 54);
            this.txtEkleAciklama.Multiline = true;
            this.txtEkleAciklama.Name = "txtEkleAciklama";
            this.txtEkleAciklama.Size = new System.Drawing.Size(560, 172);
            this.txtEkleAciklama.TabIndex = 3;
            this.txtEkleAciklama.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Açıklama:";
            // 
            // btnTemizle
            // 
            this.btnTemizle.Location = new System.Drawing.Point(632, 203);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(68, 23);
            this.btnTemizle.TabIndex = 4;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(704, 203);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(68, 23);
            this.btnEkle.TabIndex = 4;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tedarikçi:";
            // 
            // txtEkleTedarikci
            // 
            this.txtEkleTedarikci.Location = new System.Drawing.Point(66, 30);
            this.txtEkleTedarikci.Name = "txtEkleTedarikci";
            this.txtEkleTedarikci.Size = new System.Drawing.Size(560, 20);
            this.txtEkleTedarikci.TabIndex = 3;
            // 
            // pbEkleResim
            // 
            this.pbEkleResim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbEkleResim.Location = new System.Drawing.Point(632, 30);
            this.pbEkleResim.Name = "pbEkleResim";
            this.pbEkleResim.Size = new System.Drawing.Size(140, 140);
            this.pbEkleResim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEkleResim.TabIndex = 1;
            this.pbEkleResim.TabStop = false;
            this.pbEkleResim.Click += new System.EventHandler(this.pbEkleResim_Click);
            // 
            // frmTedarikciler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 490);
            this.Controls.Add(this.gbEkleme);
            this.Controls.Add(this.gbAyrinti);
            this.Controls.Add(this.lbTedarikciler);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 528);
            this.Name = "frmTedarikciler";
            this.Text = "Tedarikçiler";
            this.Load += new System.EventHandler(this.frmTedarikciler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbResim)).EndInit();
            this.gbAyrinti.ResumeLayout(false);
            this.gbAyrinti.PerformLayout();
            this.gbEkleme.ResumeLayout(false);
            this.gbEkleme.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEkleResim)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbTedarikciler;
        private System.Windows.Forms.PictureBox pbResim;
        private System.Windows.Forms.GroupBox gbAyrinti;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDuzelt;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.TextBox txtTedarikci;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.GroupBox gbEkleme;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEkleTedarikci;
        private System.Windows.Forms.Button btnEkleResimEkle;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEkleAciklama;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnResimDegistir;
        private System.Windows.Forms.Button btnTemizle;
        public System.Windows.Forms.PictureBox pbEkleResim;
    }
}