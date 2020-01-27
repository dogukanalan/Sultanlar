namespace Sultanlar.UI
{
    partial class frmINTERNETmesajyaz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmINTERNETmesajyaz));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKonu = new System.Windows.Forms.TextBox();
            this.txtMesaj = new System.Windows.Forms.TextBox();
            this.btnGonder = new System.Windows.Forms.Button();
            this.clbMusteriler = new System.Windows.Forms.CheckedListBox();
            this.rbMusteri = new System.Windows.Forms.RadioButton();
            this.rbSatTem = new System.Windows.Forms.RadioButton();
            this.rbTumu = new System.Windows.Forms.RadioButton();
            this.rbPerakende = new System.Windows.Forms.RadioButton();
            this.cbHepsini = new System.Windows.Forms.CheckBox();
            this.lblMusteriSayisi = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUnvan = new System.Windows.Forms.TextBox();
            this.btnAra = new System.Windows.Forms.Button();
            this.lblUnvan = new System.Windows.Forms.Label();
            this.rbMusterilerHaricTumu = new System.Windows.Forms.RadioButton();
            this.rbBayiYon = new System.Windows.Forms.RadioButton();
            this.rbButunSatis = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Üyeler:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Konu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mesaj:";
            // 
            // txtKonu
            // 
            this.txtKonu.Location = new System.Drawing.Point(309, 13);
            this.txtKonu.Name = "txtKonu";
            this.txtKonu.Size = new System.Drawing.Size(267, 20);
            this.txtKonu.TabIndex = 2;
            // 
            // txtMesaj
            // 
            this.txtMesaj.Location = new System.Drawing.Point(309, 39);
            this.txtMesaj.Multiline = true;
            this.txtMesaj.Name = "txtMesaj";
            this.txtMesaj.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMesaj.Size = new System.Drawing.Size(430, 350);
            this.txtMesaj.TabIndex = 2;
            // 
            // btnGonder
            // 
            this.btnGonder.Location = new System.Drawing.Point(624, 395);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(115, 23);
            this.btnGonder.TabIndex = 3;
            this.btnGonder.Text = "Gönder";
            this.btnGonder.UseVisualStyleBackColor = true;
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // clbMusteriler
            // 
            this.clbMusteriler.FormattingEnabled = true;
            this.clbMusteriler.Location = new System.Drawing.Point(12, 114);
            this.clbMusteriler.Name = "clbMusteriler";
            this.clbMusteriler.Size = new System.Drawing.Size(228, 274);
            this.clbMusteriler.Sorted = true;
            this.clbMusteriler.TabIndex = 4;
            this.clbMusteriler.SelectedIndexChanged += new System.EventHandler(this.clbMusteriler_SelectedIndexChanged);
            // 
            // rbMusteri
            // 
            this.rbMusteri.AutoSize = true;
            this.rbMusteri.Location = new System.Drawing.Point(18, 38);
            this.rbMusteri.Name = "rbMusteri";
            this.rbMusteri.Size = new System.Drawing.Size(70, 17);
            this.rbMusteri.TabIndex = 5;
            this.rbMusteri.Text = "Müşteriler";
            this.rbMusteri.UseVisualStyleBackColor = true;
            this.rbMusteri.CheckedChanged += new System.EventHandler(this.rbTumu_CheckedChanged);
            // 
            // rbSatTem
            // 
            this.rbSatTem.AutoSize = true;
            this.rbSatTem.Location = new System.Drawing.Point(11, 61);
            this.rbSatTem.Name = "rbSatTem";
            this.rbSatTem.Size = new System.Drawing.Size(68, 17);
            this.rbSatTem.TabIndex = 5;
            this.rbSatTem.Text = "Sat.Tem.";
            this.rbSatTem.UseVisualStyleBackColor = true;
            this.rbSatTem.CheckedChanged += new System.EventHandler(this.rbTumu_CheckedChanged);
            // 
            // rbTumu
            // 
            this.rbTumu.AutoSize = true;
            this.rbTumu.Checked = true;
            this.rbTumu.Location = new System.Drawing.Point(198, 61);
            this.rbTumu.Name = "rbTumu";
            this.rbTumu.Size = new System.Drawing.Size(52, 17);
            this.rbTumu.TabIndex = 5;
            this.rbTumu.TabStop = true;
            this.rbTumu.Text = "Tümü";
            this.rbTumu.UseVisualStyleBackColor = true;
            this.rbTumu.CheckedChanged += new System.EventHandler(this.rbTumu_CheckedChanged);
            // 
            // rbPerakende
            // 
            this.rbPerakende.AutoSize = true;
            this.rbPerakende.Location = new System.Drawing.Point(94, 38);
            this.rbPerakende.Name = "rbPerakende";
            this.rbPerakende.Size = new System.Drawing.Size(76, 17);
            this.rbPerakende.TabIndex = 5;
            this.rbPerakende.Text = "SDE Elem.";
            this.rbPerakende.UseVisualStyleBackColor = true;
            this.rbPerakende.CheckedChanged += new System.EventHandler(this.rbTumu_CheckedChanged);
            // 
            // cbHepsini
            // 
            this.cbHepsini.AutoSize = true;
            this.cbHepsini.Location = new System.Drawing.Point(12, 412);
            this.cbHepsini.Name = "cbHepsini";
            this.cbHepsini.Size = new System.Drawing.Size(83, 17);
            this.cbHepsini.TabIndex = 6;
            this.cbHepsini.Text = "Hepsini Seç";
            this.cbHepsini.UseVisualStyleBackColor = true;
            this.cbHepsini.CheckedChanged += new System.EventHandler(this.cbHepsini_CheckedChanged);
            // 
            // lblMusteriSayisi
            // 
            this.lblMusteriSayisi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMusteriSayisi.Location = new System.Drawing.Point(192, 411);
            this.lblMusteriSayisi.Name = "lblMusteriSayisi";
            this.lblMusteriSayisi.Size = new System.Drawing.Size(48, 17);
            this.lblMusteriSayisi.TabIndex = 7;
            this.lblMusteriSayisi.Text = "0";
            this.lblMusteriSayisi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ad:";
            // 
            // txtUnvan
            // 
            this.txtUnvan.Location = new System.Drawing.Point(60, 84);
            this.txtUnvan.Name = "txtUnvan";
            this.txtUnvan.Size = new System.Drawing.Size(127, 20);
            this.txtUnvan.TabIndex = 9;
            this.txtUnvan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUnvan_KeyDown);
            // 
            // btnAra
            // 
            this.btnAra.Location = new System.Drawing.Point(193, 82);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(47, 23);
            this.btnAra.TabIndex = 10;
            this.btnAra.Text = "Ara";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // lblUnvan
            // 
            this.lblUnvan.ForeColor = System.Drawing.Color.Maroon;
            this.lblUnvan.Location = new System.Drawing.Point(12, 391);
            this.lblUnvan.Name = "lblUnvan";
            this.lblUnvan.Size = new System.Drawing.Size(228, 17);
            this.lblUnvan.TabIndex = 7;
            this.lblUnvan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rbMusterilerHaricTumu
            // 
            this.rbMusterilerHaricTumu.AutoSize = true;
            this.rbMusterilerHaricTumu.Location = new System.Drawing.Point(139, 61);
            this.rbMusterilerHaricTumu.Name = "rbMusterilerHaricTumu";
            this.rbMusterilerHaricTumu.Size = new System.Drawing.Size(59, 17);
            this.rbMusterilerHaricTumu.TabIndex = 5;
            this.rbMusterilerHaricTumu.Text = "Tümü *";
            this.rbMusterilerHaricTumu.UseVisualStyleBackColor = true;
            this.rbMusterilerHaricTumu.CheckedChanged += new System.EventHandler(this.rbTumu_CheckedChanged);
            // 
            // rbBayiYon
            // 
            this.rbBayiYon.AutoSize = true;
            this.rbBayiYon.Location = new System.Drawing.Point(176, 38);
            this.rbBayiYon.Name = "rbBayiYon";
            this.rbBayiYon.Size = new System.Drawing.Size(70, 17);
            this.rbBayiYon.TabIndex = 5;
            this.rbBayiYon.Text = "Bayi Yön.";
            this.rbBayiYon.UseVisualStyleBackColor = true;
            this.rbBayiYon.CheckedChanged += new System.EventHandler(this.rbTumu_CheckedChanged);
            // 
            // rbButunSatis
            // 
            this.rbButunSatis.AutoSize = true;
            this.rbButunSatis.Location = new System.Drawing.Point(76, 61);
            this.rbButunSatis.Name = "rbButunSatis";
            this.rbButunSatis.Size = new System.Drawing.Size(63, 17);
            this.rbButunSatis.TabIndex = 5;
            this.rbButunSatis.Text = "Büt.Sat.";
            this.rbButunSatis.UseVisualStyleBackColor = true;
            this.rbButunSatis.CheckedChanged += new System.EventHandler(this.rbTumu_CheckedChanged);
            // 
            // frmINTERNETmesajyaz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 432);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.txtUnvan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblUnvan);
            this.Controls.Add(this.lblMusteriSayisi);
            this.Controls.Add(this.cbHepsini);
            this.Controls.Add(this.rbButunSatis);
            this.Controls.Add(this.rbMusterilerHaricTumu);
            this.Controls.Add(this.rbSatTem);
            this.Controls.Add(this.rbTumu);
            this.Controls.Add(this.rbBayiYon);
            this.Controls.Add(this.rbPerakende);
            this.Controls.Add(this.rbMusteri);
            this.Controls.Add(this.clbMusteriler);
            this.Controls.Add(this.btnGonder);
            this.Controls.Add(this.txtMesaj);
            this.Controls.Add(this.txtKonu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmINTERNETmesajyaz";
            this.Text = "Mesaj Yaz";
            this.Load += new System.EventHandler(this.frmINTERNETmesajyaz_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKonu;
        private System.Windows.Forms.TextBox txtMesaj;
        private System.Windows.Forms.Button btnGonder;
        private System.Windows.Forms.CheckedListBox clbMusteriler;
        private System.Windows.Forms.RadioButton rbMusteri;
        private System.Windows.Forms.RadioButton rbSatTem;
        private System.Windows.Forms.RadioButton rbTumu;
        private System.Windows.Forms.RadioButton rbPerakende;
        private System.Windows.Forms.CheckBox cbHepsini;
        private System.Windows.Forms.Label lblMusteriSayisi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUnvan;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.Label lblUnvan;
        private System.Windows.Forms.RadioButton rbMusterilerHaricTumu;
        private System.Windows.Forms.RadioButton rbBayiYon;
        private System.Windows.Forms.RadioButton rbButunSatis;
    }
}