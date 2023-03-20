using System;
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
    //[Yetkili]
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

        [HttpPost]
        public string Kaydet([FromBody]IadeKaydet iadekaydet) => new IadeProvider().IadeKaydet(iadekaydet);

        [HttpPost("{bayikod}/{musteri}")]
        public string DisKaydet(string bayikod, string musteri, [FromBody]XmlDocument icerik) => new Internet.GenelController().WcfPostTo("http://www.ittihadteknoloji.com.tr/wcf/bayiservis.svc/web/xml/Iade?bayikod=" + bayikod + "&musteri=" + musteri, "application/soap+xml", icerik);
    }
}
