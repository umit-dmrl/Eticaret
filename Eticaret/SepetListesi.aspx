<%@ Page Title="Sepetim" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SepetListesi.aspx.cs" Inherits="Eticaret.SepetListesi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_content" runat="server">
    <div id="message" runat="server"></div>
    <asp:ListView runat="server" ID="listSepetListesi">
        <ItemTemplate>
            <div class="sepet-product-item">
                <div id="resim"><%# (Eval("resimAdi").ToString().Trim()=="no_image")?"<img src='assets/images/no-image-thumb.png' />":"<img src='upload/"+Eval("resimAdi").ToString().Trim()+"' />" %></div>
                <div id="urun-bilgileri">
                    <font color="#27364d"><%# Eval("urunAdi").ToString().Trim() %></font> 
                    <i class="fa fa-arrow-circle-o-right" style="color:orange;"></i>
                    <font size="2">
                    <%# (Eval("urunTipi").ToString().Trim()=="1")?"Normal Ürün":null %>
                    <%# (Eval("urunTipi").ToString().Trim()=="2")?"<b>İndirimli Ürün</b>":null %>
                    <%# (Eval("urunTipi").ToString().Trim()=="3")?"<b>Kapmanyalı Ürün</b>":null %>
                    <%# (Eval("urunTipi").ToString().Trim()=="4")?"<b>Test Ürünü</b>":null %>
                    </font> 
                    <i class="fa fa-arrow-circle-o-right" style="color:orange;"></i> 
                    <span style="padding:5px; color:brown;"><%# Eval("urunFiyati").ToString().Trim() %> TL</span>
                    <br /><br />
                    <a href="UrunDetay.aspx?id=<%# Eval("id").ToString().Trim() %>" class="btn btn-primary"><i class="fa fa-search"></i></a> 
                    <a href="SepetListesi.aspx?cikar=<%# Eval("siparisid").ToString().Trim() %>" class="btn btn-danger"><i class="fa fa-remove"></i></a>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
    <br />
    <p align="right"><b>Toplam Tutar : </b>
       <asp:Label ID="txtToplam" runat="server" Text=""></asp:Label>
    </p><br />
    <p align="right">
        <a href="SiparisTamamla.aspx" id="linkSiparisTamamla" runat="server" class="btn btn-primary">Siparişi Tamamla</a>
    </p>
</asp:Content>