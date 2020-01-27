using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sultanlar.Class;
using Sultanlar.DbObj.Internet;
using Sultanlar.WebAPI.Services.Internet;

namespace Sultanlar.WebAPI.Controllers.Internet
{
    [Yetkili]
    [Produces("application/json")]
    [Route("internet/[controller]")]
    public class UyeYetkiController : Controller
    {
        [HttpGet("{id}")]
        public uyeYetkileri GetAna(string id) => new UyeYetkiProvider().UyeYetkileri(Convert.ToInt32(Sifreleme.Decrypt(id)));
    }
}
