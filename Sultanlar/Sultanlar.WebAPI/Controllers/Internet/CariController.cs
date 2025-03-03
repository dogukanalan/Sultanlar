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
    [Produces("application/json")]
    public class CariController : Controller
    {
        [Yetkili]
        [HttpGet, Route("internet/[controller]/[action]/{slsref}")]
        public List<cariHesaplar> GetAna(int slsref) => new CariProvider().Cariler(slsref);

        [Yetkili]
        [HttpGet, Route("internet/[controller]/[action]")]
        public List<cariHesaplar> GetBayi() => new CariProvider().Bayiler();

        [Yetkili]
        [HttpGet, Route("internet/[controller]/[action]/{gmref}/{slsref}")]
        public List<cariHesaplar> GetSube(int gmref, int slsref) => new CariProvider().CarilerSub(gmref, slsref);

        [Yetkili]
        [HttpGet, Route("internet/[controller]/[action]/{gmref}/{slsref}")]
        public List<cariHesaplar> GetSube1(int gmref, int slsref) => new CariProvider().Cariler1Sub(gmref, slsref);

        [Yetkili]
        [HttpPost, Route("internet/[controller]/[action]/{gmref}/{slsref}")]
        public DtAjaxResponse GetSube1(int gmref, int slsref, [FromBody]DataTableAjaxPostModel req) => new CariProvider().Cariler1Sub(gmref, slsref, req);

        [Yetkili]
        [HttpPost, Route("internet/[controller]/[action]/{gmref}/{slsref}")]
        public DtAjaxResponse GetSube1detayli(int gmref, int slsref, [FromBody] DataTableAjaxPostModel req) => new CariProvider().Cariler1SubDetayli(gmref, slsref, req);

        [Yetkili]
        [HttpGet, Route("internet/[controller]/[action]/{gmref}")]
        public List<cariHesaplar> GetSubeTp(int gmref) => new CariProvider().CarilerTpSub(gmref);

        [Yetkili]
        [HttpGet, Route("internet/[controller]/[action]/{slsref}")]
        public List<cariHesaplar> GetHepsi(int slsref) => new CariProvider().CarilerAll(slsref);

        [Yetkili]
        [HttpGet, Route("internet/[controller]/[action]/{slsref}")]
        public List<cariHesaplar> GetHepsi1(int slsref) => new CariProvider().Cariler1All(slsref);

        [Yetkili]
        [HttpGet, Route("internet/[controller]/[action]/{slsref}")]
        public List<cariHesaplar> GetHepsi12(int slsref) => new CariProvider().Cariler12All(slsref);

        [Yetkili]
        [HttpGet, Route("internet/[controller]/[action]/{slsref}")]
        public List<cariHesaplar> GetHepsi124(int slsref) => new CariProvider().Cariler124All(slsref);

        [Yetkili]
        [HttpGet, Route("internet/[controller]/[action]/{slsref}")]
        public List<cariHesaplar> GetHepsi11(int slsref) => new CariProvider().Cariler11All(slsref);

        [HttpGet, Route("internet/[controller]/[action]/{tip}/{smref}")]
        public cariHesaplar GetCari(int tip, int smref) => new CariProvider().Cari(tip, smref);
    }
}
