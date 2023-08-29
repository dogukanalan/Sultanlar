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
    [Produces("application/json")]
    [Route("internet/[controller]/[action]")]
    public class SiparisController : Controller
    {
        [Yetkili, HttpGet("{SiparisID}")]
        public siparisler Get(int SiparisID) => new SiparisProvider().Siparis(SiparisID);

        [Yetkili, HttpPost]
        public DtAjaxResponse Getir([FromBody]SiparisGet siparisget) => new SiparisProvider().Siparisler(siparisget);

        [Yetkili, HttpPost]
        public string Onay([FromBody]SiparisOnay siparisonay) => new SiparisProvider().SiparisOnay(siparisonay.SiparisID, siparisonay.Bakiye, Convert.ToInt32(Sifreleme.Decrypt(siparisonay.MusteriID)));

        [Yetkili, HttpPost]
        public string Kopya([FromBody]SiparisKopya sipariskopya) => new SiparisProvider().SiparisKopyala(sipariskopya);

        [Yetkili, HttpGet("{SiparisID}")]
        public string Sil(int SiparisID) => new SiparisProvider().SiparisSil(SiparisID);

        [Yetkili, HttpPost]
        public string Kaydet([FromBody]SiparisKaydet sipariskaydet) => new SiparisProvider().SiparisKaydet(sipariskaydet);

        [Yetkili, HttpGet("{SMREF}/{ITEMREF}/{Tarih}")]
        public SiparisIsks GetIsks(int SMREF, int ITEMREF, DateTime Tarih) => new SiparisProvider().Isks(SMREF, ITEMREF, Tarih);

        [Yetkili, HttpGet("{Fiyattipi}/{ITEMREF}")]
        public SiparisIsks GetIsks500(int Fiyattipi, int ITEMREF) => new SiparisProvider().Isks500(Fiyattipi, ITEMREF);

        [Yetkili, HttpGet("{SMREF}/{TIP}/{ITEMREF}/{Tarih}")]
        public SiparisIsks GetIsksTP(int SMREF, int TIP, int ITEMREF, DateTime Tarih) => new SiparisProvider().IsksTP(SMREF, TIP, ITEMREF, Tarih);

        [Yetkili, HttpGet("{SLSREF}")]
        public List<siparislerDetay> GetDetaySevksiz(int SLSREF) => new SiparisProvider().DetaySevksiz(SLSREF);

        [Yetkili, HttpGet("{SLSREF}")]
        public List<siparislerDetay> GetDetaySevkli(int SLSREF) => new SiparisProvider().DetaySevkli(SLSREF);

        [Yetkili, HttpGet("{SLSREF}")]
        public List<siparislerDetay> GetDetaySevkliAktarilmis(int SLSREF) => new SiparisProvider().DetaySevkliAktarilmis(SLSREF);

        [Yetkili, HttpGet("{SLSREF}")]
        public List<siparisler> GetSevksiz(int SLSREF) => new SiparisProvider().Sevksiz(SLSREF);

        [Yetkili, HttpGet("{GMREF}")]
        public List<siparisler> GetSevksizGMREF(int GMREF) => new SiparisProvider().SevksizByGmref(GMREF);

        [Yetkili, HttpGet("{SLSREF}")]
        public List<siparisler> GetSevkli(int SLSREF) => new SiparisProvider().Sevkli(SLSREF);

        [Yetkili, HttpGet("{GMREF}")]
        public List<siparisler> GetSevkliGMREF(int GMREF) => new SiparisProvider().SevkliByGmref(GMREF);

        [Yetkili, HttpGet("{SLSREF}")]
        public List<siparisler> GetSevkliAktarilmis(int SLSREF) => new SiparisProvider().SevkliAktarilmis(SLSREF);

        [Yetkili, HttpGet("{GMREF}")]
        public List<siparisler> GetSevkliAktarilmisGMREF(int GMREF) => new SiparisProvider().SevkliAktarilmisByGmref(GMREF);

        [Yetkili, HttpGet("{SLSREF}")]
        public List<siparisler> GetBakiyeler(int SLSREF) => new SiparisProvider().BakiyeSiparisler(SLSREF);

        [Yetkili, HttpGet("{GMREF}")]
        public List<siparisler> GetBakiyelerGMREF(int GMREF) => new SiparisProvider().BakiyeSiparislerByGmref(GMREF);

        [Yetkili, HttpPost]
        public string BakiyeOlustur([FromBody]List<SevkKaydet> sks) => new SiparisProvider().BakiyeKalanOlustur(sks);

        [Yetkili, HttpPost]
        public string BakiyeIptal([FromBody] List<SevkKaydet> sks) => new SiparisProvider().BakiyedenKaldir(sks);

        [Yetkili, HttpPost]
        public string DetaySevkKaydet([FromBody]List<SevkKaydet> sevkkaydet) => new SiparisProvider().DetaySevkKaydet(sevkkaydet);

        [Yetkili, HttpPost]
        public string SevkKaydet([FromBody]List<SevkKaydet> sevkkaydet) => new SiparisProvider().SevkKaydet(sevkkaydet);

        [Yetkili, HttpPost]
        public JsonResult SevkKamyon([FromBody] List<SevkKaydet> sevkkaydet) => new SiparisProvider().SevkKamyon(sevkkaydet);

        [Yetkili, HttpPost]
        public ContentResult DetaySevkAktar([FromBody] List<SevkKaydet> sevkkaydet) => new SiparisProvider().DetaySevkAktar(sevkkaydet);

        [Yetkili, HttpPost]
        public FileStreamResult SevkAktar([FromBody] List<SevkKaydet> sevkkaydet) => new SiparisProvider().SevkAktar(sevkkaydet);

        /*[Yetkisiz, HttpPost]
        public FileStreamResult SevkAktar2([FromBody] List<SevkKaydet> sevkkaydet) => new SiparisProvider().SevkAktar(sevkkaydet);*/

        [Yetkili, HttpPost]
        public string SevkIptal([FromBody] List<SevkKaydet> sevkiptal) => new SiparisProvider().SevkIptal(sevkiptal);

        [Yetkili, HttpGet("{SiparisID}")]
        public string SevkSil(int SiparisID) => new SiparisProvider().SevksizOnaydanGeri(SiparisID);

        [Yetkili, HttpGet("{Slsref}")]
        public string SevkTamami(int SLSREF) => new SiparisProvider().SevkTamami(SLSREF);

        /*[Yetkisiz, HttpGet("{SIPID}")]
        public int bakiyeref(int SIPID) => new SiparisProvider().GetBakiyeRef(SIPID);*/
    }
}
