<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ilkyuz.aspx.cs" Inherits="Sultanlar.WCF.ilkyuz" %>

<%@ Register src="ucProgress.ascx" tagname="ucProgress" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="cache-control" content="no-cache" />
    <title></title>
    <link rel="Stylesheet" type="text/css" href="StyleSheet.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/jquery-validation@1.17.0/dist/jquery.validate.js"></script>
    <script type="text/javascript" src="JScript.js"></script>
</head>
<body>
    <form id="form1" runat="server" class="login-form">
        <div class="login-page">
          <div class="form">
              <input runat="server" id="inputEposta" type="text" placeholder="eposta"/>
              <input runat="server" id="inputSifre" type="password" placeholder="şifre"/>
              <asp:Button runat="server" text="GİRİŞ" ID="btnGiris" 
                  onclick="btnGiris_Click" />
              <p class="message" runat="server" id="pP"></p>
          </div>
        </div>
        <uc1:ucProgress ID="ucProgress1" runat="server" />
        <script type="text/javascript">
            $(function () {
                $("form").validate({
                    rules: {
                        inputEposta: {
                            required: true,
                            email: true
                        },
                        inputSifre: {
                            required: true
                        }
                    },
                    messages: {
                        inputEposta: "<span style='font-size: 16px; color: Red'>Eposta düzgün formatta değil.<span><br><br>",
                        inputSifre: "<span style='font-size: 16px; color: Red'>Şifre boş bırakılamaz.<span><br><br>"
                    },
                    submitHandler: function () {
                        Goster();
                        form.submit();
                    }
                });
            });
        </script>
    </form>
</body>
</html>
