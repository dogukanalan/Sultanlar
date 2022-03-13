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
    public class BorcAlacakController : Controller
    {
        [HttpGet, Route("internet/[controller]/[action]/{SLSREF}")]
        public List<borcAlacakRaporu> Getir(int SLSREF) => new BorcAlacakProvider().BorcAlacak(SLSREF);

        [HttpGet, Route("internet/[controller]/[action]/{SMREF}")]
        public List<borcAlacakRaporu> GetirCH(int SMREF) => new BorcAlacakProvider().BorcAlacakCH(SMREF);
    }
}
