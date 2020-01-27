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
    [Route("tarifsepeti/Tarif")]
    public class TarifController : Controller
    {
        [HttpPost]
        public List<Tarif> Post([FromBody]TarifGet value)
        {
            return new TarifProvider().TariflerGetir(value);
        }
    }
}
