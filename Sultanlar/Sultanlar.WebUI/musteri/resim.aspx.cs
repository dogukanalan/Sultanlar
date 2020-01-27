using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text;
using Sultanlar.Class;
using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;
using System.Data;

namespace Sultanlar.WebUI.musteri
{
    public partial class resim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int resimid = 0;



            if (Request.QueryString["bro"] != null && Request.QueryString["bro"] != string.Empty)
            {
                resimid = Convert.ToInt32(Request.QueryString["bro"]);
                Resimler2 resimm = Resimler2.GetObject(resimid);
                byte[] resim = Resim.ResimOlustur500500(resimm.binResim);
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/png";
                Response.AddHeader("content-disposition", string.Format("attachement; filename={0}.jpg", resimm.strAciklama.Replace(" ", "-")));
                Response.BinaryWrite(resim);
            }



            else if (Request.QueryString["broB"] != null && Request.QueryString["broB"] != string.Empty)
            {
                resimid = Convert.ToInt32(Request.QueryString["broB"]);
                Resimler2 resimm = Resimler2.GetObject(resimid);
                byte[] resim = Resim.ResimOlustur400400(resimm.binResim, true, true);
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/png";
                Response.AddHeader("content-disposition", string.Format("attachement; filename={0}.jpg", resimm.strAciklama.Replace(" ", "-")));
                Response.BinaryWrite(resim);
            }



            else if (Request.QueryString["uidO"] != null && Request.QueryString["uidO"] == "0")
            {
                byte[] resim = File.ReadAllBytes(Server.MapPath("img/resimyok_o.png"));
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/png";
                Response.AddHeader("content-disposition", "attachement; filename=resimyok_o.png");
                Response.BinaryWrite(resim);
            }
            else if (Request.QueryString["uidO"] != null && Request.QueryString["uidO"] != string.Empty)
            {
                resimid = Convert.ToInt32(Request.QueryString["uidO"]);
                byte[] resim = Resimler.GetObjectOByResimID(resimid);
                string Urun = Urunler.GetProductName(UrunResim.GetUrunIDByResimID(resimid)).Replace(" ", "-");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/png";
                Response.AddHeader("content-disposition", string.Format("attachement; filename={0}.jpg", Urun));
                Response.BinaryWrite(resim);
            }



            else if (Request.QueryString["uidK"] != null && Request.QueryString["uidK"] == "0")
            {
                byte[] resim = File.ReadAllBytes(Server.MapPath("img/resimyok_k.png"));
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/png";
                Response.AddHeader("content-disposition", "attachement; filename=resimyok_k.png");
                Response.BinaryWrite(resim);
            }
            else if (Request.QueryString["uidK"] != null && Request.QueryString["uidK"] != string.Empty)
            {
                resimid = Convert.ToInt32(Request.QueryString["uidK"]);
                byte[] resim = Resimler.GetObjectKByResimID(resimid);
                string Urun = Urunler.GetProductName(UrunResim.GetUrunIDByResimID(resimid)).Replace(" ", "-");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/png";
                Response.AddHeader("content-disposition", string.Format("attachement; filename={0}.jpg", Urun));
                Response.BinaryWrite(resim);
            }



            else if (Request.QueryString["uid"] != null && Request.QueryString["uid"] == "0")
            {
                byte[] resim = File.ReadAllBytes(Server.MapPath("img/resimyok_o.png"));
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/png";
                Response.AddHeader("content-disposition", "attachement; filename=resimyok_o.png");
                Response.BinaryWrite(resim);
            }
            else if (Request.QueryString["uid"] != null && Request.QueryString["uid"] != string.Empty)
            {
                resimid = Convert.ToInt32(Request.QueryString["uid"]);
                byte[] resim = Resim.ResimOlustur400400(Resimler.GetObjectByResimID(resimid), true, true);
                string Urun = Urunler.GetProductName(UrunResim.GetUrunIDByResimID(resimid)).Replace(" ", "-");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/png";
                Response.AddHeader("content-disposition", string.Format("attachement; filename={0}.jpg", Urun));
                Response.BinaryWrite(resim);
            }



            else if (Request.QueryString["uidH"] != null && Request.QueryString["uidH"] == "0")
            {
                byte[] resim = File.ReadAllBytes(Server.MapPath("img/resimyok_o.png"));
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/png";
                Response.AddHeader("content-disposition", "attachement; filename=resimyok_o.png");
                Response.BinaryWrite(resim);
            }
            else if (Request.QueryString["uidH"] != null && Request.QueryString["uidH"] != string.Empty)
            {
                resimid = Convert.ToInt32(Request.QueryString["uidH"]);
                byte[] resim = Resim.ResimOlustur400400(MalzemeHaric.GetResim(resimid), true, true);
                string Urun = resimid.ToString();
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/png";
                Response.AddHeader("content-disposition", string.Format("attachement; filename={0}.jpg", Urun));
                Response.BinaryWrite(resim);
            }



            else if (Request.QueryString["tid"] != null && Request.QueryString["tid"] == "0")
            {
                byte[] resim = File.ReadAllBytes(Server.MapPath("img/bos.png"));
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/png";
                Response.AddHeader("content-disposition", "attachement; filename=bos.png");
                Response.BinaryWrite(resim);
            }
            else if (Request.QueryString["tid"] != null && Request.QueryString["tid"] != string.Empty)
            {
                resimid = Convert.ToInt32(Request.QueryString["tid"]);
                byte[] resim = Resimler.GetObjectOByResimID(resimid);
                string Urun = Urunler.GetProductName(UrunResim.GetUrunIDByResimID(resimid)).Replace(" ", "-");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/png";
                Response.AddHeader("content-disposition", string.Format("attachement; filename={0}.jpg", Urun));
                Response.BinaryWrite(resim);
            }



