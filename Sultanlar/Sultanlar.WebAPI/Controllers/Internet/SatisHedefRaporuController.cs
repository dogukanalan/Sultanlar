using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sultanlar.DbObj.Internet;
using Sultanlar.WebAPI.Services.Internet;

namespace Sultanlar.WebAPI.Controllers.Internet
{
    [Yetkili]
    [Produces("application/json")]
    public class SatisHedefRaporuController : Controller
    {
        [HttpGet, Route("internet/[controller]/[action]/{YIL}/{AY}/{SLSREF}")]
        public List<satisHedefRaporu> Getir(int YIL, int AY, int SLSREF) => new SatisHedefRaporuProvider().SatisHedefRapor(YIL, AY, SLSREF);

        [HttpGet, Route("internet/[controller]/[action]/{YIL}/{SLSREF}")]
        public IEnumerable<int> SatisForDashboard(int YIL, int SLSREF)
        {
            var satis = new SatisHedefRaporuProvider().DashboardYillikSatis(YIL, SLSREF);
            var results = new int[12];
            for (int i = 0; i < 12; i++)
            {
                if (i < satis.Count)
                    results[i] = Convert.ToInt32(satis[i].SATIS);
            }
            return results;
        }

        [HttpGet, Route("internet/[controller]/[action]/{YIL}/{SLSREF}")]
        public IEnumerable<int> HedefForDashboard(int YIL, int SLSREF)
        {
            var hedef = new SatisHedefRaporuProvider().DashboardYillikHedef(YIL, SLSREF);
            var results = new int[12];
            for (int i = 0; i < 12; i++)
            {
                if (i < hedef.Count)
                    results[i] = Convert.ToInt32(hedef[i].HEDEF);
            }
            return results;
        }
    }
}
