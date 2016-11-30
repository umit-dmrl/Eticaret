<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSablon.Master" AutoEventWireup="true" CodeBehind="KategoriListesi.aspx.cs" Inherits="E_Ticaret_Projesi.KategoriListesi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    <br /><br />
        <table align="center" width="100%" style="background-color:black; color:white;" cellpadding="5">
                <tr>
                    <td width="50%">Kategori Adları</td>
                    <td width="30%">Durumu</td>
                    <td width="20%">Eylemler</td>
                </tr>
            </table>
    <asp:ListView ID="listKategori" runat="server">
        <ItemTemplate>
            <table align="center" width="100%" cellpadding="5" style="background-color:#f4f4f4; border-bottom:1px solid #ccc;">
                <tr>
                    <td width="50%"><%#Eval("kategoriAdi") %></td>
                    <td width="20%">
                        <%# (Eval("onay").ToString().Trim())=="1" ? "<font color='green'>Aktif</font>" : "<font color='orange'>Pasif</font>" %>
                    </td>
                    <td width="30%" align="center">
                        <a href="KategoriDuzenle.aspx?id=<%# Eval("id").ToString().Trim() %>" class="btn btn-primary"><i class="fa fa-pencil"></i> Düzenle</a> 
                        <a href="KategoriSil.aspx?id=<%# Eval("id").ToString().Trim() %>" class="btn btn-warning"><i class="fa fa-remove"></i> Sil</a>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:ListView>
    
    <asp:DataPager ID="DataPager1" PagedControlID="listKategori" PageSize="50" QueryStringField="sayfa" runat="server">
        <Fields>
            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" FirstPageText="Baş" LastPageText="Son" NextPageText="Sonraki" PreviousPageText="Önceki" />
            <asp:NumericPagerField ButtonType="Button" />
            <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" FirstPageText="Baş" LastPageText="Son" NextPageText="Sonraki" PreviousPageText="Önceki" />
        </Fields>
    </asp:DataPager>
    
</asp:Content>
