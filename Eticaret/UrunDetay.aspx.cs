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
    public partial class UrunDetay : System.Web.UI.Page
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
                    SqlCommand urun = new SqlCommand("select * from urunler,kategoriler where urunler.kategoriID=kategoriler.id and urunler.id=" + id,vt.cnn);
                    SqlDataReader oku = urun.ExecuteReader();
                    if(oku.Read())
                    {
                        lblKategoriAdi.Text = oku["kategoriAdi"].ToString().Trim();
                        if(oku["urunTipi"].ToString().Trim()=="1")
                        {
                            lblTipi.Text = "Normal Ürün";
                        }else if(oku["urunTipi"].ToString().Trim() == "2")
                        {
                            lblTipi.Text = "İndirimli Ürün";
                        }
                        else if (oku["urunTipi"].ToString().Trim() == "3")
                        {
                            lblTipi.Text = "Kapmanyalı Ürün";
                        }
                        else if (oku["urunTipi"].ToString().Trim() == "4")
                        {
                            lblTipi.Text = "Test Ürünü";
                        }
                        lblUrunAdi.Text = oku["urunAdi"].ToString().Trim();
                        Page.Title = oku["urunAdi"].ToString().Trim();
                        lblFiyati.Text = oku["urunFiyati"].ToString().Trim() + " TL";
                        btnLink.InnerHtml = "<a class='btn btn-success' href='SepeteEkle.aspx?product="+id+ "'><i class='fa fa-shopping-basket'></i> Sepete Ekle</a>";
                        oku.Close();
                        //ürün resimlerinin gösterimi
                        SqlDataAdapter adp = new SqlDataAdapter("select resimAdi,ana_resim from urunler,urun_resimleri where ana_resim=0 and urunler.urunOpKod=urun_resimleri.urunOpKod and urunler.id="+id,vt.cnn);
                        DataTable tbl = new DataTable();
                        adp.Fill(tbl);
                        listResimler.DataSource = tbl.DefaultView;
                        listResimler.DataBind();
                        //ana ürün resmi gösterimi
                        SqlDataAdapter adp2 = new SqlDataAdapter("select resimAdi,ana_resim from urunler,urun_resimleri where ana_resim=1 and urunler.urunOpKod=urun_resimleri.urunOpKod and urunler.id=" + id, vt.cnn);
                        DataTable tbl2 = new DataTable();
                        adp2.Fill(tbl2);
                        listAnaResim.DataSource = tbl2.DefaultView;
                        listAnaResim.DataBind();
                    }
                    else
                    {
                        message.InnerHtml = "<div class='alert alert-danger'><b>Uyarı!</b> Aradığınız Ürün Bulunamadı...</div>";
                    }
                }catch(FormatException ex)
                {
                    Response.Redirect("~/Default.aspx");
                }
                catch(Exception ex)
                {
                    //Response.Redirect("~/Default.aspx");
                    Response.Write(ex);
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