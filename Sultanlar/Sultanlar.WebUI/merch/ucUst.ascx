<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucUst.ascx.cs" Inherits="Sultanlar.WebUI.merch.ucUst" %>
<img src="../musteri/img/logo.png" style="max-width: 100%" alt="logo" />
<br />
<table style="width: 100%; font-size: 14px; padding-top: 10px; padding-bottom: 5px">
    <tr>
        <td style="width: 70%; text-align: left; font-weight: bold">
            <asp:Label ID="txtUye" runat="server" Style="color: #7F0000"></asp:Label>
        </td>
        <td style="width: 28%; text-align: right; font-weight: bold">
            <asp:Image ID="Image1" runat="server" ImageUrl="../musteri/img/yeni.png" ToolTip="Okunmamış mesajınız var." />
        </td>
    </tr>
</table>
<script>
    $(document).ready(function () {
        try {
            if (surum != Android.GetSurum()) {
                AndroidToast("Uygulama sürümünüz güncel değil. Lütfen Google Play Store'dan güncelleyiniz.");
            }
        } catch (e) {

        }
    });
</script>
