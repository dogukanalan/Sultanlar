namespace Sultanlar.UI
{
    partial class frmINTERNETurunaktifpasiflog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmINTERNETurunaktifpasiflog));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcanAP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanstrKullanici = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcandtTarih = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.White;
            this.gridControl1.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black;
            this.gridControl1.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridControl1.EmbeddedNavigator.Appearance.Options.UseForeColor = true;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(391, 412);
            this.gridControl1.TabIndex = 41;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcanAP,
            this.gcanstrKullanici,
            this.gcandtTarih});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gcanAP
            // 
            this.gcanAP.AppearanceCell.Options.UseTextOptions = true;
            this.gcanAP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcanAP.AppearanceHeader.Options.UseTextOptions = true;
            this.gcanAP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcanAP.Caption = "Aktif-Pasif";
            this.gcanAP.FieldName = "AP";
            this.gcanAP.Name = "gcanAP";
            this.gcanAP.OptionsColumn.AllowEdit = false;
            this.gcanAP.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.gcanAP.Visible = true;
            this.gcanAP.VisibleIndex = 0;
            // 
            // gcanstrKullanici
            // 
            this.gcanstrKullanici.AppearanceCell.Options.UseTextOptions = true;
            this.gcanstrKullanici.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcanstrKullanici.AppearanceHeader.Options.UseTextOptions = true;
            this.gcanstrKullanici.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcanstrKullanici.Caption = "Kullanıcı";
            this.gcanstrKullanici.FieldName = "strKullanici";
            this.gcanstrKullanici.Name = "gcanstrKullanici";
            this.gcanstrKullanici.OptionsColumn.AllowEdit = false;
            this.gcanstrKullanici.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanstrKullanici.Visible = true;
            this.gcanstrKullanici.VisibleIndex = 1;
            this.gcanstrKullanici.Width = 120;
            // 
            // gcandtTarih
            // 
            this.gcandtTarih.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.5F);
            this.gcandtTarih.AppearanceCell.Options.UseTextOptions = true;
            this.gcandtTarih.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcandtTarih.AppearanceHeader.Options.UseTextOptions = true;
            this.gcandtTarih.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcandtTarih.Caption = "Tarih";
            this.gcandtTarih.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcandtTarih.FieldName = "dtTarih";
            this.gcandtTarih.Name = "gcandtTarih";
            this.gcandtTarih.OptionsColumn.AllowEdit = false;
            this.gcandtTarih.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcandtTarih.Visible = true;
            this.gcandtTarih.VisibleIndex = 2;
            this.gcandtTarih.Width = 160;
            // 
            // frmINTERNETurunaktifpasiflog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 412);
            this.Controls.Add(this.gridControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmINTERNETurunaktifpasiflog";
            this.Text = "Ürün Kullanım Seçimi Geçmişi";
            this.Load += new System.EventHandler(this.frmINTERNETurunaktifpasiflog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gcanstrKullanici;
        private DevExpress.XtraGrid.Columns.GridColumn gcandtTarih;
        private DevExpress.XtraGrid.Columns.GridColumn gcanAP;
    }
}