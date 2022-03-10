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
    }
}
