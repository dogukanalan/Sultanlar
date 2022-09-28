using Sultanlar.Class;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace Sultanlar.DbObj
{
    public class General
    {
        public static string ConnectionString
        {
            get
            {
                //string IP = Ag.DbIP == string.Empty ? "10.1.1.14" : Ag.DbIP;
                return "Server=10.10.41.2; Database=KurumsalWebSAP; User Id=sa; Password=sdl580g5p9+-;";
                // dis ip: 95.0.47.133 - SERVERDB01 - 10.1.1.14 --- Trusted_Connection=True; --- User Id=sa; Password=sdl580g5p9;
            }
        }
    }

    public class DbObj : IDbObj
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private SqlDataReader dr;
        protected int timeout;

        public DbObj()
        {
            conn = new SqlConnection(General.ConnectionString);
            cmd = new SqlCommand("", conn);
            da = new SqlDataAdapter("", conn);
            timeout = 200;
        }

        protected void Dispose() { GC.SuppressFinalize(this); }

        public virtual void DoInsert() { }

        public virtual void DoUpdate() { }

        public virtual void DoDelete() { }

        private void CmdInit(QueryType type, string text, int timeout, Dictionary<string, object> param)
        {
            cmd.CommandText = text;
            cmd.CommandType = text.StartsWith("db_sp_") || text.StartsWith("sp_") || text.StartsWith("_") ? CommandType.StoredProcedure : CommandType.Text;
            cmd.CommandTimeout = timeout;
            cmd.Parameters.Clear();

            int i = 0;
            if (type == QueryType.Insert)
            {
                cmd.Parameters.Add(param.Keys.ToArray()[0], SqlDbType.Int).Direction = ParameterDirection.Output;
                i = 1;
            }

            for (; i < param.Count; i++)
                cmd.Parameters.AddWithValue(param.Keys.ToArray()[i], param.Values.ToArray()[i]);
        }

        protected object Do(QueryType type, string storedproducer, Dictionary<string, object> param, int timeout)
        {
            object donendeger = null;
            CmdInit(type, storedproducer, timeout, param);
            conn.Open();
            cmd.ExecuteNonQuery();
            if (type == QueryType.Insert)
                donendeger = cmd.Parameters[0].Value;
            conn.Close();
            return donendeger;
        }

        protected object GetObjectSc(string storedproducer, Dictionary<string, object> param, int timeout)
        {
            CmdInit(QueryType.Select, storedproducer, timeout, param);
            conn.Open();
            object donendeger = cmd.ExecuteScalar();
            conn.Close();
            return donendeger;
        }

        protected Dictionary<int, object> GetObject(string storedproducer, Dictionary<string, object> param, int timeout)
        {
            Dictionary<int, object> donendeger = new Dictionary<int, object>();
            CmdInit(QueryType.Select, storedproducer, timeout, param);
            conn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
                for (int i = 0; i < dr.FieldCount; i++)
                    donendeger.Add(i, dr[i]);
            else
                donendeger = null;
            conn.Close();
            return donendeger;
        }

        protected Dictionary<int, Dictionary<int, object>> GetObjects(string storedproducer, Dictionary<string, object> param, int timeout)
        {
            Dictionary<int, Dictionary<int, object>> donendeger = new Dictionary<int, Dictionary<int, object>>();
            CmdInit(QueryType.Select, storedproducer, timeout, param);
            conn.Open();
            dr = cmd.ExecuteReader();
            int j = 0;
            while (dr.Read())
            {
                Dictionary<int, object> ic = new Dictionary<int, object>();
                for (int i = 0; i < dr.FieldCount; i++)
                    ic.Add(i, dr[i]);
                donendeger.Add(j, ic);
                j++;
            }
            conn.Close();
            if (j == 0)
                return null;
            return donendeger;
        }

        protected Dictionary<int, Dictionary<int, object>> GetObjects(string storedproducer, int timeout)
        {
            Dictionary<int, Dictionary<int, object>> donendeger = new Dictionary<int, Dictionary<int, object>>();
            CmdInit(QueryType.Select, storedproducer, timeout, new Dictionary<string, object>() { });
            conn.Open();
            dr = cmd.ExecuteReader();
            int j = 0;
            while (dr.Read())
            {
                Dictionary<int, object> ic = new Dictionary<int, object>();
                for (int i = 0; i < dr.FieldCount; i++)
                    ic.Add(i, dr[i]);
                donendeger.Add(j, ic);
                j++;
            }
            conn.Close();
            if (j == 0)
                return null;
            return donendeger;
        }

        protected byte ConvertToByte(object obj)
        {
            byte donendeger = 0;
            byte.TryParse(obj.ToString(), out donendeger);
            return donendeger;
        }

        protected byte[] ConvertToByteArray(object obj)
        {
            byte[] donendeger = obj == DBNull.Value ? null : (byte[])obj;
            return donendeger;
        }

        protected short ConvertToInt16(object obj)
        {
            short donendeger = 0;
            short.TryParse(obj.ToString(), out donendeger);
            return donendeger;
        }

        protected int ConvertToInt32(object obj)
        {
            int donendeger = 0;
            int.TryParse(obj.ToString(), out donendeger);
            return donendeger;
        }

        protected long ConvertToInt64(object obj)
        {
            long donendeger = 0;
            long.TryParse(obj.ToString(), out donendeger);
            return donendeger;
        }

        protected double ConvertToDouble(object obj)
        {
            double donendeger = 0;
            double.TryParse(obj.ToString(), out donendeger);
            return donendeger;
        }

        protected DateTime ConvertToDateTime(object obj)
        {
            DateTime donendeger = DateTime.Parse("01.01.1900");
            DateTime.TryParse(obj.ToString(), out donendeger);
            return donendeger;
        }

        protected Guid ConvertToGuid(string str)
        {
            Guid donendeger = Guid.Empty;
            Guid.TryParse(str, out donendeger);
            return donendeger;
        }

        protected object ConvertToBoolean(object obj)
        {
            return obj == DBNull.Value ? null : (object)Convert.ToBoolean(obj);
        }

        protected bool ConvertToBool(object obj)
        {
            return obj == DBNull.Value ? false : Convert.ToBoolean(obj);
        }

        protected string ConvertToString(object obj)
        {
            return obj.ToString();
        }
    }

    public enum QueryType
    {
        Insert, Update, Delete, Select
    }

    public interface IDbObj
    {
        void DoInsert();
        void DoUpdate();
        void DoDelete();
    }
}
