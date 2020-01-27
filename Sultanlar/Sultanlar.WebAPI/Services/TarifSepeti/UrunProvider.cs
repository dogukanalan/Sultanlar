using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Sultanlar.DatabaseObject;
using Sultanlar.WebAPI.Models.TarifSepeti;

namespace Sultanlar.WebAPI.Services.TarifSepeti
{
    public class UrunProvider
    {
        public List<Urun> UrunlerGetir()
        {
            List<Urun> donendeger = new List<Urun>();

            DataTable dt = new DataTable();
            WebGenel.Sorgu(dt, "SELECT [Web-Malzeme-Full].[ITEMREF] AS UrunID, IsNull((SELECT TOP 1 intResimID FROM tblINTERNET_UrunResim WHERE ITEMREF = [Web-Malzeme-Full].[ITEMREF]), 0) AS pkResimID, [MAL ACIK] AS Ad,[BARKOD] AS Barkod,strKategori AS Kategori FROM [Web-Malzeme-Full] LEFT OUTER JOIN tblKENTON_UrunKategori ON [Web-Malzeme-Full].[ITEMREF] = tblKENTON_UrunKategori.intUrunID LEFT OUTER JOIN tblKENTON_KategorilerUrun ON tblKENTON_UrunKategori.intKategoriID = tblKENTON_KategorilerUrun.pkID WHERE [MAL ACIK] LIKE '%KENTON%' AND IsNull((SELECT TOP 1 intResimID FROM tblINTERNET_UrunResim WHERE ITEMREF = [Web-Malzeme-Full].[ITEMREF]), 0) != 0 ORDER BY [MAL ACIK] ASC");
            
            for (int i = 0; i < dt.Rows.Count; i++)
                donendeger.Add(new Urun(Convert.ToInt32(dt.Rows[i]["UrunID"]), dt.Rows[i]["Ad"].ToString(), Convert.ToInt32(dt.Rows[i]["pkResimID"])));

            return donendeger;
        }

        public List<Urun> UrunlerGetir(UrunGet get)
        {
            List<Urun> donendeger = new List<Urun>();

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
                    donendeger.Add(new Urun(Convert.ToInt32(dt.Rows[i]["UrunID"]), dt.Rows[i]["Ad"].ToString(), Convert.ToInt32(dt.Rows[i]["pkResimID"])));
                sinir++;
            }

            return donendeger;
        }
    }
}
