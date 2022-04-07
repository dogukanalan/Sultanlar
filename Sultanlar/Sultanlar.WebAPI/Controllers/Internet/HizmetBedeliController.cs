using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sultanlar.WebAPI.Services.Internet;
using Sultanlar.WebAPI.Models.Internet;
using Sultanlar.DbObj.Internet;

namespace Sultanlar.WebAPI.Controllers.Internet
{
    [Yetkili]
    [Produces("application/json")]
    [Route("internet/[controller]/[action]")]
    public class HizmetBedeliController : Controller
    {
        [HttpGet("{HizmetBedeliID}")]
        public hizmetBedelleri Get(int HizmetBedeliID) => new HizmetBedeliProvider().HizmetBedeli(HizmetBedeliID);

        [HttpPost]
        public DtAjaxResponse Getir([FromBody]HizmetBedeliGet hizmetbedeliget) => new HizmetBedeliProvider().HizmetBedelleri(hizmetbedeliget);

        [HttpPost]
        public List<hizmetBedelleri> GetirF([FromBody]HizmetBedeliGet hizmetbedeliget) => new HizmetBedeliProvider().HizmetBedelleriFull(hizmetbedeliget);

        [HttpPost]
        public string Kaydet([FromBody]HizmetBedeliKaydet hizmetbedelikaydet) => new HizmetBedeliProvider().HizmetBedeliKaydet(hizmetbedelikaydet);

        [HttpGet("{HizmetBedeliID}")]
        public string Sil(int HizmetBedeliID) => new HizmetBedeliProvider().HizmetBedeliSil(HizmetBedeliID);
    }
}
