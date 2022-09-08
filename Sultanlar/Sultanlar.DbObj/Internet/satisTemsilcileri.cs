using System;
using System.Collections.Generic;
using System.Data;

namespace Sultanlar.DbObj.Internet
{
    public class satisTemsilcileri : DbObj
    {
        public int ACTIVE { get; set; }
        public int SLSMANREF { get; set; }
        public string SATKOD1 { get; set; }
        public string SATTEM { get; set; }
        public string SATKOD { get; set; }
        public string TELEFON { get; set; }
        public string POSITION_ { get; set; }

        public satisTemsilcileri() { }
        public satisTemsilcileri(int SLSMANREF) { this.SLSMANREF = SLSMANREF; }
        public satisTemsilcileri(int ACTIVE, int SLSMANREF, string SATKOD1, string SATTEM, string SATKOD, string TELEFON, string POSITION_)
        {
            this.ACTIVE = ACTIVE;
            this.SLSMANREF = SLSMANREF;
            this.SATKOD1 = SATKOD1;
            this.SATTEM = SATTEM;
            this.SATKOD = SATKOD;
            this.TELEFON = TELEFON;
            this.POSITION_ = POSITION_;
        }
        public override string ToString() { return SATTEM; }
        /// <summary>
        /// 2
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "ACTIVE", ACTIVE }, { "SLSMANREF", SLSMANREF }, { "SATKOD", SATKOD }, { "SATKOD1", SATKOD1 }, { "SATTEM", SATTEM }, { "TELEFON", TELEFON }, { "POSITION_", POSITION_ } };
            SLSMANREF = ConvertToInt32(Do(QueryType.Insert, "INSERT INTO [Web-SatisTemsilcileri-2] (ACTIVE, [SAT KOD], [SAT KOD1], [SAT TEM], TELEFON, POSITION_) VALUES (@ACTIVE, @SATKOD1, @SATTEM, @TELEFON, @POSITION_) SELECT @SLSMANREF = SCOPE_IDENTITY()", param, timeout));
        }
        /// <summary>
        /// 2
        /// </summary>
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { "ACTIVE", ACTIVE }, { "SLSMANREF", SLSMANREF }, { "SATKOD", SATKOD }, { "SATKOD1", SATKOD1 }, { "SATTEM", SATTEM }, { "TELEFON", TELEFON }, { "POSITION_", POSITION_ } };
            Do(QueryType.Update, "UPDATE [Web-SatisTemsilcileri-2] SET ACTIVE = @ACTIVE, [SAT KOD] = @SATKOD, [SAT KOD1] = @SATKOD1, [SAT TEM] = @SATTEM, [TELEFON] = @TELEFON, [POSITION_] = @POSITION_ WHERE SLSMANREF = @SLSMANREF", param, timeout);
        }
        /// <summary>
        /// 2
        /// </summary>
        public override void DoDelete()
        {
            Do(QueryType.Delete, "DELETE [Web-SatisTemsilcileri-2] WHERE SLSMANREF = @SLSMANREF", new Dictionary<string, object>() { { "SLSMANREF", SLSMANREF } }, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public satisTemsilcileri GetObject()
        {
            satisTemsilcileri donendeger = new satisTemsilcileri();

            Dictionary<int, object> dic = GetObject("db_sp_satisTemsilcisiGetir", new Dictionary<string, object>() { { "SLSMANREF", SLSMANREF } }, timeout);
            if (dic != null)
                donendeger = new satisTemsilcileri(ConvertToInt32(dic[0]), ConvertToInt32(dic[1]), dic[2].ToString(), dic[3].ToString(), dic[4].ToString(), dic[5].ToString(), dic[6].ToString());

            return donendeger;
        }
        /// <summary>
        /// 2
        /// </summary>
        /// <returns></returns>
        public satisTemsilcileri GetObject2()
        {
            satisTemsilcileri donendeger = new satisTemsilcileri();

            Dictionary<int, object> dic = GetObject("SELECT ACTIVE, SLSMANREF, [SAT KOD1], [SAT TEM], [SAT KOD], TELEFON, POSITION_ FROM [Web-SatisTemsilcileri-2] WHERE SLSMANREF = @SLSMANREF", new Dictionary<string, object>() { { "SLSMANREF", SLSMANREF } }, timeout);
            if (dic != null)
                donendeger = new satisTemsilcileri(ConvertToInt32(dic[0]), ConvertToInt32(dic[1]), dic[2].ToString(), dic[3].ToString(), dic[4].ToString(), dic[5].ToString(), dic[6].ToString());

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<satisTemsilcileri> GetObjects()
        {
            List<satisTemsilcileri> donendeger = new List<satisTemsilcileri>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("db_sp_satisTemsilcileriGetir", timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new satisTemsilcileri(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString()));

            return donendeger;
        }
        /// <summary>
        /// 2
        /// </summary>
        /// <returns></returns>
        public List<satisTemsilcileri> GetObjects2()
        {
            List<satisTemsilcileri> donendeger = new List<satisTemsilcileri>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects("SELECT ACTIVE, SLSMANREF, [SAT KOD1], [SAT TEM], [SAT KOD], TELEFON, POSITION_ FROM [Web-SatisTemsilcileri-2] ORDER BY [SAT TEM]", timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                    donendeger.Add(new satisTemsilcileri(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), dic[i][2].ToString(), dic[i][3].ToString(), dic[i][4].ToString(), dic[i][5].ToString(), dic[i][6].ToString()));

            return donendeger;
        }
    }
}
