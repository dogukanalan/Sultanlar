namespace Sultanlar.UI
{
    partial class frmAT2rotamusteri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAT2rotamusteri));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sbYukari = new DevExpress.XtraEditors.SimpleButton();
            this.sbAsagi = new DevExpress.XtraEditors.SimpleButton();
            this.sbEkle = new DevExpress.XtraEditors.SimpleButton();
            this.sbSil = new DevExpress.XtraEditors.SimpleButton();
            this.sbDetay = new DevExpress.XtraEditors.SimpleButton();
            this.btnYenile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControl1.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.White;
            this.gridControl1.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black;
            this.gridControl1.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridControl1.EmbeddedNavigator.Appearance.Options.UseForeColor = true;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(361, 364);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn2});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.ViewCaption = "Rotalar";
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "pkID";
            this.gridColumn1.FieldName = "pkID";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Bölge";
            this.gridColumn3.FieldName = "strBolge";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 125;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Araç";
            this.gridColumn4.FieldName = "strPlaka";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Rota";
            this.gridColumn2.FieldName = "strRota";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 200;
            // 
            // gridControl2
            // 
            this.gridControl2.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.White;
            this.gridControl2.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black;
            this.gridControl2.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridControl2.EmbeddedNavigator.Appearance.Options.UseForeColor = true;
            this.gridControl2.Location = new System.Drawing.Point(368, 39);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(466, 318);
            this.gridControl2.TabIndex = 7;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn8,
            this.gridColumn7,
            this.gridColumn9,
            this.gridColumn6});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowAutoFilterRow = true;
            this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView2.OptionsView.ShowFooter = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowViewCaption = true;
            this.gridView2.ViewCaption = "Rotadaki Müşteriler";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "pkID";
            this.gridColumn5.FieldName = "pkID";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.Caption = "Sıra";
            this.gridColumn8.FieldName = "intSira";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            this.gridColumn8.Width = 30;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "SMREF";
            this.gridColumn7.FieldName = "SMREF";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "RotaID";
            this.gridColumn9.FieldName = "intRotaID";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Müşteri";
            this.gridColumn6.FieldName = "SUBE";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 400;
            // 
            // sbYukari
            // 
            this.sbYukari.Appearance.Font = new System.Drawing.Font("Tahoma", 7F);
            this.sbYukari.Appearance.Options.UseFont = true;
            this.sbYukari.Location = new System.Drawing.Point(841, 39);
            this.sbYukari.Name = "sbYukari";
            this.sbYukari.Size = new System.Drawing.Size(22, 156);
            this.sbYukari.TabIndex = 8;
            this.sbYukari.Text = "▲";
            this.sbYukari.Click += new System.EventHandler(this.sbYukari_Click);
            // 
            // sbAsagi
            // 
            this.sbAsagi.Appearance.Font = new System.Drawing.Font("Tahoma", 7F);
            this.sbAsagi.Appearance.Options.UseFont = true;
            this.sbAsagi.Location = new System.Drawing.Point(841, 201);
            this.sbAsagi.Name = "sbAsagi";
            this.sbAsagi.Size = new System.Drawing.Size(22, 156);
            this.sbAsagi.TabIndex = 8;
            this.sbAsagi.Text = "▼";
            this.sbAsagi.Click += new System.EventHandler(this.sbAsagi_Click);
            // 
            // sbEkle
            // 
            this.sbEkle.Appearance.Font = new System.Drawing.Font("Tahoma", 7F);
            this.sbEkle.Appearance.Options.UseFont = true;
            this.sbEkle.Location = new System.Drawing.Point(368, 6);
            this.sbEkle.Name = "sbEkle";
            this.sbEkle.Size = new System.Drawing.Size(150, 27);
            this.sbEkle.TabIndex = 8;
            this.sbEkle.Text = "Rotaya Müşteri Ekle";
            this.sbEkle.Click += new System.EventHandler(this.sbEkle_Click);
            // 
            // sbSil
            // 
            this.sbSil.Appearance.Font = new System.Drawing.Font("Tahoma", 7F);
            this.sbSil.Appearance.Options.UseFont = true;
            this.sbSil.Location = new System.Drawing.Point(526, 6);
            this.sbSil.Name = "sbSil";
            this.sbSil.Size = new System.Drawing.Size(150, 27);
            this.sbSil.TabIndex = 8;
            this.sbSil.Text = "Müşteriyi Rotadan Sil";
            this.sbSil.Click += new System.EventHandler(this.sbSil_Click);
            // 
            // sbDetay
            // 
            this.sbDetay.Appearance.Font = new System.Drawing.Font("Tahoma", 7F);
            this.sbDetay.Appearance.Options.UseFont = true;
            this.sbDetay.Location = new System.Drawing.Point(684, 6);
            this.sbDetay.Name = "sbDetay";
            this.sbDetay.Size = new System.Drawing.Size(150, 27);
            this.sbDetay.TabIndex = 8;
            this.sbDetay.Text = "Müşteri Detayı";
            this.sbDetay.Click += new System.EventHandler(this.sbDetay_Click);
            // 
            // btnYenile
            // 
            this.btnYenile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnYenile.Image = global::Sultanlar.UI.Properties.Resources.Refresh_icon;
            this.btnYenile.Location = new System.Drawing.Point(840, 8);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(24, 24);
            this.btnYenile.TabIndex = 33;
            this.btnYenile.UseVisualStyleBackColor = true;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // frmAT2rotamusteri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 364);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.sbAsagi);
            this.Controls.Add(this.sbDetay);
            this.Controls.Add(this.sbSil);
            this.Controls.Add(this.sbEkle);
            this.Controls.Add(this.sbYukari);
            this.Controls.Add(this.gridControl2);
            this.Controls.Add(this.gridControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAT2rotamusteri";
            this.Text = "Rota Müşteri Bağlantıları";
            this.Load += new System.EventHandler(this.frmAT2rotamusteri_Load);
            this.SizeChanged += new System.EventHandler(this.frmAT2rotamusteri_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.SimpleButton sbYukari;
        private DevExpress.XtraEditors.SimpleButton sbAsagi;
        private DevExpress.XtraEditors.SimpleButton sbEkle;
        private DevExpress.XtraEditors.SimpleButton sbSil;
        private DevExpress.XtraEditors.SimpleButton sbDetay;
        private System.Windows.Forms.Button btnYenile;
    }
}