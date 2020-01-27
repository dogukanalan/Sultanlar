<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="grafik.aspx.cs" Inherits="Sultanlar.WebUI.musteri.grafik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sultanlar Pazarlama : Grafik</title>

	<script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/highcharts.js"></script>
    <script type="text/javascript" src="js/exporting.js"></script>

</head>
<body style="margin: 0 0 0 0">
    <form id="form1" runat="server">
        <script type="text/javascript" src="js/charttheme.js"></script>
        <div runat="server" id="container" style="width: 900px; height: 400px; margin: 0 auto;"></div>
        <div runat="server" id="divBos" style="width: 900px; height: 400px; margin: 0 auto;" visible="false">
            <span style="font-family: Tahoma; font-size: 10px; font-style: italic">Gösterilecek veri bulunamadı.<br /><br />
            Not: Grafik gösterimi yalnızca yıllık ve aylık gösterilebilir.</span>
        </div>
    </form>
</body>
</html>
