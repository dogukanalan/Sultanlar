<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mesajlar.aspx.cs" Inherits="Sultanlar.WebUI.merch.mesajlar" %>

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
    <script type="text/javascript" src="JScript.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-page">
            <div class="form">
                <uc2:ucUst ID="ucUst" runat="server" />
                <asp:RadioButtonList ID="RadioButtonList1" RepeatColumns="3" RepeatLayout="Table" RepeatDirection="Horizontal" runat="server" 
                    OnSelectedIndexChanged="RadioButtonList1_CheckedChanged" AutoPostBack="true" CssClass="radiobuttonlist"></asp:RadioButtonList>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Size="12px"
                    onpageindexchanging="GridView1_PageIndexChanging" PageSize="50">
                    <Columns>
                        <asp:TemplateField>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl="../musteri/img/yeni.png" Visible='<%# !Convert.ToBoolean(Eval("blOkundu")) %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Departman">
                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("strDepartman") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Konu" ShowHeader="False">
                            <ItemStyle HorizontalAlign="Left" Width="40%" CssClass="iobox" />
                            <ItemTemplate>
                                <a href='mesaj.aspx?a=goster&id=<%# Eval("pkMesajID") %>' class="button"><%# String.Format("{0}",Eval("strKonu")) %></a>
                            </ItemTemplate>
                            <ControlStyle CssClass="iobox" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tarih">
                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("dtGondermeZamani") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <a href='mesaj.aspx?a=sil&id=<%# Eval("pkMesajID") %>' class="button">Sil</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" CssClass="box" />
                    <AlternatingRowStyle BackColor="White" />
                    <EmptyDataRowStyle BackColor="Transparent" Font-Italic="true" HorizontalAlign="Center" />
                    <EmptyDataTemplate><br /><br />Mesaj Bulunmadı.</EmptyDataTemplate>
                </asp:GridView>
                <uc3:ucAlt ID="ucAlt1" runat="server" />
            </div>
        </div>
        <uc1:ucProgress ID="ucProgress1" runat="server" />
    </form>
</body>
</html>
