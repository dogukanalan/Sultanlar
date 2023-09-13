using Sultanlar.Class;
using Sultanlar.DbObj.Internet;
using Sultanlar.WebAPI.Models.Internet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class StokProvider
    {
        internal List<bayiStokRaporu> BayiStokRapor(int Slsref, int Smref)
        {
            object smref = Smref == 0 ? DBNull.Value : (object)Smref;
            return new bayiStokRaporu().GetObjects(Slsref, smref);
        }
        internal List<bayiStokTeslim> BayiStokTeslimler(int Gmref)
        {
            return new bayiStokTeslim().GetObjects(Gmref);
        }
        internal bayiStokTeslim BayiStokTeslim(int Gmref, string FatNo)
        {
            return new bayiStokTeslim().GetObject(Gmref, FatNo);
        }
        internal string SetBayiStokTeslim(int Gmref, string FatNo, int Kullanici, int Onay)
        {
            bayiStokTeslim bst = new bayiStokTeslim().GetObject(Gmref, FatNo);
            if (bst.KULLANICI != 0)
            {
                bst.SON_KULLANICI = Kullanici;
                bst.SON_TARIH = DateTime.Now;
                bst.TESLIM = Onay == 1 ? true : false;
                bst.DoUpdate();
            }
            else
            {
                bst = new bayiStokTeslim() { GMREF = Gmref, FAT_NO_MTB = FatNo, TESLIM = true, KULLANICI = Kullanici, SON_KULLANICI = Kullanici, TARIH = DateTime.Now, SON_TARIH = DateTime.Now };
                bst.DoInsert();
            }

            siparisler.ExecNQ("db_sp_bayiStokGuncelle1b", new ArrayList() { "GMREF" }, new[] { SqlDbType.Int }, new ArrayList() { Gmref });
            siparisler.ExecNQ("db_sp_bayiStokGuncelle2b", new ArrayList() { "GMREF" }, new[] { SqlDbType.Int }, new ArrayList() { Gmref });

            return "";
        }
        internal string TeslimSiparis(int Gmref, int Smref, int Tip, string FatNo, string musteri)
        {
            SiparisProvider sp = new SiparisProvider();
            List<satisRaporu> sr = new satisRaporu().GetObject(FatNo);

            SiparisKaydet skg = new SiparisKaydet();
            skg.detaylar = new List<SiparisKaydetDetay>();
            skg.ftip = 2;
            skg.mtip = Tip;
            skg.aciklama = "Nama sevk: " + FatNo;
            skg.smref = Smref;
            skg.teslim = DateTime.Now.ToShortDateString();
            skg.musteri = musteri;
            skg.siparisid = 0;

            for (int i = 0; i < sr.Count; i++)
            {
                SiparisKaydetDetay skgd = new SiparisKaydetDetay();
                skgd.itemref = sr[i].ITEMREF;
                skgd.malacik = sr[i].Malzeme.MALACIK;
                skgd.miktar = Convert.ToInt32(sr[i].ADETT);
                skgd.miktartur = "ST";

                SiparisIsks isks = sp.IsksTP(Smref, Tip, sr[i].ITEMREF, DateTime.Now);
                skgd.isk1 = isks.isk1;
                skgd.isk2 = isks.isk2;
                skgd.isk3 = isks.isk3;
                skgd.isk4 = isks.isk4;
                skgd.netkdv = Class.Math.IskontoDus(isks.fiyat, isks.isk1, isks.isk2, isks.isk3, isks.isk4, 0);
                
                if (skgd.miktar > 0)
                    skg.detaylar.Add(skgd);
            }

            int musteriid = Convert.ToInt32(Sifreleme.Decrypt(skg.musteri));
            string sipid = sp.SiparisKaydet(skg);

            if (sp.SiparisOnay(Convert.ToInt32(sipid), 0, musteriid) == string.Empty)
                SetBayiStokTeslim(Gmref, FatNo, musteriid, 1);

            return "";
        }
    }
}
