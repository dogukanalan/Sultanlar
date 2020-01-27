<%@ Page Title="" Language="C#" MasterPageFile="~/kenton/Site1.Master" AutoEventWireup="true" CodeBehind="kategoriler.aspx.cs" Inherits="Sultanlar.WebUI.kenton.kategoriler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater runat="server" ID="repe">
        <ItemTemplate>
            <div style='float: left; width: 50%; height: 150px; display: table; overflow: hidden; text-align: center; background-position: center; background-size: cover; background-image:url(images/tarkat/<%#Eval("pkID") %>.jpg)' onclick="window.location.href='tarifler.aspx?kat=<%#Eval("pkID") %>'"><div style="display: table-cell; vertical-align: middle;"><div style="padding: 10px"><span style="color: #fafafa; font-size: 18px; text-shadow: 1px 1px 4px #000;"><%#Eval("strKategori") %></span></div></div></div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
