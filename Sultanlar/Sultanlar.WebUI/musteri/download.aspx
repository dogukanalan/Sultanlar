<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="download.aspx.cs" Inherits="Sultanlar.WebUI.musteri.download" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 32px;
            height: 32px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family: Verdana; width: 100%; height: 100%; text-align: center; vertical-align: middle">
    
<%--        <asp:Label ID="Label2" runat="server" Font-Size="11px" 
            
            Text="İndireceğiniz formatı seçiniz:"></asp:Label>--%>

            <img alt="yükleniyor" class="style1" src="img/yukleniyor.gif" /><br /><br />

        <asp:Label ID="Label1" runat="server" Font-Size="11px" 
            
            Text="Bir hata oluştu. Lütfen bu pencereyi kapatıp yeniden indirmeyi başlatın." 
            Visible="False"></asp:Label>
    
<%--        <br />
        <br />
        <asp:ImageButton ID="ImageButton1" runat="server" style="padding-left: 10px"
            ImageUrl="~/musteri/img/excel_icon.png" onclick="ImageButton1_Click" />--%>
    
    </div>
    
    </form>
</body>
</html>
