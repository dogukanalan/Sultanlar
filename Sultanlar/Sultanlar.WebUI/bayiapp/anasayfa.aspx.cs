using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;
using System.Data;
using System.Collections;
using Sultanlar.DatabaseObject.Kenton;
using Sultanlar.DatabaseObject;

namespace Sultanlar.WebUI.bayiapp
{
    public partial class anasayfa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static List<Urun> UrunlerGetir(int sonid, string aranan, int katid)
        {
            List<Urun> donendeger = new List<Urun>();

            string kategori = string.Empty;
            if (katid != 0)
                kategori = " AND intKategoriID = " + katid.ToString();

            string urun = string.Empty;
            if (aranan.Trim() != string.Empty)
                urun = " AND [MAL ACIK] LIKE '%" + katid.ToString() + "%'";

            DataTable dt = new DataTable();
            WebGenel.Sorgu(dt, "SELECT [Web-Malzeme-Full].[ITEMREF] AS UrunID, IsNull((SELECT TOP 1 intResimID FROM tblINTERNET_UrunResim WHERE ITEMREF = [Web-Malzeme-Full].[ITEMREF]), 0) AS pkResimID, [MAL ACIK] AS Ad,[BARKOD] AS Barkod,strKategori AS Kategori FROM [Web-Malzeme-Full] LEFT OUTER JOIN tblKENTON_UrunKategori ON [Web-Malzeme-Full].[ITEMREF] = tblKENTON_UrunKategori.intUrunID LEFT OUTER JOIN tblKENTON_KategorilerUrun ON tblKENTON_UrunKategori.intKategoriID = tblKENTON_KategorilerUrun.pkID WHERE [MAL ACIK] LIKE '%KENTON%' AND IsNull((SELECT TOP 1 intResimID FROM tblINTERNET_UrunResim WHERE ITEMREF = [Web-Malzeme-Full].[ITEMREF]), 0) != 0" + urun + kategori + " ORDER BY [MAL ACIK] ASC");

            int sinir = 0;
            for (int i = sonid; i < dt.Rows.Count; i++)
            {
                if (sinir < 20)
                    donendeger.Add(new Urun(Convert.ToInt32(dt.Rows[i]["UrunID"]), dt.Rows[i]["Ad"].ToString(), Convert.ToInt32(dt.Rows[i]["pkResimID"])));
                sinir++;
            }

            return donendeger;
        }
    }

    public class Urun
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public int ResimID { get; set; }

        public Urun(int ID, string Ad, int ResimID)
        {
            this.ID = ID;
            this.Ad = Ad;
            this.ResimID = ResimID;
        }
    }
}