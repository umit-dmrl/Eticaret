<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SiparisTamamla.aspx.cs" Inherits="Eticaret.SiparisTamamla" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main_content" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="content-title">Kişisel Bilgileriniz</div>
    <table width="100%" cellpadding="0">
        <tr>
            <td width="50%">
                Ad Soyad<br />
                <asp:TextBox CssClass="form form-control" ID="txtAdSoyad" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Maroon" ControlToValidate="txtAdSoyad"></asp:RequiredFieldValidator>
                <br />
                İletişim No (Cep/Tel)<br />
                <asp:TextBox ID="txtTel" CssClass="form form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Maroon" ControlToValidate="txtTel"></asp:RequiredFieldValidator>
                <br />
                E-Posta Adresi<br />
                <asp:TextBox ID="txtEposta" CssClass="form form-control" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtEposta" ForeColor="#990000" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Maroon" ControlToValidate="txtEposta"></asp:RequiredFieldValidator>
                <br />
            </td>
            <td width="50%">
                Adres Bilgileriniz 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Maroon" ControlToValidate="txtAdres"></asp:RequiredFieldValidator>
                <br /> 
                <asp:TextBox ID="txtAdres" CssClass="form form-control" Width="500" Height="100" style="border:1px solid #ccc; margin-top: 0;" TextMode="MultiLine" runat="server"></asp:TextBox>
                <br />

            </td>
        </tr>
    </table>
    <div class="content-title">Firma Bilgileriniz (Zorunlu Alan Değil)</div>
    <table cellpadding="0" width="100%">
        <tr>
            <td width="50%">
                Firma Adı<br />
                <asp:TextBox ID="txtFirmaAdi" runat="server" CssClass="form form-control"></asp:TextBox>
                <br />
                Firma Tel<br />
                <asp:TextBox ID="txtFirmaTel" runat="server" CssClass="form form-control"></asp:TextBox>
                <br />
                Vergi Dairse / No <br />
                <asp:TextBox ID="txtVergiNo" runat="server" CssClass="form form-control"></asp:TextBox>
                <br />
            </td>
            <td width="50%">
                Firma Adresi<br />
                <asp:TextBox ID="txtFirmaAdresi" runat="server" Width="500" Height="100" CssClass="form form-control" style="border:1px solid #ccc;" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <p align="right">
        <a href="SepetListesi.aspx" class="btn btn-primary">Sepeti Göster</a> 
        <asp:Button ID="btnKaydet" CssClass="btn btn-primary" runat="server" Text="Siparişi Tamamla" OnClick="btnKaydet_Click" />
    </p>
    
</asp:Content>