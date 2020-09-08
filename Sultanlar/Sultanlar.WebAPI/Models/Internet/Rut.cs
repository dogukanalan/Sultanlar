using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Models.Internet
{
    public class Rut
    {
        public string ID { get; set; }
        public string Ruut { get; set; }
        public string Gun { get; set; }
        public string BasTar { get; set; }
        public string BitTar { get; set; }
        public Rut(string ID, string Ruut, string Gun, string BasTar, string BitTar)
        {
            this.ID = ID;
            this.Ruut = Ruut;
            this.Gun = Gun;
            this.BasTar = BasTar;
            this.BitTar = BitTar;
        }
    }
}
