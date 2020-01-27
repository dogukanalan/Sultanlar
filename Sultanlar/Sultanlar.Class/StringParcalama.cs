using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Collections;

namespace Sultanlar.Class
{
    public class StringParcalama
    {
        //
        //
        //
        //
        //
        public static string IlkHarfBuyuk(string ham)
        {
            string donendeger = string.Empty;

            if (ham.Length > 1)
            {
                //donendeger = ham.Substring(0, 1).ToUpper() + ham.Substring(1).ToLower();

                char[] ayrac = new char[1];
                ayrac[0] = ' ';
                string[] parcalar = ham.Trim().Split(ayrac);
                for (int i = 0; i < parcalar.Length; i++)
                {
                    if (parcalar[i].Length > 1)
                        donendeger += parcalar[i].Substring(0, 1).ToUpper() + parcalar[i].Substring(1).ToLower() + " ";
                }

                //if (donendeger.IndexOf(" ") > 0)
                //{
                //    try
                //    {
                //        donendeger = donendeger.Substring(0, donendeger.IndexOf(" ")) + " " +
                //            donendeger.Substring(donendeger.IndexOf(" ") + 1, 1).ToUpper() + donendeger.Substring(donendeger.IndexOf(" ") + 2).ToLower();

                //        donendeger = donendeger.Substring(0, donendeger.LastIndexOf(" ")) + " " +
                //            donendeger.Substring(donendeger.LastIndexOf(" ") + 1, 1).ToUpper() + donendeger.Substring(donendeger.LastIndexOf(" ") + 2).ToLower();
                //    }
                //    catch (Exception ex) { Hatalar.DoInsert(ex, "Sultanlar.Class.StringParcalama.IlkHarfBuyuk"); }
                //}
            }
            
            return donendeger.Trim();
        }
        //
        //
        //
        //
        //
        public static DateTime TariheCevir(string Tarih, object ctrl)
        {
            DateTime donendeger = DateTime.Now;

            if (Tarih != string.Empty)
            {
                donendeger = DateTime.Parse(Tarih);
            }
            else
            {
                //((DateTimePicker)ctrl).Enabled = false;
            }

            return donendeger;
        }
        //
        //
        //
        //
        //
        public static string HtmlToText(string ham)
        {
            string donendeger = string.Empty;
            donendeger = ham.Replace("<br />", "\r\n");
            return donendeger;
        }
        //
        //
        //
        //
        //
        public static string TextToHtml(string ham)
        {
            string donendeger = string.Empty;
            donendeger = ham.Replace("\r\n", "<br />");
            return donendeger;
        }
        //
        //
        //
        //
        //
        public static string HavaDurumu()
        {
            string donendeger = string.Empty;

            try
            {
                //donendeger = "<span style='font-size: 10px'>İstanbul Hava Durumu: <img alt='havadurumu' width='20px' src='";

                //WebResponse wr = WebRequest.Create("http://www.meteoroloji.web.tr/2.php?id=TUXX0014&baslik=istanbul").GetResponse();
                //Stream stream = wr.GetResponseStream();
                //StreamReader strR = new StreamReader(stream, Encoding.GetEncoding("iso-8859-9"));
                //string sayfa = strR.ReadToEnd();
                //strR.Close();
                //strR.Dispose();
                //wr.Close();
                //int baslangic = sayfa.IndexOf("YWeather_temp>") + 14;
                //int bitis = sayfa.IndexOf("</p>", baslangic);
                //string derece = sayfa.Substring(baslangic, bitis - baslangic);

                //int resimbaslangic = sayfa.IndexOf("<img src=") + 9;
                //int resimbitis = sayfa.IndexOf(" class", resimbaslangic);
                //string resim = sayfa.Substring(resimbaslangic, resimbitis - resimbaslangic);

                //donendeger += resim + "' /> " + derece + "</span>";

                //donendeger = "<span style='font-size: 10px'>İstanbul Hava Durumu: <img alt='havadurumu' width='20px' src='http://www.havadurumu.com.tr";

                //WebResponse wr = WebRequest.Create("http://www.havadurumu.com.tr/turkiye/istanbul_hava_durumu/").GetResponse();
                //Stream stream = wr.GetResponseStream();
                //StreamReader strR = new StreamReader(stream, Encoding.GetEncoding("iso-8859-9"));
                //string sayfa = strR.ReadToEnd();
                //strR.Close();
                //strR.Dispose();
                //wr.Close();

                //int resimbaslangic1 = sayfa.IndexOf("<span class=\"style3\">");
                //int resimbaslangic = sayfa.IndexOf("&nbsp;<img src=\"", resimbaslangic1) + 16;
                //int resimbitis = sayfa.IndexOf("\" width=", resimbaslangic);
                //string resim = sayfa.Substring(resimbaslangic, resimbitis - resimbaslangic);

                //int baslangic = sayfa.IndexOf("<span class=\"style3\">", resimbaslangic) + 21;
                //int bitis = sayfa.IndexOf(",", baslangic);
                //string derece = sayfa.Substring(baslangic, bitis - baslangic);

                //donendeger += resim + "' /> " + derece.Trim() + "</span>";


                

                WebResponse wr = WebRequest.Create("http://www.mgm.gov.tr/sondurum/turkiye.aspx?g=T").GetResponse();
                Stream stream = wr.GetResponseStream();
                StreamReader strR = new StreamReader(stream, Encoding.UTF8);
                string sayfa = strR.ReadToEnd();
                strR.Close();
                strR.Dispose();
                wr.Close();

                int bas = sayfa.IndexOf("Sabiha Gökçen Hvl.") + 18;
                int bas2 = sayfa.IndexOf("</tr>", bas) + 1;

                int baslangicSaat = sayfa.IndexOf("<td>", bas2) + 4;
                int bitisSaat = sayfa.IndexOf("</td>", baslangicSaat);
                string saat = sayfa.Substring(baslangicSaat, bitisSaat - baslangicSaat);

                int baslangic = sayfa.IndexOf("class=\"saga\">", bas2) + 13;
                int bitis = sayfa.IndexOf("</td>", baslangic);
                string derece = sayfa.Substring(baslangic, bitis - baslangic);

                int resimbaslangic = sayfa.IndexOf("<img src=\"../", bas) + 13;
                int resimbitis = sayfa.IndexOf("\" />", resimbaslangic);
                string resim = sayfa.Substring(resimbaslangic, resimbitis - resimbaslangic);

                //resim = "<img width='20px' height='20px' src='http://www.mgm.gov.tr/sunum/tahmingor-a1.aspx?g=1&m=ISTANBUL' alt='İstanbul Hava Durumu' />";

                donendeger = "<span style='font-size: 10px' title='Sabiha Gökçen F1 : " + saat + "'>İstanbul Hava Durumu: <img src=\"http://www.mgm.gov.tr/";

                donendeger += resim + "\" /> " + derece.Trim() + "</span>";
            }
            catch (Exception ex)
            {
                donendeger = string.Empty;
                //Hatalar.DoInsert(ex, "Hava Durumu");
            }
            
            return donendeger;
        }
        //
        //
        //
        //
        //
        public static ArrayList TurkceKarakterPermutasyon(string Kelime)
        {
            ArrayList donendeger = new ArrayList();
            string Deger = Kelime.ToUpper().Replace("I", "İ").Replace("Ü", "U").Replace("Ö", "O").Replace("Ş", "S").Replace("Ç", "C").Replace("Ğ", "G");
            donendeger.Add(Deger);

            ArrayList ivar = new ArrayList(), ovar = new ArrayList(), uvar = new ArrayList(), gvar = new ArrayList(), cvar = new ArrayList(), svar = new ArrayList();
            for (int i = 0; i < Deger.Length; i++)
            {
                if (Deger[i] == 'İ')
                    ivar.Add(i);
                else if (Deger[i] == 'O')
                    ovar.Add(i);
                else if (Deger[i] == 'U')
                    uvar.Add(i);
                else if (Deger[i] == 'G')
                    gvar.Add(i);
                else if (Deger[i] == 'C')
                    cvar.Add(i);
                else if (Deger[i] == 'S')
                    svar.Add(i);
            }

            #region ivar
            for (int i = 0; i < ivar.Count; i++)
            {
                int sinir = donendeger.Count;
                for (int k = 0; k < sinir; k++)
                {
                    string eklenecek = string.Empty;
                    char[] deger1 = donendeger[k].ToString().ToCharArray();
                    deger1[Convert.ToInt32(ivar[i])] = 'İ';
                    for (int j = 0; j < deger1.Length; j++)
                        eklenecek += deger1[j];
                    bool var = false;
                    for (int j = 0; j < donendeger.Count; j++)
                    {
                        if (donendeger[j].ToString() == eklenecek)
                        {
                            var = true;
                            break;
                        }
                    }
                    if (!var)
                        donendeger.Add(eklenecek);

                    eklenecek = string.Empty;
                    char[] deger2 = donendeger[k].ToString().ToCharArray();
                    deger2[Convert.ToInt32(ivar[i])] = 'I';
                    for (int j = 0; j < deger2.Length; j++)
                        eklenecek += deger2[j];
                    var = false;
                    for (int j = 0; j < donendeger.Count; j++)
                    {
                        if (donendeger[j].ToString() == eklenecek)
                        {
                            var = true;
                            break;
                        }
                    }
                    if (!var)
                        donendeger.Add(eklenecek);
                }
            }
            #endregion

            #region ovar
            for (int i = 0; i < ovar.Count; i++)
            {
                int sinir = donendeger.Count;
                for (int k = 0; k < sinir; k++)
                {
                    string eklenecek = string.Empty;
                    char[] deger1 = donendeger[k].ToString().ToCharArray();
                    deger1[Convert.ToInt32(ovar[i])] = 'Ö';
                    for (int j = 0; j < deger1.Length; j++)
                        eklenecek += deger1[j];
                    bool var = false;
                    for (int j = 0; j < donendeger.Count; j++)
                    {
                        if (donendeger[j].ToString() == eklenecek)
                        {
                            var = true;
                            break;
                        }
                    }
                    if (!var)
                        donendeger.Add(eklenecek);

                    eklenecek = string.Empty;
                    char[] deger2 = donendeger[k].ToString().ToCharArray();
                    deger2[Convert.ToInt32(ovar[i])] = 'O';
                    for (int j = 0; j < deger2.Length; j++)
                        eklenecek += deger2[j];
                    var = false;
                    for (int j = 0; j < donendeger.Count; j++)
                    {
                        if (donendeger[j].ToString() == eklenecek)
                        {
                            var = true;
                            break;
                        }
                    }
                    if (!var)
                        donendeger.Add(eklenecek);
                }
            }
            #endregion

            #region uvar
            for (int i = 0; i < uvar.Count; i++)
            {
                int sinir = donendeger.Count;
                for (int k = 0; k < sinir; k++)
                {
                    string eklenecek = string.Empty;
                    char[] deger1 = donendeger[k].ToString().ToCharArray();
                    deger1[Convert.ToInt32(uvar[i])] = 'Ü';
                    for (int j = 0; j < deger1.Length; j++)
                        eklenecek += deger1[j];
                    bool var = false;
                    for (int j = 0; j < donendeger.Count; j++)
                    {
                        if (donendeger[j].ToString() == eklenecek)
                        {
                            var = true;
                            break;
                        }
                    }
                    if (!var)
                        donendeger.Add(eklenecek);

                    eklenecek = string.Empty;
                    char[] deger2 = donendeger[k].ToString().ToCharArray();
                    deger2[Convert.ToInt32(uvar[i])] = 'U';
                    for (int j = 0; j < deger2.Length; j++)
                        eklenecek += deger2[j];
                    var = false;
                    for (int j = 0; j < donendeger.Count; j++)
                    {
                        if (donendeger[j].ToString() == eklenecek)
                        {
                            var = true;
                            break;
                        }
                    }
                    if (!var)
                        donendeger.Add(eklenecek);
                }
            }
            #endregion

            #region gvar
            for (int i = 0; i < gvar.Count; i++)
            {
                int sinir = donendeger.Count;
                for (int k = 0; k < sinir; k++)
                {
                    string eklenecek = string.Empty;
                    char[] deger1 = donendeger[k].ToString().ToCharArray();
                    deger1[Convert.ToInt32(gvar[i])] = 'Ğ';
                    for (int j = 0; j < deger1.Length; j++)
                        eklenecek += deger1[j];
                    bool var = false;
                    for (int j = 0; j < donendeger.Count; j++)
                    {
                        if (donendeger[j].ToString() == eklenecek)
                        {
                            var = true;
                            break;
                        }
                    }
                    if (!var)
                        donendeger.Add(eklenecek);

                    eklenecek = string.Empty;
                    char[] deger2 = donendeger[k].ToString().ToCharArray();
                    deger2[Convert.ToInt32(gvar[i])] = 'G';
                    for (int j = 0; j < deger2.Length; j++)
                        eklenecek += deger2[j];
                    var = false;
                    for (int j = 0; j < donendeger.Count; j++)
                    {
                        if (donendeger[j].ToString() == eklenecek)
                        {
                            var = true;
                            break;
                        }
                    }
                    if (!var)
                        donendeger.Add(eklenecek);
                }
            }
            #endregion

            #region cvar
            for (int i = 0; i < cvar.Count; i++)
            {
                int sinir = donendeger.Count;
                for (int k = 0; k < sinir; k++)
                {
                    string eklenecek = string.Empty;
                    char[] deger1 = donendeger[k].ToString().ToCharArray();
                    deger1[Convert.ToInt32(cvar[i])] = 'Ç';
                    for (int j = 0; j < deger1.Length; j++)
                        eklenecek += deger1[j];
                    bool var = false;
                    for (int j = 0; j < donendeger.Count; j++)
                    {
                        if (donendeger[j].ToString() == eklenecek)
                        {
                            var = true;
                            break;
                        }
                    }
                    if (!var)
                        donendeger.Add(eklenecek);

                    eklenecek = string.Empty;
                    char[] deger2 = donendeger[k].ToString().ToCharArray();
                    deger2[Convert.ToInt32(cvar[i])] = 'C';
                    for (int j = 0; j < deger2.Length; j++)
                        eklenecek += deger2[j];
                    var = false;
                    for (int j = 0; j < donendeger.Count; j++)
                    {
                        if (donendeger[j].ToString() == eklenecek)
                        {
                            var = true;
                            break;
                        }
                    }
                    if (!var)
                        donendeger.Add(eklenecek);
                }
            }
            #endregion

            #region svar
            for (int i = 0; i < svar.Count; i++)
            {
                int sinir = donendeger.Count;
                for (int k = 0; k < sinir; k++)
                {
                    string eklenecek = string.Empty;

                    char[] deger1 = donendeger[k].ToString().ToCharArray();
                    deger1[Convert.ToInt32(svar[i])] = 'Ş';
                    for (int j = 0; j < deger1.Length; j++)
                        eklenecek += deger1[j];
                    bool var = false;
                    for (int j = 0; j < donendeger.Count; j++)
                    {
                        if (donendeger[j].ToString() == eklenecek)
                        {
                            var = true;
                            break;
                        }
                    }
                    if (!var)
                        donendeger.Add(eklenecek);

                    eklenecek = string.Empty;
                    char[] deger2 = donendeger[k].ToString().ToCharArray();
                    deger2[Convert.ToInt32(svar[i])] = 'S';
                    for (int j = 0; j < deger2.Length; j++)
                        eklenecek += deger2[j];
                    var = false;
                    for (int j = 0; j < donendeger.Count; j++)
                    {
                        if (donendeger[j].ToString() == eklenecek)
                        {
                            var = true;
                            break;
                        }
                    }
                    if (!var)
                        donendeger.Add(eklenecek);
                }
            }
            #endregion

            return donendeger;
        }
        public static ArrayList TurkceKarakterPermutasyonESKI(string Kelime)
        {
            ArrayList donendeger = new ArrayList();
            string Deger = Kelime.ToUpper().Replace("I", "İ").Replace("Ü", "U").Replace("Ö", "O").Replace("Ş", "S").Replace("Ç", "C").Replace("Ğ", "G");
            donendeger.Add(Deger);

            bool ivar = false, ovar = false, uvar = false, gvar = false, cvar = false, svar = false;
            for (int i = 0; i < Deger.Length; i++)
            {
                if (Deger[i] == 'İ' && !ivar)
                {
                    ivar = true;
                    int sayi = donendeger.Count;
                    for (int j = 0; j < sayi; j++)
                        donendeger.Add(donendeger[j].ToString().Replace('İ', 'I'));
                }
                else if (Deger[i] == 'O' && !ovar)
                {
                    ovar = true;
                    int sayi = donendeger.Count;
                    for (int j = 0; j < sayi; j++)
                        donendeger.Add(donendeger[j].ToString().Replace('O', 'Ö'));
                }
                else if (Deger[i] == 'U' && !uvar)
                {
                    uvar = true;
                    int sayi = donendeger.Count;
                    for (int j = 0; j < sayi; j++)
                        donendeger.Add(donendeger[j].ToString().Replace('U', 'Ü'));
                }
                else if (Deger[i] == 'G' && !gvar)
                {
                    gvar = true;
                    int sayi = donendeger.Count;
                    for (int j = 0; j < sayi; j++)
                        donendeger.Add(donendeger[j].ToString().Replace('G', 'Ğ'));
                }
                else if (Deger[i] == 'C' && !cvar)
                {
                    cvar = true;
                    int sayi = donendeger.Count;
                    for (int j = 0; j < sayi; j++)
                        donendeger.Add(donendeger[j].ToString().Replace('C', 'Ç'));
                }
                else if (Deger[i] == 'S' && !svar)
                {
                    svar = true;
                    int sayi = donendeger.Count;
                    for (int j = 0; j < sayi; j++)
                        donendeger.Add(donendeger[j].ToString().Replace('S', 'Ş'));
                }
            }

            return donendeger;
        }

