using Sultanlar.Class;
using Sultanlar.DbObj.Internet;
using Sultanlar.WebAPI.Models.Internet;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Sultanlar.DatabaseObject.Internet;
using System.Collections;
using System.Data;

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

            iadeHareketleri ih = new iadeHareketleri(iade.pkIadeID, 16, DateTime.Now, iade.Musteri.AdSoyad, "");
            ih.DoInsert();

            return Donen;
        }

        internal string IadeBasa(int IadeID)
        {
            string Donen = string.Empty;
            iadeler iade = new iadeler(IadeID).GetObject();
            iade.blAktarilmis = false;
            iade.mnToplamTutar = 0;
            iade.DoUpdate();
            IadelerQ.Delete(IadeID);

            for (int i = 0; i < iade.detaylar.Count; i++)
            {
                iade.detaylar[i].mnFiyat = 0;
                iade.detaylar[i].DoUpdate();
                IadeFiyatlarSil(iade.detaylar[i].pkIadeDetayID);
            }

            iadeHareketleri ih = new iadeHareketleri(iade.pkIadeID, 28, DateTime.Now, iade.Musteri.AdSoyad, "");
            ih.DoInsert();

            return Donen;
        }

        internal string IadeSona(int IadeID)
        {
            string Donen = string.Empty;
            iadeler iade = new iadeler(IadeID).GetObject();
            iade.blAktarilmis = false;
            iade.mnToplamTutar = -2;
            iade.DoUpdate();

            iadeler.ExecNQ("db_sp_bayiStokGuncelle1b", new ArrayList() { "GMREF" }, new[] { SqlDbType.Int }, new ArrayList() { iade.Cari.GMREF });
            iadeler.ExecNQ("db_sp_bayiStokGuncelle2b", new ArrayList() { "GMREF" }, new[] { SqlDbType.Int }, new ArrayList() { iade.Cari.GMREF });

            iadeHareketleri ih = new iadeHareketleri(iade.pkIadeID, 6, DateTime.Now, iade.Musteri.AdSoyad, "");
            ih.DoInsert();

            return Donen;
        }

        internal string IadRede(int IadeID)
        {
            string Donen = string.Empty;
            iadeler iade = new iadeler(IadeID).GetObject();

            for (int i = 0; i < iade.detaylar.Count; i++)
            {
                bayiStokRaporu stok = new bayiStokRaporu().GetObject(iade.Cari.GMREF, iade.detaylar[i].intUrunID);
                if (stok.STOKAY - iade.detaylar[i].intMiktar < 0)
                {
                    return iade.detaylar[i].intUrunID + " nolu malzemede stok eksiye düşeceği için iade iptal edilemez.";
                }
            }

            iade.blAktarilmis = false;
            iade.mnToplamTutar = -1;
            iade.DoUpdate();

            for (int i = 0; i < iade.detaylar.Count; i++)
            {
                IadeFiyatlarSil(iade.detaylar[i].pkIadeDetayID);
            }

            iadeler.ExecNQ("db_sp_bayiStokGuncelle1b", new ArrayList() { "GMREF" }, new[] { SqlDbType.Int }, new ArrayList() { iade.Cari.GMREF });
            iadeler.ExecNQ("db_sp_bayiStokGuncelle2b", new ArrayList() { "GMREF" }, new[] { SqlDbType.Int }, new ArrayList() { iade.Cari.GMREF });

            iadeHareketleri ih = new iadeHareketleri(iade.pkIadeID, 5, DateTime.Now, iade.Musteri.AdSoyad, "");
            ih.DoInsert();

            return Donen;
        }

        internal string IadeFiyatlandirildi(int IadeID)
        {
            string Donen = string.Empty;
            iadeler iade = new iadeler(IadeID).GetObject();
            if (iade.tur == 1)
            {
                iade.blAktarilmis = true;
                iade.mnToplamTutar = iade.ToplamTutar;
                iade.DoUpdate();

                iadeHareketleri ih = new iadeHareketleri(iade.pkIadeID, 2, DateTime.Now, iade.Musteri.AdSoyad, "");
                ih.DoInsert();
            }
            else
            {
                return "Hata: iade Fiyatlandırılmamış kategorisinde değil.";
            }

            return Donen;
        }

        internal string IadeOnay(int IadeID)
        {
            iadeler iade = new iadeler(IadeID).GetObject();
            iade.blAktarilmis = false;
            iade.mnToplamTutar = 0.001;
            iade.DoUpdate();
            Sultanlar.DatabaseObject.Internet.Iadeler.DoInsertCopeAt(IadeID);

            if (iade.TKSREF > 1)
            {
                iade.blAktarilmis = true;
                iade.mnToplamTutar = 0;
                iade.DoUpdate(); // onay talep yerine fiyatlandırılmamışa gelmesi için

                int bayikod = CariHesaplarTP.GetGMREFBySMREF(iade.SMREF);
                int siparisno = CariHesaplarTPEk.GetBayiSiparisNo(bayikod) + 1;
                CariHesaplarTPEk.SetBayiSiparisNo(bayikod, siparisno);

                IadelerQ.WriteQuantumNo(iade.pkIadeID, DatabaseObject.Internet.Genel.BayiSiparisnoDuzeltme(siparisno), "", iade.dtOnaylamaTarihi);

                iadeHareketleri ih = new iadeHareketleri(iade.pkIadeID, 1, DateTime.Now, iade.Musteri.AdSoyad, ""); // fiyatlandırılmamışa
                ih.DoInsert();
            }
            else
            {
                iadeHareketleri ih = new iadeHareketleri(iade.pkIadeID, 26, DateTime.Now, iade.Musteri.AdSoyad, ""); // iade onay talep edildi
                ih.DoInsert();
            }

            return "";
        }

        internal string IadeKopyala(IadeKopya ikg)
        {
            string Donen = string.Empty;

            iadeler kopyalanacak = new iadeler(ikg.IadeID).GetObject();
            for (int i = 0; i < ikg.SMREFs.Count; i++)
            {
                iadeler iade = new iadeler(kopyalanacak.intMusteriID, ikg.SMREFs[i].smref, DateTime.Now, 0, false, DateTime.Now, kopyalanacak.strAciklama, kopyalanacak.strNedenKod, kopyalanacak.strDepoKod, kopyalanacak.strDepoUY, kopyalanacak.strPartiNo, ikg.SMREFs[i].tip);
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

        internal string IadeKaydet(IadeKaydet ikg, string neden)
        {
            iadeler iadees = new iadeler(ikg.iadeid).GetObject();
            if (iadees.tur != 0)
                return "hata: bu iade değiştirilemez.";

            musteriler mus = new musteriler(Convert.ToInt32(Sifreleme.Decrypt(ikg.musteri))).GetObject();
            int musid = new musteriler().GetMusteriBySLSREF(new cariHesaplar().GetObject1(ikg.mtip, ikg.smref).SLSREF).pkMusteriID;

            iadeler iade = new iadeler(musid != 0 ? musid : mus.pkMusteriID, ikg.smref, DateTime.Now, 0, false, DateTime.Now, mus.AdSoyad + ";;;" + ikg.aciklama + ";;;", "", "", "", "", ikg.mtip);
            iade.DoInsert();
            for (int i = 0; i < ikg.detaylar.Count; i++)
            {
                iadelerDetay iadedet = new iadelerDetay(iade.pkIadeID, ikg.detaylar[i].itemref, ikg.detaylar[i].malacik, ikg.detaylar[i].miktar, 0);
                iadedet.DoInsert();
            }

            iadeHareketleri ih = new iadeHareketleri(iade.pkIadeID, 8, DateTime.Now, mus.AdSoyad, ""); // iade girildi
            ih.DoInsert();

            if (ikg.iadeid != 0) // iade güncelleniyorsa eskiyi silsin
            {
                List<iadelerDetay> silinecekler = new iadelerDetay().GetObjects(iadees.pkIadeID);
                for (int i = 0; i < silinecekler.Count; i++)
                    silinecekler[i].DoDelete();
                iadees.DoDelete();
            }

            DatabaseObject.Internet.Iadeler.SetSapDepo(neden, "", "", "", iade.pkIadeID);

            return iade.pkIadeID.ToString();
        }

        internal iadelerDetay IadeDetay(int IadeDetayID) => new iadelerDetay(IadeDetayID).GetObject();

        internal string IadeDetayGuncelle(iadelerDetay Detay)
        {
            Detay.DoUpdate();

            return "";
        }

        internal List<iadeFiyatAdet> IadeFiyatAdetler(int SMREF, int ITEMREF) => new iadeFiyatAdet().GetObjects(SMREF, ITEMREF);

        internal iadeFiyatAdet IadeFiyatAdet(int ID)
        {
            iadeFiyatAdet iade = new iadeFiyatAdet(ID).GetObject();
            return iade;
        }

        internal string IadeFiyatSil(int ID)
        {
            string Donen = string.Empty;
            iadeFiyatAdet iade = new iadeFiyatAdet(ID).GetObject();
            iade.DoDelete();
            return Donen;
        }

        internal string IadeFiyatlarSil(long IadeDetayID)
        {
            string Donen = string.Empty;
            List<iadeFiyatAdet> iadefiyatadetler = new iadeFiyatAdet().GetObjects(IadeDetayID);
            for (int i = 0; i < iadefiyatadetler.Count; i++)
            {
                iadefiyatadetler[i].DoDelete();
            }
            return Donen;
        }

        internal string IadeFiyatKaydet(long IadeDetayID, long SiparisDetayID, int Miktar)
        {
            iadeFiyatAdet iade = new iadeFiyatAdet(IadeDetayID, SiparisDetayID, Miktar);
            iade.DoInsert();
            return iade.ID.ToString();
        }

        internal string IadeFiyatDuzenle(long ID, long IadeDetayID, long SiparisDetayID, int Miktar)
        {
            iadeFiyatAdet iade = new iadeFiyatAdet(ID).GetObject();
            iade.bintIadeDetayID = IadeDetayID;
            iade.bintSiparisDetayID = SiparisDetayID;
            iade.intIadeMiktar = Miktar;
            iade.DoUpdate();
            return "";
        }
    }
}
