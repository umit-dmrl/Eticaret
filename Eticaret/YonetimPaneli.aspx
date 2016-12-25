<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSablon.Master" AutoEventWireup="true" CodeBehind="YonetimPaneli.aspx.cs" Inherits="E_Ticaret_Projesi.YonetimPaneli" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .statistic-item{
            display:block;
            padding:10px;
            background-color:white;
            border:1px solid #ccc;
            border-radius:10px;
            box-shadow:3px 3px 3px #ccc;
            width:100px;
            float:left;
            margin-right:60px;
        }
        .statistic-item #icon{
            text-align:center;
            font-size:50px;
            padding:5px;
            color:orangered;
        }
        .statistic-item #aciklama{
            display:block;
            padding:5px;
            font-size:12px;
            font-weight:bold;
            text-align:center;
        }
        .statistic-item #text {
            padding:5px;
            font-size:30px;
            font-weight:bold;
            color:#2a78e5;
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="alert alert-success"><b><i class="fa fa-pie-chart"></i> Site İstatistikleri</b></div>
    <div class="statistic-item">
        <div id="icon"><i class="fa fa-cart-plus"></i></div>
        <div id="aciklama">Toplam Sipariş Sayısı</div>
        <div id="text">
            <asp:Label ID="lblToplamSiparis" runat="server" Text=""></asp:Label>
        </div>
    </div>

    <div class="statistic-item">
        <div id="icon"><i class="fa fa-database"></i></div>
        <div id="aciklama">Toplam Ürün Sayısı</div>
        <div id="text">
            <asp:Label ID="lblToplamUrunSayisi" runat="server" Text=""></asp:Label>
        </div>
    </div>

    <div class="statistic-item">
        <div id="icon"><i class="fa fa-list"></i></div>
        <div id="aciklama">Toplam Kategori Sayısı</div>
        <div id="text">
            <asp:Label ID="lblToplamKategori" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>