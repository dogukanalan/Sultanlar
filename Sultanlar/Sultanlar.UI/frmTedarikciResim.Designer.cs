namespace Sultanlar.UI
{
    partial class frmTedarikciResim
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnKucult = new System.Windows.Forms.Button();
            this.btnBuyut = new System.Windows.Forms.Button();
            this.btnSola = new System.Windows.Forms.Button();
            this.btnYukariya = new System.Windows.Forms.Button();
            this.btnSaga = new System.Windows.Forms.Button();
            this.btnAsagiya = new System.Windows.Forms.Button();
            this.btnTamamla = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 500);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnKucult
            // 
            this.btnKucult.Location = new System.Drawing.Point(4, 521);
            this.btnKucult.Name = "btnKucult";
            this.btnKucult.Size = new System.Drawing.Size(75, 23);
            this.btnKucult.TabIndex = 1;
            this.btnKucult.Text = "Küçült";
            this.btnKucult.UseVisualStyleBackColor = true;
            this.btnKucult.Click += new System.EventHandler(this.btnKucult_Click);
            // 
            // btnBuyut
            // 
            this.btnBuyut.Location = new System.Drawing.Point(85, 521);
            this.btnBuyut.Name = "btnBuyut";
            this.btnBuyut.Size = new System.Drawing.Size(75, 23);
            this.btnBuyut.TabIndex = 1;
            this.btnBuyut.Text = "Büyüt";
            this.btnBuyut.UseVisualStyleBackColor = true;
            this.btnBuyut.Click += new System.EventHandler(this.btnBuyut_Click);
            // 
            // btnSola
            // 
            this.btnSola.Location = new System.Drawing.Point(166, 521);
            this.btnSola.Name = "btnSola";
            this.btnSola.Size = new System.Drawing.Size(75, 23);
            this.btnSola.TabIndex = 1;
            this.btnSola.Text = "Sola";
            this.btnSola.UseVisualStyleBackColor = true;
            this.btnSola.Click += new System.EventHandler(this.btnSola_Click);
            // 
            // btnYukariya
            // 
            this.btnYukariya.Location = new System.Drawing.Point(247, 506);
            this.btnYukariya.Name = "btnYukariya";
            this.btnYukariya.Size = new System.Drawing.Size(75, 23);
            this.btnYukariya.TabIndex = 1;
            this.btnYukariya.Text = "Yukarıya";
            this.btnYukariya.UseVisualStyleBackColor = true;
            this.btnYukariya.Click += new System.EventHandler(this.btnYukariya_Click);
            // 
            // btnSaga
            // 
            this.btnSaga.Location = new System.Drawing.Point(328, 521);
            this.btnSaga.Name = "btnSaga";
            this.btnSaga.Size = new System.Drawing.Size(75, 23);
            this.btnSaga.TabIndex = 1;
            this.btnSaga.Text = "Sağa";
            this.btnSaga.UseVisualStyleBackColor = true;
            this.btnSaga.Click += new System.EventHandler(this.btnSaga_Click);
            // 
            // btnAsagiya
            // 
            this.btnAsagiya.Location = new System.Drawing.Point(247, 535);
            this.btnAsagiya.Name = "btnAsagiya";
            this.btnAsagiya.Size = new System.Drawing.Size(75, 23);
            this.btnAsagiya.TabIndex = 1;
            this.btnAsagiya.Text = "Aşağıya";
            this.btnAsagiya.UseVisualStyleBackColor = true;
            this.btnAsagiya.Click += new System.EventHandler(this.btnAsagiya_Click);
            // 
            // btnTamamla
            // 
            this.btnTamamla.Location = new System.Drawing.Point(425, 500);
            this.btnTamamla.Name = "btnTamamla";
            this.btnTamamla.Size = new System.Drawing.Size(75, 66);
            this.btnTamamla.TabIndex = 2;
            this.btnTamamla.Text = "Tamamla";
            this.btnTamamla.UseVisualStyleBackColor = true;
            this.btnTamamla.Click += new System.EventHandler(this.btnTamamla_Click);
            // 
            // frmTedarikciResim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 565);
            this.Controls.Add(this.btnTamamla);
            this.Controls.Add(this.btnAsagiya);
            this.Controls.Add(this.btnYukariya);
            this.Controls.Add(this.btnSaga);
            this.Controls.Add(this.btnSola);
            this.Controls.Add(this.btnBuyut);
            this.Controls.Add(this.btnKucult);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTedarikciResim";
            this.Text = "Tedarikçi Resmi";
            this.Load += new System.EventHandler(this.frmTedarikciResim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnKucult;
        private System.Windows.Forms.Button btnBuyut;
        private System.Windows.Forms.Button btnSola;
        private System.Windows.Forms.Button btnYukariya;
        private System.Windows.Forms.Button btnSaga;
        private System.Windows.Forms.Button btnAsagiya;
        private System.Windows.Forms.Button btnTamamla;
    }
}