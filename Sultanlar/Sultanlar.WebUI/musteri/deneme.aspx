<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deneme.aspx.cs" Inherits="Sultanlar.WebUI.musteri.deneme" %>

<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        input[type=button]:hover {
            background: #ffffff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    denemedir
        <dx:ASPxGridView ID="ASPxGridView1" runat="server">
            <SettingsText HeaderFilterSelectAll="Hepsini Seç" 
                HeaderFilterShowAll="Hepsini Göster" HeaderFilterShowBlanks="Boşları Göster" 
                HeaderFilterShowNonBlanks="Boş Olmayanları Göster" />
        </dx:ASPxGridView>
    <input type="button" id="flHide" value="Filtrele" onclick="AcKapa()" />
    </div>
    </form>
</body>
</html>
