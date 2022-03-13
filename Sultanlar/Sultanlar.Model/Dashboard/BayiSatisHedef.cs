using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.Model.Dashboard
{
    public class BayiSatisHedef
    {
        public BayiSatisHedef(string MUSTERI, int HEDEF, int SATIS)
        {
            this.MUSTERI = MUSTERI;
            this.HEDEF = HEDEF;
            this.SATIS = SATIS;
        }
        public string MUSTERI { get; set; }
        public int HEDEF { get; set; }
        public int SATIS { get; set; }
    }
}
