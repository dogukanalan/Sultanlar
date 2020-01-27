using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Sultanlar.Class
{
    public class BasvuruHtml
    {
        public static string HtmlSayfaGetir
            (
            bool yazdirma, string programyeri,

            string adsoyad, string dogumtarihiyeri, string cinsiyet, string TCkimlik, string nufusililce, string medenihal,
            string annebabaadi, string basvurulangorevler, string surucubelgevarmi, string surucubelgeverilistarihi, string boy, string kilo, string kardessayisi,
            string evadresi, string evtelefonu, string ceptelefonu, string adresilce, string adresil, string epostawebsayfasi, // 19

            string esadisoyadi, string esmeslegi, string esdogumtarihi, string cocuk1ad, string cocuk1dogumtarihi, string cocuk1okul, string cocuk2ad, 
            string cocuk2dogumtarihi, string cocuk2okul, string cocuk3ad, string cocuk3dogumtarihi, string cocuk3okul, string cocuk4ad, string cocuk4dogumtarihi, 
            string cocuk4okul, string cocuk5ad, string cocuk5dogumtarihi, string cocuk5okul, // 18

            string askerlikdurumu, string askerliktipi, string terhistarihi, string teciltarihi, string asklerliksinifi, string muafiyetnedeni, // 6

            string ogrenimdurumu, string ilkokuladi, string ilkokulbolum, string ilkokulbitirmeyili, string ortaokulkuladi, string ortaokulbolum, string ortaokulbitirmeyili,
            string liseadi, string lisebolum, string lisebitirmeyili, string universiteadi, string universitebolum, string universitebitirmeyili, string lisansustuadi, 
            string lisansustubolum, string lisansustubitirmeyili, // 16

            string kurs1konu, string kurs1verenkurulus, string kurs1suresi, string kurs1yili, string kurs2konu, string kurs2verenkurulus, string kurs2suresi, string kurs2yili,
            string kurs3konu, string kurs3verenkurulus, string kurs3suresi, string kurs3yili, string kurs4konu, string kurs4verenkurulus, string kurs4suresi, string kurs4yili,
            string kurs5konu, string kurs5verenkurulus, string kurs5suresi, string kurs5yili, // 20

            string dil1, string dil1okuma, string dil1yazma, string dil1konusma, string dil2, string dil2okuma, string dil2yazma, string dil2konusma,
            string dil3, string dil3okuma, string dil3yazma, string dil3konusma, // 12

            string simdikiis, string simdikiisgorev, string simdikiisgiris, string simdikiiscikis, string simdikiisucret, string simdikiisayrilma,
            string is1, string is1gorev, string is1giris, string is1cikis, string is1ucret, string is1ayrilma,
            string is2, string is2gorev, string is2giris, string is2cikis, string is2ucret, string is2ayrilma,
            string is3, string is3gorev, string is3giris, string is3cikis, string is3ucret, string is3ayrilma,
            string is4, string is4gorev, string is4giris, string is4cikis, string is4ucret, string is4ayrilma, // 30

            string mahkeme, string durusmatarihi, string mahkumiyet, string tahliyetarihi, string bakmaklayukumlu, string sureklitedavi, string kredikartitakibat,
            string kiratutar, string kiraciklama, string ortakliktutar, string ortaklikaciklama, string digertutar, string digeraciklama, string estutar, string esaciklama,
            string kredikarti1, string kredikarti1limit, string kredikarti2, string kredikarti2limit, // 19

            string tedavisurenhastalik, string onemlihastalikameliyat, string sakatlik, // 3

            string evsizin, string baskaev, string baskaevadresdurum, string otomobil, string otomobilmarkamodeldurum, string uyedernekkulupkurulus, string hobi,
            string bilgisayarprogramlari, string meslekibasari, // 9

            string sirkettanidik, string dahaoncebasvuru, string talepucret, string baslanacaktarih, string sigara, string calismasartibeklenti, string vardiya, 
            string sehirdisicalisma, string sehirdisicalismakisitlama, // 9

            string referans1ad, string referans1sirketgorev, string referans1telefon, string referans2ad, string referans2sirketgorev, string referans2telefon,
            string referans3ad, string referans3sirketgorev, string referans3telefon, // 9

            string calismahayatibeklenti, string basvurutarihi, //2

            byte[] resim
            )
        {
            string donendeger = string.Empty;



            
            System.Drawing.Image img = Resim.ByteToImage(resim);
            img.Save("C:\\yazdir.png");

            


            string head = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
                "<html xmlns='http://www.w3.org/1999/xhtml'><head><title></title><style type='text/css'>td.Ic{border-top-style: solid;border-left-style: solid;" +
                "border-top-width: 1px;border-left-width: 1px;border-top-color: #000000;border-left-color: #000000;}table.ana{width: 730px;border-right-style: solid;" +
                "border-bottom-style: solid;border-right-width: 1px;border-bottom-width: 1px;border-bottom-color: #000000;border-right-color: #000000;}" + 
                "td.IcOrta{text-align: center;border-top-style: solid;border-left-style: solid;border-top-width: 1px;border-left-width: 1px;" + 
                "border-top-color: #000000;border-left-color: #000000;}</style></head>";

            string baslik = "<table style='width: 730px;' cellpadding='5'><tr><td style='width: 160px'><img src='" + programyeri + "slogo.jpg' /></td>" +
                "<td style='width: 420px; text-align: center; font-size: 20px; padding-bottom: 30px;' valign='bottom'>İŞ BAŞVURU FORMU</td>" +
                "<td style='width: 120px'><img src='C:\\yazdir.png' /></td></tr></table>";

            string kisiselbilgiler = "<body style='font-size: 9px; font-family: Tahoma'><table><tr><td style='font-size: 16px; padding-bottom: 5px'>" +
                "KİŞİSEL BİLGİLER</td></tr></table><table cellpadding='5' cellspacing='0' class='ana'><tr><td colspan='2' class='Ic' style='width: 490px'>" +
                "Adınız, Soyadınız (tüm isimler açık olarak)<br /><b>" + adsoyad + "</b></td><td colspan='3' class='Ic' style='width: 490px'>Doğum Tarihi - Yeri<br /><b>" +
                dogumtarihiyeri + "</b></td></tr><tr><td class='Ic' style='width: 240px'>Cinsiyet<br /><b>" + cinsiyet + "</b></td><td class='Ic' style='width: 240px'>T.C. Kimlik Numarası<br /><b>" +
                TCkimlik + "</b></td><td colspan='3' class='Ic'>Nüfusa Kay. Old. Yer (İl/İlçe)<br /><b>" + nufusililce + "</b></td></tr><tr><td class='Ic'>" +
                "Medeni Hali<br /><b>" + medenihal + "</b></td><td class='Ic'>Anne / Baba Adları (sırasıyla)<br /><b>" + annebabaadi + "</b></td>" +
                "<td colspan='3' class='Ic'>Başvurulan Görevler<br /><b>" + basvurulangorevler + "</b></td></tr><tr><td class='Ic'>Sürücü Belgeniz Var Mı?<br />" +
                "<b>" + surucubelgevarmi + "</b></td><td class='Ic'>Var ise; Sınıfı Veriliş Tarihi<br /><b>" + surucubelgeverilistarihi + "</b></td><td class='Ic' style='width: 120px'>" +
                "Boyunuz<br /><b>" + boy + "</b></td><td class='Ic' style='width: 120px'>Kilonuz<br /><b>" + kilo + "</b></td><td class='Ic' style='width: 230px'>Siz Hariç Kardeşlerinizin Sayısı<br /><b>" +
                kardessayisi + "</b></td></tr><tr><td colspan='2' rowspan='2' class='Ic' valign='top'>Ev Adresiniz<br /><b>" + evadresi + "</b></td><td colspan='3' class='Ic'>" +
                "Ev Telefonu: <b>" + evtelefonu + "</b></td></tr><tr><td colspan='3' class='Ic'>GSM (Cep) Telefonu: <b>" + ceptelefonu + "</b></td></tr><tr><td class='Ic'>" +
                "İlçe: <b>" + adresilce + "</b></td><td class='Ic'>Şehir: <b>" + adresil + "</b></td><td colspan='3' class='Ic'>E-mail adresiniz; varsa kişisel web sayfanız: <b>" +
                epostawebsayfasi + "</b></td></tr></table><br />";

            string ailebilgileri = "<table><tr><td style='font-size: 16px; padding-bottom: 5px'>AİLE BİLGİLERİ</td></tr></table>" +
                "<table cellpadding='5' cellspacing='0' class='ana'><tr><td class='Ic' style='width: 400px'>Eşinizin Adı-Evlilik Öncesi Soyadı: <b>" + esadisoyadi +
                "</b></td><td class='Ic' style='width: 280px'>Mesleği: <b>" + esmeslegi + "</b></td><td class='Ic' style='width: 290px'>Doğum Tarihi: <b>" + esdogumtarihi + "</b></td></tr>" +
                "<tr><td class='IcOrta'>Çocuklarınızın Adı</td><td class='IcOrta'>Doğum Tarihi</td>" +
                "<td class='IcOrta'>Varsa Devam Ettiği Okul</td></tr><tr><td class='IcOrta'><b>" + cocuk1ad + "</b></td><td class='IcOrta'><b>" + cocuk1dogumtarihi +
                "</b></td><td class='IcOrta'><b>" + cocuk1okul + "</b></td></tr><tr><td class='IcOrta'><b>" + cocuk2ad + "</b></td><td class='IcOrta'><b>" + cocuk2dogumtarihi +
                "</b></td><td class='IcOrta'><b>" + cocuk2okul + "</b></td></tr><tr><td class='IcOrta'><b>" + cocuk3ad + "</b></td><td class='IcOrta'><b>" + cocuk3dogumtarihi +
                "</b></td><td class='IcOrta'><b>" + cocuk3okul + "</b></td></tr><tr><td class='IcOrta'><b>" + cocuk4ad + "</b></td><td class='IcOrta'><b>" + cocuk4dogumtarihi +
                "</b></td><td class='IcOrta'><b>" + cocuk4okul + "</b></td></tr><tr><td class='IcOrta'><b>" + cocuk5ad + "</b></td><td class='IcOrta'><b>" + cocuk5dogumtarihi +
                "</b></td><td class='IcOrta'><b>" + cocuk5okul + "</b></td></tr></table><br />";

            string askerlikbilgileri = "<table><tr><td style='font-size: 16px; padding-bottom: 5px'>ASKERLİK BİLGİLERİ</td></tr></table>" +
                "<table cellpadding='5' cellspacing='0' class='ana'><tr><td class='Ic' style='width: 340px'>Durum: <b>" + askerlikdurumu + "</b></td><td class='Ic' style='width: 340px'>Tip: <b>" + askerliktipi +
                "</b></td><td class='Ic' style='width: 290px'>Terhis Tarihi: <b>" + terhistarihi + "</b></td></tr><tr><td class='Ic' rowspan='2' valign='top'>.</td><td class='Ic'>Tecil Tarihi: <b>" + teciltarihi +
                "</b></td><td class='Ic'>Sınıfınız: <b>" + asklerliksinifi + "</b></td></tr><tr><td colspan='2' class='Ic'>Muafiyet Nedeni: <b>" + muafiyetnedeni + "</b></td></tr></table><br />";

            string egitimozgecmisi = "<table><tr><td style='font-size: 16px; padding-bottom: 5px'>EĞİTİM ÖZGEÇMİŞİ</td></tr></table>" +
                "<table cellpadding='5' cellspacing='0' class='ana'><tr><td class='IcOrta' colspan='4'>Bitirdiğiniz yada kayıtlı olduğunuz tüm okulları yazınız." +
                " Henüz mezun olmadıysanız, hangi sınıfta olduğunuzu belirtiniz.</td></tr><tr><td class='Ic' style='width: 200px'>Öğrenim Durumu:</td><td class='Ic' colspan='3' style='width: 780px'><b>" +
                ogrenimdurumu + "</b></td></tr><tr><td class='Ic' style='width: 200px'>.</td><td class='IcOrta' style='width: 340px'>OKUL ADI</td><td class='IcOrta' style='width: 340px'>BÖLÜM</td>" + 
                "<td class='IcOrta' style='width: 80px'>BİTİRME YILI</td></tr>" +
                "<tr><td class='Ic'>İLKOKUL</td><td class='IcOrta'><b>" + ilkokuladi + "</b></td><td class='IcOrta'><b>" + ilkokulbolum + "</b></td>" + "<td class='IcOrta'><b>" + ilkokulbitirmeyili + "</b></td></tr>" +
                "<tr><td class='Ic'>ORTAOKUL</td><td class='IcOrta'><b>" + ortaokulkuladi + "</b></td>" + "<td class='IcOrta'><b>" + ortaokulbolum + "</b></td><td class='IcOrta'><b>" + ortaokulbitirmeyili + "</b></td></tr>" +
                "<tr><td class='Ic'>LİSE</td><td class='IcOrta'><b>" + liseadi + "</b></td><td class='IcOrta'><b>" + lisebolum + "</b></td><td class='IcOrta'><b>" + lisebitirmeyili + "</b></td></tr>" +
                "<tr><td class='Ic'>ÜNİVERSİTE</td><td class='IcOrta'><b>" + universiteadi + "</b></td><td class='IcOrta'><b>" + universitebolum + "</b></td><td class='IcOrta'><b>" + universitebitirmeyili + "</b></td></tr>" +
                "<tr><td class='Ic'>LİSANS ÜSTÜ</td><td class='IcOrta'><b>" + lisansustuadi + "</b></td><td class='IcOrta'><b>" + lisansustubolum + "</b></td><td class='IcOrta'><b>" + lisansustubitirmeyili + "</b></td></tr>" +
                "</table><br />";

            string kurslar = "<table><tr><td style='font-size: 16px; padding-bottom: 5px'>KATILDIĞI KURS, SEMİNER VE EĞİTİMLER</td></tr></table>" +
                "<table cellpadding='5' cellspacing='0' class='ana'><tr><td class='IcOrta' style='width: 380px'>Konusu</td><td class='IcOrta' style='width: 300px'>Veren Kuruluş</td>" +
                "<td class='IcOrta' style='width: 200px'>Süresi</td><td class='IcOrta' style='width: 90px'>Yılı</td></tr>" +
                "<tr><td class='IcOrta'><b>" + kurs1konu + "</b></td><td class='IcOrta'><b>" + kurs1verenkurulus + "</b></td><td class='IcOrta'><b>" + kurs1suresi + "</b></td><td class='IcOrta'><b>" + kurs1yili + "</b></td></tr>" +
                "<tr><td class='IcOrta'><b>" + kurs2konu + "</b></td><td class='IcOrta'><b>" + kurs2verenkurulus + "</b></td><td class='IcOrta'><b>" + kurs2suresi + "</b></td><td class='IcOrta'><b>" + kurs2yili + "</b></td></tr>" +
                "<tr><td class='IcOrta'><b>" + kurs3konu + "</b></td><td class='IcOrta'><b>" + kurs3verenkurulus + "</b></td><td class='IcOrta'><b>" + kurs3suresi + "</b></td><td class='IcOrta'><b>" + kurs3yili + "</b></td></tr>" +
                "<tr><td class='IcOrta'><b>" + kurs4konu + "</b></td><td class='IcOrta'><b>" + kurs4verenkurulus + "</b></td><td class='IcOrta'><b>" + kurs4suresi + "</b></td><td class='IcOrta'><b>" + kurs4yili + "</b></td></tr>" +
                "<tr><td class='IcOrta'><b>" + kurs5konu + "</b></td><td class='IcOrta'><b>" + kurs5verenkurulus + "</b></td><td class='IcOrta'><b>" + kurs5suresi + "</b></td><td class='IcOrta'><b>" + kurs5yili + "</b></td></tr>" +
                "</table><br /><br /><br /><br />";

            string yabancidiller = "<table><tr><td style='font-size: 16px; padding-bottom: 5px'>YABANCI DİL BİLGİSİ</td></tr></table>" +
                "<table cellpadding='5' cellspacing='0' class='ana'><tr><td class='IcOrta' rowspan='2' style='width: 300px'>YABANCI DİL</td>" +
                "<td class='IcOrta' colspan='3' style='width: 220px'>Okuma</td><td class='IcOrta' colspan='3' style='width: 220px'>" +
                "Yazma</td><td class='IcOrta' colspan='3' style='width: 220px'>Konuşma</td></tr><tr><td class='IcOrta' style='width: 65px'>" +
                "ORTA</td><td class='IcOrta' style='width: 65px'>İYİ</td><td class='IcOrta' style='width: 70px'>ÇOK İYİ</td><td class='IcOrta' style='width: 65px'>" +
                "ORTA</td><td class='IcOrta' style='width: 65px'>İYİ</td><td class='IcOrta' style='width: 70px'>ÇOK İYİ</td><td class='IcOrta' style='width: 65px'>" +
                "ORTA</td><td class='IcOrta' style='width: 65px'>İYİ</td><td class='IcOrta' style='width: 70px'>ÇOK İYİ</td></tr>" +
                "<tr><td class='IcOrta'><b>" + dil1 + "</b></td><td class='IcOrta' colspan='3'><b>" + dil1okuma + "</b></td><td class='IcOrta' colspan='3'><b>" + dil1yazma +
                "</b></td><td class='IcOrta' colspan='3'><b>" + dil1konusma + "</b></td></tr>" +
                "<tr><td class='IcOrta'><b>" + dil2 + "</b></td><td class='IcOrta' colspan='3'><b>" + dil2okuma + "</b></td><td class='IcOrta' colspan='3'><b>" + dil2yazma +
                "</b></td><td class='IcOrta' colspan='3'><b>" + dil2konusma + "</b></td></tr>" +
                "<tr><td class='IcOrta'><b>" + dil3 + "</b></td><td class='IcOrta' colspan='3'><b>" + dil3okuma + "</b></td><td class='IcOrta' colspan='3'><b>" + dil3yazma +
                "</b></td><td class='IcOrta' colspan='3'><b>" + dil3konusma + "</b></td></tr></table><br />";

            string tecrubeler = "<table><tr><td style='font-size: 16px; padding-bottom: 5px'>ÇALIŞMA YAŞAMI (İŞ DENEYİMLERİ)</td></tr></table>" +
                "<table cellpadding='5' cellspacing='0' class='ana'><tr><td class='IcOrta' style='width: 190px'>ŞİMDİKİ İŞİNİZ</td><td class='IcOrta' style='width: 186px'>" +
                "GÖREVİNİZ</td><td class='IcOrta' style='width: 126px'>GİRİŞ TARİHİ</td><td class='IcOrta' style='width: 126px'>ÇIKIŞ TARİHİ</td>" +
                "<td class='IcOrta' style='width: 126px'>ÜCRET</td><td class='IcOrta' style='width: 186px'>AYRILMA NEDENİ</td></tr>" +
                "<tr><td class='IcOrta'><b>" + simdikiis + "</b><td class='IcOrta'><b>" + simdikiisgorev + "</b><td class='IcOrta'><b>" + simdikiisgiris +
                "</b><td class='IcOrta'><b>" + simdikiiscikis + "</b><td class='IcOrta'><b>" + simdikiisucret + "</b><td class='IcOrta'><b>" + simdikiisayrilma + "</b></tr>" +
                "<tr><td class='IcOrta'>ÖNCEKİ İŞYERİ</td><td class='IcOrta'>" +
                "GÖREVİNİZ</td><td class='IcOrta'>GİRİŞ TARİHİ</td><td class='IcOrta'>ÇIKIŞ TARİHİ</td>" +
                "<td class='IcOrta'>SON ÜCRET</td><td class='IcOrta'>AYRILMA NEDENİ</td></tr>" +
                "<tr><td class='IcOrta'><b>" + is1 + "</b><td class='IcOrta'><b>" + is1gorev + "</b><td class='IcOrta'><b>" + is1giris +
                "</b><td class='IcOrta'><b>" + is1cikis + "</b><td class='IcOrta'><b>" + is1ucret + "</b><td class='IcOrta'><b>" + is1ayrilma + "</b></tr>" +
                "<tr><td class='IcOrta'><b>" + is2 + "</b><td class='IcOrta'><b>" + is2gorev + "</b><td class='IcOrta'><b>" + is2giris +
                "</b><td class='IcOrta'><b>" + is2cikis + "</b><td class='IcOrta'><b>" + is2ucret + "</b><td class='IcOrta'><b>" + is2ayrilma + "</b></tr>" +
                "<tr><td class='IcOrta'><b>" + is3 + "</b><td class='IcOrta'><b>" + is3gorev + "</b><td class='IcOrta'><b>" + is3giris +
                "</b><td class='IcOrta'><b>" + is3cikis + "</b><td class='IcOrta'><b>" + is3ucret + "</b><td class='IcOrta'><b>" + is3ayrilma + "</b></tr>" +
                "<tr><td class='IcOrta'><b>" + is4 + "</b><td class='IcOrta'><b>" + is4gorev + "</b><td class='IcOrta'><b>" + is4giris +
                "</b><td class='IcOrta'><b>" + is4cikis + "</b><td class='IcOrta'><b>" + is4ucret + "</b><td class='IcOrta'><b>" + is4ayrilma + "</b></tr></table><br />";

            string digerbilgiler1 = "<table><tr><td style='font-size: 16px; padding-bottom: 5px'>DİĞER BİLGİLER - 1</td></tr></table>" +
                "<table cellpadding='5' cellspacing='0' class='ana'><tr><td class='Ic' colspan='4' style='width: 610px'>Herhangi bir nedenle devam eden mahkemeniz var mı? Varsa neden?<br /><b>" +
                mahkeme + "</b></td><td class='Ic' style='width: 140px'>En yakın duruşma tarihi<br /><b>" + durusmatarihi + "</b></td></tr>" +
                "<tr><td class='Ic' colspan='4'>Herhangi bir nedenle devam eden mahkumiyetiniz var mı? Varsa nedeni, süresi.<br /><b>" + mahkumiyet + "</b></td>" +
                "<td class='Ic'>Tahliye Tarihi<br /><b>" + tahliyetarihi + "</b></td></tr><tr><td class='Ic' colspan='5'>Bakmakla yükümlü olduğunuz 1. ve 2. derece yakınlarınız.<br /><b>" + 
                bakmaklayukumlu + "</b></td></tr><tr><td class='Ic' colspan='5'>Sürekli tedaviye muhtaç 1. ve 2. derece yakınlarınız.<br /><b>" + sureklitedavi +
                "</b></td></tr><tr><td class='Ic' colspan='3' style='width: 460px'>Ücret dışı Diğer Gelirleriniz.</td><td class='Ic' colspan='2' rowspan='3' valign='top'>" +
                "Kredi Kartlarından dolayı yasal takibata uğradınız mı? Açıklayınız.<br /><b>" + kredikartitakibat + "</b></td></tr><tr><td class='Ic' style='width: 120px'>" +
                ".</td><td class='IcOrta' style='width: 110px'>Tutar</td><td class='IcOrta' style='width: 200px'>Açıklama</td></tr><tr><td class='Ic'>Kira</td>" +
                "<td class='IcOrta'><b>" + kiratutar + "</b></td><td class='IcOrta'><b>" + kiraciklama + "</b></td></tr><tr><td class='Ic'>Ortaklık</td>" +
                "<td class='IcOrta'><b>" + ortakliktutar + "</b></td><td class='IcOrta'><b>" + ortaklikaciklama + "</b></td>" +
                "<td class='IcOrta' style='width: 140px'>Kredi Kartlarınız</td><td class='IcOrta'>Limiti</td></tr><tr><td class='Ic'>Diğer</td>" +
                "<td class='IcOrta'><b>" + digertutar + "</b></td><td class='IcOrta'><b>" + digeraciklama + "</b></td><td class='IcOrta'><b>" + kredikarti1 + "</b></td><td class='IcOrta'><b>" + kredikarti1limit + "</b></td></tr><tr><td class='Ic'>Eşinizin geliri</td>" +
                "<td class='IcOrta'><b>" + estutar + "</b></td><td class='IcOrta'><b>" + esaciklama + "</b></td><td class='IcOrta'><b>" + kredikarti2 + "</b></td><td class='IcOrta'><b>" + kredikarti2limit + "</b></td></tr></table><br />";

            string digerbilgiler2 = "<table><tr><td style='font-size: 16px; padding-bottom: 5px'>DİĞER BİLGİLER - 2</td></tr></table>" +
                "<table cellpadding='5' cellspacing='0' class='ana'><tr><td class='Ic'>Tedavisi süren herhangi bir hastalığınız var mı?<br /><b>" + tedavisurenhastalik +
                "</b></td></tr><tr><td class='Ic'>Varsa geçirdiğiniz önemli hastalıklar ve / veya tıbbi ameliyatlar.<br /><b>" + onemlihastalikameliyat +
                "</b></td></tr><tr><td class='Ic'>Her hangi bir sakatlığınız var mı? Varsa Oranı?<br /><b>" + sakatlik + "</b></td></tr></table><br />";

            string digerbilgiler3 = "<table><tr><td style='font-size: 16px; padding-bottom: 5px'>DİĞER BİLGİLER - 3</td></tr></table>" +
                "<table cellpadding='5' cellspacing='0' class='ana'><tr><td class='Ic' style='width: 260px'>Oturduğunuz ev size mi ait?<br /><b>" + evsizin + "</b></td>" +
                "<td style='border-color: #000000; width: 460px; border-top-style: solid; border-top-width: 1px;'>Oturduğunuz ev dışında gayri menkulünüz var mı? Varsa adresi, durumu.<br /><b>" +
                baskaev + baskaevadresdurum + "</b></td></tr><tr><td class='Ic'>Otomobiliniz var mı?<br /><b>" + otomobil + "</b></td>" +
                "<td style='border-color: #000000; border-top-style: solid; border-top-width: 1px;'>Varsa; markası, modeli ve durumu<br /><b>" + otomobilmarkamodeldurum +
                "</td></tr><tr><td class='Ic' colspan='2'>Üyesi Olduğunuz Dernek, Klüp ve Kuruluşlar<br /><b>" + uyedernekkulupkurulus + "</b></td></tr><tr>" +
                "<td class='Ic' colspan='2'>Özel Meraklarınız, hobileriniz<br /><b>" + hobi + "</b></td></tr><tr><td class='Ic' colspan='2'>" +
                "Bilgisayar kullanıyorsanız bildiğiniz programlama dillerini ve/veya paket programlarını belirtiniz.<br /><b>" + bilgisayarprogramlari + "</b></td></tr>" +
                "<tr><td class='Ic' colspan='2'>Meslek hayatınızdaki en büyük başarınızı kısaca özetleyiniz.<br /><b>" + meslekibasari + "</b></td></tr></table><br /><br /><br /><br /><br /><br /><br /><br /><br />";

            string digerbilgiler3_2 = "<table cellpadding='5' cellspacing='0' class='ana'><tr><td class='Ic' colspan='3'>Şirketimizde/Şirketler Topluluğumuzda " + 
                "akraba ya da tanıdıklarınız varsa isimleri.<br /><b>" + sirkettanidik + "</b></td></tr><tr><td class='Ic' style='width: 300px'>" +
                "Daha önce şirketimize başvurunuz oldu mu?<br /><b>" + dahaoncebasvuru + "</b></td><td class='Ic' style='width: 140px'>" + 
                "Talep ettiğiniz ücret (net)<br /><b>" + talepucret + "</b></td><td class='Ic' style='width: 270px'>Kabul edildiğiniz taktirde başlayabileceğiniz " + 
                "tarih<br /><b>" + baslanacaktarih + "</b></td></tr><tr><td class='Ic'>Sigara içiyor musunuz?<br /><b>" + sigara + "</b></td>" +
                "<td class='Ic' colspan='2'>İş ve çalışma şartları ile ilgili özel beklentileriniz<br /><b>" + calismasartibeklenti + "</b></td></tr><tr>" +
                "<td class='Ic' colspan='3'>Gerektiğinde vardiyalı olarak çalışabilir misiniz?<br /><b>" + vardiya + "</b></td></tr><tr><td class='Ic' colspan='3'>" +
                "Görev verildiği takdirde şehir dışında görev yapabilir misiniz, kısıtlamalarınız nelerdir?<br /><b>" + sehirdisicalisma + sehirdisicalismakisitlama +
                "</b></td></tr></table><br />";

            string referanslar = "<table><tr><td style='font-size: 16px; padding-bottom: 5px'>REFERANSLAR</td></tr></table>" +
                "<table cellpadding='5' cellspacing='0' class='ana'><tr><td class='IcOrta' style='width: 240px'>ADI SOYADI</td><td class='IcOrta' style='width: 300px'>" +
                "ÇALIŞTIĞI ŞİRKET - GÖREVİ</td><td class='IcOrta' style='width: 170px'>TELEFONU</td></tr><tr><td class='IcOrta'><b>" + referans1ad +
                "</b></td><td class='IcOrta'><b>" + referans1sirketgorev + "</b></td><td class='IcOrta'><b>" + referans1telefon + "</b></td></tr><tr>" +
                "<td class='IcOrta'><b>" + referans2ad + "</b></td><td class='IcOrta'><b>" + referans2sirketgorev + "</b></td><td class='IcOrta'><b>" +
                referans2telefon + "</b></td></tr><tr><td class='IcOrta'><b>" + referans3ad + "</b></td><td class='IcOrta'><b>" + referans3sirketgorev +
                "</b></td><td class='IcOrta'><b>" + referans3telefon + "</b></td></tr></table><br /><br />";

            string son = "<table cellpadding='5' cellspacing='0' class='ana'><tr><td style='border-top-style: solid; border-top-width: 1px; border-top-color: #000000; " +
                "border-left-style: solid; border-left-width: 1px; border-left-color: #000000; height: 80px;' valign='top'>Çalışma hayatınızdaki beklentilerinizi kısaca " +
                "özetleyiniz.<br /><b>" + calismahayatibeklenti + "</b></td></tr></table><br /><br />" +

                "<table cellpadding='5' cellspacing='0' style='width: 730px'><tr><td style='text-align: right'>Başvuru Tarihi: <b>" + basvurutarihi + "</b>" +
                "</td></tr></table>";

            string sonsayfa = "<table cellpadding='10' cellspacing='0'><tr><td><img src='" + programyeri + "sonsayfa.jpg' /></td></tr></table>";


            if (yazdirma == true)
            {
                donendeger = head + baslik + kisiselbilgiler + ailebilgileri + askerlikbilgileri + egitimozgecmisi + kurslar + yabancidiller + tecrubeler + digerbilgiler1 +
                digerbilgiler2 + digerbilgiler3 + digerbilgiler3_2 + referanslar + son + sonsayfa + "</body></html>";
            }
            else
            {
                donendeger = head + kisiselbilgiler + ailebilgileri + askerlikbilgileri + egitimozgecmisi + kurslar + yabancidiller + tecrubeler + digerbilgiler1 +
                digerbilgiler2 + digerbilgiler3 + digerbilgiler3_2 + referanslar + son + "</body></html>";
            }
            

            return donendeger;
        }
    }
}
