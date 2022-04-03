using Sultanlar.Class;
using Sultanlar.DbObj.Internet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class SaticiProvider
    {
        internal List<satisTemsilcileri> Saticilar(string uyeid, bool tumu)
        {
            musteriler musteri = new musteriler(Convert.ToInt32(Sifreleme.Decrypt(uyeid))).GetObject();

            if (musteri.tintUyeTipiID == 2) // yönetici ise
            {
                List<satisTemsilcileri> sattem = new satisTemsilcileri().GetObjects();
                if (tumu)
                    sattem.Insert(0, new satisTemsilcileri(0, 0, "", "Tümü"));
                return sattem;
            }
            else if (musteri.tintUyeTipiID == 4 || musteri.tintUyeTipiID == 6) // satici ise
            {
                List<satisTemsilcileri> donendeger = new List<satisTemsilcileri>();
                List<satisTemsilcileriSefler> altlar = new satisTemsilcileriSefler().GetObjects(musteri.intSLSREF);

                if (altlar.Count == 0)
                    return new List<satisTemsilcileri> { new satisTemsilcileri(musteri.intSLSREF).GetObject() };

                for (int i = 0; i < altlar.Count; i++)
                    donendeger.Add(new satisTemsilcileri(0, altlar[i].altSLSREF, "", altlar[i].Alt.SATTEM));

                return donendeger;
            }
            else if (musteri.tintUyeTipiID == 1) // müşteri ise
            {

            }

            return new satisTemsilcileri().GetObjects();
        }
    }
}
