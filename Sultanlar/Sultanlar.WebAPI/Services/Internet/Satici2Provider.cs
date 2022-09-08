using Sultanlar.Class;
using Sultanlar.DbObj.Internet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class Satici2Provider
    {
        internal string Ekle(satisTemsilcileri sattem)
        {
            sattem.DoInsert();
            return "";
        }
        internal string Guncelle(satisTemsilcileri sattem)
        {
            sattem.DoUpdate();
            return "";
        }
        internal string Sil(satisTemsilcileri sattem)
        {
            sattem.DoUpdate();
            return "";
        }
        internal satisTemsilcileri Getir(string uyeid)
        {
            musteriler musteri = new musteriler(Convert.ToInt32(Sifreleme.Decrypt(uyeid))).GetObject();
            return new satisTemsilcileri(musteri.intSLSREF).GetObject2();
        }
        internal List<satisTemsilcileri> Getir()
        {
            return new satisTemsilcileri().GetObjects2();
        }
    }
}
