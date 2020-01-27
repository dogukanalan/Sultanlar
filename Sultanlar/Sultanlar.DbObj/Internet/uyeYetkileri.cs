using System;
using System.Collections.Generic;

namespace Sultanlar.DbObj.Internet
{
    public class uyeYetkileri
    {
        public List<uyeFiyatTipleri> FiyatTipleri;
        public List<uyeGrubuFiyatTipleri> GrupFiyatTipleri;

        public uyeYetkileri(int MusteriID)
        {
            FiyatTipleri = new uyeFiyatTipleri().GetObjectsByMusteriID(MusteriID);
            GrupFiyatTipleri = new uyeGrubuFiyatTipleri().GetObjectsByUyeGrupID(new musteriler(MusteriID).GetObject().intUyeGrupID);
        }
    }
}
