
namespace Sultanlar.UI
{
    partial class frmINTERNEThedeforan
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmINTERNEThedeforan));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.webHedef3BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kurumsalWebSAPDataSet1 = new Sultanlar.UI.KurumsalWebSAPDataSet1();
            this.web_Hedef_3TableAdapter = new Sultanlar.UI.KurumsalWebSAPDataSet1TableAdapters.Web_Hedef_3TableAdapter();
            this.ıTEMREFDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MALZEME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lIMITDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webHedef3BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kurumsalWebSAPDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ıTEMREFDataGridViewTextBoxColumn,
            this.MALZEME,
            this.lIMITDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.webHedef3BindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(800, 450);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // webHedef3BindingSource
            // 
            this.webHedef3BindingSource.DataMember = "Web-Hedef-3";
            this.webHedef3BindingSource.DataSource = this.kurumsalWebSAPDataSet1;
            // 
            // kurumsalWebSAPDataSet1
            // 
            this.kurumsalWebSAPDataSet1.DataSetName = "KurumsalWebSAPDataSet1";
            this.kurumsalWebSAPDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // web_Hedef_3TableAdapter
            // 
            this.web_Hedef_3TableAdapter.ClearBeforeFill = true;
            // 
            // ıTEMREFDataGridViewTextBoxColumn
            // 
            this.ıTEMREFDataGridViewTextBoxColumn.DataPropertyName = "ITEMREF";
            this.ıTEMREFDataGridViewTextBoxColumn.HeaderText = "SAP No";
            this.ıTEMREFDataGridViewTextBoxColumn.Name = "ıTEMREFDataGridViewTextBoxColumn";
            // 
            // MALZEME
            // 
            this.MALZEME.DataPropertyName = "MALZEME";
            this.MALZEME.HeaderText = "MALZEME";
            this.MALZEME.Name = "MALZEME";
            this.MALZEME.Width = 500;
            // 
            // lIMITDataGridViewTextBoxColumn
            // 
            this.lIMITDataGridViewTextBoxColumn.DataPropertyName = "LIMIT";
            this.lIMITDataGridViewTextBoxColumn.HeaderText = "Limit Oranı (Yüzde)";
            this.lIMITDataGridViewTextBoxColumn.Name = "lIMITDataGridViewTextBoxColumn";
            this.lIMITDataGridViewTextBoxColumn.Width = 120;
            // 
            // frmINTERNEThedeforan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmINTERNEThedeforan";
            this.Text = "Hedef : Limit Oranları";
            this.Load += new System.EventHandler(this.frmINTERNEThedeforan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webHedef3BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kurumsalWebSAPDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private KurumsalWebSAPDataSet1 kurumsalWebSAPDataSet1;
        private System.Windows.Forms.BindingSource webHedef3BindingSource;
        private KurumsalWebSAPDataSet1TableAdapters.Web_Hedef_3TableAdapter web_Hedef_3TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ıTEMREFDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MALZEME;
        private System.Windows.Forms.DataGridViewTextBoxColumn lIMITDataGridViewTextBoxColumn;
    }
}