using Sultanlar.DbObj.Internet;
using Sultanlar.WebAPI.Models.Internet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class KonumProvider
    {
        internal List<konumListe> KonumListe(int Slsref) => new konumListe().GetObjects(Slsref);

        internal DtAjaxResponse KonumListe2(int Slsref, DataTableAjaxPostModel Req)
        {
            Dictionary<string, string> arama = new Dictionary<string, string>();
            for (int i = 0; i < Req.columns.Count; i++)
                if (Req.columns[i].search.value != string.Empty)
                    arama.Add(Req.columns[i].data, Req.columns[i].search.value);
            return new konumListe().GetObjects(Slsref, Req.length, Req.start, arama);
        }
    }
}
