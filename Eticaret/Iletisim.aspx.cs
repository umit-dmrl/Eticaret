using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using E_Ticaret_Projesi;
using System.Data.SqlClient;

namespace Eticaret
{
    public partial class Iletisim : System.Web.UI.Page
    {
        Veritabani vt = new Veritabani();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                vt.cnn.Open();
                SqlCommand iletisim = new SqlCommand("select * from site_iletisim_bilgileri where id=1",vt.cnn);
                SqlDataReader bilgiler = iletisim.ExecuteReader();
                if(bilgiler.Read())
                {
                    lblTel.Text = bilgiler["tel"].ToString();
                    lblFax.Text = bilgiler["fax"].ToString();
                    lblGSM.Text = bilgiler["gsm"].ToString();
                    lblAdres.Text = bilgiler["adres"].ToString();

                    maps.InnerHtml = "<iframe src='"+bilgiler["maps"].ToString().Trim()+"' width='100%' height='200' ></iframe>";

                    icon_facebook.InnerHtml = "<a target='_blank' href='" + bilgiler["facebook"].ToString().Trim() + "'><i class='fa fa-facebook'></i></a>";
                    icon_twitter.InnerHtml = "<a target='_blank' href='" + bilgiler["twitter"].ToString().Trim() + "'><i class='fa fa-twitter'></i></a>";
                    icon_instagram.InnerHtml = "<a target='_blank' href='" + bilgiler["instagram"].ToString().Trim() + "'><i class='fa fa-instagram'></i></a>";
                    icon_linkedin.InnerHtml = "<a target='_blank' href='" + bilgiler["linkedin"].ToString().Trim() + "'><i class='fa fa-linkedin'></i></a>";
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