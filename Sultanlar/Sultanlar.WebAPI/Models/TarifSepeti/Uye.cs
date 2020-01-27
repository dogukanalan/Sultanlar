using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Models.TarifSepeti
{
    public class Uye
    {
        public int pkID { get; set; }
        public string strAd { get; set; }
        public string strSoyad { get; set; }
        public string strEposta { get; set; }
        public string strSifre { get; set; }
        public DateTime dtDogum { get; set; }
        public DateTime dtTarih { get; set; }
        public bool blPasif { get; set; }

        public Uye()
        {

        }

        public Uye(int pkID, string strAd, string strSoyad, string strEposta, string strSifre, DateTime dtDogum, DateTime dtTarih, bool blPasif)
        {
            this.pkID = pkID;
            this.strAd = strAd;
            this.strSoyad = strSoyad;
            this.strEposta = strEposta;
            this.strSifre = strSifre;
            this.dtDogum = dtDogum;
            this.dtTarih = dtTarih;
            this.blPasif = blPasif;
        }
    }
}
