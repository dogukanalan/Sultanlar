using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sultanlar.DatabaseObject.Internet;
using System.Data;
using System.Collections;

namespace Sultanlar.WebUI.musteri
{
    public class SatisHedefYil : IDisposable
    {
        // Alanlar
        public string _Isim;
        public string _HAy1;
        public string _HAy2;
        public string _HAy3;
        public string _HAy4;
        public string _HAy5;
        public string _HAy6;
        public string _HAy7;
        public string _HAy8;
        public string _HAy9;
        public string _HAy10;
        public string _HAy11;
        public string _HAy12;
        public string _NAy1;
        public string _NAy2;
        public string _NAy3;
        public string _NAy4;
        public string _NAy5;
        public string _NAy6;
        public string _NAy7;
        public string _NAy8;
        public string _NAy9;
        public string _NAy10;
        public string _NAy11;
        public string _NAy12;

        // Constracter lar
        public SatisHedefYil(string Isim, string HAy1, string HAy2, string HAy3, string HAy4, string HAy5, string HAy6, string HAy7, string HAy8,
            string HAy9, string HAy10, string HAy11, string HAy12, string NAy1, string NAy2, string NAy3, string NAy4, string NAy5, string NAy6, 
            string NAy7, string NAy8, string NAy9, string NAy10, string NAy11, string NAy12)
        {
            this._Isim = Isim;
            this._NAy1 = NAy1;
            this._NAy2 = NAy2;
            this._NAy3 = NAy3;
            this._NAy4 = NAy4;
            this._NAy5 = NAy5;
            this._NAy6 = NAy6;
            this._NAy7 = NAy7;
            this._NAy8 = NAy8;
            this._NAy9 = NAy9;
            this._NAy10 = NAy10;
            this._NAy11 = NAy11;
            this._NAy12 = NAy12;
            this._HAy1 = HAy1;
            this._HAy2 = HAy2;
            this._HAy3 = HAy3;
            this._HAy4 = HAy4;
            this._HAy5 = HAy5;
            this._HAy6 = HAy6;
            this._HAy7 = HAy7;
            this._HAy8 = HAy8;
            this._HAy9 = HAy9;
            this._HAy10 = HAy10;
            this._HAy11 = HAy11;
            this._HAy12 = HAy12;
        }

        public SatisHedefYil(int SLSREF, string Kategori, int Yil)
        {
            this._Isim = SatisTemsilcileri.GetObjectBySLSREF(SLSREF.ToString());
            this._NAy1 = SatisHedef.GetToplamlarByAy(SLSREF, Kategori, Yil, 1)[2].ToString().Replace(",", ".");
            this._NAy2 = SatisHedef.GetToplamlarByAy(SLSREF, Kategori, Yil, 2)[2].ToString().Replace(",", ".");
            this._NAy3 = SatisHedef.GetToplamlarByAy(SLSREF, Kategori, Yil, 3)[2].ToString().Replace(",", ".");
            this._NAy4 = SatisHedef.GetToplamlarByAy(SLSREF, Kategori, Yil, 4)[2].ToString().Replace(",", ".");
            this._NAy5 = SatisHedef.GetToplamlarByAy(SLSREF, Kategori, Yil, 5)[2].ToString().Replace(",", ".");
            this._NAy6 = SatisHedef.GetToplamlarByAy(SLSREF, Kategori, Yil, 6)[2].ToString().Replace(",", ".");
            this._NAy7 = SatisHedef.GetToplamlarByAy(SLSREF, Kategori, Yil, 7)[2].ToString().Replace(",", ".");
            this._NAy8 = SatisHedef.GetToplamlarByAy(SLSREF, Kategori, Yil, 8)[2].ToString().Replace(",", ".");
            this._NAy9 = SatisHedef.GetToplamlarByAy(SLSREF, Kategori, Yil, 9)[2].ToString().Replace(",", ".");
            this._NAy10 = SatisHedef.GetToplamlarByAy(SLSREF, Kategori, Yil, 10)[2].ToString().Replace(",", ".");
            this._NAy11 = SatisHedef.GetToplamlarByAy(SLSREF, Kategori, Yil, 11)[2].ToString().Replace(",", ".");
            this._NAy12 = SatisHedef.GetToplamlarByAy(SLSREF, Kategori, Yil, 12)[2].ToString().Replace(",", ".");
            this._HAy1 = SatisHedef.GetToplamlarByAy(SLSREF, Kategori, Yil, 1)[0].ToString().Replace(",", ".");
            this._HAy2 = SatisHedef.GetToplamlarByAy(SLSREF, Kategori, Yil, 2)[0].ToString().Replace(",", ".");
            this._HAy3 = SatisHedef.GetToplamlarByAy(SLSREF, Kategori, Yil, 3)[0].ToString().Replace(",", ".");
            this._HAy4 = SatisHedef.GetToplamlarByAy(SLSREF, Kategori, Yil, 4)[0].ToString().Replace(",", ".");
            this._HAy5 = SatisHedef.GetToplamlarByAy(SLSREF, Kategori, Yil, 5)[0].ToString().Replace(",", ".");
            this._HAy6 = SatisHedef.GetToplamlarByAy(SLSREF, Kategori, Yil, 6)[0].ToString().Replace(",", ".");
            this._HAy7 = SatisHedef.GetToplamlarByAy(SLSREF, Kategori, Yil, 7)[0].ToString().Replace(",", ".");
            this._HAy8 = SatisHedef.GetToplamlarByAy(SLSREF, Kategori, Yil, 8)[0].ToString().Replace(",", ".");
            this._HAy9 = SatisHedef.GetToplamlarByAy(SLSREF, Kategori, Yil, 9)[0].ToString().Replace(",", ".");
            this._HAy10 = SatisHedef.GetToplamlarByAy(SLSREF, Kategori, Yil, 10)[0].ToString().Replace(",", ".");
            this._HAy11 = SatisHedef.GetToplamlarByAy(SLSREF, Kategori, Yil, 11)[0].ToString().Replace(",", ".");
            this._HAy12 = SatisHedef.GetToplamlarByAy(SLSREF, Kategori, Yil, 12)[0].ToString().Replace(",", ".");
        }

        // Dispose
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

