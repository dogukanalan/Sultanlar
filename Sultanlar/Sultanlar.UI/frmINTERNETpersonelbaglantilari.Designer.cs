namespace Sultanlar.UI
{
    partial class frmINTERNETpersonelbaglantilari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmINTERNETpersonelbaglantilari));
            this.lbPersoneller = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnPerEkle = new System.Windows.Forms.Button();
            this.btnPerDuzenle = new System.Windows.Forms.Button();
            this.btnPerSil = new System.Windows.Forms.Button();
            this.btnPerBaglantiKaldir = new System.Windows.Forms.Button();
            this.btnPerBaglanti = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnToplu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbPersoneller
            // 
            this.lbPersoneller.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPersoneller.FormattingEnabled = true;
            this.lbPersoneller.Location = new System.Drawing.Point(0, 0);
            this.lbPersoneller.Name = "lbPersoneller";
            this.lbPersoneller.Size = new System.Drawing.Size(198, 336);
            this.lbPersoneller.TabIndex = 0;
            this.lbPersoneller.SelectedIndexChanged += new System.EventHandler(this.lbPersoneller_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbPersoneller);
            this.splitContainer1.Panel1.Controls.Add(this.btnPerEkle);
            this.splitContainer1.Panel1.Controls.Add(this.btnPerDuzenle);
            this.splitContainer1.Panel1.Controls.Add(this.btnPerSil);
            this.splitContainer1.Panel1.Controls.Add(this.btnPerBaglantiKaldir);
            this.splitContainer1.Panel1.Controls.Add(this.btnPerBaglanti);
            this.splitContainer1.Panel1.Controls.Add(this.btnToplu);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainer1.Size = new System.Drawing.Size(870, 474);
            this.splitContainer1.SplitterDistance = 198;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnPerEkle
            // 
            this.btnPerEkle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPerEkle.Location = new System.Drawing.Point(0, 336);
            this.btnPerEkle.Name = "btnPerEkle";
            this.btnPerEkle.Size = new System.Drawing.Size(198, 23);
            this.btnPerEkle.TabIndex = 1;
            this.btnPerEkle.Text = "Personel Ekle";
            this.btnPerEkle.UseVisualStyleBackColor = true;
            this.btnPerEkle.Click += new System.EventHandler(this.btnPerEkle_Click);
            // 
            // btnPerDuzenle
            // 
            this.btnPerDuzenle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPerDuzenle.Location = new System.Drawing.Point(0, 359);
            this.btnPerDuzenle.Name = "btnPerDuzenle";
            this.btnPerDuzenle.Size = new System.Drawing.Size(198, 23);
            this.btnPerDuzenle.TabIndex = 4;
            this.btnPerDuzenle.Text = "Personel Düzenle";
            this.btnPerDuzenle.UseVisualStyleBackColor = true;
            this.btnPerDuzenle.Click += new System.EventHandler(this.btnPerDuzenle_Click);
            // 
            // btnPerSil
            // 
            this.btnPerSil.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPerSil.Location = new System.Drawing.Point(0, 382);
            this.btnPerSil.Name = "btnPerSil";
            this.btnPerSil.Size = new System.Drawing.Size(198, 23);
            this.btnPerSil.TabIndex = 3;
            this.btnPerSil.Text = "Personel Sil";
            this.btnPerSil.UseVisualStyleBackColor = true;
            this.btnPerSil.Click += new System.EventHandler(this.btnPerSil_Click);
            // 
            // btnPerBaglantiKaldir
            // 
            this.btnPerBaglantiKaldir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPerBaglantiKaldir.Location = new System.Drawing.Point(0, 405);
            this.btnPerBaglantiKaldir.Name = "btnPerBaglantiKaldir";
            this.btnPerBaglantiKaldir.Size = new System.Drawing.Size(198, 23);
            this.btnPerBaglantiKaldir.TabIndex = 5;
            this.btnPerBaglantiKaldir.Text = "Personel Bağlantısını Kaldır";
            this.btnPerBaglantiKaldir.UseVisualStyleBackColor = true;
            this.btnPerBaglantiKaldir.Click += new System.EventHandler(this.btnPerBaglantiKaldir_Click);
            // 
            // btnPerBaglanti
            // 
            this.btnPerBaglanti.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPerBaglanti.Location = new System.Drawing.Point(0, 428);
            this.btnPerBaglanti.Name = "btnPerBaglanti";
            this.btnPerBaglanti.Size = new System.Drawing.Size(198, 23);
            this.btnPerBaglanti.TabIndex = 2;
            this.btnPerBaglanti.Text = "Personel Bağlantısı Yap";
            this.btnPerBaglanti.UseVisualStyleBackColor = true;
            this.btnPerBaglanti.Click += new System.EventHandler(this.btnPerBaglanti_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(668, 474);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.ViewCaption = "Bağlı Müşteriler";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.FieldName = "blBayi";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "gridColumn2";
            this.gridColumn2.FieldName = "SMREF";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Bayi";
            this.gridColumn3.FieldName = "BAYI";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Nokta";
            this.gridColumn4.FieldName = "NOKTA";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Personel";
            this.gridColumn5.FieldName = "PERSONEL";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Ünvan";
            this.gridColumn6.FieldName = "UNVAN";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // btnToplu
            // 
            this.btnToplu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnToplu.Location = new System.Drawing.Point(0, 451);
            this.btnToplu.Name = "btnToplu";
            this.btnToplu.Size = new System.Drawing.Size(198, 23);
            this.btnToplu.TabIndex = 6;
            this.btnToplu.Text = "Toplu Personel Bağla";
            this.btnToplu.UseVisualStyleBackColor = true;
            this.btnToplu.Click += new System.EventHandler(this.btnToplu_Click);
            // 
            // frmINTERNETpersonelbaglantilari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 474);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmINTERNETpersonelbaglantilari";
            this.Text = "Personel Bağlantıları";
            this.Load += new System.EventHandler(this.frmINTERNETpersonelbaglantilari_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbPersoneller;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnPerEkle;
        private System.Windows.Forms.Button btnPerSil;
        private System.Windows.Forms.Button btnPerBaglanti;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Button btnPerDuzenle;
        private System.Windows.Forms.Button btnPerBaglantiKaldir;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private System.Windows.Forms.Button btnToplu;
    }
}