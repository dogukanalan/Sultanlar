using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Sultanlar.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Komsu2" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Komsu2.svc or Komsu2.svc.cs at the Solution Explorer and start debugging.
    public class Komsu2 : IKomsu2
    {
        NetworkCredential nc3 = new NetworkCredential("MISTIF", "Ankara1923*+B"); //mbozdag Alfa123**

        public void DoWork()
        {
        }

        public string Test()
        {
            return "Çalışıyor";
        }

        public komsuC0011.ZwebKomsuS_001[] komsu001(string Matnr)
        {
            if (Matnr == "0")
                Matnr = "";
            else if (Matnr.Length == 7)
            {
                Matnr = "00000000000" + Matnr;
            }
            komsuC0011.ZwebKomsuF001Service srv = new komsuC0011.ZwebKomsuF001Service();
            srv.Credentials = nc3;
            return srv.ZwebKomsuF001(Matnr);
        }

        public komsuC0021.ZwebKomsuS_002[] komsu002(string Matnr)
        {
            if (Matnr == "0")
                Matnr = "";
            else if (Matnr.Length == 7)
            {
                Matnr = "00000000000" + Matnr;
            }
            komsuC0021.ZwebKomsuF002Service srv = new komsuC0021.ZwebKomsuF002Service();
            srv.Credentials = nc3;
            return srv.ZwebKomsuF002(Matnr);
        }

        public komsuC0031.ZwebKomsuS_003[] komsu003(string Matnr)
        {
            if (Matnr == "0")
                Matnr = "";
            else if (Matnr.Length == 7)
            {
                Matnr = "00000000000" + Matnr;
            }
            komsuC0031.ZwebKomsuF003Service srv = new komsuC0031.ZwebKomsuF003Service();
            srv.Credentials = nc3;
            return srv.ZwebKomsuF003(Matnr);
        }

        public komsuC0041.ZwebKomsuS_004[] komsu004(komsuC0041.Werks werks, string Matnr)
        {
            if (Matnr == "0")
                Matnr = "";
            else if (Matnr.Length == 7)
            {
                Matnr = "00000000000" + Matnr;
            }
            komsuC0041.ZwebKomsuF004Service srv = new komsuC0041.ZwebKomsuF004Service();
            srv.Credentials = nc3;
            komsuC0041.ZwebKomsuS_004[] dortler = srv.ZwebKomsuF004(Matnr, werks);
            return dortler;
        }

        public komsuC0041.ZwebKomsuS_004[] komsu004get(string Werks, string Matnr)
        {
            if (Matnr == "0")
                Matnr = "";
            else if (Matnr.Length == 7)
            {
                Matnr = "00000000000" + Matnr;
            }
            if (Werks == "0")
                Werks = "";
            komsuC0041.ZwebKomsuF004Service srv = new komsuC0041.ZwebKomsuF004Service();
            srv.Credentials = nc3;
            komsuC0041.ZwebKomsuS_004[] dortler = srv.ZwebKomsuF004(Matnr, new komsuC0041.Werks() { Werks1 = Werks });
            return dortler;
        }
    }
}
