using Sultanlar.DbObj.Internet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class RutProvider
    {
        internal List<rutlar> Rutlar(int Slsref) => new rutlar().GetObjects(Slsref);

        internal List<rutResimler> RutResimler(int Slsref, int Smref, int Tip, int Tur, int Yil, int Ay)
        {
            object slsref = Slsref == 0 ? (object)DBNull.Value : Slsref;
            object smref = Smref == 0 ? (object)DBNull.Value : Smref;
            object tip = Tip == 0 ? (object)DBNull.Value : Tip;
            object tur = Tur == 0 ? (object)DBNull.Value : Tur;
            object ay = Ay == 0 ? (object)DBNull.Value : Ay;

            return new rutResimler().GetObjects(slsref, smref, tip, tur, Yil, ay);
        }
    }
}
