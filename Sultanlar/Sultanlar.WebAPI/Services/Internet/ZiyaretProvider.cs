using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sultanlar.DbObj.Internet;
using Sultanlar.WebAPI.Models.Internet;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class ZiyaretProvider
    {
        internal List<ziyaretler> Ziyaretler() => new ziyaretler().GetObjects(DateTime.Now.Year, (object)DBNull.Value);

        internal List<ziyaretler> Ziyaretler(int slsref, int gmref, int smref, int mtip, int yil, int ay)
        {
            object Ay = ay == 0 ? (object)DBNull.Value : ay;
            if (smref != 0)
                return new ziyaretler().GetObjectsBySMREF(slsref, mtip, smref, yil, Ay);
            else if (gmref != 0)
                return new ziyaretler().GetObjectsByGMREF(slsref, gmref, yil, Ay);
            else if (slsref != 0)
                return new ziyaretler().GetObjectsBySLSREF(slsref, yil, Ay);
            else
                return new ziyaretler().GetObjects(yil, Ay);
        }

        internal ziyaretler Ziyaret(int Tip, int Smref, int Slsref, DateTime Zaman) => new ziyaretler(Tip, Smref, Slsref, Zaman).GetObject();

        internal string ZiyaretEkle(Ziyaret ziyaret)
        {
            ziyaretler ziy = new ziyaretler(ziyaret.MTIP, ziyaret.RUT_TUR, ziyaret.RUT_ID, ziyaret.GMREF, ziyaret.SMREF, ziyaret.SLSREF, ziyaret.BARKOD, Convert.ToDateTime(ziyaret.ZIY_BAS_TAR), Convert.ToDateTime(ziyaret.ZIY_BIT_TAR), ziyaret.ZIY_NDN_ID, ziyaret.ZIY_KONUM, ziyaret.ZIY_KONUM_ADRES, ziyaret.ZIY_KONUM_CIKIS, ziyaret.ZIY_KONUM_ADRES_CIKIS, ziyaret.FARK_KNM_ZIY, new byte[] { }, ziyaret.ZIY_NOTLARI, ziyaret.ZIY_SIP, ziyaret.ZIY_AKT, ziyaret.ZIY_IAD, ziyaret.ZIY_TAH);
            ziy.DoInsert();
            return "";
        }

        internal string ZiyaretDuzelt(Ziyaret ziyaret)
        {
            ziyaretler ziy = new ziyaretler(ziyaret.MTIP, ziyaret.SMREF, ziyaret.SLSREF, Convert.ToDateTime(ziyaret.ZIY_BAS_TAR)).GetObject();
            ziy.ZIY_BIT_TAR = Convert.ToDateTime(ziyaret.ZIY_BIT_TAR);
            ziy.ZIY_NDN_ID = ziyaret.ZIY_NDN_ID;
            ziy.ZIY_KONUM = ziyaret.ZIY_KONUM;
            ziy.ZIY_KONUM_ADRES = ziyaret.ZIY_KONUM_ADRES;
            ziy.ZIY_KONUM_CIKIS = ziyaret.ZIY_KONUM_CIKIS;
            ziy.ZIY_KONUM_ADRES_CIKIS = ziyaret.ZIY_KONUM_ADRES_CIKIS;
            ziy.FARK_KNM_ZIY = ziyaret.FARK_KNM_ZIY;
            ziy.ZIY_NOTLARI = ziyaret.ZIY_NOTLARI;
            ziy.DoUpdate();
            return "";
        }

        internal string ZiyaretSil(ZiyaretGet ziyaret)
        {
            ziyaretler ziy = new ziyaretler(ziyaret.Tip, ziyaret.Smref, ziyaret.Slsref, Convert.ToDateTime(ziyaret.Zaman)).GetObject();
            ziy.DoDelete();
            return "";
        }

        internal List<ziyaretSonlandirmaSebepleri> Sonlandirma() => new ziyaretSonlandirmaSebepleri().GetObjects();
    }
}
