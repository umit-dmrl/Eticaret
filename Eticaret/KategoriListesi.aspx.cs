using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace E_Ticaret_Projesi
{
    public partial class KategoriListesi : System.Web.UI.Page
    {
        Veritabani db = new Veritabani();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.QueryString["sil"] != null)
            {
                try
                {
                    string id = Request.QueryString["sil"].ToString().Trim();
                    db.cnn.Open();
                    //kayıt kontrolü
                    SqlCommand sorgula = new SqlCommand("select * from kategoriler where id=@id",db.cnn);
                    sorgula.Parameters.Add("@id",id);
                    SqlDataReader oku = sorgula.ExecuteReader();
                    if (oku.Read())
                    {
                        try
                        {
                            SqlCommand sil = new SqlCommand("delete from kategoriler where id=@id", db.cnn);
                            sil.Parameters.Add("@id", id);
                            sil.ExecuteNonQuery();
                            lblMessage.CssClass = "alert alert-success";
                            lblMessage.Text = "Kategori Başarıyla Silindi...";
                        }
                        catch
                        {
                            lblMessage.CssClass = "alert alert-danger";
                            lblMessage.Text = "Hata! Kayıt Silinirken Beklenmeyen Bir Hata Oluştu.";
                        }
                    }
                    else
                    {
                        lblMessage.CssClass = "alert alert-danger";
                        lblMessage.Text = "Uyarı! Kayıt Bulunamadığı İçin Silinemedi.";
                    }
                    db.cnn.Close();
                    
                }
                catch (Exception ex)
                {
                    lblMessage.CssClass = "alert alert-danger";
                    lblMessage.Text = "Hata! İşlem Başarısız Oldu.";
                }

            }
            else if (Request.QueryString["mesaj"] != null)
            {
                string gelen_mesaj = Request.QueryString["mesaj"];
                if (gelen_mesaj == "success")
                {
                    lblMessage.CssClass = "alert alert-success";
                    lblMessage.Text = "İşlem Başarıyla Tamamlandı...";
                }
                else if (gelen_mesaj == "error")
                {
                    lblMessage.CssClass = "alert alert-danger";
                    lblMessage.Text = "Bir Hata Nedeniyle İşlem Başarısız Oldu...";
                }
            }
            db.cnn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("select * from kategoriler",db.cnn);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            listKategori.DataSource = tbl.DefaultView;
            listKategori.DataBind();
            db.cnn.Close();
        }
    }
}