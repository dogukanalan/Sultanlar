using Sultanlar.DbObj.Internet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class FiyatProvider
    {
        internal List<fiyatlar> Fiyatlar() => new fiyatlar().GetObjects();

        internal List<fiyatlar> Fiyatlar(int TIP) => new fiyatlar().GetObjects(TIP);

        internal List<fiyatlar> FiyatlarAll(int TIP) => new fiyatlar().GetObjectsAll(TIP);

        internal List<fiyatlar> FiyatlarAktif(int TIP)
        {
            List<fiyatlar> fiys = new fiyatlar().GetObjects(TIP);
            List<fiyatlar> donendeger = new List<fiyatlar>();
            for (int i = 0; i < fiys.Count; i++)
            {
                if (!fiys[i].malzeme.MALACIK.EndsWith("&"))
                {
                    donendeger.Add(fiys[i]);
                }
            }
            return donendeger;
        }

        internal fiyatlar Fiyat(int TIP, int ITEMREF) => new fiyatlar(TIP, ITEMREF).GetObject();

        internal List<fiyatlarTp> FiyatlarTP() => new fiyatlarTp().GetObjects();

        internal List<fiyatlarTp> FiyatlarTP(int YIL, int AY, int GUN, int TIP) => new fiyatlarTp().GetObjects(YIL, AY, GUN, TIP);

        internal fiyatlarTp FiyatTP(int YIL, int AY, int TIP, int ITEMREF) => new fiyatlarTp(YIL, AY, TIP, ITEMREF).GetObject();

        internal List<fiyatlar> FiyatlarVy(int GMREF) => new fiyatlar().GetObjectsVY(GMREF);
    }
}
