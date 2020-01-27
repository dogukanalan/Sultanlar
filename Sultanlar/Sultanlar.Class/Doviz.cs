using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Sultanlar.Class
{
    public class Doviz
    {
        //
        //
        public static string[,] DovizGetir()
        {
            DataSet ds = new DataSet();
            ds.ReadXml("http://www.tcmb.gov.tr/kurlar/today.xml");
            string[,] donendeger = new string[2, 3]; // dollar ve euro icin

            int j = 0;
            for (int i = 0; i < ds.Tables[1].Rows.Count; i++) // ilk tablo tarih
            {
                if (i == 0 || i == 11) // dollar ve euro
                {
                    donendeger[j, 0] = ds.Tables[1].Rows[i]["Isim"].ToString();
                    donendeger[j, 1] = ds.Tables[1].Rows[i]["ForexBuying"].ToString();
                    donendeger[j, 2] = ds.Tables[1].Rows[i]["ForexSelling"].ToString();
                    j++;
                }
            }

            return donendeger;
        }
        //
        //
        public static string[,] DovizGetirAlternatif()
        {
            DataSet ds = new DataSet();
            ds.ReadXml("http://xml.altinkaynak.com.tr/doviz.xml");
            string[,] donendeger = new string[2, 3]; // dollar ve euro icin

            for (int i = 0; i < ds.Tables[0].Rows.Count - 1; i++) // ilk satir tarih
            {
                if (i == 0 || i == 1) // dollar ve euro
                {
                    donendeger[i, 0] = ds.Tables[0].Rows[i + 1]["ADI"].ToString();
                    donendeger[i, 1] = ds.Tables[0].Rows[i + 1]["ALIS"].ToString();
                    donendeger[i, 2] = ds.Tables[0].Rows[i + 1]["SATIS"].ToString();
                }
            }

            return donendeger;
        }
    }
}
