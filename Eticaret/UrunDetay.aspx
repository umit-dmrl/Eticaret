<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UrunDetay.aspx.cs" Inherits="Eticaret.UrunDetay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function resmi_degistir(resim)
        {
            $(".main-image").html("<img src='upload/" + resim + "' width='200' height='120' />");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_content" runat="server">
    <div id="message" runat="server">
    </div>
    <div class="product-content">
        <div id="left-side">
            <asp:ListView ID="listAnaResim" runat="server">
                <ItemTemplate>
                    <div class="main-image">
                    <%# (Eval("resimAdi").ToString().Trim()=="no_image")?"<img src='assets/images/no-image-thumb.png' style='width:180px; height:130px;' />":"<img src='upload/"+Eval("resimAdi").ToString().Trim()+"' width='200' height='120' />" %>    
                    </div>
                </ItemTemplate>
            </asp:ListView>
            <div class="product-images">
            <asp:ListView ID="listResimler" runat="server">
                <ItemTemplate>
                    <a href="javascript:void(0)" onclick="resmi_degistir('<%# Eval("resimAdi").ToString().Trim() %>')">
                        <img src="upload/<%# Eval("resimAdi").ToString().Trim() %>" width="70" height="70" />
                    </a>
                </ItemTemplate>
            </asp:ListView>
            </div>
        </div>
        <div id="right-side">
            <ul>
                <li><font size="2" color="#898de4">Anasayfa <i class="fa fa-arrow-circle-o-right"></i> <asp:Label ID="lblKategoriAdi" runat="server" Text=""></asp:Label></font></li>
                <li><asp:Label ID="lblUrunAdi" runat="server" Text=""></asp:Label></li>
                <li><div style="padding:5px; font-weight:bold; background-color:#f4f4f4; border-radius:5px; box-shadow:3px 3px 3px #ccc; display:inline-block;"><asp:Label ID="lblFiyati" runat="server" Text=""></asp:Label></div></li>
                <li><div style="color:brown; font-size:14px;"><asp:Label ID="lblTipi" runat="server" Text=""></asp:Label></div></li>
                <br />
                <p align="right">
                    <div id="btnLink" runat="server"></div>
                </p>
                <br />
                <p align="right">
                    <img src="assets/images/payment-icon/americanexpress.png" />
                    <img src="assets/images/payment-icon/cirrus.png" />
                    <img src="assets/images/payment-icon/mastercard.png" />
                    <img src="assets/images/payment-icon/paypal.png" />
                    <img src="assets/images/payment-icon/visa.png" />
                    </p>
               
            </ul>
        </div>
    </div>
    <div style="clear:both;"></div>
</asp:Content>