    public class SatisHedefAy : IDisposable
    {
        // Alanlar
        public string _Isim;
        public string _HGun1;
        public string _HGun2;
        public string _HGun3;
        public string _HGun4;
        public string _HGun5;
        public string _HGun6;
        public string _HGun7;
        public string _HGun8;
        public string _HGun9;
        public string _HGun10;
        public string _HGun11;
        public string _HGun12;
        public string _HGun13;
        public string _HGun14;
        public string _HGun15;
        public string _HGun16;
        public string _HGun17;
        public string _HGun18;
        public string _HGun19;
        public string _HGun20;
        public string _HGun21;
        public string _HGun22;
        public string _HGun23;
        public string _HGun24;
        public string _HGun25;
        public string _HGun26;
        public string _HGun27;
        public string _HGun28;
        public string _HGun29;
        public string _HGun30;
        public string _HGun31;
        public string _NGun1;
        public string _NGun2;
        public string _NGun3;
        public string _NGun4;
        public string _NGun5;
        public string _NGun6;
        public string _NGun7;
        public string _NGun8;
        public string _NGun9;
        public string _NGun10;
        public string _NGun11;
        public string _NGun12;
        public string _NGun13;
        public string _NGun14;
        public string _NGun15;
        public string _NGun16;
        public string _NGun17;
        public string _NGun18;
        public string _NGun19;
        public string _NGun20;
        public string _NGun21;
        public string _NGun22;
        public string _NGun23;
        public string _NGun24;
        public string _NGun25;
        public string _NGun26;
        public string _NGun27;
        public string _NGun28;
        public string _NGun29;
        public string _NGun30;
        public string _NGun31;

        // Constracter lar
        public SatisHedefAy(string Isim, string HGun1, string HGun2, string HGun3, string HGun4, string HGun5, string HGun6, string HGun7,
            string HGun8, string HGun9, string HGun10, string HGun11, string HGun12, string HGun13, string HGun14, string HGun15, string HGun16,
            string HGun17, string HGun18, string HGun19, string HGun20, string HGun21, string HGun22, string HGun23, string HGun24, string HGun25,
            string HGun26, string HGun27, string HGun28, string HGun29, string HGun30, string HGun31, string NGun1, string NGun2, string NGun3,
            string NGun4, string NGun5, string NGun6, string NGun7, string NGun8, string NGun9, string NGun10, string NGun11, string NGun12,
            string NGun13, string NGun14, string NGun15, string NGun16, string NGun17, string NGun18, string NGun19, string NGun20, string NGun21,
            string NGun22, string NGun23, string NGun24, string NGun25, string NGun26, string NGun27, string NGun28, string NGun29, string NGun30,
            string NGun31)
        {
            this._Isim = Isim;
            this._NGun1 = NGun1;
            this._NGun2 = NGun2;
            this._NGun3 = NGun3;
            this._NGun4 = NGun4;
            this._NGun5 = NGun5;
            this._NGun6 = NGun6;
            this._NGun7 = NGun7;
            this._NGun8 = NGun8;
            this._NGun9 = NGun9;
            this._NGun10 = NGun10;
            this._NGun11 = NGun11;
            this._NGun12 = NGun12;
            this._NGun13 = NGun13;
            this._NGun14 = NGun14;
            this._NGun15 = NGun15;
            this._NGun16 = NGun16;
            this._NGun17 = NGun17;
            this._NGun18 = NGun18;
            this._NGun19 = NGun19;
            this._NGun20 = NGun20;
            this._NGun21 = NGun21;
            this._NGun22 = NGun22;
            this._NGun23 = NGun23;
            this._NGun24 = NGun24;
            this._NGun25 = NGun25;
            this._NGun26 = NGun26;
            this._NGun27 = NGun27;
            this._NGun28 = NGun28;
            this._NGun29 = NGun29;
            this._NGun30 = NGun30;
            this._NGun31 = NGun31;
            this._HGun1 = HGun1;
            this._HGun2 = HGun2;
            this._HGun3 = HGun3;
            this._HGun4 = HGun4;
            this._HGun5 = HGun5;
            this._HGun6 = HGun6;
            this._HGun7 = HGun7;
            this._HGun8 = HGun8;
            this._HGun9 = HGun9;
            this._HGun10 = HGun10;
            this._HGun11 = HGun11;
            this._HGun12 = HGun12;
            this._HGun13 = HGun13;
            this._HGun14 = HGun14;
            this._HGun15 = HGun15;
            this._HGun16 = HGun16;
            this._HGun17 = HGun17;
            this._HGun18 = HGun18;
            this._HGun19 = HGun19;
            this._HGun20 = HGun20;
            this._HGun21 = HGun21;
            this._HGun22 = HGun22;
            this._HGun23 = HGun23;
            this._HGun24 = HGun24;
            this._HGun25 = HGun25;
            this._HGun26 = HGun26;
            this._HGun27 = HGun27;
            this._HGun28 = HGun28;
            this._HGun29 = HGun29;
            this._HGun30 = HGun30;
            this._HGun31 = HGun31;
        }

