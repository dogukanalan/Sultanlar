using Microsoft.AspNetCore.Mvc;
using Sultanlar.DbObj.Internet;
using Sultanlar.WebAPI.Models.Internet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class CariProvider
    {
        internal List<cariHesaplar> Cariler(int SLSREF) => new cariHesaplar().GetObjectsOnlyMain(SLSREF);
        internal List<cariHesaplar> Bayiler() => new cariHesaplar().GetObjectsOnlyBayi();

        internal List<cariHesaplar> CarilerSub(int GMREF, int SLSREF) => new cariHesaplar().GetObjectsOnlySub(GMREF, SLSREF);

        internal List<cariHesaplar> Cariler1Sub(int GMREF, int SLSREF) => new cariHesaplar().GetObjects1OnlySub(GMREF, SLSREF);
        internal DtAjaxResponse Cariler1SubDetayli(int GMREF, int SLSREF, DataTableAjaxPostModel req)
        {
            List<cariHesaplar> donendeger2 = new cariHesaplar().GetObjects1OnlySub(GMREF, SLSREF, false);
            return Cariler1filtrele(donendeger2, req);
        }
        internal DtAjaxResponse Cariler1Sub(int GMREF, int SLSREF, DataTableAjaxPostModel req)
        {
            //DtAjaxResponse donendeger = new DtAjaxResponse();
            List<cariHesaplar> donendeger2 = new cariHesaplar().GetObjects1OnlySub(GMREF, SLSREF);
            return Cariler1filtrele(donendeger2, req);

            /*donendeger.recordsTotal = donendeger2.Count;
            if (req.search.value != "")
            {
                donendeger2 = donendeger2.ToList().Where(k =>
                    k.GMREF.ToString().ToUpper(CultureInfo.CurrentCulture).IndexOf(req.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.SMREF.ToString().ToUpper(CultureInfo.CurrentCulture).IndexOf(req.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.MUSTERI.ToUpper(CultureInfo.CurrentCulture).IndexOf(req.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.SUBE.ToUpper(CultureInfo.CurrentCulture).IndexOf(req.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1
                ).ToList();
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

            return donendeger;*/
        }
        private DtAjaxResponse Cariler1filtrele(List<cariHesaplar> donendeger2, DataTableAjaxPostModel req)
        {
            DtAjaxResponse donendeger = new DtAjaxResponse();

            donendeger.recordsTotal = donendeger2.Count;
            if (req.search.value != "")
            {
                donendeger2 = donendeger2.ToList().Where(k =>
                    k.GMREF.ToString().ToUpper(CultureInfo.CurrentCulture).IndexOf(req.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.SMREF.ToString().ToUpper(CultureInfo.CurrentCulture).IndexOf(req.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.MUSTERI.ToUpper(CultureInfo.CurrentCulture).IndexOf(req.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.SUBE.ToUpper(CultureInfo.CurrentCulture).IndexOf(req.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1
                ).ToList();
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

        internal List<cariHesaplar> CarilerTpSub(int GMREF) => new cariHesaplar().GetObjectsTPOnlySub(GMREF);

        internal List<cariHesaplar> CarilerAll(int SLSREF) => new cariHesaplar().GetObjects(SLSREF);

        internal List<cariHesaplar> Cariler1All(int SLSREF) => new cariHesaplar().GetObjects1(SLSREF);

        internal List<cariHesaplar> Cariler11All(int SLSREF) => new cariHesaplar().GetObjects11(SLSREF);

        internal List<cariHesaplar> Cariler12All(int SLSREF) => new cariHesaplar().GetObjects12(SLSREF);

        internal List<cariHesaplar> Cariler124All(int SLSREF) => new cariHesaplar().GetObjects124(SLSREF);

        internal cariHesaplar Cari(int TIP, int SMREF) => new cariHesaplar().GetObject1(TIP, SMREF);
    }
}
