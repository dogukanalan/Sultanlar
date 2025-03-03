﻿using System;
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
        public DtAjaxResponse Getir([FromBody]AktiviteGet aktiviteget) => new AktiviteProvider().Aktiviteler(aktiviteget);

        [HttpGet("{AktiviteID}")]
        public string Onay(int AktiviteID) => new AktiviteProvider().AktiviteOnay(AktiviteID, HttpContext.Request.Headers["sulMus"]);

        [HttpPost]
        public string Kopya([FromBody]AktiviteKopya aktivitekopya) => new AktiviteProvider().AktiviteKopyala(aktivitekopya, HttpContext.Request.Headers["sulMus"]);

        [HttpGet("{AktiviteID}")]
        public string Sil(int AktiviteID) => new AktiviteProvider().AktiviteSil(AktiviteID, HttpContext.Request.Headers["sulMus"]);

        [HttpPost]
        public string Kaydet([FromBody] AktiviteKaydet aktivitekaydet) => new AktiviteProvider().AktiviteKaydet(aktivitekaydet, HttpContext.Request.Headers["sulMus"]);
    }
}
