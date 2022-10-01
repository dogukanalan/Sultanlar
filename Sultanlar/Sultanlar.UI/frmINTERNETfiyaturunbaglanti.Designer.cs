namespace Sultanlar.UI
{
    partial class frmINTERNETfiyaturunbaglanti
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmINTERNETfiyaturunbaglanti));
            this.btnYenile = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcanTIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanITEMREF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanMALZEME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblAlt = new System.Windows.Forms.Label();
            this.sbEkle = new DevExpress.XtraEditors.SimpleButton();
            this.sbHizliSil = new DevExpress.XtraEditors.SimpleButton();
            this.sbKopyala = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnYenile
            // 
            this.btnYenile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnYenile.Image = global::Sultanlar.UI.Properties.Resources.Refresh_icon;
            this.btnYenile.Location = new System.Drawing.Point(0, 0);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(24, 24);
            this.btnYenile.TabIndex = 37;
            this.btnYenile.UseVisualStyleBackColor = true;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
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
            this.gridControl1.Size = new System.Drawing.Size(676, 444);
            this.gridControl1.TabIndex = 35;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcanTIP,
            this.gcanITEMREF,
            this.gcanMALZEME});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.ViewCaption = "Ürün-Fiyat Tipi Bağlantısı";
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            // 
            // gcanTIP
            // 
            this.gcanTIP.AppearanceCell.Options.UseTextOptions = true;
            this.gcanTIP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcanTIP.AppearanceHeader.Options.UseTextOptions = true;
            this.gcanTIP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcanTIP.Caption = "Tip";
            this.gcanTIP.FieldName = "TIP";
            this.gcanTIP.Name = "gcanTIP";
            this.gcanTIP.OptionsColumn.AllowEdit = false;
            this.gcanTIP.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanTIP.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.gcanTIP.Visible = true;
            this.gcanTIP.VisibleIndex = 0;
            this.gcanTIP.Width = 50;
            // 
            // gcanITEMREF
            // 
            this.gcanITEMREF.AppearanceCell.Options.UseTextOptions = true;
            this.gcanITEMREF.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcanITEMREF.AppearanceHeader.Options.UseTextOptions = true;
            this.gcanITEMREF.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcanITEMREF.Caption = "Kod";
            this.gcanITEMREF.FieldName = "ITEMREF";
            this.gcanITEMREF.Name = "gcanITEMREF";
            this.gcanITEMREF.OptionsColumn.AllowEdit = false;
            this.gcanITEMREF.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanITEMREF.Visible = true;
            this.gcanITEMREF.VisibleIndex = 1;
            this.gcanITEMREF.Width = 60;
            // 
            // gcanMALZEME
            // 
            this.gcanMALZEME.AppearanceHeader.Options.UseTextOptions = true;
            this.gcanMALZEME.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcanMALZEME.Caption = "Malzeme";
            this.gcanMALZEME.FieldName = "MALZEME";
            this.gcanMALZEME.Name = "gcanMALZEME";
            this.gcanMALZEME.OptionsColumn.AllowEdit = false;
            this.gcanMALZEME.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanMALZEME.Visible = true;
            this.gcanMALZEME.VisibleIndex = 2;
            this.gcanMALZEME.Width = 530;
            // 
            // lblAlt
            // 
            this.lblAlt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAlt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblAlt.Location = new System.Drawing.Point(0, 444);
            this.lblAlt.Name = "lblAlt";
            this.lblAlt.Size = new System.Drawing.Size(676, 29);
            this.lblAlt.TabIndex = 36;
            // 
            // sbEkle
            // 
            this.sbEkle.Location = new System.Drawing.Point(12, 447);
            this.sbEkle.Name = "sbEkle";
            this.sbEkle.Size = new System.Drawing.Size(125, 23);
            this.sbEkle.TabIndex = 38;
            this.sbEkle.Text = "Ekleme-Çıkarma İşlemi";
            this.sbEkle.Click += new System.EventHandler(this.sbEkle_Click);
            // 
            // sbHizliSil
            // 
            this.sbHizliSil.Location = new System.Drawing.Point(539, 447);
            this.sbHizliSil.Name = "sbHizliSil";
            this.sbHizliSil.Size = new System.Drawing.Size(125, 23);
            this.sbHizliSil.TabIndex = 38;
            this.sbHizliSil.Text = "Hızlı Silme";
            this.sbHizliSil.ToolTip = "Seçili satırı siler";
            this.sbHizliSil.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.sbHizliSil.Visible = false;
            this.sbHizliSil.Click += new System.EventHandler(this.sbHizliSil_Click);
            // 
            // sbKopyala
            // 
            this.sbKopyala.Location = new System.Drawing.Point(143, 447);
            this.sbKopyala.Name = "sbKopyala";
            this.sbKopyala.Size = new System.Drawing.Size(125, 23);
            this.sbKopyala.TabIndex = 38;
            this.sbKopyala.Text = "Cariden Kopyalama";
            this.sbKopyala.Click += new System.EventHandler(this.sbKopyala_Click);
            // 
            // frmINTERNETfiyaturunbaglanti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 473);
            this.Controls.Add(this.sbHizliSil);
            this.Controls.Add(this.sbKopyala);
            this.Controls.Add(this.sbEkle);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.lblAlt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmINTERNETfiyaturunbaglanti";
            this.Text = "Ürün Fiyat Bağlantı Ekranı";
            this.Load += new System.EventHandler(this.frmINTERNETfiyaturunbaglanti_Load);
            this.SizeChanged += new System.EventHandler(this.frmINTERNETfiyaturunbaglanti_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnYenile;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gcanTIP;
        private DevExpress.XtraGrid.Columns.GridColumn gcanITEMREF;
        private DevExpress.XtraGrid.Columns.GridColumn gcanMALZEME;
        private System.Windows.Forms.Label lblAlt;
        private DevExpress.XtraEditors.SimpleButton sbEkle;
        private DevExpress.XtraEditors.SimpleButton sbHizliSil;
        private DevExpress.XtraEditors.SimpleButton sbKopyala;
    }
}