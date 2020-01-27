<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="giris.aspx.cs" Inherits="Sultanlar.WebUI.merch.giris" %>

<%@ Register src="ucProgress.ascx" tagname="ucProgress" tagprefix="uc1" %>
<%@ Register src="ucUst.ascx" tagname="ucUst" tagprefix="uc2" %>
<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="cache-control" content="no-cache" />
    <meta name="viewport" content="width=device-width,initial-scale=1">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="StyleSheet.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/jquery-validation@1.17.0/dist/jquery.validate.js"></script>
    <script type="text/javascript" src="JScript.js"></script>
</head>
<body>
    <form id="form1" runat="server" class="login-form">
        <div class="login-page">
          <div class="form" style="padding: 45px;">
              <uc2:ucUst ID="ucUst" runat="server" />
              <input runat="server" id="inputEposta" type="text" autocomplete="off" placeholder="eposta"/>
              <input runat="server" id="inputSifre" type="password" autocomplete="off" placeholder="şifre"/>
              <asp:Button runat="server" text="GİRİŞ" ID="btnGiris" 
                  onclick="btnGiris_Click" />
              <p class="message" runat="server" id="pP"></p>
              <uc3:ucAlt ID="ucAlt1" runat="server" />
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
