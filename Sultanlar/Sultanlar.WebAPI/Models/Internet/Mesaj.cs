using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Models.Internet
{
    public class Mesaj
    {
        public string musteri { get; set; }
        public byte departman { get; set; }
        public string konu { get; set; }
        public string icerik { get; set; }
    }
}
