using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sultanlar.WebAPI.Models.TarifSepeti;
using Sultanlar.WebAPI.Services.TarifSepeti;

namespace Sultanlar.WebAPI.Controllers.TarifSepeti
{
    [Produces("application/json")]
    [Route("tarifsepeti/Urun")]
    public class UrunController : Controller
    {
        [HttpGet]
        public List<Urun> Get() => new UrunProvider().UrunlerGetir();

        [HttpPost]
        public List<Urun> Post([FromBody]UrunGet value)
        {
            return new UrunProvider().UrunlerGetir(value);
        }
    }
}
