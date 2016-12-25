<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSablon.Master" AutoEventWireup="true" CodeBehind="YoneticiAyarlari.aspx.cs" Inherits="Eticaret.YoneticiAyarlari" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="message" runat="server"></div>
    <div class="alert alert-default"><b><i class="fa fa-cogs"></i> Kullanıcı Adı Ve Parola Ayarları</b></div>
    <div class="alert alert-warning"><i class="fa fa-info-circle"></i> Sadece Kullanıcı Adı Veya Parola Değiştime İçin Yeni Alanların İçine Geçerli Olan Bilgileri Yazınız.</div>
    Kullanıcı Adınız<br />
    <asp:TextBox ID="txtUsername" runat="server" CssClass="form form-control"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtUsername" ErrorMessage="*" ForeColor="#990000"></asp:RequiredFieldValidator>
    <br />
    Yeni Kullanıcı Adınız<br />
    <asp:TextBox ID="txtYeniUsername" runat="server" CssClass="form form-control"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtYeniUsername" ErrorMessage="*" ForeColor="#990000"></asp:RequiredFieldValidator>
    <br />
    Geçerli Parolanız <br />
    <asp:TextBox ID="txtGecerliParola" runat="server" CssClass="form form-control"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtGecerliParola" ErrorMessage="*" ForeColor="#990000"></asp:RequiredFieldValidator>
    <br />
    Yeni Parolanız<br />
    <asp:TextBox ID="txtYeniParola" runat="server" CssClass="form form-control"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtYeniParola" ErrorMessage="*" ForeColor="#990000"></asp:RequiredFieldValidator>
    <br />
    Yeni Parolayı Tekrar Giriniz<br />
     <asp:TextBox ID="txtTekrar" runat="server" CssClass="form form-control"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTekrar" ErrorMessage="*" ForeColor="#990000"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtYeniParola" ControlToValidate="txtTekrar" ErrorMessage="Üstte yazdığınız parola ile uyuşmuyor." ForeColor="#990000"></asp:CompareValidator>
    <br />
    <asp:Button ID="btnGuncelle" runat="server" Text="Güncelle" CssClass="btn btn-primary" OnClick="btnGuncelle_Click" />
</asp:Content>