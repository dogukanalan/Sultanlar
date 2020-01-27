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
    public class ResimController : Controller
    {
        [HttpGet("{ResimID}")]
        public IActionResult Get(int ResimID) => File(new ResimProvider().Resimler(ResimID).binResim, "image/png");

        [HttpGet("{ResimID}")]
        public IActionResult GetK(int ResimID) => File(new ResimProvider().Resimler(ResimID).binResimK, "image/png");

        [HttpGet("{ResimID}")]
        public IActionResult GetO(int ResimID) => File(new ResimProvider().Resimler(ResimID).binResimO, "image/png");

        [HttpGet("{ITEMREF}")]
        public IActionResult GetTO(int ITEMREF)
        {
            ResimProvider rp = new ResimProvider();
            List<urunResimleri> ur = new UrunResimProvider().UrunResimleri(ITEMREF);
            if (ur.Count == 0)
                return File(rp.BosResimOlustur(100, 100), "image/png");
            return File(rp.Resimler(ur[0].intResimID).binResimO, "image/png");
        }

        [HttpGet("{ITEMREF}")]
        public IActionResult GetT(int ITEMREF)
        {
            ResimProvider rp = new ResimProvider();
            List<urunResimleri> ur = new UrunResimProvider().UrunResimleri(ITEMREF);
            if (ur.Count == 0)
                return File(rp.BosResimOlustur(400, 400), "image/png");
            return File(rp.ResimOlustur(rp.Resimler(ur[0].intResimID).binResim, 400, 400, 75), "image/png");
        }

        [Yetkili]
        [HttpPost]
        public string SdePost([FromBody]SDEResim sderesim) => new ResimProvider().SDEResimGonder(sderesim);

        [HttpGet("{ID}")]
        public IActionResult SdeResimK(int ID)
        {
            ResimProvider rp = new ResimProvider();
            return File(rp.ResimOlustur(new ResimProvider().SDEResim(ID).binResim, 100, 100, 75), "image/png");
        }

        [HttpGet("{ID}")]
        public IActionResult SdeResim(int ID) => File(new ResimProvider().SDEResim(ID).binResim, "image/png");

        [Yetkili]
        [HttpGet]
        public List<rutResimTurler> SdeResimTur() => new ResimProvider().SDEResimTurler();
    }
}
