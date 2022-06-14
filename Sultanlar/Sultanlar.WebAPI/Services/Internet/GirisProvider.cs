using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sultanlar.WebAPI.Models.Internet;
using Sultanlar.Class;
using Sultanlar.DbObj.Internet;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class GirisProvider
    {
        internal Giris GirisYap(GirisGet giris)
        {
            musteriler musteri = new musteriler().ValidateCustomer(giris.strEposta, giris.strSifre);
            if (musteri.pkMusteriID == 0 || musteri.blPasif)
                return new Giris();
            string datetime = giris.blBirGun ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59).ToString() : DateTime.Now.AddMinutes(60).ToString();
            Giris donendeger = new Giris(
                Sifreleme.Encrypt(musteri.pkMusteriID.ToString()), Sifreleme.Encrypt(musteri.isSDE ? "8" : musteri.tintUyeTipiID.ToString()), Sifreleme.Encrypt(musteri.intGMREF.ToString()), musteri.intSLSREF.ToString(), Sifreleme.Encrypt(datetime), Sifreleme.Encrypt("ri8jtDmDQca=", datetime), musteri.pkMusteriID);
            return donendeger;
        }
    }
}
