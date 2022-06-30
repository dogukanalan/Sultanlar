using Sultanlar.Class;
using Sultanlar.DbObj.Internet;
using Sultanlar.WebAPI.Models.Internet;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class IadeProvider
    {
        internal List<iadeler> Iadeler() => new iadeler().GetObjects();

        internal iadeler Iade(int IadeID) => new iadeler(IadeID).GetObject();

        internal DtAjaxResponse Iadeler(IadeGet iget)
        {
            DtAjaxResponse donendeger = new DtAjaxResponse();
            List<iadeler> donendeger2 = new List<iadeler>();

            object Onay = iget.onay == "1" ? true : iget.onay == "0" ? false : (object)DBNull.Value;
            object Ay = iget.ay == 0 ? (object)DBNull.Value : iget.ay;
            if (iget.smref != 0)
                donendeger2 = new iadeler().GetObjectsBySMREF(iget.smref, iget.yil, Ay, Onay);
            else if (iget.gmref != 0)
                donendeger2 = new iadeler().GetObjectsByGMREF(iget.gmref, iget.yil, Ay, Onay);
            else if (iget.slsref != 0)
                donendeger2 = new iadeler().GetObjectsBySLSREF(iget.slsref, iget.yil, Ay, Onay);
            else
                donendeger2 = new iadeler().GetObjects(iget.yil, Ay, Onay);

            donendeger.recordsTotal = donendeger2.Count;
            if (iget.search.value != "")
            {
                donendeger2 = donendeger2.ToList().Where(k =>
                    k.Cari.MUSTERI.ToUpper(CultureInfo.CurrentCulture).IndexOf(iget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.Cari.SUBE.ToUpper(CultureInfo.CurrentCulture).IndexOf(iget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.Musteri.AdSoyad.ToUpper(CultureInfo.CurrentCulture).IndexOf(iget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.strAciklama.ToUpper(CultureInfo.CurrentCulture).IndexOf(iget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.strDepoKod.ToUpper(CultureInfo.CurrentCulture).IndexOf(iget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.strDepoUY.ToUpper(CultureInfo.CurrentCulture).IndexOf(iget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.strNedenKod.ToUpper(CultureInfo.CurrentCulture).IndexOf(iget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.strPartiNo.ToUpper(CultureInfo.CurrentCulture).IndexOf(iget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1
                ).ToList();
            }
            donendeger.recordsFiltered = donendeger2.Count;

            for (int i = 0; i < iget.columns.Count; i++)
                if (i == iget.order[0].column)
                    donendeger2 = donendeger2.AsQueryable().OrderBy(iget.columns[i].name + " " + iget.order[0].dir).ToList();

            int Baslangic = iget.start;
            int Kactane = iget.length;
            int sinir = (Baslangic + Kactane) < donendeger2.Count ? (Baslangic + Kactane) : donendeger2.Count;

            donendeger.json = new List<object>();
            for (int i = Baslangic; i < sinir; i++)
            {
                donendeger.json.Add(donendeger2[i]);
            }

            return donendeger;
        }

        internal string IadeSil(int IadeID)
        {
            string Donen = string.Empty;
            iadeler iade = new iadeler(IadeID).GetObject();
            List<iadelerDetay> silinecekler = new iadelerDetay().GetObjects(iade.pkIadeID);
            for (int i = 0; i < silinecekler.Count; i++)
                silinecekler[i].DoDelete();
            iade.DoDelete();
            return Donen;
        }

        internal string IadeOnay(int IadeID)
        {
            iadeler iade = new iadeler(IadeID).GetObject();
            iade.blAktarilmis = false;
            iade.mnToplamTutar = 0.001;
            iade.DoUpdate();
            Sultanlar.DatabaseObject.Internet.Iadeler.DoInsertCopeAt(IadeID);

            iadeHareketleri ih = new iadeHareketleri(iade.pkIadeID, 26, DateTime.Now, iade.Musteri.AdSoyad, ""); // iade onay talep edildi
            ih.DoInsert();

            return "";
        }

        internal string IadeKopyala(IadeKopya ikg)
        {
            string Donen = string.Empty;

            iadeler kopyalanacak = new iadeler(ikg.IadeID).GetObject();
            for (int i = 0; i < ikg.SMREFs.Count; i++)
            {
                iadeler iade = new iadeler(kopyalanacak.intMusteriID, ikg.SMREFs[i].smref, DateTime.Now, kopyalanacak.mnToplamTutar, false, DateTime.Now, kopyalanacak.strAciklama, kopyalanacak.strNedenKod, kopyalanacak.strDepoKod, kopyalanacak.strDepoUY, kopyalanacak.strPartiNo);
                iade.DoInsert();
                for (int j = 0; j < kopyalanacak.detaylar.Count; j++)
                {
                    iadelerDetay iadedet = new iadelerDetay(iade.pkIadeID, kopyalanacak.detaylar[j].intUrunID, kopyalanacak.detaylar[j].strUrunAdi, kopyalanacak.detaylar[j].intMiktar, kopyalanacak.detaylar[j].mnFiyat);
                    iadedet.DoInsert();
                }
            }

            iadeHareketleri ih = new iadeHareketleri(kopyalanacak.pkIadeID, 8, DateTime.Now, kopyalanacak.Musteri.AdSoyad, "kopyalandı"); // iade girildi
            ih.DoInsert();

            return Donen;
        }

        internal string IadeKaydet(IadeKaydet ikg)
        {
            if (ikg.iadeid != 0) // iade güncelleniyorsa eskiyi silsin
            {
                iadeler iadees = new iadeler(ikg.iadeid).GetObject();
                for (int i = 0; i < iadees.detaylar.Count; i++)
                    iadees.detaylar[i].DoDelete();
                iadees.DoDelete();
            }

            musteriler mus = new musteriler(Convert.ToInt32(Sifreleme.Decrypt(ikg.musteri))).GetObject();
            int musid = new musteriler().GetMusteriBySLSREF(new cariHesaplar(ikg.smref).GetObject().SLSREF).pkMusteriID;

            iadeler iade = new iadeler(musid != 0 ? musid : mus.pkMusteriID, ikg.smref, DateTime.Now, 0, false, DateTime.Now, mus.AdSoyad + ";;;" + ikg.aciklama + ";;;", "", "", "", "");
            iade.DoInsert();
            for (int i = 0; i < ikg.detaylar.Count; i++)
            {
                iadelerDetay iadedet = new iadelerDetay(iade.pkIadeID, ikg.detaylar[i].itemref, ikg.detaylar[i].malacik, ikg.detaylar[i].miktar, 0);
                iadedet.DoInsert();
            }

            iadeHareketleri ih = new iadeHareketleri(iade.pkIadeID, 8, DateTime.Now, mus.AdSoyad, ""); // iade girildi
            ih.DoInsert();

            return iade.pkIadeID.ToString();
        }
    }
}
