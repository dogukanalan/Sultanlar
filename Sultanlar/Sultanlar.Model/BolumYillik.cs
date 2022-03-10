using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.Model
{
    public class BolumYillik
    {
        public BolumYillik(string BOLUM, int AY, int KOLI) 
        {
            this.BOLUM = BOLUM;
            this.AY = AY;
            this.KOLI = KOLI;
        }
        public string BOLUM { get; set; }
        public int AY { get; set; }
        public int KOLI { get; set; }
    }
}
