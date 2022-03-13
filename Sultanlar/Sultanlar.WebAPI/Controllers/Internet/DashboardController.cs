using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sultanlar.DbObj.Internet;
using Sultanlar.WebAPI.Models.Internet;
using Sultanlar.WebAPI.Services.Internet;
using Sultanlar.Model.Dashboard;

namespace Sultanlar.WebAPI.Controllers.Internet
{
    [Yetkili]
    [Produces("application/json")]
    public class DashboardController : Controller
    {
        [HttpGet, Route("internet/[controller]/[action]/{YIL}/{SLSREF}")]
        public IEnumerable<int> Satis(int YIL, int SLSREF)
        {
            var satis = new DashboardProvider().DashboardYillikSatis(YIL, SLSREF);
            var results = new int[12];
            for (int i = 0; i < 12; i++)
            {
                if (i < satis.Count)
                    results[i] = Convert.ToInt32(satis[i].SATIS);
            }
            return results;
        }

        [HttpGet, Route("internet/[controller]/[action]/{YIL}/{SLSREF}")]
        public IEnumerable<int> Hedef(int YIL, int SLSREF)
        {
            var hedef = new DashboardProvider().DashboardYillikHedef(YIL, SLSREF);
            var results = new int[12];
            for (int i = 0; i < 12; i++)
            {
                if (i < hedef.Count)
                    results[i] = Convert.ToInt32(hedef[i].HEDEF);
            }
            return results;
        }

        [HttpGet, Route("internet/[controller]/[action]/{YIL}/{SLSREF}")]
        public List<BolumYillik> Bolum(int YIL, int SLSREF)
        {
            return new DashboardProvider().DashboardYillikBolum(YIL, SLSREF);
        }

        [HttpGet, Route("internet/[controller]/[action]/{YIL}/{AY}")]
        public List<BayiSatisHedef> BayiSatisHedef(int YIL, int AY)
        {
            return new DashboardProvider().DashboardBayiSatisHedef(YIL, AY);
        }
    }
}
