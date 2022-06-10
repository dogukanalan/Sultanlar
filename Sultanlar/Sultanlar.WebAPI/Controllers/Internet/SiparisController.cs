using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sultanlar.Class;
using Sultanlar.DbObj.Internet;
using Sultanlar.WebAPI.Models.Internet;
using Sultanlar.WebAPI.Services.Internet;

namespace Sultanlar.WebAPI.Controllers.Internet
{
    [Yetkili]
    [Produces("application/json")]
    [Route("internet/[controller]/[action]")]
    public class SiparisController : Controller
    {
        [HttpGet("{SiparisID}")]
        public siparisler Get(int SiparisID) => new SiparisProvider().Siparis(SiparisID);

        [HttpPost]
        public DtAjaxResponse Getir([FromBody]SiparisGet siparisget) => new SiparisProvider().Siparisler(siparisget);

        [HttpPost]
        public string Onay([FromBody]SiparisOnay siparisonay) => new SiparisProvider().SiparisOnay(siparisonay.SiparisID, siparisonay.Bakiye, Convert.ToInt32(Sifreleme.Decrypt(siparisonay.MusteriID)));

        [HttpPost]
        public string Kopya([FromBody]SiparisKopya sipariskopya) => new SiparisProvider().SiparisKopyala(sipariskopya);

        [HttpGet("{SiparisID}")]
        public string Sil(int SiparisID) => new SiparisProvider().SiparisSil(SiparisID);

        [HttpPost]
        public string Kaydet([FromBody]SiparisKaydet sipariskaydet) => new SiparisProvider().SiparisKaydet(sipariskaydet);

        [HttpGet("{SMREF}/{ITEMREF}/{Tarih}")]
        public SiparisIsks GetIsks(int SMREF, int ITEMREF, DateTime Tarih) => new SiparisProvider().Isks(SMREF, ITEMREF, Tarih);

        [HttpGet("{Fiyattipi}/{ITEMREF}")]
        public SiparisIsks GetIsks500(int Fiyattipi, int ITEMREF) => new SiparisProvider().Isks500(Fiyattipi, ITEMREF);
    }
}
