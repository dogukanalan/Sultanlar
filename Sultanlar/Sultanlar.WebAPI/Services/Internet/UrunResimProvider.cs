using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sultanlar.DbObj.Internet;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class UrunResimProvider
    {
        internal List<urunResimleri> UrunResimleri() => new urunResimleri().GetObjects();

        internal List<urunResimleri> UrunResimleri(int ITEMREF) => new urunResimleri().GetObjects(ITEMREF);
    }
}
