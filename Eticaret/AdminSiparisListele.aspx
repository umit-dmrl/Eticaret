<%@ Page Title="Sipariş Listesi" Language="C#" MasterPageFile="~/AdminSablon.Master" AutoEventWireup="true" CodeBehind="AdminSiparisListele.aspx.cs" Inherits="Eticaret.AdminSiparisListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="message" runat="server"></div>
    <table width="100%" cellpadding="5" style="background-color:black; color:white; font-weight:bold;">
                <tr>
                    <td width="40%">Ad Soyad</td>
                    <td width="20%" align="center">Telefon</td>
                    <td width="20%" align="center">Sipariş Kodu</td>
                    <td width="20%" align="center">Eylemler</td>
                </tr>
            </table>
    <asp:ListView ID="listSiparisler" runat="server">
        <ItemTemplate>
            <table width="100%" style="border-bottom:1px solid #ccc; background-color:#f4f4f4;">
                <tr>
                    <td width="40%" style="padding:5px; border-left:1px solid #ccc; border-right:1px solid #ccc;"><%# Eval("adsoyad") %></td>
                    <td align="center" width="20%" style="border-right:1px solid #ccc;"><%# Eval("tel") %></td>
                    <td align="center" width="20%" style="border-right:1px solid #ccc;"><%# Eval("onayKodu") %></td>
                    <td align="center" width="20%" style="border-right:1px solid #ccc;">
                        <a href="SiparisDetay.aspx?id=<%# Eval("id") %>" class="btn btn-primary"><i class="fa fa-edit"></i></a> 
                        <a href="AdminSiparisListele.aspx?sil=<%# Eval("id") %>" class="btn btn-danger"><i class="fa fa-remove"></i></a>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:ListView>
    <br />
    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="listSiparisler" QueryStringField="sayfa">
        <Fields>
            <asp:NextPreviousPagerField ButtonCssClass="btn btn-primary" ButtonType="Button" FirstPageText="Baş" LastPageText="Son" NextPageText="İleri" PreviousPageText="Geri" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
            <asp:NumericPagerField ButtonCount="10" ButtonType="Button" CurrentPageLabelCssClass="btn btn-default" />
            <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" ButtonCssClass="btn btn-primary" FirstPageText="Baş" LastPageText="Son" NextPageText="İleri" PreviousPageText="Geri" />
        </Fields>
    </asp:DataPager>
</asp:Content>