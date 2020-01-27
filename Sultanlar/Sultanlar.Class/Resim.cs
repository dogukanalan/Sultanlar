using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Sultanlar.Class
{
    public class Resim
    {
        //
        //
        //
        //
        //
        public static byte[] ImageToByte(Image image, string ContentTip)
        {
            MemoryStream ms = new MemoryStream();
            ImageFormat resimformati = ResimFormatiniBelirle(ContentTip);
            image.Save(ms, resimformati);
            return ms.ToArray();
        }
        //
        //
        //
        //
        //
        public static byte[] ImageToByte(Image image, Guid formatguid)
        {
            MemoryStream ms = new MemoryStream();
            ImageFormat resimformati = new ImageFormat(formatguid);
            image.Save(ms, resimformati);
            return ms.ToArray();
        }
        //
        //
        //
        //
        //
        public static byte[] ImageToByte(Image image)
        {
            MemoryStream ms = new MemoryStream();
            Bitmap thumbimg = new Bitmap(image);

            EncoderParameter encp = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)85);
            EncoderParameters encps = new EncoderParameters(1);
            encps.Param[0] = encp;

            thumbimg.Save(ms, ImageCodecInfo.GetImageEncoders()[1], encps);
            return ms.ToArray();
        }
        //private static ImageCodecInfo getEncoderInfo(string mimeType)
        //{
        //    // Get image codecs for all image formats
        //    ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
        //    // Find the correct image codec
        //    for (int i = 0; i < codecs.Length; i++)
        //        if (codecs[i].MimeType == mimeType)
        //            return codecs[i];
        //    return null;
        //}
        //
        //
        //
        //
        //
        public static Image ByteToImage(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            Image image = Image.FromStream(ms);
            return image;
        }
        //
        //
        //
        //
        //
        public static Image ResimKucult(Image BuyukResim, int Genislik)
        {
            double aspectRatio = Convert.ToDouble(BuyukResim.Height) / Convert.ToDouble(BuyukResim.Width);

            //Image kucukResim = BuyukResim.GetThumbnailImage(Genislik, Convert.ToInt32(aspectRatio * Genislik), null, IntPtr.Zero);
            Image kucukResim = ResimKucult(BuyukResim, Genislik, Convert.ToInt32(aspectRatio * Genislik));

            return kucukResim;
        }
        //
        //
        //
        //
        //
        public static Image ResimKucult(Image BuyukResim, int Width, int Height)
        {
            Bitmap bmp = new Bitmap(BuyukResim.Width, BuyukResim.Height);
            Graphics gr = Graphics.FromImage(bmp);
            gr.FillRectangle(Brushes.White, 0, 0, BuyukResim.Width, BuyukResim.Height);
            gr.DrawImage(BuyukResim, 0, 0, BuyukResim.Width, BuyukResim.Height);

            //Size newsize = new Size(Width, Height);
            //Bitmap thumbimg = new Bitmap(bmp, newsize);
            //Image kucukResim = thumbimg;




            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            g.DrawImage(bmp, 0, 0, Width, Height);
            g.Dispose();


            return b;
        }
        //
        //
        //
        //
        //
        public static ImageFormat ResimFormatiniBelirle(string ContentTip)
        {
            ImageFormat donendeger = ImageFormat.Jpeg;

            if (ContentTip.ToUpper() == "JPG" || ContentTip.ToUpper() == "JPEG")
            {
                donendeger = ImageFormat.Jpeg;
            }
            else if (ContentTip.ToUpper() == "PNG")
            {
                donendeger = ImageFormat.Png;
            }
            else if (ContentTip.ToUpper() == "BMP")
            {
                donendeger = ImageFormat.Bmp;
            }
            else if (ContentTip.ToUpper() == "GIF")
            {
                donendeger = ImageFormat.Gif;
            }

            return donendeger;
        }
        //
        //
        //
        //
        //
        public static Image TedarikciResimOlustur(Image Logo, int buyukluk, int soldanuzaklik, int yukardanuzaklik)
        {
            Bitmap bmp = new Bitmap(500, 500);
            Graphics gr = Graphics.FromImage(bmp);
            Image img = Image.FromFile("\\background.png"); //Application.StartupPath + 
            gr.DrawImage(img, 0, 0, 500, 500);
            img.Dispose();

            img = ResimKucult(Logo, buyukluk);
            int genislik = img.Width;
            int yukseklik = img.Height;
            double aspectRatio = Convert.ToDouble(img.Height) / img.Width;
            genislik = buyukluk;
            yukseklik = Convert.ToInt32(aspectRatio * genislik);
            gr.DrawImage(img, soldanuzaklik, yukardanuzaklik, genislik, yukseklik);

            img.Dispose();
            img = Image.FromFile("\\front.png"); //Application.StartupPath + 
            gr.DrawImage(img, 0, 0, 500, 500);
            img.Dispose();

            Image Tedarikci = bmp;
            return Tedarikci;
        }
        //
        //
        //
        //
        //
        public static Image ResimOlustur400400(byte[] Resim)
        {
            Bitmap bmp = new Bitmap(400, 400);
            Graphics gr = Graphics.FromImage(bmp);
            Image img = ByteToImage(Resim);
            gr.DrawImage(img, 0, 0, 400, 400);
            img.Dispose();

            Image donendeger = bmp;
            return donendeger;
        }
        //
        //
        //
        //
        //
        public static byte[] ResimOlustur400400(byte[] Resim, bool data)
        {
            Bitmap bmp = new Bitmap(400, 400);
            Graphics gr = Graphics.FromImage(bmp);
            Image img2 = ByteToImage(Resim);

            double ar = Convert.ToDouble(img2.Width) / Convert.ToDouble(img2.Height);
            Image img = null;
            if (ar >= 1 && Convert.ToDouble(img2.Width) > 400)
                img = ResimKucult(img2, 400, Convert.ToInt32(Convert.ToDouble(400) / ar));
            else if (ar < 1 && Convert.ToDouble(img2.Height) > 400)
                img = ResimKucult(img2, Convert.ToInt32(Convert.ToDouble(400) * ar), 400);
            else
                img = img2;

            gr.FillRectangle(Brushes.White, 0, 0, 400, 400);
            gr.DrawImage(img, (400 - img.Width) / 2, (400 - img.Height) / 2, img.Width, img.Height);
            img.Dispose();

            Image donendeger = bmp;
            return ImageToByte(donendeger);
        }
        //
        //
        //
        //
        //
        public static byte[] ResimOlustur400400(byte[] Resim, bool data, bool data2)
        {
            Bitmap bmp = new Bitmap(800, 800);
            Graphics gr = Graphics.FromImage(bmp);
            Image img2 = ByteToImage(Resim);
            double ar = Convert.ToDouble(img2.Width) / Convert.ToDouble(img2.Height);
            Image img = null;
            if (ar >= 1 && Convert.ToDouble(img2.Width) > 800)
                img = ResimKucult(img2, 800, Convert.ToInt32(Convert.ToDouble(800) / ar));
            else if (ar < 1 && Convert.ToDouble(img2.Height) > 800)
                img = ResimKucult(img2, Convert.ToInt32(Convert.ToDouble(800) * ar), 800);
            else
                img = img2;
            gr.FillRectangle(Brushes.White, 0, 0, 800, 800);
            gr.DrawImage(img, (800 - img.Width) / 2, (800 - img.Height) / 2, img.Width, img.Height);
            img.Dispose();

            Image donendeger = bmp;
            return ImageToByte(donendeger);
        }
        //
        //
        //
        //
        //
        public static byte[] ResimOlustur500500(byte[] Resim)
        {
            Bitmap bmp = new Bitmap(750, 750);
            Graphics gr = Graphics.FromImage(bmp);
            Image img2 = ByteToImage(Resim);
            double ar = Convert.ToDouble(img2.Width) / Convert.ToDouble(img2.Height);
            Image img = null;
            if (ar >= 1 && Convert.ToDouble(img2.Width) > 750)
                img = ResimKucult(img2, 750, Convert.ToInt32(Convert.ToDouble(750) / ar));
            else if (ar < 1 && Convert.ToDouble(img2.Height) > 750)
                img = ResimKucult(img2, Convert.ToInt32(Convert.ToDouble(750) * ar), 750);
            else
                img = img2;
            gr.FillRectangle(Brushes.White, 0, 0, 750, 750);
            gr.DrawImage(img, (750 - img.Width) / 2, (750 - img.Height) / 2, img.Width, img.Height);
            img.Dispose();

            MemoryStream ms = new MemoryStream();
            EncoderParameter encp = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 65L);
            EncoderParameters encps = new EncoderParameters(1);
            encps.Param[0] = encp;
            bmp.Save(ms, ImageCodecInfo.GetImageEncoders()[1], encps);

            //Image donendeger = bmp.GetThumbnailImage(500, 500, null, new System.IntPtr());
            return ms.ToArray();
        }
        //
        //
        //
        //
        //
        public static byte[] ResimOlustur(byte[] Resim, int Width, int Height, long Quality)
        {
            Bitmap bmp = new Bitmap(Width, Height);
            Graphics gr = Graphics.FromImage(bmp);
            Image img2 = ByteToImage(Resim);
            double ar = Convert.ToDouble(img2.Width) / Convert.ToDouble(img2.Height);
            Image img = null;
            if (ar >= 1 && Convert.ToDouble(img2.Width) > Width)
                img = ResimKucult(img2, Width, Convert.ToInt32(Convert.ToDouble(Width) / ar));
            else if (ar < 1 && Convert.ToDouble(img2.Height) > Height)
                img = ResimKucult(img2, Convert.ToInt32(Convert.ToDouble(Height) * ar), Height);
            else
                img = img2;
            gr.FillRectangle(Brushes.White, 0, 0, Width, Height);
            gr.DrawImage(img, (Width - img.Width) / 2, (Height - img.Height) / 2, img.Width, img.Height);
            img.Dispose();

            MemoryStream ms = new MemoryStream();
            EncoderParameter encp = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, Quality);
            EncoderParameters encps = new EncoderParameters(1);
            encps.Param[0] = encp;
            bmp.Save(ms, ImageCodecInfo.GetImageEncoders()[1], encps);

            return ms.ToArray();
        }
        //
        //
        //
        //
        //
        public static byte[] BosResimOlustur(int Width, int Height)
        {
            Bitmap bmp = new Bitmap(Width, Height);
            Graphics gr = Graphics.FromImage(bmp);
            gr.FillRectangle(Brushes.White, 0, 0, Width, Height);
            gr.DrawString("resim yok", new Font("Arial", 14), Brushes.Black, float.Parse((Width / 2).ToString()), float.Parse((Height / 2).ToString()));

            MemoryStream ms = new MemoryStream();
            EncoderParameter encp = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 50);
            EncoderParameters encps = new EncoderParameters(1);
            encps.Param[0] = encp;
            bmp.Save(ms, ImageCodecInfo.GetImageEncoders()[1], encps);

            return ms.ToArray();
        }
    }
}
