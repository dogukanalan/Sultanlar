using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sultanlar.WebAPI.Models.Internet;
using Sultanlar.WebAPI.Services.Internet;

namespace Sultanlar.WebAPI.Controllers.Internet
{
    [Produces("application/json")]
    [Route("internet/Giris")]
    public class GirisController : Controller
    {
        [HttpPost]
        public Giris Post([FromBody]GirisGet value) => new GirisProvider().GirisYap(value);
    }
}
