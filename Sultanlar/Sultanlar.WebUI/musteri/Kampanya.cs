using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WebUI.musteri
{
    public class Kampanya
    {
        // Alanlar
        public Guid _KamKartRef;
        public int _Miktar;

        // Constracter
        public Kampanya(Guid KamKartRef, int Miktar)
        {
            this._KamKartRef = KamKartRef;
            this._Miktar = Miktar;
        }

        // Özellikler
        public Guid KamKartRef { get { return this._KamKartRef; } set { value = this._KamKartRef; } }
        public int Miktar { get { return this._Miktar; } set { value = this._Miktar; } }

        public void DoInsert(SiparisListe siplist)
        {
            DataTable dt = new DataTable();
            Kampanyalar.GetAnaUrunlerForKampanyaDoInsert(dt, this._KamKartRef);

            for (int j = 0; j < dt.Rows.Count; j++)
            {
                int urunid = Convert.ToInt32(dt.Rows[j]["ITEMREF"]);
                int miktar = Convert.ToInt32(dt.Rows[j]["MIKTAR"]) * this._Miktar;
                decimal birimfiyat = Kampanyalar.GetProductPrice(urunid, Convert.ToInt16(dt.Rows[j]["TIP"]));
                Guid kamkartref = Guid.Parse(dt.Rows[j]["KAMKARTREF"].ToString());
                Guid kamsatirref = Guid.Parse(dt.Rows[j]["KAMPANASATREF"].ToString());

                siplist.Add(urunid, miktar, birimfiyat, kamkartref, false, kamsatirref, false);
            }



            dt = new DataTable();
            Kampanyalar.GetHediyeUrunlerForKampanyaDoInsert(dt, this._KamKartRef);

            for (int j = 0; j < dt.Rows.Count; j++)
            {
                int urunid = Convert.ToInt32(dt.Rows[j]["ITEMREF"]);
                int miktar = Convert.ToInt32(dt.Rows[j]["MIKTAR"]) * this._Miktar;
                decimal birimfiyat = Urunler.GetProductPrice(urunid, Convert.ToInt16(dt.Rows[j]["TIP"]));
                //decimal birimfiyat = 0; // gidip bidaha fiyatını alıp getirmesin
                Guid kamkartref = Guid.Parse(dt.Rows[j]["KAMKARTREF"].ToString());
                Guid kamsatirref = Guid.Parse(dt.Rows[j]["KAMPHEDSATREF"].ToString());

                siplist.Add(urunid, miktar, birimfiyat, kamkartref, true, kamsatirref, false);
            }

            siplist.ToplamTutarGuncelle(true);
        }
    }
}