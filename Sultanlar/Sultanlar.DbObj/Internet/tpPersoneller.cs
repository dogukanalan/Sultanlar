using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class tpPersonelBaglantilari : DbObj
    {

    }

    public class tpPersoneller : DbObj
    {

    }

    public class tpPersonelTurleri : DbObj
    {
        public int pkID { get; set; }
        public string strTur { get; set; } 
        public string strAciklama { get; set; }
        public tpPersonelTurleri() { }
        public tpPersonelTurleri(byte pkID) { this.pkID = pkID; }
        public tpPersonelTurleri(string strTur, string strAciklama)
        {
            this.strTur = strTur;
            this.strAciklama = strAciklama;
        }
    }
}
