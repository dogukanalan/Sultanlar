<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="indir.aspx.cs" Inherits="Sultanlar.WebUI.musteri.indir" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function startWin() {
            if (navigator.appName == "Microsoft Internet Explorer") {
//                var param = "toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,width=800,height=150,noresize";
//                window.open("download.aspx", "_blank", param);
            }
            else {
//                yenipencere = window.open("download.aspx", "İndirme", "toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,width=800,height=150,noresize");
//                yenipencere.moveTo(0, 0);
            }
            window.location.href = 'download.aspx';
            document.getElementById('imgExcel').style.display = 'none';
        }
    </script>
</head>
<body style="background-color: #FFFFFF">
    <form id="form1" runat="server">
    <div style="width: 100%">
        <center>
            
            <%--<asp:Label ID="Label" runat="server" Text="indirmek için tıklayınız"></asp:Label>--%>
            
        </center>

        <div style="font-family: Verdana; width: 100%; height: 100%">
    
        <asp:Label ID="Label1" runat="server" Font-Size="11px" 
            
            Text="İndireceğiniz formatı seçiniz:"></asp:Label>

        <asp:Label ID="Label2" runat="server" Font-Size="11px" 
            
            Text="Bir hata oluştu. Lütfen bu pencereyi kapatıp yeniden indirmeyi başlatın." 
            Visible="False"></asp:Label>
    
        <br />
        <br />
        <a href='javascript:startWin()'><img src="img/excel_icon.png" alt="" border="0" id="imgExcel" /></a>
    
        </div>
    </div>
    
    </form>
</body>
</html>
