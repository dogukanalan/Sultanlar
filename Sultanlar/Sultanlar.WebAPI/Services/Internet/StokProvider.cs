using Sultanlar.DbObj.Internet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class StokProvider
    {
        internal List<bayiStokRaporu> BayiStokRapor(int Slsref, int Smref)
        {
            object smref = Smref == 0 ? DBNull.Value : (object)Smref;
            return new bayiStokRaporu().GetObjects(Slsref, smref);
        }
    }
}
