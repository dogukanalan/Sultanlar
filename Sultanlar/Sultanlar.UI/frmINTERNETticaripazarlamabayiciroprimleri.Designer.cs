﻿namespace Sultanlar.UI
{
    partial class frmINTERNETticaripazarlamabayiciroprimleri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmINTERNETticaripazarlamabayiciroprimleri));
            this.gridControl4 = new DevExpress.XtraGrid.GridControl();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnYenile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.sbEkle = new DevExpress.XtraEditors.SimpleButton();
            this.cmbBayi = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtYil = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAy = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTAH = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtYEG = new System.Windows.Forms.TextBox();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.sbGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.sbSil = new DevExpress.XtraEditors.SimpleButton();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTAHKDV = new System.Windows.Forms.TextBox();
            this.txtYEGKDV = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl4
            // 
            this.gridControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl4.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.White;
            this.gridControl4.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black;
            this.gridControl4.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridControl4.EmbeddedNavigator.Appearance.Options.UseForeColor = true;
            this.gridControl4.Location = new System.Drawing.Point(0, 0);
            this.gridControl4.MainView = this.gridView4;
            this.gridControl4.Name = "gridControl4";
            this.gridControl4.Size = new System.Drawing.Size(864, 387);
            this.gridControl4.TabIndex = 4;
            this.gridControl4.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4});
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn18,
            this.gridColumn7,
            this.gridColumn6,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn14});
            this.gridView4.GridControl = this.gridControl4;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsView.ColumnAutoWidth = false;
            this.gridView4.OptionsView.ShowAutoFilterRow = true;
            this.gridView4.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView4.OptionsView.ShowFooter = true;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            this.gridView4.ViewCaption = "Hizmet Bedelleri";
            this.gridView4.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView4_FocusedRowChanged);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "SMREF";
            this.gridColumn3.FieldName = "SMREF";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // gridColumn18
            // 
            this.gridColumn18.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn18.Caption = "Bayi";
            this.gridColumn18.FieldName = "MUSTERI";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn18.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 0;
            this.gridColumn18.Width = 225;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "Yıl";
            this.gridColumn7.FieldName = "intYil";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "Ay";
            this.gridColumn6.FieldName = "intAy";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.Caption = "KGT Ciro Primi";
            this.gridColumn10.DisplayFormat.FormatString = "C2";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn10.FieldName = "mnTAH";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "mnTAH", "{0:C2}")});
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 3;
            this.gridColumn10.Width = 125;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.Caption = "NF Ciro Primi";
            this.gridColumn11.DisplayFormat.FormatString = "C2";
            this.gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn11.FieldName = "mnYEG";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn11.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "mnYEG", "{0:C2}")});
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 4;
            this.gridColumn11.Width = 125;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "KGT KDV Oranı";
            this.gridColumn2.FieldName = "intTAHKDVoran";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 5;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "NF KDV Oranı";
            this.gridColumn1.FieldName = "intYEGKDVoran";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            // 
            // gridColumn14
            // 
            this.gridColumn14.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn14.Caption = "Açıklama";
            this.gridColumn14.FieldName = "strAciklama";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 7;
            this.gridColumn14.Width = 200;
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
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 387);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(864, 72);
            this.label1.TabIndex = 35;
            // 
            // sbEkle
            // 
            this.sbEkle.Location = new System.Drawing.Point(621, 399);
            this.sbEkle.Name = "sbEkle";
            this.sbEkle.Size = new System.Drawing.Size(75, 48);
            this.sbEkle.TabIndex = 36;
            this.sbEkle.Text = "Ekle";
            this.sbEkle.Click += new System.EventHandler(this.sbEkle_Click);
            // 
            // cmbBayi
            // 
            this.cmbBayi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBayi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbBayi.FormattingEnabled = true;
            this.cmbBayi.Location = new System.Drawing.Point(66, 401);
            this.cmbBayi.Name = "cmbBayi";
            this.cmbBayi.Size = new System.Drawing.Size(231, 20);
            this.cmbBayi.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 404);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Bayi:";
            // 
            // txtYil
            // 
            this.txtYil.Location = new System.Drawing.Point(320, 401);
            this.txtYil.Name = "txtYil";
            this.txtYil.Size = new System.Drawing.Size(35, 20);
            this.txtYil.TabIndex = 39;
            this.txtYil.Text = "2016";
            this.txtYil.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(300, 404);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Yıl:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(359, 404);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Ay:";
            // 
            // txtAy
            // 
            this.txtAy.Location = new System.Drawing.Point(379, 401);
            this.txtAy.Name = "txtAy";
            this.txtAy.Size = new System.Drawing.Size(27, 20);
            this.txtAy.TabIndex = 39;
            this.txtAy.Text = "1";
            this.txtAy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(413, 404);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "KGT Ciro:";
            // 
            // txtTAH
            // 
            this.txtTAH.Location = new System.Drawing.Point(472, 401);
            this.txtTAH.Name = "txtTAH";
            this.txtTAH.Size = new System.Drawing.Size(69, 20);
            this.txtTAH.TabIndex = 39;
            this.txtTAH.Text = "0";
            this.txtTAH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(421, 430);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "NF Ciro:";
            // 
            // txtYEG
            // 
            this.txtYEG.Location = new System.Drawing.Point(472, 426);
            this.txtYEG.Name = "txtYEG";
            this.txtYEG.Size = new System.Drawing.Size(69, 20);
            this.txtYEG.TabIndex = 39;
            this.txtYEG.Text = "0";
            this.txtYEG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(66, 427);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(340, 20);
            this.txtAciklama.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 430);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "Açıklama:";
            // 
            // sbGuncelle
            // 
            this.sbGuncelle.Location = new System.Drawing.Point(702, 399);
            this.sbGuncelle.Name = "sbGuncelle";
            this.sbGuncelle.Size = new System.Drawing.Size(75, 48);
            this.sbGuncelle.TabIndex = 36;
            this.sbGuncelle.Text = "Güncelle";
            this.sbGuncelle.Click += new System.EventHandler(this.sbGuncelle_Click);
            // 
            // sbSil
            // 
            this.sbSil.Location = new System.Drawing.Point(783, 399);
            this.sbSil.Name = "sbSil";
            this.sbSil.Size = new System.Drawing.Size(75, 48);
            this.sbSil.TabIndex = 36;
            this.sbSil.Text = "Sil";
            this.sbSil.Click += new System.EventHandler(this.sbSil_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 40;
            this.button1.Text = "Excel\'den al";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(547, 404);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "KDV:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(547, 430);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "KDV:";
            // 
            // txtTAHKDV
            // 
            this.txtTAHKDV.Location = new System.Drawing.Point(585, 401);
            this.txtTAHKDV.Name = "txtTAHKDV";
            this.txtTAHKDV.Size = new System.Drawing.Size(30, 20);
            this.txtTAHKDV.TabIndex = 39;
            this.txtTAHKDV.Text = "8";
            this.txtTAHKDV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtYEGKDV
            // 
            this.txtYEGKDV.Location = new System.Drawing.Point(585, 427);
            this.txtYEGKDV.Name = "txtYEGKDV";
            this.txtYEGKDV.Size = new System.Drawing.Size(30, 20);
            this.txtYEGKDV.TabIndex = 39;
            this.txtYEGKDV.Text = "18";
            this.txtYEGKDV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmINTERNETticaripazarlamabayiciroprimleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 459);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtAy);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.txtYEG);
            this.Controls.Add(this.txtYEGKDV);
            this.Controls.Add(this.txtTAHKDV);
            this.Controls.Add(this.txtTAH);
            this.Controls.Add(this.txtYil);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBayi);
            this.Controls.Add(this.sbSil);
            this.Controls.Add(this.sbGuncelle);
            this.Controls.Add(this.sbEkle);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.gridControl4);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmINTERNETticaripazarlamabayiciroprimleri";
            this.Text = "Bayi Ciro Primleri";
            this.Load += new System.EventHandler(this.frmINTERNETticaripazarlamabayiciroprimleri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl4;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private System.Windows.Forms.Button btnYenile;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton sbEkle;
        private System.Windows.Forms.ComboBox cmbBayi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtYil;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTAH;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtYEG;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.SimpleButton sbGuncelle;
        private DevExpress.XtraEditors.SimpleButton sbSil;
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTAHKDV;
        private System.Windows.Forms.TextBox txtYEGKDV;
    }
}