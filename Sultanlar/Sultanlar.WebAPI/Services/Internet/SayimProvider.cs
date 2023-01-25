using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sultanlar.Class;
using Sultanlar.DbObj.Internet;
using Sultanlar.WebAPI.Models.Internet;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class SayimProvider
    {
        internal List<sayimFisleri> Fisler(int Gmref) => new sayimFisleri().GetObjects(Gmref);
        internal List<sayimFisTurleri> FisTurleri() => new sayimFisTurleri().GetObjects();

        internal string FisEkle(SayimEkle sayim)
        {
            sayimFis sf = new sayimFis(false, sayim.uyeid, sayim.turid, 0, sayim.gmref, DateTime.Now, false, sayim.aciklama);
            sf.DoInsert();

            sayimFisleri fsl = new sayimFisleri(sayim.itemref, sayim.stok, sf.ID);
            fsl.DoInsert();

            return fsl.ID.ToString();
        }
        internal List<sayimRapor> Rapor(int Gmref) => new sayimRapor().GetObjects(Gmref);
        internal sayimFis Fis(int Id) => new sayimFis(Id).GetObject();

        internal string SayimKaydet(SayimKaydet sayim)
        {
            musteriler mus = new musteriler(Convert.ToInt32(Sifreleme.Decrypt(sayim.musteri))).GetObject();
            sayimFis sf = new sayimFis(false, mus.pkMusteriID, sayim.tur, 0, sayim.smref, DateTime.Now, false, sayim.aciklama);
            sf.DoInsert();
            for (int i = 0; i < sayim.detaylar.Count; i++)
            {
                sayimFisleri sfl = new sayimFisleri(sayim.detaylar[i].itemref, sayim.detaylar[i].miktar, sf.ID);
                sfl.DoInsert();
            }

            if (sayim.sayimid != 0) // sayim güncelleniyorsa eskiyi silsin
            {
                sayimFis esf = new sayimFis(sayim.sayimid).GetObject();
                List<sayimFisleri> silinecekler = new sayimFisleri().GetObjectsByID(esf.ID);
                for (int i = 0; i < silinecekler.Count; i++)
                    silinecekler[i].DoDelete();
                esf.DoDelete();
            }

            return sf.ID.ToString();
        }

        internal string Onay(int SayimId)
        {
            try
            {
                sayimFis sf = new sayimFis(SayimId).GetObject();
                if (sf.AP || sf.ONAYLI)
                {
                    return "Aktarılmış fiş tekrar onaylanamaz.";
                }
                else
                {
                    sf.ONAYLI = true;
                    sf.DoUpdate();
                    if (sf.TUR_ID == 1)
                    {
                        List<sayimEksikFazlaFisleri> sef = new sayimEksikFazlaFisleri().GetObjects(true, sf.ID);
                        List<sayimEksikFazlaFisleri> sef1 = new sayimEksikFazlaFisleri().GetObjects(false, sf.ID);

                        sayimFis yeni = new sayimFis(true, sf.UYE_ID, 2, sf.ID, sf.GMREF, DateTime.Now, true, sf.ACIKLAMA);
                        if (sef.Count > 0)
                            yeni.DoInsert();
                        sayimFis yeni1 = new sayimFis(true, sf.UYE_ID, 3, sf.ID, sf.GMREF, DateTime.Now, true, sf.ACIKLAMA);
                        if (sef1.Count > 0)
                            yeni1.DoInsert();

                        for (int i = 0; i < sef.Count; i++)
                        {
                            sayimFisleri yenidetay = new sayimFisleri(sef[i].ITEMREF, sef[i].SESF, yeni.ID);
                            yenidetay.DoInsert();
                        }
                        for (int i = 0; i < sef1.Count; i++)
                        {
                            sayimFisleri yenidetay = new sayimFisleri(sef1[i].ITEMREF, sef1[i].SESF, yeni1.ID);
                            yenidetay.DoInsert();
                        }
                        sf.AP = true;
                        sf.DoUpdate();
                    }
                    return "";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        internal string Sil(int SayimId)
        {
            try
            {
                sayimFis sf = new sayimFis(SayimId).GetObject();
                if (sf.AP || sf.ONAYLI)
                {
                    return "Aktarılmış fiş silinemez.";
                }
                else
                {
                    List<sayimFisleri> silinecekler = new sayimFisleri().GetObjectsByID(sf.ID);
                    for (int i = 0; i < silinecekler.Count; i++)
                    {
                        new sayimFisleri(silinecekler[i].ID).GetObject().DoDelete();
                        silinecekler[i].DoDelete();
                    }
                    sf.DoDelete();
                    return "";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
