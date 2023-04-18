using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sultanlar.Class
{
    public class Math
    {
        public static double IskontoDus(double fiyat, double isk1, double isk2, double isk3, double isk4, double isk5)
        {
            double birinci = fiyat - (fiyat * isk1 / 100);
            double ikinci = birinci - (birinci * isk2 / 100);
            double ucuncu = ikinci - (ikinci * isk3 / 100);
            double dorduncu = ucuncu - (ucuncu * isk4 / 100);
            return dorduncu - (dorduncu * isk5 / 100);
        }

        public static double KdvEkle(double fiyat, double kdv)
        {
            return fiyat * (100 + kdv) / 100;
        }
    }
}
