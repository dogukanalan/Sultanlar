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
    public class MesajController : Controller
    {
        [HttpGet, Route("internet/[controller]/[action]/{ID}")]
        public mesajlar GetAlinan(int ID) => new MesajProvider().AlinanMesaj(ID);

        [HttpGet, Route("internet/[controller]/[action]/{ID}")]
        public mesajlar GetGonderilen(int ID) => new MesajProvider().GonderilenMesaj(ID);

        [HttpGet, Route("internet/[controller]/[action]/{ID}/{GelGit}")]
        public mesajlar Get(int ID, int GelGit)
        {
            if (GelGit == 1)
                return new MesajProvider().GonderilenMesaj(ID);
            else
                return new MesajProvider().AlinanMesaj(ID);
        }

        [HttpPost, Route("internet/[controller]/[action]/{DepartmanID}/{MusteriID}/{GelGit}")]
        public DtAjaxResponse Getir(int DepartmanID, string MusteriID, int GelGit, [FromBody]DataTableAjaxPostModel req) => new MesajProvider().Mesajlar(DepartmanID, MusteriID, GelGit == 1, req);

        [HttpPost, Route("internet/[controller]/[action]")]
        public string Gonder([FromBody]Mesaj mesaj) => new MesajProvider().MesajGonder(mesaj);

        [HttpGet, Route("internet/[controller]/[action]/{ID}/{GelGit}")]
        public string Sil(int ID, int GelGit)
        {
            if (GelGit == 1)
                return new MesajProvider().GonderilenSil(ID, GelGit != 1);
            else
                return new MesajProvider().AlinanSil(ID, GelGit != 1);
        }

        [HttpGet, Route("internet/[controller]/[action]/{ID}/{GelGit}")]
        public string Oku(int ID, int GelGit)
        {
            if (GelGit == 1)
                return new MesajProvider().GonderilenOkundu(ID);
            else
                return new MesajProvider().AlinanOkundu(ID);
        }

        [HttpGet, Route("internet/[controller]/[action]/{musteri}")]
        public int GetMesajCount(string musteri) => new MesajProvider().GonderilenOkunmayanMesajSayisi(musteri);
    }
}
