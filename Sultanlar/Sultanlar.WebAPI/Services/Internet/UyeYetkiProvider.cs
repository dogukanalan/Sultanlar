using Sultanlar.DbObj.Internet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class UyeYetkiProvider
    {
        internal uyeYetkileri UyeYetkileri(int MusteriID)
        {
            return new uyeYetkileri(MusteriID);
        }
    }
}
