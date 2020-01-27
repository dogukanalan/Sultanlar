using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sultanlar.DatabaseObject.Internet;
using System.Data;

namespace Sultanlar.WebUI.musteri
{
    public class AktiviteDetayi : IDisposable
    {
        // Alanlar
        public long _AktiviteDetayID;
        public int _UrunID;
        public string _UrunAdi;
        public int _KoliAdet;
        public decimal _BirimFiyatKDVli;
        public decimal _AksiyonFiyati;
        public double _MusteriKarYuzde;
        public int _SatisHedefi;
        public decimal _Tutar;
        public double _EkIsk;
        public double _CiroPrimDonusYuzde;
        public decimal _BayiMaliyet;
        public decimal _DusulmusBirimFiyatKDVli;
        public double _KarZararYuzde;
        public decimal _Toplam;
        public string _Aciklama1;
        public string _Aciklama2;
        public string _Aciklama3;
        public string _Aciklama4;
        public int _DonemYil;
        public int _DonemAy;

        // Constracter lar
        public AktiviteDetayi(int UrunID, string UrunAdi, int KoliAdet, decimal BirimFiyatKDVli, decimal AksiyonFiyati, double MusteriKarYuzde,
            int SatisHedefi, decimal Tutar, double EkIsk, double CiroPrimDonusYuzde, decimal BayiMaliyet, decimal DusulmusBirimFiyatKDVli,
            double KarZararYuzde, decimal Toplam, string Aciklama1, string Aciklama2, string Aciklama3, string Aciklama4)
        {
            this._UrunID = UrunID;
            this._UrunAdi = UrunAdi;
            this._KoliAdet = KoliAdet;
            this._BirimFiyatKDVli = BirimFiyatKDVli;
            this._AksiyonFiyati = AksiyonFiyati;
            this._MusteriKarYuzde = MusteriKarYuzde;
            this._SatisHedefi = SatisHedefi;
            this._Tutar = Tutar;
            this._EkIsk = EkIsk;
            this._CiroPrimDonusYuzde = CiroPrimDonusYuzde;
            this._BayiMaliyet = BayiMaliyet; 
            this._DusulmusBirimFiyatKDVli = DusulmusBirimFiyatKDVli;
            this._KarZararYuzde = KarZararYuzde;
            this._Toplam = Toplam;
            this._Aciklama1 = Aciklama1;
            this._Aciklama2 = Aciklama2;
            this._Aciklama3 = Aciklama3;
            this._Aciklama4 = Aciklama4;
        }
        public AktiviteDetayi(int UrunID, string UrunAdi, int SatisHedefi, decimal AksiyonFiyati, decimal BirimFiyatKDVli)
        {
            this._UrunID = UrunID;
            this._UrunAdi = UrunAdi;
            this._SatisHedefi = SatisHedefi;
            this._AksiyonFiyati = AksiyonFiyati;
            this._BirimFiyatKDVli = BirimFiyatKDVli;
        }

        bool geldiFA = false;
        bool geldiFAC = false;
        bool geldiPI = false;
        bool geldiCP = false;

