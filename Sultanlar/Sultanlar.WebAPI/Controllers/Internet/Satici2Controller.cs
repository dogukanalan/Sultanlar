using Microsoft.AspNetCore.Mvc;
using Sultanlar.DbObj.Internet;
using Sultanlar.WebAPI.Services.Internet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Controllers.Internet
{
    [Yetkili]
    [Produces("application/json")]
    [Route("internet/[controller]/[action]")]
    public class Satici2Controller : Controller
    {
        [HttpPost]
        public string Ekle([FromBody]satisTemsilcileri sattem) => new Satici2Provider().Ekle(sattem);
        [HttpPost]
        public string Guncelle([FromBody]satisTemsilcileri sattem) => new Satici2Provider().Guncelle(sattem);
        [HttpPost]
        public string Sil([FromBody]satisTemsilcileri sattem) => new Satici2Provider().Sil(sattem);

        [HttpGet]
        public satisTemsilcileri Getir(string uyeid) => new Satici2Provider().Getir(uyeid);
    }
}
