using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sultanlar.Class;
using Sultanlar.DatabaseObject;

namespace Sultanlar.WebAPI.Controllers.Internet
{
    [Produces("application/json")]
    public class GenelController : Controller
    {
        [HttpGet, Yetkili]
        [Route("internet/[controller]/[action]/{cookieRTicket}")]
        public IEnumerable<string> Ticket(string cookieRTicket)
        {
            DateTime yeni = cookieRTicket == "true" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59) : DateTime.Now.AddMinutes(60);
            string yeniticket = Sifreleme.Encrypt(yeni.ToString());
            string yeniticket2 = Sifreleme.Encrypt("ri8jtDmDQca=", yeni.ToString());

            return new string[] { yeniticket, yeniticket2 };
        }

        [HttpGet, Yetkili]
        [Route("internet/[controller]/[action]")]
        public string Auth() => "";

        [HttpGet, Yetkili]
        [Route("internet/[controller]/[action]/{yer}/{json}")]
        public string HataEkle(string yer, string json)
        {
            byte[] data = System.Convert.FromBase64String(json);
            string base64Decoded = System.Text.ASCIIEncoding.ASCII.GetString(data);

            Hatalar.DoInsert(base64Decoded, "api " + yer);
            return base64Decoded;
        }
    }
}
