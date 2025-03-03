﻿using Sultanlar.DbObj.Internet;
using Sultanlar.WebAPI.Models.Internet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class RutProvider
    {
        internal List<rutlar> Rutlar(int Slsref) => new rutlar().GetObjects(Slsref);
        internal List<rutlar> RutlarBugun(int Slsref) => new rutlar().GetObjectsBugun(Slsref);
        internal DtAjaxResponse RutResimler(int Slsref, int Smref, int Tip, int Tur, int Yil, int Ay, DataTableAjaxPostModel req)
        {
            DtAjaxResponse donendeger = new DtAjaxResponse();
            List<rutResimler> donendeger2 = new List<rutResimler>();

            object slsref = Slsref == 0 ? (object)DBNull.Value : Slsref;
            object smref = Smref == 0 ? (object)DBNull.Value : Smref;
            object tip = Tip == 0 ? (object)DBNull.Value : Tip;
            object tur = Tur == 0 ? (object)DBNull.Value : Tur;
            object ay = Ay == 0 ? (object)DBNull.Value : Ay;

            donendeger2 = new rutResimler().GetObjects(slsref, smref, tip, tur, Yil, ay);

            donendeger.recordsTotal = donendeger2.Count;
            for (int i = 0; i < req.columns.Count; i++)
            {
                if (req.columns[i].search.value != string.Empty)
                {
                    if (req.columns[i].name == "musteri")
                        donendeger2 = donendeger2.ToList().Where(k => k.Cari.MUSTERI.ToUpper(CultureInfo.CurrentCulture).IndexOf(req.columns[i].search.value.ToUpper(CultureInfo.CurrentCulture)) > -1).ToList();
                    else if (req.columns[i].name == "sube")
                        donendeger2 = donendeger2.ToList().Where(k => k.Cari.SUBE.ToUpper(CultureInfo.CurrentCulture).IndexOf(req.columns[i].search.value.ToUpper(CultureInfo.CurrentCulture)) > -1).ToList();
                    else if (req.columns[i].name == "adSoyad")
                        donendeger2 = donendeger2.ToList().Where(k => k.Musteri.AdSoyad.ToUpper(CultureInfo.CurrentCulture).IndexOf(req.columns[i].search.value.ToUpper(CultureInfo.CurrentCulture)) > -1).ToList();
                    else if (req.columns[i].name == "strAciklama")
                        donendeger2 = donendeger2.ToList().Where(k => k.strAciklama.ToUpper(CultureInfo.CurrentCulture).IndexOf(req.columns[i].search.value.ToUpper(CultureInfo.CurrentCulture)) > -1).ToList();
                    else if (req.columns[i].name == "tur")
                        donendeger2 = donendeger2.ToList().Where(k => k.Tur.value.ToUpper(CultureInfo.CurrentCulture).IndexOf(req.columns[i].search.value.ToUpper(CultureInfo.CurrentCulture)) > -1).ToList();
                    else if (req.columns[i].name == "dtTarih")
                        donendeger2 = donendeger2.ToList().Where(k => k.dtTarih.ToShortDateString() == Convert.ToDateTime(req.columns[i].search.value).ToShortDateString()).ToList();
                }
            }
            donendeger.recordsFiltered = donendeger2.Count;

            int Baslangic = req.start;
            int Kactane = req.length;
            int sinir = (Baslangic + Kactane) < donendeger2.Count ? (Baslangic + Kactane) : donendeger2.Count;

            donendeger.json = new List<object>();
            for (int i = Baslangic; i < sinir; i++)
            {
                donendeger.json.Add(donendeger2[i]);
            }

            return donendeger;
        }
        internal List<rutResimler> RutResimler(string RutID) => new rutResimler().GetObjects(RutID);
        internal DtAjaxResponse Musteriler(int Slsref, int Sira, int Rutlu, DataTableAjaxPostModel Req)
        {
            Dictionary<string, string> arama = new Dictionary<string, string>();
            for (int i = 0; i < Req.columns.Count; i++)
                if (Req.columns[i].search.value != string.Empty)
                    arama.Add(Req.columns[i].data, Req.columns[i].search.value);
            return new rutlar().GetObjects(Slsref, Sira, Rutlu, Req.length, Req.start, arama);
        }
        //databaseobject
        internal string RutEkle(string mtip, string slsref, string gmref, string smref, string kacinci, string periyod, string gun, string baslangic, string bitis, string islemyapan)
        {
            Sultanlar.DatabaseObject.Internet.Musteriler mus = Sultanlar.DatabaseObject.Internet.Musteriler.GetMusteriByID(Convert.ToInt32(islemyapan));
            Sultanlar.DatabaseObject.Internet.Rutlar.Insert(Convert.ToInt32(mtip), Convert.ToInt32(slsref), Convert.ToInt32(gmref), Convert.ToInt32(smref), Convert.ToInt32(kacinci), periyod.Trim(), gun.Trim(), Convert.ToDateTime(baslangic == "" ? DateTime.Now.ToShortDateString() : baslangic), Convert.ToDateTime((bitis == "" ? "01/01/2023" : bitis)), mus.strAd + " " + mus.strSoyad, DateTime.Now);
            return "";
        }
        //databaseobject
        internal Rut RutGetir(string slsref, string gmref, string smref, string kacinci)
        {
            DataTable dt = new DataTable();
            Sultanlar.DatabaseObject.Internet.Rutlar.GetRutDetay(dt, Convert.ToInt32(slsref), Convert.ToInt32(gmref), Convert.ToInt32(smref), Convert.ToInt32(kacinci));
            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value && dt.Rows[0][0].ToString() != string.Empty)
                return new Rut(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), Convert.ToDateTime(dt.Rows[0][3]).ToShortDateString(), Convert.ToDateTime(dt.Rows[0][4]).ToShortDateString());
            return new Rut("", "", "", "", "");
        }
    }
}
