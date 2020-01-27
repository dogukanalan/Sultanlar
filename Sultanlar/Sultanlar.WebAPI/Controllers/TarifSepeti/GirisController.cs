using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sultanlar.WebAPI.Services.TarifSepeti;

namespace Sultanlar.WebAPI.Controllers.TarifSepeti
{
    [Produces("application/json")]
    [Route("tarifsepeti/Giris")]
    public class GirisController : Controller
    {
        [HttpGet("{epostasifre}")]
        public int Get(string epostasifre)
        {
            return new GirisProvider().GirisYap(epostasifre.Split(";;;", StringSplitOptions.None)[0], epostasifre.Split(";;;", StringSplitOptions.None)[1]);
        }
    }
}
