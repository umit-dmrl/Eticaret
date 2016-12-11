<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSablon.Master" AutoEventWireup="true" CodeBehind="IletisimBilgileriGuncelle.aspx.cs" Inherits="Eticaret.IletisimBilgileriGuncelle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="message" runat="server"></div>
    <div class="alert alert-info">Site İletişim Bilgileri</div>
    Telefon<br />
    <asp:TextBox ID="txtTel" TextMode="Phone" runat="server" CssClass="form form-control"></asp:TextBox>
    <br />
    GSM<br />
    <asp:TextBox ID="txtGSM" TextMode="Phone" runat="server" CssClass="form form-control"></asp:TextBox>
    <br />
    Fax<br />
    <asp:TextBox ID="txtFax" runat="server" CssClass="form form-control"></asp:TextBox>
    <br />
    Adres Bilgileri<br />
    <asp:TextBox ID="txtAdres" TextMode="MultiLine" runat="server" Width="500" Height="70" CssClass="form form-control"></asp:TextBox>
    <br />
    <div class="alert alert-info">Harita Ekleyin</div>
    <asp:TextBox ID="txtMaps" TextMode="MultiLine" runat="server" Width="500" Height="70"  CssClass="form form-control"></asp:TextBox>
    <br />
    <font color="orange" size="3"><i class="fa fa-info-circle"></i> Google veya benzeri bir arama motorundan adresinizin maps kodunu alıp yukarıdaki alana yapıştırınız!</font>
    <br />
    <div class="alert alert-info">Sosyal Medya Linkleri</div>
    Facebook<br />
    <asp:TextBox ID="txtFacebook" runat="server" CssClass="form form-control"></asp:TextBox>
    <br />
    Twitter<br />
    <asp:TextBox ID="txtTwitter" runat="server" CssClass="form form-control"></asp:TextBox>
    <br />
    Instagram<br />
    <asp:TextBox ID="txtInstagram" runat="server" CssClass="form form-control"></asp:TextBox>
    <br />
    Linkedin<br />
    <asp:TextBox ID="txtLinkedin" runat="server" CssClass="form form-control"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btnKaydet" runat="server" Text="Kaydet" CssClass="btn btn-primary" OnClick="btnKaydet_Click" />
</asp:Content>