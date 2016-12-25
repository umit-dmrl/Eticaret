using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eticaret
{
    public partial class SiparisOnayMesaji : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["kod"]!=null)
            {
                lblOnayKodu.Text = Request.QueryString["kod"].ToString().Trim();
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}