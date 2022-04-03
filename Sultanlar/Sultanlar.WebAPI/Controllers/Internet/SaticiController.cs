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
    [Route("internet/[controller]")]
    public class SaticiController : Controller
    {
        [HttpPost]
        public List<satisTemsilcileri> Post([FromBody]SaticiGet saticiget) => new SaticiProvider().Saticilar(saticiget.uyeid, false);

        [HttpPost("{tumu}")]
        public List<satisTemsilcileri> Post([FromBody] SaticiGet saticiget, bool tumu) => new SaticiProvider().Saticilar(saticiget.uyeid, tumu);
    }
}
