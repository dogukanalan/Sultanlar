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

        public KomsuC001.ZwebKomsuS_001[] komsu001(string Matnr)
        {
            KomsuC001.ZwebKomsuF001Service srv = new KomsuC001.ZwebKomsuF001Service();
            srv.Credentials = nc3;
            return srv.ZwebKomsuF001(Matnr);
        }

        public KomsuC002.ZwebKomsuS_002[] komsu002(string Matnr)
        {
            KomsuC002.ZwebKomsuF002Service srv = new KomsuC002.ZwebKomsuF002Service();
            srv.Credentials = nc3;
            return srv.ZwebKomsuF002(Matnr);
        }

        public KomsuC003.ZwebKomsuS_003[] komsu003(string Matnr)
        {
            KomsuC003.ZwebKomsuF003Service srv = new KomsuC003.ZwebKomsuF003Service();
            srv.Credentials = nc3;
            return srv.ZwebKomsuF003(Matnr);
        }

        public KomsuC004.ZwebKomsuS_004[] komsu004(string Matnr, KomsuC004.Werks Werks)
        {
            KomsuC004.ZwebKomsuF004Service srv = new KomsuC004.ZwebKomsuF004Service();
            srv.Credentials = nc3;
            KomsuC004.ZwebKomsuS_004[] dortler = srv.ZwebKomsuF004(Matnr, Werks);
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

            if (userName != "komsu" || password != "tsoft")
                throw new SecurityTokenException("Kullanıcı adı-parola yanlış.");
        }
    }
}
