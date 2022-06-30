using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WCF
{
    /// <summary>
    /// Summary description for siparis
    /// </summary>
    public class siparis : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string donendeger = "hata";
            bool aktarildi = false;

            Siparisler sip = Siparisler.GetObjectsBySiparisID(Convert.ToInt32(context.Request.QueryString["siparisid"]));

            if (Musteriler.GetMusteriByID(Convert.ToInt32(context.Request.QueryString["musteriid"])).blTaksitPlani) // harici bayi elemanı
            {
                sip.dtOnaylamaTarihi = DateTime.Now;
                sip.blAktarilmis = true;
                sip.DoUpdate();
                aktarildi = true;
            }
            else
            {
                DataTable dt = new DataTable();
                SiparislerDetay.GetObjectsBySiparisID(dt, sip.pkSiparisID);
                DataTable dt1 = new DataTable();
                WebGenel.Sorgu(dt1, @"SELECT ITEMREF FROM (SELECT ITEMREF 
,(SELECT SUM(HEDEF) FROM [Web-Hedef] WHERE YIL = YEAR(GETDATE()) AND AY = MONTH(GETDATE()) AND PRIMB = [Web-Hedef-3].ITEMREF) * (100 + LIMIT) / 100 AS LIMIT
,(SELECT SUM(KOLIT) FROM [Web-Satis-Rapor-1] WHERE YIL = YEAR(GETDATE()) AND AY = MONTH(GETDATE()) AND ITEMREF = [Web-Hedef-3].ITEMREF)
+ (SELECT sum(BKL_AD / (CASE WHEN KOLI = 0 THEN 1 ELSE KOLI END)) FROM SAP_SIPARIS_STR_DRM INNER JOIN [Web-Malzeme-Full] ON ITEMREF = MALZ_KOD WHERE YIL = YEAR(GETDATE()) AND AY = MONTH(GETDATE()) AND MALZ_KOD = [Web-Hedef-3].ITEMREF)
AS GIRILEN
FROM [Web-Hedef-3]
) AS TABLO1
WHERE (CASE WHEN LIMIT <= GIRILEN THEN 1 ELSE 0 END) = 1");

                ArrayList al = new ArrayList();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt1.Rows.Count; j++)
                    {
                        if (dt.Rows[i]["intUrunID"].ToString() == dt1.Rows[j]["ITEMREF"].ToString())
                        {
                            al.Add(dt1.Rows[j]["ITEMREF"].ToString());
                        }
                    }
                }

                if (al.Count == 0)
                {
                    aktarildi = Siparis.SiparisOnayla(Convert.ToInt32(context.Request.QueryString["siparisid"]), Convert.ToInt32(context.Request.QueryString["sevkref"]), Convert.ToInt32(context.Request.QueryString["depoid"]), Convert.ToBoolean(context.Request.QueryString["bakiye"]), Musteriler.GetMusteriByID(Convert.ToInt32(context.Request.QueryString["musteriid"])), out donendeger);
                }
                else
                {
                    aktarildi = false;
                    donendeger = "Şu ürünlerde limit aşımı mevcut: ";
                    for (int i = 0; i < al.Count; i++)
                    {
                        donendeger += al[i].ToString() + ",";
                    }
                    donendeger = donendeger.Substring(0, donendeger.Length - 1);
                }
            }

            if (aktarildi)
            {
                donendeger = string.Empty;
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(donendeger);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}