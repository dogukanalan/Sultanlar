using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
        public IMemoryCache _memoryCache;

        public SaticiController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpPost]
        public List<satisTemsilcileri> Post([FromBody]SaticiGet saticiget) => new SaticiProvider().Saticilar(saticiget.uyeid, false, _memoryCache);

        [HttpPost("{tumu}")]
        public List<satisTemsilcileri> Post([FromBody] SaticiGet saticiget, bool tumu) => new SaticiProvider().Saticilar(saticiget.uyeid, tumu, _memoryCache);
    }
}
