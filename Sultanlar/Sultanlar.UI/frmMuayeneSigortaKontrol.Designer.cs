namespace Sultanlar.UI
{
    partial class frmMuayeneSigortaKontrol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMuayeneSigortaKontrol));
            this.dgvMuayeneler = new System.Windows.Forms.DataGridView();
            this.dgvSigortalar = new System.Windows.Forms.DataGridView();
            this.clstrArabaPlaka2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cldtSigortaBitis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrArabaPlaka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cldtMuayeneBitis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMuayeneler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSigortalar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMuayeneler
            // 
            this.dgvMuayeneler.AllowUserToAddRows = false;
            this.dgvMuayeneler.AllowUserToDeleteRows = false;
            this.dgvMuayeneler.AllowUserToResizeColumns = false;
            this.dgvMuayeneler.AllowUserToResizeRows = false;
            this.dgvMuayeneler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMuayeneler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clstrArabaPlaka,
            this.cldtMuayeneBitis});
            this.dgvMuayeneler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMuayeneler.Location = new System.Drawing.Point(0, 0);
            this.dgvMuayeneler.MultiSelect = false;
            this.dgvMuayeneler.Name = "dgvMuayeneler";
            this.dgvMuayeneler.ReadOnly = true;
            this.dgvMuayeneler.RowHeadersVisible = false;
            this.dgvMuayeneler.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvMuayeneler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMuayeneler.Size = new System.Drawing.Size(324, 176);
            this.dgvMuayeneler.TabIndex = 1;
            this.dgvMuayeneler.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMuayeneler_CellClick);
            // 
            // dgvSigortalar
            // 
            this.dgvSigortalar.AllowUserToAddRows = false;
            this.dgvSigortalar.AllowUserToDeleteRows = false;
            this.dgvSigortalar.AllowUserToResizeColumns = false;
            this.dgvSigortalar.AllowUserToResizeRows = false;
            this.dgvSigortalar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSigortalar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clstrArabaPlaka2,
            this.cldtSigortaBitis});
            this.dgvSigortalar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSigortalar.Location = new System.Drawing.Point(0, 0);
            this.dgvSigortalar.MultiSelect = false;
            this.dgvSigortalar.Name = "dgvSigortalar";
            this.dgvSigortalar.ReadOnly = true;
            this.dgvSigortalar.RowHeadersVisible = false;
            this.dgvSigortalar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvSigortalar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSigortalar.Size = new System.Drawing.Size(324, 176);
            this.dgvSigortalar.TabIndex = 2;
            this.dgvSigortalar.Visible = false;
            this.dgvSigortalar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSigortalar_CellClick);
            // 
            // clstrArabaPlaka2
            // 
            this.clstrArabaPlaka2.DataPropertyName = "strArabaPlaka";
            this.clstrArabaPlaka2.HeaderText = "Plaka";
            this.clstrArabaPlaka2.Name = "clstrArabaPlaka2";
            this.clstrArabaPlaka2.ReadOnly = true;
            this.clstrArabaPlaka2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clstrArabaPlaka2.Width = 120;
            // 
            // cldtSigortaBitis
            // 
            this.cldtSigortaBitis.DataPropertyName = "dtSigortaBitis";
            this.cldtSigortaBitis.HeaderText = "Sigorta Bitiş";
            this.cldtSigortaBitis.Name = "cldtSigortaBitis";
            this.cldtSigortaBitis.ReadOnly = true;
            this.cldtSigortaBitis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cldtSigortaBitis.Width = 200;
            // 
            // clstrArabaPlaka
            // 
            this.clstrArabaPlaka.DataPropertyName = "strArabaPlaka";
            this.clstrArabaPlaka.HeaderText = "Plaka";
            this.clstrArabaPlaka.Name = "clstrArabaPlaka";
            this.clstrArabaPlaka.ReadOnly = true;
            this.clstrArabaPlaka.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clstrArabaPlaka.Width = 120;
            // 
            // cldtMuayeneBitis
            // 
            this.cldtMuayeneBitis.DataPropertyName = "dtMuayeneBitis";
            this.cldtMuayeneBitis.HeaderText = "Muayene Bitiş";
            this.cldtMuayeneBitis.Name = "cldtMuayeneBitis";
            this.cldtMuayeneBitis.ReadOnly = true;
            this.cldtMuayeneBitis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cldtMuayeneBitis.Width = 200;
            // 
            // frmMuayeneSigortaKontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 176);
            this.Controls.Add(this.dgvSigortalar);
            this.Controls.Add(this.dgvMuayeneler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(330, 200);
            this.MinimumSize = new System.Drawing.Size(330, 200);
            this.Name = "frmMuayeneSigortaKontrol";
            this.Text = "Muayene Sigorta Kontrol";
            this.Load += new System.EventHandler(this.frmMuayeneSigortaKontrol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMuayeneler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSigortalar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMuayeneler;
        private System.Windows.Forms.DataGridView dgvSigortalar;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrArabaPlaka;
        private System.Windows.Forms.DataGridViewTextBoxColumn cldtMuayeneBitis;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrArabaPlaka2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cldtSigortaBitis;
    }
}