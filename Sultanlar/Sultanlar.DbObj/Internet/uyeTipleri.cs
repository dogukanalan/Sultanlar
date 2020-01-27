using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class uyeTipleri : StandartClass, IStandartClass
    {
        public uyeTipleri()
        {
            Generate();
        }

        public uyeTipleri(int pkUyeTipiID)
        {
            key = pkUyeTipiID;
            Generate();
        }

        private uyeTipleri(int pkUyeTipiID, string strUyeTipi)
        {
            key = pkUyeTipiID;
            value = strUyeTipi;
        }

        public void Generate()
        {
            keyFieldName = "pkUyeTipiID";
            valueFieldName = "strUyeTipi";
            insertSp = "db_sp_uyeTipiEkle";
            updateSp = "db_sp_uyeTipiGuncelle";
            deleteSp = "db_sp_uyeTipiSil";
            getSp = "db_sp_uyeTipiGetir";
            getsSp = "db_sp_uyeTipleriGetir";
        }

        public uyeTipleri GetObject()
        {
            GetObj();
            return new uyeTipleri(key, value);
        }

        public List<uyeTipleri> GetObjects()
        {
            List<uyeTipleri> donendeger = new List<uyeTipleri>();
            List<StandartClass> scl = GetObjs();
            for (int i = 0; i < scl.Count; i++)
                donendeger.Add(new uyeTipleri(scl[i].key, scl[i].value));
            return donendeger;
        }
    }
}
