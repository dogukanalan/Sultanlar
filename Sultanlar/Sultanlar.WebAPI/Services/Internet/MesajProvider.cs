using Sultanlar.Class;
using Sultanlar.DbObj.Internet;
using Sultanlar.WebAPI.Models.Internet;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class MesajProvider
    {
        internal mesajlar GonderilenMesaj(int id) => new mesajlar(id, true).GetObject();

        internal mesajlar AlinanMesaj(int id) => new mesajlar(id, false).GetObject();

        internal int GonderilenOkunmayanMesajSayisi(int musteri)
        {
            return new mesajlar().GetOkunmayanCount(musteri, true);
        }

        internal DtAjaxResponse Mesajlar(int departmanid, int musteriid, bool gonderilen, DataTableAjaxPostModel Req)
        {
            DtAjaxResponse donendeger = new DtAjaxResponse();

            object DepartmanID = departmanid == 0 ? DBNull.Value : (object)departmanid;
            List<mesajlar> donendeger2 = new mesajlar().GetObjects(DepartmanID, musteriid, gonderilen);

            donendeger.recordsTotal = donendeger2.Count;
            
            for (int i = 0; i < Req.columns.Count; i++)
            {
                if (Req.columns[i].search.value != string.Empty)
                {
                    if (Req.columns[i].name == "konu")
                        donendeger2 = donendeger2.ToList().Where(k => k.strKonu.ToUpper(CultureInfo.CurrentCulture).IndexOf(Req.columns[i].search.value.ToUpper(CultureInfo.CurrentCulture)) > -1).ToList();
                    else if (Req.columns[i].name == "departman")
                        donendeger2 = donendeger2.ToList().Where(k => k.Departman.strDepartman.ToUpper(CultureInfo.CurrentCulture).IndexOf(Req.columns[i].search.value.ToUpper(CultureInfo.CurrentCulture)) > -1).ToList();
                    else if (Req.columns[i].name == "zaman")
                        donendeger2 = donendeger2.ToList().Where(k => k.dtGondermeZamani.ToShortDateString() == Convert.ToDateTime(Req.columns[i].search.value).ToShortDateString()).ToList();
                }
            }

            donendeger.recordsFiltered = donendeger2.Count;

            int Baslangic = Req.start;
            int Kactane = Req.length;
            int sinir = (Baslangic + Kactane) < donendeger2.Count ? (Baslangic + Kactane) : donendeger2.Count;
            donendeger.json = new List<object>();
            for (int i = Baslangic; i < sinir; i++)
                donendeger.json.Add(donendeger2[i]);
            
            return donendeger;
        }

        internal string MesajGonder(Mesaj mesaj)
        {
            mesajlar msj = new mesajlar(Convert.ToInt32(Sifreleme.Decrypt(mesaj.musteri)), mesaj.departman, mesaj.konu, mesaj.icerik.Replace("\n", "<br />"), DateTime.Now, DateTime.Now, false, false, false, false);
            msj.DoInsert();

            return msj.pkMesajID.ToString();
        }

        internal string GonderilenSil(int id, bool gonderen)
        {
            mesajlar msj = new mesajlar(id, true).GetObject();
            if (gonderen)
                msj.blGonderenSil = true;
            else
                msj.blOkuyanSil = true;
            msj.DoUpdate();
            return "";
        }

        internal string AlinanSil(int id, bool gonderen)
        {
            mesajlar msj = new mesajlar(id, false).GetObject();
            if (gonderen)
                msj.blGonderenSil = true;
            else
                msj.blOkuyanSil = true;
            msj.DoUpdate();
            return "";
        }

        internal string GonderilenOkundu(int id)
        {
            mesajlar msj = new mesajlar(id, true).GetObject();
            msj.blOkundu = true;
            msj.dtOkunmaZamani = DateTime.Now;
            msj.DoUpdate();
            return "";
        }

        internal string AlinanOkundu(int id)
        {
            mesajlar msj = new mesajlar(id, false).GetObject();
            msj.blOkundu = true;
            msj.dtOkunmaZamani = DateTime.Now;
            msj.DoUpdate();
            return "";
        }
    }
}
