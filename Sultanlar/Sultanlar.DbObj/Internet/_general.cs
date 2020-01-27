using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    internal class _general
    {
    }

    public class DtAjaxResponse
    {
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<object> json { get; set; }
        public double sum1 { get; set; }
        public double sum2 { get; set; }
        public double sum3 { get; set; }
        public double sum4 { get; set; }
        public double sum5 { get; set; }
    }
}
