using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    /// <summary>
    /// Insert, update, delete yok
    /// </summary>
    public class primGruplari : StandartClass, IStandartClass
    {
        public primGruplari()
        {
            Generate();
        }

        public primGruplari(int PG_B_Z)
        {
            key = PG_B_Z;
            Generate();
        }

        private primGruplari(int PG_B_Z, string PG_B_Z_ACIKLAMA)
        {
            key = PG_B_Z;
            value = PG_B_Z_ACIKLAMA;
        }

        public void Generate()
        {
            keyFieldName = "PG_B_Z";
            valueFieldName = "PG_B_Z_ACIKLAMA";
            insertSp = "";
            updateSp = "";
            deleteSp = "";
            getSp = "db_sp_primGrubuGetir";
            getsSp = "db_sp_primGruplariGetir";
        }

        public primGruplari GetObject()
        {
            GetObj();
            return new primGruplari(key, value);
        }

        public List<primGruplari> GetObjects()
        {
            List<primGruplari> donendeger = new List<primGruplari>();
            List<StandartClass> scl = GetObjs();
            for (int i = 0; i < scl.Count; i++)
                donendeger.Add(new primGruplari(scl[i].key, scl[i].value));
            return donendeger;
        }
    }
}
