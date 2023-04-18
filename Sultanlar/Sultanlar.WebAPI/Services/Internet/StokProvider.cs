using Sultanlar.DbObj.Internet;
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
    }
}
