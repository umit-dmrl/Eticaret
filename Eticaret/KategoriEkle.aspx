<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSablon.Master" AutoEventWireup="true" CodeBehind="KategoriEkle.aspx.cs" Inherits="E_Ticaret_Projesi.KategoriEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        label {
            display:inline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
            Kategori Adı<br />
            <asp:TextBox ID="txtKategoriAdi" runat="server"></asp:TextBox>
            <br />
            <asp:CheckBox ID="onay" Text=" Sitede Gösterilsin." runat="server" />
            <br />
            <br />
            <asp:Button ID="btnKaydet" runat="server" CssClass="btn btn-primary" Text="Kaydet" OnClick="btnKaydet_Click" />
            <br />
            <br />
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        
    
</asp:Content>
