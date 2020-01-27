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
    public class RutController : Controller
    {
        [HttpGet, Route("internet/[controller]/[action]/{SLSREF}")]
        public List<rutlar> GetirRutlar(int SLSREF) => new RutProvider().Rutlar(SLSREF);

        [HttpGet, Route("internet/[controller]/[action]/{SLSREF}/{SMREF}/{TIP}/{TUR}/{YIL}/{AY}")]
        public List<rutResimler> GetirRutResimler(int SLSREF, int SMREF, int TIP, int TUR, int YIL, int AY) => new RutProvider().RutResimler(SLSREF, SMREF, TIP, TUR, YIL, AY);
    }
}
