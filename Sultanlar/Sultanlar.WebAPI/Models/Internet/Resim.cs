using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Models.Internet
{
    public class SDEResim
    {
        public int smref { get; set; }
        public int tip { get; set; }
        public string musteri { get; set; }
        public int tur { get; set; }
        public string rut { get; set; }
        public int ziyaret { get; set; }
        public string resim { get; set; }
        public string aciklama { get; set; }
        public string not { get; set; }
    }
}
