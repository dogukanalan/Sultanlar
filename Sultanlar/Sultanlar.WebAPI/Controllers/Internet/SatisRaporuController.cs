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
    public class SatisRaporuController : Controller
    {
        [HttpGet, Route("internet/[controller]/[action]/{YIL}/{AY}/{SLSREF}/{GMREF}/{SMREF}/{ITEMREF}")]
        public List<satisRaporu> Getir(int YIL, int AY, int SLSREF, int GMREF, int SMREF, int ITEMREF) => new SatisRaporuProvider().SatisRapor(YIL, AY, SLSREF, GMREF, SMREF, ITEMREF);

        [HttpPost, Route("internet/[controller]/[action]/{YIL}/{AY}/{SLSREF}/{GMREF}/{SMREF}/{ITEMREF}")]
        public DtAjaxResponse GetirDy(int YIL, int AY, int SLSREF, int GMREF, int SMREF, int ITEMREF, [FromBody]DataTableAjaxPostModel req) => new SatisRaporuProvider().SatisRapor(YIL, AY, SLSREF, GMREF, SMREF, ITEMREF, req);

        [HttpGet, Route("internet/[controller]/[action]/{YIL}/{AY}/{SLSREF}/{TUR}/{GMREF}")]
        public List<satisRaporuOzet> GetirOzet(int YIL, int AY, int SLSREF, string TUR, int GMREF) => new SatisRaporuProvider().SatisRaporOzet(YIL, AY, SLSREF, TUR, GMREF);

        [HttpGet, Route("internet/[controller]/[action]/{YIL}/{AY}/{SLSREF}/{TUR}/{GMREF}")]
        public List<satisRaporuKars> GetirKars(int YIL, int AY, int SLSREF, string TUR, int GMREF) => new SatisRaporuProvider().SatisRaporKars(YIL, AY, SLSREF, TUR, GMREF);

        [HttpGet, Route("internet/[controller]/[action]/{YIL}/{AY}/{SLSREF}")]
        public List<siparisRaporu> GetirSiparis(int YIL, int AY, int SLSREF) => new SiparisProvider().SiparisRapor(YIL, AY, SLSREF);

        [HttpGet, Route("internet/[controller]/[action]/{YIL}/{AY}/{SLSREF}/{SIPNO}")]
        public List<siparisDetayRaporu> GetirSiparisDetay(int YIL, int AY, int SLSREF, int SIPNO) => new SiparisProvider().SiparisDetayRapor(YIL, AY, SLSREF, SIPNO);

        [HttpGet, Route("internet/[controller]/[action]/{YIL}/{AY}/{SLSREF}/{SIPNO}")]
        public List<siparisDurumRaporu> GetirSiparisDurum(int YIL, int AY, int SLSREF, int SIPNO) => new SiparisProvider().SiparisDurumRapor(YIL, AY, SLSREF, SIPNO);
    }
}
