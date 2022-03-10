using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sultanlar.DbObj.Internet;
using Sultanlar.WebAPI.Models.Internet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sultanlar.Model;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class DashboardProvider
    {
        internal List<satisHedefRaporu> DashboardYillikSatis(int Yil, int Slsref) => new satisHedefRaporu().GetSatisForDashboard(Yil, Slsref);
        internal List<satisHedefRaporu> DashboardYillikHedef(int Yil, int Slsref) => new satisHedefRaporu().GetHedefForDashboard(Yil, Slsref);
        internal List<BolumYillik> DashboardYillikBolum(int Yil, int Slsref) => new satisRaporu().GetBolumYillik(Yil, Slsref);
    }
}
