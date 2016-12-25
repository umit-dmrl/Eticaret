using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using E_Ticaret_Projesi;

namespace Eticaret
{
    public partial class YoneticiAyarlari : System.Web.UI.Page
    {
        Veritabani vt = new Veritabani();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                vt.cnn.Open();
                SqlCommand sorgula = new SqlCommand("select * from admin where username='"+txtUsername.Text.ToString().Trim()+"' and password='"+txtGecerliParola.Text.ToString().Trim()+"'",vt.cnn);
                SqlDataReader oku = sorgula.ExecuteReader();
                bool state = oku.Read();
                oku.Close();
                if(state==true)
                {
                    SqlCommand guncelle = new SqlCommand("update admin set username='"+txtYeniUsername.Text.ToString().Trim()+ "',password='" + txtYeniParola.Text.ToString().Trim()+"' where id=1",vt.cnn);
                    guncelle.ExecuteNonQuery();
                    message.InnerHtml = "<div class='alert alert-success'><b><i class='fa fa-check'></i> Kullanıcı Adı Ve Şifreniz Değiştirildi.</b></div>";
                }
                else
                {
                    message.InnerHtml = "<div class='alert alert-error'><b><i class='fa fa-warning'></i> Kullanıcı Bulunamadı!</b></div>";
                }

            }catch(Exception ex)
            {
                Response.Write(ex);
            }
            finally
            {
                vt.cnn.Close();
            }
        }
    }
}