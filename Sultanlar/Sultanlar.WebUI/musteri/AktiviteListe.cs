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
    public class AktiviteListe : System.Collections.CollectionBase
    {
        // Alanlar
        public int _AktiviteID;
        public int _MusteriID;
        public int _SMREF;
        public short _FiyatTipi;
        public int _AnlasmaID;
        public int _AktiviteTipiID;
        public DateTime _AktiviteBaslangic;
        public DateTime _AktiviteBitis;
        public string _Aciklama1;
        public string _Aciklama2;
        public string _Aciklama3;
        public string _Aciklama4;
        public decimal _TahSabitBedel;
        public decimal _YegSabitBedel;
        public decimal _TahHedefCiro;
        public decimal _YegHedefCiro;
        public decimal _AktiviteKarZarar;
        public double _AktiviteKarZararYuzde;
        public int _DonemYil;
        public int _DonemAy;

        // Constracter
        public AktiviteListe(int MusteriID, int SMREF, short FiyatTipi, int AktiviteTipi, bool veritabaninayaz)
        {
            this._MusteriID = MusteriID;
            this._SMREF = SMREF;
            this._FiyatTipi = FiyatTipi;
            this._AktiviteTipiID = AktiviteTipi;

            //int sonanlasmaid = FiyatTipi == 25 ? Anlasmalar.GetSonAnlasmaID(SMREF, DateTime.Now, "1") : Anlasmalar.GetSonAnlasmaID(CariHesaplar.GetGMREFBySMREF(SMREF), DateTime.Now, "2");
            //if (sonanlasmaid != 0)
            //{
            //    Anlasmalar anlasma = Anlasmalar.GetObject(sonanlasmaid);
            //    this._AnlasmaID = anlasma.pkID;
            //    this._TahSabitBedel = anlasma.TAHTumBedellerToplami + anlasma.mnTAHAnlasmaDisiBedeller;
            //    this._YegSabitBedel = anlasma.YEGTumBedellerToplami + anlasma.mnYEGAnlasmaDisiBedeller;
            //    this._TahHedefCiro = anlasma.mnTAHToplamCiro;
            //    this._YegHedefCiro = anlasma.mnYEGToplamCiro;
            //}

            if (veritabaninayaz)
            {
                Aktiviteler aktivite = new Aktiviteler();

                //if (sonanlasmaid != 0)
                //{
                //    Anlasmalar anlasma = Anlasmalar.GetObject(sonanlasmaid);

                //    aktivite = new Aktiviteler(MusteriID, SMREF, FiyatTipi, anlasma.pkID, this._AktiviteTipiID, DateTime.Now, DateTime.Now, false, DateTime.Now,
                //        DateTime.Now, "", "", "", "", anlasma.TAHTumBedellerToplami + anlasma.mnTAHAnlasmaDisiBedeller, 
                //        anlasma.TAHTumBedellerToplami + anlasma.mnTAHAnlasmaDisiBedeller, 
                //        anlasma.mnTAHToplamCiro, anlasma.mnYEGToplamCiro, 0, 0);
                //}
                //else
                //{
                    aktivite = new Aktiviteler(MusteriID, SMREF, FiyatTipi, 0, this._AktiviteTipiID, DateTime.Now, DateTime.Now, false, DateTime.Now,
                        DateTime.Now, "", "", "", "", 0, 0, 0, 0, 0, 0);
                //}

                aktivite.DoInsert();
                this._AktiviteID = aktivite.pkID;
            }
        }

        // Özellikler
        public int AktiviteID { get { return this._AktiviteID; } set { value = this._AktiviteID; } }
        public int MusteriID { get { return this._MusteriID; } set { value = this._MusteriID; } }
        public int SMREF { get { return this._SMREF; } set { value = this._SMREF; } }
        public short FiyatTipi { get { return this._FiyatTipi; } set { value = this._FiyatTipi; } }
        public int AnlasmaID { get { return this._AnlasmaID; } set { value = this._AnlasmaID; } }
        public int AktiviteTipiID { get { return this._AktiviteTipiID; } set { value = this._AktiviteTipiID; } }
        public DateTime AktiviteBaslangic { get { return this._AktiviteBaslangic; } set { value = this._AktiviteBaslangic; } }
        public DateTime AktiviteBitis { get { return this._AktiviteBitis; } set { value = this._AktiviteBitis; } }
        public string Aciklama1 { get { return this._Aciklama1; } set { value = this._Aciklama1; } }
        public string Aciklama2 { get { return this._Aciklama2; } set { value = this._Aciklama2; } }
        public string Aciklama3 { get { return this._Aciklama3; } set { value = this._Aciklama3; } }
        public string Aciklama4 { get { return this._Aciklama4; } set { value = this._Aciklama4; } }
        public decimal TahSabitBedel { get { return this._TahSabitBedel; } set { value = this._TahSabitBedel; } }
        public decimal YegSabitBedel { get { return this._YegSabitBedel; } set { value = this._YegSabitBedel; } }
        public decimal TahHedefCiro { get { return this._TahHedefCiro; } set { value = this._TahHedefCiro; } }
        public decimal YegHedefCiro { get { return this._YegHedefCiro; } set { value = this._YegHedefCiro; } }
        public double AktiviteKarZararYuzde { get { return this._AktiviteKarZararYuzde; } set { value = this._AktiviteKarZararYuzde; } }
        public AktiviteDetayi this[int index]
        {
            get { return (AktiviteDetayi)this.List[index]; }
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

                foreach (AktiviteDetayi aktdet in this.List)
                {
                    Toplam += aktdet._SatisHedefi * Convert.ToDecimal(Urunler.GetKoliAdedi(aktdet._UrunID)) * aktdet.DusulmusBirimFiyatKDVli;
                }

                return Toplam;
            }
        }
        /// <summary>
        /// Normal ekleme, ürün eğer en düşük miktarında ise daha eksiltilemeyeceğinden return true olacak
        /// </summary>
        public bool Add(int UrunID, int SatisHedefi, decimal BirimFiyatKDVli, bool farklisatira)
        {
            if (!farklisatira)
            {
                foreach (AktiviteDetayi aktdet in this.List)
                {
                    if (aktdet._UrunID == UrunID)
                    {
                        if (SatisHedefi != 0)
                        {
                            if ((aktdet._SatisHedefi + SatisHedefi) <= 0)
                            {
                                return true;
                            }

                            aktdet._SatisHedefi += SatisHedefi;
                            aktdet._KoliAdet = Convert.ToInt32(Urunler.GetKoliAdedi(aktdet._UrunID));
                        }

                        // veritabaninda guncelle:
                        AktivitelerDetay aktlerdet = AktivitelerDetay.GetObject(aktdet._AktiviteDetayID);
                        aktlerdet.strSatisHedefi = aktdet._SatisHedefi.ToString();
                        aktlerdet.intKoliAdet = Convert.ToInt32(Urunler.GetKoliAdedi(aktdet._UrunID));
                        aktlerdet.mnAksiyonFiyati = aktdet._AksiyonFiyati;
                        aktlerdet.mnDusulmusBirimFiyatKDVli = aktdet.DusulmusBirimFiyatKDVli;
                        aktlerdet.flCiroPrimDonusYuzde = aktdet.CiroPrimDonusYuzde;
                        aktlerdet.mnBayiMaliyet = aktdet.BayiMaliyet;
                        aktlerdet.flEkIsk = aktdet._EkIsk;
                        aktlerdet.strAciklama1 = aktdet.FatAltIsk.ToString("N1");
                        aktlerdet.strAciklama2 = aktdet.FatAltCiro.ToString("N1");
                        aktlerdet.strAciklama3 = aktdet.PazIsk.ToString("N1");
                        aktlerdet.mnTutar = aktdet.Tutar;
                        aktlerdet.mnToplam = aktdet._SatisHedefi * Convert.ToDecimal(Urunler.GetKoliAdedi(aktdet._UrunID)) * aktdet.DusulmusBirimFiyatKDVli;
                        aktlerdet.DoUpdate();
                        return false;
                    }
                }
            }

            if (SatisHedefi != 0)
            {
                string UrunAdi = Urunler.GetProductName(UrunID, true);

                AktiviteDetayi aktdet = new AktiviteDetayi(UrunID, UrunAdi, SatisHedefi, 0, BirimFiyatKDVli);
                aktdet._KoliAdet = Convert.ToInt32(Urunler.GetKoliAdedi(aktdet._UrunID));
                aktdet._DonemYil = this._DonemYil;
                aktdet._DonemAy = this._DonemAy;

                // veritabanina ekle:
                AktivitelerDetay aktlerdet = new AktivitelerDetay(this._AktiviteID, UrunID, UrunAdi, 0, BirimFiyatKDVli,
                    0, 0, "", 0, 0, 0, 0, 0, 0, 0, "", "", "", "", "");
                aktlerdet.DoInsert();
                aktdet._AktiviteDetayID = aktlerdet.pkID;

                aktlerdet.strSatisHedefi = aktdet._SatisHedefi.ToString();
                aktlerdet.intKoliAdet = Convert.ToInt32(Urunler.GetKoliAdedi(aktdet._UrunID));
                aktlerdet.mnAksiyonFiyati = aktdet._AksiyonFiyati;
                aktlerdet.mnDusulmusBirimFiyatKDVli = aktdet.DusulmusBirimFiyatKDVli;
                aktlerdet.flCiroPrimDonusYuzde = aktdet.CiroPrimDonusYuzde;
                aktlerdet.mnBayiMaliyet = aktdet.BayiMaliyet;
                aktlerdet.flEkIsk = aktdet._EkIsk;
                aktlerdet.strAciklama1 = aktdet.FatAltIsk.ToString("N1");
                aktlerdet.strAciklama2 = aktdet.FatAltCiro.ToString("N1");
                aktlerdet.strAciklama3 = aktdet.PazIsk.ToString("N1");
                aktlerdet.mnTutar = aktdet.Tutar;
                aktlerdet.mnToplam = aktdet._SatisHedefi * Convert.ToDecimal(Urunler.GetKoliAdedi(aktdet._UrunID)) * aktdet.DusulmusBirimFiyatKDVli;
                aktlerdet.DoUpdate();

                //aktdet._AksiyonFiyati = BirimFiyatKDVli - ((BirimFiyatKDVli / 100) * Convert.ToDecimal(aktdet.FatAltIsk));

                this.List.Add(aktdet);
            }

            return false;
        }
        /// <summary>
        /// Veritabanından gelen listeye detay satır eklemek için
        /// </summary>
        public void Add(long AktiviteDetayID)
        {
            AktivitelerDetay aktlerdet = AktivitelerDetay.GetObject(AktiviteDetayID);
            AktiviteDetayi aktdet = new AktiviteDetayi(aktlerdet.intUrunID, aktlerdet.strUrunAdi, aktlerdet.intKoliAdet, aktlerdet.mnBirimFiyatKDVli,
                aktlerdet.mnAksiyonFiyati, aktlerdet.flMusteriKarYuzde, Convert.ToInt32(aktlerdet.strSatisHedefi), aktlerdet.mnTutar,
                aktlerdet.flEkIsk, aktlerdet.flCiroPrimDonusYuzde, aktlerdet.mnBayiMaliyet, aktlerdet.mnDusulmusBirimFiyatKDVli,
                aktlerdet.flKarZararYuzde, aktlerdet.mnToplam, aktlerdet.strAciklama1, aktlerdet.strAciklama2, aktlerdet.strAciklama3,
                aktlerdet.strAciklama4);
            aktdet._AktiviteDetayID = aktlerdet.pkID;
            aktdet._DonemYil = this._DonemYil;
            aktdet._DonemAy = this._DonemAy;
            this.List.Add(aktdet);
        }
        /// <summary>
        /// Yeni miktar belirlemek için kullanıyoruz, miktar += yenimiktar değil miktar = yenimiktar
        /// </summary>
        public void Update(long AktiviteDetayID, int YeniSatisHedefi, decimal AksiyonFiyati, double EkIsk)
        {
            foreach (AktiviteDetayi aktdet in this.List)
            {
                if (aktdet._AktiviteDetayID == AktiviteDetayID)
                {
                    if (YeniSatisHedefi != 0)
                    {
                        aktdet._SatisHedefi = YeniSatisHedefi;
                    }
                    aktdet._AksiyonFiyati = AksiyonFiyati;
                    aktdet._EkIsk = EkIsk;

                    // veritabaninda guncelle:
                    AktivitelerDetay aktlerdet = AktivitelerDetay.GetObject(aktdet._AktiviteDetayID);
                    aktlerdet.strSatisHedefi = aktdet._SatisHedefi.ToString();
                    aktlerdet.intKoliAdet = Convert.ToInt32(Urunler.GetKoliAdedi(aktdet._UrunID));
                    aktlerdet.mnAksiyonFiyati = aktdet._AksiyonFiyati;
                    aktlerdet.mnDusulmusBirimFiyatKDVli = aktdet.DusulmusBirimFiyatKDVli;
                    aktlerdet.flCiroPrimDonusYuzde = aktdet.CiroPrimDonusYuzde;
                    aktlerdet.mnBayiMaliyet = aktdet.BayiMaliyet;
                    aktlerdet.flEkIsk = aktdet._EkIsk;
                    aktlerdet.strAciklama1 = aktdet.FatAltIsk.ToString("N1");
                    aktlerdet.strAciklama2 = aktdet.FatAltCiro.ToString("N1");
                    aktlerdet.strAciklama3 = aktdet.PazIsk.ToString("N1");
                    aktlerdet.mnTutar = aktdet.Tutar; // olması gerekebilir: Convert.ToDecimal(Convert.ToDouble(aktdet._DusulmusBirimFiyatKDVli) - ((Convert.ToDouble(aktdet._DusulmusBirimFiyatKDVli) / 100) * aktdet.CiroPrimDonusYuzde));
                    aktlerdet.mnToplam = aktdet._SatisHedefi * Convert.ToDecimal(Urunler.GetKoliAdedi(aktdet._UrunID)) * aktdet.DusulmusBirimFiyatKDVli;
                    aktlerdet.DoUpdate();
                    return;
                }
            }
        }
        /// <summary>
        /// Normal kaldırma
        /// </summary>
        public void Remove(long AktiviteDetayID)
        {
            foreach (AktiviteDetayi aktdet in this.List)
            {
                if (aktdet._AktiviteDetayID == AktiviteDetayID)
                {
                    // veritabanindan cikar:
                    AktivitelerDetay aktlerdet = AktivitelerDetay.GetObject(aktdet._AktiviteDetayID);
                    aktlerdet.DoDelete();

                    //SiparislerDetay.DoDeleteISKs(sipdet._SiparisDetayID); trigger yapıyor

                    List.Remove(aktdet);

                    return;
                }
            }
        }
        //
        //
        public void DeleteSiparislerDetay(bool veritabanindanda)
        {
            if (veritabanindanda)
                foreach (AktiviteDetayi aktdet in this.List)
                    AktivitelerDetay.DoDelete(aktdet._AktiviteDetayID);

            List.Clear();
            ToplamTutarGuncelle();
        }
        //
        //
        public void ToplamTutarGuncelle()
        {
            Aktiviteler aktivite = Aktiviteler.GetObject(this._AktiviteID);
            //aktivite.mnToplamTutar = this.ToplamTutar;
            aktivite.DoUpdate();
        }
        /// <summary>
        /// Veritabanından aktivite ve o aktiviteye ait aktivitedetay lari silmek için
        /// </summary>
        public void DeleteSiparisSiparislerDetayFromDB()
        {
            foreach (AktiviteDetayi aktdet in this.List)
                AktivitelerDetay.DoDelete(aktdet._AktiviteDetayID);
            Aktiviteler.DoDelete(this._AktiviteID);
        }
        /// <summary>
        /// üşengeçlik, aktivite başlangıç ve bitişi de güncelliyor
        /// </summary>
        public void AciklamaGuncelle(bool AktiviteTarihi)
        {
            Aktiviteler aktivite = Aktiviteler.GetObject(this._AktiviteID);
            if (AktiviteTarihi)
            {
                aktivite.dtAktiviteBaslangic = this._AktiviteBaslangic;
                aktivite.dtAktiviteBitis = this._AktiviteBitis;
            }
            aktivite.strAciklama1 = this._Aciklama1;
            aktivite.strAciklama2 = this._Aciklama2;
            aktivite.strAciklama3 = this._Aciklama3;
            aktivite.strAciklama4 = this._Aciklama4;
            aktivite.flAktiviteKarZararYuzde = this._AktiviteKarZararYuzde;
            aktivite.DoUpdate();
        }
    }
}