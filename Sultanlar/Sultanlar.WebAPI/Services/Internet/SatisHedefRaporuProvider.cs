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
        internal List<satisHedefRaporu> DashboardYillikSatis(int Yil, int Slsref) => new satisHedefRaporu().GetSatisForDashboard(Yil, Slsref);
        internal List<satisHedefRaporu> DashboardYillikHedef(int Yil, int Slsref) => new satisHedefRaporu().GetHedefForDashboard(Yil, Slsref);
    }
}
