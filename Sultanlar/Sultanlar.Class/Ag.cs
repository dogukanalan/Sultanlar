using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices.AccountManagement;
using System.Collections;
using System.Net.NetworkInformation;

namespace Sultanlar.Class
{
    public class Ag
    {
        public static string IP = "1.1.1.1";

        public static string DbIP 
        { 
            get
            {
                if (IP != "1.1.1.1") return IP;

                Ping pinger = new Ping();
                PingReply pingreply = pinger.Send("10.1.1.14", 10);
                if (pingreply.Status == IPStatus.Success)
                    IP = "";
                else
                    IP = "95.0.47.133";

                return IP; //System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + "\\IP.txt") ? System.IO.File.ReadAllText(System.Windows.Forms.Application.StartupPath + "\\IP.txt") : string.Empty;
            } 
        }
        //
        //
        //
        //
        //
        public static PrincipalContext insPrincipalContext;
        //
        //
        //
        //
        //
        public static void DomainKullanicilariGetir(IList List)
        {
            insPrincipalContext = new PrincipalContext(ContextType.Domain, "sultanlar.dom", "DC=sultanlar,DC=dom");
            UserPrincipal insUserPrincipal = new UserPrincipal(insPrincipalContext);
            insUserPrincipal.Name = "*";

            List.Clear();
            PrincipalSearcher insPrincipalSearcher = new PrincipalSearcher();
            insPrincipalSearcher.QueryFilter = insUserPrincipal;
            PrincipalSearchResult<Principal> results = insPrincipalSearcher.FindAll();

            foreach (Principal p in results)
            {
                List.Add(p.SamAccountName);
            }
        }
    }
}
