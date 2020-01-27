<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kartiade1.aspx.cs" Inherits="Sultanlar.WebUI.musteri.kartiade1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function clickButton(e, buttonid) {
            var evt = e ? e : window.event;
            var bt = document.getElementById(buttonid);
            if (bt) {
                if (evt.keyCode == 13) {
                    bt.click();
                    return false;
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family: Verdana; font-size: 11px; vertical-align: middle; width: 100%; text-align: center">
        
        Şifre:
        &nbsp;
        <asp:TextBox ID="TextBox1" runat="server" Width="212px" Height="22px" TextMode="Password" 
            ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" BorderWidth="1px" 
            onkeydown="return clickButton(event,'Button1')" Enabled="false"></asp:TextBox>
        &nbsp;
        <asp:Button ID="Button1" runat="server" Text="Giriş" Width="54px" Height="22px" BorderColor="#CCCCCC" 
            BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" Font-Bold="true" 
            onclick="Button1_Click" />
        
    </div>
    </form>
</body>
</html>
