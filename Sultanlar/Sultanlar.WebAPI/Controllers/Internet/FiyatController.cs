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
    [Produces("application/json")]
    public class FiyatController : Controller
    {
        [HttpGet, Route("internet/[controller]/[action]")]
        public List<fiyatlar> Get() => new FiyatProvider().Fiyatlar();
        
        [HttpGet, Route("internet/[controller]/[action]/{TIP}")]
        public List<fiyatlar> GetByTip(int TIP) => new FiyatProvider().Fiyatlar(TIP);
        
        [HttpGet, Route("internet/[controller]/[action]/{TIP}/{ITEMREF}")]
        public fiyatlar GetOne(int TIP, int ITEMREF) => new FiyatProvider().Fiyat(TIP, ITEMREF);

        [HttpGet, Route("internet/[controller]/[action]")]
        public List<fiyatlarTp> GetTP() => new FiyatProvider().FiyatlarTP();

        [HttpGet, Route("internet/[controller]/[action]/{YIL}/{AY}/{GUN}/{TIP}")]
        public List<fiyatlarTp> GetTPByYilAyTip(int YIL, int AY, int GUN, int TIP) => new FiyatProvider().FiyatlarTP(YIL, AY, GUN, TIP);

        [HttpGet, Route("internet/[controller]/[action]/{YIL}/{AY}/{TIP}/{ITEMREF}")]
        public fiyatlarTp GetOneTP(int YIL, int AY, int TIP, int ITEMREF) => new FiyatProvider().FiyatTP(YIL, AY, TIP, ITEMREF);
    }
}
