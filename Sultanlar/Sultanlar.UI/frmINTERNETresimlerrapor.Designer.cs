namespace Sultanlar.UI
{
    partial class frmINTERNETresimlerrapor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmINTERNETresimlerrapor));
            this.btnResimsizTedarikciler = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIstatistik = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblToplamUrun = new System.Windows.Forms.Label();
            this.lblResimliUrun = new System.Windows.Forms.Label();
            this.lblResimsizUrun = new System.Windows.Forms.Label();
            this.lblYuzde = new System.Windows.Forms.Label();
            this.clOZELACIK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clToplamUrunSayisi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clResimliUrunSayisi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clResimsizUrunSayisi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clYuzde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnResimsizTedarikciler
            // 
            this.btnResimsizTedarikciler.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResimsizTedarikciler.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnResimsizTedarikciler.Location = new System.Drawing.Point(394, 395);
            this.btnResimsizTedarikciler.Name = "btnResimsizTedarikciler";
            this.btnResimsizTedarikciler.Size = new System.Drawing.Size(219, 23);
            this.btnResimsizTedarikciler.TabIndex = 18;
            this.btnResimsizTedarikciler.Text = "Hiç Resim Eklenmemiş Tedarikçiler";
            this.btnResimsizTedarikciler.UseVisualStyleBackColor = true;
            this.btnResimsizTedarikciler.Click += new System.EventHandler(this.btnResimsizTedarikciler_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clOZELACIK,
            this.clToplamUrunSayisi,
            this.clResimliUrunSayisi,
            this.clResimsizUrunSayisi,
            this.clYuzde});
            this.dgv.Location = new System.Drawing.Point(15, 37);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(608, 334);
            this.dgv.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Tedarikçiye Göre Resim Sayısı:";
            // 
            // btnIstatistik
            // 
            this.btnIstatistik.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIstatistik.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnIstatistik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnIstatistik.Location = new System.Drawing.Point(218, 395);
            this.btnIstatistik.Name = "btnIstatistik";
            this.btnIstatistik.Size = new System.Drawing.Size(153, 23);
            this.btnIstatistik.TabIndex = 21;
            this.btnIstatistik.Text = "Kim Kaç Resim Ekledi";
            this.btnIstatistik.UseVisualStyleBackColor = true;
            this.btnIstatistik.Click += new System.EventHandler(this.btnIstatistik_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(182, 374);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Toplam:";
            // 
            // lblToplamUrun
            // 
            this.lblToplamUrun.AutoSize = true;
            this.lblToplamUrun.Location = new System.Drawing.Point(298, 374);
            this.lblToplamUrun.Name = "lblToplamUrun";
            this.lblToplamUrun.Size = new System.Drawing.Size(37, 13);
            this.lblToplamUrun.TabIndex = 22;
            this.lblToplamUrun.Text = "12000";
            // 
            // lblResimliUrun
            // 
            this.lblResimliUrun.AutoSize = true;
            this.lblResimliUrun.Location = new System.Drawing.Point(393, 374);
            this.lblResimliUrun.Name = "lblResimliUrun";
            this.lblResimliUrun.Size = new System.Drawing.Size(31, 13);
            this.lblResimliUrun.TabIndex = 22;
            this.lblResimliUrun.Text = "5000";
            // 
            // lblResimsizUrun
            // 
            this.lblResimsizUrun.AutoSize = true;
            this.lblResimsizUrun.Location = new System.Drawing.Point(485, 374);
            this.lblResimsizUrun.Name = "lblResimsizUrun";
            this.lblResimsizUrun.Size = new System.Drawing.Size(31, 13);
            this.lblResimsizUrun.TabIndex = 22;
            this.lblResimsizUrun.Text = "7000";
            // 
            // lblYuzde
            // 
            this.lblYuzde.AutoSize = true;
            this.lblYuzde.Location = new System.Drawing.Point(557, 374);
            this.lblYuzde.Name = "lblYuzde";
            this.lblYuzde.Size = new System.Drawing.Size(27, 13);
            this.lblYuzde.TabIndex = 22;
            this.lblYuzde.Text = "%50";
            // 
            // clOZELACIK
            // 
            this.clOZELACIK.DataPropertyName = "OZEL ACIK";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.clOZELACIK.DefaultCellStyle = dataGridViewCellStyle1;
            this.clOZELACIK.HeaderText = "Tedarikçi";
            this.clOZELACIK.Name = "clOZELACIK";
            this.clOZELACIK.ReadOnly = true;
            this.clOZELACIK.Width = 258;
            // 
            // clToplamUrunSayisi
            // 
            this.clToplamUrunSayisi.DataPropertyName = "ToplamUrunSayisi";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clToplamUrunSayisi.DefaultCellStyle = dataGridViewCellStyle2;
            this.clToplamUrunSayisi.HeaderText = "Toplam Ürün Sayısı";
            this.clToplamUrunSayisi.Name = "clToplamUrunSayisi";
            this.clToplamUrunSayisi.ReadOnly = true;
            this.clToplamUrunSayisi.Width = 90;
            // 
            // clResimliUrunSayisi
            // 
            this.clResimliUrunSayisi.DataPropertyName = "ResimliUrunSayisi";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clResimliUrunSayisi.DefaultCellStyle = dataGridViewCellStyle3;
            this.clResimliUrunSayisi.HeaderText = "Resimli Ürün Sayısı";
            this.clResimliUrunSayisi.Name = "clResimliUrunSayisi";
            this.clResimliUrunSayisi.ReadOnly = true;
            this.clResimliUrunSayisi.Width = 90;
            // 
            // clResimsizUrunSayisi
            // 
            this.clResimsizUrunSayisi.DataPropertyName = "ResimsizUrunSayisi";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clResimsizUrunSayisi.DefaultCellStyle = dataGridViewCellStyle4;
            this.clResimsizUrunSayisi.HeaderText = "Resimsiz Ürün Sayısı";
            this.clResimsizUrunSayisi.Name = "clResimsizUrunSayisi";
            this.clResimsizUrunSayisi.ReadOnly = true;
            this.clResimsizUrunSayisi.Width = 90;
            // 
            // clYuzde
            // 
            this.clYuzde.DataPropertyName = "Yuzde";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clYuzde.DefaultCellStyle = dataGridViewCellStyle5;
            this.clYuzde.HeaderText = "Resimli Yüzde (%)";
            this.clYuzde.Name = "clYuzde";
            this.clYuzde.ReadOnly = true;
            this.clYuzde.Width = 60;
            // 
            // frmINTERNETresimlerrapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 426);
            this.Controls.Add(this.lblYuzde);
            this.Controls.Add(this.lblResimsizUrun);
            this.Controls.Add(this.lblResimliUrun);
            this.Controls.Add(this.lblToplamUrun);
            this.Controls.Add(this.btnIstatistik);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnResimsizTedarikciler);
            this.Controls.Add(this.dgv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(653, 464);
            this.MinimumSize = new System.Drawing.Size(653, 464);
            this.Name = "frmINTERNETresimlerrapor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rapor";
            this.Load += new System.EventHandler(this.frmINTERNETresimlerrapor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnResimsizTedarikciler;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIstatistik;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblToplamUrun;
        private System.Windows.Forms.Label lblResimliUrun;
        private System.Windows.Forms.Label lblResimsizUrun;
        private System.Windows.Forms.Label lblYuzde;
        private System.Windows.Forms.DataGridViewTextBoxColumn clOZELACIK;
        private System.Windows.Forms.DataGridViewTextBoxColumn clToplamUrunSayisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn clResimliUrunSayisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn clResimsizUrunSayisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn clYuzde;
    }
}