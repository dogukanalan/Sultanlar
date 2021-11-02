using System;
using System.Collections;
using Sultanlar.Class;

namespace Sultanlar.DatabaseObject
{
    public static class General
    {
        public static string ConnectionString
        {
            get
            {
                string IP = Ag.DbIP == string.Empty ? "10.1.1.14" : Ag.DbIP;
                return "Server=" + IP + "; Database=KurumsalWebSAP; User Id=sa; Password=sdl580g5p9; Trusted_Connection=False;";
                // dis ip: 95.0.47.133 - SERVERDB01 - 10.1.1.14
            }
        }
        public static string ConnectionStringGOKW3
        {
            get
            {
                string IP = Ag.DbIP == string.Empty ? "10.1.1.14" : Ag.DbIP;
                return "Server=" + IP + "; Database=KurumsalWebSAP; User Id=sa; Password=sdl580g5p9; Trusted_Connection=False;";
            }
        }
        public static string ConnectionStringGOKW3sa
        {
            get
            {
                string IP = Ag.DbIP == string.Empty ? "10.1.1.14" : Ag.DbIP;
                return "Server=" + IP + "; Database=KurumsalWebSAP; User Id=sa; Password=sdl580g5p9; Trusted_Connection=False;";
            }
        }
        public static string ConnectionStringDisVeri
        {
            get
            {
                string IP = Ag.DbIP == string.Empty ? "10.1.1.14" : Ag.DbIP;
                return "Server=" + IP + "; Database=DisVeri; User Id=sa; Password=sdl580g5p9; Trusted_Connection=False;";
            }
        }
    }
    //
    //
    //
    //
    //
    public interface ISultanlar
    {
        void DoInsert();
        void DoUpdate();
        void DoDelete();
        //void GetObjects(IList List);
    }
}
