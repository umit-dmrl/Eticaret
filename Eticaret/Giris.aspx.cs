using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Ticaret_Projesi
{
    public partial class Giris : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUserName.Text.Trim().ToString();
                string password = txtPassword.Text.Trim().ToString();

                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);
                cnn.Open();
                SqlCommand kayit = new SqlCommand("select * from admin where username=@username and password=@password",cnn);
                kayit.Parameters.Add("@username", username);
                kayit.Parameters.Add("@password", password);

                SqlDataReader oku = kayit.ExecuteReader();
                int sayac=0;
                while (oku.Read())
                {
                    Session["UserID"] = oku["id"].ToString();
                    Session["UserName"] = oku["username"].ToString();
                    sayac++;
                }
                if (sayac != 0)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Hoşgeldiniz";
                    Response.Redirect("~/YonetimPaneli.aspx");
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Maroon;
                    lblMessage.Text = "Kullanıcı Adı Veya Parolanız Hatalı!";
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Hata:"+ex);
            }
        }
    }
}