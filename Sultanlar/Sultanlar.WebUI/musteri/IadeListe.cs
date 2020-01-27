using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WebUI.musteri
{
    public class IadeListe : System.Collections.CollectionBase
    {
        // Alanlar
        public int _IadeID;
        public int _MusteriID;
        public int _SMREF;

        // Constracter
        public IadeListe(int MusteriID, int SMREF, bool veritabaninayaz)
        {
            this._MusteriID = MusteriID;
            this._SMREF = SMREF;

            if (veritabaninayaz)
            {
                Iadeler iade = new Iadeler(MusteriID, SMREF, DateTime.Now, 0, false,
                    DateTime.Now, " ;;; ;;; ");
                iade.DoInsert();
                this._IadeID = iade.pkIadeID;
            }
        }

        // Özellikler
        public int MusteriID { get { return this._MusteriID; } set { value = this._MusteriID; } }
        public int SMREF { get { return this._SMREF; } set { value = this._SMREF; } }
        public IadeDetayi this[int index]
        {
            get { return (IadeDetayi)this.List[index]; }
            set { this.List[index] = value; }
        }
        public System.Collections.IList Items
        {
            get { return this.List; }
        }
        public decimal ToplamTutar
        {
            get
            {
                decimal Toplam = 0;

                foreach (IadeDetayi idet in this.List)
                {
                    Toplam += idet._Miktar * idet._BirimFiyat;
                }

                return Toplam;
            }
        }
        
        // Metodlar
        /// <summary>
        /// Normal ekleme , ürün eğer en düşük miktarında ise daha eksiltilemeyeceğinden return true olacak
        /// </summary>
        public bool Add(int UrunID, int Miktar)
        {
            foreach (IadeDetayi idet in this.List)
            {
                if (idet._UrunID == UrunID)
                {
                    if (Miktar != 0)
                    {
                        if ((idet._Miktar + Miktar) <= 0)
                        {
                            return true;
                        }

                        idet._Miktar += Miktar;
                    }

                    // veritabaninda guncelle:
                    IadelerDetay ilerdet = IadelerDetay.GetObjectByIadelerDetayID(idet._IadeDetayID);
                    ilerdet.intMiktar = idet._Miktar;
                    ilerdet.DoUpdate();
                    return false;
                }
            }

            if (Miktar != 0)
            {
                string UrunAdi = Urunler.GetProductName(UrunID, true);

                IadeDetayi idet = new IadeDetayi(UrunID, UrunAdi, Miktar, 0);

                // veritabanina ekle:
                IadelerDetay ilerdet = new IadelerDetay(this._IadeID, UrunID, UrunAdi, Miktar, 0);
                ilerdet.DoInsert();
                idet._IadeDetayID = ilerdet.pkIadeDetayID;

                this.List.Add(idet);
            }

            return false;
        }
        /// <summary>
        /// Veritabanından gelen iadeyi bu classa yazıyoruz o yüzden veritabanına ekleme olmayacak
        /// </summary>
        public void Add(int UrunID, string UrunAdi, int Miktar, decimal BirimFiyat, long IadeDetayID)
        {
            if (Miktar != 0)
            {
                IadeDetayi idet = new IadeDetayi(UrunID, UrunAdi, Miktar, BirimFiyat);
                idet._IadeDetayID = IadeDetayID;
                this.List.Add(idet);
            }
        }
        /// <summary>
        /// Yeni miktar belirlemek için kullanıyoruz, miktar += yenimiktar değil miktar = yenimiktar
        /// </summary>
        public void Update(long IadeDetayID, int YeniMiktar)
        {
            foreach (IadeDetayi idet in this.List)
            {
                if (idet._IadeDetayID == IadeDetayID)
                {
                    if (YeniMiktar != 0)
                    {
                        idet._Miktar = YeniMiktar;
                    }

                    // veritabaninda guncelle:
                    IadelerDetay ilerdet = IadelerDetay.GetObjectByIadelerDetayID(idet._IadeDetayID);
                    ilerdet.intMiktar = idet._Miktar;
                    ilerdet.DoUpdate();
                    return;
                }
            }
        }
        /// <summary>
        /// Normal iade kaldırma
        /// </summary>
        public void Remove(long IadeDetayID)
        {
            foreach (IadeDetayi idet in this.List)
            {
                if (idet._IadeDetayID == IadeDetayID)
                {
                    // veritabanindan cikar:
                    IadelerDetay ilerdet = IadelerDetay.GetObjectByIadelerDetayID(idet._IadeDetayID);
                    ilerdet.DoDelete();

                    List.Remove(idet);

                    return;
                }
            }
        }
        /// <summary>
        /// IadeDetayi sil
        /// </summary>
        public void Remove(IadeDetayi idet)
        {
            // veritabanindan cikar:
            IadelerDetay ilerdet = IadelerDetay.GetObjectByIadelerDetayID(idet._IadeDetayID);
            ilerdet.DoDelete();

            List.Remove(idet);
        }
        /// <summary>
        /// Veritabanından iadeyi ve o iadeye ait iadelerdetay lari silmek için
        /// </summary>
        public void DeleteIadeIadelerDetayFromDB()
        {
            foreach (IadeDetayi idet in this.List)
                IadelerDetay.DoDelete(idet._IadeDetayID);
            Iadeler.DoDelete(this._IadeID);
        }
        /// <summary>
        /// Veritabanından da iadeliste den de iade(ler)detay lari silmek için
        /// </summary>
        public void DeleteIadelerDetay(bool veritabanindanda)
        {
            if (veritabanindanda)
                foreach (IadeDetayi idet in this.List)
                    IadelerDetay.DoDelete(idet._IadeDetayID);

            List.Clear();
        }
        /// <summary>
        /// buraya yeni alan açmaya üşendiğim için
        /// </summary>
        public void AciklamaGuncelle(string Aciklama1, string Aciklama2, string Aciklama3)
        {
            Iadeler iade = Iadeler.GetObjectsByIadeID(this._IadeID);

            string[] aciklamalar = iade.strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None);
            aciklamalar[0] = Aciklama1;
            aciklamalar[1] = Aciklama2;
            aciklamalar[2] = Aciklama3;
            iade.strAciklama = aciklamalar[0] + ";;;" + aciklamalar[1] + ";;;" + aciklamalar[2];

            iade.DoUpdate();
        }
    }
}