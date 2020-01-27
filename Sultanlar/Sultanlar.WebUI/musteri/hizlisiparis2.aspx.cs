using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WebUI.musteri
{
    public partial class hizlisiparis2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["SMREF"] == null || Session["Musteri"] == null || Session["FiyatTipi"] == null)
                    Response.Redirect("default.aspx", true);

                int MusteriID = 0;
                if (Session["SiparisSahibiMusteriID"] != null)
                    MusteriID = Convert.ToInt32(Session["SiparisSahibiMusteriID"]);
                else
                    MusteriID = ((Musteriler)Session["Musteri"]).pkMusteriID;

                siparissahibimusteriid.Value = MusteriID.ToString();
                fiyattipi.Value = Session["FiyatTipi"].ToString();
                smref.Value = Session["SMREF"].ToString();

                Session["OfflineButunUrunler"] = null;
                Session["SiparisSahibiMusteriID"] = null;
                Session["FiyatTipi"] = null;
                Session["SMREF"] = null;
                Session["RISKBAKIYE"] = null;
            }
        }

        public string GetUrunler()
        {
            DataTable dt = new DataTable();
            Urunler.GetProductsHS(dt, fiyattipi.Value, (bool)Session["OfflineButunUrunler"], (int)Session["SMREF"]);

            string database = "<div id='isoisoiso' class='isotope' style='display: none'>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                database += "<div class='element-item transition metal ' data-category='transition'><p class='symbol'>" + dt.Rows[i]["Barkod"].ToString() + "</p><h3 class='name'>" + dt.Rows[i]["Ad"].ToString().Replace(".", " ") + "</h3><p class='weight'>" + dt.Rows[i]["Fiyat"].ToString() + " TL</p><p class='number'><input type='text' title='" + dt.Rows[i]["Ad"].ToString().Replace(".", " ") + "' id='" + dt.Rows[i]["UrunID"].ToString() + "' style='width: 20px; text-align: center; font-size: 10px' onkeydown='return clickButton(event,\"btnAktar\")' /></p></div>";
                //database += "<div class='element-item transition metal ' data-category='transition'><h3 class='name'>" + dt.Rows[i]["Ad"].ToString().Replace(".", " ") + "</h3><p class='weight'>" + dt.Rows[i]["Fiyat"].ToString() + " TL</p><p class='number'><input type='text' title='" + dt.Rows[i]["Ad"].ToString().Replace(".", " ") + "' id='" + dt.Rows[i]["UrunID"].ToString() + "' style='width: 20px; text-align: center; font-size: 10px' onkeydown='return clickButton(event,\"btnAktar\")' /></p></div>";
            }
            return database + "</div>";
        }

        protected void btnSiparisTamamla_Click(object sender, EventArgs e)
        {
            Siparisler sip = new Siparisler(
                    Convert.ToInt32(siparissahibimusteriid.Value),
                    Convert.ToInt32(smref.Value),
                    Convert.ToInt16(fiyattipi.Value),
                    DateTime.Now,
                    0,
                    false,
                    147,
                    DateTime.Now,
                    ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad + ";;;offline;;; ");
            sip.DoInsert();

            string[] UrunIDs = siparisurunidler.Value.Split(new char[] { ';' }, StringSplitOptions.None);
            string[] Miktars = siparisurunmiktarlar.Value.Split(new char[] { ';' }, StringSplitOptions.None);

            decimal toplamtutar = 0;
            decimal vadetoplam = 0;
            for (int i = 0; i < UrunIDs.Length - 1; i++) // son satır null
            {
                if (Convert.ToInt32(Miktars[i]) > 0)
                {
                    SiparislerDetay detay = new SiparislerDetay(
                        sip.pkSiparisID,
                        Convert.ToInt32(UrunIDs[i]),
                        Urunler.GetProductName(Convert.ToInt32(UrunIDs[i])),
                        Convert.ToInt32(Miktars[i]),
                        Urunler.GetProductPrice(Convert.ToInt32(UrunIDs[i]), sip.sintFiyatTipiID),
                        Guid.Empty,
                        false,
                        Guid.Empty, 
                        "ST");
                    detay.DoInsert();

                    int vade = Urunler.GetProductVade(detay.intUrunID, sip.sintFiyatTipiID);
                    vadetoplam += detay.intMiktar * detay.mnFiyat * vade;
                    toplamtutar += detay.intMiktar * detay.mnFiyat;
                }
            }

            if (UrunIDs.Length - 1 <= 0) // siparişe ürün eklenmişse
            {
                sip.DoDelete();

                Response.Redirect("default.aspx", true);
            }
            else
            {
                sip.mnToplamTutar = toplamtutar;
                sip.TKSREF = TaksitPlanlari.GetODMREF(Convert.ToInt32(Math.Round(vadetoplam / toplamtutar)));
                sip.DoUpdate();

                Session["SiparisTamamlaOnaylaBasildi"] = sip.SMREF;
                Session["OnaylanacakSiparisID"] = sip.pkSiparisID;

                Response.Redirect("siparisler.aspx", true);
            }
        }
    }
}