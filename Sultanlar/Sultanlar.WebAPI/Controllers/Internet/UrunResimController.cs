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
    [Route("internet/[controller]")]
    public class UrunResimController : Controller
    {
        [HttpGet("{ITEMREF}")]
        public List<urunResimleri> Get(int ITEMREF) => new UrunResimProvider().UrunResimleri(ITEMREF);
    }
}
