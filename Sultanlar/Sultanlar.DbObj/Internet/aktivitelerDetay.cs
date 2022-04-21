using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class aktivitelerDetay : DbObj
    {
        public long pkID { get; set; }
        public int intAktiviteID { get; set; }
        //public aktiviteler Aktivite { get { return new aktiviteler(intAktiviteID).GetObject(); } }
        public int intUrunID { get; set; }
        public malzemeler Malzeme { get { return new malzemeler(intUrunID).GetObject(); } }
        public string strUrunAdi { get; set; }
        public int intKoliAdet { get; set; }
        public double mnBirimFiyatKDVli { get; set; }
        public double mnAksiyonFiyati { get; set; }
        public double flMusteriKarYuzde { get; set; }
        public string strSatisHedefi { get; set; }
        public double mnTutar { get; set; }
        public double flEkIsk { get; set; }
        public double flCiroPrimDonusYuzde { get; set; }
        public double mnBayiMaliyet { get; set; }
        public double mnDusulmusBirimFiyatKDVli { get; set; }
        public double flKarZararYuzde { get; set; }
        public double mnToplam { get; set; }
        public string strAciklama1 { get; set; }
        public string strAciklama2 { get; set; }
        public string strAciklama3 { get; set; }
        public string strAciklama4 { get; set; }
        public string strAciklama5 { get; set; }
        public double KDVsiz { 
            get 
            {
                aktiviteler akt = new aktiviteler(intAktiviteID).GetObject();
                fiyatlarTp ftp = new fiyatlarTp().GetObject(akt.DonemYil, akt.DonemAy, akt.DonemGun, akt.sintFiyatTipiID, intUrunID);
                return mnDusulmusBirimFiyatKDVli / ((100 + ftp.KDV) / 100); 
            }
        }
        public bool Degisti { get { return flEkIsk.ToString("N2") != mnBayiMaliyet.ToString("N2"); } }

        public aktivitelerDetay() { }
        public aktivitelerDetay(long pkID) { this.pkID = pkID; }
        public aktivitelerDetay(int intAktiviteID, int intUrunID, string strUrunAdi, int intKoliAdet, double mnBirimFiyatKDVli, double mnAksiyonFiyati, double flMusteriKarYuzde, string strSatisHedefi, double mnTutar, double flEkIsk, double flCiroPrimDonusYuzde, double mnBayiMaliyet, double mnDusulmusBirimFiyatKDVli, double flKarZararYuzde, double mnToplam, string strAciklama1, string strAciklama2, string strAciklama3, string strAciklama4, string strAciklama5)
        {
            this.intAktiviteID = intAktiviteID;
            this.intUrunID = intUrunID;
            this.intKoliAdet = intKoliAdet;
            this.strUrunAdi = strUrunAdi;
            this.mnBirimFiyatKDVli = mnBirimFiyatKDVli;
            this.mnAksiyonFiyati = mnAksiyonFiyati;
            this.flMusteriKarYuzde = flMusteriKarYuzde;
            this.strSatisHedefi = strSatisHedefi;
            this.mnTutar = mnTutar;
            this.flEkIsk = flEkIsk;
            this.flCiroPrimDonusYuzde = flCiroPrimDonusYuzde;
            this.mnBayiMaliyet = mnBayiMaliyet;
            this.mnDusulmusBirimFiyatKDVli = mnDusulmusBirimFiyatKDVli;
            this.flKarZararYuzde = flKarZararYuzde;
            this.mnToplam = mnToplam;
            this.strAciklama1 = strAciklama1;
            this.strAciklama2 = strAciklama2;
            this.strAciklama3 = strAciklama3;
            this.strAciklama4 = strAciklama4;
            this.strAciklama5 = strAciklama5;
        }
        private aktivitelerDetay(long pkID, int intAktiviteID, int intUrunID, string strUrunAdi, int intKoliAdet, double mnBirimFiyatKDVli, double mnAksiyonFiyati, double flMusteriKarYuzde, string strSatisHedefi, double mnTutar, double flEkIsk, double flCiroPrimDonusYuzde, double mnBayiMaliyet, double mnDusulmusBirimFiyatKDVli, double flKarZararYuzde, double mnToplam, string strAciklama1, string strAciklama2, string strAciklama3, string strAciklama4, string strAciklama5)
        {
            this.pkID = pkID;
            this.intAktiviteID = intAktiviteID;
            this.intUrunID = intUrunID;
            this.intKoliAdet = intKoliAdet;
            this.strUrunAdi = strUrunAdi;
            this.mnBirimFiyatKDVli = mnBirimFiyatKDVli;
            this.mnAksiyonFiyati = mnAksiyonFiyati;
            this.flMusteriKarYuzde = flMusteriKarYuzde;
            this.strSatisHedefi = strSatisHedefi;
            this.mnTutar = mnTutar;
            this.flEkIsk = flEkIsk;
            this.flCiroPrimDonusYuzde = flCiroPrimDonusYuzde;
            this.mnBayiMaliyet = mnBayiMaliyet;
            this.mnDusulmusBirimFiyatKDVli = mnDusulmusBirimFiyatKDVli;
            this.flKarZararYuzde = flKarZararYuzde;
            this.mnToplam = mnToplam;
            this.strAciklama1 = strAciklama1;
            this.strAciklama2 = strAciklama2;
            this.strAciklama3 = strAciklama3;
            this.strAciklama4 = strAciklama4;
            this.strAciklama5 = strAciklama5;
        }

        public override string ToString() { return pkID.ToString(); }
        /// <summary>
        /// 
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkID", pkID }, { "intAktiviteID", intAktiviteID }, { "intUrunID", intUrunID }, { "strUrunAdi", strUrunAdi }, { "intKoliAdet", intKoliAdet }, { "mnBirimFiyatKDVli", mnBirimFiyatKDVli }, { "mnAksiyonFiyati", mnAksiyonFiyati }, { "flMusteriKarYuzde", flMusteriKarYuzde }, { "strSatisHedefi", strSatisHedefi }, { "mnTutar", mnTutar }, { "flEkIsk", flEkIsk }, { "flCiroPrimDonusYuzde", flCiroPrimDonusYuzde }, { "mnBayiMaliyet", mnBayiMaliyet }, { "mnDusulmusBirimFiyatKDVli", mnDusulmusBirimFiyatKDVli }, { "flKarZararYuzde", flKarZararYuzde }, { "mnToplam", mnToplam }, { "strAciklama1", strAciklama1 }, { "strAciklama2", strAciklama2 }, { "strAciklama3", strAciklama3 }, { "strAciklama4", strAciklama4 }, { "strAciklama5", strAciklama5 } };
            pkID = ConvertToInt32(Do(QueryType.Insert, "db_sp_aktivitelerDetayEkle", param, timeout));
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "pkID", pkID }, { "intAktiviteID", intAktiviteID }, { "intUrunID", intUrunID }, { "strUrunAdi", strUrunAdi }, { "intKoliAdet", intKoliAdet }, { "mnBirimFiyatKDVli", mnBirimFiyatKDVli }, { "mnAksiyonFiyati", mnAksiyonFiyati }, { "flMusteriKarYuzde", flMusteriKarYuzde }, { "strSatisHedefi", strSatisHedefi }, { "mnTutar", mnTutar }, { "flEkIsk", flEkIsk }, { "flCiroPrimDonusYuzde", flCiroPrimDonusYuzde }, { "mnBayiMaliyet", mnBayiMaliyet }, { "mnDusulmusBirimFiyatKDVli", mnDusulmusBirimFiyatKDVli }, { "flKarZararYuzde", flKarZararYuzde }, { "mnToplam", mnToplam }, { "strAciklama1", strAciklama1 }, { "strAciklama2", strAciklama2 }, { "strAciklama3", strAciklama3 }, { "strAciklama4", strAciklama4 }, { "strAciklama5", strAciklama5 } };
            Do(QueryType.Update, "db_sp_aktivitelerDetayGuncelle", param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoDelete()
        {
            Do(QueryType.Delete, "db_sp_aktivitelerDetaySil", new Dictionary<string, object>() { { "pkID", pkID } }, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public aktivitelerDetay GetObject()
        {
            aktivitelerDetay donendeger = new aktivitelerDetay();

            Dictionary<int, object> dic = GetObject("db_sp_aktivitelerDetayGetir", new Dictionary<string, object>() { { "pkID", pkID } }, timeout);
            if (dic != null)
                donendeger = new aktivitelerDetay(ConvertToInt64(dic[0]), ConvertToInt32(dic[1]), ConvertToInt32(dic[2]), dic[3].ToString(), ConvertToInt32(dic[4]), ConvertToDouble(dic[5]), ConvertToDouble(dic[6]), ConvertToDouble(dic[7]), dic[8].ToString(), ConvertToDouble(dic[9]), ConvertToDouble(dic[10]), ConvertToDouble(dic[11]), ConvertToDouble(dic[12]), ConvertToDouble(dic[13]), ConvertToDouble(dic[14]), ConvertToDouble(dic[15]), dic[16].ToString(), dic[17].ToString(), dic[18].ToString(), dic[19].ToString(), dic[20].ToString());

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<aktivitelerDetay> GetObjects(int intAktiviteID)
        {
            List<aktivitelerDetay> donendeger = new List<aktivitelerDetay>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_aktivitelerDetaylarGetir", new Dictionary<string, object>() { { "intAktiviteID", intAktiviteID } }, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new aktivitelerDetay(ConvertToInt64(dic[i][0]), ConvertToInt32(dic[i][1]), ConvertToInt32(dic[i][2]), dic[i][3].ToString(), ConvertToInt32(dic[i][4]), ConvertToDouble(dic[i][5]), ConvertToDouble(dic[i][6]), ConvertToDouble(dic[i][7]), dic[i][8].ToString(), ConvertToDouble(dic[i][9]), ConvertToDouble(dic[i][10]), ConvertToDouble(dic[i][11]), ConvertToDouble(dic[i][12]), ConvertToDouble(dic[i][13]), ConvertToDouble(dic[i][14]), ConvertToDouble(dic[i][15]), dic[i][16].ToString(), dic[i][17].ToString(), dic[i][18].ToString(), dic[i][19].ToString(), dic[i][20].ToString()));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public aktivitelerDetay GetObjectSon(int SMREF, int ITEMREF, DateTime Tarih)
        {
            aktivitelerDetay donendeger = new aktivitelerDetay();

            Dictionary<int, object> dic = GetObject("db_sp_aktivitelerDetayGetirSon", new Dictionary<string, object>() { { "SMREF", SMREF }, { "ITEMREF", ITEMREF }, { "Tarih", Tarih } }, timeout);
            if (dic != null)
                donendeger = new aktivitelerDetay(ConvertToInt64(dic[0]), ConvertToInt32(dic[1]), ConvertToInt32(dic[2]), dic[3].ToString(), ConvertToInt32(dic[4]), ConvertToDouble(dic[5]), ConvertToDouble(dic[6]), ConvertToDouble(dic[7]), dic[8].ToString(), ConvertToDouble(dic[9]), ConvertToDouble(dic[10]), ConvertToDouble(dic[11]), ConvertToDouble(dic[12]), ConvertToDouble(dic[13]), ConvertToDouble(dic[14]), ConvertToDouble(dic[15]), dic[16].ToString(), dic[17].ToString(), dic[18].ToString(), dic[19].ToString(), dic[20].ToString());

            return donendeger;
        }
    }
}
