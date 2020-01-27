<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="eskodlar.aspx.cs" Inherits="Sultanlar.WebUI.musteri.eskodlar" %>

<div style="font-family: Verdana">
    <%--<img src='resim.aspx?uidK=<%=Request.QueryString["id"]%>' alt="" />--%>
    <div>
        <h1>Eş ürünler:</h1>
        <p>
            <iframe src='eskodurunler.aspx?id=<%=Request.QueryString["id"]%>' height="300" width="500" frameborder="0" scrolling="no"></iframe>
        </p>
    </div>
</div>