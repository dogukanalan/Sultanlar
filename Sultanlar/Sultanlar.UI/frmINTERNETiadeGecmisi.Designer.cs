namespace Sultanlar.UI
{
    partial class frmINTERNETiadeGecmisi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmINTERNETiadeGecmisi));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clpkID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clintIadeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clintIadeHareketTurID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrIadeHareketTur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cldtTarih = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrIslemYapan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrAciklama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clpkID,
            this.clintIadeID,
            this.clintIadeHareketTurID,
            this.clstrIadeHareketTur,
            this.cldtTarih,
            this.clstrIslemYapan,
            this.clstrAciklama});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(769, 348);
            this.dataGridView1.TabIndex = 1;
            // 
            // clpkID
            // 
            this.clpkID.DataPropertyName = "pkID";
            this.clpkID.HeaderText = "pkID";
            this.clpkID.Name = "clpkID";
            this.clpkID.ReadOnly = true;
            this.clpkID.Visible = false;
            // 
            // clintIadeID
            // 
            this.clintIadeID.DataPropertyName = "intIadeID";
            this.clintIadeID.HeaderText = "intIadeID";
            this.clintIadeID.Name = "clintIadeID";
            this.clintIadeID.ReadOnly = true;
            this.clintIadeID.Visible = false;
            // 
            // clintIadeHareketTurID
            // 
            this.clintIadeHareketTurID.DataPropertyName = "intIadeHareketTurID";
            this.clintIadeHareketTurID.HeaderText = "intIadeHareketTurID";
            this.clintIadeHareketTurID.Name = "clintIadeHareketTurID";
            this.clintIadeHareketTurID.ReadOnly = true;
            this.clintIadeHareketTurID.Visible = false;
            // 
            // clstrIadeHareketTur
            // 
            this.clstrIadeHareketTur.DataPropertyName = "strIadeHareketTur";
            this.clstrIadeHareketTur.HeaderText = "Hareket";
            this.clstrIadeHareketTur.Name = "clstrIadeHareketTur";
            this.clstrIadeHareketTur.ReadOnly = true;
            this.clstrIadeHareketTur.Width = 190;
            // 
            // cldtTarih
            // 
            this.cldtTarih.DataPropertyName = "dtTarih";
            dataGridViewCellStyle1.Format = "G";
            dataGridViewCellStyle1.NullValue = null;
            this.cldtTarih.DefaultCellStyle = dataGridViewCellStyle1;
            this.cldtTarih.HeaderText = "İşlem Tarihi";
            this.cldtTarih.Name = "cldtTarih";
            this.cldtTarih.ReadOnly = true;
            this.cldtTarih.Width = 120;
            // 
            // clstrIslemYapan
            // 
            this.clstrIslemYapan.DataPropertyName = "strIslemYapan";
            this.clstrIslemYapan.HeaderText = "İşlemi Yapan Kullanıcı";
            this.clstrIslemYapan.Name = "clstrIslemYapan";
            this.clstrIslemYapan.ReadOnly = true;
            this.clstrIslemYapan.Width = 140;
            // 
            // clstrAciklama
            // 
            this.clstrAciklama.DataPropertyName = "strAciklama";
            this.clstrAciklama.HeaderText = "Açıklama";
            this.clstrAciklama.Name = "clstrAciklama";
            this.clstrAciklama.ReadOnly = true;
            this.clstrAciklama.Width = 300;
            // 
            // frmINTERNETiadeGecmisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 348);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmINTERNETiadeGecmisi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İade Geçmişi";
            this.Load += new System.EventHandler(this.frmIadeGecmisi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clpkID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clintIadeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clintIadeHareketTurID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrIadeHareketTur;
        private System.Windows.Forms.DataGridViewTextBoxColumn cldtTarih;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrIslemYapan;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrAciklama;
    }
}