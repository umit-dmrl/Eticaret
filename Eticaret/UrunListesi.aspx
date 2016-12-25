<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSablon.Master" AutoEventWireup="true" CodeBehind="UrunListesi.aspx.cs" Inherits="Eticaret.UrunListesi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .simgeler{
            display:block;
            padding:10px;
            margin-bottom:5px;
            margin-top:5px;
            border:1px solid #ccc;
            border-radius:5px;
            box-shadow:3px 3px 3px #ccc;
        }
        .icon-test-urun{
            display:inline-block;
            padding:3px;
            border-radius:50%;
            background-color:orange;
            color:white;
            text-align:center;
        }
        .icon-normal-urun{
            display:inline-block;
            padding:3px;
            border-radius:50%;
            background-color:#316dfa;
            color:white;
            text-align:center;
        }
        .icon-indirimli-urun{
            display:inline-block;
            padding:3px;
            border-radius:50%;
            background-color:green;
            color:white;
            text-align:center;
        }
        .icon-kampanya-urun{
            display:inline-block;
            padding:3px;
            border-radius:50%;
            background-color:maroon;
            color:white;
            text-align:center;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="message" runat="server"></div>
    Ürün Adına Göre Arama Yapın : <asp:TextBox ID="txtUrunAdi" runat="server" CssClass="form form-control"></asp:TextBox>
    <asp:Button ID="btnAra" runat="server" Text="Ara" CssClass="btn btn-primary" OnClick="btnAra_Click" />
    <div class="simgeler"><span class="icon-test-urun">T</span> : Test Ürünü , <span class="icon-normal-urun">N</span> : Normal Ürün , <span class="icon-indirimli-urun">İ</span> : İndirimli Ürün , <span class="icon-kampanya-urun">K</span> : Kampanyalı Ürün</div>
    <asp:ListView ID="listUrunler" runat="server">
        <ItemTemplate>
            <table cellpadding="5" width="100%" style="border-bottom:1px solid #ccc; background-color:#f4f4f4;">
                <tr>
                    <td width="10%"><%# (Eval("resimAdi").ToString().Trim()) == "no_image" ? "<img src='assets/images/no-image-thumb.png' style='width:40px; height:40px;' />" : "<img src='upload/"+Eval("resimAdi").ToString().Trim()+"'  style='width:40px; height:40px;' />" %></td>
                    <td width="25%"><%# Eval("urunAdi").ToString().Trim() %></td>
                    <td width="20%"><%# Eval("kategoriAdi").ToString().Trim() %></td>  
                    <td width="5%">
                        <%# (Convert.ToInt32(Eval("urunTipi").ToString().Trim())) == 1 ? "<span class='icon-normal-urun' title='Normal Ürün'>N</span>" : null %>
                        <%# (Convert.ToInt32(Eval("urunTipi").ToString().Trim())) == 2 ? "<span class='icon-indirimli-urun' title='İndirimli Ürün'>İ</span>" : null %>
                        <%# (Convert.ToInt32(Eval("urunTipi").ToString().Trim())) == 3 ? "<span class='icon-kampanya-urun' title='Kampanyalı Ürün'>K</span>" : null %>
                        <%# (Convert.ToInt32(Eval("urunTipi").ToString().Trim())) == 4 ? "<span class='icon-test-urun' title='Test Ürünü'>T</span>" : null %>
                    </td>
                    <td width="10%"><%# Eval("urunFiyati").ToString().Trim() %> TL</td>
                    <td width="20%">
                        <a href="UrunDuzenle.aspx?id=<%# Eval("id") %>" class="btn btn-primary"><i class="fa fa-edit"></i></a> 
                        <a href="UrunListesi.aspx?sil=<%# Eval("id") %>" class="btn btn-danger"><i class="fa fa-remove"></i></a>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>