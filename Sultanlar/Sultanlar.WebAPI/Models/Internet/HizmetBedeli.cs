using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Models.Internet
{
    public class HizmetBedeliGet
    {
        public int slsref { get; set; }
        public int gmref { get; set; }
        public int smref { get; set; }
        public int yil { get; set; }
        public int ay { get; set; }


        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public List<Column> columns { get; set; }
        public Search search { get; set; }
        public List<Order> order { get; set; }
    }
    public class HizmetBedeliKaydet
    {
        public int id { get; set; }
        public string musteri { get; set; }
        public int smref { get; set; }
        public int anlasmabedeladid { get; set; }
        public int ay { get; set; }
        public int yil { get; set; }
        public string faturano { get; set; }
        public string faturatarih { get; set; }
        public double tahbedel { get; set; }
        public double yegbedel { get; set; }
        public string aciklama { get; set; }
        public int mudurbutcesi { get; set; }
        public int elemanbutcesi { get; set; }
        public int kapamaetki { get; set; }
    }
}
