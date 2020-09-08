using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sultanlar.DbObj.Internet;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using Sultanlar.WebAPI.Models.Internet;
using Sultanlar.DatabaseObject.Internet;
using Sultanlar.Class;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class ResimProvider
    {
        internal resimler Resimler(int ResimID) => new resimler(ResimID).GetObject();

        internal string SDEResimGonder(SDEResim sderesim)
        {
            rutResimler rr = new rutResimler(sderesim.smref, sderesim.tip, Convert.ToInt32(sderesim.musteri), sderesim.tur, sderesim.rut, sderesim.ziyaret, DateTime.Now, Convert.FromBase64String(sderesim.resim), sderesim.aciklama, sderesim.not);
            rr.DoInsert();
            return rr.pkID.ToString();
        }

        internal rutResimler SDEResim(int ID) => new rutResimler(ID).GetObject();

        internal List<rutResimTurler> SDEResimTurler() => new rutResimTurler().GetObjects();
        //
        //
        //
        //
        //
        internal byte[] BosResimOlustur(int Width, int Height)
        {
            Bitmap bmp = new Bitmap(Width, Height);
            Graphics gr = Graphics.FromImage(bmp);
            gr.FillRectangle(Brushes.Transparent, 0, 0, Width, Height);

            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Png);

            return ms.ToArray();
        }
        //
        //
        //
        //
        //
        internal byte[] ResimOlustur(byte[] Resim, int Width, int Height, long Quality)
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
            EncoderParameter encp = new EncoderParameter(Encoder.Quality, Quality);
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
        private Image ByteToImage(byte[] data)
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
        private Image ResimKucult(Image BuyukResim, int Width, int Height)
        {
            Bitmap bmp = new Bitmap(BuyukResim.Width, BuyukResim.Height);
            Graphics gr = Graphics.FromImage(bmp);
            gr.FillRectangle(Brushes.White, 0, 0, BuyukResim.Width, BuyukResim.Height);
            gr.DrawImage(BuyukResim, 0, 0, BuyukResim.Width, BuyukResim.Height);
            
            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            g.DrawImage(bmp, 0, 0, Width, Height);
            g.Dispose();
            
            return b;
        }
    }
}
