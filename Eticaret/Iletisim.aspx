<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Iletisim.aspx.cs" Inherits="Eticaret.Iletisim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_content" runat="server">
    
    <table width="100%">
        <tr>
            <td width="30%" valign="top" style="vertical-align: top;">
                <img src="assets/images/iletisim.png" width="300" />
            </td>
            <td width="70&" valign="top" style="vertical-align: top;">
                <div class="alert alert-default"><b>İletişim Bilgileri</b></div>
                Sabit Telefon Numaramız<br />
                <asp:Label ID="lblTel" runat="server" Text="" ForeColor="orangered"></asp:Label>
                <br />
                <br />
                GSM<br />
                <asp:Label ID="lblGSM" runat="server" Text="" ForeColor="orangered"></asp:Label>
                <br />
                <br />
                Fax<br />
                <asp:Label ID="lblFax" runat="server" Text="" ForeColor="orangered"></asp:Label>
                <br />
                <br />
                Adres Bilgileri<br />
                <asp:Label ID="lblAdres" runat="server" Text="" ForeColor="orangered"></asp:Label>
                <br />
                <br />
                Haritalar<br />
                <div id="maps" runat="server"></div>
                <br />
                <div class="alert alert-default"><b>Sosyal Medya Linkleri</b></div>
                <br />
                <!-- icon -->
		<span class="icon" id="icon_linkedin" style="line-height: normal; float:none;" runat="server">
			
		</span><!-- icon -->

		<!-- icon -->
		<span class="icon" id="icon_instagram" style="line-height: normal; float:none;" runat="server">
			
		</span><!-- icon -->

		<!-- icon -->
		<span class="icon" id="icon_twitter" style="line-height: normal; float:none;" runat="server">
			
		</span><!-- icon -->
		
		<!-- icon -->
		<span class="icon" id="icon_facebook" style="line-height: normal; float:none;" runat="server">
			
		</span>
            </td>
        </tr>
    </table>
</asp:Content>