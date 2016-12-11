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
    public partial class _UrunResmiSil : System.Web.UI.Page
    {
        Veritabani vt = new Veritabani();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if(Request.QueryString["id"]!=null && Request.QueryString["adi"] != null && Request.QueryString["key"] != null && Request.QueryString["product"]!=null)
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    string adi = Request.QueryString["adi"];
                    string key = Request.QueryString["key"];
                    try
                    {
                        vt.cnn.Open();
                        SqlCommand komut = new SqlCommand("select * from urun_resimleri where id="+id+" and resimAdi='"+adi+"' and urunOpKod='"+key+"'",vt.cnn);
                        SqlDataReader reader = komut.ExecuteReader();
                        
                        if (reader.Read())
                        {
                            //kayıt bulunduysa resim silinebilir
                            try
                            {
                                reader.Close();
                                SqlCommand sil = new SqlCommand("delete from urun_resimleri where id=" + id + " and resimAdi='" + adi + "' and urunOpKod='" + key + "'", vt.cnn);
                                sil.ExecuteNonQuery();
                                Response.Redirect("~/UrunDuzenle.aspx?id="+Request.QueryString["product"]);
                            }catch(Exception ex)
                            {
                                Response.Write("Resim Silinirken Bir Hata Oldu!<br>"+ex);
                            }
                           
                        }
                        else
                        {
                            Response.Write("Gelen Parametreler Doğrultusunda Bir Kayıt Bulunamadı!<br><a href='javascript:history.back();'>Geri Git</a>");
                        }
                        
                    }
                    catch(Exception ex)
                    {
                        Response.Write("Sistem Hatası : <br>"+ex);
                    }
                    finally
                    {
                        vt.cnn.Close();
                    }
                }
                else
                {
                    Response.Redirect("~/UrunListesi.aspx");
                }
            }
        }
    }
}