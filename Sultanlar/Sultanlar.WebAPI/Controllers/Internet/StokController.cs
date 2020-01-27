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
    public class StokController : Controller
    {
        [HttpGet, Route("internet/[controller]/[action]/{SLSREF}/{SMREF}")]
        public List<bayiStokRaporu> GetirBayiStok(int SLSREF, int SMREF) => new StokProvider().BayiStokRapor(SLSREF, SMREF);
    }
}
