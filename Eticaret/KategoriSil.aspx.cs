using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

namespace E_Ticaret_Projesi
{
    public partial class KategoriSil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                Veritabani vt = new Veritabani();
                try
                {
                    string id = Request.QueryString["id"].ToString().Trim();
                    vt.cnn.Open();
                    SqlCommand komut = new SqlCommand("delete from kategoriler where id=" + id, vt.cnn);
                    komut.ExecuteNonQuery();
                    Response.Redirect("~/KategoriListesi.aspx?mesaj=success");
                }
                catch (Exception ex)
                {
                    Response.Write("Hata! : "+ex);
                }
                finally
                {
                    vt.cnn.Close();
                }
            }
            else
            {
                Response.Redirect("~/KategoriListesi.aspx?mesaj=error");
            }
        }
    }
}