<%@ Page Title="" Language="C#" MasterPageFile="~/kenton/Site1.Master" AutoEventWireup="true" CodeBehind="sifre.aspx.cs" Inherits="Sultanlar.WebUI.kenton.sifre" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divana">
    <img src="images/headers/5.png" class="imgheader" />
    <div style="width: 65%; margin: 0 auto;">

    <%--<span class="login100-form-title p-b-15 m-b-15">
		                    <img src="images/kenton.png" alt="Kenton" style="width: 200px" />
	                    </span>--%>
	<div class="wrap-input100 validate-input" data-validate="Geçerli eposta: a@b.c">
		<input class="input100" type="text" name="email" runat="server" id="email" autocomplete="off" clientidmode="Static" />
		<span class="focus-input100" data-placeholder="E-posta"></span>
	</div>
    <div class="container-login100-form-btn1">
		<div class="wrap-login100-form-btn1">
            <asp:Button class="login100-form-btn1" ID="btnGonder" runat="server" Text="GÖNDER" style="background: none; width: 100%; height: 100%; color: white; font-weight: bold" OnClick="btnGonder_Click" />
		</div>
	</div><br /><br />
	<span id="nonhata" runat="server" class="login100-form-title" style="font-size: 14px; color: white"></span>
	<span id="hata" runat="server" class="login100-form-title" style="font-size: 14px; color: white"></span>
    </div>
        </div>
</asp:Content>
