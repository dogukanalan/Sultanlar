using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KomsuWcf;
using System.ServiceModel;

namespace Sultanlar.WebAPI.Controllers.Out
{
    //[YetkiliOut]
    [Produces("application/json")]
    [Route("out/[controller]/[action]")]
    public class Komsu : Controller
    {
        [HttpGet]
        public async Task<ZwebKomsuS_001[]> Komsu001()
        {
            KomsuClient komsu = new KomsuClient();
            komsu.ClientCredentials.UserName.UserName = "komsu";
            komsu.ClientCredentials.UserName.Password = "tsoft";
            ZwebKomsuS_001[] bir = await Task.Run(() => { return komsu.komsu001(""); });
            return bir;
        }
    }
}