        // Özellikler
        public long AktiviteDetayID { get { return this._AktiviteDetayID; } set { value = this._AktiviteDetayID; } }
        public int UrunID { get { return this._UrunID; } set { value = this._UrunID; } }
        public string UrtKod { get { return Urunler.GetProductUrtKod(this._UrunID); } }
        public string UrunAdi { get { return this._UrunAdi; } set { value = this._UrunAdi; } }
        public int KoliAdet { get { return this._KoliAdet; } set { value = this._KoliAdet; } }
        public decimal BirimFiyatKDVli { get { return this._BirimFiyatKDVli; } set { value = this._BirimFiyatKDVli; } }
        public decimal AksiyonFiyati { get { return this._AksiyonFiyati; } set { value = this._AksiyonFiyati; } }
        public double MusteriKarYuzde { get { return this._MusteriKarYuzde; } set { value = this._MusteriKarYuzde; } }
        public int SatisHedefi { get { return this._SatisHedefi; } set { value = this._SatisHedefi; } }
        public decimal Tutar 
        { 
            get 
            {
                double para1 = Convert.ToDouble(DusulmusBirimFiyatKDVli) - ((Convert.ToDouble(DusulmusBirimFiyatKDVli) / 100) * CiroPrimDonusYuzde);
                this._Tutar = Convert.ToDecimal(para1);
                return this._Tutar; 
            } 
            set 
            { 
                value = this._Tutar; 
            } 
        }
        public double FatAltIsk
        {
            get
            {
                if (geldiFA)
                    return Convert.ToDouble(this._Aciklama1);
                geldiFA = true;

                double donendeger = 0;

                int SMREF = Aktiviteler.GetObject(AktivitelerDetay.GetObject(this._AktiviteDetayID).intAktiviteID).SMREF;
                int sonanlasmaid = Aktiviteler.GetObject(AktivitelerDetay.GetObject(this._AktiviteDetayID).intAktiviteID).intAnlasmaID; // FiyatTipi == 25 ? Anlasmalar.GetSonAnlasmaID(SMREF, DateTime.Now, "1") : Anlasmalar.GetSonAnlasmaID(CariHesaplar.GetGMREFBySMREF(SMREF), DateTime.Now, "2");
                short FiyatTipi = Aktiviteler.GetObject(AktivitelerDetay.GetObject(this._AktiviteDetayID).intAktiviteID).sintFiyatTipiID; // direk dağıtım

                if (FiyatTipi.ToString().StartsWith("5") || (FiyatTipi == 7 && sonanlasmaid != 0))
                {
                    Anlasmalar anlasma = Anlasmalar.GetObject(sonanlasmaid);

                    double isk1 = anlasma != null ? (Urunler.GetProductOzelKod(this._UrunID) != "T2" ? anlasma.flTAHIsk : anlasma.flYEGIsk) : 0; //Urunler.GetProductDiscountsAndPrice(this._UrunID, FiyatTipi, this._DonemYil, this._DonemAy)[0];
                    double isk2 = 0; //Urunler.GetProductDiscountsAndPrice(this._UrunID, FiyatTipi, this._DonemYil, this._DonemAy)[1];
                    double birincidusulmus = 100 - isk1;
                    double ikincidusulmus = birincidusulmus - ((birincidusulmus / 100) * isk2);
                    donendeger = 100 - ikincidusulmus;
                    this._Aciklama1 = donendeger.ToString("N1");
                    return donendeger;
                }

                if (sonanlasmaid != 0)
                {
                    Anlasmalar anlasma = Anlasmalar.GetObject(sonanlasmaid);
                    if (Urunler.GetProductGRPKOD(this._UrunID) == "STG-1")
                        donendeger = anlasma.flTAHIsk;
                    else if (Urunler.GetProductGRPKOD(this._UrunID) == "STG-2")
                        donendeger = anlasma.flYEGIsk;
                    else
                        donendeger = anlasma.flYEGIsk;
                }
                else
                {
                    //double[] fiyatiskonto = Urunler.GetProductDiscountsAndPrice(this._UrunID, 25); // anlaşma yoksa 25. fiyat tipindeki 1. iskonto
                    int GMREF = 0;
                    if (FiyatTipi == 25) // altcaridir (web-musteri-tp)
                    {
                        GMREF = CariHesaplarTP.GetObject(SMREF, false).GMREF;
                        if (Urunler.GetProductGRPKOD(this._UrunID) == "STG-1")
                            donendeger = CariHesaplarTPEk2.GetObject(GMREF, this._DonemYil, this._DonemAy).TAH_ISK;
                        else if (Urunler.GetProductGRPKOD(this._UrunID) == "STG-2")
                            donendeger = CariHesaplarTPEk2.GetObject(GMREF, this._DonemYil, this._DonemAy).YEG_ISK;
                        else
                            donendeger = 5;
                    }
                    else
                    {
                        if (Urunler.GetProductGRPKOD(this._UrunID) == "STG-1")
                            donendeger = 5; // fiyat değişiminde iskonto değişirse değişmesi lazım
                        else if (Urunler.GetProductGRPKOD(this._UrunID) == "STG-2")
                            donendeger = 5; // fiyat değişiminde iskonto değişirse değişmesi lazım
                        else
                            donendeger = 5;
                    }
                }

                this._Aciklama1 = donendeger.ToString("N1");
                return donendeger;
            }
        }
        public double FatAltCiro
        {
            get
            {
                if (geldiFAC)
                    return Convert.ToDouble(this._Aciklama2);
                geldiFAC = true;

                double donendeger = 0;

                int SMREF = Aktiviteler.GetObject(AktivitelerDetay.GetObject(this._AktiviteDetayID).intAktiviteID).SMREF;
                int sonanlasmaid = Aktiviteler.GetObject(AktivitelerDetay.GetObject(this._AktiviteDetayID).intAktiviteID).intAnlasmaID; // FiyatTipi == 25 ? Anlasmalar.GetSonAnlasmaID(SMREF, DateTime.Now, "1") : Anlasmalar.GetSonAnlasmaID(CariHesaplar.GetGMREFBySMREF(SMREF), DateTime.Now, "2");
                short FiyatTipi = Aktiviteler.GetObject(AktivitelerDetay.GetObject(this._AktiviteDetayID).intAktiviteID).sintFiyatTipiID; // direk dağıtım

                if (FiyatTipi.ToString().StartsWith("5") || (FiyatTipi == 7 && sonanlasmaid != 0))
                {
                    Anlasmalar anlasma = Anlasmalar.GetObject(sonanlasmaid);
                    donendeger = anlasma != null ? (Urunler.GetProductOzelKod(this._UrunID) != "T2" ? anlasma.flTAHCiroIsk : anlasma.flYEGCiroIsk) : 0;

                    //donendeger = Urunler.GetProductDiscountsAndPrice(this._UrunID, FiyatTipi, this._DonemYil, this._DonemAy)[2];

                    this._Aciklama2 = donendeger.ToString("N1");
                    return donendeger;
                }

                if (sonanlasmaid != 0)
                {
                    Anlasmalar anlasma = Anlasmalar.GetObject(sonanlasmaid);
                    if (Urunler.GetProductGRPKOD(this._UrunID) == "STG-1")
                        donendeger = anlasma.flTAHCiroIsk;
                    else if (Urunler.GetProductGRPKOD(this._UrunID) == "STG-2")
                        donendeger = anlasma.flYEGCiroIsk;
                    else
                        donendeger = anlasma.flYEGCiroIsk;
                }
                else
                {
                    if (FiyatTipi == 25) // altcaridir (web-musteri-tp)
                    {
                        //if (CariHesaplarTP.GetObject(SMREF, true).GMREF == 1005405 || CariHesaplarTP.GetObject(SMREF, true).GMREF == 1000951) // bayi öztrakya veya meltem ise
                        //{
                            if (Urunler.GetProductGRPKOD(this._UrunID) == "STG-1")
                                donendeger = 0; // fiyat değişiminde iskonto değişirse değişmesi lazım
                            else if (Urunler.GetProductGRPKOD(this._UrunID) == "STG-2")
                                donendeger = 0; // fiyat değişiminde iskonto değişirse değişmesi lazım
                        //}
                    }
                    else
                    {
                        if (Urunler.GetProductGRPKOD(this._UrunID) == "STG-1")
                            donendeger = 0; // fiyat değişiminde iskonto değişirse değişmesi lazım
                        else if (Urunler.GetProductGRPKOD(this._UrunID) == "STG-2")
                            donendeger = 0; // fiyat değişiminde iskonto değişirse değişmesi lazım
                    }
                }

                this._Aciklama2 = donendeger.ToString("N1");
                return donendeger;
            }
        }
        public double PazIsk 
        { 
            get
            {
                if (geldiPI)
                    return Convert.ToDouble(this._Aciklama3);
                geldiPI = true;

                double donendeger = 0;

                short FiyatTipi = Aktiviteler.GetObject(AktivitelerDetay.GetObject(this._AktiviteDetayID).intAktiviteID).sintFiyatTipiID;
                int SMREF = Aktiviteler.GetObject(AktivitelerDetay.GetObject(this._AktiviteDetayID).intAktiviteID).SMREF;
                if (FiyatTipi == 25) // altcaridir (web-musteri-tp)
                {
                    //if (CariHesaplarTP.GetObject(Aktiviteler.GetObject(AktivitelerDetay.GetObject(this._AktiviteDetayID).intAktiviteID).SMREF, true).GMREF == 1005405
                    //    || CariHesaplarTP.GetObject(Aktiviteler.GetObject(AktivitelerDetay.GetObject(this._AktiviteDetayID).intAktiviteID).SMREF, true).GMREF == 1000951) // bayi öztrakya veya meltem ise
                    //{
                    //    donendeger = Urunler.GetProductDiscountsAndPrice(this._UrunID, 7, this._DonemYil, this._DonemAy)[2];
                    //}
                    //else
                    //{
                        donendeger = Urunler.GetProductDiscountsAndPrice(this._UrunID, 25, this._DonemYil, this._DonemAy)[2];
                    //}
                }
                else
                {
                    if (FiyatTipi.ToString().StartsWith("5"))
                    {
                        donendeger = Urunler.GetProductDiscountsAndPrice(this._UrunID, FiyatTipi, this._DonemYil, this._DonemAy)[5];
                    }
                    else
                    {
                        donendeger = Urunler.GetProductDiscountsAndPrice(this._UrunID, 7, this._DonemYil, this._DonemAy)[2];
                    }
                }

                this._Aciklama3 = donendeger.ToString("N1");
                return donendeger; 
            } 
        }
        public double EkIsk { get { return this._EkIsk; } set { value = this._EkIsk; } }
        public double CiroPrimDonusYuzde 
        { 
            get
            {
                if (geldiCP)
                    return this._CiroPrimDonusYuzde;
                geldiCP = true;

                double donendeger = 0;

                short FiyatTipi = Aktiviteler.GetObject(AktivitelerDetay.GetObject(this._AktiviteDetayID).intAktiviteID).sintFiyatTipiID;
                int SMREF = Aktiviteler.GetObject(AktivitelerDetay.GetObject(this._AktiviteDetayID).intAktiviteID).SMREF;
                int sonanlasmaid = Aktiviteler.GetObject(AktivitelerDetay.GetObject(this._AktiviteDetayID).intAktiviteID).intAnlasmaID; //FiyatTipi == 25 ? Anlasmalar.GetSonAnlasmaID(SMREF, DateTime.Now, "1") : Anlasmalar.GetSonAnlasmaID(CariHesaplar.GetGMREFBySMREF(SMREF), DateTime.Now, "2");

                if (FiyatTipi.ToString().StartsWith("5") || (FiyatTipi == 7 && sonanlasmaid != 0))
                {
                    Anlasmalar anlasma = Anlasmalar.GetObject(sonanlasmaid);
                    donendeger = anlasma != null ? 
                        (
                        Urunler.GetProductOzelKod(this._UrunID) != "T2" ? 
                        anlasma.flTAHCiro + anlasma.flTAHCiro3 + anlasma.flTAHCiro6 + anlasma.flTAHCiro12 : 
                        anlasma.flYEGCiro + anlasma.flYEGCiro3 + anlasma.flYEGCiro6 + anlasma.flYEGCiro12
                        ) : 0;

                    this._CiroPrimDonusYuzde = donendeger;
                    return donendeger;
                }

                if (sonanlasmaid != 0)
                {
                    Anlasmalar anlasma = Anlasmalar.GetObject(sonanlasmaid);
                    if (Urunler.GetProductGRPKOD(this._UrunID) == "STG-1")
                        donendeger = anlasma.flTAHCiro + anlasma.flTAHCiro3 + anlasma.flTAHCiro6 + anlasma.flTAHCiro12;
                    else if (Urunler.GetProductGRPKOD(this._UrunID) == "STG-2")
                        donendeger = anlasma.flYEGCiro + anlasma.flYEGCiro3 + anlasma.flYEGCiro6 + anlasma.flYEGCiro12;
                    else
                        donendeger = anlasma.flYEGCiro + anlasma.flYEGCiro3 + anlasma.flYEGCiro6 + anlasma.flYEGCiro12;
                }

                this._CiroPrimDonusYuzde = donendeger;
                return donendeger; 
            } 
        }
        public decimal BayiMaliyet { get { return this._BayiMaliyet; } set { value = this._BayiMaliyet; } }
        public decimal DusulmusBirimFiyatKDVli 
        {
            get
            {
                double para1 = Convert.ToDouble(_BirimFiyatKDVli) - ((Convert.ToDouble(_BirimFiyatKDVli) / 100) * FatAltIsk);
                double para2 = Convert.ToDouble(para1) - ((Convert.ToDouble(para1) / 100) * FatAltCiro);
                double para3 = Convert.ToDouble(para2) - ((Convert.ToDouble(para2) / 100) * PazIsk);
                double para4 = Convert.ToDouble(para3) - ((Convert.ToDouble(para3) / 100) * EkIsk);
                this._DusulmusBirimFiyatKDVli = Convert.ToDecimal(para4);
                return Convert.ToDecimal(para4); 
            }
        }
        public decimal CiroPrimiDusulmusKDVDahil
        {
            get
            {
                double para1 = Convert.ToDouble(_DusulmusBirimFiyatKDVli) - ((Convert.ToDouble(_DusulmusBirimFiyatKDVli) / 100) * CiroPrimDonusYuzde);
                this._Tutar = Convert.ToDecimal(para1);
                return Convert.ToDecimal(para1);
            }
        }
        public double KarZararYuzde { get { return this._KarZararYuzde; } set { value = this._KarZararYuzde; } }
        public decimal Toplam { get { return this._Toplam; } set { value = this._Toplam; } }
        public string Aciklama1 { get { return this._Aciklama1; } }
        public string Aciklama2 { get { return this._Aciklama2; } }
        public string Aciklama3 { get { return this._Aciklama3; } }
        public string Aciklama4 { get { return this._Aciklama4; } set { value = this._Aciklama4; } }
        public decimal SonFiyat
        {
            get
            {
                Aktiviteler aktivite = Aktiviteler.GetObject(AktivitelerDetay.GetObject(this._AktiviteDetayID).intAktiviteID);
                long adid = AktivitelerDetay.GetSonAktivitelerDetayID(aktivite.SMREF, this._UrunID.ToString(), aktivite.sintFiyatTipiID);
                return adid != 0 ? AktivitelerDetay.GetObject(adid).mnTutar : 0;
            }
        }

