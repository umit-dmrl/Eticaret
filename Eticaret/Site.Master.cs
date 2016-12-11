using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using E_Ticaret_Projesi;
using System.Data.SqlClient;
using System.Data;

namespace Eticaret
{
    public partial class Site : System.Web.UI.MasterPage
    {
        Veritabani vt = new Veritabani();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                vt.cnn.Open();
                SqlCommand komut = new SqlCommand("select * from site_ayarlari where id=1",vt.cnn);
                SqlDataReader oku = komut.ExecuteReader();
                if(oku.Read())
                {
                    logo.InnerHtml = oku["baslik"].ToString().Trim();
                    site_title.Text = oku["baslik"].ToString().Trim();
                    site_description.Content = oku["aciklama"].ToString().Trim();
                    site_keywords.Content = oku["anahtar_kelimeler"].ToString().Trim();
                    copyright.InnerHtml = oku["telif"].ToString().Trim();
                }else
                {
                    Response.Write("Site Bilgileri Tanımlı Değil!");
                }
                oku.Close();
                //kategori listeleme
                SqlDataAdapter adp = new SqlDataAdapter("select * from kategoriler where onay='1'",vt.cnn);
                DataTable tbl = new DataTable();
                adp.Fill(tbl);
                listKategoriler.DataSource = tbl.DefaultView;
                listKategoriler.DataBind();
                //sosyal medya linkleri
                SqlCommand sosyal = new SqlCommand("select facebook,twitter,instagram,linkedin from site_iletisim_bilgileri where id=1",vt.cnn);
                SqlDataReader sosyal_oku = sosyal.ExecuteReader();
                if(sosyal_oku.Read())
                {
                    icon_facebook.InnerHtml = "<a target='_blank' href='"+sosyal_oku["facebook"].ToString().Trim()+"'><i class='fa fa-facebook'></i></a>";
                    icon_twitter.InnerHtml = "<a target='_blank' href='" + sosyal_oku["twitter"].ToString().Trim() + "'><i class='fa fa-twitter'></i></a>";
                    icon_instagram.InnerHtml = "<a target='_blank' href='" + sosyal_oku["instagram"].ToString().Trim() + "'><i class='fa fa-instagram'></i></a>";
                    icon_linkedin.InnerHtml = "<a target='_blank' href='" + sosyal_oku["linkedin"].ToString().Trim() + "'><i class='fa fa-linkedin'></i></a>";
                }
            }
            catch(Exception ex)
            {
                Response.Write("Sistem Hatası! Site Düzgün Çalışmıyor..."+ex);
            }
            finally
            {
                vt.cnn.Close();
            }
        }
    }
}