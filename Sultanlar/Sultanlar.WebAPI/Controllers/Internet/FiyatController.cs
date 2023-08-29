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
        
        [HttpGet, Route("internet/[controller]/[action]/{TIP}/{GMREF}/{MTIP}/{SMREF}")]
        public List<fiyatlar> GetByTip(int TIP, int GMREF, int MTIP, int SMREF) => new FiyatProvider().Fiyatlar(TIP, GMREF, MTIP, SMREF);

        [HttpGet, Route("internet/[controller]/[action]/{TIP}/{GMREF}/{MTIP}/{SMREF}")]
        public List<fiyatlar> GetByTip2(int TIP, int GMREF, int MTIP, int SMREF) => new FiyatProvider().Fiyatlar2(TIP, GMREF, MTIP, SMREF);

        [HttpGet, Route("internet/[controller]/[action]")]
        public List<fiyatlar> GetHaric() => new FiyatProvider().FiyatlarHaric();

        [HttpGet, Route("internet/[controller]/[action]/{TIP}/{GMREF}/{MTIP}/{SMREF}")]
        public List<fiyatlar> GetNonByTip(int TIP, int GMREF, int MTIP, int SMREF) => new FiyatProvider().FiyatlarNon(TIP, GMREF, MTIP, SMREF);

        [HttpGet, Route("internet/[controller]/[action]/{TIP}/{GMREF}/{MTIP}/{SMREF}")]
        public async Task<List<fiyatlar>> GetAllByTip(int TIP, int GMREF, int MTIP, int SMREF) => await Task.Run(() => new FiyatProvider().FiyatlarAll(TIP, GMREF, MTIP, SMREF));

        [HttpGet, Route("internet/[controller]/[action]/{TIP}/{GMREF}/{MTIP}/{SMREF}")]
        public List<fiyatlar> GetByTipAkt(int TIP, int GMREF, int MTIP, int SMREF) => new FiyatProvider().FiyatlarAktif(TIP, GMREF, MTIP, SMREF);

        [HttpGet, Route("internet/[controller]/[action]/{TIP}/{ITEMREF}")]
        public fiyatlar GetOne(int TIP, int ITEMREF) => new FiyatProvider().Fiyat(TIP, ITEMREF);

        [HttpGet, Route("internet/[controller]/[action]")]
        public List<fiyatlarTp> GetTP() => new FiyatProvider().FiyatlarTP();

        [HttpGet, Route("internet/[controller]/[action]/{YIL}/{AY}/{GUN}/{TIP}")]
        public List<fiyatlarTp> GetTPByYilAyTip(int YIL, int AY, int GUN, int TIP) => new FiyatProvider().FiyatlarTP(YIL, AY, GUN, TIP);

        [HttpGet, Route("internet/[controller]/[action]/{YIL}/{AY}/{TIP}/{ITEMREF}")]
        public fiyatlarTp GetOneTP(int YIL, int AY, int TIP, int ITEMREF) => new FiyatProvider().FiyatTP(YIL, AY, TIP, ITEMREF);

        [HttpGet, Route("internet/[controller]/[action]/{GMREF}/{MTIP}")]
        public List<fiyatlar> GetVyByGMREF(int GMREF, int MTIP) => new FiyatProvider().FiyatlarVy(GMREF, MTIP);

        [HttpGet, Route("internet/[controller]/[action]/{GMREF}/{MTIP}")]
        public List<fiyatlar> GetNonVyByGMREF(int GMREF, int MTIP) => new FiyatProvider().FiyatlarNonVy(GMREF, MTIP);

        [HttpGet, Route("internet/[controller]/[action]")]
        public List<fiyatTipleri> GetFiyatTipler500birlikte() => new FiyatProvider().FiyatTipler500birlikte();

        [HttpGet, Route("internet/[controller]/[action]/{TIP}/{ITEMREF}/{KULLANICI}")]
        public string SetEkle(int TIP, int ITEMREF, string KULLANICI) => new FiyatProvider().FiyatEkle(TIP, ITEMREF, KULLANICI);

        [HttpGet, Route("internet/[controller]/[action]/{TIP}/{ITEMREF}/{KULLANICI}")]
        public string SetCikar(int TIP, int ITEMREF, string KULLANICI) => new FiyatProvider().FiyatCikar(TIP, ITEMREF, KULLANICI);

        [HttpGet, Route("internet/[controller]/[action]/{GMREF}/{NETTOP}/{SMREF}/{TIP}/{MUSTERI}")]
        public string YeniFiyatTip(int GMREF, int NETTOP, int SMREF, int TIP, string MUSTERI) => new FiyatProvider().FiyatTipOlustur(GMREF, NETTOP, SMREF, TIP, MUSTERI);

        [HttpGet, Route("internet/[controller]/[action]/{SMREF}")]
        public List<fiyatlar> GetSmrefad(int SMREF) => new FiyatProvider().Smrefad(SMREF);
    }
}
