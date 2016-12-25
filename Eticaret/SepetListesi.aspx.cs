using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using E_Ticaret_Projesi;
using System.Data;

namespace Eticaret
{
    public partial class SepetListesi : System.Web.UI.Page
    {
        Veritabani vt = new Veritabani();
        protected void Page_Load(object sender, EventArgs e)
        {
            //sistem mesajları
            if(Request.QueryString["islem"]!=null)
            {
                string durum = Request.QueryString["islem"].ToString().Trim();
                if(durum=="success")
                {
                    message.InnerHtml = "<div class='alert alert-success'><b>Başarılı!</b> Ürün Sepetinize Eklendi.</div>";
                }else if(durum=="error")
                {
                    message.InnerHtml = "<div class='alert alert-error'><b>Uyarı!</b> Bir Hata Nedeniyle Ürün Eklenemedi.</div>";
                }
            }
            //sepetten ürün silme işlemi
            if(Request.QueryString["cikar"]!=null)
            {
                try
                {
                    int siparis = Convert.ToInt32(Request.QueryString["cikar"].ToString().Trim());
                    vt.cnn.Open();
                    SqlCommand siparis_sorgula = new SqlCommand("select * from siparisler where id="+siparis+" and onay='0' and user_key='"+Session["site_userid"].ToString().Trim() +"'",vt.cnn);
                    SqlDataReader siparis_oku = siparis_sorgula.ExecuteReader();
                    if(siparis_oku.Read())
                    {
                        siparis_oku.Close();
                        try
                        {
                            SqlCommand sil = new SqlCommand("delete from siparisler where id=" + siparis + " and onay='0' and user_key='" + Session["site_userid"].ToString().Trim() + "'", vt.cnn);
                            sil.ExecuteNonQuery();
                            message.InnerHtml = "<div class='alert alert-success'><b>Başarılı!</b> Siparişiniz Silindi.</div>";
                        }catch(Exception ex)
                        {
                            Response.Write(ex);
                            //Response.Redirect("~/Default.aspx");
                        }
                    }else
                    {
                        message.InnerHtml = "<div class='alert alert-error'><b>Uyarı!</b> Siparişiniz Bulunamadı.</div>";
                    }
                }
                catch(FormatException ex)
                {
                    message.InnerHtml = "<div class='alert alert-error'><b>Uyarı!</b> Tanımsız Bir İşlem Yapılmaya Çalışıldı.</div>";
                }
                catch(Exception ex)
                {
                    Response.Write(ex);
                    //Response.Redirect("~/Default.aspx");
                }
                finally
                {
                    vt.cnn.Close();
                }
            }

            if(Session["site_userid"]!=null)
            {
                //işlemleri yap
                try
                {
                    vt.cnn.Open();
                    SqlDataAdapter adp = new SqlDataAdapter("select urunler.id,siparisler.id as siparisid,urunAdi,urunFiyati,urunTipi,urunler.urunOpKod,resimAdi,siparisler.onay from siparisler,urunler,urun_resimleri where urunler.id=siparisler.product and urunler.urunOpKod=urun_resimleri.urunOpKod and urun_resimleri.ana_resim=1 and siparisler.onay='0' and user_key='" + Session["site_userid"].ToString().Trim() + "'", vt.cnn);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    listSepetListesi.DataSource = tbl.DefaultView;
                    listSepetListesi.DataBind();
                    if(listSepetListesi.Items.Count()==0)
                    {
                        message.InnerHtml = "<div class='alert alert-info'>Sepetinize Henüz Ürün Eklemediniz...</div>";
                        linkSiparisTamamla.Visible = false;
                    }
                    else
                    {
                        //toplam fiyatı hesaplat
                        SqlCommand toplam_fiyat = new SqlCommand("select urunFiyati from siparisler,urunler where urunler.id=siparisler.product and user_key='" + Session["site_userid"].ToString().Trim() + "'", vt.cnn);
                        SqlDataReader fiyatlar = toplam_fiyat.ExecuteReader();
                        int toplam = 0;
                        while (fiyatlar.Read())
                        {
                            toplam += Convert.ToInt32(fiyatlar["urunFiyati"].ToString().Trim());
                        }
                        txtToplam.Text = toplam.ToString()+" TL";
                    }
                }
                catch(Exception ex)
                {
                    Response.Write("Sistem Hatası ! "+ex);
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