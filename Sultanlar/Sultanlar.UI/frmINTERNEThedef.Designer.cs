namespace Sultanlar.UI
{
    partial class frmINTERNEThedef
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmINTERNEThedef));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.txtPRIM = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtYIL = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcanSLSREF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanPERSONEL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanSMREF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanBAYI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanYIL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanPRIMB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanPRIMGRUBU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcanHEDEF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnExcelYardim = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(0, 28);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(286, 345);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(73, 60);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(307, 20);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // txtPRIM
            // 
            this.txtPRIM.Location = new System.Drawing.Point(73, 115);
            this.txtPRIM.Name = "txtPRIM";
            this.txtPRIM.Size = new System.Drawing.Size(307, 20);
            this.txtPRIM.TabIndex = 3;
            this.txtPRIM.Text = "0,00";
            this.txtPRIM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(73, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(307, 49);
            this.button1.TabIndex = 4;
            this.button1.Text = "Gir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(73, 33);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(307, 20);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Malzemeler:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ay:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hedef (Koli):";
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(684, 28);
            this.label4.TabIndex = 7;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 5);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(45, 17);
            this.radioButton1.TabIndex = 8;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Bayi";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(69, 5);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(51, 17);
            this.radioButton2.TabIndex = 8;
            this.radioButton2.Text = "Satıcı";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Yıl:";
            // 
            // txtYIL
            // 
            this.txtYIL.Location = new System.Drawing.Point(73, 85);
            this.txtYIL.Name = "txtYIL";
            this.txtYIL.Size = new System.Drawing.Size(307, 20);
            this.txtYIL.TabIndex = 3;
            this.txtYIL.Text = "2019";
            this.txtYIL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtYIL.TextChanged += new System.EventHandler(this.txtYIL_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(496, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Excel\'den Al";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.gridControl1.Size = new System.Drawing.Size(684, 373);
            this.gridControl1.TabIndex = 10;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Visible = false;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcanSLSREF,
            this.gcanPERSONEL,
            this.gcanSMREF,
            this.gcanBAYI,
            this.gcanYIL,
            this.gcanAY,
            this.gcanPRIMB,
            this.gcanPRIMGRUBU,
            this.gcanHEDEF});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.ViewCaption = "Hedefler";
            // 
            // gcanSLSREF
            // 
            this.gcanSLSREF.Caption = "Per.Kod";
            this.gcanSLSREF.FieldName = "SLSREF";
            this.gcanSLSREF.Name = "gcanSLSREF";
            this.gcanSLSREF.OptionsColumn.AllowEdit = false;
            this.gcanSLSREF.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanSLSREF.Visible = true;
            this.gcanSLSREF.VisibleIndex = 0;
            // 
            // gcanPERSONEL
            // 
            this.gcanPERSONEL.Caption = "Personel";
            this.gcanPERSONEL.FieldName = "PERSONEL";
            this.gcanPERSONEL.Name = "gcanPERSONEL";
            this.gcanPERSONEL.OptionsColumn.AllowEdit = false;
            this.gcanPERSONEL.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanPERSONEL.Visible = true;
            this.gcanPERSONEL.VisibleIndex = 1;
            this.gcanPERSONEL.Width = 110;
            // 
            // gcanSMREF
            // 
            this.gcanSMREF.Caption = "Bayi Kod";
            this.gcanSMREF.FieldName = "SMREF";
            this.gcanSMREF.Name = "gcanSMREF";
            this.gcanSMREF.OptionsColumn.AllowEdit = false;
            this.gcanSMREF.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanSMREF.Visible = true;
            this.gcanSMREF.VisibleIndex = 2;
            // 
            // gcanBAYI
            // 
            this.gcanBAYI.Caption = "Bayi";
            this.gcanBAYI.FieldName = "BAYI";
            this.gcanBAYI.Name = "gcanBAYI";
            this.gcanBAYI.OptionsColumn.AllowEdit = false;
            this.gcanBAYI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanBAYI.Visible = true;
            this.gcanBAYI.VisibleIndex = 3;
            this.gcanBAYI.Width = 190;
            // 
            // gcanYIL
            // 
            this.gcanYIL.Caption = "Yıl";
            this.gcanYIL.FieldName = "YIL";
            this.gcanYIL.Name = "gcanYIL";
            this.gcanYIL.OptionsColumn.AllowEdit = false;
            this.gcanYIL.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanYIL.Visible = true;
            this.gcanYIL.VisibleIndex = 4;
            // 
            // gcanAY
            // 
            this.gcanAY.Caption = "Ay";
            this.gcanAY.FieldName = "AY";
            this.gcanAY.Name = "gcanAY";
            this.gcanAY.OptionsColumn.AllowEdit = false;
            this.gcanAY.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanAY.Visible = true;
            this.gcanAY.VisibleIndex = 5;
            // 
            // gcanPRIMB
            // 
            this.gcanPRIMB.Caption = "M.Kod";
            this.gcanPRIMB.FieldName = "PRIMB";
            this.gcanPRIMB.Name = "gcanPRIMB";
            this.gcanPRIMB.OptionsColumn.AllowEdit = false;
            this.gcanPRIMB.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanPRIMB.Visible = true;
            this.gcanPRIMB.VisibleIndex = 6;
            // 
            // gcanPRIMGRUBU
            // 
            this.gcanPRIMGRUBU.Caption = "Malzeme";
            this.gcanPRIMGRUBU.FieldName = "PRIMGRUBU";
            this.gcanPRIMGRUBU.Name = "gcanPRIMGRUBU";
            this.gcanPRIMGRUBU.OptionsColumn.AllowEdit = false;
            this.gcanPRIMGRUBU.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanPRIMGRUBU.Visible = true;
            this.gcanPRIMGRUBU.VisibleIndex = 7;
            this.gcanPRIMGRUBU.Width = 150;
            // 
            // gcanHEDEF
            // 
            this.gcanHEDEF.Caption = "Hedef (Koli)";
            this.gcanHEDEF.FieldName = "HEDEF";
            this.gcanHEDEF.Name = "gcanHEDEF";
            this.gcanHEDEF.OptionsColumn.AllowEdit = false;
            this.gcanHEDEF.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcanHEDEF.Visible = true;
            this.gcanHEDEF.VisibleIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.txtPRIM);
            this.panel1.Controls.Add(this.txtYIL);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(292, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 345);
            this.panel1.TabIndex = 11;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(237, 6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(98, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Tabloyu Göster";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnExcelYardim
            // 
            this.btnExcelYardim.ForeColor = System.Drawing.Color.Blue;
            this.btnExcelYardim.Location = new System.Drawing.Point(469, 2);
            this.btnExcelYardim.Name = "btnExcelYardim";
            this.btnExcelYardim.Size = new System.Drawing.Size(21, 22);
            this.btnExcelYardim.TabIndex = 13;
            this.btnExcelYardim.Text = "?";
            this.btnExcelYardim.UseVisualStyleBackColor = true;
            this.btnExcelYardim.Click += new System.EventHandler(this.btnExcelYardim_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(341, 5);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(56, 17);
            this.checkBox2.TabIndex = 14;
            this.checkBox2.Text = "Bonus";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // frmINTERNEThedef
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 373);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.btnExcelYardim);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gridControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmINTERNEThedef";
            this.Text = "Hedefler";
            this.Load += new System.EventHandler(this.frmINTERNEThedef_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox txtPRIM;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtYIL;
        private System.Windows.Forms.Button button2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gcanSLSREF;
        private DevExpress.XtraGrid.Columns.GridColumn gcanPERSONEL;
        private DevExpress.XtraGrid.Columns.GridColumn gcanSMREF;
        private DevExpress.XtraGrid.Columns.GridColumn gcanBAYI;
        private DevExpress.XtraGrid.Columns.GridColumn gcanYIL;
        private DevExpress.XtraGrid.Columns.GridColumn gcanAY;
        private DevExpress.XtraGrid.Columns.GridColumn gcanPRIMB;
        private DevExpress.XtraGrid.Columns.GridColumn gcanPRIMGRUBU;
        private DevExpress.XtraGrid.Columns.GridColumn gcanHEDEF;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnExcelYardim;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}