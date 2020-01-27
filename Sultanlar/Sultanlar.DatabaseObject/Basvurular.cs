using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.Class;

namespace Sultanlar.DatabaseObject
{
    public class Basvurular : IDisposable, ISultanlar
        {
        //
        //
        //
        // Alanlar:
        //
        private int _pkBasvuruID;
        private string _strAd;
        private string _strSoyad;
        private string _dtDogumTarihi;
        private byte _tintDogumYeriID;
        private bool _blCinsiyet;
        private string _strTCKimlik;
        private byte _tintNufusIlID;
        private short _sintNufusIlceID;
        private byte _tintMedeniDurumID;
        private string _strAnneBaba;
        private bool _blSurucuBelge;
        private byte _tintSurucuBelgeSinifiID;
        private string _dtSurucuBelgeTarihi;
        private bool _blPsikoteknik;
        private byte _tintSRC;
        private string _strBoy;
        private string _strKilo;
        private string _strKardesSayisi;
        private string _strAdres;
        private string _strEvTelefonu;
        private string _strCepTelefonu;
        private short _sintAdresIlceID;
        private byte _tintAdresIlID;
        private string _strEposta;
        private string _strWebSayfasi;
        private string _strEsAd;
        private string _strEsSoyad;
        private string _strEsMeslek;
        private string _dtEsDogumTarihi;
        private byte _tintAskerlikDurumuID;
        private byte _tintAskerlikTipID;
        private string _dtTerhisTarihi;
        private string _dtTecilTarihi;
        private string _strMuafNedeni;
        private string _strAskerlikSinifi;
        private byte _tintOgrenimDurumuID;
        private bool _blMahkeme;
        private string _strMahkemeNedeni;
        private string _dtMahkemeDurusmaTarihi;
        private bool _blMahkumiyet;
        private string _strMahkumiyetNedeni;
        private string _dtMahkumiyetTahliye;
        private string _strBakmaklaYukumluYakin;
        private string _strTedaviyeMuhtacYakin;
        private bool _blKrediKartiTakibat;
        private string _strKrediKartiTakibat;
        private bool _blSurenHastalik;
        private string _strSurenHastalik;
        private bool _blOnemliAmeliyat;
        private string _strOnemliAmeliyat;
        private bool _blSakatlik;
        private string _strSakatlik;
        private bool _blEvSizin;
        private bool _blBaskaEv;
        private string _strBaskaEvAdresDurum;
        private bool _blOtomobil;
        private string _strOtomobilMarkaModelDurum;
        private string _strUyeDernekKlupKurulus;
        private string _strOzelMerakHobi;
        private string _strBildigiBilgisayarProgramiDiger;
        private string _strMeslekBasari;
        private string _strSirketTanidik;
        private bool _blDahaOnceBasvuru;
        private string _strTalepUcret;
        private string _dtIsBaslangicTarihi;
        private bool _blSigara;
        private string _strIsOzelBeklenti;
        private bool _blVardiyaliCalisma;
        private bool _blSehirDisiCalisma;
        private string _strSehirDisiCalismaKisitlama;
        private string _strCalismaHayatiBeklenti;
        private DateTime _dtBasvuruTarihi;
        private string _strFotograf;
        private bool _blSilindi;
        private object _binResim;
        int _intArananGorevID;
        bool _blEpostaIleYollandi;
        //
        //
        //
        // Constracter lar:
        //
        private Basvurular(int pkBasvuruID, string strAd, string strSoyad, string dtDogumTarihi, byte tintDogumYeriID, bool blCinsiyet, string strTCKimlik,
            byte tintNufusIlID, short sintNufusIlceID, byte tintMedeniDurumID, string strAnneBaba, bool blSurucuBelge, byte tintSurucuBelgeSinifiID,
            string dtSurucuBelgeTarihi, bool blPsikoteknik, byte tintSRC, string strBoy, string strKilo, string strKardesSayisi, string strAdres, string strEvTelefonu,
            string strCepTelefonu, short sintAdresIlceID, byte tintAdresIlID, string strEposta, string strWebSayfasi, string strEsAd, string strEsSoyad, string strEsMeslek,
            string dtEsDogumTarihi, byte tintAskerlikDurumuID, byte tintAskerlikTipID, string dtTerhisTarihi, string dtTecilTarihi, string strMuafNedeni,
            string strAskerlikSinifi, byte tintOgrenimDurumuID, bool blMahkeme, string strMahkemeNedeni, string dtMahkemeDurusmaTarihi, bool blMahkumiyet,
            string strMahkumiyetNedeni, string dtMahkumiyetTahliye, string strBakmaklaYukumluYakin, string strTedaviyeMuhtacYakin, bool blKrediKartiTakibat, 
            string strKrediKartiTakibat, bool blSurenHastalik, string strSurenHastalik, bool blOnemliAmeliyat, string strOnemliAmeliyat, bool blSakatlik, string strSakatlik, 
            bool blEvSizin, bool blBaskaEv, string strBaskaEvAdresDurum, bool blOtomobil, string strOtomobilMarkaModelDurum, string strUyeDernekKlupKurulus, 
            string strOzelMerakHobi, string strBildigiBilgisayarProgramiDiger, string strMeslekBasari, string strSirketTanidik, bool blDahaOnceBasvuru,
            string strTalepUcret, string dtIsBaslangicTarihi, bool blSigara, string strIsOzelBeklenti, bool blVardiyaliCalisma, bool blSehirDisiCalisma,
            string strSehirDisiCalismaKisitlama, string strCalismaHayatiBeklenti, DateTime dtBasvuruTarihi, string strFotograf, bool blSilindi, object binResim,
            int intArananGorevID, bool blEpostaIleYollandi)
        {
            this._pkBasvuruID = pkBasvuruID;
            this._strAd = strAd;
            this._strSoyad = strSoyad;
            this._dtDogumTarihi = dtDogumTarihi;
            this._tintDogumYeriID = tintDogumYeriID;
            this._blCinsiyet = blCinsiyet;
            this._strTCKimlik = strTCKimlik;
            this._tintNufusIlID = tintNufusIlID;
            this._sintNufusIlceID = sintNufusIlceID;
            this._tintMedeniDurumID = tintMedeniDurumID;
            this._strAnneBaba = strAnneBaba;
            this._blSurucuBelge = blSurucuBelge;
            this._tintSurucuBelgeSinifiID = tintSurucuBelgeSinifiID;
            this._dtSurucuBelgeTarihi = dtSurucuBelgeTarihi;
            this._blPsikoteknik = blPsikoteknik;
            this._tintSRC = tintSRC;
            this._strBoy = strBoy;
            this._strKilo = strKilo;
            this._strKardesSayisi = strKardesSayisi;
            this._strAdres = strAdres;
            this._strEvTelefonu = strEvTelefonu;
            this._strCepTelefonu = strCepTelefonu;
            this._sintAdresIlceID = sintAdresIlceID;
            this._tintAdresIlID = tintAdresIlID;
            this._strEposta = strEposta;
            this._strWebSayfasi = strWebSayfasi;
            this._strEsAd = strEsAd;
            this._strEsSoyad = strEsSoyad;
            this._strEsMeslek = strEsMeslek;
            this._dtEsDogumTarihi = dtEsDogumTarihi;
            this._tintAskerlikDurumuID = tintAskerlikDurumuID;
            this._tintAskerlikTipID = tintAskerlikTipID;
            this._dtTerhisTarihi = dtTerhisTarihi;
            this._dtTecilTarihi = dtTecilTarihi;
            this._strMuafNedeni = strMuafNedeni;
            this._strAskerlikSinifi = strAskerlikSinifi;
            this._tintOgrenimDurumuID = tintOgrenimDurumuID;
            this._blMahkeme = blMahkeme;
            this._strMahkemeNedeni = strMahkemeNedeni;
            this._dtMahkemeDurusmaTarihi = dtMahkemeDurusmaTarihi;
            this._blMahkumiyet = blMahkumiyet;
            this._strMahkumiyetNedeni = strMahkumiyetNedeni;
            this._dtMahkumiyetTahliye = dtMahkumiyetTahliye;
            this._strBakmaklaYukumluYakin = strBakmaklaYukumluYakin;
            this._strTedaviyeMuhtacYakin = strTedaviyeMuhtacYakin;
            this._blKrediKartiTakibat = blKrediKartiTakibat;
            this._strKrediKartiTakibat = strKrediKartiTakibat;
            this._blSurenHastalik = blSurenHastalik;
            this._strSurenHastalik = strSurenHastalik;
            this._blOnemliAmeliyat = blOnemliAmeliyat;
            this._strOnemliAmeliyat = strOnemliAmeliyat;
            this._blSakatlik = blSakatlik;
            this._strSakatlik = strSakatlik;
            this._blEvSizin = blEvSizin;
            this._blBaskaEv = blBaskaEv;
            this._strBaskaEvAdresDurum = strBaskaEvAdresDurum;
            this._blOtomobil = blOtomobil;
            this._strOtomobilMarkaModelDurum = strOtomobilMarkaModelDurum;
            this._strUyeDernekKlupKurulus = strUyeDernekKlupKurulus;
            this._strOzelMerakHobi = strOzelMerakHobi;
            this._strBildigiBilgisayarProgramiDiger = strBildigiBilgisayarProgramiDiger;
            this._strMeslekBasari = strMeslekBasari;
            this._strSirketTanidik = strSirketTanidik;
            this._blDahaOnceBasvuru = blDahaOnceBasvuru;
            this._strTalepUcret = strTalepUcret;
            this._dtIsBaslangicTarihi = dtIsBaslangicTarihi;
            this._blSigara = blSigara;
            this._strIsOzelBeklenti = strIsOzelBeklenti;
            this._blVardiyaliCalisma = blVardiyaliCalisma;
            this._blSehirDisiCalisma = blSehirDisiCalisma;
            this._strSehirDisiCalismaKisitlama = strSehirDisiCalismaKisitlama;
            this._strCalismaHayatiBeklenti = strCalismaHayatiBeklenti;
            this._dtBasvuruTarihi = dtBasvuruTarihi;
            this._strFotograf = strFotograf;
            this._blSilindi = blSilindi;
            this._binResim = binResim;
            this._intArananGorevID = intArananGorevID;
            this._blEpostaIleYollandi = blEpostaIleYollandi;
        }
        //
        //
        public Basvurular(string strAd, string strSoyad, string dtDogumTarihi, byte tintDogumYeriID, bool blCinsiyet, string strTCKimlik,
            byte tintNufusIlID, short sintNufusIlceID, byte tintMedeniDurumID, string strAnneBaba, bool blSurucuBelge, byte tintSurucuBelgeSinifiID,
            string dtSurucuBelgeTarihi, bool blPsikoteknik, byte tintSRC, string strBoy, string strKilo, string strKardesSayisi, string strAdres, string strEvTelefonu,
            string strCepTelefonu, short sintAdresIlceID, byte tintAdresIlID, string strEposta, string strWebSayfasi, string strEsAd, string strEsSoyad, string strEsMeslek,
            string dtEsDogumTarihi, byte tintAskerlikDurumuID, byte tintAskerlikTipID, string dtTerhisTarihi, string dtTecilTarihi, string strMuafNedeni,
            string strAskerlikSinifi, byte tintOgrenimDurumuID, bool blMahkeme, string strMahkemeNedeni, string dtMahkemeDurusmaTarihi, bool blMahkumiyet,
            string strMahkumiyetNedeni, string dtMahkumiyetTahliye, string strBakmaklaYukumluYakin, string strTedaviyeMuhtacYakin, bool blKrediKartiTakibat,
            string strKrediKartiTakibat, bool blSurenHastalik, string strSurenHastalik, bool blOnemliAmeliyat, string strOnemliAmeliyat, bool blSakatlik, string strSakatlik,
            bool blEvSizin, bool blBaskaEv, string strBaskaEvAdresDurum, bool blOtomobil, string strOtomobilMarkaModelDurum, string strUyeDernekKlupKurulus,
            string strOzelMerakHobi, string strBildigiBilgisayarProgramiDiger, string strMeslekBasari, string strSirketTanidik, bool blDahaOnceBasvuru,
            string strTalepUcret, string dtIsBaslangicTarihi, bool blSigara, string strIsOzelBeklenti, bool blVardiyaliCalisma, bool blSehirDisiCalisma,
            string strSehirDisiCalismaKisitlama, string strCalismaHayatiBeklenti, DateTime dtBasvuruTarihi, string strFotograf, bool blSilindi, object binResim,
            int intArananGorevID, bool blEpostaIleYollandi)
        {
            this._strAd = strAd;
            this._strSoyad = strSoyad;
            this._dtDogumTarihi = dtDogumTarihi;
            this._tintDogumYeriID = tintDogumYeriID;
            this._blCinsiyet = blCinsiyet;
            this._strTCKimlik = strTCKimlik;
            this._tintNufusIlID = tintNufusIlID;
            this._sintNufusIlceID = sintNufusIlceID;
            this._tintMedeniDurumID = tintMedeniDurumID;
            this._strAnneBaba = strAnneBaba;
            this._blSurucuBelge = blSurucuBelge;
            this._tintSurucuBelgeSinifiID = tintSurucuBelgeSinifiID;
            this._dtSurucuBelgeTarihi = dtSurucuBelgeTarihi;
            this._blPsikoteknik = blPsikoteknik;
            this._tintSRC = tintSRC;
            this._strBoy = strBoy;
            this._strKilo = strKilo;
            this._strKardesSayisi = strKardesSayisi;
            this._strAdres = strAdres;
            this._strEvTelefonu = strEvTelefonu;
            this._strCepTelefonu = strCepTelefonu;
            this._sintAdresIlceID = sintAdresIlceID;
            this._tintAdresIlID = tintAdresIlID;
            this._strEposta = strEposta;
            this._strWebSayfasi = strWebSayfasi;
            this._strEsAd = strEsAd;
            this._strEsSoyad = strEsSoyad;
            this._strEsMeslek = strEsMeslek;
            this._dtEsDogumTarihi = dtEsDogumTarihi;
            this._tintAskerlikDurumuID = tintAskerlikDurumuID;
            this._tintAskerlikTipID = tintAskerlikTipID;
            this._dtTerhisTarihi = dtTerhisTarihi;
            this._dtTecilTarihi = dtTecilTarihi;
            this._strMuafNedeni = strMuafNedeni;
            this._strAskerlikSinifi = strAskerlikSinifi;
            this._tintOgrenimDurumuID = tintOgrenimDurumuID;
            this._blMahkeme = blMahkeme;
            this._strMahkemeNedeni = strMahkemeNedeni;
            this._dtMahkemeDurusmaTarihi = dtMahkemeDurusmaTarihi;
            this._blMahkumiyet = blMahkumiyet;
            this._strMahkumiyetNedeni = strMahkumiyetNedeni;
            this._dtMahkumiyetTahliye = dtMahkumiyetTahliye;
            this._strBakmaklaYukumluYakin = strBakmaklaYukumluYakin;
            this._strTedaviyeMuhtacYakin = strTedaviyeMuhtacYakin;
            this._blKrediKartiTakibat = blKrediKartiTakibat;
            this._strKrediKartiTakibat = strKrediKartiTakibat;
            this._blSurenHastalik = blSurenHastalik;
            this._strSurenHastalik = strSurenHastalik;
            this._blOnemliAmeliyat = blOnemliAmeliyat;
            this._strOnemliAmeliyat = strOnemliAmeliyat;
            this._blSakatlik = blSakatlik;
            this._strSakatlik = strSakatlik;
            this._blEvSizin = blEvSizin;
            this._blBaskaEv = blBaskaEv;
            this._strBaskaEvAdresDurum = strBaskaEvAdresDurum;
            this._blOtomobil = blOtomobil;
            this._strOtomobilMarkaModelDurum = strOtomobilMarkaModelDurum;
            this._strUyeDernekKlupKurulus = strUyeDernekKlupKurulus;
            this._strOzelMerakHobi = strOzelMerakHobi;
            this._strBildigiBilgisayarProgramiDiger = strBildigiBilgisayarProgramiDiger;
            this._strMeslekBasari = strMeslekBasari;
            this._strSirketTanidik = strSirketTanidik;
            this._blDahaOnceBasvuru = blDahaOnceBasvuru;
            this._strTalepUcret = strTalepUcret;
            this._dtIsBaslangicTarihi = dtIsBaslangicTarihi;
            this._blSigara = blSigara;
            this._strIsOzelBeklenti = strIsOzelBeklenti;
            this._blVardiyaliCalisma = blVardiyaliCalisma;
            this._blSehirDisiCalisma = blSehirDisiCalisma;
            this._strSehirDisiCalismaKisitlama = strSehirDisiCalismaKisitlama;
            this._strCalismaHayatiBeklenti = strCalismaHayatiBeklenti;
            this._dtBasvuruTarihi = dtBasvuruTarihi;
            this._strFotograf = strFotograf;
            this._blSilindi = blSilindi;
            this._binResim = binResim;
            this._intArananGorevID = intArananGorevID;
            this._blEpostaIleYollandi = blEpostaIleYollandi;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkBasvuruID
        {
            get
            {
                return this._pkBasvuruID;
            }
        }
        public string strAd { get { return this._strAd; } set { this._strAd = value; } }
        public string strSoyad { get { return this._strSoyad; } set { this._strSoyad = value; } }
        public string dtDogumTarihi { get { return this._dtDogumTarihi; } set { this._dtDogumTarihi = value; } }
        public byte tintDogumYeriID { get { return this._tintDogumYeriID; } set { this._tintDogumYeriID = value; } }
        public bool blCinsiyet { get { return this._blCinsiyet; } set { this._blCinsiyet = value; } }
        public string strTCKimlik { get { return this._strTCKimlik; } set { this._strTCKimlik = value; } }
        public byte tintNufusIlID { get { return this._tintNufusIlID; } set { this._tintNufusIlID = value; } }
        public short sintNufusIlceID { get { return this._sintNufusIlceID; } set { this._sintNufusIlceID = value; } }
        public byte tintMedeniDurumID { get { return this._tintMedeniDurumID; } set { this._tintMedeniDurumID = value; } }
        public string strAnneBaba { get { return this._strAnneBaba; } set { this._strAnneBaba = value; } }
        public bool blSurucuBelge { get { return this._blSurucuBelge; } set { this._blSurucuBelge = value; } }
        public byte tintSurucuBelgeSinifiID { get { return this._tintSurucuBelgeSinifiID; } set { this._tintSurucuBelgeSinifiID = value; } }
        public string dtSurucuBelgeTarihi { get { return this._dtSurucuBelgeTarihi; } set { this._dtSurucuBelgeTarihi = value; } }
        public bool blPsikoteknik { get { return this._blPsikoteknik; } set { this._blPsikoteknik = value; } }
        public byte tintSRC { get { return this._tintSRC; } set { this._tintSRC = value; } }
        public string strBoy { get { return this._strBoy; } set { this._strBoy = value; } }
        public string strKilo { get { return this._strKilo; } set { this._strKilo = value; } }
        public string strKardesSayisi { get { return this._strKardesSayisi; } set { this._strKardesSayisi = value; } }
        public string strAdres { get { return this._strAdres; } set { this._strAdres = value; } }
        public string strEvTelefonu { get { return this._strEvTelefonu; } set { this._strEvTelefonu = value; } }
        public string strCepTelefonu { get { return this._strCepTelefonu; } set { this._strCepTelefonu = value; } }
        public short sintAdresIlceID { get { return this._sintAdresIlceID; } set { this._sintAdresIlceID = value; } }
        public byte tintAdresIlID { get { return this._tintAdresIlID; } set { this._tintAdresIlID = value; } }
        public string strEposta { get { return this._strEposta; } set { this._strEposta = value; } }
        public string strWebSayfasi { get { return this._strWebSayfasi; } set { this._strWebSayfasi = value; } }
        public string strEsAd { get { return this._strEsAd; } set { this._strEsAd = value; } }
        public string strEsSoyad { get { return this._strEsSoyad; } set { this._strEsSoyad = value; } }
        public string strEsMeslek { get { return this._strEsMeslek; } set { this._strEsMeslek = value; } }
        public string dtEsDogumTarihi { get { return this._dtEsDogumTarihi; } set { this._dtEsDogumTarihi = value; } }
        public byte tintAskerlikDurumuID { get { return this._tintAskerlikDurumuID; } set { this._tintAskerlikDurumuID = value; } }
        public byte tintAskerlikTipID { get { return this._tintAskerlikTipID; } set { this._tintAskerlikTipID = value; } }
        public string dtTerhisTarihi { get { return this._dtTerhisTarihi; } set { this._dtTerhisTarihi = value; } }
        public string dtTecilTarihi { get { return this._dtTecilTarihi; } set { this._dtTecilTarihi = value; } }
        public string strMuafNedeni { get { return this._strMuafNedeni; } set { this._strMuafNedeni = value; } }
        public string strAskerlikSinifi { get { return this._strAskerlikSinifi; } set { this._strAskerlikSinifi = value; } }
        public byte tintOgrenimDurumuID { get { return this._tintOgrenimDurumuID; } set { this._tintOgrenimDurumuID = value; } }
        public bool blMahkeme { get { return this._blMahkeme; } set { this._blMahkeme = value; } }
        public string strMahkemeNedeni { get { return this._strMahkemeNedeni; } set { this._strMahkemeNedeni = value; } }
        public string dtMahkemeDurusmaTarihi { get { return this._dtMahkemeDurusmaTarihi; } set { this._dtMahkemeDurusmaTarihi = value; } }
        public bool blMahkumiyet { get { return this._blMahkumiyet; } set { this._blMahkumiyet = value; } }
        public string strMahkumiyetNedeni { get { return this._strMahkumiyetNedeni; } set { this._strMahkumiyetNedeni = value; } }
        public string dtMahkumiyetTahliye { get { return this._dtMahkumiyetTahliye; } set { this._dtMahkumiyetTahliye = value; } }
        public string strBakmaklaYukumluYakin { get { return this._strBakmaklaYukumluYakin; } set { this._strBakmaklaYukumluYakin = value; } }
        public string strTedaviyeMuhtacYakin { get { return this._strTedaviyeMuhtacYakin; } set { this._strTedaviyeMuhtacYakin = value; } }
        public bool blKrediKartiTakibat { get { return this._blKrediKartiTakibat; } set { this._blKrediKartiTakibat = value; } }
        public string strKrediKartiTakibat { get { return this._strKrediKartiTakibat; } set { this._strKrediKartiTakibat = value; } }
        public bool blSurenHastalik { get { return this._blSurenHastalik; } set { this._blSurenHastalik = value; } }
        public string strSurenHastalik { get { return this._strSurenHastalik; } set { this._strSurenHastalik = value; } }
        public bool blOnemliAmeliyat { get { return this._blOnemliAmeliyat; } set { this._blOnemliAmeliyat = value; } }
        public string strOnemliAmeliyat { get { return this._strOnemliAmeliyat; } set { this._strOnemliAmeliyat = value; } }
        public bool blSakatlik { get { return this._blSakatlik; } set { this._blSakatlik = value; } }
        public string strSakatlik { get { return this._strSakatlik; } set { this._strSakatlik = value; } }
        public bool blEvSizin { get { return this._blEvSizin; } set { this._blEvSizin = value; } }
        public bool blBaskaEv { get { return this._blBaskaEv; } set { this._blBaskaEv = value; } }
        public string strBaskaEvAdresDurum { get { return this._strBaskaEvAdresDurum; } set { this._strBaskaEvAdresDurum = value; } }
        public bool blOtomobil { get { return this._blOtomobil; } set { this._blOtomobil = value; } }
        public string strOtomobilMarkaModelDurum { get { return this._strOtomobilMarkaModelDurum; } set { this._strOtomobilMarkaModelDurum = value; } }
        public string strUyeDernekKlupKurulus { get { return this._strUyeDernekKlupKurulus; } set { this._strUyeDernekKlupKurulus = value; } }
        public string strOzelMerakHobi { get { return this._strOzelMerakHobi; } set { this._strOzelMerakHobi = value; } }
        public string strBildigiBilgisayarProgramiDiger { get { return this._strBildigiBilgisayarProgramiDiger; } set { this._strBildigiBilgisayarProgramiDiger = value; } }
        public string strMeslekBasari { get { return this._strMeslekBasari; } set { this._strMeslekBasari = value; } }
        public string strSirketTanidik { get { return this._strSirketTanidik; } set { this._strSirketTanidik = value; } }
        public bool blDahaOnceBasvuru { get { return this._blDahaOnceBasvuru; } set { this._blDahaOnceBasvuru = value; } }
        public string strTalepUcret { get { return this._strTalepUcret; } set { this._strTalepUcret = value; } }
        public string dtIsBaslangicTarihi { get { return this._dtIsBaslangicTarihi; } set { this._dtIsBaslangicTarihi = value; } }
        public bool blSigara { get { return this._blSigara; } set { this._blSigara = value; } }
        public string strIsOzelBeklenti { get { return this._strIsOzelBeklenti; } set { this._strIsOzelBeklenti = value; } }
        public bool blVardiyaliCalisma { get { return this._blVardiyaliCalisma; } set { this._blVardiyaliCalisma = value; } }
        public bool blSehirDisiCalisma { get { return this._blSehirDisiCalisma; } set { this._blSehirDisiCalisma = value; } }
        public string strSehirDisiCalismaKisitlama { get { return this._strSehirDisiCalismaKisitlama; } set { this._strSehirDisiCalismaKisitlama = value; } }
        public string strCalismaHayatiBeklenti { get { return this._strCalismaHayatiBeklenti; } set { this._strCalismaHayatiBeklenti = value; } }
        public DateTime dtBasvuruTarihi { get { return this._dtBasvuruTarihi; } set { this._dtBasvuruTarihi = value; } }
        public string strFotograf { get { return this._strFotograf; } set { this._strFotograf = value; } }
        public bool blSilindi { get { return this._blSilindi; } set { this._blSilindi = value; } }
        public object binResim { get { return this._binResim; } set { this._binResim = value; } }
        public int intArananGorevID { get { return this._intArananGorevID; } set { this._intArananGorevID = value; } }
        public bool blEpostaIleYollandi { get { return this._blEpostaIleYollandi; } set { this._blEpostaIleYollandi = value; } }
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
            return StringParcalama.IlkHarfBuyuk(this._strAd) + " " + StringParcalama.IlkHarfBuyuk(this._strSoyad);
        }
        //
        //
        //
        // Metodlar:
        //
        public void DoInsert()
        {
            object SurucuBelgeTarihi = DBNull.Value;
            object EsDogumTarihi = DBNull.Value;
            object AskerlikTecilTarihi = DBNull.Value;
            object AskerlikTerhisTarihi = DBNull.Value;
            object MahkemeDurusmaTarihi = DBNull.Value;
            object MahkumiyetTahliyeTarihi = DBNull.Value;
            object IsBaslangicTarihi = DBNull.Value;
            object BinResim = DBNull.Value;
            if (_dtSurucuBelgeTarihi != string.Empty)
            {
                SurucuBelgeTarihi = DateTime.Parse(_dtSurucuBelgeTarihi);
            }
            if (_dtEsDogumTarihi != string.Empty)
            {
                EsDogumTarihi = DateTime.Parse(_dtEsDogumTarihi);
            }
            if (_dtTecilTarihi != string.Empty)
            {
                AskerlikTecilTarihi = DateTime.Parse(_dtTecilTarihi);
            }
            if (_dtTerhisTarihi != string.Empty)
            {
                AskerlikTerhisTarihi = DateTime.Parse(_dtTerhisTarihi);
            }
            if (_dtMahkemeDurusmaTarihi != string.Empty)
            {
                MahkemeDurusmaTarihi = DateTime.Parse(_dtMahkemeDurusmaTarihi);
            }
            if (_dtMahkumiyetTahliye != string.Empty)
            {
                MahkumiyetTahliyeTarihi = DateTime.Parse(_dtMahkumiyetTahliye);
            }
            if (_dtIsBaslangicTarihi != string.Empty)
            {
                IsBaslangicTarihi = DateTime.Parse(_dtIsBaslangicTarihi);
            }
            if (_binResim != null)
            {
                BinResim = _binResim;
            }


            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_BasvuruEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@strAd", SqlDbType.NVarChar, 50).Value = this._strAd;
                cmd.Parameters.Add("@strSoyad", SqlDbType.NVarChar, 50).Value = this._strSoyad;
                cmd.Parameters.Add("@dtDogumTarihi", SqlDbType.SmallDateTime).Value = DateTime.Parse(this._dtDogumTarihi);
                cmd.Parameters.Add("@tintDogumYeriID", SqlDbType.TinyInt).Value = this._tintDogumYeriID;
                cmd.Parameters.Add("@blCinsiyet", SqlDbType.Bit).Value = this._blCinsiyet;
                cmd.Parameters.Add("@strTCKimlik", SqlDbType.VarChar, 11).Value = this._strTCKimlik;
                cmd.Parameters.Add("@tintNufusIlID", SqlDbType.TinyInt).Value = this._tintNufusIlID;
                cmd.Parameters.Add("@sintNufusIlceID", SqlDbType.SmallInt).Value = this._sintNufusIlceID;
                cmd.Parameters.Add("@tintMedeniDurumID", SqlDbType.TinyInt).Value = this._tintMedeniDurumID;
                cmd.Parameters.Add("@strAnneBaba", SqlDbType.NVarChar, 40).Value = this._strAnneBaba;
                cmd.Parameters.Add("@blSurucuBelge", SqlDbType.Bit).Value = this._blSurucuBelge;
                cmd.Parameters.Add("@tintSurucuBelgeSinifiID", SqlDbType.TinyInt).Value = this._tintSurucuBelgeSinifiID;
                cmd.Parameters.Add("@dtSurucuBelgeTarihi", SqlDbType.SmallDateTime).Value = SurucuBelgeTarihi;
                cmd.Parameters.Add("@blPsikoteknik", SqlDbType.Bit).Value = this._blPsikoteknik;
                cmd.Parameters.Add("@tintSRC", SqlDbType.TinyInt).Value = this._tintSRC;
                cmd.Parameters.Add("@strBoy", SqlDbType.NVarChar, 5).Value = this._strBoy;
                cmd.Parameters.Add("@strKilo", SqlDbType.NVarChar, 5).Value = this._strKilo;
                cmd.Parameters.Add("@strKardesSayisi", SqlDbType.NVarChar, 2).Value = this._strKardesSayisi;
                cmd.Parameters.Add("@strAdres", SqlDbType.NVarChar, 200).Value = this._strAdres;
                cmd.Parameters.Add("@strEvTelefonu", SqlDbType.VarChar, 15).Value = this._strEvTelefonu;
                cmd.Parameters.Add("@strCepTelefonu", SqlDbType.VarChar, 15).Value = this._strCepTelefonu;
                cmd.Parameters.Add("@sintAdresIlceID", SqlDbType.SmallInt).Value = this._sintAdresIlceID;
                cmd.Parameters.Add("@tintAdresIlID", SqlDbType.TinyInt).Value = this._tintAdresIlID;
                cmd.Parameters.Add("@strEposta", SqlDbType.NVarChar, 50).Value = this._strEposta;
                cmd.Parameters.Add("@strWebSayfasi", SqlDbType.NVarChar, 50).Value = this._strWebSayfasi;
                cmd.Parameters.Add("@strEsAd", SqlDbType.NVarChar, 50).Value = this._strEsAd;
                cmd.Parameters.Add("@strEsSoyad", SqlDbType.NVarChar, 50).Value = this._strEsSoyad;
                cmd.Parameters.Add("@strEsMeslek", SqlDbType.NVarChar, 80).Value = this._strEsMeslek;
                cmd.Parameters.Add("@dtEsDogumTarihi", SqlDbType.SmallDateTime).Value = EsDogumTarihi;
                cmd.Parameters.Add("@tintAskerlikDurumuID", SqlDbType.TinyInt).Value = this._tintAskerlikDurumuID;
                cmd.Parameters.Add("@tintAskerlikTipID", SqlDbType.TinyInt).Value = this._tintAskerlikTipID;
                cmd.Parameters.Add("@dtTerhisTarihi", SqlDbType.SmallDateTime).Value = AskerlikTerhisTarihi;
                cmd.Parameters.Add("@dtTecilTarihi", SqlDbType.SmallDateTime).Value = AskerlikTecilTarihi;
                cmd.Parameters.Add("@strMuafNedeni", SqlDbType.NVarChar, 80).Value = this._strMuafNedeni;
                cmd.Parameters.Add("@strAskerlikSinifi", SqlDbType.NVarChar, 30).Value = this._strAskerlikSinifi;
                cmd.Parameters.Add("@tintOgrenimDurumuID", SqlDbType.TinyInt).Value = this._tintOgrenimDurumuID;
                cmd.Parameters.Add("@blMahkeme", SqlDbType.Bit).Value = this._blMahkeme;
                cmd.Parameters.Add("@strMahkemeNedeni", SqlDbType.NVarChar, 100).Value = this._strMahkemeNedeni;
                cmd.Parameters.Add("@dtMahkemeDurusmaTarihi", SqlDbType.SmallDateTime).Value = MahkemeDurusmaTarihi;
                cmd.Parameters.Add("@blMahkumiyet", SqlDbType.Bit).Value = this._blMahkumiyet;
                cmd.Parameters.Add("@strMahkumiyetNedeni", SqlDbType.NVarChar, 100).Value = this._strMahkumiyetNedeni;
                cmd.Parameters.Add("@dtMahkumiyetTahliye", SqlDbType.SmallDateTime).Value = MahkumiyetTahliyeTarihi;
                cmd.Parameters.Add("@strBakmaklaYukumluYakin", SqlDbType.NVarChar, 100).Value = this._strBakmaklaYukumluYakin;
                cmd.Parameters.Add("@strTedaviyeMuhtacYakin", SqlDbType.NVarChar, 100).Value = this._strTedaviyeMuhtacYakin;
                cmd.Parameters.Add("@blKrediKartiTakibat", SqlDbType.Bit).Value = this._blKrediKartiTakibat;
                cmd.Parameters.Add("@strKrediKartiTakibat", SqlDbType.NVarChar, 150).Value = this._strKrediKartiTakibat;
                cmd.Parameters.Add("@blSurenHastalik", SqlDbType.Bit).Value = this._blSurenHastalik;
                cmd.Parameters.Add("@strSurenHastalik", SqlDbType.NVarChar, 100).Value = this._strSurenHastalik;
                cmd.Parameters.Add("@blOnemliAmeliyat", SqlDbType.Bit).Value = this._blOnemliAmeliyat;
                cmd.Parameters.Add("@strOnemliAmeliyat", SqlDbType.NVarChar, 100).Value = this._strOnemliAmeliyat;
                cmd.Parameters.Add("@blSakatlik", SqlDbType.Bit).Value = this._blSakatlik;
                cmd.Parameters.Add("@strSakatlik", SqlDbType.NVarChar, 100).Value = this._strSakatlik;
                cmd.Parameters.Add("@blEvSizin", SqlDbType.Bit).Value = this._blEvSizin;
                cmd.Parameters.Add("@blBaskaEv", SqlDbType.Bit).Value = this._blBaskaEv;
                cmd.Parameters.Add("@strBaskaEvAdresDurum", SqlDbType.NVarChar, 200).Value = this._strBaskaEvAdresDurum;
                cmd.Parameters.Add("@blOtomobil", SqlDbType.Bit).Value = this._blOtomobil;
                cmd.Parameters.Add("@strOtomobilMarkaModelDurum", SqlDbType.NVarChar, 150).Value = this._strOtomobilMarkaModelDurum;
                cmd.Parameters.Add("@strUyeDernekKlupKurulus", SqlDbType.NVarChar, 100).Value = this._strUyeDernekKlupKurulus;
                cmd.Parameters.Add("@strOzelMerakHobi", SqlDbType.NVarChar, 100).Value = this._strOzelMerakHobi;
                cmd.Parameters.Add("@strBildigiBilgisayarProgramiDiger", SqlDbType.NVarChar, 70).Value = this._strBildigiBilgisayarProgramiDiger;
                cmd.Parameters.Add("@strMeslekBasari", SqlDbType.NVarChar, 100).Value = this._strMeslekBasari;
                cmd.Parameters.Add("@strSirketTanidik", SqlDbType.NVarChar, 150).Value = this._strSirketTanidik;
                cmd.Parameters.Add("@blDahaOnceBasvuru", SqlDbType.Bit).Value = this._blDahaOnceBasvuru;
                cmd.Parameters.Add("@strTalepUcret", SqlDbType.NVarChar, 50).Value = this._strTalepUcret;
                cmd.Parameters.Add("@dtIsBaslangicTarihi", SqlDbType.SmallDateTime).Value = IsBaslangicTarihi;
                cmd.Parameters.Add("@blSigara", SqlDbType.Bit).Value = this._blSigara;
                cmd.Parameters.Add("@strIsOzelBeklenti", SqlDbType.NVarChar, 100).Value = this._strIsOzelBeklenti;
                cmd.Parameters.Add("@blVardiyaliCalisma", SqlDbType.Bit).Value = this._blVardiyaliCalisma;
                cmd.Parameters.Add("@blSehirDisiCalisma", SqlDbType.Bit).Value = this._blSehirDisiCalisma;
                cmd.Parameters.Add("@strSehirDisiCalismaKisitlama", SqlDbType.NVarChar, 100).Value = this._strSehirDisiCalismaKisitlama;
                cmd.Parameters.Add("@strCalismaHayatiBeklenti", SqlDbType.NVarChar, 300).Value = this._strCalismaHayatiBeklenti;
                cmd.Parameters.Add("@dtBasvuruTarihi", SqlDbType.SmallDateTime).Value = this._dtBasvuruTarihi;
                cmd.Parameters.Add("@strFotograf", SqlDbType.NVarChar, 100).Value = this._strFotograf;
                cmd.Parameters.Add("@blSilindi", SqlDbType.Bit).Value = this._blSilindi;
                cmd.Parameters.Add("@binResim", SqlDbType.VarBinary).Value = BinResim;
                cmd.Parameters.Add("@intArananGorevID", SqlDbType.Int).Value = this._intArananGorevID;
                cmd.Parameters.Add("@blEpostaIleYollandi", SqlDbType.Bit).Value = this._blEpostaIleYollandi;
                cmd.Parameters.Add("@pkBasvuruID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkBasvuruID = Convert.ToInt32(cmd.Parameters["@pkBasvuruID"].Value);
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //
        //
        public void DoUpdate()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_BasvuruGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkBasvuruID", SqlDbType.Int).Value = this._pkBasvuruID;
                cmd.Parameters.Add("@strAd", SqlDbType.NVarChar, 50).Value = this._strAd;
                cmd.Parameters.Add("@strSoyad", SqlDbType.NVarChar, 50).Value = this._strSoyad;
                cmd.Parameters.Add("@dtDogumTarihi", SqlDbType.SmallDateTime).Value = this._dtDogumTarihi;
                cmd.Parameters.Add("@tintDogumYeriID", SqlDbType.TinyInt).Value = this._tintDogumYeriID;
                cmd.Parameters.Add("@blCinsiyet", SqlDbType.Bit).Value = this._blCinsiyet;
                cmd.Parameters.Add("@strTCKimlik", SqlDbType.VarChar, 11).Value = this._strTCKimlik;
                cmd.Parameters.Add("@tintNufusIlID", SqlDbType.TinyInt).Value = this._tintNufusIlID;
                cmd.Parameters.Add("@sintNufusIlceID", SqlDbType.SmallInt).Value = this._sintNufusIlceID;
                cmd.Parameters.Add("@tintMedeniDurumID", SqlDbType.TinyInt).Value = this._tintMedeniDurumID;
                cmd.Parameters.Add("@strAnneBaba", SqlDbType.NVarChar, 40).Value = this._strAnneBaba;
                cmd.Parameters.Add("@blSurucuBelge", SqlDbType.Bit).Value = this._blSurucuBelge;
                cmd.Parameters.Add("@tintSurucuBelgeSinifiID", SqlDbType.TinyInt).Value = this._tintSurucuBelgeSinifiID;
                cmd.Parameters.Add("@dtSurucuBelgeTarihi", SqlDbType.SmallDateTime).Value = this._dtSurucuBelgeTarihi;
                cmd.Parameters.Add("@blPsikoteknik", SqlDbType.Bit).Value = this._blPsikoteknik;
                cmd.Parameters.Add("@tintSRC", SqlDbType.TinyInt).Value = this._tintSRC;
                cmd.Parameters.Add("@strBoy", SqlDbType.NVarChar, 5).Value = this._strBoy;
                cmd.Parameters.Add("@strKilo", SqlDbType.NVarChar, 5).Value = this._strKilo;
                cmd.Parameters.Add("@strKardesSayisi", SqlDbType.NVarChar, 2).Value = this._strKardesSayisi;
                cmd.Parameters.Add("@strAdres", SqlDbType.NVarChar, 200).Value = this._strAdres;
                cmd.Parameters.Add("@strEvTelefonu", SqlDbType.VarChar, 15).Value = this._strEvTelefonu;
                cmd.Parameters.Add("@strCepTelefonu", SqlDbType.VarChar, 15).Value = this._strCepTelefonu;
                cmd.Parameters.Add("@sintAdresIlceID", SqlDbType.SmallInt).Value = this._sintAdresIlceID;
                cmd.Parameters.Add("@tintAdresIlID", SqlDbType.TinyInt).Value = this._tintAdresIlID;
                cmd.Parameters.Add("@strEposta", SqlDbType.NVarChar, 50).Value = this._strEposta;
                cmd.Parameters.Add("@strWebSayfasi", SqlDbType.NVarChar, 50).Value = this._strWebSayfasi;
                cmd.Parameters.Add("@strEsAd", SqlDbType.NVarChar, 50).Value = this._strEsAd;
                cmd.Parameters.Add("@strEsSoyad", SqlDbType.NVarChar, 50).Value = this._strEsSoyad;
                cmd.Parameters.Add("@strEsMeslek", SqlDbType.NVarChar, 80).Value = this._strEsMeslek;
                cmd.Parameters.Add("@dtEsDogumTarihi", SqlDbType.SmallDateTime).Value = this._dtEsDogumTarihi;
                cmd.Parameters.Add("@tintAskerlikDurumuID", SqlDbType.TinyInt).Value = this._tintAskerlikDurumuID;
                cmd.Parameters.Add("@tintAskerlikTipID", SqlDbType.TinyInt).Value = this._tintAskerlikTipID;
                cmd.Parameters.Add("@dtTerhisTarihi", SqlDbType.SmallDateTime).Value = this._dtTerhisTarihi;
                cmd.Parameters.Add("@dtTecilTarihi", SqlDbType.SmallDateTime).Value = this._dtTecilTarihi;
                cmd.Parameters.Add("@strMuafNedeni", SqlDbType.NVarChar, 80).Value = this._strMuafNedeni;
                cmd.Parameters.Add("@strAskerlikSinifi", SqlDbType.NVarChar, 30).Value = this._strAskerlikSinifi;
                cmd.Parameters.Add("@tintOgrenimDurumuID", SqlDbType.TinyInt).Value = this._tintOgrenimDurumuID;
                cmd.Parameters.Add("@blMahkeme", SqlDbType.Bit).Value = this._blMahkeme;
                cmd.Parameters.Add("@strMahkemeNedeni", SqlDbType.NVarChar, 100).Value = this._strMahkemeNedeni;
                cmd.Parameters.Add("@dtMahkemeDurusmaTarihi", SqlDbType.SmallDateTime).Value = this._dtMahkemeDurusmaTarihi;
                cmd.Parameters.Add("@blMahkumiyet", SqlDbType.Bit).Value = this._blMahkumiyet;
                cmd.Parameters.Add("@strMahkumiyetNedeni", SqlDbType.NVarChar, 100).Value = this._strMahkumiyetNedeni;
                cmd.Parameters.Add("@dtMahkumiyetTahliye", SqlDbType.SmallDateTime).Value = this._dtMahkumiyetTahliye;
                cmd.Parameters.Add("@strBakmaklaYukumluYakin", SqlDbType.NVarChar, 100).Value = this._strBakmaklaYukumluYakin;
                cmd.Parameters.Add("@strTedaviyeMuhtacYakin", SqlDbType.NVarChar, 100).Value = this._strTedaviyeMuhtacYakin;
                cmd.Parameters.Add("@blKrediKartiTakibat", SqlDbType.Bit).Value = this._blKrediKartiTakibat;
                cmd.Parameters.Add("@strKrediKartiTakibat", SqlDbType.NVarChar, 150).Value = this._strKrediKartiTakibat;
                cmd.Parameters.Add("@blSurenHastalik", SqlDbType.Bit).Value = this._blSurenHastalik;
                cmd.Parameters.Add("@strSurenHastalik", SqlDbType.NVarChar, 100).Value = this._strSurenHastalik;
                cmd.Parameters.Add("@blOnemliAmeliyat", SqlDbType.Bit).Value = this._blOnemliAmeliyat;
                cmd.Parameters.Add("@strOnemliAmeliyat", SqlDbType.NVarChar, 100).Value = this._strOnemliAmeliyat;
                cmd.Parameters.Add("@blSakatlik", SqlDbType.Bit).Value = this._blSakatlik;
                cmd.Parameters.Add("@strSakatlik", SqlDbType.NVarChar, 100).Value = this._strSakatlik;
                cmd.Parameters.Add("@blEvSizin", SqlDbType.Bit).Value = this._blEvSizin;
                cmd.Parameters.Add("@blBaskaEv", SqlDbType.Bit).Value = this._blBaskaEv;
                cmd.Parameters.Add("@strBaskaEvAdresDurum", SqlDbType.NVarChar, 200).Value = this._strBaskaEvAdresDurum;
                cmd.Parameters.Add("@blOtomobil", SqlDbType.Bit).Value = this._blOtomobil;
                cmd.Parameters.Add("@strOtomobilMarkaModelDurum", SqlDbType.NVarChar, 150).Value = this._strOtomobilMarkaModelDurum;
                cmd.Parameters.Add("@strUyeDernekKlupKurulus", SqlDbType.NVarChar, 100).Value = this._strUyeDernekKlupKurulus;
                cmd.Parameters.Add("@strOzelMerakHobi", SqlDbType.NVarChar, 100).Value = this._strOzelMerakHobi;
                cmd.Parameters.Add("@strBildigiBilgisayarProgramiDiger", SqlDbType.NVarChar, 70).Value = this._strBildigiBilgisayarProgramiDiger;
                cmd.Parameters.Add("@strMeslekBasari", SqlDbType.NVarChar, 100).Value = this._strMeslekBasari;
                cmd.Parameters.Add("@strSirketTanidik", SqlDbType.NVarChar, 150).Value = this._strSirketTanidik;
                cmd.Parameters.Add("@blDahaOnceBasvuru", SqlDbType.Bit).Value = this._blDahaOnceBasvuru;
                cmd.Parameters.Add("@strTalepUcret", SqlDbType.NVarChar, 50).Value = this._strTalepUcret;
                cmd.Parameters.Add("@dtIsBaslangicTarihi", SqlDbType.SmallDateTime).Value = this._dtIsBaslangicTarihi;
                cmd.Parameters.Add("@blSigara", SqlDbType.Bit).Value = this._blSigara;
                cmd.Parameters.Add("@strIsOzelBeklenti", SqlDbType.NVarChar, 100).Value = this._strIsOzelBeklenti;
                cmd.Parameters.Add("@blVardiyaliCalisma", SqlDbType.Bit).Value = this._blVardiyaliCalisma;
                cmd.Parameters.Add("@blSehirDisiCalisma", SqlDbType.Bit).Value = this._blSehirDisiCalisma;
                cmd.Parameters.Add("@strSehirDisiCalismaKisitlama", SqlDbType.NVarChar, 100).Value = this._strSehirDisiCalismaKisitlama;
                cmd.Parameters.Add("@strCalismaHayatiBeklenti", SqlDbType.NVarChar, 300).Value = this._strCalismaHayatiBeklenti;
                cmd.Parameters.Add("@dtBasvuruTarihi", SqlDbType.SmallDateTime).Value = this._dtBasvuruTarihi;
                cmd.Parameters.Add("@strFotograf", SqlDbType.NVarChar, 100).Value = this._strFotograf;
                cmd.Parameters.Add("@binResim", SqlDbType.VarBinary).Value = this._binResim;
                cmd.Parameters.Add("@blSilindi", SqlDbType.Bit).Value = this._blSilindi;
                cmd.Parameters.Add("@intArananGorevID", SqlDbType.Int).Value = this._intArananGorevID;
                cmd.Parameters.Add("@blEpostaIleYollandi", SqlDbType.Bit).Value = this._blEpostaIleYollandi;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //
        //
        public static void DoEpostaOK(int BasvuruID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_BasvuruEpostaGonderildi", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkBasvuruID", SqlDbType.Int).Value = BasvuruID;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //
        //
        public void DoDelete()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_BasvuruSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkBasvuruID", SqlDbType.Int).Value = this._pkBasvuruID;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //
        //
        public void DoRestore()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_BasvuruGeriDondur", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkBasvuruID", SqlDbType.Int).Value = this._pkBasvuruID;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //
        //
        public static void GetObject(IList List, bool silinmemis)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if (silinmemis)
                {
                    cmd.CommandText = "sp_BasvuruGetir";
                }
                else
                {
                    cmd.CommandText = "sp_BasvuruGetirSilinenler";
                }

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;

                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new Basvurular(Convert.ToInt32(dr[0]), StringParcalama.IlkHarfBuyuk(dr[1].ToString()), StringParcalama.IlkHarfBuyuk(dr[2].ToString()), dr[3].ToString(), Convert.ToByte(dr[4]), Convert.ToBoolean(dr[5]),
                            dr[6].ToString(), Convert.ToByte(dr[7]), Convert.ToInt16(dr[8]), Convert.ToByte(dr[9]), dr[10].ToString(), Convert.ToBoolean(dr[11]),
                            Convert.ToByte(dr[12]), dr[13].ToString(), Convert.ToBoolean(dr[14]), Convert.ToByte(dr[15]), dr[16].ToString(), dr[17].ToString(),
                            dr[18].ToString(), dr[19].ToString(), dr[20].ToString(), dr[21].ToString(), Convert.ToInt16(dr[22]), Convert.ToByte(dr[23]), dr[24].ToString(),
                            dr[25].ToString(), dr[26].ToString(), dr[27].ToString(), dr[28].ToString(), dr[29].ToString(), Convert.ToByte(dr[30]), Convert.ToByte(dr[31]),
                            dr[32].ToString(), dr[33].ToString(), dr[34].ToString(), dr[35].ToString(), Convert.ToByte(dr[36]), Convert.ToBoolean(dr[37]), dr[38].ToString(),
                            dr[39].ToString(), Convert.ToBoolean(dr[40]), dr[41].ToString(), dr[42].ToString(), dr[43].ToString(), dr[44].ToString(), Convert.ToBoolean(dr[45]),
                            dr[46].ToString(), Convert.ToBoolean(dr[47]), dr[48].ToString(), Convert.ToBoolean(dr[49]), dr[50].ToString(), Convert.ToBoolean(dr[51]),
                            dr[52].ToString(), Convert.ToBoolean(dr[53]), Convert.ToBoolean(dr[54]), dr[55].ToString(), Convert.ToBoolean(dr[56]), dr[57].ToString(),
                            dr[58].ToString(), dr[59].ToString(), dr[60].ToString(), dr[61].ToString(), dr[62].ToString(), Convert.ToBoolean(dr[63]), dr[64].ToString(),
                            dr[65].ToString(), Convert.ToBoolean(dr[66]), dr[67].ToString(), Convert.ToBoolean(dr[68]), Convert.ToBoolean(dr[69]), dr[70].ToString(),
                            dr[71].ToString(), DateTime.Parse(dr[72].ToString()), dr[73].ToString(), Convert.ToBoolean(dr[74]), dr[75], Convert.ToInt32(dr[76]), 
                            Convert.ToBoolean(dr[77])));
                    }
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
