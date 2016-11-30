<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Giris.aspx.cs" Inherits="E_Ticaret_Projesi.Giris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Yönetim Paneli</title>
    <link rel="stylesheet" href="assets/css/Admin.css" />
    <link rel='stylesheet prefetch' href='assets/css/bootstrap.min.css'>
    <script src='assets/js/jquery.min.js'></script>
    <script src='assets/js/bootstrap.min.js'></script>
    <script src="assets/js/jquery-ui.js"></script>
    <link rel="stylesheet" href="assets/css/jquery-ui.css">

</head>
<body>
    <form id="form1" runat="server">
        <div class="giris-panel">
            <div class="title">Yönetim Paneli</div>
            <div class="content">
                Kullanıcı Adı<br />
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                <br />
                Parola<br />
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                <div class="btn-submit">
                    <asp:Button ID="btnLogin" runat="server" Text="Giriş Yap" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
                </div>
                <br />
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>