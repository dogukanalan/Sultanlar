namespace Sultanlar.UI
{
    partial class frmINTERNETdisSiparisler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmINTERNETdisSiparisler));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnYenile = new System.Windows.Forms.Button();
            this.lblAlt = new System.Windows.Forms.Label();
            this.btnIptal = new System.Windows.Forms.Button();
            this.cltintSirketID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrSirket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cldtOlusmaTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clQUANTUMNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clbintDisKod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clpkID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrFaturaAdSoyad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clstrKargoSirketi = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clstrKargoTakip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeight = 32;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cltintSirketID,
            this.clstrSirket,
            this.cldtOlusmaTarihi,
            this.clQUANTUMNo,
            this.clbintDisKod,
            this.clpkID,
            this.clstrFaturaAdSoyad,
            this.clstrKargoSirketi,
            this.clstrKargoTakip});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 33;
            this.dataGridView1.Size = new System.Drawing.Size(970, 373);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // btnYenile
            // 
            this.btnYenile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnYenile.Image = global::Sultanlar.UI.Properties.Resources.refresh;
            this.btnYenile.Location = new System.Drawing.Point(0, 0);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(33, 33);
            this.btnYenile.TabIndex = 32;
            this.btnYenile.UseVisualStyleBackColor = true;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // lblAlt
            // 
            this.lblAlt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblAlt.Location = new System.Drawing.Point(0, 373);
            this.lblAlt.Name = "lblAlt";
            this.lblAlt.Size = new System.Drawing.Size(970, 40);
            this.lblAlt.TabIndex = 33;
            // 
            // btnIptal
            // 
            this.btnIptal.Location = new System.Drawing.Point(9, 381);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(114, 23);
            this.btnIptal.TabIndex = 34;
            this.btnIptal.Text = "Siparişi iptal et";
            this.btnIptal.UseVisualStyleBackColor = true;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // cltintSirketID
            // 
            this.cltintSirketID.DataPropertyName = "tintSirketID";
            this.cltintSirketID.HeaderText = "Şirket No";
            this.cltintSirketID.Name = "cltintSirketID";
            this.cltintSirketID.ReadOnly = true;
            this.cltintSirketID.Visible = false;
            this.cltintSirketID.Width = 75;
            // 
            // clstrSirket
            // 
            this.clstrSirket.DataPropertyName = "strSirket";
            this.clstrSirket.HeaderText = "Kaynak Firma";
            this.clstrSirket.Name = "clstrSirket";
            this.clstrSirket.ReadOnly = true;
            this.clstrSirket.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clstrSirket.Width = 50;
            // 
            // cldtOlusmaTarihi
            // 
            this.cldtOlusmaTarihi.DataPropertyName = "dtOlusmaTarihi";
            this.cldtOlusmaTarihi.HeaderText = "Sipariş Tarihi";
            this.cldtOlusmaTarihi.Name = "cldtOlusmaTarihi";
            this.cldtOlusmaTarihi.ReadOnly = true;
            // 
            // clQUANTUMNo
            // 
            this.clQUANTUMNo.DataPropertyName = "QUANTUMNo";
            this.clQUANTUMNo.HeaderText = "Quantum No";
            this.clQUANTUMNo.Name = "clQUANTUMNo";
            this.clQUANTUMNo.ReadOnly = true;
            this.clQUANTUMNo.Width = 125;
            // 
            // clbintDisKod
            // 
            this.clbintDisKod.DataPropertyName = "bintDisKod";
            this.clbintDisKod.HeaderText = "F.Sipariş No";
            this.clbintDisKod.Name = "clbintDisKod";
            this.clbintDisKod.ReadOnly = true;
            this.clbintDisKod.Width = 125;
            // 
            // clpkID
            // 
            this.clpkID.DataPropertyName = "pkID";
            this.clpkID.HeaderText = "Sipariş No";
            this.clpkID.Name = "clpkID";
            this.clpkID.ReadOnly = true;
            // 
            // clstrFaturaAdSoyad
            // 
            this.clstrFaturaAdSoyad.DataPropertyName = "strFaturaAdSoyad";
            this.clstrFaturaAdSoyad.HeaderText = "Ad Soyad";
            this.clstrFaturaAdSoyad.Name = "clstrFaturaAdSoyad";
            this.clstrFaturaAdSoyad.ReadOnly = true;
            this.clstrFaturaAdSoyad.Width = 150;
            // 
            // clstrKargoSirketi
            // 
            this.clstrKargoSirketi.DataPropertyName = "strKargoSirketi";
            this.clstrKargoSirketi.HeaderText = "Kargo Şirketi";
            this.clstrKargoSirketi.Items.AddRange(new object[] {
            "Ceva Lojistik",
            "MNG",
            "Yurtiçi",
            "Aras",
            "Sürat"});
            this.clstrKargoSirketi.Name = "clstrKargoSirketi";
            this.clstrKargoSirketi.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clstrKargoSirketi.Width = 120;
            // 
            // clstrKargoTakip
            // 
            this.clstrKargoTakip.DataPropertyName = "strKargoTakip";
            this.clstrKargoTakip.HeaderText = "Kargo Takip No";
            this.clstrKargoTakip.Name = "clstrKargoTakip";
            this.clstrKargoTakip.Width = 150;
            // 
            // frmINTERNETdisSiparisler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 413);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblAlt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmINTERNETdisSiparisler";
            this.Text = "E-Ticaret Siparişleri";
            this.Load += new System.EventHandler(this.frmDisSiparisler_Load);
            this.SizeChanged += new System.EventHandler(this.frmINTERNETdisSiparisler_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnYenile;
        private System.Windows.Forms.Label lblAlt;
        private System.Windows.Forms.Button btnIptal;
        private System.Windows.Forms.DataGridViewTextBoxColumn cltintSirketID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrSirket;
        private System.Windows.Forms.DataGridViewTextBoxColumn cldtOlusmaTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn clQUANTUMNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clbintDisKod;
        private System.Windows.Forms.DataGridViewTextBoxColumn clpkID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrFaturaAdSoyad;
        private System.Windows.Forms.DataGridViewComboBoxColumn clstrKargoSirketi;
        private System.Windows.Forms.DataGridViewTextBoxColumn clstrKargoTakip;
    }
}