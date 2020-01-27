namespace Sultanlar.UI
{
    partial class frmCHEkstresi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCHEkstresi));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAlt = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMusteri = new System.Windows.Forms.TextBox();
            this.cmbMusteriler = new System.Windows.Forms.ComboBox();
            this.lblSatirSayisi1 = new System.Windows.Forms.Label();
            this.lblSatirSayisi = new System.Windows.Forms.Label();
            this.lbMusteriler = new System.Windows.Forms.ListBox();
            this.txtMusteri1 = new System.Windows.Forms.TextBox();
            this.dtpBas = new System.Windows.Forms.DateTimePicker();
            this.dtpSon = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSatTem = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTedSatTem = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbTarih = new System.Windows.Forms.CheckBox();
            this.btnMusteriTemizle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 53);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(904, 366);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DataSourceChanged += new System.EventHandler(this.dataGridView1_DataSourceChanged);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(904, 53);
            this.label1.TabIndex = 2;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAlt
            // 
            this.lblAlt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAlt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblAlt.Location = new System.Drawing.Point(0, 419);
            this.lblAlt.Name = "lblAlt";
            this.lblAlt.Padding = new System.Windows.Forms.Padding(0, 0, 70, 0);
            this.lblAlt.Size = new System.Drawing.Size(904, 23);
            this.lblAlt.TabIndex = 13;
            this.lblAlt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Müşteri:";
            // 
            // txtMusteri
            // 
            this.txtMusteri.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMusteri.Location = new System.Drawing.Point(62, 6);
            this.txtMusteri.Name = "txtMusteri";
            this.txtMusteri.Size = new System.Drawing.Size(269, 18);
            this.txtMusteri.TabIndex = 15;
            this.txtMusteri.TextChanged += new System.EventHandler(this.txtMusteri_TextChanged);
            this.txtMusteri.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMusteri_KeyDown);
            // 
            // cmbMusteriler
            // 
            this.cmbMusteriler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMusteriler.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbMusteriler.FormattingEnabled = true;
            this.cmbMusteriler.Location = new System.Drawing.Point(62, 28);
            this.cmbMusteriler.Name = "cmbMusteriler";
            this.cmbMusteriler.Size = new System.Drawing.Size(288, 20);
            this.cmbMusteriler.TabIndex = 16;
            this.cmbMusteriler.Visible = false;
            this.cmbMusteriler.SelectedIndexChanged += new System.EventHandler(this.cmbMusteriler_SelectedIndexChanged);
            // 
            // lblSatirSayisi1
            // 
            this.lblSatirSayisi1.AutoSize = true;
            this.lblSatirSayisi1.Location = new System.Drawing.Point(793, 424);
            this.lblSatirSayisi1.Name = "lblSatirSayisi1";
            this.lblSatirSayisi1.Size = new System.Drawing.Size(61, 13);
            this.lblSatirSayisi1.TabIndex = 18;
            this.lblSatirSayisi1.Text = "Satır Sayısı:";
            // 
            // lblSatirSayisi
            // 
            this.lblSatirSayisi.ForeColor = System.Drawing.Color.Red;
            this.lblSatirSayisi.Location = new System.Drawing.Point(860, 424);
            this.lblSatirSayisi.Name = "lblSatirSayisi";
            this.lblSatirSayisi.Size = new System.Drawing.Size(44, 13);
            this.lblSatirSayisi.TabIndex = 17;
            this.lblSatirSayisi.Text = "0";
            this.lblSatirSayisi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbMusteriler
            // 
            this.lbMusteriler.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbMusteriler.FormattingEnabled = true;
            this.lbMusteriler.ItemHeight = 12;
            this.lbMusteriler.Location = new System.Drawing.Point(62, 28);
            this.lbMusteriler.Name = "lbMusteriler";
            this.lbMusteriler.Size = new System.Drawing.Size(288, 136);
            this.lbMusteriler.TabIndex = 19;
            this.lbMusteriler.Visible = false;
            this.lbMusteriler.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbMusteriler_KeyDown);
            // 
            // txtMusteri1
            // 
            this.txtMusteri1.BackColor = System.Drawing.Color.White;
            this.txtMusteri1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMusteri1.Location = new System.Drawing.Point(62, 29);
            this.txtMusteri1.Name = "txtMusteri1";
            this.txtMusteri1.ReadOnly = true;
            this.txtMusteri1.Size = new System.Drawing.Size(288, 18);
            this.txtMusteri1.TabIndex = 20;
            this.txtMusteri1.Visible = false;
            // 
            // dtpBas
            // 
            this.dtpBas.Enabled = false;
            this.dtpBas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpBas.Location = new System.Drawing.Point(799, 5);
            this.dtpBas.Name = "dtpBas";
            this.dtpBas.Size = new System.Drawing.Size(93, 18);
            this.dtpBas.TabIndex = 21;
            this.dtpBas.ValueChanged += new System.EventHandler(this.dtpBas_ValueChanged);
            // 
            // dtpSon
            // 
            this.dtpSon.Enabled = false;
            this.dtpSon.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpSon.Location = new System.Drawing.Point(799, 31);
            this.dtpSon.Name = "dtpSon";
            this.dtpSon.Size = new System.Drawing.Size(93, 18);
            this.dtpSon.TabIndex = 21;
            this.dtpSon.ValueChanged += new System.EventHandler(this.dtpBas_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(367, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Satış Temsilcisi:";
            // 
            // cmbSatTem
            // 
            this.cmbSatTem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSatTem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbSatTem.FormattingEnabled = true;
            this.cmbSatTem.Location = new System.Drawing.Point(501, 5);
            this.cmbSatTem.Name = "cmbSatTem";
            this.cmbSatTem.Size = new System.Drawing.Size(240, 20);
            this.cmbSatTem.Sorted = true;
            this.cmbSatTem.TabIndex = 22;
            this.cmbSatTem.SelectedIndexChanged += new System.EventHandler(this.cmbSatTem_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(367, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Tedarikçi Satış Temsilcisi:";
            // 
            // cmbTedSatTem
            // 
            this.cmbTedSatTem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTedSatTem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbTedSatTem.FormattingEnabled = true;
            this.cmbTedSatTem.Location = new System.Drawing.Point(501, 28);
            this.cmbTedSatTem.Name = "cmbTedSatTem";
            this.cmbTedSatTem.Size = new System.Drawing.Size(240, 20);
            this.cmbTedSatTem.Sorted = true;
            this.cmbTedSatTem.TabIndex = 22;
            this.cmbTedSatTem.SelectedIndexChanged += new System.EventHandler(this.cmbTedSatTem_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(759, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Tarih:";
            // 
            // cbTarih
            // 
            this.cbTarih.AutoSize = true;
            this.cbTarih.Location = new System.Drawing.Point(770, 30);
            this.cbTarih.Name = "cbTarih";
            this.cbTarih.Size = new System.Drawing.Size(15, 14);
            this.cbTarih.TabIndex = 23;
            this.cbTarih.UseVisualStyleBackColor = true;
            this.cbTarih.CheckedChanged += new System.EventHandler(this.cbTarih_CheckedChanged);
            // 
            // btnMusteriTemizle
            // 
            this.btnMusteriTemizle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMusteriTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMusteriTemizle.Location = new System.Drawing.Point(331, 6);
            this.btnMusteriTemizle.Name = "btnMusteriTemizle";
            this.btnMusteriTemizle.Size = new System.Drawing.Size(19, 18);
            this.btnMusteriTemizle.TabIndex = 24;
            this.btnMusteriTemizle.Text = "-";
            this.btnMusteriTemizle.UseVisualStyleBackColor = true;
            this.btnMusteriTemizle.Click += new System.EventHandler(this.btnMusteriTemizle_Click);
            // 
            // frmCHEkstresi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 442);
            this.Controls.Add(this.btnMusteriTemizle);
            this.Controls.Add(this.cbTarih);
            this.Controls.Add(this.cmbTedSatTem);
            this.Controls.Add(this.cmbSatTem);
            this.Controls.Add(this.dtpSon);
            this.Controls.Add(this.dtpBas);
            this.Controls.Add(this.lbMusteriler);
            this.Controls.Add(this.txtMusteri1);
            this.Controls.Add(this.lblSatirSayisi1);
            this.Controls.Add(this.lblSatirSayisi);
            this.Controls.Add(this.cmbMusteriler);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMusteri);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblAlt);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCHEkstresi";
            this.Text = "Finans : C/H Ekstresi";
            this.Load += new System.EventHandler(this.frmCHEkstresi_Load);
            this.SizeChanged += new System.EventHandler(this.frmCHEkstresi_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAlt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMusteri;
        private System.Windows.Forms.ComboBox cmbMusteriler;
        private System.Windows.Forms.Label lblSatirSayisi1;
        private System.Windows.Forms.Label lblSatirSayisi;
        private System.Windows.Forms.ListBox lbMusteriler;
        private System.Windows.Forms.TextBox txtMusteri1;
        private System.Windows.Forms.DateTimePicker dtpBas;
        private System.Windows.Forms.DateTimePicker dtpSon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSatTem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTedSatTem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbTarih;
        private System.Windows.Forms.Button btnMusteriTemizle;
    }
}