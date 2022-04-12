using Sultanlar.DbObj.Internet;
using Sultanlar.WebAPI.Models.Internet;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class SatisRaporuProvider
    {
        internal List<satisRaporu> SatisRapor(int Yil, int Ay, int Slsref, int Gmref, int Smref, int Itemref)
        {
            //object slsref = Slsref == 0 ? DBNull.Value : (object)Slsref;
            object gmref = Gmref == 0 ? DBNull.Value : (object)Gmref;
            object smref = Smref == 0 ? DBNull.Value : (object)Smref;
            object itemref = Itemref == 0 ? DBNull.Value : (object)Itemref;
            return new satisRaporu().GetObjects(Yil, Ay, Slsref, gmref, smref, itemref);
        }

        internal DtAjaxResponse SatisRapor(int Yil, int Ay, int Slsref, int Gmref, int Smref, int Itemref, DataTableAjaxPostModel Req)
        {
            DtAjaxResponse donendeger = new DtAjaxResponse();

            //object slsref = Slsref == 0 ? DBNull.Value : (object)Slsref;
            object ay = Ay == 0 ? DBNull.Value : (object)Ay;
            object gmref = Gmref == 0 ? DBNull.Value : (object)Gmref;
            object smref = Smref == 0 ? DBNull.Value : (object)Smref;
            object itemref = Itemref == 0 ? DBNull.Value : (object)Itemref;
            List<satisRaporu> donendeger2 = new satisRaporu().GetObjects(Yil, ay, Slsref, gmref, smref, itemref);

            donendeger.recordsTotal = donendeger2.Count;

            for (int i = 0; i < Req.columns.Count; i++)
            {
                if (Req.columns[i].search.value != string.Empty)
                {
                    if (Req.columns[i].name == "turack")
                        donendeger2 = donendeger2.ToList().Where(k => k.TURACK.ToUpper(CultureInfo.CurrentCulture).IndexOf(Req.columns[i].search.value.ToUpper(CultureInfo.CurrentCulture)) > -1).ToList();
                    else if (Req.columns[i].name == "sipno")
                        donendeger2 = donendeger2.ToList().Where(k => k.SIPNO.ToUpper(CultureInfo.CurrentCulture).IndexOf(Req.columns[i].search.value.ToUpper(CultureInfo.CurrentCulture)) > -1).ToList();
                    else if (Req.columns[i].name == "siptar")
                        donendeger2 = donendeger2.ToList().Where(k => k.SIPTAR.ToShortDateString() == Convert.ToDateTime(Req.columns[i].search.value).ToShortDateString()).ToList();
                    else if (Req.columns[i].name == "fatnomtb")
                        donendeger2 = donendeger2.ToList().Where(k => k.FATNO.ToUpper(CultureInfo.CurrentCulture).IndexOf(Req.columns[i].search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 || k.FATNOMTB.ToUpper(CultureInfo.CurrentCulture).IndexOf(Req.columns[i].search.value.ToUpper(CultureInfo.CurrentCulture)) > -1).ToList();
                    else if (Req.columns[i].name == "fatno")
                        donendeger2 = donendeger2.ToList().Where(k => k.FATNO.ToUpper(CultureInfo.CurrentCulture).IndexOf(Req.columns[i].search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 || k.FATNOMTB.ToUpper(CultureInfo.CurrentCulture).IndexOf(Req.columns[i].search.value.ToUpper(CultureInfo.CurrentCulture)) > -1).ToList();
                    else if (Req.columns[i].name == "fattar")
                        donendeger2 = donendeger2.ToList().Where(k => k.FATTAR.ToShortDateString() == Convert.ToDateTime(Req.columns[i].search.value).ToShortDateString()).ToList();
                    else if (Req.columns[i].name == "anacari")
                        donendeger2 = donendeger2.ToList().Where(k => k.AnaCari.MUSTERI.ToUpper(CultureInfo.CurrentCulture).IndexOf(Req.columns[i].search.value.ToUpper(CultureInfo.CurrentCulture)) > -1).ToList();
                    else if (Req.columns[i].name == "sube")
                        donendeger2 = donendeger2.ToList().Where(k => k.Sube.SUBE.ToUpper(CultureInfo.CurrentCulture).IndexOf(Req.columns[i].search.value.ToUpper(CultureInfo.CurrentCulture)) > -1).ToList();
                    else if (Req.columns[i].name == "malzeme")
                        donendeger2 = donendeger2.ToList().Where(k => k.Malzeme.MALACIK.ToUpper(CultureInfo.CurrentCulture).IndexOf(Req.columns[i].search.value.ToUpper(CultureInfo.CurrentCulture)) > -1).ToList();
                }
            }

            donendeger.recordsFiltered = donendeger2.Count;

            int Baslangic = Req.start;
            int Kactane = Req.length;
            int sinir = (Baslangic + Kactane) < donendeger2.Count ? (Baslangic + Kactane) : donendeger2.Count;

            double adettop = 0, kolitop = 0, nettop = 0;
            donendeger.json = new List<object>();
            for (int i = Baslangic; i < sinir; i++)
            {
                adettop += donendeger2[i].ADETT;
                kolitop += donendeger2[i].KOLIT;
                nettop += donendeger2[i].NETT;
                donendeger.json.Add(donendeger2[i]);
            }
            donendeger.sum1 = adettop; donendeger.sum2 = kolitop; donendeger.sum3 = nettop;

            return donendeger;
        }

        internal List<satisRaporuOzet> SatisRaporOzet(int Yil, int Ay, int Slsref, string Tur, int Gmref)
        {
            object ay = Ay == 0 ? DBNull.Value : (object)Ay;
            object slsref = Slsref == 0 ? DBNull.Value : (object)Slsref;
            return new satisRaporuOzet().GetObjects(Yil, ay, slsref, Tur, DBNull.Value);
        }

        internal List<satisRaporuKars> SatisRaporKars(int Yil, int Ay, int Slsref, string Tur, int Gmref)
        {
            object ay = Ay == 0 ? DBNull.Value : (object)Ay;
            object slsref = Slsref == 0 ? DBNull.Value : (object)Slsref;
            return new satisRaporuKars().GetObjects(Yil, ay, slsref, Tur, DBNull.Value);
        }
    }
}
