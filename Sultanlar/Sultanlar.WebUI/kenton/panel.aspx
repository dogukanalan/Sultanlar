<%@ Page Title="" Language="C#" MasterPageFile="~/kenton/Site1.Master" AutoEventWireup="true"
    CodeBehind="panel.aspx.cs" Inherits="Sultanlar.WebUI.kenton.panel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divana">
    <div style="display: block; padding: 0 35px;">
    <img src="images/headers/5.png" class="imgheader" />
        <p style="font-size: 14px; color: white; text-align: center">Hoşgeldiniz, <span style="font-size: 14px" runat="server"
            id="spanKullanici">(Kullanıcı)</span>...</p></div>
    <%--<div class="container-login100-form-btn1" onclick="window.location.href = 'tarifler.aspx?a=benim'">
        <div class="wrap-login100-form-btn1">
            <div class="login100-form-bgbtn1">
            </div>
            <a class='login100-form-btn1' href='#'>BENİM TARİFLERİM</a></div>
    </div>
    <br />
    <div class="container-login100-form-btn1" onclick="window.location.href = 'tarifler.aspx?a=fav'">
        <div class="wrap-login100-form-btn1">
            <div class="login100-form-bgbtn1">
            </div>
            <a class='login100-form-btn1' href='#'>FAVORİ TARİFLERİM</a></div>
    </div>
    <br />
    <div class="container-login100-form-btn1" onclick="window.location.href = 'yorumlar.aspx?a=benim'">
        <div class="wrap-login100-form-btn1">
            <div class="login100-form-bgbtn1">
            </div>
            <a class='login100-form-btn1' href='#'>YORUMLARIM</a></div>
    </div>
    <br />
    <div class="container-login100-form-btn1" onclick="window.location.href = 'uyelik.aspx'">
        <div class="wrap-login100-form-btn1">
            <div class="login100-form-bgbtn1">
            </div>
            <a class='login100-form-btn1' href='#'>ÜYELİK BİLGİLERİM</a></div>
    </div>--%>

        <div style="height:auto; float: left">
        <div style='float: left; width: 50%; height: 150px; display: table; overflow: hidden; text-align: center; background-position: center; background-size: cover; background-image:url(images/box/1.jpg)' onclick="window.location.href='tarifler.aspx?a=benim'"><div style="display: table-cell; vertical-align: middle;"><div style="padding: 10px"><span style="color: #fafafa; font-size: 18px; text-shadow: 1px 1px 4px #000;">BENİM TARİFLERİM</span></div></div></div>
        <div style='float: left; width: 50%; height: 150px; display: table; overflow: hidden; text-align: center; background-position: center; background-size: cover; background-image:url(images/box/3.jpg)' onclick="window.location.href='tarifler.aspx?a=fav'"><div style="display: table-cell; vertical-align: middle;"><div style="padding: 10px"><span style="color: #fafafa; font-size: 18px; text-shadow: 1px 1px 4px #000;">FAVORİ TARİFLERİM</span></div></div></div>
        <div style='float: left; width: 50%; height: 150px; display: table; overflow: hidden; text-align: center; background-position: center; background-size: cover; background-image:url(images/box/4.jpg)' onclick="window.location.href='yorumlar.aspx?a=benim'"><div style="display: table-cell; vertical-align: middle;"><div style="padding: 10px"><span style="color: #fafafa; font-size: 18px; text-shadow: 1px 1px 4px #000;">YORUMLARIM</span></div></div></div>
        <div style='float: left; width: 50%; height: 150px; display: table; overflow: hidden; text-align: center; background-position: center; background-size: cover; background-image:url(images/box/5.jpg)' onclick="window.location.href='uyelik.aspx'"><div style="display: table-cell; vertical-align: middle;"><div style="padding: 10px"><span style="color: #fafafa; font-size: 18px; text-shadow: 1px 1px 4px #000;">ÜYELİK BİLGİLERİM</span></div></div></div>
        </div>

        
    <div class="container-login100-form-btn1" onclick="window.location.href = 'exit.aspx'" style="height: 40px; float: left; width: 100%">
        <div class="wrap-login100-form-btn1">
            <div class="login100-form-bgbtn1">
            </div>
            <a class='login100-form-btn1' href='#'>ÇIKIŞ</a></div>
    </div>
        <br /><br />

    </div>
</asp:Content>
