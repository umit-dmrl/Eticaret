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
    public partial class IletisimBilgileriGuncelle : System.Web.UI.Page
    {
        Veritabani vt = new Veritabani();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["islem"]!=null)
            {
                string durum = Request.QueryString["islem"];
                if(durum=="success")
                {
                    message.InnerHtml = "<div class='alert alert-success'><b>Başarılı!</b> İşlem Başarıyla Tamamlandı.</div>";
                }else if(durum=="error")
                {
                    message.InnerHtml = "<div class='alert alert-error'><b>Hata!</b> Bir Hata Nedeniyle İşlem Başarısız Oldu.</div>";
                }else if(durum== "notfound")
                {
                    message.InnerHtml = "<div class='alert alert-error'><b>Hata!</b> İletişim Bilgileri Bulunamadı.</div>";
                }
            }
            if(!Page.IsPostBack)
            {
                try
                {
                    vt.cnn.Open();
                    SqlCommand komut = new SqlCommand("select * from site_iletisim_bilgileri where id=1",vt.cnn);
                    SqlDataReader oku = komut.ExecuteReader();
                    if(oku.Read())
                    {
                        txtTel.Text = oku["tel"].ToString().Trim();
                        txtGSM.Text = oku["gsm"].ToString().Trim();
                        txtFax.Text = oku["fax"].ToString().Trim();
                        txtAdres.Text = oku["adres"].ToString().Trim();
                        txtMaps.Text = oku["maps"].ToString().Trim();
                        txtFacebook.Text = oku["facebook"].ToString().Trim();
                        txtTwitter.Text = oku["twitter"].ToString().Trim();
                        txtInstagram.Text = oku["instagram"].ToString().Trim();
                        txtLinkedin.Text = oku["linkedin"].ToString().Trim();
                    }
                    else
                    {
                        Response.Redirect("~/IletisimBilgileriGuncelle.aspx?islem=notfound");
                    }
                }
                catch
                {
                    Response.Redirect("~/IletisimBilgileriGuncelle.aspx?islem=error");
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
                SqlCommand update = new SqlCommand("update site_iletisim_bilgileri set tel='"+txtTel.Text.ToString().Trim()+"',gsm='"+ txtGSM.Text.ToString().Trim() + "',fax='"+ txtFax.Text.ToString().Trim() + "',adres='"+ txtAdres.Text.ToString().Trim() + "',maps='"+ txtMaps.Text.ToString().Trim() + "',facebook='"+ txtFacebook.Text.ToString().Trim() + "',twitter='"+ txtTwitter.Text.ToString().Trim() + "',instagram='"+ txtInstagram.Text.ToString().Trim() + "',linkedin='"+ txtLinkedin.Text.ToString().Trim() + "' where id=1", vt.cnn);
                update.ExecuteNonQuery();
                Response.Redirect("~/IletisimBilgileriGuncelle.aspx?islem=success");
            }
            catch(Exception ex)
            {
                Response.Write(ex);
                //Response.Redirect("~/IletisimBilgileriGuncelle.aspx?islem=error");
            }
            finally
            {
                vt.cnn.Close();
            }
        }
    }
}