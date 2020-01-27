using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class anlasmaBedelAdlari : StandartClass, IStandartClass
    {
        public anlasmaBedelAdlari()
        {
            Generate();
        }

        public anlasmaBedelAdlari(int pkID)
        {
            key = pkID;
            Generate();
        }

        private anlasmaBedelAdlari(int pkID, string strBedel)
        {
            key = pkID;
            value = strBedel;
        }

        public void Generate()
        {
            keyFieldName = "pkID";
            valueFieldName = "strBedel";
            insertSp = "db_sp_anlasmaBedelAdEkle";
            updateSp = "db_sp_anlasmaBedelAdGuncelle";
            deleteSp = "db_sp_anlasmaBedelAdSil";
            getSp = "db_sp_anlasmaBedelAdGetir";
            getsSp = "db_sp_anlasmaBedelAdlariGetir";
        }

        public anlasmaBedelAdlari GetObject()
        {
            GetObj();
            return new anlasmaBedelAdlari(key, value);
        }

        public List<anlasmaBedelAdlari> GetObjects()
        {
            List<anlasmaBedelAdlari> donendeger = new List<anlasmaBedelAdlari>();
            List<StandartClass> scl = GetObjs();
            for (int i = 0; i < scl.Count; i++)
                donendeger.Add(new anlasmaBedelAdlari(scl[i].key, scl[i].value));
            return donendeger;
        }
    }
}
