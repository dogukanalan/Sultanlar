using Sultanlar.Class;
using Sultanlar.DatabaseObject.Kenton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Services.TarifSepeti
{
    public class GirisProvider
    {
        public int GirisYap(string Eposta, string Sifre)
        {
            return Uyeler.Validate(Eposta, Sifreleme.Encrypt(Sifre));
        }
    }
}
