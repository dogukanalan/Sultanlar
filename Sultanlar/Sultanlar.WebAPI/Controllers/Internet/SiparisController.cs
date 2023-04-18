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
    //[Yetkili]
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

        [HttpGet("{SMREF}/{TIP}/{ITEMREF}/{Tarih}")]
        public SiparisIsks GetIsksTP(int SMREF, int TIP, int ITEMREF, DateTime Tarih) => new SiparisProvider().IsksTP(SMREF, TIP, ITEMREF, Tarih);

        [HttpGet("{SLSREF}")]
        public List<siparislerDetay> GetDetaySevksiz(int SLSREF) => new SiparisProvider().DetaySevksiz(SLSREF);

        [HttpGet("{SLSREF}")]
        public List<siparislerDetay> GetDetaySevkli(int SLSREF) => new SiparisProvider().DetaySevkli(SLSREF);

        [HttpGet("{SLSREF}")]
        public List<siparislerDetay> GetDetaySevkliAktarilmis(int SLSREF) => new SiparisProvider().DetaySevkliAktarilmis(SLSREF);

        [HttpGet("{SLSREF}")]
        public List<siparisler> GetSevksiz(int SLSREF) => new SiparisProvider().Sevksiz(SLSREF);

        [HttpGet("{SLSREF}")]
        public List<siparisler> GetSevkli(int SLSREF) => new SiparisProvider().Sevkli(SLSREF);

        [HttpGet("{SLSREF}")]
        public List<siparisler> GetSevkliAktarilmis(int SLSREF) => new SiparisProvider().SevkliAktarilmis(SLSREF);

        [HttpGet("{SLSREF}")]
        public List<siparisler> GetBakiyeler(int SLSREF) => new SiparisProvider().BakiyeSiparisler(SLSREF);

        [HttpPost]
        public string BakiyeOlustur([FromBody]List<SevkKaydet> sks) => new SiparisProvider().BakiyeKalanOlustur(sks);

        [HttpPost]
        public string DetaySevkKaydet([FromBody]List<SevkKaydet> sevkkaydet) => new SiparisProvider().DetaySevkKaydet(sevkkaydet);

        [HttpPost]
        public string SevkKaydet([FromBody]List<SevkKaydet> sevkkaydet) => new SiparisProvider().SevkKaydet(sevkkaydet);

        [HttpPost]
        public ContentResult DetaySevkAktar([FromBody] List<SevkKaydet> sevkkaydet) => new SiparisProvider().DetaySevkAktar(sevkkaydet);

        [HttpPost]
        public ContentResult SevkAktar([FromBody] List<SevkKaydet> sevkkaydet) => new SiparisProvider().SevkAktar(sevkkaydet);

        [HttpPost]
        public string SevkIptal([FromBody] List<SevkKaydet> sevkiptal) => new SiparisProvider().SevkIptal(sevkiptal);

        [HttpGet("{SiparisID}")]
        public string SevkSil(int SiparisID) => new SiparisProvider().SevksizOnaydanGeri(SiparisID);

        [HttpGet("{Slsref}")]
        public string SevkTamami(int SLSREF) => new SiparisProvider().SevkTamami(SLSREF);
    }
}
