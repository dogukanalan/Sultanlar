using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;
using System.Collections;

namespace Sultanlar.WebUI.musteri
{
    public partial class grafik : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["tur"] == null)
            {
                container.Visible = false;
                divBos.Visible = true;
                return;
            }
            else if (Request.QueryString["tur"] == "yil" && (Request.QueryString["ref"] == null || Request.QueryString["yil"] == null))
            {
                container.Visible = false;
                divBos.Visible = true;
                return;
            }
            else if (Request.QueryString["tur"] == "ay" && (Request.QueryString["ref"] == null || Request.QueryString["yil"] == null || 
                Request.QueryString["ay"] == null))
            {
                container.Visible = false;
                divBos.Visible = true;
                return;
            }
            else if (Request.QueryString["tur"] == "tyil" && Request.QueryString["yil"] == null)
            {
                container.Visible = false;
                divBos.Visible = true;
                return;
            }
            else if (Request.QueryString["tur"] == "tay" && (Request.QueryString["yil"] == null || Request.QueryString["ay"] == null))
            {
                container.Visible = false;
                divBos.Visible = true;
                return;
            }
            else if (Request.QueryString["tur"] == "tsyil" && (Request.QueryString["ref"] == null || Request.QueryString["yil"] == null))
            {
                container.Visible = false;
                divBos.Visible = true;
                return;
            }
            else if (Request.QueryString["tur"] == "tsay" && (Request.QueryString["ref"] == null || Request.QueryString["yil"] == null ||
                Request.QueryString["ay"] == null))
            {
                container.Visible = false;
                divBos.Visible = true;
                return;
            }



            if (Request.QueryString["tur"] == "yil")
            {
                Yil(Convert.ToInt32(Request.QueryString["ref"]), Request.QueryString["kat"].ToString(), Convert.ToInt32(Request.QueryString["yil"]));
            }
            else if (Request.QueryString["tur"] == "ay")
            {
                Ay(Convert.ToInt32(Request.QueryString["ref"]), Request.QueryString["kat"].ToString(), Convert.ToInt32(Request.QueryString["yil"]), Convert.ToInt32(Request.QueryString["ay"]));
            }
            else if (Request.QueryString["tur"] == "tyil")
            {
                YilT(Request.QueryString["kat"].ToString(), Convert.ToInt32(Request.QueryString["yil"]));
            }
            else if (Request.QueryString["tur"] == "tay")
            {
                AyT(Request.QueryString["kat"].ToString(), Convert.ToInt32(Request.QueryString["yil"]), Convert.ToInt32(Request.QueryString["ay"]));
            }
            else if (Request.QueryString["tur"] == "tsyil")
            {
                YilTs(Convert.ToInt32(Request.QueryString["ref"]), Request.QueryString["kat"].ToString(), Convert.ToInt32(Request.QueryString["yil"]));
            }
            else if (Request.QueryString["tur"] == "tsay")
            {
                AyTs(Convert.ToInt32(Request.QueryString["ref"]), Request.QueryString["kat"].ToString(), Convert.ToInt32(Request.QueryString["yil"]), Convert.ToInt32(Request.QueryString["ay"]));
            }
        }

        private void Yil(int SLSREF, string Kategori, int Yil)
        {
            SatisHedefYil sathedyil = new SatisHedefYil(SLSREF, Kategori, Yil);

            string baslik = sathedyil._Isim;
            string kaynak = Yil.ToString();
            string soltaraf = "Tutar (TL)";

            ScriptManager.RegisterStartupScript(container, typeof(string), "grafik", "<script type='text/javascript'>" +
                "$(function () {var chart;$(document).ready(function () {chart = new Highcharts.Chart({chart: {renderTo: 'container',type: 'area'},title: {text: '" +
                baslik + "'},subtitle: {text: '" +
                kaynak + "'},xAxis: {labels: {formatter: function () {return this.value;}}},yAxis: {title: {text: '" +
                soltaraf + "'},labels: {formatter: function () {return this.value;}}},tooltip: {formatter: function () {" +
                "return this.series.name + '<br/>' + this.x + '. ay: <b>' + Highcharts.numberFormat(this.y, 0) + ' TL</b>';}}" + 
                ",plotOptions: {area: {pointStart: 1,marker: {enabled: false,symbol: 'circle',radius: 2,states: {hover: {enabled: true}}}}}" +
                ",series: [" +

                "{name: 'Hedef'," +
                "data: [" +
                sathedyil._HAy1 + ", " +
                sathedyil._HAy2 + ", " +
                sathedyil._HAy3 + ", " +
                sathedyil._HAy4 + ", " +
                sathedyil._HAy5 + ", " +
                sathedyil._HAy6 + ", " +
                sathedyil._HAy7 + ", " +
                sathedyil._HAy8 + ", " +
                sathedyil._HAy9 + ", " +
                sathedyil._HAy10 + ", " +
                sathedyil._HAy11 + ", " +
                sathedyil._HAy12 +
                "]}" +

                ",{name: 'Satış'," +
                "data: [" +
                sathedyil._NAy1 + ", " +
                sathedyil._NAy2 + ", " +
                sathedyil._NAy3 + ", " +
                sathedyil._NAy4 + ", " +
                sathedyil._NAy5 + ", " +
                sathedyil._NAy6 + ", " +
                sathedyil._NAy7 + ", " +
                sathedyil._NAy8 + ", " +
                sathedyil._NAy9 + ", " +
                sathedyil._NAy10 + ", " +
                sathedyil._NAy11 + ", " +
                sathedyil._NAy12 +
                "]}" +

                "]" +
                "});});});"
                + "</script>", false);
        }

        private void Ay(int SLSREF, string Kategori, int Yil, int Ay)
        {
            SatisHedefAy satheday = new SatisHedefAy(SLSREF, Kategori, Yil, Ay);

            string baslik = satheday._Isim;
            string kaynak = Yil.ToString() + " / " + Ay.ToString();
            string soltaraf = "Tutar (TL)";

            ScriptManager.RegisterStartupScript(container, typeof(string), "grafik", "<script type='text/javascript'>" +
                "$(function () {var chart;$(document).ready(function () {chart = new Highcharts.Chart({chart: {renderTo: 'container',type: 'areaspline'},title: {text: '" +
                baslik + "'},subtitle: {text: '" +
                kaynak + "'},xAxis: {labels: {formatter: function () {return this.value;}}},yAxis: {title: {text: '" +
                soltaraf + "'},labels: {formatter: function () {return this.value;}}},tooltip: {formatter: function () {" +
                "return this.series.name + '<br/>' + this.x + '. gün: <b>' + Highcharts.numberFormat(this.y, 0) + ' TL</b>';}}" +
                ",plotOptions: {areaspline: {fillOpacity: 0.5 }}" +
                ",series: [" +

                "{name: 'Hedef'," +
                "data: [0, " +
                satheday._HGun1 + ", " +
                satheday._HGun2 + ", " +
                satheday._HGun3 + ", " +
                satheday._HGun4 + ", " +
                satheday._HGun5 + ", " +
                satheday._HGun6 + ", " +
                satheday._HGun7 + ", " +
                satheday._HGun8 + ", " +
                satheday._HGun9 + ", " +
                satheday._HGun10 + ", " +
                satheday._HGun11 + ", " +
                satheday._HGun12 + ", " +
                satheday._HGun13 + ", " +
                satheday._HGun14 + ", " +
                satheday._HGun15 + ", " +
                satheday._HGun16 + ", " +
                satheday._HGun17 + ", " +
                satheday._HGun18 + ", " +
                satheday._HGun19 + ", " +
                satheday._HGun20 + ", " +
                satheday._HGun21 + ", " +
                satheday._HGun22 + ", " +
                satheday._HGun23 + ", " +
                satheday._HGun24 + ", " +
                satheday._HGun25 + ", " +
                satheday._HGun26 + ", " +
                satheday._HGun27 + ", " +
                satheday._HGun28 + ", " +
                satheday._HGun29 + ", " +
                satheday._HGun30 + ", " +
                satheday._HGun31 + 
                "]}" +

                ",{name: 'Satış'," +
                "data: [0, " +
                satheday._NGun1 + ", " +
                satheday._NGun2 + ", " +
                satheday._NGun3 + ", " +
                satheday._NGun4 + ", " +
                satheday._NGun5 + ", " +
                satheday._NGun6 + ", " +
                satheday._NGun7 + ", " +
                satheday._NGun8 + ", " +
                satheday._NGun9 + ", " +
                satheday._NGun10 + ", " +
                satheday._NGun11 + ", " +
                satheday._NGun12 + ", " +
                satheday._NGun13 + ", " +
                satheday._NGun14 + ", " +
                satheday._NGun15 + ", " +
                satheday._NGun16 + ", " +
                satheday._NGun17 + ", " +
                satheday._NGun18 + ", " +
                satheday._NGun19 + ", " +
                satheday._NGun20 + ", " +
                satheday._NGun21 + ", " +
                satheday._NGun22 + ", " +
                satheday._NGun23 + ", " +
                satheday._NGun24 + ", " +
                satheday._NGun25 + ", " +
                satheday._NGun26 + ", " +
                satheday._NGun27 + ", " +
                satheday._NGun28 + ", " +
                satheday._NGun29 + ", " +
                satheday._NGun30 + ", " +
                satheday._NGun31 +
                "]}" +

                "]" +
                "});});});"
                + "</script>", false);
        }

        private void YilT(string Kategori, int Yil)
        {
            SatisHedefYilT sathedyil = new SatisHedefYilT(Kategori, Yil);

            string baslik = sathedyil._Isim;
            string kaynak = Yil.ToString();
            string soltaraf = "Tutar (TL)";

            ScriptManager.RegisterStartupScript(container, typeof(string), "grafik", "<script type='text/javascript'>" +
                "$(function () {var chart;$(document).ready(function () {chart = new Highcharts.Chart({chart: {renderTo: 'container',type: 'area'},title: {text: '" +
                baslik + "'},subtitle: {text: '" +
                kaynak + "'},xAxis: {labels: {formatter: function () {return this.value;}}},yAxis: {title: {text: '" +
                soltaraf + "'},labels: {formatter: function () {return this.value;}}},tooltip: {formatter: function () {" +
                "return this.series.name + '<br/>' + this.x + '. ay: <b>' + Highcharts.numberFormat(this.y, 0) + ' TL</b>';}}" + 
                ",plotOptions: {area: {pointStart: 1,marker: {enabled: false,symbol: 'circle',radius: 2,states: {hover: {enabled: true}}}}}" +
                ",series: [" +

                "{name: 'Hedef'," +
                "data: [" +
                sathedyil._HAy1 + ", " +
                sathedyil._HAy2 + ", " +
                sathedyil._HAy3 + ", " +
                sathedyil._HAy4 + ", " +
                sathedyil._HAy5 + ", " +
                sathedyil._HAy6 + ", " +
                sathedyil._HAy7 + ", " +
                sathedyil._HAy8 + ", " +
                sathedyil._HAy9 + ", " +
                sathedyil._HAy10 + ", " +
                sathedyil._HAy11 + ", " +
                sathedyil._HAy12 +
                "]}" +

                ",{name: 'Satış'," +
                "data: [" +
                sathedyil._NAy1 + ", " +
                sathedyil._NAy2 + ", " +
                sathedyil._NAy3 + ", " +
                sathedyil._NAy4 + ", " +
                sathedyil._NAy5 + ", " +
                sathedyil._NAy6 + ", " +
                sathedyil._NAy7 + ", " +
                sathedyil._NAy8 + ", " +
                sathedyil._NAy9 + ", " +
                sathedyil._NAy10 + ", " +
                sathedyil._NAy11 + ", " +
                sathedyil._NAy12 +
                "]}" +

                "]" +
                "});});});"
                + "</script>", false);
        }

        private void AyT(string Kategori, int Yil, int Ay)
        {
            SatisHedefAyT satheday = new SatisHedefAyT(Kategori, Yil, Ay);

            string baslik = satheday._Isim;
            string kaynak = Yil.ToString() + " / " + Ay.ToString();
            string soltaraf = "Tutar (TL)";

            ScriptManager.RegisterStartupScript(container, typeof(string), "grafik", "<script type='text/javascript'>" +
                "$(function () {var chart;$(document).ready(function () {chart = new Highcharts.Chart({chart: {renderTo: 'container',type: 'areaspline'},title: {text: '" +
                baslik + "'},subtitle: {text: '" +
                kaynak + "'},xAxis: {labels: {formatter: function () {return this.value;}}},yAxis: {title: {text: '" +
                soltaraf + "'},labels: {formatter: function () {return this.value;}}},tooltip: {formatter: function () {" +
                "return this.series.name + '<br/>' + this.x + '. gün: <b>' + Highcharts.numberFormat(this.y, 0) + ' TL</b>';}}" +
                ",plotOptions: {areaspline: {fillOpacity: 0.5 }}" +
                ",series: [" +

                "{name: 'Hedef'," +
                "data: [0, " +
                satheday._HGun1 + ", " +
                satheday._HGun2 + ", " +
                satheday._HGun3 + ", " +
                satheday._HGun4 + ", " +
                satheday._HGun5 + ", " +
                satheday._HGun6 + ", " +
                satheday._HGun7 + ", " +
                satheday._HGun8 + ", " +
                satheday._HGun9 + ", " +
                satheday._HGun10 + ", " +
                satheday._HGun11 + ", " +
                satheday._HGun12 + ", " +
                satheday._HGun13 + ", " +
                satheday._HGun14 + ", " +
                satheday._HGun15 + ", " +
                satheday._HGun16 + ", " +
                satheday._HGun17 + ", " +
                satheday._HGun18 + ", " +
                satheday._HGun19 + ", " +
                satheday._HGun20 + ", " +
                satheday._HGun21 + ", " +
                satheday._HGun22 + ", " +
                satheday._HGun23 + ", " +
                satheday._HGun24 + ", " +
                satheday._HGun25 + ", " +
                satheday._HGun26 + ", " +
                satheday._HGun27 + ", " +
                satheday._HGun28 + ", " +
                satheday._HGun29 + ", " +
                satheday._HGun30 + ", " +
                satheday._HGun31 +
                "]}" +

                ",{name: 'Satış'," +
                "data: [0, " +
                satheday._NGun1 + ", " +
                satheday._NGun2 + ", " +
                satheday._NGun3 + ", " +
                satheday._NGun4 + ", " +
                satheday._NGun5 + ", " +
                satheday._NGun6 + ", " +
                satheday._NGun7 + ", " +
                satheday._NGun8 + ", " +
                satheday._NGun9 + ", " +
                satheday._NGun10 + ", " +
                satheday._NGun11 + ", " +
                satheday._NGun12 + ", " +
                satheday._NGun13 + ", " +
                satheday._NGun14 + ", " +
                satheday._NGun15 + ", " +
                satheday._NGun16 + ", " +
                satheday._NGun17 + ", " +
                satheday._NGun18 + ", " +
                satheday._NGun19 + ", " +
                satheday._NGun20 + ", " +
                satheday._NGun21 + ", " +
                satheday._NGun22 + ", " +
                satheday._NGun23 + ", " +
                satheday._NGun24 + ", " +
                satheday._NGun25 + ", " +
                satheday._NGun26 + ", " +
                satheday._NGun27 + ", " +
                satheday._NGun28 + ", " +
                satheday._NGun29 + ", " +
                satheday._NGun30 + ", " +
                satheday._NGun31 +
                "]}" +

                "]" +
                "});});});"
                + "</script>", false);
        }

        private void YilTs(int SLSREF, string Kategori, int Yil)
        {
            ArrayList SLSREFs = SatisTemsilcileriSefler.GetAltRefler(SLSREF);

            SatisHedefYilTs sathedyil = new SatisHedefYilTs(SLSREFs, Kategori, Yil);

            string baslik = sathedyil._Isim;
            string kaynak = Yil.ToString();
            string soltaraf = "Tutar (TL)";

            ScriptManager.RegisterStartupScript(container, typeof(string), "grafik", "<script type='text/javascript'>" +
                "$(function () {var chart;$(document).ready(function () {chart = new Highcharts.Chart({chart: {renderTo: 'container',type: 'area'},title: {text: '" +
                baslik + "'},subtitle: {text: '" +
                kaynak + "'},xAxis: {labels: {formatter: function () {return this.value;}}},yAxis: {title: {text: '" +
                soltaraf + "'},labels: {formatter: function () {return this.value;}}},tooltip: {formatter: function () {" +
                "return this.series.name + '<br/>' + this.x + '. ay: <b>' + Highcharts.numberFormat(this.y, 0) + ' TL</b>';}}" + 
                ",plotOptions: {area: {pointStart: 1,marker: {enabled: false,symbol: 'circle',radius: 2,states: {hover: {enabled: true}}}}}" +
                ",series: [" +

                "{name: 'Hedef'," +
                "data: [" +
                sathedyil._HAy1 + ", " +
                sathedyil._HAy2 + ", " +
                sathedyil._HAy3 + ", " +
                sathedyil._HAy4 + ", " +
                sathedyil._HAy5 + ", " +
                sathedyil._HAy6 + ", " +
                sathedyil._HAy7 + ", " +
                sathedyil._HAy8 + ", " +
                sathedyil._HAy9 + ", " +
                sathedyil._HAy10 + ", " +
                sathedyil._HAy11 + ", " +
                sathedyil._HAy12 +
                "]}" +

                ",{name: 'Satış'," +
                "data: [" +
                sathedyil._NAy1 + ", " +
                sathedyil._NAy2 + ", " +
                sathedyil._NAy3 + ", " +
                sathedyil._NAy4 + ", " +
                sathedyil._NAy5 + ", " +
                sathedyil._NAy6 + ", " +
                sathedyil._NAy7 + ", " +
                sathedyil._NAy8 + ", " +
                sathedyil._NAy9 + ", " +
                sathedyil._NAy10 + ", " +
                sathedyil._NAy11 + ", " +
                sathedyil._NAy12 +
                "]}" +

                "]" +
                "});});});"
                + "</script>", false);
        }

        private void AyTs(int SLSREF, string Kategori, int Yil, int Ay)
        {
            ArrayList SLSREFs = SatisTemsilcileriSefler.GetAltRefler(SLSREF);

            SatisHedefAyTs satheday = new SatisHedefAyTs(SLSREFs, Kategori, Yil, Ay);

            string baslik = satheday._Isim;
            string kaynak = Yil.ToString() + " / " + Ay.ToString();
            string soltaraf = "Tutar (TL)";

            ScriptManager.RegisterStartupScript(container, typeof(string), "grafik", "<script type='text/javascript'>" +
                "$(function () {var chart;$(document).ready(function () {chart = new Highcharts.Chart({chart: {renderTo: 'container',type: 'areaspline'},title: {text: '" +
                baslik + "'},subtitle: {text: '" +
                kaynak + "'},xAxis: {labels: {formatter: function () {return this.value;}}},yAxis: {title: {text: '" +
                soltaraf + "'},labels: {formatter: function () {return this.value;}}},tooltip: {formatter: function () {" +
                "return this.series.name + '<br/>' + this.x + '. gün: <b>' + Highcharts.numberFormat(this.y, 0) + ' TL</b>';}}" +
                ",plotOptions: {areaspline: {fillOpacity: 0.5 }}" +
                ",series: [" +

                "{name: 'Hedef'," +
                "data: [0, " +
                satheday._HGun1 + ", " +
                satheday._HGun2 + ", " +
                satheday._HGun3 + ", " +
                satheday._HGun4 + ", " +
                satheday._HGun5 + ", " +
                satheday._HGun6 + ", " +
                satheday._HGun7 + ", " +
                satheday._HGun8 + ", " +
                satheday._HGun9 + ", " +
                satheday._HGun10 + ", " +
                satheday._HGun11 + ", " +
                satheday._HGun12 + ", " +
                satheday._HGun13 + ", " +
                satheday._HGun14 + ", " +
                satheday._HGun15 + ", " +
                satheday._HGun16 + ", " +
                satheday._HGun17 + ", " +
                satheday._HGun18 + ", " +
                satheday._HGun19 + ", " +
                satheday._HGun20 + ", " +
                satheday._HGun21 + ", " +
                satheday._HGun22 + ", " +
                satheday._HGun23 + ", " +
                satheday._HGun24 + ", " +
                satheday._HGun25 + ", " +
                satheday._HGun26 + ", " +
                satheday._HGun27 + ", " +
                satheday._HGun28 + ", " +
                satheday._HGun29 + ", " +
                satheday._HGun30 + ", " +
                satheday._HGun31 +
                "]}" +

                ",{name: 'Satış'," +
                "data: [0, " +
                satheday._NGun1 + ", " +
                satheday._NGun2 + ", " +
                satheday._NGun3 + ", " +
                satheday._NGun4 + ", " +
                satheday._NGun5 + ", " +
                satheday._NGun6 + ", " +
                satheday._NGun7 + ", " +
                satheday._NGun8 + ", " +
                satheday._NGun9 + ", " +
                satheday._NGun10 + ", " +
                satheday._NGun11 + ", " +
                satheday._NGun12 + ", " +
                satheday._NGun13 + ", " +
                satheday._NGun14 + ", " +
                satheday._NGun15 + ", " +
                satheday._NGun16 + ", " +
                satheday._NGun17 + ", " +
                satheday._NGun18 + ", " +
                satheday._NGun19 + ", " +
                satheday._NGun20 + ", " +
                satheday._NGun21 + ", " +
                satheday._NGun22 + ", " +
                satheday._NGun23 + ", " +
                satheday._NGun24 + ", " +
                satheday._NGun25 + ", " +
                satheday._NGun26 + ", " +
                satheday._NGun27 + ", " +
                satheday._NGun28 + ", " +
                satheday._NGun29 + ", " +
                satheday._NGun30 + ", " +
                satheday._NGun31 +
                "]}" +

                "]" +
                "});});});"
                + "</script>", false);
        }
    }
}