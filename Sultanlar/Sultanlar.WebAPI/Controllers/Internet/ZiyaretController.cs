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
    [Produces("application/json")]
    [Route("internet/[controller]/[action]")]
    public class ZiyaretController : Controller
    {
        [Yetkili]
        [HttpGet]
        public List<ziyaretler> Gets() => new ZiyaretProvider().Ziyaretler();

        [Yetkili]
        [HttpPost]
        public DtAjaxResponse Getir([FromBody]ZiyaretsGet ziyaretsget) => new ZiyaretProvider().Ziyaretler(ziyaretsget);

        [Yetkili]
        [HttpPost]
        public ziyaretler Get([FromBody]ZiyaretGet ziyaretGet) => new ZiyaretProvider().Ziyaret(ziyaretGet);

        [Yetkili]
        [HttpPost]
        public Ziyaret Ekle([FromBody]Ziyaret ziyaret) => new ZiyaretProvider().ZiyaretEkle(ziyaret);

        [Yetkili]
        [HttpPost]
        public string Duzelt([FromBody]Ziyaret ziyaret) => new ZiyaretProvider().ZiyaretDuzelt(ziyaret);

        [Yetkili]
        [HttpPost]
        public string Sil([FromBody]ZiyaretGet ziyaret) => new ZiyaretProvider().ZiyaretSil(ziyaret);

        [Yetkili]
        [HttpGet]
        public List<ziyaretSonlandirmaSebepleri> Sonlandirma() => new ZiyaretProvider().Sonlandirma();

        [Yetkili]
        [HttpPost]
        public string VaryokEkle([FromBody]ZiyaretVaryok varyok) => new ZiyaretProvider().VaryokEkle(varyok);

        [Yetkili]
        [HttpGet("{BARKOD}")]
        public ziyaretvaryok VaryokGetir(string BARKOD) => new ZiyaretProvider().VaryokGetir(BARKOD);

        [Yetkili]
        [HttpGet("{BARKOD}")]
        public string VaryokSil(string BARKOD) => new ZiyaretProvider().VaryokSil(BARKOD);

        [HttpGet("{ID}/{MUSTERIID}/{SLSREF}")]
        public string VaryokLogEkle(string ID, string MUSTERIID, string SLSREF) => new ZiyaretProvider().VaryokLogekle(ID, MUSTERIID, SLSREF);
    }
}
