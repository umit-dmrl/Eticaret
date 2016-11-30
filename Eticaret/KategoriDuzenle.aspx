<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSablon.Master" AutoEventWireup="true" CodeBehind="KategoriDuzenle.aspx.cs" Inherits="E_Ticaret_Projesi.KategoriDuzenle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
    Kategori Adı<br />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    <asp:CheckBox ID="CheckBox1" runat="server" Text="Sitede Gösterilsin" />
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Güncelle" CssClass="btn btn-primary" />
    <br />
</asp:Content>
