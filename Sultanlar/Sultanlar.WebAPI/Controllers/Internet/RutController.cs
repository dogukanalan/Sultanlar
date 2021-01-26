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
    public class RutController : Controller
    {
        [HttpGet, Route("internet/[controller]/[action]/{SLSREF}")]
        public List<rutlar> GetirRutlar(int SLSREF) => new RutProvider().Rutlar(SLSREF);
        [HttpGet, Route("internet/[controller]/[action]/{SLSREF}")]
        public List<rutlar> GetirRutlarBugun(int SLSREF) => new RutProvider().RutlarBugun(SLSREF);
        [HttpGet, Route("internet/[controller]/[action]/{SLSREF}/{SMREF}/{TIP}/{TUR}/{YIL}/{AY}")]
        public List<rutResimler> GetirRutResimler(int SLSREF, int SMREF, int TIP, int TUR, int YIL, int AY) => new RutProvider().RutResimler(SLSREF, SMREF, TIP, TUR, YIL, AY);
        [HttpGet, Route("internet/[controller]/[action]/{RutID}")]
        public List<rutResimler> GetirRutResimlerByRutID(string RutID) => new RutProvider().RutResimler(RutID);

        [HttpPost, Route("internet/[controller]/[action]/{SLSREF}")]
        public DtAjaxResponse Musteriler(int SLSREF, [FromBody]DataTableAjaxPostModel req) => new RutProvider().Musteriler(SLSREF, req);

        [HttpGet, Route("internet/[controller]/[action]/{slsref}/{gmref}/{smref}/{kacinci}")]
        public Rut GetirRut(string slsref, string gmref, string smref, string kacinci) => new RutProvider().RutGetir(slsref, gmref, smref, kacinci);
        [HttpGet, Route("internet/[controller]/[action]/{mtip}/{slsref}/{gmref}/{smref}/{kacinci}/{periyod}/{gun}/{baslangic}/{bitis}/{islemyapan}")]
        public string RutEkle(string mtip, string slsref, string gmref, string smref, string kacinci, string periyod, string gun, string baslangic, string bitis, string islemyapan) => new RutProvider().RutEkle(mtip, slsref, gmref, smref, kacinci, periyod, gun, baslangic, bitis, islemyapan);
    }
}
