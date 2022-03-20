using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.Model.Dashboard
{
    public class SatisHedefVgb
    {
        public SatisHedefVgb(string MUSTERI, int HEDEF, int SATIS, int BEKLEYEN, double VGB, double VGBGUN)
        {
            this.MUSTERI = MUSTERI;
            this.HEDEF = HEDEF;
            this.SATIS = SATIS;
            this.BEKLEYEN = BEKLEYEN;
            this.VGB = VGB;
            this.VGBGUN = VGBGUN;
        }
        public string MUSTERI { get; set; }
        public int HEDEF { get; set; }
        public int SATIS { get; set; }
        public int BEKLEYEN { get; set; }
        public double VGB { get; set; }
        public double VGBGUN { get; set; }
    }
}
