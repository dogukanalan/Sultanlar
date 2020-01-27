using Sultanlar.DbObj.Internet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class BorcAlacakProvider
    {
        internal List<borcAlacakRaporu> BorcAlacak(int Slsref) => new borcAlacakRaporu().GetObjects(Slsref);
    }
}
