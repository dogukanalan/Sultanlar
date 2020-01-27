namespace Sultanlar.UI
{
    partial class frmINTERNETiadeislem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmINTERNETiadeislem));
            this.btnYenile = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcanpkID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanSMREF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcandtGiris = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanMUSTERI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcandtKontrol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanstrAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanstrKontrol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcandtPazarlama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanblKontrol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanblPazarlama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanstrFatNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanstrPazarlama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblAlt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFatNo = new System.Windows.Forms.TextBox();
            this.sbKontrol = new DevExpress.XtraEditors.SimpleButton();
            this.cmbPersoneller = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpSatici = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpMuhasebe = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.sbIadeDegil = new DevExpress.XtraEditors.SimpleButton();
            this.cbSatici = new System.Windows.Forms.CheckBox();
            this.cbSaticiTarih = new System.Windows.Forms.CheckBox();
            this.cbMuhasebeTarihi = new System.Windows.Forms.CheckBox();
            this.sbSil = new DevExpress.XtraEditors.SimpleButton();
            this.sbIadeGelmedi = new DevExpress.XtraEditors.SimpleButton();
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
            this.gridControl1.Size = new System.Drawing.Size(1000, 431);
            this.gridControl1.TabIndex = 35;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcanpkID,
            this.gcanSMREF,
            this.gcandtGiris,
            this.gcanMUSTERI,
            this.gcandtKontrol,
            this.gcanstrAciklama,
            this.gcanstrKontrol,
            this.gcandtPazarlama,
            this.gcanblKontrol,
            this.gcanblPazarlama,
            this.gridColumn3,
            this.gcanstrFatNo,
            this.gcanstrPazarlama,
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.ViewCaption = "İşlem Süreci";
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // gcanpkID
            // 
            this.gcanpkID.Caption = "No";
            this.gcanpkID.FieldName = "intIadeID";
            this.gcanpkID.Name = "gcanpkID";
            this.gcanpkID.OptionsColumn.AllowEdit = false;
            this.gcanpkID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanpkID.Width = 45;
            // 
            // gcanSMREF
            // 
            this.gcanSMREF.Caption = "SMREF";
            this.gcanSMREF.FieldName = "SMREF";
            this.gcanSMREF.Name = "gcanSMREF";
            this.gcanSMREF.OptionsColumn.AllowEdit = false;
            this.gcanSMREF.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // gcandtGiris
            // 
            this.gcandtGiris.AppearanceHeader.Options.UseTextOptions = true;
            this.gcandtGiris.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcandtGiris.Caption = "Gir.Tarihi";
            this.gcandtGiris.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcandtGiris.FieldName = "dtOnaylamaTarihi";
            this.gcandtGiris.Name = "gcandtGiris";
            this.gcandtGiris.OptionsColumn.AllowEdit = false;
            this.gcandtGiris.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcandtGiris.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.gcandtGiris.Visible = true;
            this.gcandtGiris.VisibleIndex = 0;
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
            // gcandtKontrol
            // 
            this.gcandtKontrol.AppearanceHeader.Options.UseTextOptions = true;
            this.gcandtKontrol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcandtKontrol.Caption = "İrs.Tarihi";
            this.gcandtKontrol.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcandtKontrol.FieldName = "dtIrsaliye";
            this.gcandtKontrol.Name = "gcandtKontrol";
            this.gcandtKontrol.OptionsColumn.AllowEdit = false;
            this.gcandtKontrol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // gcanstrAciklama
            // 
            this.gcanstrAciklama.AppearanceHeader.Options.UseTextOptions = true;
            this.gcanstrAciklama.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcanstrAciklama.Caption = "Açıklama";
            this.gcanstrAciklama.FieldName = "strAciklama2";
            this.gcanstrAciklama.Name = "gcanstrAciklama";
            this.gcanstrAciklama.OptionsColumn.AllowEdit = false;
            this.gcanstrAciklama.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanstrAciklama.Visible = true;
            this.gcanstrAciklama.VisibleIndex = 2;
            this.gcanstrAciklama.Width = 120;
            // 
            // gcanstrKontrol
            // 
            this.gcanstrKontrol.AppearanceHeader.Options.UseTextOptions = true;
            this.gcanstrKontrol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcanstrKontrol.Caption = "Sap.No";
            this.gcanstrKontrol.FieldName = "QUANTUMNO";
            this.gcanstrKontrol.Name = "gcanstrKontrol";
            this.gcanstrKontrol.OptionsColumn.AllowEdit = false;
            this.gcanstrKontrol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanstrKontrol.Visible = true;
            this.gcanstrKontrol.VisibleIndex = 3;
            this.gcanstrKontrol.Width = 100;
            // 
            // gcandtPazarlama
            // 
            this.gcandtPazarlama.AppearanceHeader.Options.UseTextOptions = true;
            this.gcandtPazarlama.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcandtPazarlama.Caption = "Fiy.V.Tarihi";
            this.gcandtPazarlama.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcandtPazarlama.FieldName = "dtOnaylamaTarihi";
            this.gcandtPazarlama.Name = "gcandtPazarlama";
            this.gcandtPazarlama.OptionsColumn.AllowEdit = false;
            this.gcandtPazarlama.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcandtPazarlama.Visible = true;
            this.gcandtPazarlama.VisibleIndex = 4;
            // 
            // gcanblKontrol
            // 
            this.gcanblKontrol.AppearanceHeader.Options.UseTextOptions = true;
            this.gcanblKontrol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcanblKontrol.Caption = "Sat.V.Tarihi";
            this.gcanblKontrol.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcanblKontrol.FieldName = "dtVerilis";
            this.gcanblKontrol.Name = "gcanblKontrol";
            this.gcanblKontrol.OptionsColumn.AllowEdit = false;
            this.gcanblKontrol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanblKontrol.Visible = true;
            this.gcanblKontrol.VisibleIndex = 5;
            // 
            // gcanblPazarlama
            // 
            this.gcanblPazarlama.AppearanceHeader.Options.UseTextOptions = true;
            this.gcanblPazarlama.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcanblPazarlama.Caption = "Satıcı";
            this.gcanblPazarlama.FieldName = "strVerilen";
            this.gcanblPazarlama.Name = "gcanblPazarlama";
            this.gcanblPazarlama.OptionsColumn.AllowEdit = false;
            this.gcanblPazarlama.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanblPazarlama.Visible = true;
            this.gcanblPazarlama.VisibleIndex = 6;
            this.gcanblPazarlama.Width = 100;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Muh.V.Tarihi";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn3.FieldName = "dtMuhasebeVerilis";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 7;
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
            this.gcanstrFatNo.VisibleIndex = 8;
            this.gcanstrFatNo.Width = 100;
            // 
            // gcanstrPazarlama
            // 
            this.gcanstrPazarlama.AppearanceHeader.Options.UseTextOptions = true;
            this.gcanstrPazarlama.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcanstrPazarlama.Caption = "İade Değil";
            this.gcanstrPazarlama.FieldName = "blIadeDegil";
            this.gcanstrPazarlama.Name = "gcanstrPazarlama";
            this.gcanstrPazarlama.OptionsColumn.AllowEdit = false;
            this.gcanstrPazarlama.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanstrPazarlama.Visible = true;
            this.gcanstrPazarlama.VisibleIndex = 9;
            this.gcanstrPazarlama.Width = 50;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.FieldName = "strAciklama";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "gridColumn2";
            this.gridColumn2.FieldName = "strAciklama3";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // lblAlt
            // 
            this.lblAlt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAlt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblAlt.Location = new System.Drawing.Point(0, 431);
            this.lblAlt.Name = "lblAlt";
            this.lblAlt.Size = new System.Drawing.Size(1000, 29);
            this.lblAlt.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 438);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Satıcı:";
            // 
            // txtFatNo
            // 
            this.txtFatNo.Location = new System.Drawing.Point(576, 435);
            this.txtFatNo.Name = "txtFatNo";
            this.txtFatNo.Size = new System.Drawing.Size(188, 20);
            this.txtFatNo.TabIndex = 39;
            this.txtFatNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFatNo_KeyDown);
            this.txtFatNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFatNo_KeyUp);
            // 
            // sbKontrol
            // 
            this.sbKontrol.Appearance.BackColor = System.Drawing.Color.DarkCyan;
            this.sbKontrol.Appearance.ForeColor = System.Drawing.Color.White;
            this.sbKontrol.Appearance.Options.UseBackColor = true;
            this.sbKontrol.Appearance.Options.UseForeColor = true;
            this.sbKontrol.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.sbKontrol.Location = new System.Drawing.Point(770, 434);
            this.sbKontrol.Name = "sbKontrol";
            this.sbKontrol.Size = new System.Drawing.Size(49, 23);
            this.sbKontrol.TabIndex = 38;
            this.sbKontrol.Text = "İşle";
            this.sbKontrol.Click += new System.EventHandler(this.sbKontrol_Click);
            // 
            // cmbPersoneller
            // 
            this.cmbPersoneller.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbPersoneller.FormattingEnabled = true;
            this.cmbPersoneller.Location = new System.Drawing.Point(50, 435);
            this.cmbPersoneller.Name = "cmbPersoneller";
            this.cmbPersoneller.Size = new System.Drawing.Size(141, 20);
            this.cmbPersoneller.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 438);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Sat.Ver.:";
            // 
            // dtpSatici
            // 
            this.dtpSatici.Location = new System.Drawing.Point(253, 435);
            this.dtpSatici.Name = "dtpSatici";
            this.dtpSatici.Size = new System.Drawing.Size(104, 20);
            this.dtpSatici.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(375, 438);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Muh.Ver.:";
            // 
            // dtpMuhasebe
            // 
            this.dtpMuhasebe.Location = new System.Drawing.Point(424, 435);
            this.dtpMuhasebe.Name = "dtpMuhasebe";
            this.dtpMuhasebe.Size = new System.Drawing.Size(104, 20);
            this.dtpMuhasebe.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(530, 438);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Fat.No.:";
            // 
            // sbIadeDegil
            // 
            this.sbIadeDegil.Appearance.BackColor = System.Drawing.Color.DarkOrange;
            this.sbIadeDegil.Appearance.ForeColor = System.Drawing.Color.White;
            this.sbIadeDegil.Appearance.Options.UseBackColor = true;
            this.sbIadeDegil.Appearance.Options.UseForeColor = true;
            this.sbIadeDegil.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.sbIadeDegil.Location = new System.Drawing.Point(825, 434);
            this.sbIadeDegil.Name = "sbIadeDegil";
            this.sbIadeDegil.Size = new System.Drawing.Size(80, 23);
            this.sbIadeDegil.TabIndex = 38;
            this.sbIadeDegil.Text = "İade Fat. Değil";
            this.sbIadeDegil.Click += new System.EventHandler(this.sbIadeDegil_Click);
            // 
            // cbSatici
            // 
            this.cbSatici.AutoSize = true;
            this.cbSatici.Checked = true;
            this.cbSatici.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSatici.Location = new System.Drawing.Point(5, 438);
            this.cbSatici.Name = "cbSatici";
            this.cbSatici.Size = new System.Drawing.Size(15, 14);
            this.cbSatici.TabIndex = 43;
            this.cbSatici.UseVisualStyleBackColor = true;
            this.cbSatici.CheckedChanged += new System.EventHandler(this.cbSatici_CheckedChanged);
            // 
            // cbSaticiTarih
            // 
            this.cbSaticiTarih.AutoSize = true;
            this.cbSaticiTarih.Checked = true;
            this.cbSaticiTarih.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSaticiTarih.Location = new System.Drawing.Point(196, 438);
            this.cbSaticiTarih.Name = "cbSaticiTarih";
            this.cbSaticiTarih.Size = new System.Drawing.Size(15, 14);
            this.cbSaticiTarih.TabIndex = 43;
            this.cbSaticiTarih.UseVisualStyleBackColor = true;
            this.cbSaticiTarih.CheckedChanged += new System.EventHandler(this.cbSaticiTarih_CheckedChanged);
            // 
            // cbMuhasebeTarihi
            // 
            this.cbMuhasebeTarihi.AutoSize = true;
            this.cbMuhasebeTarihi.Checked = true;
            this.cbMuhasebeTarihi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMuhasebeTarihi.Location = new System.Drawing.Point(362, 438);
            this.cbMuhasebeTarihi.Name = "cbMuhasebeTarihi";
            this.cbMuhasebeTarihi.Size = new System.Drawing.Size(15, 14);
            this.cbMuhasebeTarihi.TabIndex = 43;
            this.cbMuhasebeTarihi.UseVisualStyleBackColor = true;
            this.cbMuhasebeTarihi.CheckedChanged += new System.EventHandler(this.cbMuhasebeTarihi_CheckedChanged);
            // 
            // sbSil
            // 
            this.sbSil.Appearance.BackColor = System.Drawing.Color.Black;
            this.sbSil.Appearance.ForeColor = System.Drawing.Color.White;
            this.sbSil.Appearance.Options.UseBackColor = true;
            this.sbSil.Appearance.Options.UseForeColor = true;
            this.sbSil.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.sbSil.Location = new System.Drawing.Point(972, 434);
            this.sbSil.Name = "sbSil";
            this.sbSil.Size = new System.Drawing.Size(24, 23);
            this.sbSil.TabIndex = 38;
            this.sbSil.Text = "Sil";
            this.sbSil.Click += new System.EventHandler(this.sbSil_Click);
            // 
            // sbIadeGelmedi
            // 
            this.sbIadeGelmedi.Appearance.BackColor = System.Drawing.Color.Red;
            this.sbIadeGelmedi.Appearance.ForeColor = System.Drawing.Color.White;
            this.sbIadeGelmedi.Appearance.Options.UseBackColor = true;
            this.sbIadeGelmedi.Appearance.Options.UseForeColor = true;
            this.sbIadeGelmedi.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.sbIadeGelmedi.Location = new System.Drawing.Point(911, 434);
            this.sbIadeGelmedi.Name = "sbIadeGelmedi";
            this.sbIadeGelmedi.Size = new System.Drawing.Size(55, 23);
            this.sbIadeGelmedi.TabIndex = 38;
            this.sbIadeGelmedi.Text = "İ. Gelmedi";
            this.sbIadeGelmedi.Click += new System.EventHandler(this.sbIadeGelmedi_Click);
            // 
            // frmINTERNETiadeislem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 460);
            this.Controls.Add(this.txtFatNo);
            this.Controls.Add(this.cbMuhasebeTarihi);
            this.Controls.Add(this.cbSaticiTarih);
            this.Controls.Add(this.cbSatici);
            this.Controls.Add(this.dtpMuhasebe);
            this.Controls.Add(this.dtpSatici);
            this.Controls.Add(this.cmbPersoneller);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sbSil);
            this.Controls.Add(this.sbIadeGelmedi);
            this.Controls.Add(this.sbIadeDegil);
            this.Controls.Add(this.sbKontrol);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.lblAlt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(2000, 499);
            this.MinimumSize = new System.Drawing.Size(920, 499);
            this.Name = "frmINTERNETiadeislem";
            this.Text = "İadeler : İşlem Süreci";
            this.Load += new System.EventHandler(this.frmINTERNETiadeislem_Load);
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
        private DevExpress.XtraGrid.Columns.GridColumn gcanSMREF;
        private DevExpress.XtraGrid.Columns.GridColumn gcanMUSTERI;
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFatNo;
        private DevExpress.XtraEditors.SimpleButton sbKontrol;
        private System.Windows.Forms.ComboBox cmbPersoneller;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpSatici;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpMuhasebe;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton sbIadeDegil;
        private System.Windows.Forms.CheckBox cbSatici;
        private System.Windows.Forms.CheckBox cbSaticiTarih;
        private System.Windows.Forms.CheckBox cbMuhasebeTarihi;
        private DevExpress.XtraEditors.SimpleButton sbSil;
        private DevExpress.XtraEditors.SimpleButton sbIadeGelmedi;
    }
}