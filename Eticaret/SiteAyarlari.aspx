<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSablon.Master" AutoEventWireup="true" CodeBehind="SiteAyarlari.aspx.cs" Inherits="Eticaret.SiteAyarlari" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="message" runat="server"></div>
    Site Başlığı<br />
    <asp:TextBox CssClass="form form-control" ID="txtBaslik" runat="server"></asp:TextBox><br />
    Site Anahtar Kelimeleri (Keywords)<br />
    <asp:TextBox CssClass="form form-control" ID="txtAnahtarKelimeler" runat="server"></asp:TextBox>
    <br />
    <font size="2" color="orange"><i class="fa fa-info-circle"></i> Kelimelerin arasını virgül (,) simgesi ile ayırınız.</font>
    <br />
    Site Açıklaması (Description)<br />
    <asp:TextBox CssClass="form form-control" ID="txtAciklama" runat="server" TextMode="MultiLine" Width="400" Height="70"></asp:TextBox>
    <br />
    Telif Hakkı (Copyright)<br />
    <asp:TextBox CssClass="form form-control" ID="txtTelifHakki" runat="server"></asp:TextBox>
    <br />
    <font size="2" color="orange"><i class="fa fa-info-circle"></i> Bu kısım sitenin altında görünür.</font>
    <br /><br />
    <asp:Button ID="btnKaydet" runat="server" Text="Bilgileri Kaydet" CssClass="btn btn-primary" OnClick="btnKaydet_Click" />
</asp:Content>