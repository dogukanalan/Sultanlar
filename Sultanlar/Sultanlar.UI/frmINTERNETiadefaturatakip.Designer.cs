namespace Sultanlar.UI
{
    partial class frmINTERNETiadefaturatakip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmINTERNETiadefaturatakip));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcanpkID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanintMusteriID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanSMREF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanstrAdSoyad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanMUSTERI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanSUBE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanstrFatNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcandtGiris = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanstrAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanblKontrol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcandtKontrol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanstrKontrol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanblPazarlama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcandtPazarlama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanstrPazarlama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblAlt = new System.Windows.Forms.Label();
            this.sbKontrol = new DevExpress.XtraEditors.SimpleButton();
            this.txtKontrol = new System.Windows.Forms.TextBox();
            this.sbPazarlama = new DevExpress.XtraEditors.SimpleButton();
            this.txtPazarlama = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnYenile = new System.Windows.Forms.Button();
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
            this.gridControl1.Size = new System.Drawing.Size(879, 431);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcanpkID,
            this.gcanintMusteriID,
            this.gcanSMREF,
            this.gcanstrAdSoyad,
            this.gcanMUSTERI,
            this.gcanSUBE,
            this.gcanstrFatNo,
            this.gcandtGiris,
            this.gcanstrAciklama,
            this.gcanblKontrol,
            this.gcandtKontrol,
            this.gcanstrKontrol,
            this.gcanblPazarlama,
            this.gcandtPazarlama,
            this.gcanstrPazarlama});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.ViewCaption = "Fatura Takibi";
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
            // gcanintMusteriID
            // 
            this.gcanintMusteriID.FieldName = "intMusteriID";
            this.gcanintMusteriID.Name = "gcanintMusteriID";
            // 
            // gcanSMREF
            // 
            this.gcanSMREF.Caption = "SMREF";
            this.gcanSMREF.FieldName = "SMREF";
            this.gcanSMREF.Name = "gcanSMREF";
            this.gcanSMREF.OptionsColumn.AllowEdit = false;
            this.gcanSMREF.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // gcanstrAdSoyad
            // 
            this.gcanstrAdSoyad.AppearanceHeader.Options.UseTextOptions = true;
            this.gcanstrAdSoyad.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcanstrAdSoyad.Caption = "Ad Soyad";
            this.gcanstrAdSoyad.FieldName = "strAdSoyad";
            this.gcanstrAdSoyad.Name = "gcanstrAdSoyad";
            this.gcanstrAdSoyad.OptionsColumn.AllowEdit = false;
            this.gcanstrAdSoyad.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanstrAdSoyad.Visible = true;
            this.gcanstrAdSoyad.VisibleIndex = 0;
            this.gcanstrAdSoyad.Width = 120;
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
            this.gcanMUSTERI.VisibleIndex = 1;
            this.gcanMUSTERI.Width = 195;
            // 
            // gcanSUBE
            // 
            this.gcanSUBE.AppearanceHeader.Options.UseTextOptions = true;
            this.gcanSUBE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcanSUBE.Caption = "Şube";
            this.gcanSUBE.FieldName = "SUBE";
            this.gcanSUBE.Name = "gcanSUBE";
            this.gcanSUBE.OptionsColumn.AllowEdit = false;
            this.gcanSUBE.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanSUBE.Visible = true;
            this.gcanSUBE.VisibleIndex = 2;
            this.gcanSUBE.Width = 195;
            // 
            // gcanstrFatNo
            // 
            this.gcanstrFatNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gcanstrFatNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcanstrFatNo.Caption = "Fat.No";
            this.gcanstrFatNo.FieldName = "strFatNo";
            this.gcanstrFatNo.Name = "gcanstrFatNo";
            this.gcanstrFatNo.OptionsColumn.AllowEdit = false;
            this.gcanstrFatNo.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanstrFatNo.Visible = true;
            this.gcanstrFatNo.VisibleIndex = 3;
            // 
            // gcandtGiris
            // 
            this.gcandtGiris.AppearanceHeader.Options.UseTextOptions = true;
            this.gcandtGiris.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcandtGiris.Caption = "Gir.Tarihi";
            this.gcandtGiris.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcandtGiris.FieldName = "dtGiris";
            this.gcandtGiris.Name = "gcandtGiris";
            this.gcandtGiris.OptionsColumn.AllowEdit = false;
            this.gcandtGiris.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcandtGiris.Visible = true;
            this.gcandtGiris.VisibleIndex = 4;
            // 
            // gcanstrAciklama
            // 
            this.gcanstrAciklama.AppearanceHeader.Options.UseTextOptions = true;
            this.gcanstrAciklama.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcanstrAciklama.Caption = "Açıklama";
            this.gcanstrAciklama.FieldName = "strAciklama";
            this.gcanstrAciklama.Name = "gcanstrAciklama";
            this.gcanstrAciklama.OptionsColumn.AllowEdit = false;
            this.gcanstrAciklama.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanstrAciklama.Visible = true;
            this.gcanstrAciklama.VisibleIndex = 5;
            this.gcanstrAciklama.Width = 120;
            // 
            // gcanblKontrol
            // 
            this.gcanblKontrol.AppearanceHeader.Options.UseTextOptions = true;
            this.gcanblKontrol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcanblKontrol.Caption = "Kon.Ed.Gönd.";
            this.gcanblKontrol.FieldName = "blKontrol";
            this.gcanblKontrol.Name = "gcanblKontrol";
            this.gcanblKontrol.OptionsColumn.AllowEdit = false;
            this.gcanblKontrol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanblKontrol.Visible = true;
            this.gcanblKontrol.VisibleIndex = 6;
            // 
            // gcandtKontrol
            // 
            this.gcandtKontrol.AppearanceHeader.Options.UseTextOptions = true;
            this.gcandtKontrol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcandtKontrol.Caption = "Kont.Tarihi";
            this.gcandtKontrol.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcandtKontrol.FieldName = "dtKontrol";
            this.gcandtKontrol.Name = "gcandtKontrol";
            this.gcandtKontrol.OptionsColumn.AllowEdit = false;
            this.gcandtKontrol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcandtKontrol.Visible = true;
            this.gcandtKontrol.VisibleIndex = 7;
            // 
            // gcanstrKontrol
            // 
            this.gcanstrKontrol.AppearanceHeader.Options.UseTextOptions = true;
            this.gcanstrKontrol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcanstrKontrol.Caption = "Kont.Açıklama";
            this.gcanstrKontrol.FieldName = "strKontrol";
            this.gcanstrKontrol.Name = "gcanstrKontrol";
            this.gcanstrKontrol.OptionsColumn.AllowEdit = false;
            this.gcanstrKontrol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanstrKontrol.Visible = true;
            this.gcanstrKontrol.VisibleIndex = 8;
            this.gcanstrKontrol.Width = 120;
            // 
            // gcanblPazarlama
            // 
            this.gcanblPazarlama.AppearanceHeader.Options.UseTextOptions = true;
            this.gcanblPazarlama.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcanblPazarlama.Caption = "Paz.M.Gönd.";
            this.gcanblPazarlama.FieldName = "blPazarlama";
            this.gcanblPazarlama.Name = "gcanblPazarlama";
            this.gcanblPazarlama.OptionsColumn.AllowEdit = false;
            this.gcanblPazarlama.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanblPazarlama.Visible = true;
            this.gcanblPazarlama.VisibleIndex = 9;
            // 
            // gcandtPazarlama
            // 
            this.gcandtPazarlama.AppearanceHeader.Options.UseTextOptions = true;
            this.gcandtPazarlama.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcandtPazarlama.Caption = "Paz.G.Tarihi";
            this.gcandtPazarlama.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcandtPazarlama.FieldName = "dtPazarlama";
            this.gcandtPazarlama.Name = "gcandtPazarlama";
            this.gcandtPazarlama.OptionsColumn.AllowEdit = false;
            this.gcandtPazarlama.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcandtPazarlama.Visible = true;
            this.gcandtPazarlama.VisibleIndex = 10;
            // 
            // gcanstrPazarlama
            // 
            this.gcanstrPazarlama.AppearanceHeader.Options.UseTextOptions = true;
            this.gcanstrPazarlama.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcanstrPazarlama.Caption = "Paz.Açıklama";
            this.gcanstrPazarlama.FieldName = "strPazarlama";
            this.gcanstrPazarlama.Name = "gcanstrPazarlama";
            this.gcanstrPazarlama.OptionsColumn.AllowEdit = false;
            this.gcanstrPazarlama.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanstrPazarlama.Visible = true;
            this.gcanstrPazarlama.VisibleIndex = 11;
            this.gcanstrPazarlama.Width = 120;
            // 
            // lblAlt
            // 
            this.lblAlt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAlt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblAlt.Location = new System.Drawing.Point(0, 431);
            this.lblAlt.Name = "lblAlt";
            this.lblAlt.Size = new System.Drawing.Size(879, 29);
            this.lblAlt.TabIndex = 10;
            // 
            // sbKontrol
            // 
            this.sbKontrol.Enabled = false;
            this.sbKontrol.Location = new System.Drawing.Point(220, 434);
            this.sbKontrol.Name = "sbKontrol";
            this.sbKontrol.Size = new System.Drawing.Size(125, 23);
            this.sbKontrol.TabIndex = 13;
            this.sbKontrol.Text = "Kontrol Edildi Gönderildi";
            this.sbKontrol.Click += new System.EventHandler(this.sbKontrol_Click);
            // 
            // txtKontrol
            // 
            this.txtKontrol.Location = new System.Drawing.Point(114, 435);
            this.txtKontrol.Name = "txtKontrol";
            this.txtKontrol.Size = new System.Drawing.Size(100, 20);
            this.txtKontrol.TabIndex = 14;
            // 
            // sbPazarlama
            // 
            this.sbPazarlama.Enabled = false;
            this.sbPazarlama.Location = new System.Drawing.Point(661, 434);
            this.sbPazarlama.Name = "sbPazarlama";
            this.sbPazarlama.Size = new System.Drawing.Size(125, 23);
            this.sbPazarlama.TabIndex = 13;
            this.sbPazarlama.Text = "Paz.Muh.ye Gönderdi";
            this.sbPazarlama.Click += new System.EventHandler(this.sbPazarlama_Click);
            // 
            // txtPazarlama
            // 
            this.txtPazarlama.Location = new System.Drawing.Point(555, 435);
            this.txtPazarlama.Name = "txtPazarlama";
            this.txtPazarlama.Size = new System.Drawing.Size(100, 20);
            this.txtPazarlama.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 438);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Kontrol Açıklaması:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(437, 438);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Pazarlama Açıklaması:";
            // 
            // btnYenile
            // 
            this.btnYenile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnYenile.Image = global::Sultanlar.UI.Properties.Resources.Refresh_icon;
            this.btnYenile.Location = new System.Drawing.Point(0, 0);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(24, 24);
            this.btnYenile.TabIndex = 34;
            this.btnYenile.UseVisualStyleBackColor = true;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // frmINTERNETiadefaturatakip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 460);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPazarlama);
            this.Controls.Add(this.sbPazarlama);
            this.Controls.Add(this.txtKontrol);
            this.Controls.Add(this.sbKontrol);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.lblAlt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmINTERNETiadefaturatakip";
            this.Text = "İade Fatura Takip";
            this.Load += new System.EventHandler(this.frmINTERNETiadefaturatakip_Load);
            this.SizeChanged += new System.EventHandler(this.frmINTERNETiadefaturatakip_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gcanpkID;
        private DevExpress.XtraGrid.Columns.GridColumn gcanSMREF;
        private DevExpress.XtraGrid.Columns.GridColumn gcanMUSTERI;
        private DevExpress.XtraGrid.Columns.GridColumn gcanSUBE;
        private DevExpress.XtraGrid.Columns.GridColumn gcanstrFatNo;
        private DevExpress.XtraGrid.Columns.GridColumn gcandtGiris;
        private DevExpress.XtraGrid.Columns.GridColumn gcanstrAciklama;
        private DevExpress.XtraGrid.Columns.GridColumn gcanblKontrol;
        private DevExpress.XtraGrid.Columns.GridColumn gcandtKontrol;
        private DevExpress.XtraGrid.Columns.GridColumn gcanstrKontrol;
        private DevExpress.XtraGrid.Columns.GridColumn gcanblPazarlama;
        private DevExpress.XtraGrid.Columns.GridColumn gcandtPazarlama;
        private DevExpress.XtraGrid.Columns.GridColumn gcanstrPazarlama;
        private System.Windows.Forms.Label lblAlt;
        private DevExpress.XtraGrid.Columns.GridColumn gcanintMusteriID;
        private DevExpress.XtraGrid.Columns.GridColumn gcanstrAdSoyad;
        private DevExpress.XtraEditors.SimpleButton sbKontrol;
        private System.Windows.Forms.TextBox txtKontrol;
        private DevExpress.XtraEditors.SimpleButton sbPazarlama;
        private System.Windows.Forms.TextBox txtPazarlama;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnYenile;
    }
}