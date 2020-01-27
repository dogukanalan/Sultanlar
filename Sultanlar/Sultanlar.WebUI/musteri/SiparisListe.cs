using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WebUI.musteri
{
    /// <summary>
    /// veritabaninayaz degiskeni, siparisin siparisler tablosundan ve icindeki urunlerin siparislerdetay tablosundan gelirken, sepetlisteye eklenirken tekrar yazmamasi icin engelleme amacli olusturuldu
    /// </summary>
    public class SiparisListe : System.Collections.CollectionBase
    {
        // Alanlar
        public int _SiparisID;
        public int _MusteriID;
        public int _SMREF;
        public short _FiyatTipi;
        public int _TKSREF;
        //public string _Aciklama1;
        //public string _Aciklama2;
        //public string _Aciklama3;
        //public string _Aciklama4;

        // Constracter
        public SiparisListe(int MusteriID, int SMREF, short FiyatTipi, bool veritabaninayaz)
        {
            this._MusteriID = MusteriID;
            this._SMREF = SMREF;
            this._FiyatTipi = FiyatTipi;
            this._TKSREF = 147; // sipariş açılırken 0 gün vade olması için

            if (veritabaninayaz)
            {
                Siparisler siparis = new Siparisler(MusteriID, SMREF, FiyatTipi, DateTime.Now, this.ToplamTutar, false,
                    this._TKSREF, DateTime.Now, " ;;; ;;; ");
                siparis.DoInsert();
                this._SiparisID = siparis.pkSiparisID;
            }
        }

        // Özellikler
        public int MusteriID { get { return this._MusteriID; } set { value = this._MusteriID; } }
        public int SMREF { get { return this._SMREF; } set { value = this._SMREF; } }
        public short FiyatTipi { get { return this._FiyatTipi; } set { value = this._FiyatTipi; } }
        public int TKSREF { get { return this._TKSREF; } set { value = this._TKSREF; } }
        //public string Aciklama1 { get { return this._Aciklama1; } set { value = this._Aciklama1; } }
        //public string Aciklama2 { get { return this._Aciklama2; } set { value = this._Aciklama2; } }
        //public string Aciklama3 { get { return this._Aciklama3; } set { value = this._Aciklama3; } }
        //public string Aciklama4 { get { return this._Aciklama4; } set { value = this._Aciklama4; } }
        public SiparisDetayi this[int index]
        {
            get { return (SiparisDetayi)this.List[index]; }
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

                foreach (SiparisDetayi sipdet in this.List)
                {
                    if (!sipdet._KampanyaHediye) // kampanya hediye ürünlerin kampanyasız fiyatlarını veritabanına yazmaya başladıktan sonra koydum
                        Toplam += sipdet._Miktar * sipdet._BirimFiyat;
                }

                return Toplam;
            }
        }
        public int OrtalamaVade
        {
            get
            {
                decimal vadetoplam = 0;
                foreach (SiparisDetayi sipdet in this.List)
                {
                    int vade = 0;
                    if (!sipdet._KampanyaHediye) // kampanya hediye ürünlerin kampanyasız fiyatlarını veritabanına yazmaya başladıktan sonra koydum
                        vade = Urunler.GetProductVade(sipdet._UrunID, this._FiyatTipi);
                    vadetoplam += Convert.ToInt32(sipdet._Miktar) * Convert.ToDecimal(sipdet._BirimFiyat) * vade;
                }

                if (this.ToplamTutar == 0)
                    return 0;

                return Convert.ToInt32(Math.Round(vadetoplam / this.ToplamTutar));
            }
        }
        public double ToplamKoli
        {
            get
            {
                double Toplam = 0;

                foreach (SiparisDetayi sipdet in this.List)
                {
                    Toplam += sipdet.KOLIDONUSUM;
                }

                return Toplam;
            }
        }
        
        // Metodlar
        /// <summary>
        /// Normal ekleme , kampanya (veya ürün) eğer en düşük miktarında ise daha eksiltilemeyeceğinden return true olacak
        /// </summary>
        public bool Add(int UrunID, int Miktar, decimal BirimFiyat, Guid KamKartRef, bool KampanyaHediye, Guid KamSatirRef, bool farklisatira)
        {
            if (!farklisatira)
            {
                foreach (SiparisDetayi sipdet in this.List)
                {
                    if (sipdet._UrunID == UrunID && sipdet._KamKartRef == KamKartRef &&
                        sipdet._KampanyaHediye == KampanyaHediye && sipdet._KamSatirRef == KamSatirRef)
                    {
                        if (Miktar != 0)
                        {
                            if ((sipdet._Miktar + Miktar) <= 0)
                            {
                                return true;
                            }

                            sipdet._Miktar += Miktar;
                        }

                        // veritabaninda guncelle:
                        SiparislerDetay siplerdet = SiparislerDetay.GetObjectBySiparislerDetayID(sipdet._SiparisDetayID);
                        siplerdet.intMiktar = sipdet._Miktar;
                        siplerdet.DoUpdate();
                        return false;
                    }
                }
            }

            if (Miktar != 0)
            {
                string UrunAdi = Urunler.GetProductName(UrunID, true);

                SiparisDetayi sipdet = new SiparisDetayi(UrunID, UrunAdi, Miktar, BirimFiyat, KamKartRef, KampanyaHediye, KamSatirRef, "ST");

                // veritabanina ekle:
                SiparislerDetay siplerdet = new SiparislerDetay(this._SiparisID, UrunID, UrunAdi, Miktar, BirimFiyat, KamKartRef, KampanyaHediye, KamSatirRef, sipdet._MiktarTur);
                siplerdet.DoInsert();
                sipdet._SiparisDetayID = siplerdet.pkSiparisDetayID;

                double[] isks = Urunler.GetProductDiscountsAndPrice(UrunID, Siparisler.GetObjectsBySiparisID(SiparislerDetay.GetObjectBySiparislerDetayID(sipdet._SiparisDetayID).intSiparisID).sintFiyatTipiID);
                sipdet._FIYAT = isks[4];
                sipdet._ISK1 = isks[0];
                sipdet._ISK2 = isks[1];
                sipdet._ISK3 = isks[2];
                sipdet._ISK4 = isks[3];

                this.List.Add(sipdet);
            }

            return false;
        }
        /// <summary>
        /// Veritabanından gelen siparisi bu classa yazıyoruz o yüzden veritabanına ekleme olmayacak
        /// </summary>
        public void Add(int UrunID, string UrunAdi, int Miktar, decimal BirimFiyat, Guid KamKartRef, bool KampanyaHediye, Guid KamSatirRef, string MiktarTur, long SiparisDetayID)
        {
            //foreach (SiparisDetayi sipdet in this.List)
            //{
            //    if (sipdet._UrunID == UrunID && sipdet._KamKartRef == KamKartRef && sipdet._KampanyaHediye == KampanyaHediye)
            //    {
            //        if (Miktar != 0)
            //        {
            //            sipdet._Miktar += Miktar;
            //        }

            //        sipdet._SiparisDetayID = SiparisDetayID;
            //        return;
            //    }
            //}

            if (Miktar != 0)
            {
                SiparisDetayi sipdet = new SiparisDetayi(UrunID, UrunAdi, Miktar, BirimFiyat, KamKartRef, KampanyaHediye, KamSatirRef, MiktarTur);
                sipdet._SiparisDetayID = SiparisDetayID;
                this.List.Add(sipdet);
            }
        }
        /// <summary>
        /// Veritabanından gelen siparisi bu classa yazıyoruz o yüzden veritabanına ekleme olmayacak
        /// </summary>
        public void Add(int UrunID, string UrunAdi, int Miktar, decimal BirimFiyat, Guid KamKartRef, bool KampanyaHediye, Guid KamSatirRef, string MiktarTur, long SiparisDetayID,
            double ISK1, double ISK2, double ISK3, double ISK4)
        {
            if (Miktar != 0)
            {
                SiparisDetayi sipdet = new SiparisDetayi(UrunID, UrunAdi, Miktar, BirimFiyat, KamKartRef, KampanyaHediye, KamSatirRef, MiktarTur, ISK1, ISK2, ISK3, ISK4);
                sipdet._SiparisDetayID = SiparisDetayID;
                this.List.Add(sipdet);
            }
        }
        /// <summary>
        /// Yeni miktar belirlemek için kullanıyoruz, miktar += yenimiktar değil miktar = yenimiktar
        /// </summary>
        public void Update(long SiparisDetayID, int YeniMiktar, decimal BirimFiyat, string MiktarTur)
        {
            foreach (SiparisDetayi sipdet in this.List)
            {
                if (sipdet._SiparisDetayID == SiparisDetayID)
                {
                    if (YeniMiktar != 0)
                    {
                        sipdet._Miktar = YeniMiktar;
                    }
                    sipdet._MiktarTur = MiktarTur;
                    sipdet._BirimFiyat = BirimFiyat;

                    // veritabaninda guncelle:
                    SiparislerDetay siplerdet = SiparislerDetay.GetObjectBySiparislerDetayID(sipdet._SiparisDetayID);
                    siplerdet.intMiktar = sipdet._Miktar;
                    siplerdet.mnFiyat = sipdet._BirimFiyat;
                    siplerdet.strMiktarTur = sipdet._MiktarTur;
                    siplerdet.DoUpdate();
                    return;
                }
            }
        }
        /// <summary>
        /// Yeni miktar belirlemek için kullanıyoruz, miktar += yenimiktar değil miktar = yenimiktar, F2
        /// </summary>
        public void Update(long SiparisDetayID, int YeniMiktar, decimal BirimFiyat, string MiktarTur, double ISK1, double ISK2, double ISK3, double ISK4, double FIYAT)
        {
            foreach (SiparisDetayi sipdet in this.List)
            {
                if (sipdet._SiparisDetayID == SiparisDetayID)
                {
                    if (YeniMiktar != 0)
                    {
                        sipdet._Miktar = YeniMiktar;
                    }
                    sipdet._MiktarTur = MiktarTur;
                    sipdet._BirimFiyat = BirimFiyat;
                    sipdet._FIYAT = FIYAT;
                    sipdet._ISK1 = ISK1;
                    sipdet._ISK2 = ISK2;
                    sipdet._ISK3 = ISK3;
                    sipdet._ISK4 = ISK4;

                    // veritabaninda guncelle:
                    SiparislerDetay siplerdet = SiparislerDetay.GetObjectBySiparislerDetayID(sipdet._SiparisDetayID);
                    siplerdet.intMiktar = sipdet._Miktar;
                    siplerdet.mnFiyat = sipdet._BirimFiyat;
                    siplerdet.strMiktarTur = sipdet._MiktarTur;
                    siplerdet.DoUpdate();

                    SiparislerDetay.DoInsertISKs(SiparisDetayID, FIYAT, ISK1, ISK2, ISK3, ISK4, 0, 0, 0, 0, 0, 0);
                    return;
                }
            }
        }
        /// <summary>
        /// Normal sipariş kaldırma, kampanyasatirref e gerek yok çünkü kampanyalı bir ürün ise o kamkartref e bağlı bütün kampanya ürünleri silinecek
        /// </summary>
        public void Remove(long SiparisDetayID, Guid KamKartRef)
        {
            if (KamKartRef != Guid.Empty) // kampanyadaki bir ürün silinirse bütün kampanya ürünleri silinmesi için
            {
                // veritabanindan cikar:
                SiparislerDetay.DoDelete(this._SiparisID, KamKartRef);

                int[] kaldirilacakIndexler = new int[List.Count];

                for (int i = 0; i < List.Count; i++)
                {
                    SiparisDetayi sipdet = (SiparisDetayi)List[i];

                    if (sipdet._KamKartRef == KamKartRef)
                        kaldirilacakIndexler[i] = 1;
                    else
                        kaldirilacakIndexler[i] = 0;
                }

                int j = 0;
                for (int i = 0; i < kaldirilacakIndexler.Length; i++)
                {
                    if (kaldirilacakIndexler[i] == 1)
                    {
                        List.RemoveAt(j);
                        j--;
                    }
                    j++;
                }

                return;
            }

            foreach (SiparisDetayi sipdet in this.List)
            {
                if (sipdet._SiparisDetayID == SiparisDetayID)
                {
                    // veritabanindan cikar:
                    SiparislerDetay siplerdet = SiparislerDetay.GetObjectBySiparislerDetayID(sipdet._SiparisDetayID);
                    siplerdet.DoDelete();

                    //SiparislerDetay.DoDeleteISKs(sipdet._SiparisDetayID); trigger yapıyor

                    List.Remove(sipdet);

                    return;
                }
            }
        }
        ///// <summary>
        ///// Fiyattipi değiştirilidiğinde önceki kampanyalar ve ürünler dahil herşey silineceği için bunu kullanıyoruz
        ///// </summary>
        //public void Remove(int UrunID)
        //{
        //    foreach (SiparisDetayi sipdet in this.List)
        //    {
        //        if (sipdet._UrunID == UrunID)
        //        {
        //            //// veritabanindan cikar:
        //            //SiparislerDetay siplerdet = SiparislerDetay.GetObjectBySiparislerDetayID(sipdet._SiparisDetayID);
        //            //siplerdet.DoDelete();

        //            List.Remove(sipdet);

        //            return;
        //        }
        //    }
        //}
        /// <summary>
        /// SiparisDetayi sil
        /// </summary>
        public void Remove(SiparisDetayi sipdet)
        {
            if (sipdet._KamKartRef != Guid.Empty) // bu sipdet bir kampanya ise hediyeleri de sil // ESKİ
            {
                foreach (SiparisDetayi sipdet1 in this.List)
                {
                    if (sipdet1._KamKartRef == sipdet._KamKartRef)
                    {
                        // veritabanindan cikar:
                        SiparislerDetay siplerdet1 = SiparislerDetay.GetObjectBySiparislerDetayID(sipdet1._SiparisDetayID);
                        siplerdet1.DoDelete();

                        List.Remove(sipdet1);
                        return;
                    }
                }
            }

            // veritabanindan cikar:
            SiparislerDetay siplerdet = SiparislerDetay.GetObjectBySiparislerDetayID(sipdet._SiparisDetayID);
            siplerdet.DoDelete();

            List.Remove(sipdet);
        }
        /// <summary>
        /// Veritabanında Siparişler de toplam tutar değişmesi için, birde tksref i ekledik her ürün hareketinde ort. vade veritabanına da yazılsın diye
        /// </summary>
        public void ToplamTutarGuncelle(bool vadeyide)
        {
            Siparisler siparis = Siparisler.GetObjectsBySiparisID(this._SiparisID);
            siparis.mnToplamTutar = this.ToplamTutar;

            if (vadeyide)
                if (!TaksitPlanlari.TaksitMi(this._TKSREF))
                    siparis.TKSREF = TaksitPlanlari.GetODMREF(this.OrtalamaVade);

            siparis.DoUpdate();
        }
        /// <summary>
        /// Veritabanından siparis i ve o siparişe ait siparislerdetay lari silmek için
        /// </summary>
        public void DeleteSiparisSiparislerDetayFromDB()
        {
            foreach (SiparisDetayi sipdet in this.List)
                SiparislerDetay.DoDelete(sipdet._SiparisDetayID);
            Siparisler.DoDelete(this._SiparisID);
        }
        /// <summary>
        /// Veritabanından da siparisliste den de siparis(ler)detay lari silmek için
        /// </summary>
        public void DeleteSiparislerDetay(bool veritabanindanda)
        {
            if (veritabanindanda)
                foreach (SiparisDetayi sipdet in this.List)
                        SiparislerDetay.DoDelete(sipdet._SiparisDetayID);

            List.Clear();
            ToplamTutarGuncelle(true);
        }
        /// <summary>
        /// Fiyat tipi veya taksit planı gibi sipariş kartında değişen bir bilgiyi veritabanından da değiştirmek için
        /// </summary>
        public void SiparisiVeritabanindaGuncelle()
        {
            Siparisler siparis = Siparisler.GetObjectsBySiparisID(this._SiparisID);
            siparis.sintFiyatTipiID = this._FiyatTipi;
            siparis.TKSREF = this._TKSREF;
            siparis.mnToplamTutar = this.ToplamTutar;
            siparis.DoUpdate();
        }
        /// <summary>
        /// buraya yeni alan açmaya üşendiğim için
        /// </summary>
        public void AciklamaGuncelle(string Aciklama1, string Aciklama2, string Aciklama3)
        {
            Siparisler siparis = Siparisler.GetObjectsBySiparisID(this._SiparisID);

            string[] aciklamalar = siparis.strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None);
            aciklamalar[0] = Aciklama1;
            aciklamalar[1] = Aciklama2;
            aciklamalar[2] = Aciklama3;
            siparis.strAciklama = aciklamalar[0] + ";;;" + aciklamalar[1] + ";;;" + aciklamalar[2];

            siparis.DoUpdate();
        }
    }
}