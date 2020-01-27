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

        public satisTemsilcileri() { }
        public satisTemsilcileri(int SLSMANREF) { this.SLSMANREF = SLSMANREF; }
        public satisTemsilcileri(int ACTIVE, int SLSMANREF, string SATKOD1, string SATTEM)
        {
            this.ACTIVE = ACTIVE;
            this.SLSMANREF = SLSMANREF;
            this.SATKOD1 = SATKOD1;
            this.SATTEM = SATTEM;
        }
        
        public override string ToString() { return SATTEM; }
        #region kullanımdışı
        /// <summary>
        /// Kullanılmayacak
        /// </summary>
        public override void DoInsert()
        {
            /*using (conn)
            {
                string[] param = new string[] { "ACTIVE", "SLSMANREF", "SATKOD1", "SATTEM" };
                object[] values = new object[] { ACTIVE, SLSMANREF, SATKOD1, SATTEM };
                CmdInit("INSERT INTO [Web-SatisTemsilcileri] (ACTIVE, SLSMANREF, [SAT KOD1], [SAT TEM]) VALUES (@ACTIVE, @SLSMANREF, @SATKOD1, @SATTEM)", CommandType.Text, 200, param, values);
                conn.Open();
                cmd.ExecuteNonQuery();
            }*/
        }
        /// <summary>
        /// Kullanılmayacak
        /// </summary>
        public override void DoUpdate()
        {
            /*using (conn)
            {
                string[] param = new string[] { "ACTIVE", "SLSMANREF", "SATKOD1", "SATTEM" };
                object[] values = new object[] { ACTIVE, SLSMANREF, SATKOD1, SATTEM };
                CmdInit("UPDATE [Web-SatisTemsilcileri] SET ACTIVE = @ACTIVE, [SAT KOD1] = @SATKOD1, [SAT TEM] = @SATTEM) WHERE SLSMANREF = @SLSMANREF", CommandType.Text, 200, param, values);
                conn.Open();
                cmd.ExecuteNonQuery();
            }*/
        }
        /// <summary>
        /// Kullanılmayacak
        /// </summary>
        public override void DoDelete()
        {
            /*using (conn)
            {
                string[] param = new string[] { "ACTIVE", "SLSMANREF", "SATKOD1", "SATTEM" };
                object[] values = new object[] { ACTIVE, SLSMANREF, SATKOD1, SATTEM };
                CmdInit("DELETE [Web-SatisTemsilcileri] WHERE SLSMANREF = @SLSMANREF", CommandType.Text, 200, param, values);
                conn.Open();
                cmd.ExecuteNonQuery();
            }*/
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public satisTemsilcileri GetObject()
        {
            satisTemsilcileri donendeger = new satisTemsilcileri();

            Dictionary<int, object> dic = GetObject("db_sp_satisTemsilcisiGetir", new Dictionary<string, object>() { { "SLSMANREF", SLSMANREF } }, timeout);
            if (dic != null)
                donendeger = new satisTemsilcileri(ConvertToInt32(dic[0]), ConvertToInt32(dic[1]), dic[2].ToString(), dic[3].ToString());

            /*using (conn)
            {
                string[] param = new string[] { "SLSMANREF" };
                object[] values = new object[] { SLSMANREF };
                CmdInit("db_sp_satisTemsilcisiGetir", 200, param, values);
                conn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                    donendeger = new satisTemsilcileri(ConvertToInt32(dr[0]), ConvertToInt32(dr[1]), dr[2].ToString(), dr[3].ToString());
            }*/

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
                    donendeger.Add(new satisTemsilcileri(ConvertToInt32(dic[i][0]), ConvertToInt32(dic[i][1]), dic[i][2].ToString(), dic[i][3].ToString()));

            /*using (conn)
            {
                string[] param = new string[] { };
                object[] values = new object[] { };
                CmdInit("db_sp_satisTemsilcileriGetir", 200, param, values);
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                    donendeger.Add(new satisTemsilcileri(ConvertToInt32(dr[0]), ConvertToInt32(dr[1]), dr[2].ToString(), dr[3].ToString()));
            }*/

            return donendeger;
        }
    }
}
