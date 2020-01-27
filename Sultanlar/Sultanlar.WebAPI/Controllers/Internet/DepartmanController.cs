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
    public class DepartmanController : Controller
    {
        [HttpGet, Route("internet/[controller]/[action]")]
        public List<departmanlar> Getir() => new DepartmanProvider().Departmanlar();

        [HttpGet, Route("internet/[controller]/[action]/{ID}")]
        public departmanlar Get(byte ID) => new DepartmanProvider().Departman(ID);
    }
}
