namespace Sultanlar.UI
{
    partial class frmAT2aracbedellerikopyala
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAT2aracbedellerikopyala));
            this.clbAraclar = new System.Windows.Forms.CheckedListBox();
            this.btnKopyala = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbAracBedelleri = new Sultanlar.UI.VListBox();
            this.clbAracBedelleri = new System.Windows.Forms.CheckedListBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clbAraclar
            // 
            this.clbAraclar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbAraclar.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.clbAraclar.FormattingEnabled = true;
            this.clbAraclar.Location = new System.Drawing.Point(0, 0);
            this.clbAraclar.Name = "clbAraclar";
            this.clbAraclar.Size = new System.Drawing.Size(260, 400);
            this.clbAraclar.TabIndex = 2;
            // 
            // btnKopyala
            // 
            this.btnKopyala.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnKopyala.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnKopyala.Location = new System.Drawing.Point(0, 400);
            this.btnKopyala.Name = "btnKopyala";
            this.btnKopyala.Size = new System.Drawing.Size(784, 32);
            this.btnKopyala.TabIndex = 3;
            this.btnKopyala.Text = "Kopyala";
            this.btnKopyala.UseVisualStyleBackColor = true;
            this.btnKopyala.Click += new System.EventHandler(this.btnKopyala_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbAracBedelleri);
            this.splitContainer1.Panel1.Controls.Add(this.clbAracBedelleri);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.clbAraclar);
            this.splitContainer1.Size = new System.Drawing.Size(784, 400);
            this.splitContainer1.SplitterDistance = 520;
            this.splitContainer1.TabIndex = 4;
            // 
            // lbAracBedelleri
            // 
            this.lbAracBedelleri.Count = 1;
            this.lbAracBedelleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAracBedelleri.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbAracBedelleri.FormattingEnabled = true;
            this.lbAracBedelleri.ItemHeight = 16;
            this.lbAracBedelleri.Location = new System.Drawing.Point(0, 0);
            this.lbAracBedelleri.Name = "lbAracBedelleri";
            this.lbAracBedelleri.Size = new System.Drawing.Size(520, 400);
            this.lbAracBedelleri.TabIndex = 4;
            // 
            // clbAracBedelleri
            // 
            this.clbAracBedelleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbAracBedelleri.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.clbAracBedelleri.FormattingEnabled = true;
            this.clbAracBedelleri.Location = new System.Drawing.Point(0, 0);
            this.clbAracBedelleri.Name = "clbAracBedelleri";
            this.clbAracBedelleri.Size = new System.Drawing.Size(520, 400);
            this.clbAracBedelleri.TabIndex = 3;
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.White;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtLog.Location = new System.Drawing.Point(0, 432);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(784, 130);
            this.txtLog.TabIndex = 5;
            // 
            // frmAT2aracbedellerikopyala
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnKopyala);
            this.Controls.Add(this.txtLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAT2aracbedellerikopyala";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kira Bedeli Kopyalama";
            this.Load += new System.EventHandler(this.frmAT2aracbedellerikopyala_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbAraclar;
        private System.Windows.Forms.Button btnKopyala;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckedListBox clbAracBedelleri;
        private System.Windows.Forms.TextBox txtLog;
        private VListBox lbAracBedelleri;
    }
}