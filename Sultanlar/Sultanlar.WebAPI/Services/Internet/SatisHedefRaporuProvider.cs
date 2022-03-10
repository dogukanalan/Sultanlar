using Sultanlar.DbObj.Internet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class SatisHedefRaporuProvider
    {
        internal List<satisHedefRaporu> SatisHedefRapor(int Yil, int Ay, int Slsref) => new satisHedefRaporu().GetObjects(Yil, Ay, Slsref);
    }
}
