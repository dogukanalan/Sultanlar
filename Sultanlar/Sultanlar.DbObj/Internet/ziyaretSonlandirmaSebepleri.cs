using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class ziyaretSonlandirmaSebepleri : StandartClass, IStandartClass
    {
        public ziyaretSonlandirmaSebepleri()
        {
            Generate();
        }

        public ziyaretSonlandirmaSebepleri(int ID)
        {
            key = ID;
            Generate();
        }

        private ziyaretSonlandirmaSebepleri(int ID, string ACIKLAMA)
        {
            key = ID;
            value = ACIKLAMA;
        }

        public void Generate()
        {
            keyFieldName = "ID";
            valueFieldName = "ACIKLAMA";
            insertSp = "db_sp_ziyaretSonlandirmaSebepEkle";
            updateSp = "db_sp_ziyaretSonlandirmaSebepGuncelle";
            deleteSp = "db_sp_ziyaretSonlandirmaSebepSil";
            getSp = "db_sp_ziyaretSonlandirmaSebepGetir";
            getsSp = "db_sp_ziyaretSonlandirmaSebepleriGetir";
        }

        public ziyaretSonlandirmaSebepleri GetObject()
        {
            GetObj();
            return new ziyaretSonlandirmaSebepleri(key, value);
        }

        public List<ziyaretSonlandirmaSebepleri> GetObjects()
        {
            List<ziyaretSonlandirmaSebepleri> donendeger = new List<ziyaretSonlandirmaSebepleri>();
            List<StandartClass> scl = GetObjs();
            for (int i = 0; i < scl.Count; i++)
                donendeger.Add(new ziyaretSonlandirmaSebepleri(scl[i].key, scl[i].value));
            return donendeger;
        }
    }
}
