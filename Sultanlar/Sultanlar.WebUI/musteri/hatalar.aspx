<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hatalar.aspx.cs" Inherits="Sultanlar.WebUI.musteri.hatalar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" CellPadding="5" 
            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
            AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
            DataKeyNames="pkHataID" BackImageUrl="~/musteri/img/bg-logo.jpg" 
            PageSize="50" Width="100%" Font-Size="12px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="pkHataID" HeaderText="ID" ReadOnly="True" 
                    InsertVisible="False" SortExpression="pkHataID" >
                <HeaderStyle Wrap="True" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="strHataKodu" HeaderText="Kod" 
                    SortExpression="strHataKodu" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" />
                </asp:BoundField>
                <asp:BoundField DataField="strHataKaynak" HeaderText="Kaynak" 
                    SortExpression="strHataKaynak" >
                <ItemStyle VerticalAlign="Middle" Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="strHataYeri" HeaderText="Yer" 
                    SortExpression="strHataYeri" >
                <ItemStyle VerticalAlign="Middle" Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="strHataAciklama" HeaderText="Açıklama" 
                    SortExpression="strHataAciklama" >
                <ItemStyle VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="dtHataZamani" HeaderText="Tarih" 
                    SortExpression="dtHataZamani" DataFormatString="{0:dd/MM/yyyy}" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" />
                </asp:BoundField>
                <asp:CommandField ShowEditButton="True" ButtonType="Image" 
                    CancelImageUrl="~/musteri/img/ic_iade.png" CancelText="İ" 
                    DeleteImageUrl="~/musteri/img/sil.gif" DeleteText="S" 
                    EditImageUrl="~/musteri/img/degistir.gif" EditText="D" InsertText="E" 
                    NewText="Y" SelectText="S" ShowDeleteButton="True" 
                    UpdateImageUrl="~/musteri/img/ic_siparis.png" UpdateText="U" >
                <ItemStyle VerticalAlign="Middle" Width="50px" />
                </asp:CommandField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="Data Source=serverdb01;Initial Catalog=KurumsalWebSAP;User ID=sultanlar; Password=pazarlama" 
            ProviderName="System.Data.SqlClient" 
            SelectCommand="SELECT [pkHataID], [strHataKodu], [strHataKaynak], [strHataYeri], [strHataAciklama], [dtHataZamani] FROM [tblHatalar]
WHERE blPasif = 'False'" 
            DeleteCommand="UPDATE [tblHatalar] SET blPasif = 'True' WHERE [pkHataID] = @pkHataID" 
            
            UpdateCommand="UPDATE [tblHatalar] SET [strHataKodu] = @strHataKodu, [strHataKaynak] = @strHataKaynak, [strHataYeri] = @strHataYeri, [strHataAciklama] = @strHataAciklama, [dtHataZamani] = @dtHataZamani WHERE [pkHataID] = @pkHataID" 
            
            InsertCommand="INSERT INTO [tblHatalar] ([strHataKodu], [strHataKaynak], [strHataYeri], [strHataAciklama], [dtHataZamani]) VALUES (@strHataKodu, @strHataKaynak, @strHataYeri, @strHataAciklama, @dtHataZamani)">
            <DeleteParameters>
                <asp:Parameter Name="pkHataID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="strHataKodu" Type="String" />
                <asp:Parameter Name="strHataKaynak" Type="String" />
                <asp:Parameter Name="strHataYeri" Type="String" />
                <asp:Parameter Name="strHataAciklama" Type="String" />
                <asp:Parameter Name="dtHataZamani" Type="DateTime" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="strHataKodu" Type="String" />
                <asp:Parameter Name="strHataKaynak" Type="String" />
                <asp:Parameter Name="strHataYeri" Type="String" />
                <asp:Parameter Name="strHataAciklama" Type="String" />
                <asp:Parameter Name="dtHataZamani" Type="DateTime" />
                <asp:Parameter Name="pkHataID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
