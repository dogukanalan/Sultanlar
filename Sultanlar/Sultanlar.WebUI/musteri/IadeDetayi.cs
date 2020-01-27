using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WebUI.musteri
{
    public class IadeDetayi : IDisposable
    {
        // Alanlar
        public long _IadeDetayID;
        public int _UrunID;
        public string _UrunAdi;
        public int _Miktar;
        public decimal _BirimFiyat;

        // Özellikler
        public long IadeDetayID { get { return this._IadeDetayID; } set { value = this._IadeDetayID; } }
        public int UrunID { get { return this._UrunID; } set { value = this._UrunID; } }
        public string UrunAdi { get { return this._UrunAdi; } set { value = this._UrunAdi; } }
        public int Miktar { get { return this._Miktar; } set { value = this._Miktar; } }
        public decimal BirimFiyat { get { return this._BirimFiyat; } set { value = this._BirimFiyat; } }
        public string Ad { get { return this._UrunAdi; } }

        public double KDV { get { return Urunler.GetProductKDV(this._UrunID, true); } }

        // Constracter lar
        public IadeDetayi(int UrunID, string UrunAdi, int Miktar, decimal BirimFiyat)
        {
            this._UrunID = UrunID;
            this._UrunAdi = UrunAdi;
            this._Miktar = Miktar;
            this._BirimFiyat = BirimFiyat;
        }

        // Dispose
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        // Guncelle
        public void Update()
        {
            IadelerDetay ilerdet = IadelerDetay.GetObjectByIadelerDetayID(this._IadeDetayID);
            ilerdet.intUrunID = this._UrunID;
            ilerdet.strUrunAdi = this._UrunAdi;
            ilerdet.intMiktar = this._Miktar;
            ilerdet.mnFiyat = 0; //this._BirimFiyat
            ilerdet.DoUpdate();
        }
    }
}