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
    public partial class SiteAyarlari : System.Web.UI.Page
    {
        Veritabani vt = new Veritabani();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["islem"]!=null)
            {
                string durum = Request.QueryString["islem"];
                if(durum=="success")
                {
                    message.InnerHtml = "<div class='alert alert-success'><b>Başarılı!</b> Güncelleme İşlemi Başarıyla Tamamlandı.</div>";
                }
            }
            if(!Page.IsPostBack)
            {
                try
                {
                    vt.cnn.Open();
                    SqlCommand komut = new SqlCommand("select * from site_ayarlari where id=1",vt.cnn);
                    SqlDataReader oku = komut.ExecuteReader();
                    if(oku.Read())
                    {
                        txtBaslik.Text = oku["baslik"].ToString().Trim();
                        txtAnahtarKelimeler.Text = oku["anahtar_kelimeler"].ToString().Trim();
                        txtAciklama.Text = oku["aciklama"].ToString().Trim();
                        txtTelifHakki.Text = oku["telif"].ToString().Trim();
                    }else
                    {
                        Response.Write("Site Ayarları Bulunamadı!");
                    }
                }
                catch
                {
                    Response.Write("Sistem Hatası!");
                }
                finally
                {
                    vt.cnn.Close();
                }
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                vt.cnn.Open();
                SqlCommand update = new SqlCommand("update site_ayarlari set baslik='"+txtBaslik.Text.ToString().Trim()+"',anahtar_kelimeler='"+ txtAnahtarKelimeler.Text.ToString().Trim() + "',aciklama='"+ txtAciklama.Text.ToString().Trim() + "',telif='"+ txtTelifHakki.Text.ToString().Trim() + "' where id=1", vt.cnn);
                update.ExecuteNonQuery();
                Response.Redirect("~/SiteAyarlari.aspx?islem=success");
            }
            catch
            {
                Response.Write("Site ayarları güncellenemedi!");
            }
            finally
            {
                vt.cnn.Close();
            }
        }
    }
}