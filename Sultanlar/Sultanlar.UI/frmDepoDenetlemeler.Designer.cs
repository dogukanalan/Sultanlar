namespace Sultanlar.UI
{
    partial class frmDepoDenetlemeler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDepoDenetlemeler));
            this.btnYenile = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcanpkID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanGMREF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanMUSTERI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcandtTarih = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanstrDenetleyen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanstrUnvan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanstrTespilter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblYeniGiris = new System.Windows.Forms.Label();
            this.txtUnvan = new System.Windows.Forms.TextBox();
            this.sbGonder = new DevExpress.XtraEditors.SimpleButton();
            this.lblAlt = new System.Windows.Forms.Label();
            this.lblMusteri = new System.Windows.Forms.Label();
            this.lblDenetleyen = new System.Windows.Forms.Label();
            this.txtDenetleyen = new System.Windows.Forms.TextBox();
            this.lblUnvan = new System.Windows.Forms.Label();
            this.txtTespitler = new System.Windows.Forms.TextBox();
            this.lblTespitler = new System.Windows.Forms.Label();
            this.cmbMusteriler = new System.Windows.Forms.ComboBox();
            this.lblResimler = new System.Windows.Forms.Label();
            this.sbResimEkle = new DevExpress.XtraEditors.SimpleButton();
            this.sbResimTemizle = new DevExpress.XtraEditors.SimpleButton();
            this.lblResimSayisi = new System.Windows.Forms.Label();
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
            this.btnYenile.TabIndex = 36;
            this.btnYenile.UseVisualStyleBackColor = true;
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
            this.gridControl1.Size = new System.Drawing.Size(984, 387);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcanpkID,
            this.gcanGMREF,
            this.gcanMUSTERI,
            this.gcandtTarih,
            this.gcanstrDenetleyen,
            this.gcanstrUnvan,
            this.gcanstrTespilter});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.ViewCaption = "Depo Denetlemeleri";
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gcanpkID
            // 
            this.gcanpkID.Caption = "No";
            this.gcanpkID.FieldName = "pkID";
            this.gcanpkID.Name = "gcanpkID";
            this.gcanpkID.OptionsColumn.AllowEdit = false;
            this.gcanpkID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanpkID.Width = 45;
            // 
            // gcanGMREF
            // 
            this.gcanGMREF.Caption = "GMREF";
            this.gcanGMREF.FieldName = "GMREF";
            this.gcanGMREF.Name = "gcanGMREF";
            this.gcanGMREF.OptionsColumn.AllowEdit = false;
            this.gcanGMREF.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // gcanMUSTERI
            // 
            this.gcanMUSTERI.AppearanceHeader.Options.UseTextOptions = true;
            this.gcanMUSTERI.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcanMUSTERI.Caption = "Müşteri";
            this.gcanMUSTERI.FieldName = "MUSTERI";
            this.gcanMUSTERI.Name = "gcanMUSTERI";
            this.gcanMUSTERI.OptionsColumn.AllowEdit = false;
            this.gcanMUSTERI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanMUSTERI.Visible = true;
            this.gcanMUSTERI.VisibleIndex = 0;
            this.gcanMUSTERI.Width = 195;
            // 
            // gcandtTarih
            // 
            this.gcandtTarih.AppearanceCell.Options.UseTextOptions = true;
            this.gcandtTarih.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcandtTarih.AppearanceHeader.Options.UseTextOptions = true;
            this.gcandtTarih.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcandtTarih.Caption = "Tarih";
            this.gcandtTarih.DisplayFormat.FormatString = "d";
            this.gcandtTarih.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcandtTarih.FieldName = "dtTarih";
            this.gcandtTarih.Name = "gcandtTarih";
            this.gcandtTarih.OptionsColumn.AllowEdit = false;
            this.gcandtTarih.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcandtTarih.Visible = true;
            this.gcandtTarih.VisibleIndex = 1;
            // 
            // gcanstrDenetleyen
            // 
            this.gcanstrDenetleyen.AppearanceCell.Options.UseTextOptions = true;
            this.gcanstrDenetleyen.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcanstrDenetleyen.AppearanceHeader.Options.UseTextOptions = true;
            this.gcanstrDenetleyen.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcanstrDenetleyen.Caption = "Denetleyen";
            this.gcanstrDenetleyen.FieldName = "strDenetleyen";
            this.gcanstrDenetleyen.Name = "gcanstrDenetleyen";
            this.gcanstrDenetleyen.OptionsColumn.AllowEdit = false;
            this.gcanstrDenetleyen.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanstrDenetleyen.Visible = true;
            this.gcanstrDenetleyen.VisibleIndex = 2;
            this.gcanstrDenetleyen.Width = 100;
            // 
            // gcanstrUnvan
            // 
            this.gcanstrUnvan.AppearanceCell.Options.UseTextOptions = true;
            this.gcanstrUnvan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcanstrUnvan.AppearanceHeader.Options.UseTextOptions = true;
            this.gcanstrUnvan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcanstrUnvan.Caption = "Ünvan";
            this.gcanstrUnvan.FieldName = "strUnvan";
            this.gcanstrUnvan.Name = "gcanstrUnvan";
            this.gcanstrUnvan.OptionsColumn.AllowEdit = false;
            this.gcanstrUnvan.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanstrUnvan.Visible = true;
            this.gcanstrUnvan.VisibleIndex = 3;
            this.gcanstrUnvan.Width = 120;
            // 
            // gcanstrTespilter
            // 
            this.gcanstrTespilter.AppearanceHeader.Options.UseTextOptions = true;
            this.gcanstrTespilter.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcanstrTespilter.Caption = "Tespitler";
            this.gcanstrTespilter.FieldName = "strTespilter";
            this.gcanstrTespilter.Name = "gcanstrTespilter";
            this.gcanstrTespilter.OptionsColumn.AllowEdit = false;
            this.gcanstrTespilter.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanstrTespilter.Visible = true;
            this.gcanstrTespilter.VisibleIndex = 4;
            this.gcanstrTespilter.Width = 458;
            // 
            // lblYeniGiris
            // 
            this.lblYeniGiris.AutoSize = true;
            this.lblYeniGiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblYeniGiris.ForeColor = System.Drawing.Color.DarkRed;
            this.lblYeniGiris.Location = new System.Drawing.Point(12, 404);
            this.lblYeniGiris.Name = "lblYeniGiris";
            this.lblYeniGiris.Size = new System.Drawing.Size(32, 26);
            this.lblYeniGiris.TabIndex = 1;
            this.lblYeniGiris.Text = "Yeni\r\nGiriş";
            // 
            // txtUnvan
            // 
            this.txtUnvan.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUnvan.Location = new System.Drawing.Point(379, 419);
            this.txtUnvan.Name = "txtUnvan";
            this.txtUnvan.Size = new System.Drawing.Size(99, 18);
            this.txtUnvan.TabIndex = 4;
            // 
            // sbGonder
            // 
            this.sbGonder.Location = new System.Drawing.Point(927, 394);
            this.sbGonder.Name = "sbGonder";
            this.sbGonder.Size = new System.Drawing.Size(50, 46);
            this.sbGonder.TabIndex = 6;
            this.sbGonder.Text = "Gönder";
            this.sbGonder.Click += new System.EventHandler(this.sbGonder_Click);
            // 
            // lblAlt
            // 
            this.lblAlt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAlt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblAlt.Location = new System.Drawing.Point(0, 387);
            this.lblAlt.Name = "lblAlt";
            this.lblAlt.Size = new System.Drawing.Size(984, 60);
            this.lblAlt.TabIndex = 1;
            // 
            // lblMusteri
            // 
            this.lblMusteri.AutoSize = true;
            this.lblMusteri.Location = new System.Drawing.Point(58, 397);
            this.lblMusteri.Name = "lblMusteri";
            this.lblMusteri.Size = new System.Drawing.Size(44, 13);
            this.lblMusteri.TabIndex = 1;
            this.lblMusteri.Text = "Müşteri:";
            // 
            // lblDenetleyen
            // 
            this.lblDenetleyen.AutoSize = true;
            this.lblDenetleyen.Location = new System.Drawing.Point(309, 397);
            this.lblDenetleyen.Name = "lblDenetleyen";
            this.lblDenetleyen.Size = new System.Drawing.Size(64, 13);
            this.lblDenetleyen.TabIndex = 1;
            this.lblDenetleyen.Text = "Denetleyen:";
            // 
            // txtDenetleyen
            // 
            this.txtDenetleyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDenetleyen.Location = new System.Drawing.Point(379, 394);
            this.txtDenetleyen.Name = "txtDenetleyen";
            this.txtDenetleyen.Size = new System.Drawing.Size(99, 18);
            this.txtDenetleyen.TabIndex = 3;
            // 
            // lblUnvan
            // 
            this.lblUnvan.AutoSize = true;
            this.lblUnvan.Location = new System.Drawing.Point(331, 422);
            this.lblUnvan.Name = "lblUnvan";
            this.lblUnvan.Size = new System.Drawing.Size(42, 13);
            this.lblUnvan.TabIndex = 1;
            this.lblUnvan.Text = "Ünvan:";
            // 
            // txtTespitler
            // 
            this.txtTespitler.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTespitler.Location = new System.Drawing.Point(540, 394);
            this.txtTespitler.Multiline = true;
            this.txtTespitler.Name = "txtTespitler";
            this.txtTespitler.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTespitler.Size = new System.Drawing.Size(381, 46);
            this.txtTespitler.TabIndex = 5;
            // 
            // lblTespitler
            // 
            this.lblTespitler.AutoSize = true;
            this.lblTespitler.Location = new System.Drawing.Point(484, 397);
            this.lblTespitler.Name = "lblTespitler";
            this.lblTespitler.Size = new System.Drawing.Size(50, 13);
            this.lblTespitler.TabIndex = 1;
            this.lblTespitler.Text = "Tespitler:";
            // 
            // cmbMusteriler
            // 
            this.cmbMusteriler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMusteriler.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbMusteriler.FormattingEnabled = true;
            this.cmbMusteriler.Location = new System.Drawing.Point(108, 394);
            this.cmbMusteriler.Name = "cmbMusteriler";
            this.cmbMusteriler.Size = new System.Drawing.Size(195, 20);
            this.cmbMusteriler.TabIndex = 2;
            // 
            // lblResimler
            // 
            this.lblResimler.AutoSize = true;
            this.lblResimler.Location = new System.Drawing.Point(52, 422);
            this.lblResimler.Name = "lblResimler";
            this.lblResimler.Size = new System.Drawing.Size(50, 13);
            this.lblResimler.TabIndex = 1;
            this.lblResimler.Text = "Resimler:";
            // 
            // sbResimEkle
            // 
            this.sbResimEkle.Location = new System.Drawing.Point(108, 419);
            this.sbResimEkle.Name = "sbResimEkle";
            this.sbResimEkle.Size = new System.Drawing.Size(45, 21);
            this.sbResimEkle.TabIndex = 2;
            this.sbResimEkle.Text = "Ekle";
            this.sbResimEkle.Click += new System.EventHandler(this.sbResimEkle_Click);
            // 
            // sbResimTemizle
            // 
            this.sbResimTemizle.Location = new System.Drawing.Point(258, 419);
            this.sbResimTemizle.Name = "sbResimTemizle";
            this.sbResimTemizle.Size = new System.Drawing.Size(45, 21);
            this.sbResimTemizle.TabIndex = 2;
            this.sbResimTemizle.Text = "Temizle";
            this.sbResimTemizle.Click += new System.EventHandler(this.sbResimTemizle_Click);
            // 
            // lblResimSayisi
            // 
            this.lblResimSayisi.ForeColor = System.Drawing.Color.DarkMagenta;
            this.lblResimSayisi.Location = new System.Drawing.Point(159, 422);
            this.lblResimSayisi.Name = "lblResimSayisi";
            this.lblResimSayisi.Size = new System.Drawing.Size(93, 13);
            this.lblResimSayisi.TabIndex = 40;
            this.lblResimSayisi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmDepoDenetlemeler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 447);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.cmbMusteriler);
            this.Controls.Add(this.lblTespitler);
            this.Controls.Add(this.lblUnvan);
            this.Controls.Add(this.lblDenetleyen);
            this.Controls.Add(this.lblResimSayisi);
            this.Controls.Add(this.lblResimler);
            this.Controls.Add(this.lblMusteri);
            this.Controls.Add(this.lblYeniGiris);
            this.Controls.Add(this.txtTespitler);
            this.Controls.Add(this.txtDenetleyen);
            this.Controls.Add(this.txtUnvan);
            this.Controls.Add(this.sbResimTemizle);
            this.Controls.Add(this.sbResimEkle);
            this.Controls.Add(this.sbGonder);
            this.Controls.Add(this.lblAlt);
            this.Controls.Add(this.btnYenile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDepoDenetlemeler";
            this.Text = "Depo Denetlemeleri";
            this.Load += new System.EventHandler(this.frmDepoDenetlemeler_Load);
            this.SizeChanged += new System.EventHandler(this.frmDepoDenetlemeler_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnYenile;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gcanpkID;
        private DevExpress.XtraGrid.Columns.GridColumn gcanGMREF;
        private DevExpress.XtraGrid.Columns.GridColumn gcanMUSTERI;
        private DevExpress.XtraGrid.Columns.GridColumn gcandtTarih;
        private DevExpress.XtraGrid.Columns.GridColumn gcanstrDenetleyen;
        private DevExpress.XtraGrid.Columns.GridColumn gcanstrUnvan;
        private DevExpress.XtraGrid.Columns.GridColumn gcanstrTespilter;
        private System.Windows.Forms.Label lblYeniGiris;
        private System.Windows.Forms.TextBox txtUnvan;
        private DevExpress.XtraEditors.SimpleButton sbGonder;
        private System.Windows.Forms.Label lblAlt;
        private System.Windows.Forms.Label lblMusteri;
        private System.Windows.Forms.Label lblDenetleyen;
        private System.Windows.Forms.TextBox txtDenetleyen;
        private System.Windows.Forms.Label lblUnvan;
        private System.Windows.Forms.TextBox txtTespitler;
        private System.Windows.Forms.Label lblTespitler;
        private System.Windows.Forms.ComboBox cmbMusteriler;
        private System.Windows.Forms.Label lblResimler;
        private DevExpress.XtraEditors.SimpleButton sbResimEkle;
        private DevExpress.XtraEditors.SimpleButton sbResimTemizle;
        private System.Windows.Forms.Label lblResimSayisi;
    }
}