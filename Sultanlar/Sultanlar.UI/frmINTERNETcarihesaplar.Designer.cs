namespace Sultanlar.UI
{
    partial class frmINTERNETsatistemsilcileri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmINTERNETsatistemsilcileri));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtMUSTERI = new System.Windows.Forms.TextBox();
            this.btnAra = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.clGMREF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clACTIVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clILGILI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clMUSKOD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clMUSTERI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clMTACIKLAMA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSATTEM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clVRGDAIRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clVRGNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTELEFON = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clGMREF,
            this.clACTIVE,
            this.clILGILI,
            this.clMUSKOD,
            this.clMUSTERI,
            this.clMTACIKLAMA,
            this.clSATTEM,
            this.clVRGDAIRE,
            this.clVRGNO,
            this.clTELEFON});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(964, 305);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // txtMUSTERI
            // 
            this.txtMUSTERI.Location = new System.Drawing.Point(124, 8);
            this.txtMUSTERI.Name = "txtMUSTERI";
            this.txtMUSTERI.Size = new System.Drawing.Size(251, 20);
            this.txtMUSTERI.TabIndex = 1;
            this.txtMUSTERI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMUSTERI_KeyDown);
            // 
            // btnAra
            // 
            this.btnAra.Location = new System.Drawing.Point(381, 6);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(75, 23);
            this.btnAra.TabIndex = 2;
            this.btnAra.Text = "Ara";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(964, 35);
            this.label1.TabIndex = 3;
            this.label1.Text = " Müşteriye Göre Arama:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // clGMREF
            // 
            this.clGMREF.DataPropertyName = "GMREF";
            this.clGMREF.HeaderText = "GMREF";
            this.clGMREF.Name = "clGMREF";
            this.clGMREF.ReadOnly = true;
            this.clGMREF.Visible = false;
            this.clGMREF.Width = 70;
            // 
            // clACTIVE
            // 
            this.clACTIVE.DataPropertyName = "ACTIVE";
            this.clACTIVE.HeaderText = "ACTIVE";
            this.clACTIVE.Name = "clACTIVE";
            this.clACTIVE.ReadOnly = true;
            this.clACTIVE.Width = 70;
            // 
            // clILGILI
            // 
            this.clILGILI.DataPropertyName = "ILGILI";
            this.clILGILI.HeaderText = "İLGİLİ";
            this.clILGILI.Name = "clILGILI";
            this.clILGILI.ReadOnly = true;
            this.clILGILI.Width = 61;
            // 
            // clMUSKOD
            // 
            this.clMUSKOD.DataPropertyName = "MUS KOD";
            this.clMUSKOD.HeaderText = "MÜŞTERİ KODU";
            this.clMUSKOD.Name = "clMUSKOD";
            this.clMUSKOD.ReadOnly = true;
            this.clMUSKOD.Width = 105;
            // 
            // clMUSTERI
            // 
            this.clMUSTERI.DataPropertyName = "MUSTERI";
            this.clMUSTERI.HeaderText = "MÜŞTERİ";
            this.clMUSTERI.Name = "clMUSTERI";
            this.clMUSTERI.ReadOnly = true;
            this.clMUSTERI.Width = 81;
            // 
            // clMTACIKLAMA
            // 
            this.clMTACIKLAMA.DataPropertyName = "MT ACIKLAMA";
            this.clMTACIKLAMA.HeaderText = "MÜŞTERİ AÇIKLAMA";
            this.clMTACIKLAMA.Name = "clMTACIKLAMA";
            this.clMTACIKLAMA.ReadOnly = true;
            this.clMTACIKLAMA.Width = 125;
            // 
            // clSATTEM
            // 
            this.clSATTEM.DataPropertyName = "SAT TEM";
            this.clSATTEM.HeaderText = "SAT.TEM.";
            this.clSATTEM.Name = "clSATTEM";
            this.clSATTEM.ReadOnly = true;
            this.clSATTEM.Width = 82;
            // 
            // clVRGDAIRE
            // 
            this.clVRGDAIRE.DataPropertyName = "VRG DAIRE";
            this.clVRGDAIRE.HeaderText = "VERGİ DAİRE";
            this.clVRGDAIRE.Name = "clVRGDAIRE";
            this.clVRGDAIRE.ReadOnly = true;
            this.clVRGDAIRE.Width = 93;
            // 
            // clVRGNO
            // 
            this.clVRGNO.DataPropertyName = "VRG NO";
            this.clVRGNO.HeaderText = "VERGİ NO";
            this.clVRGNO.Name = "clVRGNO";
            this.clVRGNO.ReadOnly = true;
            this.clVRGNO.Width = 78;
            // 
            // clTELEFON
            // 
            this.clTELEFON.DataPropertyName = "TEL-1";
            this.clTELEFON.HeaderText = "TELEFON";
            this.clTELEFON.Name = "clTELEFON";
            this.clTELEFON.ReadOnly = true;
            this.clTELEFON.Width = 81;
            // 
            // frmINTERNETsatistemsilcileri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 340);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.txtMUSTERI);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmINTERNETsatistemsilcileri";
            this.Text = "Cari Hesaplar";
            this.Load += new System.EventHandler(this.frmINTERNETcarihesaplar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtMUSTERI;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clGMREF;
        private System.Windows.Forms.DataGridViewTextBoxColumn clACTIVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn clILGILI;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMUSKOD;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMUSTERI;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMTACIKLAMA;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSATTEM;
        private System.Windows.Forms.DataGridViewTextBoxColumn clVRGDAIRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn clVRGNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTELEFON;
    }
}