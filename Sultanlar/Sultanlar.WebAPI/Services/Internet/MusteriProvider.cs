using Sultanlar.Class;
using Sultanlar.DbObj.Internet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class MusteriProvider
    {
        internal musteriler Musteri(string id) => new musteriler(Convert.ToInt32(Sifreleme.Decrypt(id))).GetObject();

        internal string MusteriGuncelle(string id, string ad, string soyad, string telefon, string sifre)
        {
            musteriler musteri = new musteriler(Convert.ToInt32(Sifreleme.Decrypt(id))).GetObject();
            musteri.strAd = ad;
            musteri.strSoyad = soyad;
            musteri.strTelefon = telefon;
            if (sifre != "")
                musteri.binSifre = sifre;
            musteri.DoUpdate();
            return "";
        }
    }
}
