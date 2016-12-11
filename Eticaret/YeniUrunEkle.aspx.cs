using E_Ticaret_Projesi;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eticaret
{
    public partial class YeniUrunEkle : System.Web.UI.Page
    {
        Veritabani vt = new Veritabani();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    vt.cnn.Open();
                    SqlDataAdapter adp = new SqlDataAdapter("select * from yuklenen_urun_resimleri order by id desc", vt.cnn);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    listAnaResimler.DataSource = tbl.DefaultView;
                    listAnaResimler.DataBind();

                    listDigerResimler.DataSource = tbl.DefaultView;
                    listDigerResimler.DataBind();
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

        protected void btnUrunKaydet_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            string urunOpKod = Guid.NewGuid().ToString();
            int kategoriID = Convert.ToInt32(dropdownKategoriler.SelectedItem.Value);
            string urunAdi = txtUrunAdi.Text.ToString().Trim();
            string urunFiyati = txtFiyat.Text.ToString().Trim();
            string urunAciklama = txtUrunAciklama.Text.ToString().Trim();
            int urunTipi = Convert.ToInt32(dropdownUrunTipi.SelectedItem.Value);
            //Ürünün Ana resim id si
            string anaresim = secilenAnaResim.Value.ToString().Trim();
            string anaresimAdi = secilenAnaResimAdi.Value.ToString().Trim();
            //Ürünün diğer resimlerinin id değerlerini alıyoruz
            foreach(ListViewDataItem item in listDigerResimler.Items)
            {
                CheckBox check = item.FindControl("secim") as CheckBox;
                if(check != null )
                {
                    if(check.Checked==true)
                    {
                        HiddenField id = item.FindControl("hiddenResimID") as HiddenField;
                        HiddenField adi = item.FindControl("hiddenResimAdi") as HiddenField;
                        int resim_id = Convert.ToInt32(id.Value);
                        try
                        {
                            vt.cnn.Open();
                            SqlCommand cmd = new SqlCommand("insert into urun_resimleri (resimID,resimAdi,urunOpKod,ana_resim) values ('" + resim_id + "','" + adi.Value + "','" + urunOpKod + "',0)", vt.cnn);
                            cmd.ExecuteNonQuery();
                        }
                        catch
                        {
                            Response.Write("Ürün resimleri kaydedilirken bir hata oluştu!");
                        }
                        finally
                        {

                            vt.cnn.Close();
                        }
                    }
                }
            }
            //ana ürün resmini kaydediyoruz
            try
            {
                vt.cnn.Open();
                SqlCommand cmd = new SqlCommand("insert into urun_resimleri (resimID,resimAdi,urunOpKod,ana_resim) values ('" + anaresim + "','" + anaresimAdi + "','" + urunOpKod + "',1)", vt.cnn);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Response.Write("Ana ürün resmi kaydedilirken bir hata oluştu!");
            }
            finally
            {

                vt.cnn.Close();
            }
            //ürün bilgileri kaydediliyor
            try
            {
                vt.cnn.Open();
                SqlCommand cmd = new SqlCommand("insert into urunler (kategoriID,urunAdi,urunFiyati,urunAciklama,urunTipi,urunOpKod) values ("+kategoriID+",'"+urunAdi+"','"+urunFiyati+"','"+urunAciklama+"',"+urunTipi+",'"+urunOpKod+"')", vt.cnn);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Response.Write("Ana ürün resmi kaydedilirken bir hata oluştu!");
            }
            finally
            {

                vt.cnn.Close();
            }
            //Response.Write("OpKod : "+urunOpKod+"<br>Kategori ID : "+kategoriID+"<br>Ürün Adı : "+urunAdi+"<br>Ürün Fiyatı : "+urunFiyati+"<br>Ürün Açıklama : "+urunAciklama+"<br>Ürün Tipi : "+urunTipi+"<br>Ana Resim : "+anaresim);
            Response.Redirect("~/UrunListesi.aspx");
        }
    }
}