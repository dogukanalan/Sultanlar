using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sultanlar.DbObj.Internet;
using Sultanlar.WebAPI.Models.Internet;
using Sultanlar.WebAPI.Services.Internet;

namespace Sultanlar.WebAPI.Controllers.Internet
{
    [Yetkili]
    [Produces("application/json")]
    [Route("internet/[controller]/[action]")]
    public class ZiyaretController : Controller
    {
        [HttpGet]
        public List<ziyaretler> Gets() => new ZiyaretProvider().Ziyaretler();

        [HttpPost]
        public DtAjaxResponse Getir([FromBody]ZiyaretsGet ziyaretsget) => new ZiyaretProvider().Ziyaretler(ziyaretsget);

        [HttpPost]
        public ziyaretler Get([FromBody]ZiyaretGet ziyaretGet) => new ZiyaretProvider().Ziyaret(ziyaretGet);

        [HttpPost]
        public Ziyaret Ekle([FromBody]Ziyaret ziyaret) => new ZiyaretProvider().ZiyaretEkle(ziyaret);

        [HttpPost]
        public string Duzelt([FromBody]Ziyaret ziyaret) => new ZiyaretProvider().ZiyaretDuzelt(ziyaret);

        [HttpPost]
        public string Sil([FromBody]ZiyaretGet ziyaret) => new ZiyaretProvider().ZiyaretSil(ziyaret);

        [HttpGet]
        public List<ziyaretSonlandirmaSebepleri> Sonlandirma() => new ZiyaretProvider().Sonlandirma();
    }
}
