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
    public partial class AdminSiparisListele : System.Web.UI.Page
    {
        Veritabani vt = new Veritabani();
        protected void Page_Load(object sender, EventArgs e)
        {
            //sipariş silme
            if(Request.QueryString["sil"] != null)
            {
                try
                {
                    vt.cnn.Open();
                    int id = Convert.ToInt32(Request.QueryString["sil"].ToString().Trim());
                    SqlCommand sorgula = new SqlCommand("select * from siparis_bilgileri where id=" + id,vt.cnn);
                    SqlDataReader sonuc = sorgula.ExecuteReader();
                    string user_key = "";
                    if(sonuc.Read())
                    {
                        user_key = sonuc["user_key"].ToString();
                        sonuc.Close();
                        try
                        {
                            SqlCommand siparis_bilgisi_sil = new SqlCommand("delete from siparis_bilgileri where id=" + id, vt.cnn);
                            siparis_bilgisi_sil.ExecuteNonQuery();
                            SqlCommand siparis_sil = new SqlCommand("delete from siparisler where user_key='"+user_key+"'",vt.cnn);
                            siparis_sil.ExecuteNonQuery();
                            message.InnerHtml = "<div class='alert alert-success'><i class='fa fa-check'></i> Sipariş Silindi.</div>";
                        }
                        catch(Exception ex)
                        {
                            message.InnerHtml = "<div class='alert alert-error'><i class='fa fa-warning'></i> Silme işlemi sırasında hata oluştu.</div>";
                            //Response.Write("silme : "+ex);
                        }
                    }else
                    {
                        message.InnerHtml = "<div class='alert alert-error'><i class='fa fa-warning'></i> Sipariş Bulunamadı.</div>";
                    }
                }catch(FormatException ex)
                {
                    message.InnerHtml = "<div class='alert alert-error'><i class='fa fa-warning'></i> Uygunsuz Bir İşlem Geldiği İçin İşlem Yapılamadı.</div>";
                }
                catch(Exception ex)
                {
                    //Response.Write(ex);
                    message.InnerHtml = "<div class='alert alert-error'><i class='fa fa-warning'></i> Sipariş silinirken hata oluştu.</div>";
                }
                finally
                {
                    vt.cnn.Close();
                }
            }
            //siparişleri listeleme
            try
            {
                vt.cnn.Open();
                SqlDataAdapter adp = new SqlDataAdapter("select id,user_key,adsoyad,tel,email,onayKodu from siparis_bilgileri order by id desc",vt.cnn);
                DataTable tbl = new DataTable();
                adp.Fill(tbl);
                listSiparisler.DataSource = tbl.DefaultView;
                listSiparisler.DataBind();
            }
            catch(Exception ex)
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