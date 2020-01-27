namespace Sultanlar.UI
{
    partial class frmINTERNETuyegrubuolustur
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
            this.btnOlustur = new System.Windows.Forms.Button();
            this.txtUyeGrubu = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOlustur
            // 
            this.btnOlustur.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOlustur.Location = new System.Drawing.Point(240, 10);
            this.btnOlustur.Name = "btnOlustur";
            this.btnOlustur.Size = new System.Drawing.Size(75, 23);
            this.btnOlustur.TabIndex = 0;
            this.btnOlustur.Text = "Oluştur";
            this.btnOlustur.UseVisualStyleBackColor = true;
            this.btnOlustur.Click += new System.EventHandler(this.btnOlustur_Click);
            // 
            // txtUyeGrubu
            // 
            this.txtUyeGrubu.Location = new System.Drawing.Point(12, 12);
            this.txtUyeGrubu.Name = "txtUyeGrubu";
            this.txtUyeGrubu.Size = new System.Drawing.Size(222, 20);
            this.txtUyeGrubu.TabIndex = 1;
            // 
            // frmINTERNETuyegrubuolustur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 43);
            this.Controls.Add(this.txtUyeGrubu);
            this.Controls.Add(this.btnOlustur);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmINTERNETuyegrubuolustur";
            this.Text = "Yeni Üye Grubu Oluştur";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOlustur;
        private System.Windows.Forms.TextBox txtUyeGrubu;
    }
}