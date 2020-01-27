<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucProgress.ascx.cs" Inherits="Sultanlar.WebUI.musteri.ucProgress" %>
<div style="padding-top: 300px; filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40;
    background-color: #000000; position: fixed; width: 100%; height: 100%; z-index: 9;
    left: 0; top: 0;">
</div>
<div style="padding-top: 75px; position: fixed; width: 100%; height: 100%; z-index: 10;
    left: 0; top: 0;">
    <table style="width: 300px; height: 300px; margin-left: 350px; background-color: #ffffff; border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
        <tr>
            <td style="text-align: center; border-bottom: 1px dotted #CCCCCC; height: 50px; font-size: 18px; font-family: Gisha">
                Yükleniyor
            </td>
        </tr>
        <tr>
            <td style="text-align: center; height: 100%">
                <br />
                <img alt="" src="img/yukleniyor.gif" /><br />
                <br />
                <span style="font-family: Tahoma; font-size: 16px; color: #C5670B">lütfen bekleyin...</span><br />
                <br />
            </td>
        </tr>
    </table>
</div>