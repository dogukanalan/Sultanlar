using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Collections;

namespace Sultanlar.Class
{
    public class StringEczane
    {
        public static void EczanelerEkle(int gunekadar, object lbl)
        {
            for (int gun = DateTime.Now.Day; gun <= gunekadar; gun++)
            {
                for (int ilce = 1; ilce < 41; ilce++)
                {
                    if (ilce != 12)
                    {
                        string tarih = gun + "." + DateTime.Now.Month + "." + DateTime.Now.Year;
                        WebResponse wr = WebRequest.Create("http://www.istanbulsaglik.gov.tr/w/nobet/liste.asp?lc=" + ilce + "&gun=" + tarih).GetResponse();

                        Stream stream = wr.GetResponseStream();
                        StreamReader strR = new System.IO.StreamReader(stream, Encoding.GetEncoding("iso-8859-9"));
                        string sayfa = strR.ReadToEnd();
                        strR.Close();
                        strR.Dispose();
                        wr.Close();

                        int baslangic = sayfa.IndexOf(tarih + "&nbsp;Tarihindeki");
                        int bitis = sayfa.IndexOf("<td  class=\"sagMenust\"");
                        string ana = sayfa.Substring(baslangic, bitis - baslangic);
                        string[] ayrac = new string[1];
                        ayrac[0] = "<table";
                        string[] eczanelerKabasi = ana.Split(ayrac, StringSplitOptions.None);
                        string[] eczaneler = new string[eczanelerKabasi.Length - 1];

                        for (int i = 0; i < eczaneler.Length; i++)
                        {
                            int bas = eczanelerKabasi[i + 1].IndexOf("height=\"10\">") + 12;
                            int son = eczanelerKabasi[i + 1].IndexOf("</td>", bas);

                            int adresbas = eczanelerKabasi[i + 1].IndexOf("Adres :</td><td height=\"25\" bgcolor=\"#FDFEEB\">") + 46;
                            int adresson = eczanelerKabasi[i + 1].IndexOf("</td>", adresbas);

                            int telefonbas = eczanelerKabasi[i + 1].IndexOf("Tel :</td><td height=\"25\" bgcolor=\"#FDFEEB\">") + 44;
                            int telefonson = eczanelerKabasi[i + 1].IndexOf("</td>", telefonbas);

                            int haritabas = eczanelerKabasi[i + 1].IndexOf("<a href=\"http://sehirrehberi") + 9;
                            int haritason = eczanelerKabasi[i + 1].IndexOf("\" style", haritabas);


                            eczaneler[i] = eczanelerKabasi[i + 1].Substring(bas, son - bas);
                            string eczaneAdi = eczanelerKabasi[i + 1].Substring(bas, son - bas); //eczane adi
                            string eczaneAdresi = eczanelerKabasi[i + 1].Substring(adresbas, adresson - adresbas); //eczane adresi
                            string eczaneTelefonu = eczanelerKabasi[i + 1].Substring(telefonbas, telefonson - telefonbas); //eczane telefonu
                            string eczaneHarita = eczanelerKabasi[i + 1].Substring(haritabas, haritason - haritabas); //eczaneharitasi
                            if (!eczaneHarita.StartsWith("http"))
                            {
                                eczaneHarita = string.Empty;
                            }


                            //Eczaneler.DoInsert(Convert.ToByte(ilce), Convert.ToByte(gun), eczaneAdi, eczaneAdresi, eczaneTelefonu, eczaneHarita);
                        }

                        //lbl.Text = gun.ToString() + ". gün için " + ilce.ToString() + " nolu ilçe alındı.";
                    }
                }

                //lbl.Text = gun.ToString() + ". gün bitti.";
            }



            //lbl.Text = "İşlem tamamlandı.";
        }
        public static void EczanelerEkle2(int gunekadar, object lbl)
        {
            string ay = DateTime.Now.Month.ToString();
            if (ay.Length == 1)
                ay = "0" + ay;

            for (int gun = DateTime.Now.Day; gun <= gunekadar; gun++)
            {
                string gun1 = gun.ToString();
                if (gun.ToString().Length == 1)
                    gun1 = "0" + gun.ToString();

                WebResponse wr = WebRequest.Create("http://www.istanbulsaglik.gov.tr/w/nobet/liste.asp?lc=0&gun=" + gun1 + "." + ay + "." + DateTime.Now.Year.ToString()).GetResponse();

                Stream stream = wr.GetResponseStream();
                StreamReader strR = new System.IO.StreamReader(stream, Encoding.GetEncoding("iso-8859-9"));
                string sayfa = strR.ReadToEnd();
                strR.Close();
                strR.Dispose();
                wr.Close();

                if (sayfa.IndexOf("<img src=\"baslik01.gif\" >") == -1) break;

                int baslangic = sayfa.IndexOf("<img src=\"baslik01.gif\" >") + 25;
                int bitis = sayfa.IndexOf("</td>", baslangic);
                string ana = sayfa.Substring(baslangic, bitis - baslangic);

                string[] ayrac = new string[1];
                ayrac[0] = "<br>";

                string[] herilce = ana.Split(ayrac, StringSplitOptions.None);
                ArrayList ilcekodlar = new ArrayList();
                for (int i = 0; i < herilce.Length - 1; i++)
                {
                    int baslangic1 = herilce[i].IndexOf("('") + 2;
                    int bitis1 = herilce[i].IndexOf("')");
                    string ilcekod = herilce[i].Substring(baslangic1, bitis1 - baslangic1);
                    ilcekodlar.Add(ilcekod);
                }



                for (int i = 0; i < ilcekodlar.Count; i++)
                {
                    int baslangic1 = ilcekodlar[i].ToString().IndexOf("=") + 1;
                    int bitis1 = ilcekodlar[i].ToString().IndexOf("&");
                    string ilceid = ilcekodlar[i].ToString().Substring(baslangic1, bitis1 - baslangic1);



                    WebResponse wr1 = WebRequest.Create("http://ismgis.istanbulsaglik.gov.tr/eczane/GetNobetciEczaneler.aspx" + ilcekodlar[i].ToString()).GetResponse();

                    Stream stream1 = wr1.GetResponseStream();
                    StreamReader strR1 = new System.IO.StreamReader(stream1, Encoding.UTF8);
                    string sayfa1 = strR1.ReadToEnd();
                    strR1.Close();
                    strR1.Dispose();
                    wr1.Close();



                    string[] ayrac1 = new string[1];
                    ayrac1[0] = "<strong>";

                    string[] eczanelerKabasi = sayfa1.Split(ayrac1, StringSplitOptions.None);
                    for (int j = 0; j < eczanelerKabasi.Length - 2; j++)
                    {
                        //int bas = eczanelerKabasi[j + 2].IndexOf("40\"><strong>") + 12;
                        int bas = 0; // <strong> dan ayirdigimiz icin
                        int son = eczanelerKabasi[j + 2].IndexOf("</strong>", bas);

                        int adresbas = eczanelerKabasi[j + 2].IndexOf("Adres : <div/></td><td height=\"25\" bgcolor=\"#e8e8e8\">") + 53;
                        int adresson = eczanelerKabasi[j + 2].IndexOf("</td>", adresbas);

                        int telefonbas = eczanelerKabasi[j + 2].IndexOf("Tel : <div/></td><td height=\"25\" bgcolor=\"#e8e8e8\">") + 51;
                        int telefonson = eczanelerKabasi[j + 2].IndexOf("</td>", telefonbas);

                        int haritabas = eczanelerKabasi[j + 2].IndexOf("http://sehirrehberi");
                        int haritason = 1;
                        if (haritabas > -1)
                            haritason = eczanelerKabasi[j + 2].IndexOf("\"", haritabas);
                        else
                            haritabas = 0;



                        string eczaneAdi = eczanelerKabasi[j + 2].Substring(bas, son - bas); //eczane adi
                        string eczaneAdresi = eczanelerKabasi[j + 2].Substring(adresbas, adresson - adresbas); //eczane adresi
                        string eczaneTelefonu = eczanelerKabasi[j + 2].Substring(telefonbas, telefonson - telefonbas); //eczane telefonu
                        string eczaneHarita = eczanelerKabasi[j + 2].Substring(haritabas, haritason - haritabas); //eczaneharitasi
                        if (!eczaneHarita.StartsWith("http"))
                            eczaneHarita = string.Empty;



                        //Eczaneler.DoInsert(Convert.ToByte(ilceid), Convert.ToByte(gun), eczaneAdi, eczaneAdresi, eczaneTelefonu, eczaneHarita);
                    }

                    //lbl.Text = gun1 + ". gün için " + ilceid + " nolu ilçe alındı.";
                }

                //lbl.Text = gun1 + ". gün bitti.";
            }

            //lbl.Text = "İşlem tamamlandı.";
        }
    }
}
