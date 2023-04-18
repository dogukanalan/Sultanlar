using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DatabaseObject.Internet
{
    public class Genel
    {
        public static string BayiSiparisnoDuzeltme(int siparisno)
        {
            string donendeger = string.Empty;
            string numara = siparisno.ToString();
            switch (numara.Length)
            {
                case 1:
                    donendeger = "0000" + numara;
                    break;
                case 2:
                    donendeger = "000" + numara;
                    break;
                case 3:
                    donendeger = "00" + numara;
                    break;
                case 4:
                    donendeger = "0" + numara;
                    break;
                case 5:
                    donendeger = numara;
                    break;
                default:
                    break;
            }
            return "SLT" + DateTime.Now.Year.ToString() + donendeger;
        }
    }
}
