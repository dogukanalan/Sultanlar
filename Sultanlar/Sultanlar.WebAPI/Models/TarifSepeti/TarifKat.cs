using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Models.TarifSepeti
{
    public class TarifKat
    {
        public int pkID { get; set; }
        public int intTarifID { get; set; }
        public int intKategoriID { get; set; }

        public TarifKat()
        {

        }

        public TarifKat(int pkID, int intTarifID, int intKategoriID)
        {
            this.pkID = pkID;
            this.intTarifID = intTarifID;
            this.intKategoriID = intKategoriID;
        }
    }
}