        public SatisHedefAy(int SLSREF, string Kategori, int Yil, int Ay)
        {
            this._Isim = SatisTemsilcileri.GetObjectBySLSREF(SLSREF.ToString());

            DataTable dt = SatisHedef.GetToplamlarGunGunByAy(SLSREF, Kategori, Yil, Ay);

            if (dt.Rows.Count > 0) this._NGun1 = dt.Rows[0][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun1 = "0";
            if (dt.Rows.Count > 1) this._NGun2 = dt.Rows[1][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[1][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun2 = "0";
            if (dt.Rows.Count > 2) this._NGun3 = dt.Rows[2][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[2][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun3 = "0";
            if (dt.Rows.Count > 3) this._NGun4 = dt.Rows[3][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[3][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun4 = "0";
            if (dt.Rows.Count > 4) this._NGun5 = dt.Rows[4][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[4][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun5 = "0";
            if (dt.Rows.Count > 5) this._NGun6 = dt.Rows[5][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[5][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun6 = "0";
            if (dt.Rows.Count > 6) this._NGun7 = dt.Rows[6][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[6][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun7 = "0";
            if (dt.Rows.Count > 7) this._NGun8 = dt.Rows[7][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[7][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun8 = "0";
            if (dt.Rows.Count > 8) this._NGun9 = dt.Rows[8][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[8][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun9 = "0";
            if (dt.Rows.Count > 9) this._NGun10 = dt.Rows[9][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[9][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun10 = "0";
            if (dt.Rows.Count > 10) this._NGun11 = dt.Rows[10][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[10][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun11 = "0";
            if (dt.Rows.Count > 11) this._NGun12 = dt.Rows[11][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[11][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun12 = "0";
            if (dt.Rows.Count > 12) this._NGun13 = dt.Rows[12][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[12][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun13 = "0";
            if (dt.Rows.Count > 13) this._NGun14 = dt.Rows[13][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[13][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun14 = "0";
            if (dt.Rows.Count > 14) this._NGun15 = dt.Rows[14][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[14][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun15 = "0";
            if (dt.Rows.Count > 15) this._NGun16 = dt.Rows[15][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[15][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun16 = "0";
            if (dt.Rows.Count > 16) this._NGun17 = dt.Rows[16][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[16][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun17 = "0";
            if (dt.Rows.Count > 17) this._NGun18 = dt.Rows[17][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[17][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun18 = "0";
            if (dt.Rows.Count > 18) this._NGun19 = dt.Rows[18][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[18][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun19 = "0";
            if (dt.Rows.Count > 19) this._NGun20 = dt.Rows[19][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[19][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun20 = "0";
            if (dt.Rows.Count > 20) this._NGun21 = dt.Rows[20][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[20][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun21 = "0";
            if (dt.Rows.Count > 21) this._NGun22 = dt.Rows[21][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[21][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun22 = "0";
            if (dt.Rows.Count > 22) this._NGun23 = dt.Rows[22][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[22][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun23 = "0";
            if (dt.Rows.Count > 23) this._NGun24 = dt.Rows[23][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[23][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun24 = "0";
            if (dt.Rows.Count > 24) this._NGun25 = dt.Rows[24][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[24][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun25 = "0";
            if (dt.Rows.Count > 25) this._NGun26 = dt.Rows[25][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[25][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun26 = "0";
            if (dt.Rows.Count > 26) this._NGun27 = dt.Rows[26][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[26][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun27 = "0";
            if (dt.Rows.Count > 27) this._NGun28 = dt.Rows[27][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[27][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun28 = "0";
            if (dt.Rows.Count > 28) this._NGun29 = dt.Rows[28][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[28][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun29 = "0";
            if (dt.Rows.Count > 29) this._NGun30 = dt.Rows[29][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[29][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun30 = "0";
            if (dt.Rows.Count > 30) this._NGun31 = dt.Rows[30][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[30][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun31 = "0";
            if (dt.Rows.Count > 0) this._HGun1 = dt.Rows[0][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun1 = "0";
            if (dt.Rows.Count > 1) this._HGun2 = dt.Rows[1][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[1][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun2 = "0";
            if (dt.Rows.Count > 2) this._HGun3 = dt.Rows[2][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[2][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun3 = "0";
            if (dt.Rows.Count > 3) this._HGun4 = dt.Rows[3][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[3][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun4 = "0";
            if (dt.Rows.Count > 4) this._HGun5 = dt.Rows[4][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[4][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun5 = "0";
            if (dt.Rows.Count > 5) this._HGun6 = dt.Rows[5][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[5][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun6 = "0";
            if (dt.Rows.Count > 6) this._HGun7 = dt.Rows[6][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[6][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun7 = "0";
            if (dt.Rows.Count > 7) this._HGun8 = dt.Rows[7][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[7][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun8 = "0";
            if (dt.Rows.Count > 8) this._HGun9 = dt.Rows[8][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[8][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun9 = "0";
            if (dt.Rows.Count > 9) this._HGun10 = dt.Rows[9][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[9][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun10 = "0";
            if (dt.Rows.Count > 10) this._HGun11 = dt.Rows[10][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[10][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun11 = "0";
            if (dt.Rows.Count > 11) this._HGun12 = dt.Rows[11][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[11][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun12 = "0";
            if (dt.Rows.Count > 12) this._HGun13 = dt.Rows[12][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[12][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun13 = "0";
            if (dt.Rows.Count > 13) this._HGun14 = dt.Rows[13][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[13][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun14 = "0";
            if (dt.Rows.Count > 14) this._HGun15 = dt.Rows[14][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[14][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun15 = "0";
            if (dt.Rows.Count > 15) this._HGun16 = dt.Rows[15][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[15][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun16 = "0";
            if (dt.Rows.Count > 16) this._HGun17 = dt.Rows[16][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[16][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun17 = "0";
            if (dt.Rows.Count > 17) this._HGun18 = dt.Rows[17][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[17][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun18 = "0";
            if (dt.Rows.Count > 18) this._HGun19 = dt.Rows[18][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[18][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun19 = "0";
            if (dt.Rows.Count > 19) this._HGun20 = dt.Rows[19][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[19][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun20 = "0";
            if (dt.Rows.Count > 20) this._HGun21 = dt.Rows[20][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[20][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun21 = "0";
            if (dt.Rows.Count > 21) this._HGun22 = dt.Rows[21][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[21][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun22 = "0";
            if (dt.Rows.Count > 22) this._HGun23 = dt.Rows[22][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[22][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun23 = "0";
            if (dt.Rows.Count > 23) this._HGun24 = dt.Rows[23][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[23][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun24 = "0";
            if (dt.Rows.Count > 24) this._HGun25 = dt.Rows[24][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[24][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun25 = "0";
            if (dt.Rows.Count > 25) this._HGun26 = dt.Rows[25][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[25][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun26 = "0";
            if (dt.Rows.Count > 26) this._HGun27 = dt.Rows[26][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[26][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun27 = "0";
            if (dt.Rows.Count > 27) this._HGun28 = dt.Rows[27][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[27][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun28 = "0";
            if (dt.Rows.Count > 28) this._HGun29 = dt.Rows[28][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[28][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun29 = "0";
            if (dt.Rows.Count > 29) this._HGun30 = dt.Rows[29][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[29][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun30 = "0";
            if (dt.Rows.Count > 30) this._HGun31 = dt.Rows[30][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[30][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun31 = "0";
        }

        // Dispose
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

    public class SatisHedefYilT : IDisposable
    {
        // Alanlar
        public string _Isim;
        public string _HAy1;
        public string _HAy2;
        public string _HAy3;
        public string _HAy4;
        public string _HAy5;
        public string _HAy6;
        public string _HAy7;
        public string _HAy8;
        public string _HAy9;
        public string _HAy10;
        public string _HAy11;
        public string _HAy12;
        public string _NAy1;
        public string _NAy2;
        public string _NAy3;
        public string _NAy4;
        public string _NAy5;
        public string _NAy6;
        public string _NAy7;
        public string _NAy8;
        public string _NAy9;
        public string _NAy10;
        public string _NAy11;
        public string _NAy12;

        // Constracter lar
        public SatisHedefYilT(string Isim, string HAy1, string HAy2, string HAy3, string HAy4, string HAy5, string HAy6, string HAy7, string HAy8,
            string HAy9, string HAy10, string HAy11, string HAy12, string NAy1, string NAy2, string NAy3, string NAy4, string NAy5, string NAy6,
            string NAy7, string NAy8, string NAy9, string NAy10, string NAy11, string NAy12)
        {
            this._Isim = Isim;
            this._NAy1 = NAy1;
            this._NAy2 = NAy2;
            this._NAy3 = NAy3;
            this._NAy4 = NAy4;
            this._NAy5 = NAy5;
            this._NAy6 = NAy6;
            this._NAy7 = NAy7;
            this._NAy8 = NAy8;
            this._NAy9 = NAy9;
            this._NAy10 = NAy10;
            this._NAy11 = NAy11;
            this._NAy12 = NAy12;
            this._HAy1 = HAy1;
            this._HAy2 = HAy2;
            this._HAy3 = HAy3;
            this._HAy4 = HAy4;
            this._HAy5 = HAy5;
            this._HAy6 = HAy6;
            this._HAy7 = HAy7;
            this._HAy8 = HAy8;
            this._HAy9 = HAy9;
            this._HAy10 = HAy10;
            this._HAy11 = HAy11;
            this._HAy12 = HAy12;
        }

        public SatisHedefYilT(string Kategori, int Yil)
        {
            this._Isim = Yil.ToString();
            this._NAy1 = SatisHedef.GetToplamlarTByAy(Kategori, Yil, 1)[2].ToString().Replace(",", ".");
            this._NAy2 = SatisHedef.GetToplamlarTByAy(Kategori, Yil, 2)[2].ToString().Replace(",", ".");
            this._NAy3 = SatisHedef.GetToplamlarTByAy(Kategori, Yil, 3)[2].ToString().Replace(",", ".");
            this._NAy4 = SatisHedef.GetToplamlarTByAy(Kategori, Yil, 4)[2].ToString().Replace(",", ".");
            this._NAy5 = SatisHedef.GetToplamlarTByAy(Kategori, Yil, 5)[2].ToString().Replace(",", ".");
            this._NAy6 = SatisHedef.GetToplamlarTByAy(Kategori, Yil, 6)[2].ToString().Replace(",", ".");
            this._NAy7 = SatisHedef.GetToplamlarTByAy(Kategori, Yil, 7)[2].ToString().Replace(",", ".");
            this._NAy8 = SatisHedef.GetToplamlarTByAy(Kategori, Yil, 8)[2].ToString().Replace(",", ".");
            this._NAy9 = SatisHedef.GetToplamlarTByAy(Kategori, Yil, 9)[2].ToString().Replace(",", ".");
            this._NAy10 = SatisHedef.GetToplamlarTByAy(Kategori, Yil, 10)[2].ToString().Replace(",", ".");
            this._NAy11 = SatisHedef.GetToplamlarTByAy(Kategori, Yil, 11)[2].ToString().Replace(",", ".");
            this._NAy12 = SatisHedef.GetToplamlarTByAy(Kategori, Yil, 12)[2].ToString().Replace(",", ".");
            this._HAy1 = SatisHedef.GetToplamlarTByAy(Kategori, Yil, 1)[0].ToString().Replace(",", ".");
            this._HAy2 = SatisHedef.GetToplamlarTByAy(Kategori, Yil, 2)[0].ToString().Replace(",", ".");
            this._HAy3 = SatisHedef.GetToplamlarTByAy(Kategori, Yil, 3)[0].ToString().Replace(",", ".");
            this._HAy4 = SatisHedef.GetToplamlarTByAy(Kategori, Yil, 4)[0].ToString().Replace(",", ".");
            this._HAy5 = SatisHedef.GetToplamlarTByAy(Kategori, Yil, 5)[0].ToString().Replace(",", ".");
            this._HAy6 = SatisHedef.GetToplamlarTByAy(Kategori, Yil, 6)[0].ToString().Replace(",", ".");
            this._HAy7 = SatisHedef.GetToplamlarTByAy(Kategori, Yil, 7)[0].ToString().Replace(",", ".");
            this._HAy8 = SatisHedef.GetToplamlarTByAy(Kategori, Yil, 8)[0].ToString().Replace(",", ".");
            this._HAy9 = SatisHedef.GetToplamlarTByAy(Kategori, Yil, 9)[0].ToString().Replace(",", ".");
            this._HAy10 = SatisHedef.GetToplamlarTByAy(Kategori, Yil, 10)[0].ToString().Replace(",", ".");
            this._HAy11 = SatisHedef.GetToplamlarTByAy(Kategori, Yil, 11)[0].ToString().Replace(",", ".");
            this._HAy12 = SatisHedef.GetToplamlarTByAy(Kategori, Yil, 12)[0].ToString().Replace(",", ".");
        }

        // Dispose
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

    public class SatisHedefAyT : IDisposable
    {
        // Alanlar
        public string _Isim;
        public string _HGun1;
        public string _HGun2;
        public string _HGun3;
        public string _HGun4;
        public string _HGun5;
        public string _HGun6;
        public string _HGun7;
        public string _HGun8;
        public string _HGun9;
        public string _HGun10;
        public string _HGun11;
        public string _HGun12;
        public string _HGun13;
        public string _HGun14;
        public string _HGun15;
        public string _HGun16;
        public string _HGun17;
        public string _HGun18;
        public string _HGun19;
        public string _HGun20;
        public string _HGun21;
        public string _HGun22;
        public string _HGun23;
        public string _HGun24;
        public string _HGun25;
        public string _HGun26;
        public string _HGun27;
        public string _HGun28;
        public string _HGun29;
        public string _HGun30;
        public string _HGun31;
        public string _NGun1;
        public string _NGun2;
        public string _NGun3;
        public string _NGun4;
        public string _NGun5;
        public string _NGun6;
        public string _NGun7;
        public string _NGun8;
        public string _NGun9;
        public string _NGun10;
        public string _NGun11;
        public string _NGun12;
        public string _NGun13;
        public string _NGun14;
        public string _NGun15;
        public string _NGun16;
        public string _NGun17;
        public string _NGun18;
        public string _NGun19;
        public string _NGun20;
        public string _NGun21;
        public string _NGun22;
        public string _NGun23;
        public string _NGun24;
        public string _NGun25;
        public string _NGun26;
        public string _NGun27;
        public string _NGun28;
        public string _NGun29;
        public string _NGun30;
        public string _NGun31;

        // Constracter lar
        public SatisHedefAyT(string Isim, string HGun1, string HGun2, string HGun3, string HGun4, string HGun5, string HGun6, string HGun7,
            string HGun8, string HGun9, string HGun10, string HGun11, string HGun12, string HGun13, string HGun14, string HGun15, string HGun16,
            string HGun17, string HGun18, string HGun19, string HGun20, string HGun21, string HGun22, string HGun23, string HGun24, string HGun25,
            string HGun26, string HGun27, string HGun28, string HGun29, string HGun30, string HGun31, string NGun1, string NGun2, string NGun3,
            string NGun4, string NGun5, string NGun6, string NGun7, string NGun8, string NGun9, string NGun10, string NGun11, string NGun12,
            string NGun13, string NGun14, string NGun15, string NGun16, string NGun17, string NGun18, string NGun19, string NGun20, string NGun21,
            string NGun22, string NGun23, string NGun24, string NGun25, string NGun26, string NGun27, string NGun28, string NGun29, string NGun30,
            string NGun31)
        {
            this._Isim = Isim;
            this._NGun1 = NGun1;
            this._NGun2 = NGun2;
            this._NGun3 = NGun3;
            this._NGun4 = NGun4;
            this._NGun5 = NGun5;
            this._NGun6 = NGun6;
            this._NGun7 = NGun7;
            this._NGun8 = NGun8;
            this._NGun9 = NGun9;
            this._NGun10 = NGun10;
            this._NGun11 = NGun11;
            this._NGun12 = NGun12;
            this._NGun13 = NGun13;
            this._NGun14 = NGun14;
            this._NGun15 = NGun15;
            this._NGun16 = NGun16;
            this._NGun17 = NGun17;
            this._NGun18 = NGun18;
            this._NGun19 = NGun19;
            this._NGun20 = NGun20;
            this._NGun21 = NGun21;
            this._NGun22 = NGun22;
            this._NGun23 = NGun23;
            this._NGun24 = NGun24;
            this._NGun25 = NGun25;
            this._NGun26 = NGun26;
            this._NGun27 = NGun27;
            this._NGun28 = NGun28;
            this._NGun29 = NGun29;
            this._NGun30 = NGun30;
            this._NGun31 = NGun31;
            this._HGun1 = HGun1;
            this._HGun2 = HGun2;
            this._HGun3 = HGun3;
            this._HGun4 = HGun4;
            this._HGun5 = HGun5;
            this._HGun6 = HGun6;
            this._HGun7 = HGun7;
            this._HGun8 = HGun8;
            this._HGun9 = HGun9;
            this._HGun10 = HGun10;
            this._HGun11 = HGun11;
            this._HGun12 = HGun12;
            this._HGun13 = HGun13;
            this._HGun14 = HGun14;
            this._HGun15 = HGun15;
            this._HGun16 = HGun16;
            this._HGun17 = HGun17;
            this._HGun18 = HGun18;
            this._HGun19 = HGun19;
            this._HGun20 = HGun20;
            this._HGun21 = HGun21;
            this._HGun22 = HGun22;
            this._HGun23 = HGun23;
            this._HGun24 = HGun24;
            this._HGun25 = HGun25;
            this._HGun26 = HGun26;
            this._HGun27 = HGun27;
            this._HGun28 = HGun28;
            this._HGun29 = HGun29;
            this._HGun30 = HGun30;
            this._HGun31 = HGun31;
        }

        public SatisHedefAyT(string Kategori, int Yil, int Ay)
        {
            this._Isim = Yil.ToString() + " / " + Ay.ToString();

            DataTable dt = SatisHedef.GetToplamlarTGunGunByAy(Kategori, Yil, Ay);

            if (dt.Rows.Count > 0) this._NGun1 = dt.Rows[0][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun1 = "0";
            if (dt.Rows.Count > 1) this._NGun2 = dt.Rows[1][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[1][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun2 = "0";
            if (dt.Rows.Count > 2) this._NGun3 = dt.Rows[2][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[2][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun3 = "0";
            if (dt.Rows.Count > 3) this._NGun4 = dt.Rows[3][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[3][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun4 = "0";
            if (dt.Rows.Count > 4) this._NGun5 = dt.Rows[4][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[4][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun5 = "0";
            if (dt.Rows.Count > 5) this._NGun6 = dt.Rows[5][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[5][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun6 = "0";
            if (dt.Rows.Count > 6) this._NGun7 = dt.Rows[6][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[6][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun7 = "0";
            if (dt.Rows.Count > 7) this._NGun8 = dt.Rows[7][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[7][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun8 = "0";
            if (dt.Rows.Count > 8) this._NGun9 = dt.Rows[8][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[8][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun9 = "0";
            if (dt.Rows.Count > 9) this._NGun10 = dt.Rows[9][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[9][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun10 = "0";
            if (dt.Rows.Count > 10) this._NGun11 = dt.Rows[10][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[10][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun11 = "0";
            if (dt.Rows.Count > 11) this._NGun12 = dt.Rows[11][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[11][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun12 = "0";
            if (dt.Rows.Count > 12) this._NGun13 = dt.Rows[12][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[12][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun13 = "0";
            if (dt.Rows.Count > 13) this._NGun14 = dt.Rows[13][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[13][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun14 = "0";
            if (dt.Rows.Count > 14) this._NGun15 = dt.Rows[14][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[14][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun15 = "0";
            if (dt.Rows.Count > 15) this._NGun16 = dt.Rows[15][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[15][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun16 = "0";
            if (dt.Rows.Count > 16) this._NGun17 = dt.Rows[16][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[16][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun17 = "0";
            if (dt.Rows.Count > 17) this._NGun18 = dt.Rows[17][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[17][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun18 = "0";
            if (dt.Rows.Count > 18) this._NGun19 = dt.Rows[18][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[18][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun19 = "0";
            if (dt.Rows.Count > 19) this._NGun20 = dt.Rows[19][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[19][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun20 = "0";
            if (dt.Rows.Count > 20) this._NGun21 = dt.Rows[20][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[20][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun21 = "0";
            if (dt.Rows.Count > 21) this._NGun22 = dt.Rows[21][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[21][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun22 = "0";
            if (dt.Rows.Count > 22) this._NGun23 = dt.Rows[22][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[22][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun23 = "0";
            if (dt.Rows.Count > 23) this._NGun24 = dt.Rows[23][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[23][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun24 = "0";
            if (dt.Rows.Count > 24) this._NGun25 = dt.Rows[24][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[24][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun25 = "0";
            if (dt.Rows.Count > 25) this._NGun26 = dt.Rows[25][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[25][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun26 = "0";
            if (dt.Rows.Count > 26) this._NGun27 = dt.Rows[26][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[26][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun27 = "0";
            if (dt.Rows.Count > 27) this._NGun28 = dt.Rows[27][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[27][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun28 = "0";
            if (dt.Rows.Count > 28) this._NGun29 = dt.Rows[28][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[28][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun29 = "0";
            if (dt.Rows.Count > 29) this._NGun30 = dt.Rows[29][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[29][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun30 = "0";
            if (dt.Rows.Count > 30) this._NGun31 = dt.Rows[30][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[30][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun31 = "0";
            if (dt.Rows.Count > 0) this._HGun1 = dt.Rows[0][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun1 = "0";
            if (dt.Rows.Count > 1) this._HGun2 = dt.Rows[1][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[1][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun2 = "0";
            if (dt.Rows.Count > 2) this._HGun3 = dt.Rows[2][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[2][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun3 = "0";
            if (dt.Rows.Count > 3) this._HGun4 = dt.Rows[3][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[3][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun4 = "0";
            if (dt.Rows.Count > 4) this._HGun5 = dt.Rows[4][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[4][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun5 = "0";
            if (dt.Rows.Count > 5) this._HGun6 = dt.Rows[5][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[5][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun6 = "0";
            if (dt.Rows.Count > 6) this._HGun7 = dt.Rows[6][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[6][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun7 = "0";
            if (dt.Rows.Count > 7) this._HGun8 = dt.Rows[7][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[7][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun8 = "0";
            if (dt.Rows.Count > 8) this._HGun9 = dt.Rows[8][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[8][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun9 = "0";
            if (dt.Rows.Count > 9) this._HGun10 = dt.Rows[9][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[9][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun10 = "0";
            if (dt.Rows.Count > 10) this._HGun11 = dt.Rows[10][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[10][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun11 = "0";
            if (dt.Rows.Count > 11) this._HGun12 = dt.Rows[11][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[11][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun12 = "0";
            if (dt.Rows.Count > 12) this._HGun13 = dt.Rows[12][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[12][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun13 = "0";
            if (dt.Rows.Count > 13) this._HGun14 = dt.Rows[13][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[13][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun14 = "0";
            if (dt.Rows.Count > 14) this._HGun15 = dt.Rows[14][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[14][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun15 = "0";
            if (dt.Rows.Count > 15) this._HGun16 = dt.Rows[15][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[15][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun16 = "0";
            if (dt.Rows.Count > 16) this._HGun17 = dt.Rows[16][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[16][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun17 = "0";
            if (dt.Rows.Count > 17) this._HGun18 = dt.Rows[17][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[17][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun18 = "0";
            if (dt.Rows.Count > 18) this._HGun19 = dt.Rows[18][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[18][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun19 = "0";
            if (dt.Rows.Count > 19) this._HGun20 = dt.Rows[19][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[19][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun20 = "0";
            if (dt.Rows.Count > 20) this._HGun21 = dt.Rows[20][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[20][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun21 = "0";
            if (dt.Rows.Count > 21) this._HGun22 = dt.Rows[21][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[21][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun22 = "0";
            if (dt.Rows.Count > 22) this._HGun23 = dt.Rows[22][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[22][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun23 = "0";
            if (dt.Rows.Count > 23) this._HGun24 = dt.Rows[23][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[23][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun24 = "0";
            if (dt.Rows.Count > 24) this._HGun25 = dt.Rows[24][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[24][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun25 = "0";
            if (dt.Rows.Count > 25) this._HGun26 = dt.Rows[25][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[25][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun26 = "0";
            if (dt.Rows.Count > 26) this._HGun27 = dt.Rows[26][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[26][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun27 = "0";
            if (dt.Rows.Count > 27) this._HGun28 = dt.Rows[27][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[27][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun28 = "0";
            if (dt.Rows.Count > 28) this._HGun29 = dt.Rows[28][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[28][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun29 = "0";
            if (dt.Rows.Count > 29) this._HGun30 = dt.Rows[29][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[29][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun30 = "0";
            if (dt.Rows.Count > 30) this._HGun31 = dt.Rows[30][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[30][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun31 = "0";
        }

        // Dispose
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

    public class SatisHedefYilTs : IDisposable
    {
        // Alanlar
        public string _Isim;
        public string _HAy1;
        public string _HAy2;
        public string _HAy3;
        public string _HAy4;
        public string _HAy5;
        public string _HAy6;
        public string _HAy7;
        public string _HAy8;
        public string _HAy9;
        public string _HAy10;
        public string _HAy11;
        public string _HAy12;
        public string _NAy1;
        public string _NAy2;
        public string _NAy3;
        public string _NAy4;
        public string _NAy5;
        public string _NAy6;
        public string _NAy7;
        public string _NAy8;
        public string _NAy9;
        public string _NAy10;
        public string _NAy11;
        public string _NAy12;

        // Constracter lar
        public SatisHedefYilTs(string Isim, string HAy1, string HAy2, string HAy3, string HAy4, string HAy5, string HAy6, string HAy7, string HAy8,
            string HAy9, string HAy10, string HAy11, string HAy12, string NAy1, string NAy2, string NAy3, string NAy4, string NAy5, string NAy6,
            string NAy7, string NAy8, string NAy9, string NAy10, string NAy11, string NAy12)
        {
            this._Isim = Isim;
            this._NAy1 = NAy1;
            this._NAy2 = NAy2;
            this._NAy3 = NAy3;
            this._NAy4 = NAy4;
            this._NAy5 = NAy5;
            this._NAy6 = NAy6;
            this._NAy7 = NAy7;
            this._NAy8 = NAy8;
            this._NAy9 = NAy9;
            this._NAy10 = NAy10;
            this._NAy11 = NAy11;
            this._NAy12 = NAy12;
            this._HAy1 = HAy1;
            this._HAy2 = HAy2;
            this._HAy3 = HAy3;
            this._HAy4 = HAy4;
            this._HAy5 = HAy5;
            this._HAy6 = HAy6;
            this._HAy7 = HAy7;
            this._HAy8 = HAy8;
            this._HAy9 = HAy9;
            this._HAy10 = HAy10;
            this._HAy11 = HAy11;
            this._HAy12 = HAy12;
        }

        public SatisHedefYilTs(ArrayList SLSREFs, string Kategori, int Yil)
        {
            this._Isim = Yil.ToString();
            this._NAy1 = SatisHedef.GetToplamlarTsByAy(SLSREFs, Kategori, Yil, 1)[2].ToString().Replace(",", ".");
            this._NAy2 = SatisHedef.GetToplamlarTsByAy(SLSREFs, Kategori, Yil, 2)[2].ToString().Replace(",", ".");
            this._NAy3 = SatisHedef.GetToplamlarTsByAy(SLSREFs, Kategori, Yil, 3)[2].ToString().Replace(",", ".");
            this._NAy4 = SatisHedef.GetToplamlarTsByAy(SLSREFs, Kategori, Yil, 4)[2].ToString().Replace(",", ".");
            this._NAy5 = SatisHedef.GetToplamlarTsByAy(SLSREFs, Kategori, Yil, 5)[2].ToString().Replace(",", ".");
            this._NAy6 = SatisHedef.GetToplamlarTsByAy(SLSREFs, Kategori, Yil, 6)[2].ToString().Replace(",", ".");
            this._NAy7 = SatisHedef.GetToplamlarTsByAy(SLSREFs, Kategori, Yil, 7)[2].ToString().Replace(",", ".");
            this._NAy8 = SatisHedef.GetToplamlarTsByAy(SLSREFs, Kategori, Yil, 8)[2].ToString().Replace(",", ".");
            this._NAy9 = SatisHedef.GetToplamlarTsByAy(SLSREFs, Kategori, Yil, 9)[2].ToString().Replace(",", ".");
            this._NAy10 = SatisHedef.GetToplamlarTsByAy(SLSREFs, Kategori, Yil, 10)[2].ToString().Replace(",", ".");
            this._NAy11 = SatisHedef.GetToplamlarTsByAy(SLSREFs, Kategori, Yil, 11)[2].ToString().Replace(",", ".");
            this._NAy12 = SatisHedef.GetToplamlarTsByAy(SLSREFs, Kategori, Yil, 12)[2].ToString().Replace(",", ".");
            this._HAy1 = SatisHedef.GetToplamlarTsByAy(SLSREFs, Kategori, Yil, 1)[0].ToString().Replace(",", ".");
            this._HAy2 = SatisHedef.GetToplamlarTsByAy(SLSREFs, Kategori, Yil, 2)[0].ToString().Replace(",", ".");
            this._HAy3 = SatisHedef.GetToplamlarTsByAy(SLSREFs, Kategori, Yil, 3)[0].ToString().Replace(",", ".");
            this._HAy4 = SatisHedef.GetToplamlarTsByAy(SLSREFs, Kategori, Yil, 4)[0].ToString().Replace(",", ".");
            this._HAy5 = SatisHedef.GetToplamlarTsByAy(SLSREFs, Kategori, Yil, 5)[0].ToString().Replace(",", ".");
            this._HAy6 = SatisHedef.GetToplamlarTsByAy(SLSREFs, Kategori, Yil, 6)[0].ToString().Replace(",", ".");
            this._HAy7 = SatisHedef.GetToplamlarTsByAy(SLSREFs, Kategori, Yil, 7)[0].ToString().Replace(",", ".");
            this._HAy8 = SatisHedef.GetToplamlarTsByAy(SLSREFs, Kategori, Yil, 8)[0].ToString().Replace(",", ".");
            this._HAy9 = SatisHedef.GetToplamlarTsByAy(SLSREFs, Kategori, Yil, 9)[0].ToString().Replace(",", ".");
            this._HAy10 = SatisHedef.GetToplamlarTsByAy(SLSREFs, Kategori, Yil, 10)[0].ToString().Replace(",", ".");
            this._HAy11 = SatisHedef.GetToplamlarTsByAy(SLSREFs, Kategori, Yil, 11)[0].ToString().Replace(",", ".");
            this._HAy12 = SatisHedef.GetToplamlarTsByAy(SLSREFs, Kategori, Yil, 12)[0].ToString().Replace(",", ".");
        }

        // Dispose
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

    public class SatisHedefAyTs : IDisposable
    {
        // Alanlar
        public string _Isim;
        public string _HGun1;
        public string _HGun2;
        public string _HGun3;
        public string _HGun4;
        public string _HGun5;
        public string _HGun6;
        public string _HGun7;
        public string _HGun8;
        public string _HGun9;
        public string _HGun10;
        public string _HGun11;
        public string _HGun12;
        public string _HGun13;
        public string _HGun14;
        public string _HGun15;
        public string _HGun16;
        public string _HGun17;
        public string _HGun18;
        public string _HGun19;
        public string _HGun20;
        public string _HGun21;
        public string _HGun22;
        public string _HGun23;
        public string _HGun24;
        public string _HGun25;
        public string _HGun26;
        public string _HGun27;
        public string _HGun28;
        public string _HGun29;
        public string _HGun30;
        public string _HGun31;
        public string _NGun1;
        public string _NGun2;
        public string _NGun3;
        public string _NGun4;
        public string _NGun5;
        public string _NGun6;
        public string _NGun7;
        public string _NGun8;
        public string _NGun9;
        public string _NGun10;
        public string _NGun11;
        public string _NGun12;
        public string _NGun13;
        public string _NGun14;
        public string _NGun15;
        public string _NGun16;
        public string _NGun17;
        public string _NGun18;
        public string _NGun19;
        public string _NGun20;
        public string _NGun21;
        public string _NGun22;
        public string _NGun23;
        public string _NGun24;
        public string _NGun25;
        public string _NGun26;
        public string _NGun27;
        public string _NGun28;
        public string _NGun29;
        public string _NGun30;
        public string _NGun31;

        // Constracter lar
        public SatisHedefAyTs(string Isim, string HGun1, string HGun2, string HGun3, string HGun4, string HGun5, string HGun6, string HGun7,
            string HGun8, string HGun9, string HGun10, string HGun11, string HGun12, string HGun13, string HGun14, string HGun15, string HGun16,
            string HGun17, string HGun18, string HGun19, string HGun20, string HGun21, string HGun22, string HGun23, string HGun24, string HGun25,
            string HGun26, string HGun27, string HGun28, string HGun29, string HGun30, string HGun31, string NGun1, string NGun2, string NGun3,
            string NGun4, string NGun5, string NGun6, string NGun7, string NGun8, string NGun9, string NGun10, string NGun11, string NGun12,
            string NGun13, string NGun14, string NGun15, string NGun16, string NGun17, string NGun18, string NGun19, string NGun20, string NGun21,
            string NGun22, string NGun23, string NGun24, string NGun25, string NGun26, string NGun27, string NGun28, string NGun29, string NGun30,
            string NGun31)
        {
            this._Isim = Isim;
            this._NGun1 = NGun1;
            this._NGun2 = NGun2;
            this._NGun3 = NGun3;
            this._NGun4 = NGun4;
            this._NGun5 = NGun5;
            this._NGun6 = NGun6;
            this._NGun7 = NGun7;
            this._NGun8 = NGun8;
            this._NGun9 = NGun9;
            this._NGun10 = NGun10;
            this._NGun11 = NGun11;
            this._NGun12 = NGun12;
            this._NGun13 = NGun13;
            this._NGun14 = NGun14;
            this._NGun15 = NGun15;
            this._NGun16 = NGun16;
            this._NGun17 = NGun17;
            this._NGun18 = NGun18;
            this._NGun19 = NGun19;
            this._NGun20 = NGun20;
            this._NGun21 = NGun21;
            this._NGun22 = NGun22;
            this._NGun23 = NGun23;
            this._NGun24 = NGun24;
            this._NGun25 = NGun25;
            this._NGun26 = NGun26;
            this._NGun27 = NGun27;
            this._NGun28 = NGun28;
            this._NGun29 = NGun29;
            this._NGun30 = NGun30;
            this._NGun31 = NGun31;
            this._HGun1 = HGun1;
            this._HGun2 = HGun2;
            this._HGun3 = HGun3;
            this._HGun4 = HGun4;
            this._HGun5 = HGun5;
            this._HGun6 = HGun6;
            this._HGun7 = HGun7;
            this._HGun8 = HGun8;
            this._HGun9 = HGun9;
            this._HGun10 = HGun10;
            this._HGun11 = HGun11;
            this._HGun12 = HGun12;
            this._HGun13 = HGun13;
            this._HGun14 = HGun14;
            this._HGun15 = HGun15;
            this._HGun16 = HGun16;
            this._HGun17 = HGun17;
            this._HGun18 = HGun18;
            this._HGun19 = HGun19;
            this._HGun20 = HGun20;
            this._HGun21 = HGun21;
            this._HGun22 = HGun22;
            this._HGun23 = HGun23;
            this._HGun24 = HGun24;
            this._HGun25 = HGun25;
            this._HGun26 = HGun26;
            this._HGun27 = HGun27;
            this._HGun28 = HGun28;
            this._HGun29 = HGun29;
            this._HGun30 = HGun30;
            this._HGun31 = HGun31;
        }

        public SatisHedefAyTs(ArrayList SLSREFs, string Kategori, int Yil, int Ay)
        {
            this._Isim = Yil.ToString();

            DataTable dt = SatisHedef.GetToplamlarTsGunGunByAy(SLSREFs, Kategori, Yil, Ay);

            if (dt.Rows.Count > 0) this._NGun1 = dt.Rows[0][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun1 = "0";
            if (dt.Rows.Count > 1) this._NGun2 = dt.Rows[1][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[1][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun2 = "0";
            if (dt.Rows.Count > 2) this._NGun3 = dt.Rows[2][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[2][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun3 = "0";
            if (dt.Rows.Count > 3) this._NGun4 = dt.Rows[3][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[3][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun4 = "0";
            if (dt.Rows.Count > 4) this._NGun5 = dt.Rows[4][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[4][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun5 = "0";
            if (dt.Rows.Count > 5) this._NGun6 = dt.Rows[5][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[5][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun6 = "0";
            if (dt.Rows.Count > 6) this._NGun7 = dt.Rows[6][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[6][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun7 = "0";
            if (dt.Rows.Count > 7) this._NGun8 = dt.Rows[7][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[7][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun8 = "0";
            if (dt.Rows.Count > 8) this._NGun9 = dt.Rows[8][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[8][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun9 = "0";
            if (dt.Rows.Count > 9) this._NGun10 = dt.Rows[9][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[9][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun10 = "0";
            if (dt.Rows.Count > 10) this._NGun11 = dt.Rows[10][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[10][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun11 = "0";
            if (dt.Rows.Count > 11) this._NGun12 = dt.Rows[11][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[11][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun12 = "0";
            if (dt.Rows.Count > 12) this._NGun13 = dt.Rows[12][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[12][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun13 = "0";
            if (dt.Rows.Count > 13) this._NGun14 = dt.Rows[13][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[13][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun14 = "0";
            if (dt.Rows.Count > 14) this._NGun15 = dt.Rows[14][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[14][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun15 = "0";
            if (dt.Rows.Count > 15) this._NGun16 = dt.Rows[15][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[15][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun16 = "0";
            if (dt.Rows.Count > 16) this._NGun17 = dt.Rows[16][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[16][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun17 = "0";
            if (dt.Rows.Count > 17) this._NGun18 = dt.Rows[17][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[17][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun18 = "0";
            if (dt.Rows.Count > 18) this._NGun19 = dt.Rows[18][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[18][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun19 = "0";
            if (dt.Rows.Count > 19) this._NGun20 = dt.Rows[19][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[19][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun20 = "0";
            if (dt.Rows.Count > 20) this._NGun21 = dt.Rows[20][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[20][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun21 = "0";
            if (dt.Rows.Count > 21) this._NGun22 = dt.Rows[21][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[21][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun22 = "0";
            if (dt.Rows.Count > 22) this._NGun23 = dt.Rows[22][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[22][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun23 = "0";
            if (dt.Rows.Count > 23) this._NGun24 = dt.Rows[23][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[23][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun24 = "0";
            if (dt.Rows.Count > 24) this._NGun25 = dt.Rows[24][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[24][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun25 = "0";
            if (dt.Rows.Count > 25) this._NGun26 = dt.Rows[25][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[25][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun26 = "0";
            if (dt.Rows.Count > 26) this._NGun27 = dt.Rows[26][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[26][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun27 = "0";
            if (dt.Rows.Count > 27) this._NGun28 = dt.Rows[27][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[27][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun28 = "0";
            if (dt.Rows.Count > 28) this._NGun29 = dt.Rows[28][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[28][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun29 = "0";
            if (dt.Rows.Count > 29) this._NGun30 = dt.Rows[29][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[29][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun30 = "0";
            if (dt.Rows.Count > 30) this._NGun31 = dt.Rows[30][2] != DBNull.Value ? Convert.ToDecimal(dt.Rows[30][2]).ToString("N0").Replace(".", "") : "0"; else this._NGun31 = "0";
            if (dt.Rows.Count > 0) this._HGun1 = dt.Rows[0][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun1 = "0";
            if (dt.Rows.Count > 1) this._HGun2 = dt.Rows[1][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[1][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun2 = "0";
            if (dt.Rows.Count > 2) this._HGun3 = dt.Rows[2][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[2][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun3 = "0";
            if (dt.Rows.Count > 3) this._HGun4 = dt.Rows[3][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[3][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun4 = "0";
            if (dt.Rows.Count > 4) this._HGun5 = dt.Rows[4][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[4][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun5 = "0";
            if (dt.Rows.Count > 5) this._HGun6 = dt.Rows[5][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[5][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun6 = "0";
            if (dt.Rows.Count > 6) this._HGun7 = dt.Rows[6][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[6][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun7 = "0";
            if (dt.Rows.Count > 7) this._HGun8 = dt.Rows[7][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[7][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun8 = "0";
            if (dt.Rows.Count > 8) this._HGun9 = dt.Rows[8][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[8][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun9 = "0";
            if (dt.Rows.Count > 9) this._HGun10 = dt.Rows[9][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[9][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun10 = "0";
            if (dt.Rows.Count > 10) this._HGun11 = dt.Rows[10][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[10][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun11 = "0";
            if (dt.Rows.Count > 11) this._HGun12 = dt.Rows[11][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[11][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun12 = "0";
            if (dt.Rows.Count > 12) this._HGun13 = dt.Rows[12][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[12][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun13 = "0";
            if (dt.Rows.Count > 13) this._HGun14 = dt.Rows[13][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[13][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun14 = "0";
            if (dt.Rows.Count > 14) this._HGun15 = dt.Rows[14][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[14][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun15 = "0";
            if (dt.Rows.Count > 15) this._HGun16 = dt.Rows[15][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[15][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun16 = "0";
            if (dt.Rows.Count > 16) this._HGun17 = dt.Rows[16][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[16][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun17 = "0";
            if (dt.Rows.Count > 17) this._HGun18 = dt.Rows[17][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[17][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun18 = "0";
            if (dt.Rows.Count > 18) this._HGun19 = dt.Rows[18][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[18][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun19 = "0";
            if (dt.Rows.Count > 19) this._HGun20 = dt.Rows[19][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[19][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun20 = "0";
            if (dt.Rows.Count > 20) this._HGun21 = dt.Rows[20][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[20][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun21 = "0";
            if (dt.Rows.Count > 21) this._HGun22 = dt.Rows[21][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[21][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun22 = "0";
            if (dt.Rows.Count > 22) this._HGun23 = dt.Rows[22][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[22][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun23 = "0";
            if (dt.Rows.Count > 23) this._HGun24 = dt.Rows[23][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[23][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun24 = "0";
            if (dt.Rows.Count > 24) this._HGun25 = dt.Rows[24][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[24][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun25 = "0";
            if (dt.Rows.Count > 25) this._HGun26 = dt.Rows[25][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[25][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun26 = "0";
            if (dt.Rows.Count > 26) this._HGun27 = dt.Rows[26][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[26][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun27 = "0";
            if (dt.Rows.Count > 27) this._HGun28 = dt.Rows[27][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[27][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun28 = "0";
            if (dt.Rows.Count > 28) this._HGun29 = dt.Rows[28][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[28][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun29 = "0";
            if (dt.Rows.Count > 29) this._HGun30 = dt.Rows[29][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[29][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun30 = "0";
            if (dt.Rows.Count > 30) this._HGun31 = dt.Rows[30][0] != DBNull.Value ? Convert.ToDecimal(dt.Rows[30][0]).ToString("N0").Replace(".", "") : "0"; else this._HGun31 = "0";
        }

        // Dispose
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}