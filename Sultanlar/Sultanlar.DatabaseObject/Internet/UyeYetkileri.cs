using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Sultanlar.DatabaseObject.Internet
{
    public class UyeYetkileri
    {
        //
        //
        //
        // Alanlar:
        //
        private int _MusteriID;
        private ArrayList _FiyatTipler;
        private ArrayList _GrupKodlar;
        private ArrayList _OzelKodlar;
        //
        //
        //
        // Constracter lar:
        //
        private UyeYetkileri(int MusteriID, ArrayList FiyatTipler, ArrayList GrupKodlar, ArrayList OzelKodlar)
        {
            this._MusteriID = MusteriID;
            this._FiyatTipler = FiyatTipler;
            this._GrupKodlar = GrupKodlar;
            this._OzelKodlar = OzelKodlar;
        }
        //
        //
        public UyeYetkileri(int MusteriID)
        {
            this._MusteriID = MusteriID;
            this._FiyatTipler = new ArrayList();
            this._OzelKodlar = new ArrayList();
            this._GrupKodlar = new ArrayList();
            int UyeGrubuID = Musteriler.GetUyeGrubuByMusteriID(this._MusteriID);

            if (UyeGrubuID == 5) // özel grup
            {
                UyeFiyatTipleri.GetObjectOnlyFiyatTipler(this._FiyatTipler, this._MusteriID, true);
                UyeOzelKodlar.GetObjectOnlyOzelKodlar(this._OzelKodlar, this._MusteriID, true);
                UyeGrupKodlar.GetObjectOnlyGrupKodlar(this._GrupKodlar, this._MusteriID, true);
            }
            else
            {
                UyeGrubuFiyatTipleri.GetObjectOnlyFiyatTipler(this._FiyatTipler, UyeGrubuID, true);
                UyeGrubuOzelKodlar.GetObjectOnlyOzelKodlar(this._OzelKodlar, UyeGrubuID, true);
                UyeGrubuGrupKodlar.GetObjectOnlyGrupKodlar(this._GrupKodlar, UyeGrubuID, true);
            }
        }
        //
        //
        //
        // Özellikler:
        //
        public int MusteriID 
        { 
            get 
            { 
                return this._MusteriID; 
            } 
        }
        //
        //
        public ArrayList FiyatTipler 
        { 
            get 
            { 
                return this._FiyatTipler; 
            } 
            set 
            { 
                this._FiyatTipler = value; 
            } 
        }
        //
        //
        public ArrayList GrupKodlar
        {
            get
            {
                return this._GrupKodlar;
            }
            set
            {
                this._GrupKodlar = value;
            }
        }
        //
        //
        public ArrayList OzelKodlar
        {
            get
            {
                return this._OzelKodlar;
            }
            set
            {
                this._OzelKodlar = value;
            }
        }
        //
        //
        //
        // Yoketme metodu:
        //
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        //
        //
        //
        // ToString:
        //
        public override string ToString()
        {
            return this._MusteriID.ToString();
        }
        //
        //
        //
        // Metodlar:
        //
        private Musteriler GetMusteri()
        {
            return Musteriler.GetMusteriByID(this._MusteriID);
        }
    }
}
