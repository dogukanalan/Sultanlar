using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Models.TarifSepeti
{
    public class Tarif
    {
        public int pkID { get; set; }
        public int intUyeID { get; set; }
        public Uye Uye { get; set; }
        public bool blOnay { get; set; }
        public string strBaslik { get; set; }
        public string strMalzemeler { get; set; }
        public string strHazirlanis { get; set; }
        public byte[] binResim { get; set; }
        public byte[] binResimUrunler { get; set; }
        public string strUrunlerLink { get; set; }
        public DateTime dtTarih { get; set; }
        public double OrtPuan { get; set; }
        public List<TarifKat> TarifKategoriler { get; set; }

        public Tarif()
        {

        }

        public Tarif(int pkID, int intUyeID, Uye Uye, bool blOnay, string strBaslik, string strMalzemeler, string strHazirlanis, byte[] binResim,
            byte[] binResimUrunler, string strUrunlerLink, DateTime dtTarih, double OrtPuan, List<TarifKat> TarifKategoriler)
        {
            this.pkID = pkID;
            this.intUyeID = intUyeID;
            this.Uye = Uye;
            this.blOnay = blOnay;
            this.strBaslik = strBaslik;
            this.strMalzemeler = strMalzemeler;
            this.strHazirlanis = strHazirlanis;
            this.binResim = binResim;
            this.binResimUrunler = binResimUrunler;
            this.strUrunlerLink = strUrunlerLink;
            this.dtTarih = dtTarih;
            this.OrtPuan = OrtPuan;
            this.TarifKategoriler = TarifKategoriler;
        }
    }

    public class TarifGet
    {
        public int katid { get; set; }
        public string aranan { get; set; }
        public int sonid { get; set; }
        public int kactane { get; set; }
        public string action { get; set; }
        public string uyeid { get; set; }
        public string urunid { get; set; }
        public string order { get; set; }
    }
}
