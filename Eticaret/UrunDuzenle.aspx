<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSablon.Master" AutoEventWireup="true" CodeBehind="UrunDuzenle.aspx.cs" Inherits="Eticaret.UrunDuzenle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#anaResimSecimPaneli").hide();
            //$("#secilenResimGorunum").html("<img src='assets/images/no-image-thumb.png' style='width:100px; height:100px;' />");
        });
        function anaResimSecimPaneliToggle() {
            $("#anaResimSecimPaneli").slideToggle(1000);
        }
        function ana_resim_yap(ana_resim_id, ana_resim_adi)
        {
            $("#ContentPlaceHolder1_secilenAnaResim").val(ana_resim_id);
            $("#ContentPlaceHolder1_secilenAnaResimAdi").val(ana_resim_adi);
            $("#ContentPlaceHolder1_secilenResimGorunum").html("<img src='upload/" + ana_resim_adi + "' style='width:100px; height:100px;' />");
        }
    </script>
    <style type="text/css">
        .anaResimSecimPaneli .images{
            display:block;
            width:100%;
            height:200px;
            border:1px solid #ccc;
            background-color:#f4f4f4;
            overflow:hidden;
            overflow-y:scroll;
        }
        .anaResimSecimPaneli .image_item{
            display:block;
            width:70px;
            height:80px;
            padding:5px;
            border:1px solid #ccc;
            background:white;
            float:left;
            margin-left:5px;
            margin-bottom:5px;
        }
        .anaResimSecimPaneli .image_item a {
            display:block;
            font:12px Arial;    
        }
        label {
            display:inline;
            margin-left:3px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hiddenProductID" runat="server" Value="" />
    <asp:HiddenField ID="hiddenKey" runat="server" Value="" />
    <asp:HiddenField ID="secilenAnaResim" Value="-1" runat="server" />
    <asp:HiddenField ID="secilenAnaResimAdi" Value="no_image" runat="server" />
    Kategori Seçiniz<br />
    <asp:DropDownList ID="dropdownKategoriler" runat="server" CssClass="form form-control" DataSourceID="SqlDataSource1" DataTextField="kategoriAdi" DataValueField="id"></asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:proje %>" SelectCommand="SELECT * FROM [kategoriler] ORDER BY [kategoriAdi]"></asp:SqlDataSource>
    <br />
    Ürün Adı<br />
    <asp:TextBox ID="txtUrunAdi" runat="server"></asp:TextBox>
    <br />
    Ürün Fiyatı<br />
    <asp:TextBox ID="txtFiyat" runat="server" TextMode="Number"></asp:TextBox>
    <br />
    Ürün Özellikleri / Açıklamalar<br />
    <asp:TextBox ID="txtUrunAciklama" runat="server" TextMode="MultiLine" Width="500" CssClass="form form-control"></asp:TextBox>
    <br />
    Ürün Tipi<br />
    <asp:DropDownList ID="dropdownUrunTipi" runat="server" CssClass="form form-control">
        <asp:ListItem Value="1">Normal Ürün</asp:ListItem>
        <asp:ListItem Value="2">İndirimli Ürün</asp:ListItem>
        <asp:ListItem Value="3">Kapmanyalı Ürün</asp:ListItem>
        <asp:ListItem Value="4">Test Ürünü</asp:ListItem>
    </asp:DropDownList>
    <br />
    <div id="secilenResimGorunum" runat="server"></div>
    <br />
    <a href="javascript:void(0)" onclick="anaResimSecimPaneliToggle()">Ana Ürün Resmi Seçiniz</a><br />
    <div class="anaResimSecimPaneli" id="anaResimSecimPaneli">
                <div class="images">
                    <asp:ListView ID="listAnaResimler" runat="server">
                        <ItemTemplate>
                            <div class="image_item">
                                <img src="upload/<%# Eval("ResimAdi").ToString().Trim() %>" style="width:70px; height:60px;" />
                                <a href="javascript:void(0)" onclick="ana_resim_yap(<%# Eval("id").ToString().Trim() %>,'<%# Eval("ResimAdi").ToString().Trim() %>')">Ana Resim</a>
                                <asp:HiddenField ID="HiddenField1" Value='<%# Eval("id").ToString().Trim() %>' runat="server" />
                            </div>  
                        </ItemTemplate>
                    </asp:ListView>
                    </div>
                    <br />
                    <div style="clear:both;"></div>
    </div>
    <br />
    <div id="secilenDigerUrunResimleri" class="anaResimSecimPaneli" runat="server">
        <asp:ListView ID="listviewSecilenDigerResimler" runat="server">
            <ItemTemplate>
                <div class="image_item">
                     <img src="upload/<%# Eval("ResimAdi").ToString().Trim() %>" style="width:70px; height:60px;" />
                     <a href="_UrunResmiSil.aspx?id=<%# Eval("id").ToString().Trim() %>&adi=<%# Eval("resimAdi").ToString().Trim() %>&key=<%# Eval("urunOpKod").ToString().Trim() %>&product=<%# hiddenProductID.Value %>">Resmi Sil</a>
                     <asp:HiddenField ID="HiddenField1" Value='<%# Eval("id").ToString().Trim() %>' runat="server" />
                 </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <div style="clear:both;"></div>
    <br />
    <a href="javascript:void(0)">Daha Fazla Resim Seç</a>
    <div id="digerUrunResimleri" class="anaResimSecimPaneli">
        <div class="images">
                    <asp:ListView ID="listDigerResimler" runat="server">
                        <ItemTemplate>
                            <div class="image_item">
                                <img src="upload/<%# Eval("ResimAdi").ToString().Trim() %>" style="width:70px; height:60px;" />
                                <asp:CheckBox ID="secim" runat="server" Text="Seç" />
                                <asp:HiddenField ID="hiddenResimID" Value='<%# Eval("id").ToString().Trim() %>' runat="server" />
                                <asp:HiddenField ID="hiddenResimAdi" Value='<%# Eval("ResimAdi").ToString().Trim() %>' runat="server" />
                            </div>  
                        </ItemTemplate>
                    </asp:ListView>
                    </div>
                    <br />
                    <div style="clear:both;"></div>
    </div>
    <br />
    <asp:Button ID="btnUrunKaydet" runat="server" Text="Güncelle" CssClass="btn btn-primary" OnClick="btnUrunKaydet_Click" />
</asp:Content>