        // Dispose
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        // Guncelle
        public void Update()
        {
            AktivitelerDetay aktivitelerdetay = AktivitelerDetay.GetObject(this._AktiviteDetayID);
            aktivitelerdetay.intUrunID = this._UrunID;
            aktivitelerdetay.strUrunAdi = this._UrunAdi;
            aktivitelerdetay.intKoliAdet = this._KoliAdet;
            aktivitelerdetay.mnBirimFiyatKDVli = this._BirimFiyatKDVli;
            aktivitelerdetay.mnAksiyonFiyati = this._AksiyonFiyati;
            aktivitelerdetay.flMusteriKarYuzde = this._MusteriKarYuzde;
            aktivitelerdetay.strSatisHedefi = this._SatisHedefi.ToString();
            aktivitelerdetay.mnTutar = this.Tutar;
            aktivitelerdetay.flEkIsk = this._EkIsk;
            aktivitelerdetay.flCiroPrimDonusYuzde = this.CiroPrimDonusYuzde;
            aktivitelerdetay.mnDusulmusBirimFiyatKDVli = this.DusulmusBirimFiyatKDVli;
            aktivitelerdetay.flKarZararYuzde = this._KarZararYuzde;
            aktivitelerdetay.mnToplam = this._Toplam;
            aktivitelerdetay.strAciklama1 = this._Aciklama1;
            aktivitelerdetay.strAciklama2 = this._Aciklama2;
            aktivitelerdetay.strAciklama3 = this._Aciklama3;
            aktivitelerdetay.strAciklama4 = this._Aciklama4;
            aktivitelerdetay.DoUpdate();
        }
    }
}