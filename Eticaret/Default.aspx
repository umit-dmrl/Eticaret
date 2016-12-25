﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Eticaret.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_content" runat="server">
    <div class="content-title"><i class="fa fa-arrow-circle-o-right"></i> Yeni Ürünler</div>
    <asp:ListView ID="listSonUrunler" runat="server">
        <ItemTemplate>
            <div class="urun-item">
                <div id="urun-resim">
                    <a href="UrunDetay.aspx?id=<%# Eval("id") %>" title="<%# Eval("urunAdi") %>">
                        <%# (Eval("resimAdi").ToString().Trim()=="no_image")?"<img src='assets/images/no-image-thumb.png' style='margin-bottom: 13px;' />":"<img src='upload/"+Eval("resimAdi").ToString().Trim()+"' width='180' height='100' />" %>
                    </a>       
                </div>
                <div id="urun-title"><%# Eval("urunAdi") %></div>
                <div id="fiyat">
                    Ürün Fiyatı : <%# Eval("urunFiyati") %> TL
                    <br />
                    Ürün Tipi : 
                    <%# (Eval("urunTipi").ToString().Trim()=="1")?"<b>Normal Ürün</b>":null %>
                    <%# (Eval("urunTipi").ToString().Trim()=="2")?"<b>İndirimli Ürün</b>":null %>
                    <%# (Eval("urunTipi").ToString().Trim()=="3")?"<b>Kapmanyalı Ürün</b>":null %>
                    <%# (Eval("urunTipi").ToString().Trim()=="4")?"<b>Test Ürünü</b>":null %>
                </div>
                <div id="buttons">
                    <a href="UrunDetay.aspx?id=<%# Eval("id") %>" class="btn btn-primary"><i class="fa fa-search"></i> İncele</a>
                    <a href="SepeteEkle.aspx?product=<%# Eval("id") %>" class="btn btn-success"><i class="fa fa-shopping-basket"></i> Ekle</a>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
    <div style="clear:both;"></div>
    <br />
    <div class="content-title"><i class="fa fa-arrow-circle-o-right"></i> Kampanyalı Ürünler</div>
    <asp:ListView ID="listKampanyaliUrunler" runat="server">
        <ItemTemplate>
            <div class="urun-item">
                <div id="urun-resim">
                    <%# (Eval("resimAdi").ToString().Trim()=="no_image")?"<img src='assets/images/no-image-thumb.png' style='margin-bottom: 13px;' />":"<img src='upload/"+Eval("resimAdi").ToString().Trim()+"' width='180' height='100' />" %>
                    
                </div>
                <div id="urun-title"><%# Eval("urunAdi") %></div>
                <div id="fiyat">
                    Ürün Fiyatı : <%# Eval("urunFiyati") %> TL
                    <br />
                    Ürün Tipi : 
                    <%# (Eval("urunTipi").ToString().Trim()=="1")?"<b>Normal Ürün</b>":null %>
                    <%# (Eval("urunTipi").ToString().Trim()=="2")?"<b>İndirimli Ürün</b>":null %>
                    <%# (Eval("urunTipi").ToString().Trim()=="3")?"<b>Kapmanyalı Ürün</b>":null %>
                    <%# (Eval("urunTipi").ToString().Trim()=="4")?"<b>Test Ürünü</b>":null %>
                </div>
                <div id="buttons">
                    <a href="UrunDetay.aspx?id=<%# Eval("id") %>" class="btn btn-primary"><i class="fa fa-search"></i> İncele</a>
                    <a href="SepeteEkle.aspx?product=<%# Eval("id") %>" class="btn btn-success"><i class="fa fa-shopping-basket"></i> Ekle</a>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
