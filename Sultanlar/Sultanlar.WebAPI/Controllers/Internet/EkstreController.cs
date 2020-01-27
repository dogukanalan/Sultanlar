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
    public class EkstreController : Controller
    {
        [HttpGet, Route("internet/[controller]/[action]/{GMREF}/{AY}")]
        public List<ekstreler> Getir(int GMREF, int AY) => new EkstreProvider().Ekstreler(GMREF, AY);

        [HttpGet, Route("internet/[controller]/[action]/{GMREF}")]
        public ekstreler GetirDipTop(int GMREF) => new EkstreProvider().EkstrelerDipTop(GMREF);
    }
}
