using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Models.Internet
{
    public class Giris
    {
        public string pkID { get; set; }
        public string intUyeTipiID { get; set; }
        public string intGMREF { get; set; }
        public string intSLSREF { get; set; }
        public string token { get; set; }
        public string tokenCr { get; set; }
        public int musteri { get; set; }
        public bool taksit { get; set; }
        public string tur { get; set; }

        public Giris()
        {

        }

        public Giris(string pkID, string intUyeTipiID, string intGMREF, string intSLSREF, string token, string tokenCr, int musteri, bool taksit, string tur)
        {
            this.pkID = pkID;
            this.intUyeTipiID = intUyeTipiID;
            this.intGMREF = intGMREF;
            this.intSLSREF = intSLSREF;
            this.token = token;
            this.tokenCr = tokenCr;
            this.musteri = musteri;
            this.taksit = taksit;
            this.tur = tur;
        }
    }

    public class GirisGet
    {
        public string strEposta { get; set; }
        public string strSifre { get; set; }
        public bool blBirGun { get; set; }

        public GirisGet()
        {

        }

        public GirisGet(string strEposta, string strSifre, bool blBirGun)
        {
            this.strEposta = strEposta;
            this.strSifre = strSifre;
            this.blBirGun = blBirGun;
        }
    }
}
