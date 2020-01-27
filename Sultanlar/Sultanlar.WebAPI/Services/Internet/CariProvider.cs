using Sultanlar.DbObj.Internet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class CariProvider
    {
        internal List<cariHesaplar> Cariler(int SLSREF) => new cariHesaplar().GetObjectsOnlyMain(SLSREF);

        internal List<cariHesaplar> CarilerSub(int GMREF) => new cariHesaplar().GetObjectsOnlySub(GMREF);

        internal List<cariHesaplar> Cariler1Sub(int GMREF) => new cariHesaplar().GetObjects1OnlySub(GMREF);

        internal List<cariHesaplar> CarilerTpSub(int GMREF) => new cariHesaplar().GetObjectsTPOnlySub(GMREF);

        internal List<cariHesaplar> CarilerAll(int SLSREF) => new cariHesaplar().GetObjects(SLSREF);

        internal List<cariHesaplar> Cariler1All(int SLSREF) => new cariHesaplar().GetObjects1(SLSREF);

        internal List<cariHesaplar> Cariler11All(int SLSREF) => new cariHesaplar().GetObjects11(SLSREF);

        internal cariHesaplar Cari(int TIP, int SMREF) => new cariHesaplar().GetObject1(TIP, SMREF);
    }
}
