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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Komsu" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Komsu.svc or Komsu.svc.cs at the Solution Explorer and start debugging.
    public class Komsu : IKomsu
    {
        NetworkCredential nc3 = new NetworkCredential("mbozdag", "Alfa123**"); //mbozdag Alfa123**

        public void DoWork()
        {
        }

        public string Test()
        {
            return "Çalışıyor";
        }

        public Komsu001.ZwebKomsuS_001[] komsu001(string Matnr)
        {
            Komsu001.ZwebKomsuF001Service srv = new Komsu001.ZwebKomsuF001Service();
            srv.Credentials = nc3;
            return srv.ZwebKomsuF001(Matnr);
        }

        public Komsu002.ZwebKomsuS_002[] komsu002(string Matnr)
        {
            Komsu002.ZwebKomsuF002Service srv = new Komsu002.ZwebKomsuF002Service();
            srv.Credentials = nc3;
            return srv.ZwebKomsuF002(Matnr);
        }

        public Komsu003.ZwebKomsuS_003[] komsu003(string Matnr)
        {
            Komsu003.ZwebKomsuF003Service srv = new Komsu003.ZwebKomsuF003Service();
            srv.Credentials = nc3;
            return srv.ZwebKomsuF003(Matnr);
        }

        public Komsu004.ZwebKomsuS_004[] komsu004(string Matnr, Komsu004.Werks Werks)
        {
            Komsu004.ZwebKomsuF004Service srv = new Komsu004.ZwebKomsuF004Service();
            srv.Credentials = nc3;
            Komsu004.ZwebKomsuS_004[] dortler = srv.ZwebKomsuF004(Matnr, Werks);
            return dortler;
        }
    }

    public class KomsuServiceAuthenticator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException("username");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");

            if (userName != "test" || password != "test")
                throw new SecurityTokenException("Kullanıcı adı-parola yanlış.");
        }
    }
}
