using Sultanlar.DatabaseObject;
using Sultanlar.DbObj.Internet;
using Sultanlar.WebAPI.Models.Internet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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

        //databaseobject
        internal string KonumSet(string smref, string tip, string Coords, string Coords1)
        {
            string lat = Coords1.ToString().Substring(0, Coords1.ToString().IndexOf(",")).Trim();
            string lng = Coords1.Substring(Coords1.IndexOf(",") + 1).Trim();
            string adres = Coords;

            DatabaseObject.Internet.Rutlar.SetKonum(Convert.ToInt32(smref), Convert.ToInt32(tip), lat + "," + lng);
            DatabaseObject.Internet.Rutlar.SetKonumAdres(Convert.ToInt32(smref), Convert.ToInt32(tip), adres);

            return "";
        }

        //databaseobject
        internal string SlsrefKonum(object obj)
        {
            string jsonStr = obj.ToString();
            JsonDocument json = JsonDocument.Parse(jsonStr);
            string slsref = json.RootElement.GetProperty("slsref").GetString();
            string coord = json.RootElement.GetProperty("coord").GetString();
            string yer = json.RootElement.GetProperty("yer").GetString();
            string sayfa = json.RootElement.GetProperty("sayfa").GetString();

            string SLSREF = slsref;
            string ZAMAN = DateTime.Now.Month.ToString() + "." + DateTime.Now.Day.ToString() + "." + DateTime.Now.Year.ToString() + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            string COORD = coord;
            string YER = yer;
            string SAYFA = sayfa;
            WebGenel.Sorgu("INSERT INTO [Web-SatisTemsilcileri-Log] (SLSREF,ZAMAN,COORD,YER,SAYFA) VALUES (" +
                SLSREF + ",CONVERT(datetime,'" + ZAMAN + "'),'" + COORD + "','" + YER.Replace("'", "").Replace("\"", "").Replace("%", "") + "','" + SAYFA + "')");

            return "";
        }
    }
}
