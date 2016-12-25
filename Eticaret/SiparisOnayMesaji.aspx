<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SiparisOnayMesaji.aspx.cs" Inherits="Eticaret.SiparisOnayMesaji" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_content" runat="server">
    <div class="alert alert-success" style="font-size:20px; text-align:center;">
        <i class="fa fa-check"></i> Siparişiniz Başarıyla Tarafımıza Ulaşmıştır.<br /><br />
        Onay Kodunuz : <asp:Label ID="lblOnayKodu" runat="server" ForeColor="#006699"></asp:Label>
        <br /><br />
        <font size="3" color="orange"><i class="fa fa-warning"></i> Onay Kodunuzu Siparişlerinizi Takip Edebilmek İçin Saklayınız...</font>
    </div>
</asp:Content>