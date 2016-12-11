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
    public partial class UrunDuzenle : System.Web.UI.Page
    {
        Veritabani vt = new Veritabani();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    try
                    {
                        vt.cnn.Open();
                        SqlCommand komut = new SqlCommand("select * from urunler,kategoriler where urunler.kategoriID=kategoriler.id and urunler.id=" + id, vt.cnn);
                        SqlDataReader kayitlar = komut.ExecuteReader();
                        string opkod = "";
                        if (kayitlar.Read())
                        {
                            hiddenProductID.Value = kayitlar["id"].ToString().Trim();
                            hiddenKey.Value = kayitlar["urunOpKod"].ToString().Trim();
                            dropdownKategoriler.SelectedValue = kayitlar[7].ToString().Trim();
                            txtUrunAdi.Text = kayitlar["urunAdi"].ToString().Trim();
                            txtFiyat.Text = kayitlar["urunFiyati"].ToString().Trim();
                            txtUrunAciklama.Text = kayitlar["urunAciklama"].ToString().Trim();
                            if (kayitlar["urunTipi"].ToString().Trim() == "1")
                            {
                                dropdownUrunTipi.SelectedValue = "1";
                            }
                            else if (kayitlar["urunTipi"].ToString().Trim() == "2")
                            {
                                dropdownUrunTipi.SelectedValue = "2";
                            }
                            else if (kayitlar["urunTipi"].ToString().Trim() == "3")
                            {
                                dropdownUrunTipi.SelectedValue = "3";
                            }
                            else if (kayitlar["urunTipi"].ToString().Trim() == "4")
                            {
                                dropdownUrunTipi.SelectedValue = "4";
                            }
                            //ürün resimleri
                            opkod = kayitlar["urunOpKod"].ToString().Trim();
                            kayitlar.Close();

                            SqlDataAdapter adp2 = new SqlDataAdapter("select * from yuklenen_urun_resimleri order by id desc", vt.cnn);
                            DataTable tbl2 = new DataTable();
                            adp2.Fill(tbl2);
                            listAnaResimler.DataSource = tbl2.DefaultView;
                            listAnaResimler.DataBind();

                            listDigerResimler.DataSource = tbl2.DefaultView;
                            listDigerResimler.DataBind();
                        }
                        else
                        {
                            Response.Redirect("~/UrunListesi.aspx");
                        }
                        //seçilmiş olan ana ürün resmi için
                        SqlCommand resimler = new SqlCommand("select * from urun_resimleri where urunOpKod='" + opkod + "'", vt.cnn);
                        SqlDataReader resimleri_oku = resimler.ExecuteReader();
                        string diger_resimler = "";
                        while (resimleri_oku.Read())
                        {
                            if (bool.Parse(resimleri_oku["ana_resim"].ToString()) == true && resimleri_oku["resimAdi"].ToString().Trim() == "no_image")
                            {
                                secilenResimGorunum.InnerHtml = "<img src='assets/images/no-image-thumb.png'  style='width:100px; height:100px;' />";
                            }
                            else if (bool.Parse(resimleri_oku["ana_resim"].ToString()) == true)
                            {
                                secilenAnaResim.Value = resimleri_oku["resimID"].ToString().Trim();
                                secilenAnaResimAdi.Value = resimleri_oku["resimAdi"].ToString().Trim();
                                secilenResimGorunum.InnerHtml = "<img src='upload/" + resimleri_oku["resimAdi"].ToString().Trim() + "'  style='width:100px; height:100px;' />";
                            }
                            /*else
                            {
                                diger_resimler += "<img src='upload/" + resimleri_oku["resimAdi"].ToString().Trim() + "'  style='width:70px; height:70px;' /> ";
                            }*/
                        }
                        resimleri_oku.Close();
                        //secilenDigerUrunResimleri.InnerHtml = diger_resimler;
                        //seçilmiş olan diğer ürün resimleri için
                        SqlDataAdapter adp = new SqlDataAdapter("select * from urun_resimleri where urunOpKod='" + opkod + "' and ana_resim=0", vt.cnn);
                        DataTable tbl = new DataTable();
                        adp.Fill(tbl);
                        listviewSecilenDigerResimler.DataSource = tbl.DefaultView;
                        listviewSecilenDigerResimler.DataBind();
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Sistem Hatası!<br>" + ex);
                    }
                    finally
                    {
                        vt.cnn.Close();
                    }
                }
            }
        }

        protected void btnUrunKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                int kategori = Convert.ToInt32(dropdownKategoriler.SelectedValue.ToString().Trim());
                string urunAdi = txtUrunAdi.Text.ToString().Trim();
                string urunFiyati = txtFiyat.Text.ToString().Trim();
                string urunAciklama = txtUrunAciklama.Text.ToString().Trim();
                int urunTipi = Convert.ToInt32(dropdownUrunTipi.SelectedValue.ToString().Trim());

                vt.cnn.Open();
                SqlCommand update = new SqlCommand("update urunler set kategoriID="+kategori+" , urunAdi='"+urunAdi+"' , urunFiyati='"+urunFiyati+"' , urunAciklama='"+urunAciklama+"' , urunTipi="+urunTipi+" where id="+hiddenProductID.Value,vt.cnn);
                update.ExecuteNonQuery();
                Response.Write("ürün bilgileri güncellendi.<br>");

                //ana ürün resmini güncelleme
                SqlCommand ana_resimUpdate = new SqlCommand("update urun_resimleri set resimID="+secilenAnaResim.Value+" , resimAdi='"+secilenAnaResimAdi.Value+"' where urunOpKod='"+hiddenKey.Value+"' and ana_resim=1",vt.cnn);
                ana_resimUpdate.ExecuteNonQuery();
                Response.Write("ana resim güncellendi.");

                //diğer ürün resimleri ekleme
                foreach(ListViewDataItem item in listDigerResimler.Items)
                {
                    CheckBox check = item.FindControl("secim") as CheckBox;
                    if(check != null)
                    {
                        if(check.Checked==true)
                        {
                            HiddenField id = item.FindControl("hiddenResimID") as HiddenField;
                            HiddenField adi = item.FindControl("hiddenResimAdi") as HiddenField;
                            int resimID = Convert.ToInt32(id.Value);
                            try
                            {
                                SqlCommand cmd = new SqlCommand("insert into urun_resimleri (resimID,resimAdi,urunOpKod,ana_resim) values ('" + resimID + "','" + adi.Value + "','" + hiddenKey.Value + "',0)", vt.cnn);
                                cmd.ExecuteNonQuery();
                            }
                            catch(Exception ex)
                            {
                                Response.Write("Ürün resimleri kaydedilirken bir hata oluştu!<br>");
                            }
                        }
                    }
                }
                Response.Redirect("~/UrunListesi.aspx?islem=success");
            }
            catch(Exception ex)
            {
                Response.Write("Sistem Hatası! Ürün Güncelleme Yaparken Hata Bulundu...<br>");
            }
            finally
            {
                vt.cnn.Close();
            }
        }
    }
}