            else if (Request.QueryString["itemref"] != null && Request.QueryString["itemref"] != string.Empty)
            {
                resimid = UrunResim.GetResimIDByUrunID(Convert.ToInt32(Request.QueryString["itemref"]));
                byte[] resim = Resimler.GetObjectByResimID(resimid);
                string Urun = Urunler.GetProductName(UrunResim.GetUrunIDByResimID(resimid)).Replace(" ", "-");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/png";
                Response.AddHeader("content-disposition", string.Format("attachement; filename={0}.jpg", Urun));
                try
                {
                    Response.BinaryWrite(resim);
                }
                catch (Exception)
                {
                    resim = File.ReadAllBytes(Server.MapPath("img/resimyok_o.png"));
                    Response.BinaryWrite(resim);
                }
            }



            else if (Request.QueryString["uid400"] != null && Request.QueryString["uid400"] == "0")
            {
                byte[] resim = File.ReadAllBytes(Server.MapPath("img/resimyok_b.png"));
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/png";
                Response.AddHeader("content-disposition", "attachement; filename=resimyok_b.png");
                Response.BinaryWrite(resim);
            }
            else if (Request.QueryString["uid400"] != null && Request.QueryString["uid400"] != string.Empty)
            {
                resimid = Convert.ToInt32(Request.QueryString["uid400"]);
                byte[] resim = Resim.ResimOlustur400400(Resimler.GetObjectByResimID(resimid), true);
                string Urun = Urunler.GetProductName(UrunResim.GetUrunIDByResimID(resimid)).Replace(" ", "-");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/png";
                Response.AddHeader("content-disposition", string.Format("attachement; filename={0}.jpg", Urun));
                Response.BinaryWrite(resim);
            }



            else if (Request.QueryString["fid"] != null && Request.QueryString["fid"] == "0")
            {
                byte[] resim = File.ReadAllBytes(Server.MapPath("img/resimyok_o.png"));
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/png";
                Response.AddHeader("content-disposition", "attachement; filename=resimyok_o.png");
                Response.BinaryWrite(resim);
            }
            else if (Request.QueryString["fid"] != null && Request.QueryString["fid"] != string.Empty)
            {
                resimid = Convert.ToInt32(Request.QueryString["fid"]);
                byte[] resim = Resimler.GetObjectByResimID(resimid);
                string Urun = Urunler.GetProductBarkod(UrunResim.GetUrunIDByResimID(resimid)); //Urunler.GetProductName(UrunResim.GetUrunIDByResimID(resimid)).Replace(" ", "-")
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/png";
                Response.AddHeader("content-disposition", string.Format("attachement; filename={0}.jpg", Urun));
                Response.BinaryWrite(resim);
            }



            else if (Request.QueryString["musres"] != null && Request.QueryString["musres"] != string.Empty)
            {
                RutResim rutresim = RutResim.GetObject(Convert.ToInt32(Request.QueryString["musres"]));
                byte[] resim = rutresim.binResim;
                string isim = rutresim.strAciklama.Replace(" ", "-");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/jpeg";
                Response.AddHeader("content-disposition", string.Format("attachement; filename={0}.jpg", isim));
                try
                {
                    Response.BinaryWrite(resim);
                }
                catch (Exception)
                {
                    resim = File.ReadAllBytes(Server.MapPath("img/resimyok_o.png"));
                    Response.BinaryWrite(resim);
                }
            }
            else if (Request.QueryString["musresK"] != null && Request.QueryString["musresK"] != string.Empty)
            {
                RutResim rutresim = RutResim.GetObject(Convert.ToInt32(Request.QueryString["musresK"]));
                byte[] resim = Resim.ImageToByte(Resim.ResimKucult(Resim.ByteToImage(rutresim.binResim), 45));
                string isim = rutresim.strAciklama.Replace(" ", "-");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/jpeg";
                Response.AddHeader("content-disposition", string.Format("attachement; filename={0}.jpg", isim));
                try
                {
                    Response.BinaryWrite(resim);
                }
                catch (Exception)
                {
                    resim = File.ReadAllBytes(Server.MapPath("img/resimyok_o.png"));
                    Response.BinaryWrite(resim);
                }
            }



            else
            {
                Response.Redirect("default.aspx", true);
            }

            if (Request.QueryString["count"] != null && Request.QueryString["count"] == "1")
            {
                ResimlerIndirmeler ri = new ResimlerIndirmeler(resimid, 
                    ((Musteriler)Session["Musteri"]).pkMusteriID, DateTime.Now, "");
                ri.DoInsert();
            }

            Response.Flush();
            Response.End();
        }

        [System.Web.Services.WebMethod()]
        public static void UploadPicMerch(string imageData, string smref, string tip, string tur, string musteri, string ziyaret, string rut, string aciklama)
        {
            byte[] resim = Convert.FromBase64String(imageData);
            int SMREF = Convert.ToInt32(smref);
            int TIP = Convert.ToInt32(tip);
            int MUSTERI = Convert.ToInt32(musteri);
            int TUR = Convert.ToInt32(tur);
            int ZIYARET = Convert.ToInt32(ziyaret);
            RutResim rr = new RutResim(SMREF, TIP, MUSTERI, TUR, rut, ZIYARET, DateTime.Now, resim, aciklama, "");
            rr.DoInsert();
        }
    }
}