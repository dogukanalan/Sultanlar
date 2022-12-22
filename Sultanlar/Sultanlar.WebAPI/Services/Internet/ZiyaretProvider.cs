﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Sultanlar.DbObj.Internet;
using Sultanlar.WebAPI.Models.Internet;
using System.Linq.Dynamic.Core;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class ZiyaretProvider
    {
        internal List<ziyaretler> Ziyaretler() => new ziyaretler().GetObjects(DateTime.Now.Year, (object)DBNull.Value);

        internal DtAjaxResponse Ziyaretler(ZiyaretsGet zget)
        {
            DtAjaxResponse donendeger = new DtAjaxResponse();
            List<ziyaretler> donendeger2 = new List<ziyaretler>();

            object Ay = zget.Ay == 0 ? (object)DBNull.Value : zget.Ay;
            if (zget.Smref != 0)
                donendeger2 = new ziyaretler().GetObjectsBySMREF(zget.Slsref, zget.Tip, zget.Smref, zget.Yil, Ay);
            else if (zget.Gmref != 0)
                donendeger2 = new ziyaretler().GetObjectsByGMREF(zget.Slsref, zget.Gmref, zget.Yil, Ay);
            else if (zget.Slsref != 0)
                donendeger2 = new ziyaretler().GetObjectsBySLSREF(zget.Slsref, zget.Yil, Ay);
            else
                donendeger2 = new ziyaretler().GetObjects(zget.Yil, Ay);

            donendeger.recordsTotal = donendeger2.Count;
            if (zget.search.value != "")
            {
                donendeger2 = donendeger2.ToList().Where(k =>
                    k.Cari.MUSTERI.ToUpper(CultureInfo.CurrentCulture).IndexOf(zget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1
                ).ToList();
            }
            donendeger.recordsFiltered = donendeger2.Count;

            for (int i = 0; i < zget.columns.Count; i++)
                if (i == zget.order[0].column)
                    donendeger2 = donendeger2.AsQueryable().OrderBy(zget.columns[i].name + " " + zget.order[0].dir).ToList();

            int Baslangic = zget.start;
            int Kactane = zget.length;
            int sinir = (Baslangic + Kactane) < donendeger2.Count ? (Baslangic + Kactane) : donendeger2.Count;

            donendeger.json = new List<object>();
            for (int i = Baslangic; i < sinir; i++)
            {
                donendeger.json.Add(donendeger2[i]);
            }

            return donendeger;
        }

        internal ziyaretler Ziyaret(ZiyaretGet ziyaret) => new ziyaretler().GetObjectByBarkod(ziyaret.Barkod);

        internal Ziyaret ZiyaretEkle(Ziyaret ziyaret)
        {
            string id = ziyaret.SLSREF.ToString() + ziyaret.GMREF.ToString() + ziyaret.SMREF.ToString() + "." + DateTime.Now.ToString().Replace(" ", ".");
            if (ziyaret.RUT_TUR == 2)
            {
                ziyaret.RUT_ID = id;
            }
            ziyaret.BARKOD = id;

            ziyaretler ziy = new ziyaretler(ziyaret.MTIP, ziyaret.RUT_TUR, ziyaret.RUT_ID, ziyaret.GMREF, ziyaret.SMREF, ziyaret.SLSREF, ziyaret.BARKOD, 
                DateTime.Now, DateTime.Now, //Convert.ToDateTime(ziyaret.ZIY_BAS_TAR), Convert.ToDateTime(ziyaret.ZIY_BIT_TAR), 
                ziyaret.ZIY_NDN_ID, ziyaret.ZIY_KONUM, ziyaret.ZIY_KONUM_ADRES, ziyaret.ZIY_KONUM_CIKIS, ziyaret.ZIY_KONUM_ADRES_CIKIS, ziyaret.FARK_KNM_ZIY, new byte[] { }, ziyaret.ZIY_NOTLARI, ziyaret.ZIY_SIP, ziyaret.ZIY_AKT, ziyaret.ZIY_IAD, ziyaret.ZIY_TAH, ziyaret.YOL);
            ziy.DoInsert();

            return ziyaret;
        }

        internal string ZiyaretDuzelt(Ziyaret ziyaret)
        {
            ziyaretler ziy = new ziyaretler().GetObjectByBarkod(ziyaret.BARKOD);

            /*if (ziyaret.RUT_TUR == 2)
            {
                ziy = new ziyaretler().GetObjectByRutID(ziyaret.RUT_ID);
            }
            else
            {
                ziy = new ziyaretler(ziyaret.MTIP, ziyaret.SMREF, ziyaret.SLSREF, Convert.ToDateTime(ziyaret.ZIY_BAS_TAR)).GetObject();
            }*/

            ziy.ZIY_BIT_TAR = DateTime.Now; //Convert.ToDateTime(ziyaret.ZIY_BIT_TAR);
            ziy.ZIY_NDN_ID = ziyaret.ZIY_NDN_ID;
            ziy.ZIY_KONUM = ziyaret.ZIY_KONUM;
            ziy.ZIY_KONUM_ADRES = ziyaret.ZIY_KONUM_ADRES;
            ziy.ZIY_KONUM_CIKIS = ziyaret.ZIY_KONUM_CIKIS;
            ziy.ZIY_KONUM_ADRES_CIKIS = ziyaret.ZIY_KONUM_ADRES_CIKIS;
            ziy.FARK_KNM_ZIY = ziyaret.FARK_KNM_ZIY;
            ziy.ZIY_NOTLARI = ziyaret.ZIY_NOTLARI;
            ziy.YOL = ziyaret.YOL;
            ziy.DoUpdate();
            return "";
        }

        internal string ZiyaretSil(ZiyaretGet ziyaret)
        {
            ziyaretler ziy = new ziyaretler().GetObjectByBarkod(ziyaret.Barkod);
            if (ziy.varyok || ziy.resim)
            {
                return "Ziyaret üzerinde işlem yapılmış. İptal edilemez.";
            }
            //ziyaretler ziy = new ziyaretler(ziyaret.Tip, ziyaret.Smref, ziyaret.Slsref, Convert.ToDateTime(ziyaret.Zaman)).GetObject();
            ziy.DoDelete();
            return "";
        }

        internal List<ziyaretSonlandirmaSebepleri> Sonlandirma() => new ziyaretSonlandirmaSebepleri().GetObjects();

        internal string VaryokEkle(ZiyaretVaryok varyok)
        {
            ziyaretler ziy = new ziyaretler().GetObjectByBarkod(varyok.barkod);
            if (ziy.ZIY_BAS_TAR != ziy.ZIY_BIT_TAR)
                return "ziyaret bitmis";

            ziyaretvaryok onceki = new ziyaretvaryok().GetObject(varyok.barkod);
            if (onceki.pkID > 0)
                onceki.DoDelete();

            ziyaretvaryok vy = new ziyaretvaryok();
            vy.BARKOD = varyok.barkod;
            vy.FIYAT_TIP = varyok.tip;
            vy.TARIH = DateTime.Now;
            vy.DoInsert();

            SiparisKaydet skg = new SiparisKaydet();
            skg.detaylar = new List<SiparisKaydetDetay>();

            for (int i = 0; i < varyok.detays.Count; i++)
            {
                ziyaretvaryokdetay vyd = new ziyaretvaryokdetay();
                vyd.VARYOK_ID = vy.pkID;
                vyd.ITEMREF = varyok.detays[i].itemref;
                vyd.VARYOK = varyok.detays[i].varyok;
                vyd.DEPO = varyok.detays[i].depo;
                vyd.RAF = varyok.detays[i].raf;
                vyd.RAF_FIYAT = varyok.detays[i].raffiyat;
                vyd.SKT = varyok.detays[i].skt;
                vyd.SIPARIS = varyok.detays[i].siparis;
                if (varyok.detays[i].isaret)
                    vyd.DoInsert();
                else
                    vyd.DoInsertNull();

                SiparisKaydetDetay skgd = new SiparisKaydetDetay();
                skgd.itemref = vyd.ITEMREF;
                skgd.malacik = new malzemeler(vyd.ITEMREF).GetObject().MALACIK;
                skgd.miktar = vyd.SIPARIS;
                skgd.miktartur = "ST";
                skgd.netkdv = new fiyatlar(vy.FIYAT_TIP, vyd.ITEMREF).NETKDV;
                if (skgd.miktar > 0)
                    skg.detaylar.Add(skgd);
            }

            string eposta = new musteriler().GetMusteriBySLSREF(Convert.ToInt32(vy.Ziyaret.AnaCari.SATKOD)).strEposta;
            new EpostaProvider().EpostaGonder("Sultanlar", eposta, "Var/Yok Liste (" + vy.Ziyaret.Satici.SATTEM + ")", vy.Ziyaret.Cari.MUSTERI + " carisine bir varyok listesi gönderilmiştir.<br><br><a href='" + "https://www.ittihadteknoloji.com.tr/site/Ziyaret/Varyok?ziyaretid=" + vy.Ziyaret.BARKOD + "&smref=" + vy.Ziyaret.SMREF + "&mtip=" + vy.Ziyaret.MTIP + "&incele=true'>Görüntülemek için tıklayınız");

            skg.ftip = Convert.ToInt16(vy.FIYAT_TIP);
            skg.aciklama = "Ziy.V/Y: " + varyok.barkod;
            skg.smref = vy.Ziyaret.MTIP == 1 ? vy.Ziyaret.SMREF : vy.Ziyaret.GMREF;
            skg.teslim = DateTime.Now.ToShortDateString();
            skg.musteri = varyok.musteri;
            skg.siparisid = 0;

            if (varyok.tip != 0 && varyok.tip < 1000 && skg.detaylar.Count > 0)
            {
                SiparisProvider sp = new SiparisProvider();
                sp.SiparisKaydet(skg);
            }

            return "";
        }

        internal ziyaretvaryok VaryokGetir(string BARKOD) => new ziyaretvaryok().GetObject(BARKOD);

        internal string VaryokSil(string BARKOD)
        {
            new ziyaretvaryok().GetObject(BARKOD).DoDelete();
            return "";
        }
    }
}
