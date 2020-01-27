using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WebUI.musteri
{
    public class SiparisDetayi : IDisposable
    {
        // Alanlar
        public long _SiparisDetayID;
        public int _UrunID;
        public string _UrunAdi;
        public int _Miktar;
        public decimal _BirimFiyat;
        public Guid _KamKartRef;
        public bool _KampanyaHediye;
        public Guid _KamSatirRef;
        public string _MiktarTur;
        public string _Brutler;
        public double _ISK1;
        public double _ISK2;
        public double _ISK3;
        public double _ISK4;
        public double _FIYAT;

        // Constracter lar
        public SiparisDetayi(int UrunID, string UrunAdi, int Miktar, decimal BirimFiyat, Guid KamKartRef, bool KampanyaHediye, Guid KamSatirRef, string MiktarTur)
        {
            this._UrunID = UrunID;
            this._UrunAdi = UrunAdi;
            this._Miktar = Miktar;
            //if (KampanyaHediye)
            //    this._BirimFiyat = 0;
            //else
                this._BirimFiyat = BirimFiyat;
            this._KamKartRef = KamKartRef;
            this._KampanyaHediye = KampanyaHediye;
            this._KamSatirRef = KamSatirRef;
            this._MiktarTur = MiktarTur;
        }
        public SiparisDetayi(int UrunID, string UrunAdi, int Miktar, decimal BirimFiyat, Guid KamKartRef, bool KampanyaHediye, Guid KamSatirRef, string MiktarTur,
            double ISK1, double ISK2, double ISK3, double ISK4)
        {
            this._UrunID = UrunID;
            this._UrunAdi = UrunAdi;
            this._Miktar = Miktar;
            //if (KampanyaHediye)
            //    this._BirimFiyat = 0;
            //else
            this._BirimFiyat = BirimFiyat;
            this._KamKartRef = KamKartRef;
            this._KampanyaHediye = KampanyaHediye;
            this._KamSatirRef = KamSatirRef;
            this._MiktarTur = MiktarTur;
            this._ISK1 = ISK1;
            this._ISK2 = ISK2;
            this._ISK3 = ISK3;
            this._ISK4 = ISK4;
        }

        // Özellikler
        public long SiparisDetayID { get { return this._SiparisDetayID; } set { value = this._SiparisDetayID; } }
        public int UrunID { get { return this._UrunID; } set { value = this._UrunID; } }
        public string UrunAdi { get { return this._UrunAdi; } set { value = this._UrunAdi; } }
        public int Miktar { get { return this._Miktar; } set { value = this._Miktar; } }
        public decimal BirimFiyat { get { return this._BirimFiyat; } set { value = this._BirimFiyat; } }
        public Guid KamKartRef { get { return this._KamKartRef; } set { value = this._KamKartRef; } }
        public bool KampanyaHediye { get { return this._KampanyaHediye; } set { value = this._KampanyaHediye; } }
        public Guid KamSatirRef { get { return this._KamSatirRef; } set { value = this._KamSatirRef; } }
        public string MiktarTur { get { return this._MiktarTur; } set { value = this._MiktarTur; } }
        public string Ad
        {
            get
            {
                string bas = string.Empty;
                string son = string.Empty;

                if (this._KamKartRef != Guid.Empty && !this._KampanyaHediye)
                {
                    bas = "<strong>";
                    son = "</strong>";
                }
                else if (this._KampanyaHediye)
                {
                    bas = "<i>";
                    son = "</i>";
                }

                //return bas + Urunler.GetProductName(this._UrunID) + son;
                return bas + this._UrunAdi + son;
            }
        }
        public string Brutler { get { return this._Brutler; } set { value = this._Brutler; } }
        public double ISK1 { get { return this._ISK1; } set { value = this._ISK1; } }
        public double ISK2 { get { return this._ISK2; } set { value = this._ISK2; } }
        public double ISK3 { get { return this._ISK3; } set { value = this._ISK3; } }
        public double ISK4 { get { return this._ISK4; } set { value = this._ISK4; } }
        public double FIYAT { get { return this._FIYAT; } set { value = this._FIYAT; } }
        public double KOLIDONUSUM { get { return this._MiktarTur == "KI" ? this._Miktar : Convert.ToDouble(this._Miktar) / Urunler.GetKoliAdedi(this._UrunID); } }

        // Dispose
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        // Guncelle
        public void Update()
        {
            SiparislerDetay siplerdet = SiparislerDetay.GetObjectBySiparislerDetayID(this._SiparisDetayID);
            siplerdet.intUrunID = this._UrunID;
            siplerdet.strUrunAdi = this._UrunAdi;
            siplerdet.intMiktar = this._Miktar;
            siplerdet.mnFiyat = this._BirimFiyat;
            siplerdet.unKampanyaKart = this._KamKartRef;
            siplerdet.blKampanyaHediye = this._KampanyaHediye;
            siplerdet.unKampanyaSatir = this._KamSatirRef;
            siplerdet.strMiktarTur = this._MiktarTur;
            siplerdet.DoUpdate();

            SiparislerDetay.DoInsertISKs(this._SiparisDetayID, this._FIYAT, this._ISK1, this._ISK2, this._ISK3, this._ISK4, 0, 0, 0, 0, 0, 0);
        }
    }
}