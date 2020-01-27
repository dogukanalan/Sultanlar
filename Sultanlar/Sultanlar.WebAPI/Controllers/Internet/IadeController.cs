using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sultanlar.DbObj.Internet;
using Sultanlar.WebAPI.Models.Internet;
using Sultanlar.WebAPI.Services.Internet;

namespace Sultanlar.WebAPI.Controllers
{
    [Yetkili]
    [Produces("application/json")]
    [Route("internet/[controller]/[action]")]
    public class IadeController : Controller
    {
        [HttpGet("{IadeID}")]
        public iadeler Get(int IadeID) => new IadeProvider().Iade(IadeID);

        [HttpPost]
        public List<iadeler> Getir([FromBody]IadeGet iadeget) => new IadeProvider().Iadeler(iadeget.slsref, iadeget.gmref, iadeget.smref, iadeget.yil, iadeget.ay, iadeget.onay);

        [HttpPost]
        public string Onay([FromBody]IadeOnay iadeonay) => new IadeProvider().IadeOnay(iadeonay.IadeID);

        [HttpPost]
        public string Kopya([FromBody]IadeKopya iadekopya) => new IadeProvider().IadeKopyala(iadekopya);

        [HttpGet("{IadeID}")]
        public string Sil(int IadeID) => new IadeProvider().IadeSil(IadeID);

        [HttpPost]
        public string Kaydet([FromBody]IadeKaydet iadekaydet) => new IadeProvider().IadeKaydet(iadekaydet);
    }
}
