using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sultanlar.Class;
using Sultanlar.DbObj.Internet;
using Sultanlar.WebAPI.Models.Internet;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class HizmetBedeliProvider
    {
        internal List<hizmetBedelleri> HizmetBedelleri() => new hizmetBedelleri().GetObjects();

        internal hizmetBedelleri HizmetBedeli(int HizmetBedeliID) => new hizmetBedelleri(HizmetBedeliID).GetObject();

        internal List<hizmetBedelleri> HizmetBedelleri(int slsref, int gmref, int smref, int yil, int ay)
        {
            object Ay = ay == 0 ? (object)DBNull.Value : ay;
            if (slsref != 0)
                return new hizmetBedelleri().GetObjectsBySLSREF(slsref, yil, Ay);
            if (gmref != 0)
                return new hizmetBedelleri().GetObjectsByGMREF(gmref, yil, Ay);
            if (smref != 0)
                return new hizmetBedelleri().GetObjectsBySMREF(smref, yil, Ay);

            return new hizmetBedelleri().GetObjects();
        }

        internal string HizmetBedeliKaydet(HizmetBedeliKaydet hbk)
        {
            musteriler mus = new musteriler(Convert.ToInt32(Sifreleme.Decrypt(hbk.musteri))).GetObject();
            hizmetBedelleri hb = new hizmetBedelleri(mus.pkMusteriID, hbk.smref, hbk.anlasmabedeladid, hbk.ay, hbk.yil, hbk.faturano, Convert.ToDateTime(hbk.faturatarih), 
                Convert.ToDecimal(hbk.tahbedel), Convert.ToDecimal(hbk.yegbedel), 0, hbk.aciklama, "", "", "", hbk.mudurbutcesi, hbk.elemanbutcesi, Convert.ToBoolean(hbk.kapamaetki));

            hb.DoInsert();

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
