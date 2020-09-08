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
    [Route("internet/[controller]")]
    public class MusteriController : Controller
    {
        [HttpGet("{id}")]
        public musteriler Get(int id) => new MusteriProvider().Musteri(id);

        [HttpPost]
        public string Post([FromBody]Musteri musteri) => new MusteriProvider().MusteriGuncelle(musteri.id, musteri.ad, musteri.soyad, musteri.telefon, musteri.sifre);
    }
}
