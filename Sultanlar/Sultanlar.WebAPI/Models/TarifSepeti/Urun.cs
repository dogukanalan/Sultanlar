using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Models.TarifSepeti
{
    public class Urun
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public int ResimID { get; set; }

        public Urun() { }

        public Urun(int ID, string Ad, int ResimID)
        {
            this.ID = ID;
            this.Ad = Ad;
            this.ResimID = ResimID;
        }
    }

    public class UrunGet
    {
        public int katid { get; set; }
        public string aranan { get; set; }
        public int sonid { get; set; }
    }
}
