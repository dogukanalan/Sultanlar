using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj
{
    public class StandartClass : DbObj
    {
        protected string keyFieldName;
        protected string valueFieldName;
        protected string insertSp;
        protected string updateSp;
        protected string deleteSp;
        protected string getSp;
        protected string getsSp;

        public int key { get; set; }
        public string value { get; set; }

        protected StandartClass() { }
        protected StandartClass(int key) { this.key = key; }
        protected StandartClass(int key, string value) { this.key = key; this.value = value; }
        
        public override string ToString() { return value; }
        //public virtual void Generate() { }
        /// <summary>
        /// 
        /// </summary>
        public override void DoInsert()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { keyFieldName, key }, { valueFieldName, value } };
            key = ConvertToInt32(Do(QueryType.Insert, insertSp, param, timeout));
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoUpdate()
        {
            Dictionary<string, object> param = new Dictionary<string, object>() { { keyFieldName, key }, { valueFieldName, value } };
            Do(QueryType.Update, updateSp, param, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void DoDelete()
        {
            Do(QueryType.Delete, deleteSp, new Dictionary<string, object>() { { keyFieldName, key } }, timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected void GetObj()
        {
            Dictionary<int, object> dic = GetObject(getSp, new Dictionary<string, object>() { { keyFieldName, key } }, timeout);
            if (dic != null)
            {
                key = ConvertToInt32(dic[0]);
                value = dic[1].ToString();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /*public virtual object GetObject()
        {
            //StandartClass donendeger = new StandartClass();

            //Dictionary<int, object> dic = GetObject(getSp, new Dictionary<string, object>() { { keyFieldName, key } }, timeout);
            //donendeger = new StandartClass(ConvertToInt32(dic[0]), dic[1].ToString());

            //return donendeger;
            return null;
        }*/
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected List<StandartClass> GetObjs()
        {
            List<StandartClass> donendeger = new List<StandartClass>();

            Dictionary<int, Dictionary<int, object>> dic = GetObjects(getsSp, timeout);
            if (dic != null)
                for (int i = 0; i < dic.Count; i++)
                donendeger.Add(new StandartClass(ConvertToInt32(dic[i][0]), dic[i][1].ToString()));

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /*public virtual object GetObjects()
        {
            //List<StandartClass> donendeger = new List<StandartClass>();

            //Dictionary<int, Dictionary<int, object>> dic = GetObjects(getsSp, timeout);
            //for (int i = 0; i < dic.Count; i++)
            //    donendeger.Add(new StandartClass(ConvertToInt32(dic[i][0]), dic[i][1].ToString()));

            //return donendeger;
            return null;
        }*/
    }

    public interface IStandartClass
    {
        void Generate();
    }
}
