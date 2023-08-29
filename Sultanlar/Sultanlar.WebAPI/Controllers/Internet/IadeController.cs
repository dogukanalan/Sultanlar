using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sultanlar.DbObj.Internet;
using Sultanlar.WebAPI.Models.Internet;
using Sultanlar.WebAPI.Services.Internet;

namespace Sultanlar.WebAPI.Controllers
{
    [Yetkili]
    [Produces("application/json")]
    [Route("internet/[controller]/[action]")]
    public class IadeController : Controller
    {
        [HttpGet("{IadeID}")]
        public iadeler Get(int IadeID) => new IadeProvider().Iade(IadeID);

        [HttpPost]
        public DtAjaxResponse Getir([FromBody]IadeGet iadeget) => new IadeProvider().Iadeler(iadeget);

        [HttpPost]
        public string Onay([FromBody]IadeOnay iadeonay) => new IadeProvider().IadeOnay(iadeonay.IadeID);

        [HttpPost]
        public string Kopya([FromBody]IadeKopya iadekopya) => new IadeProvider().IadeKopyala(iadekopya);

        [HttpGet("{IadeID}")]
        public string Sil(int IadeID) => new IadeProvider().IadeSil(IadeID);

        [HttpGet("{IadeID}")]
        public string Gerial(int IadeID) => new IadeProvider().IadeBasa(IadeID);

        [HttpGet("{IadeID}")]
        public string Bitir(int IadeID) => new IadeProvider().IadeSona(IadeID);

        [HttpGet("{IadeID}")]
        public string Reddet(int IadeID) => new IadeProvider().IadRede(IadeID);

        [HttpGet("{IadeID}")]
        public string FiyatlandirmaBitir(int IadeID) => new IadeProvider().IadeFiyatlandirildi(IadeID);

        [HttpPost("{Neden}")]
        public string Kaydet([FromBody]IadeKaydet iadekaydet, string Neden) => new IadeProvider().IadeKaydet(iadekaydet, Neden);

        [HttpPost("{bayikod}/{musteri}/{neden}")]
        public string DisKaydet(string bayikod, string musteri, string neden, [FromBody] XmlDocument icerik)
        {
            string donendeger = new Internet.GenelController().WcfPostTo("http://www.ittihadteknoloji.com.tr/wcf/bayiservis.svc/web/xml/Iade?bayikod=" + bayikod + "&musteri=" + musteri + "&neden=" + neden, "application/soap+xml", icerik);

            return donendeger;
        }

        [HttpGet("{SMREF}/{ITEMREF}")]
        public List<iadeFiyatAdet> FiyatAdetlerGet(int SMREF, int ITEMREF) => new IadeProvider().IadeFiyatAdetler(SMREF, ITEMREF);

        [HttpGet("{ID}")]
        public iadeFiyatAdet FiyatAdetGet(int ID) => new IadeProvider().IadeFiyatAdet(ID);

        [HttpGet("{IadeDetayID}")]
        public iadelerDetay GetIadeDetay(int IadeDetayID) => new IadeProvider().IadeDetay(IadeDetayID);

        [HttpPost]
        public string SetIadeDetay([FromBody]iadelerDetay detay) => new IadeProvider().IadeDetayGuncelle(detay);

        [HttpGet("{ID}")]
        public string FiyatAdetSil(int ID) => new IadeProvider().IadeFiyatSil(ID);

        [HttpGet("{IadeDetayID}")]
        public string FiyatAdetlerSil(long IadeDetayID) => new IadeProvider().IadeFiyatlarSil(IadeDetayID);

        [HttpGet("{IadeDetayID}/{SiparisDetayID}/{Miktar}")]
        public string FiyatAdetEkle(long IadeDetayID, long SiparisDetayID, int Miktar) => new IadeProvider().IadeFiyatKaydet(IadeDetayID, SiparisDetayID, Miktar);

        [HttpGet("{ID}/{IadeDetayID}/{SiparisDetayID}/{Miktar}")]
        public string FiyatAdetGuncelle(long ID, long IadeDetayID, long SiparisDetayID, int Miktar) => new IadeProvider().IadeFiyatDuzenle(ID, IadeDetayID, SiparisDetayID, Miktar);
    }
}
