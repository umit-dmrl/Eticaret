<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSablon.Master" AutoEventWireup="true" CodeBehind="YeniUrunEkle.aspx.cs" Inherits="Eticaret.YeniUrunEkle" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#anaResimSecimPaneli").hide();
        });
        function anaResimSecimPaneliToggle() {
            $("#anaResimSecimPaneli").slideToggle(1000);
        }
        function ana_resim_yap(ana_resim_id)
        {
            $("#ContentPlaceHolder1_secilenAnaResim").val(ana_resim_id);
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
            height:70px;
            padding:5px;
            border:1px solid #ccc;
            background:white;
            float:left;
            margin-left:5px;
            margin-bottom:5px;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="secilenAnaResim" Value="" runat="server" />
    Ürün Adı<br />
    <asp:TextBox ID="txtUrunAdi" runat="server"></asp:TextBox>
    <br />
    Ürün Fiyatı<br />
    <asp:TextBox ID="txtFiyat" runat="server" TextMode="Number"></asp:TextBox>
    <br />
    <a href="javascript:void(0)" onclick="anaResimSecimPaneliToggle()">Ana Ürün Resmi Seçiniz</a><br />
    <div class="anaResimSecimPaneli" id="anaResimSecimPaneli">
                <div class="images">
                    <asp:ListView ID="listAnaResimler" runat="server">
                        <ItemTemplate>
                            <div class="image_item">
                                <img src="upload/<%# Eval("ResimAdi").ToString().Trim() %>" width="70" height="70" />
                                <a href="javascript:void(0)" onclick="ana_resim_yap(<%# Eval("id").ToString().Trim() %>)">Ana Resim</a>
                                <asp:HiddenField ID="HiddenField1" Value='<%# Eval("id").ToString().Trim() %>' runat="server" />
                            </div>  
                        </ItemTemplate>
                    </asp:ListView>
                    </div>
                    <br />
                    <div style="clear:both;"></div>
    </div>
    <br /><br/>
    Diğer Ürün Resimleri<br />
    <asp:FileUpload ID="digerResimleri" runat="server" />
    <br /><br />
    <asp:Button ID="btnUrunKaydet" runat="server" Text="Kaydet" CssClass="btn btn-primary" OnClick="btnUrunKaydet_Click" />
</asp:Content>
