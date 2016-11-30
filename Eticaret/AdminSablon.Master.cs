using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Ticaret_Projesi
{
    public partial class AdminSablon : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null || Session["UserName"] == null)
            {
                Response.Redirect("~/Giris.aspx");
            }
            else
            {
                lblUserName.Text = Session["UserName"].ToString();
            }
        }
    }
}