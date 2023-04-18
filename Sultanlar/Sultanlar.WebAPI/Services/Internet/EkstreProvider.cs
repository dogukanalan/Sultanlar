using Sultanlar.DbObj.Internet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class EkstreProvider
    {
        internal List<ekstreler> Ekstreler(int GMREF, int Yil, int AY)
        {
            object Ay = AY == 0 ? (object)DBNull.Value : AY;

            List <ekstreler> ekstre = new ekstreler().GetObjects(GMREF, Yil, Ay);

            double oncekitoplam = 0;
            for (int i = 0; i < ekstre.Count; i++)
            {
                oncekitoplam += ekstre[i].BAKIYE;
                ekstre[i].BAKIYE = oncekitoplam;
                if (i == ekstre.Count - 1)
                {
                    ekstreler diptop = new ekstreler().GetObjectsDipTop(GMREF);
                    ekstre.Add(diptop);
                    i++;
                }
            }

            return ekstre;
        }

        internal ekstreler EkstrelerDipTop(int GMREF) => new ekstreler().GetObjectsDipTop(GMREF);
    }
}
