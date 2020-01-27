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
    public class AktiviteController : Controller
    {
        [HttpGet("{AktiviteID}")]
        public aktiviteler Get(int AktiviteID) => new AktiviteProvider().Aktivite(AktiviteID);

        [HttpPost]
        public List<aktiviteler> Getir([FromBody]AktiviteGet aktiviteget) => new AktiviteProvider().Aktiviteler(aktiviteget.slsref, aktiviteget.gmref, aktiviteget.smref, aktiviteget.tip, aktiviteget.yil, aktiviteget.ay, aktiviteget.onay);

        [HttpGet("{AktiviteID}")]
        public string Onay(int AktiviteID) => new AktiviteProvider().AktiviteOnay(AktiviteID);

        [HttpPost]
        public string Kopya([FromBody]AktiviteKopya aktivitekopya) => new AktiviteProvider().AktiviteKopyala(aktivitekopya);

        [HttpGet("{AktiviteID}")]
        public string Sil(int AktiviteID) => new AktiviteProvider().AktiviteSil(AktiviteID);

        [HttpPost]
        public string Kaydet([FromBody]AktiviteKaydet aktivitekaydet) => new AktiviteProvider().AktiviteKaydet(aktivitekaydet);
    }
}
