using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Models.Internet
{
    public class Cari
    {
        public int SMREF { get; set; }
        public int GMREF { get; set; }
        public int SLSREF { get; set; }
        public int SATKOD { get; set; }
        public string SATKOD1 { get; set; }
        public string MUSTERI { get; set; }
        public string SUBE { get; set; }

        public Cari()
        {

        }

        public Cari(int SMREF, int GMREF, int SLSREF, int SATKOD, string SATKOD1, string MUSTERI, string SUBE)
        {
            this.SMREF = SMREF;
            this.GMREF = GMREF;
            this.SLSREF = SLSREF;
            this.SATKOD = SATKOD;
            this.SATKOD1 = SATKOD1;
            this.MUSTERI = MUSTERI;
            this.SUBE = SUBE;
        }
    }
}
