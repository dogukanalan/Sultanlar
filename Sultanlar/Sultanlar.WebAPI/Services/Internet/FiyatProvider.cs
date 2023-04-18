using Sultanlar.DbObj.Internet;
using Sultanlar.DatabaseObject.Internet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class FiyatProvider
    {
        internal List<fiyatlar> Fiyatlar() => new fiyatlar().GetObjects();

        internal List<fiyatlar> Fiyatlar(int TIP, int GMREF, int MTIP, int SMREF) => new fiyatlar().GetObjects(TIP, GMREF, MTIP, SMREF);

        internal List<fiyatlar> Fiyatlar2(int TIP, int GMREF, int MTIP, int SMREF) => new fiyatlar().GetObjectsByGmrefMtip(TIP, GMREF, MTIP, SMREF);

        internal List<fiyatlar> FiyatlarNon(int TIP, int GMREF, int MTIP, int SMREF)
        {
            List<fiyatlar> donendeger = new List<fiyatlar>();
            List<fiyatlar> fiys = new fiyatlar().GetObjects(TIP, GMREF, MTIP, SMREF);
            List<fiyatlar> hepsi = new fiyatlar().GetObjects(20, GMREF, MTIP, GMREF);
            //donendeger = fiys.Count == 0 ? hepsi : hepsi.Where(z => fiys.ToList().Any(x => x.ITEMREF != z.ITEMREF)).ToList();
            for (int i = 0; i < hepsi.Count; i++)
            {
                if (!fiys.ToList().Any(x => x.ITEMREF == hepsi[i].ITEMREF))
                {
                    hepsi[i].TIP = TIP;
                    donendeger.Add(hepsi[i]);
                }
            }
            return donendeger;
        }

        internal List<fiyatlar> FiyatlarAll(int TIP, int GMREF, int MTIP, int SMREF) => new fiyatlar().GetObjectsAll(TIP, GMREF, MTIP, SMREF);

        internal List<fiyatlar> FiyatlarAktif(int TIP, int GMREF, int MTIP, int SMREF)
        {
            List<fiyatlar> fiys = new fiyatlar().GetObjects(TIP, GMREF, MTIP, SMREF);
            List<fiyatlar> donendeger = new List<fiyatlar>();
            for (int i = 0; i < fiys.Count; i++)
            {
                if (!fiys[i].malzeme.MALACIK.EndsWith("&"))
                {
                    donendeger.Add(fiys[i]);
                }
            }
            //List<fiyatlar> donendeger = new fiyatlar().GetObjects(TIP, GMREF, MTIP, SMREF).Where(x => !x.malzeme.MALACIK.EndsWith("&")).ToList();
            return donendeger;
        }

        internal fiyatlar Fiyat(int TIP, int ITEMREF) => new fiyatlar(TIP, ITEMREF).GetObject();

        internal List<fiyatlarTp> FiyatlarTP() => new fiyatlarTp().GetObjects();

        internal List<fiyatlarTp> FiyatlarTP(int YIL, int AY, int GUN, int TIP) => new fiyatlarTp().GetObjects(YIL, AY, GUN, TIP);

        internal fiyatlarTp FiyatTP(int YIL, int AY, int TIP, int ITEMREF) => new fiyatlarTp(YIL, AY, TIP, ITEMREF).GetObject();

        internal List<fiyatlar> FiyatlarVy(int GMREF, int MTIP) => new fiyatlar().GetObjectsVY(GMREF, MTIP);

        internal List<fiyatlar> FiyatlarNonVy(int GMREF, int MTIP)
        {
            List<fiyatlar> donendeger = new List<fiyatlar>();
            List<fiyatlar> fiys = new fiyatlar().GetObjectsVY(GMREF, MTIP);
            List<fiyatlar> hepsi = new fiyatlar().GetObjects(20, GMREF, MTIP, GMREF);
            //donendeger = fiys.Count == 0 ? hepsi : hepsi.Where(z => fiys.Any(x => x.ITEMREF != z.ITEMREF)).ToList();
            for (int i = 0; i < hepsi.Count; i++)
            {
                if (!fiys.ToList().Any(x => x.ITEMREF == hepsi[i].ITEMREF))
                {
                    donendeger.Add(hepsi[i]);
                }
            }
            return donendeger;
        }

        internal List<fiyatTipleri> FiyatTipler500birlikte() => new fiyatTipleri().GetObjects500birlikte();

        internal string FiyatEkle(int TIP, int ITEMREF, string KULLANICI)
        {
            if (TIP > 5000)
            {
                fiyatTipleri ft = new fiyatTipleri(TIP).GetObject();
                FiyatTipUrun.DoInsert5000(TIP, ITEMREF, ft.GetAnaGmrefNo(), KULLANICI);
            }
            else
            {
                FiyatTipUrun ftp = new FiyatTipUrun(TIP, ITEMREF, KULLANICI);
                ftp.DoInsert();
            }

            return "";
        }

        internal string FiyatCikar(int TIP, int ITEMREF, string KULLANICI)
        {
            if (TIP > 5000)
            {
                FiyatTipUrun.DoDelete5000(TIP, ITEMREF, KULLANICI);
            }
            else
            {
                FiyatTipUrun.DoDelete(TIP, ITEMREF, KULLANICI);
            }

            return "";
        }

        internal string FiyatTipOlustur(int GMREF, int NETTOP, int SMREF, int TIP, string MUSTERI)
        {
            string donendeger = string.Empty;

            fiyatTipleri ft = new fiyatTipleri().GetObjectByGMREF(SMREF, TIP);
            if (ft.NOSU > 0)
                return "";

            if (TIP == 1)
            {
                donendeger = fiyatTipleri.DoInsert(MUSTERI, TIP, 1008700, GMREF, SMREF).ToString();
            }
            else if (TIP == 4)
            {
                donendeger = fiyatTipleri.DoInsert(MUSTERI, TIP, GMREF, SMREF, SMREF).ToString();
            }
            else if (TIP == 5)
            {
                donendeger = fiyatTipleri.DoInsert(MUSTERI, TIP, GMREF, NETTOP, SMREF).ToString();
            }

            return donendeger;
        }

        internal List<fiyatlar> Smrefad(int SMREF)
        {
            return new fiyatlar().GetObjectsSmrefad(SMREF); ;
        }
    }
}
