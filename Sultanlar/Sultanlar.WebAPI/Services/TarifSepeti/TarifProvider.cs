using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sultanlar.Class;
using Sultanlar.DatabaseObject.Kenton;
using Sultanlar.WebAPI.Models.TarifSepeti;

namespace Sultanlar.WebAPI.Services.TarifSepeti
{
    public class TarifProvider
    {
        public List<Tarif> TariflerGetir(TarifGet get)
        {
            List<Tarif> donendeger = new List<Tarif>();

            List<Tarifler> returnvalue = new List<Tarifler>();

            if (get.action == "")
                returnvalue = Tarifler.GetObjects(get.sonid, get.kactane, get.aranan, get.katid, get.order);
            else if (get.action == "benim")
                returnvalue = Tarifler.GetObjectsOwn(get.sonid, get.kactane, Convert.ToInt32(Sifreleme.Decrypt(get.uyeid)), get.aranan, get.order);
            else if (get.action == "fav")
                returnvalue = Tarifler.GetObjectsFav(get.sonid, get.kactane, Convert.ToInt32(Sifreleme.Decrypt(get.uyeid)), get.aranan, get.order);
            else if (get.action == "urun")
                returnvalue = Tarifler.GetObjectsByUrunID(get.sonid, get.kactane, Convert.ToInt32(get.urunid), get.aranan, get.order); // uye id aslinda urun id
            else if (get.action == "kul")
                returnvalue = Tarifler.GetObjectsKul(get.sonid, get.kactane, get.aranan, get.katid, get.order);

            for (int i = 0; i < returnvalue.Count; i++)
            {
                List<TarifKat> tarkats = new List<TarifKat>();
                for (int j = 0; j < returnvalue[i].TarifKategoriler.Count; j++)
                    tarkats.Add(new TarifKat(returnvalue[i].TarifKategoriler[j].pkID, returnvalue[i].TarifKategoriler[j].intTarifID, returnvalue[i].TarifKategoriler[j].intKategoriID));
                Uye uye = new Uye(returnvalue[i].Uye.pkID, returnvalue[i].Uye.strAd, returnvalue[i].Uye.strSoyad, returnvalue[i].Uye.strEposta, returnvalue[i].Uye.strSifre, returnvalue[i].Uye.dtDogum, returnvalue[i].Uye.dtTarih, returnvalue[i].Uye.blPasif);
                donendeger.Add(new Tarif(returnvalue[i].pkID, returnvalue[i].intUyeID, uye, returnvalue[i].blOnay, returnvalue[i].strBaslik, returnvalue[i].strMalzemeler, returnvalue[i].strHazirlanis, returnvalue[i].binResim, returnvalue[i].binResimUrunler, returnvalue[i].strUrunlerLink, returnvalue[i].dtTarih, returnvalue[i].OrtPuan, tarkats));
            }

            return donendeger;
        }
    }
}
