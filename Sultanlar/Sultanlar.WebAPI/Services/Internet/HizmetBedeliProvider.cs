using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Sultanlar.Class;
using Sultanlar.DbObj.Internet;
using Sultanlar.WebAPI.Models.Internet;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class HizmetBedeliProvider
    {
        internal List<hizmetBedelleri> HizmetBedelleri(int yil, int Ay) => new hizmetBedelleri().GetObjects(yil, Ay);

        internal hizmetBedelleri HizmetBedeli(int HizmetBedeliID) => new hizmetBedelleri(HizmetBedeliID).GetObject();

        internal DtAjaxResponse HizmetBedelleri(HizmetBedeliGet hget)
        {
            DtAjaxResponse donendeger = new DtAjaxResponse();
            List<hizmetBedelleri> donendeger2 = new List<hizmetBedelleri>();

            object Ay = hget.ay == 0 ? (object)DBNull.Value : hget.ay;
            if (hget.smref != 0)
                donendeger2 = new hizmetBedelleri().GetObjectsBySMREF(hget.smref, hget.yil, Ay);
            else if (hget.gmref != 0)
                donendeger2 = new hizmetBedelleri().GetObjectsByGMREF(hget.gmref, hget.yil, Ay);
            else if (hget.slsref != 0)
                donendeger2 = new hizmetBedelleri().GetObjectsBySLSREF(hget.slsref, hget.yil, Ay);
            else
                donendeger2 = new hizmetBedelleri().GetObjects(hget.yil, Ay);

            donendeger.recordsTotal = donendeger2.Count;
            if (hget.search.value != "")
            {
                donendeger2 = donendeger2.ToList().Where(k =>
                    k.Cari.MUSTERI.ToUpper(CultureInfo.CurrentCulture).IndexOf(hget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.Cari.SUBE.ToUpper(CultureInfo.CurrentCulture).IndexOf(hget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.Musteri.AdSoyad.ToUpper(CultureInfo.CurrentCulture).IndexOf(hget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.strAciklama1.ToUpper(CultureInfo.CurrentCulture).IndexOf(hget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.strAciklama2.ToUpper(CultureInfo.CurrentCulture).IndexOf(hget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.strAciklama3.ToUpper(CultureInfo.CurrentCulture).IndexOf(hget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.strAciklama4.ToUpper(CultureInfo.CurrentCulture).IndexOf(hget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.strFaturaNo.ToUpper(CultureInfo.CurrentCulture).IndexOf(hget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1
                ).ToList();
            }
            donendeger.recordsFiltered = donendeger2.Count;

            int Baslangic = hget.start;
            int Kactane = hget.length;
            int sinir = (Baslangic + Kactane) < donendeger2.Count ? (Baslangic + Kactane) : donendeger2.Count;

            donendeger.json = new List<object>();
            for (int i = Baslangic; i < sinir; i++)
            {
                donendeger.json.Add(donendeger2[i]);
            }

            return donendeger;
        }

        internal string HizmetBedeliKaydet(HizmetBedeliKaydet hbk)
        {
            musteriler mus = new musteriler(Convert.ToInt32(Sifreleme.Decrypt(hbk.musteri))).GetObject();

            hizmetBedelleri hb = new hizmetBedelleri(mus.pkMusteriID, hbk.smref, hbk.anlasmabedeladid, hbk.ay, hbk.yil, hbk.faturano, Convert.ToDateTime(hbk.faturatarih),
                Convert.ToDecimal(hbk.tahbedel), Convert.ToDecimal(hbk.yegbedel), 0, hbk.aciklama, "", "", "", hbk.mudurbutcesi, hbk.elemanbutcesi, Convert.ToBoolean(hbk.kapamaetki));

            if (hbk.id > 0)
            {
                hb.pkID = hbk.id;
                hb.DoUpdate();
            }
            else
            {
                hb.DoInsert();
            }

            return string.Empty;
        }

        internal string HizmetBedeliSil(int HizmetBedeliID)
        {
            string Donen = string.Empty;
            hizmetBedelleri hb = new hizmetBedelleri(HizmetBedeliID).GetObject();
            hb.DoDelete();
            return Donen;
        }
    }
}
