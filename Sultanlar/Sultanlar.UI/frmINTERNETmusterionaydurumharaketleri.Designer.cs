namespace Sultanlar.UI
{
    partial class frmINTERNETmusterionaydurumharaketleri
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clpkID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clintMusteriID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cltintDurumID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrAdSoyad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrDurum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cldtZaman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrKullanici = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.clintMusteriID,
            this.cltintDurumID,
            this.clstrAdSoyad,
            this.clstrDurum,
            this.cldtZaman,
            this.clstrKullanici});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(822, 332);
            this.dataGridView1.TabIndex = 0;
            // 
            // clpkID
            // 
            this.clpkID.DataPropertyName = "pkID";
            this.clpkID.HeaderText = "pkID";
            this.clpkID.Name = "clpkID";
            this.clpkID.ReadOnly = true;
            this.clpkID.Visible = false;
            // 
            // clintMusteriID
            // 
            this.clintMusteriID.DataPropertyName = "intMusteriID";
            this.clintMusteriID.HeaderText = "intMusteriID";
            this.clintMusteriID.Name = "clintMusteriID";
            this.clintMusteriID.ReadOnly = true;
            this.clintMusteriID.Visible = false;
            // 
            // cltintDurumID
            // 
            this.cltintDurumID.DataPropertyName = "tintDurumID";
            this.cltintDurumID.HeaderText = "tintDurumID";
            this.cltintDurumID.Name = "cltintDurumID";
            this.cltintDurumID.ReadOnly = true;
            this.cltintDurumID.Visible = false;
            // 
            // clstrAdSoyad
            // 
            this.clstrAdSoyad.DataPropertyName = "strAdSoyad";
            this.clstrAdSoyad.HeaderText = "Müşteri";
            this.clstrAdSoyad.Name = "clstrAdSoyad";
            this.clstrAdSoyad.ReadOnly = true;
            this.clstrAdSoyad.Width = 200;
            // 
            // clstrDurum
            // 
            this.clstrDurum.DataPropertyName = "strDurum";
            this.clstrDurum.HeaderText = "Durum";
            this.clstrDurum.Name = "clstrDurum";
            this.clstrDurum.ReadOnly = true;
            this.clstrDurum.Width = 300;
            // 
            // cldtZaman
            // 
            this.cldtZaman.DataPropertyName = "dtZaman";
            dataGridViewCellStyle1.Format = "G";
            dataGridViewCellStyle1.NullValue = null;
            this.cldtZaman.DefaultCellStyle = dataGridViewCellStyle1;
            this.cldtZaman.HeaderText = "İşlem Zamanı";
            this.cldtZaman.Name = "cldtZaman";
            this.cldtZaman.ReadOnly = true;
            this.cldtZaman.Width = 150;
            // 
            // clstrKullanici
            // 
            this.clstrKullanici.DataPropertyName = "strKullanici";
            this.clstrKullanici.HeaderText = "İşlem Yapan Kullanıcı";
            this.clstrKullanici.Name = "clstrKullanici";
            this.clstrKullanici.ReadOnly = true;
            this.clstrKullanici.Width = 150;
            // 
            // frmINTERNETmusterionaydurumharaketleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 332);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmINTERNETmusterionaydurumharaketleri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Müşteri Onay Durumu İşlem Geçmişi";
            this.Load += new System.EventHandler(this.frmINTERNETmusterionaydurumharaketleri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clpkID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clintMusteriID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cltintDurumID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrAdSoyad;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrDurum;
        private System.Windows.Forms.DataGridViewTextBoxColumn cldtZaman;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrKullanici;
    }
}