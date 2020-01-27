namespace Sultanlar.UI
{
    partial class frmINTERNETsatistemsilcileri1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmINTERNETsatistemsilcileri1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clSLSMANREF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSATKOD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSATKOD1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSATTEM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTELEFON = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAra = new System.Windows.Forms.Button();
            this.txtSATTEM = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.clSLSMANREF,
            this.clSATKOD,
            this.clSATKOD1,
            this.clSATTEM,
            this.clTELEFON});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(784, 302);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // clSLSMANREF
            // 
            this.clSLSMANREF.DataPropertyName = "SLSMANREF";
            this.clSLSMANREF.HeaderText = "SLSREF";
            this.clSLSMANREF.Name = "clSLSMANREF";
            this.clSLSMANREF.ReadOnly = true;
            this.clSLSMANREF.Visible = false;
            this.clSLSMANREF.Width = 73;
            // 
            // clSATKOD
            // 
            this.clSATKOD.DataPropertyName = "SAT KOD";
            this.clSATKOD.HeaderText = "SAT KOD";
            this.clSATKOD.Name = "clSATKOD";
            this.clSATKOD.ReadOnly = true;
            this.clSATKOD.Width = 73;
            // 
            // clSATKOD1
            // 
            this.clSATKOD1.DataPropertyName = "SAT KOD1";
            this.clSATKOD1.HeaderText = "SAT KOD 1";
            this.clSATKOD1.Name = "clSATKOD1";
            this.clSATKOD1.ReadOnly = true;
            this.clSATKOD1.Width = 73;
            // 
            // clSATTEM
            // 
            this.clSATTEM.DataPropertyName = "SAT TEM";
            this.clSATTEM.HeaderText = "SATIŞ TEMSİLCİSİ";
            this.clSATTEM.Name = "clSATTEM";
            this.clSATTEM.ReadOnly = true;
            this.clSATTEM.Width = 115;
            // 
            // clTELEFON
            // 
            this.clTELEFON.DataPropertyName = "TELEFON";
            this.clTELEFON.HeaderText = "TELEFON";
            this.clTELEFON.Name = "clTELEFON";
            this.clTELEFON.ReadOnly = true;
            this.clTELEFON.Width = 81;
            // 
            // btnAra
            // 
            this.btnAra.Location = new System.Drawing.Point(381, 6);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(75, 23);
            this.btnAra.TabIndex = 6;
            this.btnAra.Text = "Ara";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // txtSATTEM
            // 
            this.txtSATTEM.Location = new System.Drawing.Point(156, 8);
            this.txtSATTEM.Name = "txtSATTEM";
            this.txtSATTEM.Size = new System.Drawing.Size(219, 20);
            this.txtSATTEM.TabIndex = 5;
            this.txtSATTEM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSATTEM_KeyDown);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(784, 35);
            this.label1.TabIndex = 7;
            this.label1.Text = "Satış Temsilcisine Göre Arama:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmINTERNETsatistemsilcileri1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 337);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.txtSATTEM);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmINTERNETsatistemsilcileri1";
            this.Text = "Satış Temsilcileri";
            this.Load += new System.EventHandler(this.frmINTERNETsatistemsilcileri1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.TextBox txtSATTEM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSLSMANREF;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSATKOD;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSATKOD1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSATTEM;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTELEFON;
    }
}