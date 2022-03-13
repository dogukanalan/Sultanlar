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
    public class KonumController : Controller
    {
        [HttpGet, Route("internet/[controller]/[action]/{SLSREF}")]
        public List<konumListe> GetirKonumListe(int SLSREF) => new KonumProvider().KonumListe(SLSREF);

        [HttpPost, Route("internet/[controller]/[action]/{SLSREF}")]
        public DtAjaxResponse GetirKonumListePost(int SLSREF, [FromBody]DataTableAjaxPostModel req) => new KonumProvider().KonumListe2(SLSREF, req);

        [HttpGet, Route("internet/[controller]/[action]/{SMREF}/{TIP}/{ADRES}/{COORDS}")]
        public string KonumSet(string SMREF, string TIP, string ADRES, string COORDS) => new KonumProvider().KonumSet(SMREF, TIP, ADRES, COORDS);
    }
}
