using Sultanlar.Class;
using Sultanlar.DbObj.Internet;
using Sultanlar.WebAPI.Models.Internet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class IadeProvider
    {
        internal List<iadeler> Iadeler() => new iadeler().GetObjects();

        internal iadeler Iade(int IadeID) => new iadeler(IadeID).GetObject();

        internal List<iadeler> Iadeler(int slsref, int gmref, int smref, int yil, int ay, string onay)
        {
            object Onay = onay == "1" ? true : onay == "0" ? false : (object)DBNull.Value;
            object Ay = ay == 0 ? (object)DBNull.Value : ay;
            if (slsref != 0)
                return new iadeler().GetObjectsBySLSREF(slsref, yil, Ay, Onay);
            if (gmref != 0)
                return new iadeler().GetObjectsByGMREF(gmref, yil, Ay, Onay);
            if (smref != 0)
                return new iadeler().GetObjectsBySMREF(smref, yil, Ay, Onay);

            return new iadeler().GetObjects(yil, Ay, Onay);
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
            iade.blAktarilmis = true;
            iade.DoUpdate();

            iadeHareketleri ih = new iadeHareketleri(iade.pkIadeID, 1, DateTime.Now, iade.Musteri.AdSoyad, ""); // iade onaylandı
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
