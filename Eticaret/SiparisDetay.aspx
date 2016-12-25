<%@ Page Title="Sipariş Detayı" Language="C#" MasterPageFile="~/AdminSablon.Master" AutoEventWireup="true" CodeBehind="SiparisDetay.aspx.cs" Inherits="Eticaret.SiparisDetay" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="lblUser" runat="server" />
    <asp:HiddenField ID="lblSiparisNo" runat="server" />
    <div id="message" runat="server"></div>
    Sipariş Durumu : 
    <asp:DropDownList ID="durum" runat="server">
        <asp:ListItem Value="Sipariş Henüz Onaylanmadı">Sipariş Henüz Onaylanmadı</asp:ListItem>
        <asp:ListItem Value="Sipariş Beklemede">Sipariş Beklemede</asp:ListItem>
        <asp:ListItem Value="Sipariş Kargoya Verildi">Sipariş Kargoya Verildi</asp:ListItem>
        <asp:ListItem Value="Sipariş İptal Edildi">Sipariş İptal Edildi.</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="btnDurumGuncelle" runat="server" Text="Güncelle" CssClass="btn btn-primary" OnClick="btnDurumGuncelle_Click" />
    <br />
    <asp:Label ID="durumu_goster" runat="server"></asp:Label>
    <div class="alert alert-default">Kişisel Bilgileriniz</div>
    <table width="100%" cellpadding="0">
        <tr>
            <td width="50%">
                Sipariş Kodu :
                <asp:Label ID="lblKod" runat="server" Text="" ForeColor="Green"></asp:Label>
                <br />
                <br />
                Ad Soyad<br />
                <asp:Label ID="lblAdSoyad" runat="server" Text="" ForeColor="BlueViolet"></asp:Label>
                <br />
                <br />
                İletişim No (Cep/Tel)<br />
                <asp:Label ID="lblTel" runat="server" Text="" ForeColor="BlueViolet"></asp:Label>
                <br />
                <br />
                E-Posta Adresi<br />
                <asp:Label ID="lblEmail" runat="server" Text="" ForeColor="BlueViolet"></asp:Label>
                <br />
                <br />
            </td>
            <td width="50%" valign="top">
                Adres Bilgileriniz <br />
                <asp:Label ID="lblAdres" runat="server" Text=""></asp:Label>

            </td>
        </tr>
    </table>
    <div class="alert alert-default">Firma Bilgileriniz (Zorunlu Alan Değil)</div>
    <table cellpadding="0" width="100%">
        <tr>
            <td width="50%">
                Firma Adı<br />
                <asp:Label ID="lblFirmaAdi" runat="server" Text=""  ForeColor="BlueViolet"></asp:Label>
                <br />
                <br />
                Firma Tel<br />
                <asp:Label ID="lblFirmaTel" runat="server" Text="" ForeColor="BlueViolet"></asp:Label>
                <br />
                <br />
                Vergi Dairse / No <br />
                <asp:Label ID="lblVergiNo" runat="server" Text="" ForeColor="BlueViolet"></asp:Label>
                <br />
            </td>
            <td width="50%" valign="top">
                Firma Adresi<br />
                <asp:Label ID="lblFirmaAdresi" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <div class="alert alert-default">Siparişler</div>
    <asp:ListView runat="server" ID="listSepetListesi">
        <ItemTemplate>
            <div class="sepet-product-item">
                <div id="resim"><%# (Eval("resimAdi").ToString().Trim()=="no_image")?"<img src='assets/images/no-image-thumb.png' />":"<img src='upload/"+Eval("resimAdi").ToString().Trim()+"' />" %></div>
                <div id="urun-bilgileri">
                    <font color="#27364d"><%# Eval("urunAdi").ToString().Trim() %></font><br /> 
                    <i class="fa fa-arrow-circle-o-right" style="color:orange;"></i>
                    <font size="2">
                    <%# (Eval("urunTipi").ToString().Trim()=="1")?"Normal Ürün":null %>
                    <%# (Eval("urunTipi").ToString().Trim()=="2")?"<b>İndirimli Ürün</b>":null %>
                    <%# (Eval("urunTipi").ToString().Trim()=="3")?"<b>Kapmanyalı Ürün</b>":null %>
                    <%# (Eval("urunTipi").ToString().Trim()=="4")?"<b>Test Ürünü</b>":null %>
                    </font> <br />
                    <i class="fa fa-arrow-circle-o-right" style="color:orange;"></i> 
                    <span style="padding:5px; color:brown;"><%# Eval("urunFiyati").ToString().Trim() %> TL</span>
                    <br />
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
    <p align="right">
        <b>Toplam : </b> <asp:Label ID="txtToplam" runat="server" Text=""></asp:Label>
    </p>
    </asp:Content>