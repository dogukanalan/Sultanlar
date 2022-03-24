using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.Model.Dashboard
{
    public class SatisHedefBolge
    {
        public SatisHedefBolge(string UST, int HEDEF, int SATIS, int BEKLEYEN)
        {
            this.UST = UST;
            this.HEDEF = HEDEF;
            this.SATIS = SATIS;
            this.BEKLEYEN = BEKLEYEN;
        }
        public string UST { get; set; }
        public int HEDEF { get; set; }
        public int SATIS { get; set; }
        public int BEKLEYEN { get; set; }
    }
}