        public static string NoktayiBoslukla(string ham)
        {
            string donendeger = string.Empty;

            if (ham.Length < 2) return ham;

            string[] parcalar = ham.Substring(1, ham.Length - 1).Split(new string[] { "." }, StringSplitOptions.None);
            donendeger = ham[0].ToString();
            for (int i = 0; i < parcalar.Length; i++)
                donendeger += parcalar[i].Trim() + ". ";
            donendeger = donendeger.Substring(0, donendeger.Length - 2);
            //donendeger += ham[ham.Length - 1].ToString();

            //ArrayList noktalar = new ArrayList();
            //for (int i = 0; i < ham.Length; i++)
            //{
            //    if (ham[i] == '.')
            //    {
            //        if (i > 0 && ham[i - 1] != ' ' && i + 1 < ham.Length && ham[i + 1] != ' ')
            //        {
            //            noktalar.Add(i);
            //        }
            //    }
            //}

            //if (noktalar.Count > 0)
            //{
            //    ArrayList parcalar = new ArrayList();
            //    parcalar.Add(ham.Substring(0, Convert.ToInt32(noktalar[0]) + 1));
            //    for (int i = 0; i < noktalar.Count - 1; i++)
            //    {
            //        parcalar.Add(ham.Substring(Convert.ToInt32(noktalar[i]) + 1, Convert.ToInt32(noktalar[i + 1]) - Convert.ToInt32(noktalar[i])));
            //    }
            //    parcalar.Add(ham.Substring(Convert.ToInt32(noktalar[noktalar.Count - 1]) + 1));

            //    for (int i = 0; i < parcalar.Count; i++)
            //    {
            //        donendeger += parcalar[i].ToString() + " ";
            //    }
            //}

            return donendeger;
        }
    }
}
