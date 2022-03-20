
namespace Sultanlar.UI
{
    partial class frmINTERNETticaripazarlamavericekmemusteri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmINTERNETticaripazarlamavericekmemusteri));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.clSecim = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CH_KOD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CH_ACIKLAMA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MUSKOD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MUSTERI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ILCE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SMREF1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clSecim,
            this.CH_KOD,
            this.CH_ACIKLAMA,
            this.MUSKOD,
            this.MUSTERI,
            this.IL,
            this.ILCE,
            this.SMREF1});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1023, 754);
            this.dataGridView1.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label11.Location = new System.Drawing.Point(0, 754);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(1023, 33);
            this.label11.TabIndex = 1;
            this.label11.Text = "Satır Sayısı";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(127, 759);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Seçilen carileri aç";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 763);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(118, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Sadece Olmayanlar";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(45, 5);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // clSecim
            // 
            this.clSecim.DataPropertyName = "Secim";
            this.clSecim.HeaderText = "     Seçim";
            this.clSecim.Name = "clSecim";
            // 
            // CH_KOD
            // 
            this.CH_KOD.DataPropertyName = "CH_KOD";
            this.CH_KOD.HeaderText = "Satış Cari Kod";
            this.CH_KOD.Name = "CH_KOD";
            this.CH_KOD.ReadOnly = true;
            // 
            // CH_ACIKLAMA
            // 
            this.CH_ACIKLAMA.DataPropertyName = "CH_ACIKLAMA";
            this.CH_ACIKLAMA.HeaderText = "Satış Cari";
            this.CH_ACIKLAMA.Name = "CH_ACIKLAMA";
            this.CH_ACIKLAMA.ReadOnly = true;
            // 
            // MUSKOD
            // 
            this.MUSKOD.DataPropertyName = "MUS KOD";
            this.MUSKOD.HeaderText = "Kayıtlı Cari Kod";
            this.MUSKOD.Name = "MUSKOD";
            this.MUSKOD.ReadOnly = true;
            // 
            // MUSTERI
            // 
            this.MUSTERI.DataPropertyName = "MUSTERI";
            this.MUSTERI.HeaderText = "Kayıtlı Cari";
            this.MUSTERI.Name = "MUSTERI";
            this.MUSTERI.ReadOnly = true;
            // 
            // IL
            // 
            this.IL.DataPropertyName = "IL";
            this.IL.HeaderText = "İl";
            this.IL.Name = "IL";
            this.IL.ReadOnly = true;
            // 
            // ILCE
            // 
            this.ILCE.DataPropertyName = "ILCE";
            this.ILCE.HeaderText = "İlçe";
            this.ILCE.Name = "ILCE";
            this.ILCE.ReadOnly = true;
            // 
            // SMREF1
            // 
            this.SMREF1.DataPropertyName = "SMREF";
            this.SMREF1.HeaderText = "Kod";
            this.SMREF1.Name = "SMREF1";
            this.SMREF1.ReadOnly = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(304, 761);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(118, 20);
            this.textBox1.TabIndex = 14;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(428, 759);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(39, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Ara";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(473, 761);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(296, 21);
            this.comboBox1.TabIndex = 16;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(775, 759);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(63, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "Eşleştir";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmINTERNETticaripazarlamavericekmemusteri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 787);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmINTERNETticaripazarlamavericekmemusteri";
            this.Text = "Ticari Pazarlama : Veri Çekme Müşteriler";
            this.Load += new System.EventHandler(this.frmINTERNETticaripazarlamavericekmemusteri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clSecim;
        private System.Windows.Forms.DataGridViewTextBoxColumn CH_KOD;
        private System.Windows.Forms.DataGridViewTextBoxColumn CH_ACIKLAMA;
        private System.Windows.Forms.DataGridViewTextBoxColumn MUSKOD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MUSTERI;
        private System.Windows.Forms.DataGridViewTextBoxColumn IL;
        private System.Windows.Forms.DataGridViewTextBoxColumn ILCE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SMREF1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button3;
    }
}