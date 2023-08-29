using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sultanlar.DbObj.Internet;
using Sultanlar.WebAPI.Services.Internet;

namespace Sultanlar.WebAPI.Controllers.Internet
{
    [Yetkili]
    [Produces("application/json")]
    public class StokController : Controller
    {
        [HttpGet, Route("internet/[controller]/[action]/{SLSREF}/{SMREF}")]
        public List<bayiStokRaporu> GetirBayiStok(int SLSREF, int SMREF) => new StokProvider().BayiStokRapor(SLSREF, SMREF);

        [HttpGet, Route("internet/[controller]/[action]/{GMREF}")]
        public List<bayiStokTeslim> GetBayiStokTeslimler(int GMREF) => new StokProvider().BayiStokTeslimler(GMREF);

        [HttpGet, Route("internet/[controller]/[action]/{GMREF}/{FATNO}")]
        public bayiStokTeslim GetBayiStokTeslim(int GMREF, string FATNO) => new StokProvider().BayiStokTeslim(GMREF, FATNO);

        [HttpGet, Route("internet/[controller]/[action]/{FATNO}")]
        public List<satisRaporu> GetBayiStokTeslimDetay(string FATNO) => new satisRaporu().GetObject(FATNO);

        [HttpGet, Route("internet/[controller]/[action]/{GMREF}/{FATNO}/{KULLANICI}/{ONAY}")]
        public string SetTeslim(int GMREF, string FATNO, int KULLANICI, int ONAY) => new StokProvider().SetBayiStokTeslim(GMREF, FATNO, KULLANICI, ONAY);
    }
}
