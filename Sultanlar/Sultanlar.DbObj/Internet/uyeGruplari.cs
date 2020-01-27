using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class uyeGruplari : StandartClass, IStandartClass
    {
        public uyeGruplari()
        {
            Generate();
        }

        public uyeGruplari(int pkUyeGrupID)
        {
            key = pkUyeGrupID;
            Generate();
        }

        private uyeGruplari(int pkUyeGrupID, string strUyeGrup)
        {
            key = pkUyeGrupID;
            value = strUyeGrup;
        }

        public void Generate()
        {
            keyFieldName = "pkUyeGrupID";
            valueFieldName = "strUyeGrup";
            insertSp = "db_sp_uyeGrupEkle";
            updateSp = "db_sp_uyeGrupGuncelle";
            deleteSp = "db_sp_uyeGrupSil";
            getSp = "db_sp_uyeGrupGetir";
            getsSp = "db_sp_uyeGruplariGetir";
        }

        public uyeGruplari GetObject()
        {
            GetObj();
            return new uyeGruplari(key, value);
        }

        public List<uyeGruplari> GetObjects()
        {
            List<uyeGruplari> donendeger = new List<uyeGruplari>();
            List<StandartClass> scl = GetObjs();
            for (int i = 0; i < scl.Count; i++)
                donendeger.Add(new uyeGruplari(scl[i].key, scl[i].value));
            return donendeger;
        }
    }
}
