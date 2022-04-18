using Microsoft.Extensions.Caching.Memory;
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
        private IMemoryCache _memoryCache;

        internal List<satisTemsilcileri> Saticilar(string uyeid, bool tumu, IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;

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
                /*List<satisTemsilcileriSefler> altlar = new satisTemsilcileriSefler().GetObjects(musteri.intSLSREF);

                if (altlar.Count == 0)
                    return new List<satisTemsilcileri> { new satisTemsilcileri(musteri.intSLSREF).GetObject() };

                for (int i = 0; i < altlar.Count; i++)
                    donendeger.Add(new satisTemsilcileri(0, altlar[i].altSLSREF, "", altlar[i].Alt.SATTEM));*/



                List<satisTemsilcileri> sattem = CacheControl("SatTems", 30, CacheItemPriority.Normal);
                List<satisTemsilcileriSefler> hepsi = CacheControl1("SatTemSefs", 30, CacheItemPriority.Normal);
                var ustler = hepsi.Where(x => x.ustSLSREF == musteri.intSLSREF).Select(x => x.altSLSREF);
                donendeger = sattem.Where(y => ustler.Contains(y.SLSMANREF)).ToList();

                return donendeger;
            }
            else if (musteri.tintUyeTipiID == 1) // müşteri ise
            {

            }

            return new satisTemsilcileri().GetObjects();
        }

        public List<satisTemsilcileri> CacheControl(string cacheName, int Minutes, CacheItemPriority Priority)
        {
            List<satisTemsilcileri> sattems;
            if (!_memoryCache.TryGetValue(cacheName, out sattems))
            {
                sattems = new satisTemsilcileri().GetObjects();
                var cacheExpOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(Minutes),
                    Priority = Priority
                };

                _memoryCache.Set(cacheName, sattems, cacheExpOptions);
            }

            return sattems;
        }

        public List<satisTemsilcileriSefler> CacheControl1(string cacheName, int Minutes, CacheItemPriority Priority)
        {
            List<satisTemsilcileriSefler> sefler;
            if (!_memoryCache.TryGetValue(cacheName, out sefler))
            {
                sefler = new satisTemsilcileriSefler().GetObjects();
                var cacheExpOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(Minutes),
                    Priority = Priority
                };

                _memoryCache.Set(cacheName, sefler, cacheExpOptions);
            }

            return sefler;
        }
    }
}
