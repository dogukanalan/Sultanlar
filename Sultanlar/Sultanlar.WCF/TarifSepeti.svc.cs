using Sultanlar.Class;
using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Kenton;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Script.Services;
using System.Web.Services;

namespace Sultanlar.WCF
{
    public class TarifSepeti : ITarifSepeti
    {
        public List<UrunPost> UrunlerGetir(UrunGet get)
        {
            List<UrunPost> donendeger = new List<UrunPost>();

            string kategori = string.Empty;
            if (get.katid != 0)
                kategori = " AND intKategoriID = " + get.katid.ToString();

            string urun = string.Empty;
            if (get.aranan.Trim() != string.Empty)
                urun = " AND [MAL ACIK] LIKE '%" + get.katid.ToString() + "%'";

            DataTable dt = new DataTable();
            WebGenel.Sorgu(dt, "SELECT [Web-Malzeme-Full].[ITEMREF] AS UrunID, IsNull((SELECT TOP 1 intResimID FROM tblINTERNET_UrunResim WHERE ITEMREF = [Web-Malzeme-Full].[ITEMREF]), 0) AS pkResimID, [MAL ACIK] AS Ad,[BARKOD] AS Barkod,strKategori AS Kategori FROM [Web-Malzeme-Full] LEFT OUTER JOIN tblKENTON_UrunKategori ON [Web-Malzeme-Full].[ITEMREF] = tblKENTON_UrunKategori.intUrunID LEFT OUTER JOIN tblKENTON_KategorilerUrun ON tblKENTON_UrunKategori.intKategoriID = tblKENTON_KategorilerUrun.pkID WHERE [MAL ACIK] LIKE '%KENTON%' AND IsNull((SELECT TOP 1 intResimID FROM tblINTERNET_UrunResim WHERE ITEMREF = [Web-Malzeme-Full].[ITEMREF]), 0) != 0" + urun + kategori + " ORDER BY [MAL ACIK] ASC");

            int sinir = 0;
            for (int i = get.sonid; i < dt.Rows.Count; i++)
            {
                if (sinir < 20)
                    donendeger.Add(new UrunPost(Convert.ToInt32(dt.Rows[i]["UrunID"]), dt.Rows[i]["Ad"].ToString(), Convert.ToInt32(dt.Rows[i]["pkResimID"])));
                sinir++;
            }

            return donendeger;
        }

        public List<TarifPost> TariflerGetir(TarifGet get)
        {
            List<TarifPost> donendeger = new List<TarifPost>();

            List<Tarifler> returnvalue = new List<Tarifler>();

            if (get.action == "")
                returnvalue = Tarifler.GetObjects(get.sonid, get.kactane, get.aranan, get.katid, get.order);
            else if (get.action == "benim")
                returnvalue = Tarifler.GetObjectsOwn(get.sonid, get.kactane, Convert.ToInt32(Sifreleme.Decrypt(get.uyeid)), get.aranan, get.order);
            else if (get.action == "fav")
                returnvalue = Tarifler.GetObjectsFav(get.sonid, get.kactane, Convert.ToInt32(Sifreleme.Decrypt(get.uyeid)), get.aranan, get.order);
            else if (get.action == "urun")
                returnvalue = Tarifler.GetObjectsByUrunID(get.sonid, get.kactane, Convert.ToInt32(get.urunid), get.aranan, get.order); // uye id aslinda urun id
            else if (get.action == "kul")
                returnvalue = Tarifler.GetObjectsKul(get.sonid, get.kactane, get.aranan, get.katid, get.order);

            for (int i = 0; i < returnvalue.Count; i++)
                donendeger.Add(new TarifPost(returnvalue[i].pkID, returnvalue[i].intUyeID, returnvalue[i].Uye, returnvalue[i].blOnay, returnvalue[i].strBaslik, returnvalue[i].strMalzemeler, returnvalue[i].strHazirlanis, returnvalue[i].binResim, returnvalue[i].binResimUrunler, returnvalue[i].strUrunlerLink, returnvalue[i].dtTarih, returnvalue[i].OrtPuan, returnvalue[i].TarifKategoriler));

            return donendeger;
        }
        
        public GirisPost GirisYap(GirisGet get)
        {
            return new GirisPost(Uyeler.Validate(get.eposta, Sifreleme.Encrypt(get.sifre)));
        }
    }
}
