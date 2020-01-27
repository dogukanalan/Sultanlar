namespace Sultanlar.UI
{
    partial class frmINTERNETticaripazarlamabayistoklar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmINTERNETticaripazarlamabayistoklar));
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbAy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbYil = new System.Windows.Forms.ComboBox();
            this.cmbBayiler = new System.Windows.Forms.ComboBox();
            this.sbDonemSil = new DevExpress.XtraEditors.SimpleButton();
            this.sbGetir = new DevExpress.XtraEditors.SimpleButton();
            this.sbExcel = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn45 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblUst = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(445, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Ay:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(346, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Yıl:";
            // 
            // cmbAy
            // 
            this.cmbAy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAy.FormattingEnabled = true;
            this.cmbAy.Items.AddRange(new object[] {
            "Hepsi",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmbAy.Location = new System.Drawing.Point(473, 11);
            this.cmbAy.Name = "cmbAy";
            this.cmbAy.Size = new System.Drawing.Size(55, 21);
            this.cmbAy.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Bayi:";
            // 
            // cmbYil
            // 
            this.cmbYil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYil.FormattingEnabled = true;
            this.cmbYil.Items.AddRange(new object[] {
            "Hepsi",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023"});
            this.cmbYil.Location = new System.Drawing.Point(373, 11);
            this.cmbYil.Name = "cmbYil";
            this.cmbYil.Size = new System.Drawing.Size(55, 21);
            this.cmbYil.TabIndex = 21;
            // 
            // cmbBayiler
            // 
            this.cmbBayiler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBayiler.FormattingEnabled = true;
            this.cmbBayiler.Location = new System.Drawing.Point(40, 11);
            this.cmbBayiler.Name = "cmbBayiler";
            this.cmbBayiler.Size = new System.Drawing.Size(289, 21);
            this.cmbBayiler.TabIndex = 19;
            // 
            // sbDonemSil
            // 
            this.sbDonemSil.Location = new System.Drawing.Point(755, 10);
            this.sbDonemSil.Name = "sbDonemSil";
            this.sbDonemSil.Size = new System.Drawing.Size(98, 23);
            this.sbDonemSil.TabIndex = 16;
            this.sbDonemSil.Text = "Dönemi Sil";
            this.sbDonemSil.ToolTip = "Seçim yapılan bayinin seçilen dönemini siler";
            this.sbDonemSil.Click += new System.EventHandler(this.sbDonemSil_Click);
            // 
            // sbGetir
            // 
            this.sbGetir.Location = new System.Drawing.Point(547, 10);
            this.sbGetir.Name = "sbGetir";
            this.sbGetir.Size = new System.Drawing.Size(98, 23);
            this.sbGetir.TabIndex = 17;
            this.sbGetir.Text = "Getir";
            this.sbGetir.Click += new System.EventHandler(this.sbGetir_Click);
            // 
            // sbExcel
            // 
            this.sbExcel.Location = new System.Drawing.Point(651, 10);
            this.sbExcel.Name = "sbExcel";
            this.sbExcel.Size = new System.Drawing.Size(98, 23);
            this.sbExcel.TabIndex = 18;
            this.sbExcel.Text = "Excel\'den Veri Al";
            this.sbExcel.Click += new System.EventHandler(this.sbExcel_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.White;
            this.gridControl1.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black;
            this.gridControl1.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridControl1.EmbeddedNavigator.Appearance.Options.UseForeColor = true;
            this.gridControl1.Location = new System.Drawing.Point(0, 43);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(874, 438);
            this.gridControl1.TabIndex = 14;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn45,
            this.gridColumn10,
            this.gridColumn9,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn5,
            this.gridColumn27});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.ViewCaption = "Satış Raporu";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "SMREF";
            this.gridColumn1.FieldName = "SMREF";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn45
            // 
            this.gridColumn45.Caption = "Bayi";
            this.gridColumn45.FieldName = "BAYI";
            this.gridColumn45.Name = "gridColumn45";
            this.gridColumn45.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn45.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.gridColumn45.Visible = true;
            this.gridColumn45.VisibleIndex = 0;
            this.gridColumn45.Width = 200;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Yıl";
            this.gridColumn10.FieldName = "YIL";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 1;
            this.gridColumn10.Width = 50;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Ay";
            this.gridColumn9.FieldName = "AY";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 2;
            this.gridColumn9.Width = 50;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Ür.Kod";
            this.gridColumn6.FieldName = "ITEMREF";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 70;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Ürün";
            this.gridColumn7.FieldName = "URUN";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            this.gridColumn7.Width = 250;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Stok";
            this.gridColumn8.FieldName = "STOK";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            this.gridColumn8.Width = 65;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Eklenme Tarihi";
            this.gridColumn5.FieldName = "ZAMAN";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 6;
            this.gridColumn5.Width = 85;
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "Mevc.Stok";
            this.gridColumn27.FieldName = "TOPLAMSTOK";
            this.gridColumn27.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 7;
            this.gridColumn27.Width = 65;
            // 
            // lblUst
            // 
            this.lblUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUst.Location = new System.Drawing.Point(0, 0);
            this.lblUst.Name = "lblUst";
            this.lblUst.Size = new System.Drawing.Size(874, 43);
            this.lblUst.TabIndex = 15;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 455);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(326, 23);
            this.progressBar1.TabIndex = 25;
            this.progressBar1.Visible = false;
            // 
            // frmINTERNETticaripazarlamabayistoklar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 481);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbAy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbYil);
            this.Controls.Add(this.cmbBayiler);
            this.Controls.Add(this.sbDonemSil);
            this.Controls.Add(this.sbGetir);
            this.Controls.Add(this.sbExcel);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.lblUst);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmINTERNETticaripazarlamabayistoklar";
            this.Text = "Bayi Stokları";
            this.Load += new System.EventHandler(this.frmINTERNETticaripazarlamabayistoklar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbAy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbYil;
        private System.Windows.Forms.ComboBox cmbBayiler;
        private DevExpress.XtraEditors.SimpleButton sbDonemSil;
        private DevExpress.XtraEditors.SimpleButton sbGetir;
        private DevExpress.XtraEditors.SimpleButton sbExcel;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn45;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private System.Windows.Forms.Label lblUst;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}