namespace Sultanlar.UI
{
    partial class frmINTERNETsatistemsilcilerisefler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmINTERNETsatistemsilcilerisefler));
            this.lbSefler = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbAltlar = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAltDuzenle = new System.Windows.Forms.Button();
            this.btnSefDuzenle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbSefler
            // 
            this.lbSefler.FormattingEnabled = true;
            this.lbSefler.Location = new System.Drawing.Point(12, 38);
            this.lbSefler.Name = "lbSefler";
            this.lbSefler.Size = new System.Drawing.Size(204, 303);
            this.lbSefler.Sorted = true;
            this.lbSefler.TabIndex = 0;
            this.lbSefler.SelectedIndexChanged += new System.EventHandler(this.lbSefler_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Şefler:";
            // 
            // lbAltlar
            // 
            this.lbAltlar.FormattingEnabled = true;
            this.lbAltlar.Location = new System.Drawing.Point(256, 38);
            this.lbAltlar.Name = "lbAltlar";
            this.lbAltlar.Size = new System.Drawing.Size(204, 303);
            this.lbAltlar.Sorted = true;
            this.lbAltlar.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Alt Satış Temsilcileri:";
            // 
            // btnAltDuzenle
            // 
            this.btnAltDuzenle.Location = new System.Drawing.Point(256, 347);
            this.btnAltDuzenle.Name = "btnAltDuzenle";
            this.btnAltDuzenle.Size = new System.Drawing.Size(204, 23);
            this.btnAltDuzenle.TabIndex = 2;
            this.btnAltDuzenle.Text = "Düzenle";
            this.btnAltDuzenle.UseVisualStyleBackColor = true;
            this.btnAltDuzenle.Click += new System.EventHandler(this.btnAltDuzenle_Click);
            // 
            // btnSefDuzenle
            // 
            this.btnSefDuzenle.Location = new System.Drawing.Point(12, 347);
            this.btnSefDuzenle.Name = "btnSefDuzenle";
            this.btnSefDuzenle.Size = new System.Drawing.Size(204, 23);
            this.btnSefDuzenle.TabIndex = 2;
            this.btnSefDuzenle.Text = "Şef Düzenle";
            this.btnSefDuzenle.UseVisualStyleBackColor = true;
            this.btnSefDuzenle.Click += new System.EventHandler(this.btnSefDuzenle_Click);
            // 
            // frmINTERNETsatistemsilcilerisefler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 381);
            this.Controls.Add(this.btnSefDuzenle);
            this.Controls.Add(this.btnAltDuzenle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbAltlar);
            this.Controls.Add(this.lbSefler);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(488, 419);
            this.MinimumSize = new System.Drawing.Size(488, 419);
            this.Name = "frmINTERNETsatistemsilcilerisefler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Satış Temsilcileri Şef Düzenlemesi";
            this.Load += new System.EventHandler(this.frmINTERNETsatistemsilcilerisefler_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbSefler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbAltlar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAltDuzenle;
        private System.Windows.Forms.Button btnSefDuzenle;
    }
}