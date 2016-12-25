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
    public partial class Kategori : System.Web.UI.Page
    {
        Veritabani vt = new Veritabani();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["id"]!=null)
            {
                try
                {
                    int id = Convert.ToInt32(Request.QueryString["id"].ToString().Trim());
                    vt.cnn.Open();
                    SqlCommand komut = new SqlCommand("select * from kategoriler where onay='1' and id=" + id, vt.cnn);
                    SqlDataReader oku = komut.ExecuteReader();
                    if (oku.Read())
                    { 
                        page_title.InnerHtml = "<div class='content-title'>Anasayfa <i class='fa fa-arrow-circle-o-right'></i> "+oku["kategoriAdi"].ToString().Trim()+"</div>";
                    }
                    else
                    {
                        message.InnerHtml = "<div class='alert alert-danger'><i class='fa fa-warning'></i> Kategori Bulunamadı!</div>";
                    }
                    oku.Close();
                    SqlDataAdapter urunler = new SqlDataAdapter("select urunler.id,urunAdi,urunFiyati,urunTipi,resimAdi from urunler,urun_resimleri where urunler.urunOpKod=urun_resimleri.urunOpKod and urun_resimleri.ana_resim=1 and urunler.kategoriID=" + id+" order by urunler.id desc", vt.cnn);
                    DataTable tbl = new DataTable();
                    urunler.Fill(tbl);
                    listUrunler.DataSource = tbl.DefaultView;
                    listUrunler.DataBind();
                    if(listUrunler.Items.Count()==0)
                    {
                        message.InnerHtml = "<div class='alert alert-danger'><i class='fa fa-warning'></i> Bu Kategoriye Henüz Ürün Eklenmedi!</div>";
                    }
                }
                catch (FormatException ex)
                {
                    Response.Redirect("~/Default.aspx");
                }
                catch (Exception ex)
                {
                    Response.Write("Sistem Hatası!" + ex);
                    //Response.Redirect("~/Default.aspx");
                }
                finally
                {
                    vt.cnn.Close();
                }
            }else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}