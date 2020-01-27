using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class iadeHareketTurleri : StandartClass, IStandartClass
    {
        public iadeHareketTurleri()
        {
            Generate();
        }

        public iadeHareketTurleri(int pkIadeHareketTurID)
        {
            key = pkIadeHareketTurID;
            Generate();
        }

        private iadeHareketTurleri(int pkIadeHareketTurID, string strIadeHareketTur)
        {
            key = pkIadeHareketTurID;
            value = strIadeHareketTur;
        }

        public void Generate()
        {
            keyFieldName = "pkIadeHareketTurID";
            valueFieldName = "strIadeHareketTur";
            insertSp = "db_sp_iadeHareketTurEkle";
            updateSp = "db_sp_iadeHareketTurGuncelle";
            deleteSp = "db_sp_iadeHareketTurSil";
            getSp = "db_sp_iadeHareketTurGetir";
            getsSp = "db_sp_iadeHareketTurleriGetir";
        }

        public iadeHareketTurleri GetObject()
        {
            GetObj();
            return new iadeHareketTurleri(key, value);
        }

        public List<iadeHareketTurleri> GetObjects()
        {
            List<iadeHareketTurleri> donendeger = new List<iadeHareketTurleri>();
            List<StandartClass> scl = GetObjs();
            for (int i = 0; i < scl.Count; i++)
                donendeger.Add(new iadeHareketTurleri(scl[i].key, scl[i].value));
            return donendeger;
        }
    }
}
