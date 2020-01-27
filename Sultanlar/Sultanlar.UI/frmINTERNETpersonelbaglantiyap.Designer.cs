namespace Sultanlar.UI
{
    partial class frmINTERNETpersonelbaglantiyap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmINTERNETpersonelbaglantiyap));
            this.clbPersoneller = new System.Windows.Forms.CheckedListBox();
            this.clbMusteriler = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbBayiler = new System.Windows.Forms.ComboBox();
            this.cbTumu = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // clbPersoneller
            // 
            this.clbPersoneller.FormattingEnabled = true;
            this.clbPersoneller.Location = new System.Drawing.Point(10, 10);
            this.clbPersoneller.Name = "clbPersoneller";
            this.clbPersoneller.Size = new System.Drawing.Size(199, 484);
            this.clbPersoneller.TabIndex = 0;
            // 
            // clbMusteriler
            // 
            this.clbMusteriler.FormattingEnabled = true;
            this.clbMusteriler.Location = new System.Drawing.Point(215, 40);
            this.clbMusteriler.Name = "clbMusteriler";
            this.clbMusteriler.Size = new System.Drawing.Size(576, 394);
            this.clbMusteriler.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(215, 470);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(576, 24);
            this.button1.TabIndex = 1;
            this.button1.Text = "Bağla";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbBayiler
            // 
            this.cmbBayiler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBayiler.FormattingEnabled = true;
            this.cmbBayiler.Location = new System.Drawing.Point(215, 10);
            this.cmbBayiler.Name = "cmbBayiler";
            this.cmbBayiler.Size = new System.Drawing.Size(576, 21);
            this.cmbBayiler.TabIndex = 2;
            this.cmbBayiler.SelectedIndexChanged += new System.EventHandler(this.cmbBayiler_SelectedIndexChanged);
            // 
            // cbTumu
            // 
            this.cbTumu.AutoSize = true;
            this.cbTumu.Location = new System.Drawing.Point(215, 440);
            this.cbTumu.Name = "cbTumu";
            this.cbTumu.Size = new System.Drawing.Size(87, 17);
            this.cbTumu.TabIndex = 3;
            this.cbTumu.Text = "Tümünü Seç";
            this.cbTumu.UseVisualStyleBackColor = true;
            this.cbTumu.CheckedChanged += new System.EventHandler(this.cbTumu_CheckedChanged);
            // 
            // frmINTERNETpersonelbaglantiyap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 505);
            this.Controls.Add(this.cbTumu);
            this.Controls.Add(this.cmbBayiler);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.clbMusteriler);
            this.Controls.Add(this.clbPersoneller);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmINTERNETpersonelbaglantiyap";
            this.Text = "Personel Bağlantısı Yap";
            this.Load += new System.EventHandler(this.frmINTERNETpersonelbaglantiyap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbPersoneller;
        private System.Windows.Forms.CheckedListBox clbMusteriler;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbBayiler;
        private System.Windows.Forms.CheckBox cbTumu;
    }
}