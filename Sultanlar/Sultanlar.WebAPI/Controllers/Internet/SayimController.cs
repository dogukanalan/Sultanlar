using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sultanlar.DbObj.Internet;
using Sultanlar.WebAPI.Services.Internet;
using Sultanlar.WebAPI.Models.Internet;

namespace Sultanlar.WebAPI.Controllers.Internet
{
    [Yetkili]
    [Produces("application/json")]
    public class SayimController : Controller
    {
        [HttpGet, Route("internet/[controller]/[action]/{GMREF}")]
        public List<sayimFisleri> GetirFisler(int GMREF) => new SayimProvider().Fisler(GMREF);

        [HttpGet, Route("internet/[controller]/[action]")]
        public List<sayimFisTurleri> GetirFisTurleri() => new SayimProvider().FisTurleri();

        [HttpPost, Route("internet/[controller]/[action]")]
        public string FisEkle([FromBody]SayimEkle sayim) => new SayimProvider().FisEkle(sayim);

        [HttpGet, Route("internet/[controller]/[action]/{GMREF}")]
        public List<sayimRapor> GetirRapor(int GMREF) => new SayimProvider().Rapor(GMREF);

        [HttpGet, Route("internet/[controller]/[action]/{ID}")]
        public sayimFis GetirFis(int ID) => new SayimProvider().Fis(ID);

        [HttpPost, Route("internet/[controller]/[action]")]
        public string Kaydet([FromBody]SayimKaydet sayim) => new SayimProvider().SayimKaydet(sayim);

        [HttpGet, Route("internet/[controller]/[action]/{SAYIMID}")]
        public string Onay(int SAYIMID) => new SayimProvider().Onay(SAYIMID);

        [HttpGet, Route("internet/[controller]/[action]/{SAYIMID}")]
        public string Sil(int SAYIMID) => new SayimProvider().Sil(SAYIMID);
    }
}
