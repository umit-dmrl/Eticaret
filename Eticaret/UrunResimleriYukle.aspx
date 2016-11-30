<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSablon.Master" AutoEventWireup="true" CodeBehind="UrunResimleriYukle.aspx.cs" Inherits="Eticaret.UrunResimleriYukle" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="uploadify/uploadify.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="uploadify/swfobject.js"></script>
    <script type="text/javascript" src="uploadify/jquery.uploadify.v2.1.0.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            
            $("#<%=digerResimleri.ClientID%>").uploadify({
                'uploader': 'uploadify/uploadify.swf',
                'script': 'Upload.ashx',
                'cancelImg': 'assets/images/cancel.png',
                'folder': 'upload',
                'multi': true,
                'buttonText': 'Resim Sec',
                'auto': true,
                onAllComplete: function (event, data) {
                    location.reload();
                }

            });
        });
    </script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        Yüklemek İstediğiniz Ürün Resimlerini Seçiniz<br />
        <asp:FileUpload ID="digerResimleri" runat="server" AllowMultiple="True" />
        <font size="1" color="maroon">Uyarı : Sadece Resim Türünden Dosyalar Seçiniz Aksi Halde Dosya Yüklenmeyecektir!</font></div>
    <div>
        <table align="center" width="100%" style="background-color:black; color:white;" cellpadding="5">
                <tr>
                    <td width="5%">Seçim</td>
                    <td width="70%">Resim</td>
                    <td width="25%" align="center">Eylemler</td>
                </tr>
            </table>
        <asp:ListView ID="listResimler" runat="server">
            <ItemTemplate>
                <table align="center" width="100%"  style="background-color:#f4f4f4; border-bottom:1px solid #ccc;" cellpadding="5">
                <tr>
                    <td width="5%"><asp:CheckBox ID="secim" runat="server" Text="" /></td>
                    <td width="70%">
                        <img src="upload/<%# Eval("ResimAdi").ToString().Trim() %>" width="100" height="100" />
                        <asp:HiddenField ID="resimID" Value='<%# Eval("id").ToString().Trim() %>' runat="server" />
                    </td>
                    <td width="25%" align="center">
                        <a href="upload/<%# Eval("ResimAdi").ToString().Trim() %>" target="_blank" class="btn btn-default"><i class="fa fa-search-plus"></i></a>
                        <a href="upload/<%# Eval("id").ToString().Trim() %>" target="_blank" class="btn btn-danger"><i class="fa fa-remove"></i></a>
                    </td>
                </tr>
            </table>
            </ItemTemplate>
        </asp:ListView>
        <br />
        <asp:DataPager ID="DataPager1" PagedControlID="listResimler" PageSize="20" QueryStringField="sayfa" runat="server">
        <Fields>
            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" FirstPageText="Baş" LastPageText="Son" NextPageText="Sonraki" PreviousPageText="Önceki" />
            <asp:NumericPagerField ButtonType="Button" NumericButtonCssClass="btn btn-default" CurrentPageLabelCssClass="btn btn-primary" />
            <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" FirstPageText="Baş" LastPageText="Son" NextPageText="Sonraki" PreviousPageText="Önceki" />
        </Fields>
    </asp:DataPager>

    <p align="right"><asp:Button Text="Seçilenleri Sil" CssClass="btn btn-danger" runat="server" ID="btnTopluSil" OnClick="btnTopluSil_Click" /></p>
    </div>
</asp:Content>