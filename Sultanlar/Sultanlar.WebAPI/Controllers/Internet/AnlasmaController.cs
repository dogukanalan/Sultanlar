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
    public class AnlasmaController : Controller
    {
        [HttpGet("{AnlasmaID}")]
        public anlasmalar Get(int AnlasmaID) => new AnlasmaProvider().Anlasma(AnlasmaID);

        [HttpPost]
        public DtAjaxResponse Getir([FromBody]AnlasmaGet anlasmaget) => new AnlasmaProvider().Anlasmalar(anlasmaget);
        
        [HttpPost]
        public List<anlasmalar> GetirByMus([FromBody]AnlasmaMusteriGet anlasmaget) => new AnlasmaProvider().Anlasmalar(anlasmaget.yil, anlasmaget.ay, anlasmaget.smref, anlasmaget.tip, anlasmaget.yegmi);

        [HttpPost]
        public string Kaydet([FromBody]AnlasmaKaydet anlasmakaydet) => new AnlasmaProvider().AnlasmaKaydet(anlasmakaydet, HttpContext.Request.Headers["sulMus"]);

        [HttpGet("{ID}")]
        public anlasmaBedelAdlari GetBedelTanim(int ID) => new AnlasmaProvider().AnlasmaBedelAdlari(ID);

        [HttpGet]
        public List<anlasmaBedelAdlari> GetBedelTanimlar() => new AnlasmaProvider().AnlasmaBedelAdlari();

        [HttpPost]
        public string Kopya([FromBody]AnlasmaKopya anlasmakopya) => new AnlasmaProvider().AnlasmaKopyala(anlasmakopya, HttpContext.Request.Headers["sulMus"]);
    }
}
