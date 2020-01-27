using Sultanlar.Class;
using Sultanlar.DatabaseObject.Internet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sultanlar.UI
{
    public partial class frmINTERNETresim : Form
    {
        public frmINTERNETresim(string resimUrl)
        {
            InitializeComponent();

            kaydet = false;
            olcek = 960;
            Img = new Image[12];
            Img[0] = ResimOlusturTek(Resim.ByteToImage(File.ReadAllBytes(resimUrl)), olcek, 0, 0);
        }

        private int olcek;
        private Image Imaj;
        private Image[] Img;
        private int[] yukardanuzaklik;
        private int[] soldanuzaklik;
        private int[] buyukluk;

        public Image imaj => ResimKucult(pictureBox1.Image, olcek, true); //ResimKucult(Imaj, Imaj.Width, true);
        public bool kaydet;

        private int yukseklik(int radio) => Convert.ToInt32(Convert.ToDouble(buyukluk[radio]) / (Convert.ToDouble(Img[radio].Width) / Convert.ToDouble(Img[radio].Height)));

        private void frmINTERNETresim_Load(object sender, EventArgs e)
        {
            double ar = Convert.ToDouble(Img[0].Width) / Convert.ToDouble(Img[0].Height);
            int birinciresimgenislik = ar >= 1 ? olcek : Convert.ToInt32(olcek * ar);
            int birinciresimsoldan = ar >= 1 ? 0 : (olcek - birinciresimgenislik) / 2;
            int birinciresimyukardan = ar >= 1 ? (olcek - Convert.ToInt32(olcek / ar)) / 2 : 0;

            yukardanuzaklik = new int[12] { birinciresimyukardan, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            soldanuzaklik = new int[12] { birinciresimsoldan, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            buyukluk = new int[12] { birinciresimgenislik, olcek, olcek, olcek, olcek, olcek, olcek, olcek, olcek, olcek, olcek, olcek };
            ResimiKoy();
        }

        private Image ResimOlustur(Image[] resim, int[] buyukluk, int[] soldanuzaklik, int[] yukardanuzaklik)
        {
            Bitmap bmp = new Bitmap(olcek, olcek);
            Graphics gr = Graphics.FromImage(bmp);
            Image img;

            for (int i = 0; i < resim.Length; i++)
            {
                if (resim[i] != null)
                {
                    img = ResimKucult(resim[i], buyukluk[i], false);
                    int genislik = img.Width;
                    int yukseklik = img.Height;
                    double aspectRatio = Convert.ToDouble(img.Height) / img.Width;
                    genislik = buyukluk[i];
                    yukseklik = Convert.ToInt32(aspectRatio * genislik);
                    gr.DrawImage(img, soldanuzaklik[i], yukardanuzaklik[i], genislik, yukseklik);
                    img.Dispose();
                    GC.SuppressFinalize(img);
                }
            }

            Image donendeger = bmp;
            return donendeger;
        }

        private Image ResimOlusturTek(Image resim, int buyukluk, int soldanuzaklik, int yukardanuzaklik)
        {
            Image img = ResimKucult(resim, buyukluk, false);
            int genislik = img.Width;
            int yukseklik = img.Height;
            double aspectRatio = Convert.ToDouble(img.Height) / img.Width;
            genislik = buyukluk;
            yukseklik = Convert.ToInt32(aspectRatio * genislik);

            Bitmap bmp = new Bitmap(genislik, yukseklik);
            Graphics gr = Graphics.FromImage(bmp);

            gr.DrawImage(img, soldanuzaklik, yukardanuzaklik, genislik, yukseklik);
            img.Dispose();

            Image donendeger = bmp;
            return donendeger;
        }

        private Image ResimOlusturBos()
        {
            Bitmap bmp = new Bitmap(olcek, olcek);
            Graphics gr = Graphics.FromImage(bmp);
            gr.FillRectangle(Brushes.Transparent, 0, 0, olcek, olcek);
            Image donendeger = bmp;
            return donendeger;
        }

        private Image ResimKopyala(Image resim)
        {
            Bitmap bmp = new Bitmap(resim.Width, resim.Height);
            Graphics gr = Graphics.FromImage(bmp);
            gr.DrawImage(resim, 0, 0, resim.Width, resim.Height);
            Image donendeger = bmp;
            return donendeger;
        }

        private Image ResimKucult(Image BuyukResim, int Genislik, bool arkabeyaz)
        {
            double aspectRatio = Convert.ToDouble(BuyukResim.Height) / Convert.ToDouble(BuyukResim.Width);
            Image kucukResim = ResimKucult(BuyukResim, Genislik, Convert.ToInt32(aspectRatio * Genislik), arkabeyaz);
            return kucukResim;
        }

        private Image ResimKucult(Image BuyukResim, int Width, int Height, bool arkabeyaz)
        {
            Bitmap bmp = (Bitmap)BuyukResim;
            if (arkabeyaz)
            {
                bmp = new Bitmap(BuyukResim.Width, BuyukResim.Height);
                Graphics gr = Graphics.FromImage(bmp);
                gr.FillRectangle(Brushes.White, 0, 0, BuyukResim.Width, BuyukResim.Height);
                gr.DrawImage(BuyukResim, 0, 0, BuyukResim.Width, BuyukResim.Height);
            }

            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            g.DrawImage(bmp, 0, 0, Width, Height);
            g.Dispose();

            return b;
        }

        private void ResimiKoy()
        {
            Imaj = ResimOlustur(Img, buyukluk, soldanuzaklik, yukardanuzaklik);
            pictureBox1.Image = Imaj;
            pictureBox2.Image = ResimOlusturTek(Imaj, 200, 0, 0);
        }

        private Image ResimKes(Image BuyukResim, int soldan, int yukardan, int genislik, int boy, bool arkabeyaz)
        {
            Bitmap bmp = (Bitmap)BuyukResim;

            Bitmap b = new Bitmap(genislik, boy);
            Graphics g = Graphics.FromImage(b);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            g.DrawImage(bmp, 0, 0, 400, 400);
            g.Dispose();

            return b;
            return ((Bitmap)BuyukResim).Clone(new Rectangle(soldan, yukardan, genislik, boy), System.Drawing.Imaging.PixelFormat.DontCare);
        }

        private int Olcut => Convert.ToInt32(textBox1.Text.Trim());

        private int HangiRadio => radioButton1.Checked ? 0 : radioButton2.Checked ? 1 : radioButton3.Checked ? 2 : radioButton4.Checked ? 3 : radioButton5.Checked ? 4 : radioButton6.Checked ? 5 : radioButton7.Checked ? 6 : radioButton8.Checked ? 7 : radioButton9.Checked ? 8 : radioButton10.Checked ? 9 : radioButton11.Checked ? 10 : radioButton12.Checked ? 11 : -1;

        private int SonRadio => radioButton12.Enabled ? 11 : radioButton11.Enabled ? 10 : radioButton10.Enabled ? 9 : radioButton9.Enabled ? 8 : radioButton8.Enabled ? 7 : radioButton7.Enabled ? 6 : radioButton6.Enabled ? 5 : radioButton5.Enabled ? 4 : radioButton4.Enabled ? 3 : radioButton3.Enabled ? 2 : radioButton2.Enabled ? 1 : radioButton1.Enabled ? 0 : -1;

        #region radio
        private void RadioEnable(int radio)
        {
            if (radio == 0)
                radioButton1.Enabled = true;
            else if (radio == 1)
                radioButton2.Enabled = true;
            else if (radio == 2)
                radioButton3.Enabled = true;
            else if (radio == 3)
                radioButton4.Enabled = true;
            else if (radio == 4)
                radioButton5.Enabled = true;
            else if (radio == 5)
                radioButton6.Enabled = true;
            else if (radio == 6)
                radioButton7.Enabled = true;
            else if (radio == 7)
                radioButton8.Enabled = true;
            else if (radio == 8)
                radioButton9.Enabled = true;
            else if (radio == 9)
                radioButton10.Enabled = true;
            else if (radio == 10)
                radioButton11.Enabled = true;
            else if (radio == 11)
                radioButton12.Enabled = true;
        }

        private void RadioDisable(int radio)
        {
            if (radio == 0)
                radioButton1.Enabled = false;
            else if (radio == 1)
                radioButton2.Enabled = false;
            else if (radio == 2)
                radioButton3.Enabled = false;
            else if (radio == 3)
                radioButton4.Enabled = false;
            else if (radio == 4)
                radioButton5.Enabled = false;
            else if (radio == 5)
                radioButton6.Enabled = false;
            else if (radio == 6)
                radioButton7.Enabled = false;
            else if (radio == 7)
                radioButton8.Enabled = false;
            else if (radio == 8)
                radioButton9.Enabled = false;
            else if (radio == 9)
                radioButton10.Enabled = false;
            else if (radio == 10)
                radioButton11.Enabled = false;
            else if (radio == 11)
                radioButton12.Enabled = false;
        }

        private bool RadioIsEnable(int radio)
        {
            if (radio == 0)
                return radioButton1.Enabled;
            else if (radio == 1)
                return radioButton2.Enabled;
            else if (radio == 2)
                return radioButton3.Enabled;
            else if (radio == 3)
                return radioButton4.Enabled;
            else if (radio == 4)
                return radioButton5.Enabled;
            else if (radio == 5)
                return radioButton6.Enabled;
            else if (radio == 6)
                return radioButton7.Enabled;
            else if (radio == 7)
                return radioButton8.Enabled;
            else if (radio == 8)
                return radioButton9.Enabled;
            else if (radio == 9)
                return radioButton10.Enabled;
            else if (radio == 10)
                return radioButton11.Enabled;
            else if (radio == 11)
                return radioButton12.Enabled;
            else
                return false;
        }

        private void RadioCheck(int radio)
        {
            if (radio == 0)
                radioButton1.Checked = true;
            else if (radio == 1)
                radioButton2.Checked = true;
            else if (radio == 2)
                radioButton3.Checked = true;
            else if (radio == 3)
                radioButton4.Checked = true;
            else if (radio == 4)
                radioButton5.Checked = true;
            else if (radio == 5)
                radioButton6.Checked = true;
            else if (radio == 6)
                radioButton7.Checked = true;
            else if (radio == 7)
                radioButton8.Checked = true;
            else if (radio == 8)
                radioButton9.Checked = true;
            else if (radio == 9)
                radioButton10.Checked = true;
            else if (radio == 10)
                radioButton11.Checked = true;
            else if (radio == 11)
                radioButton12.Checked = true;
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                for (int i = 0; i < 12; i++)
                    if (RadioIsEnable(i))
                        yukardanuzaklik[i] = yukardanuzaklik[i] - Olcut;
            }
            else
            {
                yukardanuzaklik[HangiRadio] = yukardanuzaklik[HangiRadio] - Olcut;
            }

            ResimiKoy();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                for (int i = 0; i < 12; i++)
                    if (RadioIsEnable(i))
                        yukardanuzaklik[i] = yukardanuzaklik[i] + Olcut;
            }
            else
            {
                yukardanuzaklik[HangiRadio] = yukardanuzaklik[HangiRadio] + Olcut;
            }

            ResimiKoy();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                for (int i = 0; i < 12; i++)
                    if (RadioIsEnable(i))
                        soldanuzaklik[i] = soldanuzaklik[i] - Olcut;
            }
            else
            {
                soldanuzaklik[HangiRadio] = soldanuzaklik[HangiRadio] - Olcut;
            }

            ResimiKoy();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                for (int i = 0; i < 12; i++)
                    if (RadioIsEnable(i))
                        soldanuzaklik[i] = soldanuzaklik[i] + Olcut;
            }
            else
            {
                soldanuzaklik[HangiRadio] = soldanuzaklik[HangiRadio] + Olcut;
            }

            ResimiKoy();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                for (int i = 0; i < 12; i++)
                {
                    if (RadioIsEnable(i))
                    {
                        yukardanuzaklik[i] = yukardanuzaklik[i] - Olcut;
                        soldanuzaklik[i] = soldanuzaklik[i] - Olcut;
                    }
                }
            }
            else
            {
                yukardanuzaklik[HangiRadio] = yukardanuzaklik[HangiRadio] - Olcut;
                soldanuzaklik[HangiRadio] = soldanuzaklik[HangiRadio] - Olcut;
            }

            ResimiKoy();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                for (int i = 0; i < 12; i++)
                {
                    if (RadioIsEnable(i))
                    {
                        yukardanuzaklik[i] = yukardanuzaklik[i] - Olcut;
                        soldanuzaklik[i] = soldanuzaklik[i] + Olcut;
                    }
                }
            }
            else
            {
                yukardanuzaklik[HangiRadio] = yukardanuzaklik[HangiRadio] - Olcut;
                soldanuzaklik[HangiRadio] = soldanuzaklik[HangiRadio] + Olcut;
            }

            ResimiKoy();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                for (int i = 0; i < 12; i++)
                {
                    if (RadioIsEnable(i))
                    {
                        soldanuzaklik[i] = soldanuzaklik[i] - Olcut;
                        yukardanuzaklik[i] = yukardanuzaklik[i] + Olcut;
                    }
                }
            }
            else
            {
                soldanuzaklik[HangiRadio] = soldanuzaklik[HangiRadio] - Olcut;
                yukardanuzaklik[HangiRadio] = yukardanuzaklik[HangiRadio] + Olcut;
            }

            ResimiKoy();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                for (int i = 0; i < 12; i++)
                {
                    if (RadioIsEnable(i))
                    {
                        soldanuzaklik[i] = soldanuzaklik[i] + Olcut;
                        yukardanuzaklik[i] = yukardanuzaklik[i] + Olcut;
                    }
                }
            }
            else
            {
                soldanuzaklik[HangiRadio] = soldanuzaklik[HangiRadio] + Olcut;
                yukardanuzaklik[HangiRadio] = yukardanuzaklik[HangiRadio] + Olcut;
            }

            ResimiKoy();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                for (int i = 0; i < 12; i++)
                    if (RadioIsEnable(i))
                        if (buyukluk[HangiRadio] > Olcut)
                            buyukluk[i] = buyukluk[i] - Olcut;
            }
            else
            {
                if (buyukluk[HangiRadio] > Olcut)
                    buyukluk[HangiRadio] = buyukluk[HangiRadio] - Olcut;
            }

            ResimiKoy();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                for (int i = 0; i < 12; i++)
                    if (RadioIsEnable(i))
                        if (buyukluk[HangiRadio] > Olcut)
                            buyukluk[i] = buyukluk[i] + Olcut;
            }
            else
            {
                if (buyukluk[HangiRadio] < olcek)
                    buyukluk[HangiRadio] = buyukluk[HangiRadio] + Olcut;
            }

            ResimiKoy();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Convert.ToInt32(textBox2.Text.Trim()) && SonRadio < 11; i++)
            {
                Img[SonRadio + 1] = ResimKopyala(Img[HangiRadio]);
                buyukluk[SonRadio + 1] = buyukluk[HangiRadio];
                soldanuzaklik[SonRadio + 1] = soldanuzaklik[HangiRadio];
                yukardanuzaklik[SonRadio + 1] = yukardanuzaklik[HangiRadio];

                RadioEnable(SonRadio + 1);
                RadioCheck(SonRadio);
                ResimiKoy();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (SonRadio < 11)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Desteklenen Resim Dosyaları|*.jpeg;*.jpg;*.bmp;*.png;*.gif;*.tif;*.tiff|JPG Dosyaları|*.jpeg;*.jpg|BMP Dosyaları|*.bmp|PNG Dosyaları|*.png|GIF Dosyaları|*.gif|TIFF Dosyaları|*.tif;*.tiff|Bütün Dosyalar|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Img[SonRadio + 1] = ResimOlusturTek(Resim.ByteToImage(File.ReadAllBytes(ofd.FileName)), olcek, 0, 0);
                    RadioEnable(SonRadio + 1);
                    RadioCheck(SonRadio);
                    ResimiKoy();
                }
            }
        }

        bool p2down;
        int ofirstlocx;
        int ofirstlocy;
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            p2down = true;
            textBox1.Focus();
            if (e.Button == MouseButtons.Left)
            {
                ofirstlocx = e.X;
                ofirstlocy = e.Y;
            }
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            if (p2down)
            {
                p2down = false;
                if (e.Button == MouseButtons.Left)
                {
                    int osecondlocx = e.X;
                    int osecondlocy = e.Y;

                    if (checkBox1.Checked)
                    {
                        for (int i = 0; i < 12; i++)
                        {
                            if (RadioIsEnable(i))
                            {
                                soldanuzaklik[i] = soldanuzaklik[i] + (osecondlocx - ofirstlocx) * 5;
                                yukardanuzaklik[i] = yukardanuzaklik[i] + (osecondlocy - ofirstlocy) * 5;
                            }
                        }
                    }
                    else
                    {
                        soldanuzaklik[HangiRadio] = soldanuzaklik[HangiRadio] + (osecondlocx - ofirstlocx) * 5;
                        yukardanuzaklik[HangiRadio] = yukardanuzaklik[HangiRadio] + (osecondlocy - ofirstlocy) * 5;
                    }

                    ResimiKoy();
                }
            }
        }

        bool p1down;
        int firstlocx;
        int firstlocy;
        int kesmex;
        int kesmey;
        int kesmeen;
        int kesmeboy;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            p1down = true;
            textBox1.Focus();
            if (e.Button == MouseButtons.Left)
            {
                firstlocx = e.X;
                firstlocy = e.Y;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (p1down)
            {
                int secondlocx = e.X;
                int secondlocy = e.Y;
                Graphics myGraph = pictureBox1.CreateGraphics();

                if (checkBox2.Checked) // çizim
                {
                    myGraph.DrawLine(Pens.Black, firstlocx, firstlocy, secondlocx, secondlocy);
                    firstlocx = e.X;
                    firstlocy = e.Y;
                }
                else if (checkBox3.Checked) // kesme
                {
                    pictureBox1.Invalidate();

                    int x1 = firstlocx;
                    int boyutx = secondlocx - firstlocx;
                    int y1 = firstlocy;
                    int boyuty = secondlocy - firstlocy;
                    if (firstlocx > secondlocx)
                    {
                        boyutx = firstlocx - secondlocx;
                        x1 = secondlocx;
                    }
                    if (firstlocy > secondlocy)
                    {
                        boyuty = firstlocy - secondlocy;
                        y1 = secondlocy;
                    }
                    
                    myGraph.DrawRectangle(Pens.Black, x1, y1, boyutx, boyuty);

                    kesmex = soldanuzaklik[HangiRadio] > x1 ? 0 : x1 - soldanuzaklik[HangiRadio];
                    kesmey = yukardanuzaklik[HangiRadio] > y1 ? 0 : y1 - yukardanuzaklik[HangiRadio];
                    kesmeen = soldanuzaklik[HangiRadio] > x1 ? secondlocx - soldanuzaklik[HangiRadio] : boyutx;
                    kesmeboy = yukardanuzaklik[HangiRadio] > y1 ? secondlocy - yukardanuzaklik[HangiRadio] : boyuty;

                    double ar = Convert.ToDouble(Img[HangiRadio].Width) / Convert.ToDouble(Img[HangiRadio].Height);
                    kesmeen = kesmeen > buyukluk[HangiRadio] ? buyukluk[HangiRadio] : kesmeen;
                    kesmeboy = kesmeboy > yukseklik(HangiRadio) ? yukseklik(HangiRadio) : kesmeboy;
                }
                else // sürükleme
                {
                    double ar = Convert.ToDouble(Img[HangiRadio].Width) / Convert.ToDouble(Img[HangiRadio].Height);
                    
                    pictureBox1.Invalidate();
                    //myGraph.FillRectangle(Brushes.Transparent, 0, 0, olcek, olcek);
                    //myGraph.DrawImage(ResimKucult(Img[HangiRadio], buyukluk[HangiRadio], false), soldanuzaklik[HangiRadio] + secondlocx - firstlocx, yukardanuzaklik[HangiRadio] + secondlocy - firstlocy);
                    
                    myGraph.DrawRectangle(Pens.DarkGray, soldanuzaklik[HangiRadio] + secondlocx - firstlocx, yukardanuzaklik[HangiRadio] + secondlocy - firstlocy, buyukluk[HangiRadio], yukseklik(HangiRadio));
                    
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (p1down)
            {
                p1down = false;
                if (e.Button == MouseButtons.Left)
                {
                    if (checkBox2.Checked) // çizim
                    {

                    }
                    else if (checkBox3.Checked) // kesme
                    {
                        if (firstlocx > e.X || firstlocy > e.Y)
                        {
                            MessageBox.Show("Tersten kesme henüz hazır değil.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        MessageBox.Show(kesmex + " " + kesmey + " " + kesmeen + " " + kesmeboy);
                        //pictureBox1.Image = ResimKes(Img[HangiRadio], kesmex, kesmey, kesmeen, kesmeboy, false);
                    }
                    else // sürükleme
                    {
                        int secondlocx = e.X;
                        int secondlocy = e.Y;

                        if (checkBox1.Checked)
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                if (RadioIsEnable(i))
                                {
                                    soldanuzaklik[i] = soldanuzaklik[i] + (secondlocx - firstlocx);
                                    yukardanuzaklik[i] = yukardanuzaklik[i] + (secondlocy - firstlocy);
                                }
                            }
                        }
                        else
                        {
                            soldanuzaklik[HangiRadio] = soldanuzaklik[HangiRadio] + (secondlocx - firstlocx);
                            yukardanuzaklik[HangiRadio] = yukardanuzaklik[HangiRadio] + (secondlocy - firstlocy);
                        }

                        ResimiKoy();
                    }
                }
            }
        }

        private void frmINTERNETresim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                button3.PerformClick();
            else if (e.KeyCode == Keys.Down)
                button4.PerformClick();
            else if (e.KeyCode == Keys.Left)
                button5.PerformClick();
            else if (e.KeyCode == Keys.Right)
                button6.PerformClick();
            else if (e.KeyCode == Keys.F2)
                button7.PerformClick();
            else if (e.KeyCode == Keys.F3)
                button8.PerformClick();

            else if (e.KeyCode == Keys.H)
                checkBox1.Checked = !checkBox1.Checked;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            kaydet = true;
            this.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Img[HangiRadio] = ResimOlusturBos();
            soldanuzaklik[HangiRadio] = 0;
            yukardanuzaklik[HangiRadio] = 0;
            buyukluk[HangiRadio] = 1000;

            RadioDisable(HangiRadio);
            RadioCheck(0);

            ResimiKoy();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Birinci resim hariç hepsi silinecek, devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Sil();
                ResimiKoy();
            }
        }

        private void Sil()
        {
            for (int i = 1; i < 12; i++)
            {
                Img[i] = ResimOlusturBos();
                soldanuzaklik[i] = 0;
                yukardanuzaklik[i] = 0;
                buyukluk[i] = 1000;

                RadioDisable(i);
            }

            RadioCheck(0);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox2.Text.Trim()) != 1 && Convert.ToInt32(textBox2.Text.Trim()) != 3 && Convert.ToInt32(textBox2.Text.Trim()) != 5 && Convert.ToInt32(textBox2.Text.Trim()) != 7 && Convert.ToInt32(textBox2.Text.Trim()) != 9 && Convert.ToInt32(textBox2.Text.Trim()) != 11)
            {
                MessageBox.Show("Tek sayılı ölçekli kopyalama yapılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Birinci resim hariç hepsi silinecek ve birinci resim kopyalanacak, devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                Sil();
            else
                return;

            if (Convert.ToInt32(textBox2.Text.Trim()) == 1)
                Ikili();
            else if (Convert.ToInt32(textBox2.Text.Trim()) == 3)
                Dortlu();
            else if (Convert.ToInt32(textBox2.Text.Trim()) == 5)
                Altili();
            else if (Convert.ToInt32(textBox2.Text.Trim()) == 7)
                Sekizli();
            else if (Convert.ToInt32(textBox2.Text.Trim()) == 9)
                Onlu();
            else if (Convert.ToInt32(textBox2.Text.Trim()) == 11)
            {
                if (MessageBox.Show("Üçlü sıra olsun mu?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    Onikili2();
                else
                    Onikili();
            }

            ResimiKoy();
        }

        #region ikili
        private void Ikili()
        {
            double ar = Convert.ToDouble(Img[0].Width) / Convert.ToDouble(Img[0].Height);
            int yukseklik = 0;

            if (ar >= 1)
            {
                buyukluk[0] = olcek / 2;
                yukseklik = (buyukluk[0] * Img[0].Height / Img[0].Width);
                soldanuzaklik[0] = 0;
                yukardanuzaklik[0] = (olcek - yukseklik) / 2;
            }
            else
            {
                yukardanuzaklik[0] = 0;
                yukseklik = olcek / 2;
                buyukluk[0] = Convert.ToInt32(Convert.ToDouble(yukseklik) * ar);
                soldanuzaklik[0] = (olcek - buyukluk[0] * 2) / 2;
            }

            Img[1] = ResimKopyala(Img[0]);
            buyukluk[1] = buyukluk[0];
            soldanuzaklik[1] = buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[1] = yukardanuzaklik[0];

            RadioEnable(1);
        }
        #endregion

        #region dörtlü
        private void Dortlu()
        {
            double ar = Convert.ToDouble(Img[0].Width) / Convert.ToDouble(Img[0].Height);
            int yukseklik = 0;

            if (ar >= 1)
            {
                buyukluk[0] = olcek / 2;
                yukseklik = Convert.ToInt32(Convert.ToDouble(buyukluk[0]) / ar);
                soldanuzaklik[0] = 0;
                yukardanuzaklik[0] = (olcek - yukseklik * 2) / 2;
            }
            else
            {
                yukardanuzaklik[0] = 0;
                yukseklik = olcek / 2;
                buyukluk[0] = Convert.ToInt32(Convert.ToDouble(yukseklik) * ar);
                soldanuzaklik[0] = (olcek - buyukluk[0] * 2) / 2;
            }

            Img[1] = ResimKopyala(Img[0]);
            buyukluk[1] = buyukluk[0];
            soldanuzaklik[1] = buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[1] = yukardanuzaklik[0];

            Img[2] = ResimKopyala(Img[0]);
            buyukluk[2] = buyukluk[0];
            soldanuzaklik[2] = soldanuzaklik[0];
            yukardanuzaklik[2] = yukardanuzaklik[0] + yukseklik;

            Img[3] = ResimKopyala(Img[0]);
            buyukluk[3] = buyukluk[0];
            soldanuzaklik[3] = buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[3] = yukardanuzaklik[0] + yukseklik;

            RadioEnable(1); RadioEnable(2); RadioEnable(3);
        }
        #endregion

        #region altılı
        private void Altili()
        {
            double ar = Convert.ToDouble(Img[0].Width) / Convert.ToDouble(Img[0].Height);
            int yukseklik = 0;

            if (ar >= 0.67)
            {
                buyukluk[0] = olcek / 3;
                yukseklik = Convert.ToInt32(Convert.ToDouble(buyukluk[0]) / ar);
                soldanuzaklik[0] = 0;
                yukardanuzaklik[0] = (olcek - yukseklik * 2) / 2;
            }
            else
            {
                yukardanuzaklik[0] = 0;
                yukseklik = olcek / 2;
                buyukluk[0] = Convert.ToInt32(Convert.ToDouble(yukseklik) * ar);
                soldanuzaklik[0] = (olcek - buyukluk[0] * 3) / 2;
            }

            Img[1] = ResimKopyala(Img[0]);
            buyukluk[1] = buyukluk[0];
            soldanuzaklik[1] = buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[1] = yukardanuzaklik[0];

            Img[2] = ResimKopyala(Img[0]);
            buyukluk[2] = buyukluk[0];
            soldanuzaklik[2] = buyukluk[0] + buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[2] = yukardanuzaklik[0];

            Img[3] = ResimKopyala(Img[0]);
            buyukluk[3] = buyukluk[0];
            soldanuzaklik[3] = soldanuzaklik[0];
            yukardanuzaklik[3] = yukardanuzaklik[0] + yukseklik;

            Img[4] = ResimKopyala(Img[0]);
            buyukluk[4] = buyukluk[0];
            soldanuzaklik[4] = buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[4] = yukardanuzaklik[0] + yukseklik;

            Img[5] = ResimKopyala(Img[0]);
            buyukluk[5] = buyukluk[0];
            soldanuzaklik[5] = buyukluk[0] + buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[5] = yukardanuzaklik[0] + yukseklik;

            RadioEnable(1); RadioEnable(2); RadioEnable(3); RadioEnable(4); RadioEnable(5);
        }
        #endregion

        #region sekizli
        private void Sekizli()
        {
            double ar = Convert.ToDouble(Img[0].Width) / Convert.ToDouble(Img[0].Height);
            int yukseklik = 0;

            if (ar >= 0.5)
            {
                buyukluk[0] = olcek / 4;
                yukseklik = Convert.ToInt32(Convert.ToDouble(buyukluk[0]) / ar);
                soldanuzaklik[0] = 0;
                yukardanuzaklik[0] = (olcek - yukseklik * 2) / 2;
            }
            else
            {
                yukardanuzaklik[0] = 0;
                yukseklik = olcek / 2;
                buyukluk[0] = Convert.ToInt32(Convert.ToDouble(yukseklik) * ar);
                soldanuzaklik[0] = (olcek - buyukluk[0] * 4) / 2;
            }

            Img[1] = ResimKopyala(Img[0]);
            buyukluk[1] = buyukluk[0];
            soldanuzaklik[1] = buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[1] = yukardanuzaklik[0];

            Img[2] = ResimKopyala(Img[0]);
            buyukluk[2] = buyukluk[0];
            soldanuzaklik[2] = buyukluk[0] + buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[2] = yukardanuzaklik[0];

            Img[3] = ResimKopyala(Img[0]);
            buyukluk[3] = buyukluk[0];
            soldanuzaklik[3] = buyukluk[0] + buyukluk[0] + buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[3] = yukardanuzaklik[0];

            Img[4] = ResimKopyala(Img[0]);
            buyukluk[4] = buyukluk[0];
            soldanuzaklik[4] = soldanuzaklik[0];
            yukardanuzaklik[4] = yukardanuzaklik[0] + yukseklik;

            Img[5] = ResimKopyala(Img[0]);
            buyukluk[5] = buyukluk[0];
            soldanuzaklik[5] = buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[5] = yukardanuzaklik[0] + yukseklik;

            Img[6] = ResimKopyala(Img[0]);
            buyukluk[6] = buyukluk[0];
            soldanuzaklik[6] = buyukluk[0] + buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[6] = yukardanuzaklik[0] + yukseklik;

            Img[7] = ResimKopyala(Img[0]);
            buyukluk[7] = buyukluk[0];
            soldanuzaklik[7] = buyukluk[0] + buyukluk[0] + buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[7] = yukardanuzaklik[0] + yukseklik;

            RadioEnable(1); RadioEnable(2); RadioEnable(3); RadioEnable(4); RadioEnable(5); RadioEnable(6); RadioEnable(7);
        }
        #endregion

        #region onlu
        private void Onlu()
        {
            double ar = Convert.ToDouble(Img[0].Width) / Convert.ToDouble(Img[0].Height);
            int yukseklik = 0;

            if (ar >= 0.4)
            {
                buyukluk[0] = olcek / 5;
                yukseklik = Convert.ToInt32(Convert.ToDouble(buyukluk[0]) / ar);
                soldanuzaklik[0] = 0;
                yukardanuzaklik[0] = (olcek - yukseklik * 2) / 2;
            }
            else
            {
                yukardanuzaklik[0] = 0;
                yukseklik = olcek / 2;
                buyukluk[0] = Convert.ToInt32(Convert.ToDouble(yukseklik) * ar);
                soldanuzaklik[0] = (olcek - buyukluk[0] * 5) / 2;
            }

            Img[1] = ResimKopyala(Img[0]);
            buyukluk[1] = buyukluk[0];
            soldanuzaklik[1] = buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[1] = yukardanuzaklik[0];

            Img[2] = ResimKopyala(Img[0]);
            buyukluk[2] = buyukluk[0];
            soldanuzaklik[2] = buyukluk[0] + buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[2] = yukardanuzaklik[0];

            Img[3] = ResimKopyala(Img[0]);
            buyukluk[3] = buyukluk[0];
            soldanuzaklik[3] = buyukluk[0] + buyukluk[0] + buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[3] = yukardanuzaklik[0];

            Img[4] = ResimKopyala(Img[0]);
            buyukluk[4] = buyukluk[0];
            soldanuzaklik[4] = buyukluk[0] + buyukluk[0] + buyukluk[0] + buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[4] = yukardanuzaklik[0];

            Img[5] = ResimKopyala(Img[0]);
            buyukluk[5] = buyukluk[0];
            soldanuzaklik[5] = soldanuzaklik[0];
            yukardanuzaklik[5] = yukardanuzaklik[0] + yukseklik;

            Img[6] = ResimKopyala(Img[0]);
            buyukluk[6] = buyukluk[0];
            soldanuzaklik[6] = buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[6] = yukardanuzaklik[0] + yukseklik;

            Img[7] = ResimKopyala(Img[0]);
            buyukluk[7] = buyukluk[0];
            soldanuzaklik[7] = buyukluk[0] + buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[7] = yukardanuzaklik[0] + yukseklik;

            Img[8] = ResimKopyala(Img[0]);
            buyukluk[8] = buyukluk[0];
            soldanuzaklik[8] = buyukluk[0] + buyukluk[0] + buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[8] = yukardanuzaklik[0] + yukseklik;

            Img[9] = ResimKopyala(Img[0]);
            buyukluk[9] = buyukluk[0];
            soldanuzaklik[9] = buyukluk[0] + buyukluk[0] + buyukluk[0] + buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[9] = yukardanuzaklik[0] + yukseklik;

            RadioEnable(1); RadioEnable(2); RadioEnable(3); RadioEnable(4); RadioEnable(5); RadioEnable(6); RadioEnable(7); RadioEnable(8); RadioEnable(9);
        }
        #endregion

        #region onikili
        private void Onikili()
        {
            double ar = Convert.ToDouble(Img[0].Width) / Convert.ToDouble(Img[0].Height);
            int yukseklik = 0;

            if (ar >= 0.34)
            {
                buyukluk[0] = olcek / 6;
                yukseklik = Convert.ToInt32(Convert.ToDouble(buyukluk[0]) / ar);
                soldanuzaklik[0] = 0;
                yukardanuzaklik[0] = (olcek - yukseklik * 2) / 2;
            }
            else
            {
                yukardanuzaklik[0] = 0;
                yukseklik = olcek / 2;
                buyukluk[0] = Convert.ToInt32(Convert.ToDouble(yukseklik) * ar);
                soldanuzaklik[0] = (olcek - buyukluk[0] * 6) / 2;
            }

            Img[1] = ResimKopyala(Img[0]);
            buyukluk[1] = buyukluk[0];
            soldanuzaklik[1] = buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[1] = yukardanuzaklik[0];

            Img[2] = ResimKopyala(Img[0]);
            buyukluk[2] = buyukluk[0];
            soldanuzaklik[2] = buyukluk[0] + buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[2] = yukardanuzaklik[0];

            Img[3] = ResimKopyala(Img[0]);
            buyukluk[3] = buyukluk[0];
            soldanuzaklik[3] = buyukluk[0] + buyukluk[0] + buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[3] = yukardanuzaklik[0];

            Img[4] = ResimKopyala(Img[0]);
            buyukluk[4] = buyukluk[0];
            soldanuzaklik[4] = buyukluk[0] + buyukluk[0] + buyukluk[0] + buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[4] = yukardanuzaklik[0];

            Img[5] = ResimKopyala(Img[0]);
            buyukluk[5] = buyukluk[0];
            soldanuzaklik[5] = buyukluk[0] + buyukluk[0] + buyukluk[0] + buyukluk[0] + buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[5] = yukardanuzaklik[0];

            Img[6] = ResimKopyala(Img[0]);
            buyukluk[6] = buyukluk[0];
            soldanuzaklik[6] = soldanuzaklik[0];
            yukardanuzaklik[6] = yukardanuzaklik[0] + yukseklik;

            Img[7] = ResimKopyala(Img[0]);
            buyukluk[7] = buyukluk[0];
            soldanuzaklik[7] = buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[7] = yukardanuzaklik[0] + yukseklik;

            Img[8] = ResimKopyala(Img[0]);
            buyukluk[8] = buyukluk[0];
            soldanuzaklik[8] = buyukluk[0] + buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[8] = yukardanuzaklik[0] + yukseklik;

            Img[9] = ResimKopyala(Img[0]);
            buyukluk[9] = buyukluk[0];
            soldanuzaklik[9] = buyukluk[0] + buyukluk[0] + buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[9] = yukardanuzaklik[0] + yukseklik;

            Img[10] = ResimKopyala(Img[0]);
            buyukluk[10] = buyukluk[0];
            soldanuzaklik[10] = buyukluk[0] + buyukluk[0] + buyukluk[0] + buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[10] = yukardanuzaklik[0] + yukseklik;

            Img[11] = ResimKopyala(Img[0]);
            buyukluk[11] = buyukluk[0];
            soldanuzaklik[11] = buyukluk[0] + buyukluk[0] + buyukluk[0] + buyukluk[0] + buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[11] = yukardanuzaklik[0] + yukseklik;

            RadioEnable(1); RadioEnable(2); RadioEnable(3); RadioEnable(4); RadioEnable(5); RadioEnable(6); RadioEnable(7); RadioEnable(8); RadioEnable(9); RadioEnable(10); RadioEnable(11);
        }

        private void Onikili2()
        {
            double ar = Convert.ToDouble(Img[0].Width) / Convert.ToDouble(Img[0].Height);
            int yukseklik = 0;

            if (ar >= 0.67)
            {
                buyukluk[0] = olcek / 4;
                yukseklik = Convert.ToInt32(Convert.ToDouble(buyukluk[0]) / ar);
                soldanuzaklik[0] = 0;
                yukardanuzaklik[0] = (olcek - yukseklik * 3) / 2;
            }
            else
            {
                yukardanuzaklik[0] = 0;
                yukseklik = olcek / 3;
                buyukluk[0] = Convert.ToInt32(Convert.ToDouble(yukseklik) * ar);
                soldanuzaklik[0] = (olcek - buyukluk[0] * 4) / 2;
            }

            Img[1] = ResimKopyala(Img[0]);
            buyukluk[1] = buyukluk[0];
            soldanuzaklik[1] = buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[1] = yukardanuzaklik[0];

            Img[2] = ResimKopyala(Img[0]);
            buyukluk[2] = buyukluk[0];
            soldanuzaklik[2] = buyukluk[0] + buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[2] = yukardanuzaklik[0];

            Img[3] = ResimKopyala(Img[0]);
            buyukluk[3] = buyukluk[0];
            soldanuzaklik[3] = buyukluk[0] + buyukluk[0] + buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[3] = yukardanuzaklik[0];

            Img[4] = ResimKopyala(Img[0]);
            buyukluk[4] = buyukluk[0];
            soldanuzaklik[4] = soldanuzaklik[0];
            yukardanuzaklik[4] = yukardanuzaklik[0] + yukseklik;

            Img[5] = ResimKopyala(Img[0]);
            buyukluk[5] = buyukluk[0];
            soldanuzaklik[5] = buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[5] = yukardanuzaklik[0] + yukseklik;

            Img[6] = ResimKopyala(Img[0]);
            buyukluk[6] = buyukluk[0];
            soldanuzaklik[6] = buyukluk[0] + buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[6] = yukardanuzaklik[0] + yukseklik;

            Img[7] = ResimKopyala(Img[0]);
            buyukluk[7] = buyukluk[0];
            soldanuzaklik[7] = buyukluk[0] + buyukluk[0] + buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[7] = yukardanuzaklik[0] + yukseklik;

            Img[8] = ResimKopyala(Img[0]);
            buyukluk[8] = buyukluk[0];
            soldanuzaklik[8] = soldanuzaklik[0];
            yukardanuzaklik[8] = yukardanuzaklik[0] + yukseklik + yukseklik;

            Img[9] = ResimKopyala(Img[0]);
            buyukluk[9] = buyukluk[0];
            soldanuzaklik[9] = buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[9] = yukardanuzaklik[0] + yukseklik + yukseklik;

            Img[10] = ResimKopyala(Img[0]);
            buyukluk[10] = buyukluk[0];
            soldanuzaklik[10] = buyukluk[0] + buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[10] = yukardanuzaklik[0] + yukseklik + yukseklik;

            Img[11] = ResimKopyala(Img[0]);
            buyukluk[11] = buyukluk[0];
            soldanuzaklik[11] = buyukluk[0] + buyukluk[0] + buyukluk[0] + soldanuzaklik[0];
            yukardanuzaklik[11] = yukardanuzaklik[0] + yukseklik + yukseklik;

            RadioEnable(1); RadioEnable(2); RadioEnable(3); RadioEnable(4); RadioEnable(5); RadioEnable(6); RadioEnable(7); RadioEnable(8); RadioEnable(9); RadioEnable(10); RadioEnable(11);
        }
        #endregion

        private void button18_Click(object sender, EventArgs e)
        {
            int[] yukardanuzaklikG = new int[24] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] soldanuzaklikG = new int[24] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] buyuklukG = new int[24] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            Image[] ImgG = new Image[24];

            ImgG[0] = ResimKopyala(Img[0]);
            double ar = Convert.ToDouble(ImgG[0].Width) / Convert.ToDouble(ImgG[0].Height);
            int yukseklik = 0;

            if (ar >= 0.67)
            {
                buyuklukG[0] = olcek / 6;
                yukseklik = Convert.ToInt32(Convert.ToDouble(buyuklukG[0]) / ar);
                soldanuzaklikG[0] = 0;
                yukardanuzaklikG[0] = (olcek - yukseklik * 4) / 2;
            }
            else
            {
                yukardanuzaklikG[0] = 0;
                yukseklik = olcek / 4;
                buyuklukG[0] = Convert.ToInt32(Convert.ToDouble(yukseklik) * ar);
                soldanuzaklikG[0] = (olcek - buyuklukG[0] * 6) / 2;
            }

            ImgG[1] = ResimKopyala(ImgG[0]);
            buyuklukG[1] = buyuklukG[0];
            soldanuzaklikG[1] = buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[1] = yukardanuzaklikG[0];

            ImgG[2] = ResimKopyala(ImgG[0]);
            buyuklukG[2] = buyuklukG[0];
            soldanuzaklikG[2] = buyuklukG[0] + buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[2] = yukardanuzaklikG[0];

            ImgG[3] = ResimKopyala(ImgG[0]);
            buyuklukG[3] = buyuklukG[0];
            soldanuzaklikG[3] = buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[3] = yukardanuzaklikG[0];

            ImgG[4] = ResimKopyala(ImgG[0]);
            buyuklukG[4] = buyuklukG[0];
            soldanuzaklikG[4] = buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[4] = yukardanuzaklikG[0];

            ImgG[5] = ResimKopyala(ImgG[0]);
            buyuklukG[5] = buyuklukG[0];
            soldanuzaklikG[5] = buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[5] = yukardanuzaklikG[0];
            
            ImgG[6] = ResimKopyala(ImgG[0]);
            buyuklukG[6] = buyuklukG[0];
            soldanuzaklikG[6] = soldanuzaklikG[0];
            yukardanuzaklikG[6] = yukardanuzaklikG[0] + yukseklik;

            ImgG[7] = ResimKopyala(ImgG[0]);
            buyuklukG[7] = buyuklukG[0];
            soldanuzaklikG[7] = buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[7] = yukardanuzaklikG[0] + yukseklik;

            ImgG[8] = ResimKopyala(ImgG[0]);
            buyuklukG[8] = buyuklukG[0];
            soldanuzaklikG[8] = buyuklukG[0] + buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[8] = yukardanuzaklikG[0] + yukseklik;

            ImgG[9] = ResimKopyala(ImgG[0]);
            buyuklukG[9] = buyuklukG[0];
            soldanuzaklikG[9] = buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[9] = yukardanuzaklikG[0] + yukseklik;

            ImgG[10] = ResimKopyala(ImgG[0]);
            buyuklukG[10] = buyuklukG[0];
            soldanuzaklikG[10] = buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[10] = yukardanuzaklikG[0] + yukseklik;

            ImgG[11] = ResimKopyala(ImgG[0]);
            buyuklukG[11] = buyuklukG[0];
            soldanuzaklikG[11] = buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[11] = yukardanuzaklikG[0] + yukseklik;
            
            ImgG[12] = ResimKopyala(ImgG[0]);
            buyuklukG[12] = buyuklukG[0];
            soldanuzaklikG[12] = soldanuzaklikG[0];
            yukardanuzaklikG[12] = yukardanuzaklikG[0] + yukseklik + yukseklik;

            ImgG[13] = ResimKopyala(ImgG[0]);
            buyuklukG[13] = buyuklukG[0];
            soldanuzaklikG[13] = buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[13] = yukardanuzaklikG[0] + yukseklik + yukseklik;

            ImgG[14] = ResimKopyala(ImgG[0]);
            buyuklukG[14] = buyuklukG[0];
            soldanuzaklikG[14] = buyuklukG[0] + buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[14] = yukardanuzaklikG[0] + yukseklik + yukseklik;

            ImgG[15] = ResimKopyala(ImgG[0]);
            buyuklukG[15] = buyuklukG[0];
            soldanuzaklikG[15] = buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[15] = yukardanuzaklikG[0] + yukseklik + yukseklik;

            ImgG[16] = ResimKopyala(ImgG[0]);
            buyuklukG[16] = buyuklukG[0];
            soldanuzaklikG[16] = buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[16] = yukardanuzaklikG[0] + yukseklik + yukseklik;

            ImgG[17] = ResimKopyala(ImgG[0]);
            buyuklukG[17] = buyuklukG[0];
            soldanuzaklikG[17] = buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[17] = yukardanuzaklikG[0] + yukseklik + yukseklik;
            
            ImgG[18] = ResimKopyala(ImgG[0]);
            buyuklukG[18] = buyuklukG[0];
            soldanuzaklikG[18] = soldanuzaklikG[0];
            yukardanuzaklikG[18] = yukardanuzaklikG[0] + yukseklik + yukseklik + yukseklik;

            ImgG[19] = ResimKopyala(ImgG[0]);
            buyuklukG[19] = buyuklukG[0];
            soldanuzaklikG[19] = buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[19] = yukardanuzaklikG[0] + yukseklik + yukseklik + yukseklik;

            ImgG[20] = ResimKopyala(ImgG[0]);
            buyuklukG[20] = buyuklukG[0];
            soldanuzaklikG[20] = buyuklukG[0] + buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[20] = yukardanuzaklikG[0] + yukseklik + yukseklik + yukseklik;

            ImgG[21] = ResimKopyala(ImgG[0]);
            buyuklukG[21] = buyuklukG[0];
            soldanuzaklikG[21] = buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[21] = yukardanuzaklikG[0] + yukseklik + yukseklik + yukseklik;

            ImgG[22] = ResimKopyala(ImgG[0]);
            buyuklukG[22] = buyuklukG[0];
            soldanuzaklikG[22] = buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[22] = yukardanuzaklikG[0] + yukseklik + yukseklik + yukseklik;

            ImgG[23] = ResimKopyala(ImgG[0]);
            buyuklukG[23] = buyuklukG[0];
            soldanuzaklikG[23] = buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[23] = yukardanuzaklikG[0] + yukseklik + yukseklik + yukseklik;
            


            RadioCheck(0);
            for (int i = 0; i < this.Controls.Count; i++)
                this.Controls[i].Enabled = false;
            panel1.Enabled = true;

            Bitmap bmp = new Bitmap(olcek, olcek);
            Graphics gr = Graphics.FromImage(bmp);
            Image img;

            for (int i = 0; i < ImgG.Length; i++)
            {
                if (ImgG[i] != null)
                {
                    img = ResimKucult(ImgG[i], buyuklukG[i], false);
                    int genislik = img.Width;
                    int yuksekl = img.Height;
                    double aspectRatio = Convert.ToDouble(img.Height) / img.Width;
                    genislik = buyuklukG[i];
                    yuksekl = Convert.ToInt32(aspectRatio * genislik);
                    gr.DrawImage(img, soldanuzaklikG[i], yukardanuzaklikG[i], genislik, yuksekl);
                    img.Dispose();
                    GC.SuppressFinalize(img);
                }
            }
            
            pictureBox1.Image = bmp;
            pictureBox2.Image = ResimOlusturTek(bmp, 200, 0, 0);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            int[] yukardanuzaklikG = new int[18] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] soldanuzaklikG = new int[18] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] buyuklukG = new int[18] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            Image[] ImgG = new Image[18];

            ImgG[0] = ResimKopyala(Img[0]);
            double ar = Convert.ToDouble(ImgG[0].Width) / Convert.ToDouble(ImgG[0].Height);
            int yukseklik = 0;

            if (ar >= 0.34)
            {
                buyuklukG[0] = olcek / 6;
                yukseklik = Convert.ToInt32(Convert.ToDouble(buyuklukG[0]) / ar);
                soldanuzaklikG[0] = 0;
                yukardanuzaklikG[0] = (olcek - yukseklik * 3) / 2;
            }
            else
            {
                yukardanuzaklikG[0] = 0;
                yukseklik = olcek / 3;
                buyuklukG[0] = Convert.ToInt32(Convert.ToDouble(yukseklik) * ar);
                soldanuzaklikG[0] = (olcek - buyuklukG[0] * 6) / 2;
            }

            ImgG[1] = ResimKopyala(ImgG[0]);
            buyuklukG[1] = buyuklukG[0];
            soldanuzaklikG[1] = buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[1] = yukardanuzaklikG[0];

            ImgG[2] = ResimKopyala(ImgG[0]);
            buyuklukG[2] = buyuklukG[0];
            soldanuzaklikG[2] = buyuklukG[0] + buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[2] = yukardanuzaklikG[0];

            ImgG[3] = ResimKopyala(ImgG[0]);
            buyuklukG[3] = buyuklukG[0];
            soldanuzaklikG[3] = buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[3] = yukardanuzaklikG[0];

            ImgG[4] = ResimKopyala(ImgG[0]);
            buyuklukG[4] = buyuklukG[0];
            soldanuzaklikG[4] = buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[4] = yukardanuzaklikG[0];

            ImgG[5] = ResimKopyala(ImgG[0]);
            buyuklukG[5] = buyuklukG[0];
            soldanuzaklikG[5] = buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[5] = yukardanuzaklikG[0];

            ImgG[6] = ResimKopyala(ImgG[0]);
            buyuklukG[6] = buyuklukG[0];
            soldanuzaklikG[6] = soldanuzaklikG[0];
            yukardanuzaklikG[6] = yukardanuzaklikG[0] + yukseklik;

            ImgG[7] = ResimKopyala(ImgG[0]);
            buyuklukG[7] = buyuklukG[0];
            soldanuzaklikG[7] = buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[7] = yukardanuzaklikG[0] + yukseklik;

            ImgG[8] = ResimKopyala(ImgG[0]);
            buyuklukG[8] = buyuklukG[0];
            soldanuzaklikG[8] = buyuklukG[0] + buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[8] = yukardanuzaklikG[0] + yukseklik;

            ImgG[9] = ResimKopyala(ImgG[0]);
            buyuklukG[9] = buyuklukG[0];
            soldanuzaklikG[9] = buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[9] = yukardanuzaklikG[0] + yukseklik;

            ImgG[10] = ResimKopyala(ImgG[0]);
            buyuklukG[10] = buyuklukG[0];
            soldanuzaklikG[10] = buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[10] = yukardanuzaklikG[0] + yukseklik;

            ImgG[11] = ResimKopyala(ImgG[0]);
            buyuklukG[11] = buyuklukG[0];
            soldanuzaklikG[11] = buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[11] = yukardanuzaklikG[0] + yukseklik;

            ImgG[12] = ResimKopyala(ImgG[0]);
            buyuklukG[12] = buyuklukG[0];
            soldanuzaklikG[12] = soldanuzaklikG[0];
            yukardanuzaklikG[12] = yukardanuzaklikG[0] + yukseklik + yukseklik;

            ImgG[13] = ResimKopyala(ImgG[0]);
            buyuklukG[13] = buyuklukG[0];
            soldanuzaklikG[13] = buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[13] = yukardanuzaklikG[0] + yukseklik + yukseklik;

            ImgG[14] = ResimKopyala(ImgG[0]);
            buyuklukG[14] = buyuklukG[0];
            soldanuzaklikG[14] = buyuklukG[0] + buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[14] = yukardanuzaklikG[0] + yukseklik + yukseklik;

            ImgG[15] = ResimKopyala(ImgG[0]);
            buyuklukG[15] = buyuklukG[0];
            soldanuzaklikG[15] = buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[15] = yukardanuzaklikG[0] + yukseklik + yukseklik;

            ImgG[16] = ResimKopyala(ImgG[0]);
            buyuklukG[16] = buyuklukG[0];
            soldanuzaklikG[16] = buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[16] = yukardanuzaklikG[0] + yukseklik + yukseklik;

            ImgG[17] = ResimKopyala(ImgG[0]);
            buyuklukG[17] = buyuklukG[0];
            soldanuzaklikG[17] = buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + buyuklukG[0] + soldanuzaklikG[0];
            yukardanuzaklikG[17] = yukardanuzaklikG[0] + yukseklik + yukseklik;



            RadioCheck(0);
            for (int i = 0; i < this.Controls.Count; i++)
                this.Controls[i].Enabled = false;
            panel1.Enabled = true;

            Bitmap bmp = new Bitmap(olcek, olcek);
            Graphics gr = Graphics.FromImage(bmp);
            Image img;

            for (int i = 0; i < ImgG.Length; i++)
            {
                if (ImgG[i] != null)
                {
                    img = ResimKucult(ImgG[i], buyuklukG[i], false);
                    int genislik = img.Width;
                    int yuksekl = img.Height;
                    double aspectRatio = Convert.ToDouble(img.Height) / img.Width;
                    genislik = buyuklukG[i];
                    yuksekl = Convert.ToInt32(aspectRatio * genislik);
                    gr.DrawImage(img, soldanuzaklikG[i], yukardanuzaklikG[i], genislik, yuksekl);
                    img.Dispose();
                    GC.SuppressFinalize(img);
                }
            }

            pictureBox1.Image = bmp;
            pictureBox2.Image = ResimOlusturTek(bmp, 200, 0, 0);
        }
    }
}
