using Sultanlar.Class;
using Sultanlar.DbObj.Internet;
using Sultanlar.WebAPI.Models.Internet;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class AnlasmaProvider
    {
        internal List<anlasmaBedelAdlari> AnlasmaBedelAdlari() => new anlasmaBedelAdlari().GetObjects();

        internal anlasmaBedelAdlari AnlasmaBedelAdlari(int ID) => new anlasmaBedelAdlari(ID).GetObject();

        internal anlasmalar Anlasma(int ID) => new anlasmalar(ID).GetObject();

        internal List<anlasmalar> Anlasmalar() => new anlasmalar().GetObjects();

        internal DtAjaxResponse Anlasmalar(AnlasmaGet aget)
        {
            DtAjaxResponse donendeger = new DtAjaxResponse();
            List<anlasmalar> donendeger2 = new List<anlasmalar>();

            object Onay = aget.onay == "1" ? 1 : aget.onay == "0" ? 0 : (object)DBNull.Value;
            object Ay = aget.ay == 0 ? (object)DBNull.Value : aget.ay;
            if (aget.smref != 0)
                donendeger2 = new anlasmalar().GetObjectsBySMREF(aget.smref, aget.tip, aget.yil, Ay, Onay);
            else if (aget.gmref != 0)
                donendeger2 = new anlasmalar().GetObjectsByGMREF(aget.gmref, aget.yil, Ay, Onay);
            else if (aget.slsref != 0)
                donendeger2 = new anlasmalar().GetObjectsBySLSREF(aget.slsref, aget.yil, Ay, Onay);
            else
                donendeger2 = new anlasmalar().GetObjects(aget.yil, Ay, Onay);

            donendeger.recordsTotal = donendeger2.Count;
            if (aget.search.value != "")
            {
                donendeger2 = donendeger2.ToList().Where(k =>
                    k.Cari.MUSTERI.ToUpper(CultureInfo.CurrentCulture).IndexOf(aget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.Cari.SUBE.ToUpper(CultureInfo.CurrentCulture).IndexOf(aget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.Musteri.AdSoyad.ToUpper(CultureInfo.CurrentCulture).IndexOf(aget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.strAciklama1.ToUpper(CultureInfo.CurrentCulture).IndexOf(aget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1
                ).ToList();
            }
            donendeger.recordsFiltered = donendeger2.Count;

            int Baslangic = aget.start;
            int Kactane = aget.length;
            int sinir = (Baslangic + Kactane) < donendeger2.Count ? (Baslangic + Kactane) : donendeger2.Count;

            donendeger.json = new List<object>();
            for (int i = Baslangic; i < sinir; i++)
            {
                donendeger.json.Add(donendeger2[i]);
            }

            return donendeger;
        }

        internal List<anlasmalar> Anlasmalar(int yil, int ay, int smref, string tip)
        {
            return new anlasmalar().GetObjectsByMusteri(yil, ay, smref, tip);
        }

        internal string AnlasmaKaydet(AnlasmaKaydet akg)
        {
            musteriler mus = new musteriler(Convert.ToInt32(Sifreleme.Decrypt(akg.musteri))).GetObject();

            akg.aciklama = akg.aciklama + " (Anlaşma onay talep tarihi:" + DateTime.Now.ToShortDateString() + ")";
            anlasmalar anlasma = new anlasmalar(akg.smref, mus.pkMusteriID, Convert.ToDateTime(akg.baslangic), Convert.ToDateTime(akg.bitis), akg.vadekgt, akg.vadenf, akg.skukgt, akg.skunf, akg.fataltkgt, akg.cirokgt, akg.ciro3kgt, akg.ciro6kgt, akg.ciro12kgt, akg.cirofataltkgt, akg.anldisikgt, akg.topcirokgt, akg.fataltnf, akg.cironf, akg.ciro3nf, akg.ciro6nf, akg.ciro12nf, akg.cirofataltnf, akg.anldisinf, akg.topcironf, akg.aciklama, akg.aciklama2, "", akg.subesay.ToString(), 0);
            anlasma.DoInsert();

            anlasmaBedeller ab = new anlasmaBedeller();
            bool kgtgirdi = false;
            int bedelid = 0;
            for (int i = 0; i < akg.bedeller.Count; i++)
            {
                if (akg.bedeller[i].tur == "kgt")
                {
                    bedelid = akg.bedeller[i].id;
                    ab = new anlasmaBedeller(anlasma.pkID, akg.bedeller[i].id, akg.bedeller[i].adet, akg.bedeller[i].bedel, 0, 0, 0, 0, "", "", "", "");
                    ab.DoInsert();
                    kgtgirdi = true;
                }
                else
                {
                    if (kgtgirdi && bedelid == akg.bedeller[i].id)
                    {
                        ab.intYEGAdet = akg.bedeller[i].adet;
                        ab.mnYEGBedel = akg.bedeller[i].bedel;
                        ab.DoUpdate();
                    }
                    else
                    {
                        ab = new anlasmaBedeller(anlasma.pkID, akg.bedeller[i].id, 0, 0, 0, akg.bedeller[i].adet, akg.bedeller[i].bedel, 0, "", "", "", "");
                        ab.DoInsert();
                    }
                    kgtgirdi = false;
                }
            }

            return anlasma.pkID.ToString();
        }

        internal string AnlasmaKopyala(AnlasmaKopya akg)
        {
            string Donen = string.Empty;

            musteriler mus = new musteriler(Convert.ToInt32(Sifreleme.Decrypt(akg.musteri))).GetObject();
            anlasmalar kopyalanacak = new anlasmalar(akg.id).GetObject();
            for (int i = 0; i < akg.SMREFs.Count; i++)
            {
                cariHesaplar cari = new cariHesaplar().GetObject1(akg.SMREFs[i].tip, akg.SMREFs[i].smref);
                anlasmalar anl = new anlasmalar(
                    akg.SMREFs[i].smref,
                    mus.pkMusteriID,
                    Convert.ToDateTime(akg.baslangic),
                    Convert.ToDateTime(akg.bitis),
                    kopyalanacak.intVadeTAH, 
                    kopyalanacak.intVadeYEG, 
                    kopyalanacak.intListSKUTAH, 
                    kopyalanacak.intListSKUYEG, 
                    kopyalanacak.flTAHIsk, 
                    kopyalanacak.flTAHCiro, 
                    kopyalanacak.flTAHCiro3, 
                    kopyalanacak.flTAHCiro6, 
                    kopyalanacak.flTAHCiro12, 
                    kopyalanacak.flTAHCiroIsk, 
                    kopyalanacak.mnTAHAnlasmaDisiBedeller, 
                    kopyalanacak.mnTAHToplamCiro, 
                    kopyalanacak.flYEGIsk, 
                    kopyalanacak.flYEGCiro, 
                    kopyalanacak.flYEGCiro3, 
                    kopyalanacak.flYEGCiro6, 
                    kopyalanacak.flYEGCiro12, 
                    kopyalanacak.flYEGCiroIsk, 
                    kopyalanacak.mnYEGAnlasmaDisiBedeller, 
                    kopyalanacak.mnYEGToplamCiro, 
                    akg.aciklama, 
                    akg.SMREFs[i].tip == 1 ? "2" : "1", 
                    kopyalanacak.strAciklama3, 
                    "0", 
                    0);
                anl.DoInsert();

                for (int j = 0; j < kopyalanacak.bedeller.Count; j++)
                {
                    anlasmaBedeller bed = new anlasmaBedeller(kopyalanacak.bedeller[j].pkID).GetObject();
                    anlasmaBedeller bedel = new anlasmaBedeller(anl.pkID, bed.intAnlasmaBedelAdID, bed.intTAHAdet, bed.mnTAHBedel, bed.flTAHIsk, bed.intYEGAdet, bed.mnYEGBedel, bed.flYEGIsk, bed.strAciklama1, bed.strAciklama2, bed.strAciklama3, bed.strAciklama4);
                    bedel.DoInsert();
                }
            }

            return Donen;
        }
    }
}
